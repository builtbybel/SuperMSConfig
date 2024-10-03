using Microsoft.Win32;
using SuperMSConfig;
using System;

public class AIHabits : BaseHabitCategory
{
    public override string CategoryName => "AI";
    private readonly Logger logger;

    public AIHabits(Logger logger)
    {
        this.logger = logger;

        // Copilot Taskbar
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.CurrentUser,
            @"Software\Policies\Microsoft\Windows\WindowsCopilot",
            "TurnOffWindowsCopilot", 
            0, 
            1, 
            "Windows AI",
            "DWORD", 
            logger));

        // Recall Experience
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.CurrentUser,
            @"Software\Policies\Microsoft\Windows\WindowsAI",
            "DisableAIDataAnalysis", 
            0, 
            1, 
            "Windows AI (Recall > Current user)",
            "DWORD", logger));
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.LocalMachine,
            @"Software\Policies\Microsoft\Windows\WindowsAI",
            "DisableAIDataAnalysis", 
            0,
            1,
            "Windows AI (Recall > All users)",
            "DWORD", 
             logger));
    }
}