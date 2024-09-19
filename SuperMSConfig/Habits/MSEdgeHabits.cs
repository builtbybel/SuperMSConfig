using Microsoft.Win32;
using SuperMSConfig;
using System;

public class BrowserHabits : BaseHabitCategory
{
    private readonly Logger logger;

    public override string CategoryName => "MS Edge ";

    public BrowserHabits(Logger logger)
    {
        this.logger = logger;

        // Disable Password Saving
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.LocalMachine,
            @"Software\Policies\Microsoft\Edge",
            "PasswordManagerEnabled",
            1,  // Bad value (password saving enabled)
            0,  // Good value (password saving disabled)
            CategoryName + "Disable password saving for better security",
            "DWORD", 
            logger));

        // Disable Auto-Complete
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.LocalMachine,
            @"Software\Policies\Microsoft\Edge",
            "AutofillAddressEnabled",
            1,  // Bad value (auto-fill enabled)
            0,  // Good value (auto-fill disabled)
            CategoryName + "Disable auto-fill for better privacy",
            "DWORD", 
            logger));

        // Enable Safe Browsing
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.LocalMachine,
            @"Software\Policies\Microsoft\Edge",
            "SafeBrowsingEnabled",
            0,  // Bad value (safe browsing disabled)
            1,  // Good value (safe browsing enabled)
            CategoryName + "Enable Safe Browsing to protect against harmful sites",
            "DWORD", 
            logger));

        // Block Pop-ups
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.LocalMachine,
            @"Software\Policies\Microsoft\Edge",
            "PopupsAllowed",
            1,  // Bad value (pop-ups allowed)
            0,  // Good value (pop-ups blocked)
            CategoryName + "Block pop-ups to avoid unwanted interruptions",
            "DWORD", 
            logger));

        // Enable Do Not Track
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.LocalMachine,
            @"Software\Policies\Microsoft\Edge",
            "DoNotTrackEnabled",
            0,  // Bad value (Do Not Track disabled)
            1,  // Good value (Do Not Track enabled)
            CategoryName + "Enable Do Not Track to enhance privacy",
            "DWORD", 
            logger));

        // Disable Autofill Credit Card
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.LocalMachine,
            @"Software\Policies\Microsoft\Edge",
            "AutofillCreditCardEnabled",
            1,  // Bad value (credit card autofill enabled)
            0,  // Good value (credit card autofill disabled)
            CategoryName + "Disable autofill for credit cards for better security",
            "DWORD", 
            logger));

        // Disable Browser Sign-in
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.LocalMachine,
            @"Software\Policies\Microsoft\Edge",
            "BrowserSignin",
            1,  // Bad value (sign-in enabled)
            0,  // Good value (sign-in disabled)
            CategoryName + "Disable browser sign-in to prevent account syncing",
            "DWORD", 
            logger));

        // Disable Default Browser Setting
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.LocalMachine,
            @"Software\Policies\Microsoft\Edge",
            "DefaultBrowserSettingEnabled",
            1,  // Bad value (default browser setting enabled)
            0,  // Good value (default browser setting disabled)
            CategoryName + "Disable default browser setting",
            "DWORD", 
            logger));

        // Disable Edge Collections
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.LocalMachine,
            @"Software\Policies\Microsoft\Edge",
            "EdgeCollectionsEnabled",
            1,  // Bad value (collections enabled)
            0,  // Good value (collections disabled)
            CategoryName + "Disable Edge Collections",
            "DWORD", 
            logger));

        // Disable Edge Shopping Assistant
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.LocalMachine,
            @"Software\Policies\Microsoft\Edge",
            "EdgeShoppingAssistantEnabled",
            1,  // Bad value (shopping assistant enabled)
            0,  // Good value (shopping assistant disabled)
            CategoryName + "Disable Edge Shopping Assistant",
            "DWORD", 
            logger));

        // Disable Gamer Mode
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.LocalMachine,
            @"Software\Policies\Microsoft\Edge",
            "GamerModeEnabled",
            1,  // Bad value (gamer mode enabled)
            0,  // Good value (gamer mode disabled)
            CategoryName + "Disable Gamer Mode",
            "DWORD", 
            logger));

        // Disable First Run Experience
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.LocalMachine,
            @"Software\Policies\Microsoft\Edge",
            "HideFirstRunExperience",
            0,  // Bad value (first run experience enabled)
            1,  // Good value (first run experience disabled)
            CategoryName + "Hide First Run Experience",
            "DWORD", 
            logger));

        // Disable Import on Each Launch
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.LocalMachine,
            @"Software\Policies\Microsoft\Edge",
            "ImportOnEachLaunch",
            1,  // Bad value (import on each launch enabled)
            0,  // Good value (import on each launch disabled)
            CategoryName + "Disable import on each launch",
            "DWORD", 
            logger));

        // "Don't Show Sponsored links in new tab page
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.LocalMachine,
            @"Software\Policies\Microsoft\Edge",
            "NewTabPageHideDefaultTopSites",
            0,  // Bad value (top sites visible)
            1,  // Good value (top sites hidden)
            CategoryName + "Don't Show Sponsored links in new tab page",
            "DWORD", 
            logger));

        // Disable New Tab Page Quick Links
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.LocalMachine,
            @"Software\Policies\Microsoft\Edge",
            "NewTabPageQuickLinksEnabled",
            1,  // Bad value (quick links enabled)
            0,  // Good value (quick links disabled)
            CategoryName + "Disable quick links on new tab page",
            "DWORD", 
            logger));

        // Disable Startup Boost
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.LocalMachine,
            @"Software\Policies\Microsoft\Edge",
            "StartupBoostEnabled",
            1,  // Bad value (startup boost enabled)
            0,  // Good value (startup boost disabled)
            CategoryName + "Disable startup boost",
            "DWORD", 
            logger));

        // Disable User Feedback
        habits.Add(new SuperMSConfig.RegistryHabit(
            RegistryHive.LocalMachine,
            @"Software\Policies\Microsoft\Edge",
            "UserFeedbackAllowed",
            1,  // Bad value (feedback allowed)
            0,  // Good value (feedback disabled)
            CategoryName + "Disable user feedback",
            "DWORD", 
            logger));
    }
}
