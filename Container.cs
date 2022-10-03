using System;
using System.Collections.Generic;
using EspMon;

namespace EspMon
{
    public class Container
    {
        public Dictionary<PartType, Dictionary<MetricType, float>> Data = new();

        public Container()
        {
            foreach (var part in (PartType[])Enum.GetValues(typeof(PartType)))
            {
                Data.Add(part, GetMetricsForPart(part));
            }
        }

        private static Dictionary<MetricType, float> GetMetricsForPart(PartType part)
        {
            var result = new Dictionary<MetricType, float>
            {
                { MetricType.Temperature, 0 },
                { MetricType.UsagePercentage, 0 },
                { MetricType.FrequencyHz, 0 }
            };

            switch (part)
            {
                case PartType.Processor:
                    result.Add(MetricType.PowerDrawWatts, 0);
                    break;
                case PartType.GraphicsCard:
                    result.Add(MetricType.PowerDrawWatts, 0);
                    result.Add(MetricType.VideoMemoryFrequencyHz, 0);
                    break;
            }

            return result;
        }
    }
}