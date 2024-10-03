namespace SuperMSConfig
{
    public class StartupHabits : BaseHabitCategory
    {
        private readonly Logger logger;

        public override string CategoryName => "Startup";

        public StartupHabits(Logger logger)
        {
            this.logger = logger;

            habits.Add(new StartupHabit("Discord", "Discord: Essential for gaming and communication but can be disabled if it impacts startup performance.", logger));
            habits.Add(new StartupHabit("UninstallT20", "Microsoft Teams Updater: Automatically updates Microsoft Teams; disable if it's causing startup delays.", logger));
            habits.Add(new StartupHabit("Teams", "Microsoft Teams: Critical for work-related collaboration; disable if it affects startup time.", logger));
            habits.Add(new StartupHabit("OneDrive", "OneDrive: Syncs files to the cloud; can be disabled if not needed or causing issues.", logger));
            habits.Add(new StartupHabit("Spotify", "Spotify: Launches music streaming; can be disabled if it slows down your system at startup.", logger));
            habits.Add(new StartupHabit("Skype", "Skype: Used for calls and messaging; disable if not needed to speed up your startup.", logger));
            habits.Add(new StartupHabit("Acrobat", "Adobe Acrobat: Opens PDFs; can be disabled if you don't frequently use it or it slows down boot.", logger));
            habits.Add(new StartupHabit("Java Update Scheduler", "Java Update Scheduler: Keeps Java updated; disable if you prefer manual updates or it's causing slowdowns.", logger));
            habits.Add(new StartupHabit("CCleaner", "CCleaner: Cleans up system junk; can be disabled if it causes slow startup times.", logger));
            habits.Add(new StartupHabit("NVIDIA GeForce Experience", "NVIDIA GeForce Experience: Manages graphics drivers and settings; disable if it’s impacting startup performance.", logger));
            habits.Add(new StartupHabit("QuickTime", "QuickTime: Media player; can be disabled if it's not frequently used or slows down startup.", logger));
            habits.Add(new StartupHabit("uTorrent", "uTorrent: BitTorrent client; can be disabled if it's causing delays or issues at startup.", logger));
            habits.Add(new StartupHabit("RtHDVBg", "Realtek HD Audio Driver: Essential for high-quality sound but may be disabled if causing issues.", logger));
            habits.Add(new StartupHabit("RtHDVCpl", "Realtek HD Control Panel: Manages audio settings; can be disabled if it disrupts system performance.", logger));
        }
    }
}