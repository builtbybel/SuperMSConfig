using Microsoft.Win32;
using SuperMSConfig;
using System;

public class SystemHabits : BaseHabitCategory
{
    private readonly Logger logger;

    public override string CategoryName => "System";

    public SystemHabits(Logger logger)
    {
        this.logger = logger;

        //Hasten the shutdown process
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.LocalMachine,
            @"SYSTEM\CurrentControlSet\Control",
            "WaitToKillServiceTimeout",
            "5000",  // Bad value (disabled)
            "2000",  // Good value (enabled)
            "Hasten the shutdown process",
            "STRING",
            logger));


        // Modify the Taskbar alignment to left
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.CurrentUser,
            @"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
            "TaskbarAl",
            1,  // Bad value (disabled)
            0,  // Good value (enabled)
            "Modify the Taskbar alignment to left",
            "DWORD",
            logger));

        // Performance Monitoring
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.LocalMachine,
            @"Software\Microsoft\Windows\CurrentVersion\PerformanceMonitoring",
            "EnablePerformanceMonitoring",
            0,  // Bad value (disabled)
            1,  // Good value (enabled)
            "Enable performance monitoring",
             "DWORD",
            logger));

        // Launch folders in a new process
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.LocalMachine,
            @"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
            "LaunchFolderWindowsInNewProcess",
            0,  // Bad value (disabled)
            1,  // Good value (enabled)
            "Launch folders in a new process",
             "DWORD",
            logger));

        // Enable SuperFetch
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.LocalMachine,
            @"Software\Policies\Microsoft\Windows\System",
            "EnableSuperFetch",
            0,  // Bad value (disabled)
            1,  // Good value (enabled)
            "Enable SuperFetch (improves performance by preloading frequently used apps)",
             "DWORD",
            logger));

        // Allow access to Task Manager
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.LocalMachine,
            @"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options",
            "DisableTaskMgr",
            1,  // Bad value (enabled)
            0,  // Good value (disabled)
            "Allow access to Task Manager",
             "DWORD",
            logger));

        // Disable Background Apps
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.CurrentUser,
            @"Software\Microsoft\Windows\CurrentVersion\BackgroundAccessApplications",
            "GlobalUserDisabled",
            0,  // Bad value (disabled)
            1,  // Good value (enabled)
            "Disable background apps (improves system performance)",
             "DWORD",
            logger));

        // Hide Super Hidden Files and Folders
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.CurrentUser,
            @"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
            "ShowSuperHidden",
            1,  // Bad value (enabled)
            0,  // Good value (disabled)
            "Hide super hidden files and folders (improves Explorer performance)",
             "DWORD",
            logger));

        // Windows Update
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.LocalMachine,
            @"Software\Policies\Microsoft\Windows\WindowsUpdate",
            "DisableWindowsUpdateAccess",
            1,  // Bad value (disabled)
            0,  // Good value (enabled)
            "Enabled Windows Updates",
             "DWORD",
            logger));

        // Fast Startup
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.LocalMachine,
            @"SYSTEM\CurrentControlSet\Control\Session Manager\Power",
            "HiberbootEnabled",
            0,  // Bad value (disabled)
            1,  // Good value (enabled)
            "Enable Fast Startup to speed up boot times",
             "DWORD",
            logger));

        // System Restore
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.LocalMachine,
            @"SOFTWARE\Policies\Microsoft\Windows NT\CurrentVersion\SystemRestore",
            "DisableSR",
            1,  // Bad value (System Restore disabled)
            0,  // Good value (System Restore enabled)
            "Enable System Restore for better system recovery options",
             "DWORD",
            logger));

        // Remote Desktop
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.LocalMachine,
            @"SYSTEM\CurrentControlSet\Control\Terminal Server",
            "fDenyTSConnections",
            1,  // Bad value (Remote Desktop disabled)
            0,  // Good value (Remote Desktop enabled)
            "Enable Remote Desktop for remote access to your system",
             "DWORD",
            logger));

        // File Extensions Visibility
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.CurrentUser,
            @"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced",
            "HideFileExt",
            1,  // Bad value (file extensions hidden)
            0,  // Good value (file extensions visible)
            "Show file extensions for better file management",
             "DWORD",
            logger));
    }
}
