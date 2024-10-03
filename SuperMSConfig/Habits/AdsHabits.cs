using Microsoft.Win32;
using SuperMSConfig;
using System;
using System.Collections.Generic;

public class AdsHabits : BaseHabitCategory
{
    private readonly Logger logger;

    public override string CategoryName => "Ads";

    public AdsHabits(Logger logger)
    {
        // this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        // just assign our logger to the field if it's null
        this.logger = logger;

        if (logger == null)
        {
            Console.WriteLine("Warning: Logger is null. Logging will be disabled.");
        }

        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.CurrentUser,
            @"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
            "ShowSyncProviderNotifications",
            1,
            0,
            "Disable Windows 11 File Explorer Ads",
            "DWORD",
            logger));

        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.CurrentUser,
            @"Software\Microsoft\Windows\CurrentVersion\UserProfileEngagement",
            "ScoobeSystemSettingEnabled",
            1,
            0,
            "Disable Windows 11 FinishSetup Ads",
            "DWORD",
            logger));

        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.CurrentUser,
            @"Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager",
            "RotatingLockScreenOverlayEnabled",
            1,
            0,
            "Disable Windows 11 LockScreen Ads",
            "DWORD",
            logger));

        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.CurrentUser,
            @"Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager",
            "SubscribedContent-338387Enabled",
            1,
            0,
            "Disable Windows 11 LockScreen Ads",
            "DWORD",
            logger));

        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.CurrentUser,
            @"Software\Microsoft\Windows\CurrentVersion\AdvertisingInfo",
            "Enabled",
            1,
            0,
            "Disable Windows 11 Personalized Ads",
            "DWORD",
            logger));

        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.CurrentUser,
            @"Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager",
            "SubscribedContent-338393Enabled",
            1,
            0,
            "Disable Windows 11 Settings Ads",
            "DWORD",
            logger));

        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.CurrentUser,
            @"Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager",
            "SubscribedContent-353694Enabled",
            1,
            0,
            "Disable Windows 11 Settings Ads",
            "DWORD",
            logger));

        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.CurrentUser,
            @"Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager",
            "SubscribedContent-353696Enabled",
            1,
            0,
            "Disable Windows 11 Settings Ads",
            "DWORD",
            logger));

        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.CurrentUser,
            @"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
            "Start_IrisRecommendations",
            1,
            0,
            "Disable Windows 11 Startmenu Ads",
            "DWORD",
            logger));

        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.CurrentUser,
            @"Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager",
            "SubscribedContent-338389Enabled",
            1,
            0,
            "Disable Windows Tips and Suggestions",
            "DWORD",
            logger));

        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.CurrentUser,
            @"Software\Microsoft\Windows\CurrentVersion\Privacy",
            "TailoredExperiencesWithDiagnosticDataEnabled",
            1,
            0,
            "Disable Tailored Experiences",
            "DWORD",
            logger));

        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.CurrentUser,
            @"Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager",
            "SubscribedContent-310093Enabled",
            1,
            0,
            "Disable Windows 11 Welcome Experience Ads",
            "DWORD",
            logger));
    }
}