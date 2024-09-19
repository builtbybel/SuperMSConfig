using System;
using System.Collections.Generic;

namespace SuperMSConfig
{
    public class ServiceHabits : BaseHabitCategory
    {
        private readonly Logger logger;

        public override string CategoryName => "Services";

        public ServiceHabits(Logger logger)
        {
            this.logger = logger;

            //  badValue; 1 for stopped, 0 for running

            habits.Add(new ServiceHabit("diagnosticshub.standardcollector.service", "Microsoft (R) Diagnostics Hub Standard Collector Service: Collects diagnostic data for system health and performance.", logger, 1));

            // Adobe Acrobat Updater
            habits.Add(new ServiceHabit("AdobeARMservice", "Adobe Acrobat Update Service: Keeps Adobe Acrobat software up to date.", logger, 1));

            // Google Services (irrelevant services)
            habits.Add(new ServiceHabit("gupdate", "Google Update Service: Keeps Google applications such as Chrome up to date.", logger, 1));
            habits.Add(new ServiceHabit("gupdatem", "Google Update Service (Machine-Wide): Keeps Google applications up to date (machine-wide).", logger, 1));

            // TeamViewer
            habits.Add(new ServiceHabit("TeamViewer", "TeamViewer Service: Allows remote access and support connections.", logger, 1));

            // Citrix Updater Service
            habits.Add(new ServiceHabit("CWAUpdaterService", "Citrix Workspace App Updater Service: Manages updates for Citrix Workspace.", logger, 1));

            // Apple Services (on Windows)
            habits.Add(new ServiceHabit("AppleMobileDeviceService", "Apple Mobile Device Service: Allows iTunes to communicate with iPhones/iPads.", logger, 1));
            habits.Add(new ServiceHabit("Bonjour Service", "Apple Bonjour Service: Allows automatic discovery of devices on local networks, often unnecessary.", logger, 1));

            // NVIDIA Telemetry
            habits.Add(new ServiceHabit("NvTelemetryContainer", "NVIDIA Telemetry Service: Collects and sends telemetry data to NVIDIA.", logger, 1));

            // Dropbox Update Services
            habits.Add(new ServiceHabit("dbupdate", "Dropbox Update Service: Keeps Dropbox application up to date.", logger, 1));
            habits.Add(new ServiceHabit("dbupdatem", "Dropbox Update Service (Machine-Wide): Keeps Dropbox up to date for all users on the system.", logger, 1));

            // Skype Updater
            habits.Add(new ServiceHabit("SkypeUpdate", "Skype Updater Service: Updates Skype automatically, often unnecessary.", logger, 1));

            // Spotify Web Helper
            habits.Add(new ServiceHabit("SpotifyWebHelper", "Spotify Web Helper: Automatically launches Spotify from web links, often not needed.", logger, 1));

            // Realtek Audio Services
            habits.Add(new ServiceHabit("RtkAudioService", "Realtek Audio Service: Manages audio-related tasks for Realtek hardware, usually unnecessary for basic use.", logger, 1));

            // Intel Update Manager
            habits.Add(new ServiceHabit("IntelRapidStorage", "Intel Rapid Storage Technology: Often unnecessary unless using advanced RAID or disk management features.", logger, 1));

            // Steam Client Service
            habits.Add(new ServiceHabit("Steam Client Service", "Steam Client Service: Allows Steam to update and manage games, not needed unless you actively use Steam.", logger, 1));

            // Adobe Genuine Software Integrity Service
            habits.Add(new ServiceHabit("AdobeGenuineMonitorService", "Adobe Genuine Software Integrity Service: Checks for genuine Adobe software, not essential for regular use.", logger, 1));

            // Windows Services
            habits.Add(new ServiceHabit("diagnosticshub.standardcollector.service", "Microsoft (R) Diagnostics Hub Standard Collector Service: Collects diagnostic data for system health and performance.", logger, 1));
            habits.Add(new ServiceHabit("DiagTrack", "Diagnostics Tracking Service: Monitors and tracks diagnostics and performance metrics.", logger, 1));
            habits.Add(new ServiceHabit("dmwappushservice", "WAP Push Message Routing Service: Handles WAP push messages, but can be safely turned off if not in use.", logger, 1));
            habits.Add(new ServiceHabit("lfsvc", "Geolocation Service: Manages location data for various applications. Disable if you don’t use location-based services.", logger, 1));
            habits.Add(new ServiceHabit("MapsBroker", "Downloaded Maps Manager: Manages offline maps. Disable if you don’t use offline maps.", logger, 1));
            habits.Add(new ServiceHabit("NetTcpPortSharing", "Net.Tcp Port Sharing Service: Enables network communication via TCP. Turn off if you don’t use networked applications.", logger, 1));
            habits.Add(new ServiceHabit("RemoteRegistry", "Remote Registry: Allows remote access to the Windows registry. Disable if remote registry access is unnecessary.", logger, 1));
            habits.Add(new ServiceHabit("TrkWks", "Distributed Link Tracking Client: Maintains links to files across a network. Disable if not using networked file links.", logger, 1));
            habits.Add(new ServiceHabit("WbioSrvc", "Windows Biometric Service: Supports fingerprint and facial recognition hardware. Disable if you don’t use biometric devices.", logger, 1));
            habits.Add(new ServiceHabit("WMPNetworkSvc", "Windows Media Player Network Sharing Service: Shares media over the network. Disable if you don’t share media.", logger, 1));
            habits.Add(new ServiceHabit("XblAuthManager", "Xbox Live Auth Manager: Manages Xbox Live authentication. Turn off if you don’t use Xbox Live services.", logger, 1));
            habits.Add(new ServiceHabit("XblGameSave", "Xbox Live Game Save Service: Manages Xbox game saves. Disable if you’re not using Xbox Live game features.", logger, 1));
            habits.Add(new ServiceHabit("XboxNetApiSvc", "Xbox Live Networking Service: Handles Xbox Live network connections. Turn off if Xbox Live services aren’t needed.", logger, 1));
            habits.Add(new ServiceHabit("ndu", "Windows Network Data Usage Monitor: Tracks network data usage. Disable if you don’t need to monitor data usage.", logger, 1));
            habits.Add(new ServiceHabit("fxssvc", "Fax Service: Manages fax operations. If you don’t use a fax machine, it’s safe to turn off this service.", logger, 1));
            habits.Add(new ServiceHabit("WiaRpc", "Windows Image Acquisition (WIA): Supports image acquisition devices like scanners and cameras. Disable if these devices aren’t used.", logger, 1));
            habits.Add(new ServiceHabit("SmartCard", "Smart Card: Supports smart card devices for security. Turn off if smart card functionality isn’t needed.", logger, 1));
            habits.Add(new ServiceHabit("Spooler", "Print Spooler: Manages print jobs. Disable if you don’t have a printer or print jobs.", logger, 1));
            habits.Add(new ServiceHabit("SysMain", "Superfetch (SysMain): Improves startup times by preloading frequently used applications. If you have an SSD, you might not need this.", logger, 1));
            habits.Add(new ServiceHabit("bthserv", "Bluetooth Support Service: Manages Bluetooth connections. Turn off if you don’t use Bluetooth devices.", logger, 1));
            habits.Add(new ServiceHabit("WerSvc", "Windows Error Reporting Service: Sends error reports to Microsoft. Disable if you don’t wish to share error information.", logger, 1));
            habits.Add(new ServiceHabit("wisvc", "Windows Insider Service: Manages Windows Insider updates. Disable if you’re not part of the Insider Program.", logger, 1));
            habits.Add(new ServiceHabit("seclogon", "Secondary Logon: Allows running applications with different credentials. Turn off if you don’t use this feature.", logger, 1));
        }
    }
}