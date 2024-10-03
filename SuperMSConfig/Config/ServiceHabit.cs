using Microsoft.Win32;
using System;
using System.Drawing;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace SuperMSConfig
{
    public class ServiceHabit : BaseHabit
    {
        private readonly string serviceName;
        private readonly string description;
        private readonly Logger logger;
        private readonly int badValue;

        public ServiceHabit(string serviceName, string description, Logger logger, int badValue)
        {
            this.serviceName = serviceName;
            this.description = description;
            this.logger = logger;
            this.badValue = badValue;
            Status = HabitStatus.NotConfigured; // Initial status
        }

        public override string Name => $"Service: {serviceName}";
        public override string Description => description;

        public override HabitStatus Status { get; set; }

        public override async Task Check()
        {
            try
            {
                logger.Log($"Checking service '{serviceName}'...", Color.Blue);

                ServiceControllerStatus status = CheckServiceStatus();
                if ((badValue == 1 && status == ServiceControllerStatus.Running) ||
                    (badValue == 0 && status != ServiceControllerStatus.Running))
                {
                    Status = HabitStatus.Bad;
                }
                else
                {
                    Status = HabitStatus.Good;
                }

                logger.Log($"{serviceName} status: {(Status == HabitStatus.Bad ? "Bad" : "Good")}.", Status == HabitStatus.Bad ? Color.Red : Color.Green);
            }
            catch (Exception ex)
            {
                logger.Log($"Error during Check: {ex.Message}", Color.Red, ex.StackTrace);
                Status = HabitStatus.NotConfigured; // Set status to NotConfigured in case of error
            }
        }

        private ServiceControllerStatus CheckServiceStatus()
        {
            try
            {
                using (var service = new ServiceController(serviceName))
                {
                    service.Refresh();
                    return service.Status;
                }
            }
            catch (InvalidOperationException ex)
            {
                logger.Log($"Service '{serviceName}' not found: {ex.Message}", Color.Red);
                Status = HabitStatus.NotConfigured; // Set status to NotConfigured if the service is not found
                return ServiceControllerStatus.Stopped;
            }
            catch (Exception ex)
            {
                logger.Log($"Error checking status of '{serviceName}': {ex.Message}", Color.Red);
                Status = HabitStatus.NotConfigured; // Set status to NotConfigured if there is a general error
                return ServiceControllerStatus.Stopped;
            }
        }

        public override async Task Fix()
        {
            try
            {
                if (Status == HabitStatus.Bad)
                {
                    logger.Log($"Stopping service '{serviceName}' and setting to manual...", Color.Blue);
                    await Task.Run(() =>
                    {
                        using (var service = new ServiceController(serviceName))
                        {
                            if (service.Status != ServiceControllerStatus.Stopped)
                            {
                                service.Stop();
                                service.WaitForStatus(ServiceControllerStatus.Stopped);
                                logger.Log($"Service '{serviceName}' stopped successfully.", Color.Green);
                            }
                            else
                            {
                                logger.Log($"Service '{serviceName}' is already stopped.", Color.Orange);
                            }

                            SetServiceStartType(serviceName, 3); // 3 means Manual
                        }
                    });
                }
            }
            catch (InvalidOperationException ex)
            {
                logger.Log($"Service '{serviceName}' not found or cannot be stopped: {ex.Message}", Color.Red);
            }
            catch (Exception ex)
            {
                logger.Log($"Error stopping service '{serviceName}': {ex.Message}", Color.Red);
            }
        }

        public override async Task Revert()
        {
            try
            {
                if (Status == HabitStatus.Good)
                {
                    logger.Log($"Starting service '{serviceName}' and setting to automatic...", Color.Blue);
                    await Task.Run(() =>
                    {
                        using (var service = new ServiceController(serviceName))
                        {
                            if (service.Status != ServiceControllerStatus.Running)
                            {
                                service.Start();
                                service.WaitForStatus(ServiceControllerStatus.Running);
                                logger.Log($"Service '{serviceName}' started successfully.", Color.Green);
                            }
                            else
                            {
                                logger.Log($"Service '{serviceName}' is already running.", Color.Orange);
                            }

                            SetServiceStartType(serviceName, 2); // 2 means Automatic
                        }
                    });
                }
            }
            catch (InvalidOperationException ex)
            {
                logger.Log($"Service '{serviceName}' not found or cannot be started: {ex.Message}", Color.Red);
            }
            catch (Exception ex)
            {
                logger.Log($"Error starting service '{serviceName}': {ex.Message}", Color.Red);
            }
        }

        private void SetServiceStartType(string serviceName, int startType)
        {
            try
            {
                string keyPath = $@"SYSTEM\CurrentControlSet\Services\{serviceName}";
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(keyPath, writable: true))
                {
                    if (key != null)
                    {
                        key.SetValue("Start", startType, RegistryValueKind.DWord);
                        logger.Log($"Service '{serviceName}' start type set to {(startType == 2 ? "Automatic" : "Manual")}.", Color.Green);
                    }
                    else
                    {
                        logger.Log($"Failed to find registry key for service '{serviceName}'.", Color.Red);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Log($"Error setting service start type: {ex.Message}", Color.Red);
            }
        }

        public override string GetDetails()
        {
            ServiceControllerStatus status = CheckServiceStatus();
            return $"Service Name: {serviceName}, Description: {description}, Status: {status}";
        }
    }
}
