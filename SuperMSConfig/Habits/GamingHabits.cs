using Microsoft.Win32;
using SuperMSConfig;
using System;

public class GamingHabits : BaseHabitCategory
{
    private readonly Logger logger;

    public override string CategoryName => "Gaming";

    public GamingHabits(Logger logger)
    {
        this.logger = logger;

        // Disable VBS (Virtualization-Based Security)
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.LocalMachine,
            @"SYSTEM\CurrentControlSet\Control\DeviceGuard",
            "EnableVirtualizationBasedSecurity",
            1,  // Bad value (enabled)
            0,  // Good value (disabled)
            "Disable Virtualization-Based Security " +
            "(This feature is known for hogging system resources." +
            "Disabling it frees up CPU cycles and ensures your games run smoother, " +
            "with less overhead dragging down performance making your gaming experience feel sluggish)",
            "DWORD",
             logger
        ));

        // Disable Core Isolation / Memory Integrity
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.LocalMachine,
            @"SYSTEM\CurrentControlSet\Control\DeviceGuard\Scenarios\HypervisorEnforcedCodeIntegrity",
            "Enabled",
            1,  // Bad value (enabled)
            0,  // Good value (disabled)
            "Disable Memory Integrity for better gaming FPS (Core Isolation)",
            "DWORD", logger
        ));
    }
}