using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using static BaseHabit;

namespace SuperMSConfig
{
    public class HabitChecker
    {
        private readonly List<BaseHabitCategory> habitCategories = new List<BaseHabitCategory>();
        private readonly Logger logger;

        public HabitChecker(Logger logger)
        {
            this.logger = logger;

            // Add habit categories
            habitCategories.Add(new AdsHabits(logger));
            habitCategories.Add(new AIHabits(logger));
            habitCategories.Add(new PrivacyHabits(logger));
            habitCategories.Add(new SecurityHabits(logger));
            habitCategories.Add(new ServiceHabits(logger));
            habitCategories.Add(new AppsHabits(logger));
            habitCategories.Add(new StartupHabits(logger));
            habitCategories.Add(new SystemHabits(logger));
            habitCategories.Add(new BrowserHabits(logger));
            habitCategories.Add(new GamingHabits(logger));
        }

        public async Task<List<BaseHabit>> GetAllHabits()
        {
            var habits = new List<BaseHabit>();

            foreach (var category in habitCategories)
            {
                habits.AddRange(category.GetHabits());
            }

            return habits;
        }

        public async Task CheckHabit(BaseHabit habit)
        {
            await habit.Check();
            logger.Log($"{habit.Name} - {habit.Description}: {habit.Status}",
                GetColorForStatus(habit.Status),
                habit.GetDetails());
        }

        // Get color based on HabitStatus
        public Color GetColorForStatus(HabitStatus status)
        {
            switch (status)
            {
                case HabitStatus.Good:
                    return Color.DimGray;
                case HabitStatus.Bad:
                    return Color.Crimson;
                case HabitStatus.NotConfigured:
                    return Color.DarkOrange;
                default:
                    return Color.Black; // Fallback color if status is unknown
            }
        }

        // Get all category names and add to dropdown list in UI
        public List<string> GetCategoryNames()
        {
            return habitCategories
                .Select(c => c.CategoryName)
                .Distinct()
                .ToList();
        }

        public async Task<List<BaseHabit>> GetHabitsByCategory(string categoryName)
        {
            var category = habitCategories.FirstOrDefault(c => c.CategoryName == categoryName);

            if (category != null)
            {
                return category.GetHabits().ToList();
            }

            return new List<BaseHabit>();
        }

        // Check if app runs as Admin 
        public bool IsRunningAsAdmin()
        {
            try
            {
                WindowsIdentity identity = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                bool isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);

                // logger.Log($"App is running with Admin rights: {isAdmin}", isAdmin ? Color.Green : Color.Red);

                if (!isAdmin)
                {
                    // logger.Log("The app should be run as Administrator to ensure all features work properly.", Color.Orange);
                }

                return isAdmin;
            }
            catch (Exception ex)
            {
                logger.Log($"Error checking admin rights: {ex.Message}", Color.Red);
                return false;
            }
        }
    }
}
