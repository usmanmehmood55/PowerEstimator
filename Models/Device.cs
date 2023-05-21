namespace PowerEstimator
{
    internal class Device
    {
        public List<Load> Loads { get; set; }
        public Source Source { get; set; }
        public TimeSpan ActiveTimePerDay { get; set; }
        public TimeSpan CycleTime { get; set; }

        public Device(List<Load> loads, Source source, TimeSpan cycleTIme, TimeSpan activeHours)
        {
            Loads            = loads;
            Source           = source;
            CycleTime        = cycleTIme;
            ActiveTimePerDay = activeHours;
        }

        public Device()
        {
            Loads  = new List<Load>();
            Source = new Source();
        }

        public double GetTotalDrawAmpHours()
        {
            double totalCurrentDraw = 0;

            foreach (Load load in Loads)
            {
                totalCurrentDraw += load.GetTotalDrawAmpHours();
            }

            return totalCurrentDraw;
        }

        public TimeSpan GetEndurance()
        {
            var totalDrawAmpHours = GetTotalDrawAmpHours();
            double ampsPerCycle = totalDrawAmpHours / CycleTime.TotalHours;
            double ampsPerDay = ampsPerCycle * ActiveTimePerDay.TotalHours;

            double batteryLifeHours = (Source.CapacityAmpHours * 24) / ampsPerDay;

            TimeSpan batteryLife;
            try
            {
                batteryLife = TimeSpan.FromHours(batteryLifeHours);
            }
            catch (OverflowException)
            {
                batteryLife = TimeSpan.Zero;
            }

            return batteryLife;
        }
    }
}
