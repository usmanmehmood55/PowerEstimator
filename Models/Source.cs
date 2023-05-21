namespace PowerEstimator
{
    internal class Source
    {
        public double CapacityAmpHours { get; set; }
        public double CapacityMilliAmpHours
        {
            get { return CapacityAmpHours * 1000.0; }
            set { CapacityAmpHours = value / 1000.0; }
        }

        public double VoltageVolts { get; set; }
        public double VoltageMilliVolts
        {
            get { return VoltageVolts * 1000.0; }
            set { VoltageVolts = value / 1000.0; }
        }

        public Source() { }

        public Source(double capacityMilliAmpHours, double voltageVolts)
        {
            CapacityMilliAmpHours = capacityMilliAmpHours;
            VoltageVolts          = voltageVolts;
        }
    }
}