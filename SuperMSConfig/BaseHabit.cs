using System.Threading.Tasks;

public abstract class BaseHabit
{
    public abstract string Name { get; }
    public abstract string Description { get; }

    public enum HabitStatus
    {
        Good,
        Bad,
        NotConfigured
    }

    public virtual HabitStatus Status { get; set; } = HabitStatus.NotConfigured;

    public abstract Task Check();
    public abstract Task Fix();
    public abstract Task Revert();
    public abstract string GetDetails();
}
