using SuperMSConfig;
using System;

public class AppsHabits : BaseHabitCategory
{
    private readonly Logger logger;

    public override string CategoryName => "Apps / Bloatware";

    public AppsHabits(Logger logger)
    {
        this.logger = logger;

        // Bloatware entries
        habits.Add(new AppsHabit("Microsoft.BingWeather", "Remove Microsoft Bing Weather App", logger));
        habits.Add(new AppsHabit("Microsoft.XboxApp", "Remove Xbox App", logger));
        habits.Add(new AppsHabit("Microsoft.OfficeHub", "Remove Office Hub", logger));
        habits.Add(new AppsHabit("Microsoft.SkypeApp", "Remove Skype", logger));
        habits.Add(new AppsHabit("Microsoft.MixedReality.Portal", "Remove Mixed Reality Portal", logger));
        habits.Add(new AppsHabit("Microsoft.WindowsPhone", "Remove Windows Phone App", logger));
        habits.Add(new AppsHabit("Microsoft.3DBuilder", "Remove 3D Builder", logger));
        habits.Add(new AppsHabit("Microsoft.BingFinance", "Remove Bing Finance", logger));
        habits.Add(new AppsHabit("Microsoft.BingNews", "Remove Bing News", logger));
        habits.Add(new AppsHabit("Microsoft.BingSports", "Remove Bing Sports", logger));
        habits.Add(new AppsHabit("Microsoft.BingTravel", "Remove Bing Travel", logger));
        habits.Add(new AppsHabit("Microsoft.GetHelp", "Remove Get Help App", logger));
        habits.Add(new AppsHabit("Microsoft.GetStarted", "Remove Get Started App", logger));
        // Additional bloatware entries
        habits.Add(new AppsHabit("Microsoft.MicrosoftSolitaireCollection", "Remove Microsoft Solitaire Collection", logger));
        habits.Add(new AppsHabit("Microsoft.MicrosoftStickyNotes", "Remove Microsoft Sticky Notes", logger));
        habits.Add(new AppsHabit("Microsoft.MicrosoftToDo", "Remove Microsoft To Do", logger));
        habits.Add(new AppsHabit("Microsoft.MicrosoftPhotos", "Remove Microsoft Photos", logger));
        habits.Add(new AppsHabit("Microsoft.MicrosoftNews", "Remove Microsoft News", logger));
        habits.Add(new AppsHabit("Facebook", "Remove Facebook", logger));
        habits.Add(new AppsHabit("Instagram", "Remove Instagram", logger));
        habits.Add(new AppsHabit("Twitter.Twitter", "Remove Twitter", logger));
        habits.Add(new AppsHabit("King.CandyCrushSaga", "Remove Candy Crush Saga", logger));
        habits.Add(new AppsHabit("King.CandyCrushSodaSaga", "Remove Candy Crush Soda Saga", logger));
        habits.Add(new AppsHabit("King.CandyCrushFriendsSaga", "Remove Candy Crush Friends Saga", logger));
    }
}