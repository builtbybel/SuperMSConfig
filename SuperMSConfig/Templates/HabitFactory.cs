using Microsoft.Win32;
using SuperMSConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templates;

namespace Templates
{
    public class HabitFactory
    {
        public BaseHabit CreateHabit(HabitTemplate template, Logger logger)
        {
            switch (template.Type)
            {
                case "RegistryHabit":
                    var hive = (RegistryHive)Enum.Parse(typeof(RegistryHive), template.Hive);
                    var valueType = template.ValueType ?? "DWORD"; // Default to "Dword" if not specified
                    return new RegistryHabit(
                        hive,
                        template.Key,
                        template.ValueName,
                        template.BadValue,
                        template.GoodValue,
                        template.Description,
                        valueType,
                        logger);

                case "StartupHabit":
                    return new StartupHabit(template.AppName, template.Description, logger);
                case "ServiceHabit":
                    // Convert BadValue to int, assuming it's always numeric
                    return new ServiceHabit(template.ServiceName, template.Description, logger, Convert.ToInt32(template.BadValue));

                case "AppsHabit":
                    return new AppsHabit(template.AppName, template.Description, logger);

                default:
                    throw new ArgumentException($"Unknown habit type: {template.Type}");
            }
        }
    }
}