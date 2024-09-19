using Microsoft.Win32;
using SuperMSConfig;
using System;

public class PrivacyHabits : BaseHabitCategory
{
    private readonly Logger logger;

    public override string CategoryName => "Privacy";

    public PrivacyHabits(Logger logger)
    {
        this.logger = logger;

        // Disable diagnostic data collection
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.LocalMachine,
            @"Software\Policies\Microsoft\Windows\DataCollection",
            "AllowTelemetry",
            2,  // Bad Enhanced data collection (full)
            1,  // Recommended for home users / Minimal data collection (basic)
            "Enable basic telemetry data collection for Home/Pro editions",
            "DWORD",
            logger));

        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.LocalMachine,
            @"Software\Policies\Microsoft\Windows\DataCollection",
            "AllowTelemetry",
            1,  // Bad value (enabled)
            0,  // Disable telemetry (only for Enterprise, Education, Server)
            "Disable telemetry data collection for enterprise-level privacy",
            "DWORD",
            logger));


        // Disable personalized advertising
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.CurrentUser,
            @"Software\Microsoft\Windows\CurrentVersion\AdvertisingInfo",
            "Enabled",
            1,  // Bad value (enabled)
            0,  // Good value (disabled)
            "Disable personalized advertising (prevents Windows from showing targeted ads)",
            "DWORD",
            logger));

        // Disable activity history
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.CurrentUser,
            @"Software\Microsoft\Windows\CurrentVersion\Privacy",
            "ActivityHistoryEnabled",
            1,  // Bad value (enabled)
            0,  // Good value (disabled)
            "Disable activity history (prevents Windows from tracking and storing your activity)",
            "DWORD",
            logger));

        // Disable location tracking
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.CurrentUser,
            @"Software\Microsoft\Windows\CurrentVersion\LocationAndSensors",
            "LocationEnabled",
            1,  // Bad value (enabled)
            0,  // Good value (disabled)
            "Disable location tracking (prevents Windows from accessing your location)",
            "DWORD",
            logger));

        // Disable background apps
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.CurrentUser,
            @"Software\Microsoft\Windows\CurrentVersion\BackgroundAccessApplications",
            "Disabled",
            1,  // Bad value (enabled)
            0,  // Good value (disabled)
            "Disable background apps (prevents apps from running in the background)",
            "DWORD",
            logger));

        // Disable automatic app updates
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.CurrentUser,
            @"Software\Microsoft\Windows\CurrentVersion\WindowsStore\WindowsUpdate",
            "AutoDownload",
            1,  // Bad value (enabled)
            0,  // Good value (disabled)
            "Disable automatic app updates (prevents apps from updating automatically)",
            "DWORD",
            logger));

        // Disable sending of feedback and error reports
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.CurrentUser,
            @"Software\Microsoft\Windows\CurrentVersion\Feedback",
            "EnableFeedback",
            0,  // Bad value (enabled)
            1,  // Good value (disabled)
            "Disable sending of feedback and error reports (prevents sending feedback to Microsoft)",
            "DWORD",
            logger));

        // Disable camera access
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.CurrentUser,
            @"Software\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\camera",
            "Value",
            "Allow",  // Bad value (Allow)
            "Deny",   // Good value (Deny)
            "Disable camera access (prevents apps from using your camera)",
            "STRING",
            logger));

        // Disable microphone access
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.CurrentUser,
            @"Software\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\microphone",
            "Value",
            "Allow",  // Bad value (Allow)
            "Deny",   // Good value (Deny)
            "Disable microphone access (prevents apps from using your microphone)",
            "STRING",
            logger));

        // Disable location access
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.CurrentUser,
            @"Software\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\location",
            "Value",
            "Allow",  // Bad value (Allow)
            "Deny",   // Good value (Deny)
            "Disable location access (prevents apps from using your location)",
            "STRING",
            logger));

        // Disable contacts access
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.CurrentUser,
            @"Software\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\contacts",
            "Value",
            "Allow",  // Bad value (Allow)
            "Deny",   // Good value (Deny)
            "Disable contacts access (prevents apps from using your contacts)",
             "STRING",
            logger));

        // Disable calendar access
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.CurrentUser,
            @"Software\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\calendar",
            "Value",
            "Allow",  // Bad value (Allow)
            "Deny",   // Good value (Deny)
            "Disable calendar access (prevents apps from accessing your calendar)",
            "STRING",
            logger));

        // Disable call history access
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.CurrentUser,
            @"Software\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\callHistory",
            "Value",
            "Allow",  // Bad value (Allow)
            "Deny",   // Good value (Deny)
            "Disable call history access (prevents apps from accessing your call history)",
            "STRING",
            logger));

        // Disable email access
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.CurrentUser,
            @"Software\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\email",
            "Value",
            "Allow",  // Bad value (Allow)
            "Deny",   // Good value (Deny)
            "Disable email access (prevents apps from accessing your email)",
            "STRING",
            logger));

        // Disable messaging access
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.CurrentUser,
            @"Software\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\messaging",
            "Value",
            "Allow",  // Bad value (Allow)
            "Deny",   // Good value (Deny)
            "Disable messaging access (prevents apps from accessing your messages)",
            "STRING",
            logger));

        // Disable radio access
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.CurrentUser,
            @"Software\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\radios",
            "Value",
            "Allow",  // Bad value (Allow)
            "Deny",   // Good value (Deny)
            "Disable radio access (prevents apps from accessing your radios)",
            "STRING",
            logger));

    }
}