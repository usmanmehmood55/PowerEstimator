namespace PowerEstimator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            _ = args;

            TimeSpan cycleTime = TimeSpan.FromSeconds(5);

            Load controller = new()
            {
                ActiveDrawMilliAmps = 4,
                ActiveDuration      = TimeSpan.FromMilliseconds(75),
                SleepDrawMicroAmps  = 13,
                SleepDuration       = cycleTime,
            };

            Load regulator = new()
            {
                SleepDrawMicroAmps  = 10,
                SleepDuration       = cycleTime,
            };

            Source battery = new()
            {
                CapacityMilliAmpHours = 2200,
                VoltageVolts          = 3.16,
            };

            Device device = new()
            {
                Loads            = new List<Load> { controller, regulator },
                Source           = battery,
                ActiveTimePerDay = TimeSpan.FromHours(23),
                CycleTime        = cycleTime,
            };

            TimeSpan batteryLife = device.GetEndurance();
            Console.WriteLine($"Estimated battery life: {(batteryLife.TotalDays / 365).ToString()} years");  // gives 3.157 years
        }
    }
}
