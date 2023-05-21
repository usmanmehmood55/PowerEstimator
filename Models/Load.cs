namespace PowerEstimator
{
    internal class Load
    {
        #region ActiveDraw
        public double ActiveDrawAmps { get; set; }

        public double ActiveDrawMilliAmps
        {
            get { return ActiveDrawAmps * 1000.0; }
            set { ActiveDrawAmps = value / 1000.0; }
        }

        public double ActiveDrawMicroAmps 
        {
            get { return ActiveDrawMilliAmps * 1000.0; }
            set { ActiveDrawMilliAmps = value / 1000.0; } 
        }
        #endregion

        #region SleepDraw
        public double SleepDrawAmps { get; set; }

        public double SleepDrawMilliAmps
        {
            get { return SleepDrawAmps * 1000.0; }
            set { SleepDrawAmps = value / 1000.0; }
        }

        public double SleepDrawMicroAmps
        {
            get { return SleepDrawMilliAmps * 1000.0; }
            set { SleepDrawMilliAmps = value / 1000.0; }
        }
        #endregion

        public TimeSpan SleepDuration { get; set; }

        public TimeSpan ActiveDuration { get; set; }

        public Load() { }

        public double GetTotalDrawAmpHours()
        {
            double activeCurrentHours = ActiveDuration.TotalHours * ActiveDrawAmps;
            double sleepCurrentHours = SleepDuration.TotalHours * SleepDrawAmps;
            double totalCurrentDraw = activeCurrentHours + sleepCurrentHours;
            return totalCurrentDraw;
        }

        public double GetTotalDrawMilliAmpHours() => GetTotalDrawAmpHours() * 1000.0;
    }
}
