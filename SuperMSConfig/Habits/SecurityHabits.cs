using Microsoft.Win32;
using SuperMSConfig;
using System;

public class SecurityHabits : BaseHabitCategory
{
    private readonly Logger logger; 

    public override string CategoryName => "Security";

    public SecurityHabits(Logger logger)
    {
        this.logger = logger;

        // Enable Windows Defender
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.LocalMachine,
            @"Software\Policies\Microsoft\Windows Defender",
            "DisableAntiSpyware",
            1,  // Bad value (disabled)
            0,  // Good value (enabled)
            "Enable Windows Defender (prevents spyware and malware)",
            "DWORD",
            logger));

        // Enable User Account Control (UAC)
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.LocalMachine,
            @"Software\Policies\Microsoft\Windows\System",
            "EnableLUA",
            0,  // Bad value (disabled)
            1,  // Good value (enabled)
            "Enable User Account Control (UAC) (prompts for administrative actions)",
            "DWORD",
            logger));

        // Disable SMBv1
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.LocalMachine,
            @"System\CurrentControlSet\Services\LanmanServer\Parameters",
            "SMB1",
            1,  // Bad value (enabled)
            0,  // Good value (disabled)
            "Disable SMBv1 (prevents exploitation of old vulnerabilities)",
            "DWORD",
            logger));

        // Enable Windows Defender Real-Time Protection
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.LocalMachine,
            @"Software\Policies\Microsoft\Windows Defender\Real-Time Protection",
            "DisableRealtimeMonitoring",
            1,  // Bad value (disabled)
            0,  // Good value (enabled)
            "Enable Windows Defender Real-Time Protection (scans for threats in real time)",
            "DWORD",
            logger));

        // Disable Windows Script Host
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.CurrentUser,
            @"Software\Microsoft\Windows Script Host\Settings",
            "Enabled",
            1,  // Bad value (enabled)
            0,  // Good value (disabled)
            "Disable Windows Script Host (prevents malicious scripts)",
            "DWORD",
            logger));

        // Enable Secure Boot
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.LocalMachine,
            @"System\CurrentControlSet\Control\SecureBoot\State",
            "UEFISecureBootEnabled",
            0,  // Bad value (disabled)
            1,  // Good value (enabled)
            "Enable Secure Boot (prevents unauthorized OS and bootloaders)",
            "DWORD",
            logger));

        // Enable Firewall
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.LocalMachine,
            @"Software\Policies\Microsoft\WindowsFirewall\DomainProfile",
            "EnableFirewall",
            0,  // Bad value (disabled)
            1,  // Good value (enabled)
            "Enable Firewall (Protect all network connections)",
            "DWORD",
            logger));

        // Disable AutoRun
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.LocalMachine,
            @"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer",
            "NoDriveTypeAutoRun",
            0,  // Bad value (enabled)
            255, // Good value (disabled)
            "Disable AutoRun (prevents auto-starting of malicious USB devices)",
            "DWORD",
            logger));

        // Disable Guest Account
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.LocalMachine,
            @"Software\Microsoft\Windows NT\CurrentVersion\Winlogon",
            "AutoAdminLogon",
            1,  // Bad value (enabled)
            0,  // Good value (disabled)
            "Disable Guest Account (prevents unauthorized access)",
            "DWORD",
            logger));
    }
}
