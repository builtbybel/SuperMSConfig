using System.Collections.Generic;

namespace SuperMSConfig
{
    public abstract class BaseHabitCategory
    {
        protected readonly List<BaseHabit> habits = new List<BaseHabit>();
        public IReadOnlyList<BaseHabit> Habits => habits.AsReadOnly();

        public abstract string CategoryName { get; }

        public IEnumerable<BaseHabit> GetHabits()
        {
            foreach (var habit in habits)
            {
                yield return habit;
            }
        }
    }
}
