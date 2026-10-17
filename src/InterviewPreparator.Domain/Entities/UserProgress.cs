namespace InterviewPreparator.Domain.Entities;

/// <summary>
/// Represents a user's accumulated progress across their sessions.
/// </summary>
public class UserProgress : Entity
{
    #region Fields

    private readonly IReadOnlyCollection<SessionTaskProgress> _taskProgress;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the ID of the user whose progress is represented.
    /// </summary>
    public Int32 UserId { get; }

    /// <summary>
    /// Gets the points earned by the user across all sessions.
    /// </summary>
    public Int32 TotalEarnedPoints { get; }

    /// <summary>
    /// Gets the total points available across all recorded tasks.
    /// </summary>
    public Int32 TotalPossiblePoints { get; }

    /// <summary>
    /// Gets the points earned and available for each task.
    /// </summary>
    public IReadOnlyCollection<SessionTaskProgress> Tasks => _taskProgress;

    #endregion

    #region Constructors

    /// <summary>
    /// Creates a progress snapshot from the user's session history.
    /// </summary>
    /// <param name="sessionHistory">The user's session history.</param>
    public UserProgress(SessionHistory sessionHistory)
    {
        ArgumentNullException.ThrowIfNull(sessionHistory);

        UserId = sessionHistory.UserId;
        var taskProgress = sessionHistory.Sessions
            .SelectMany(session => session.Tasks.Select(task => new SessionTaskProgress(
                session.Id,
                task.Id,
                task.EarnedPoints,
                task.PossiblePoints)))
            .ToArray();

        _taskProgress = Array.AsReadOnly(taskProgress);
        TotalEarnedPoints = _taskProgress.Sum(task => task.EarnedPoints);
        TotalPossiblePoints = _taskProgress.Sum(task => task.PossiblePoints);
    }

    #endregion
}

/// <summary>
/// Represents a task's contribution to a user's progress.
/// </summary>
/// <param name="SessionId">The ID of the session containing the task.</param>
/// <param name="TaskId">The task ID.</param>
/// <param name="EarnedPoints">The points earned for the task.</param>
/// <param name="PossiblePoints">The points available for the task.</param>
public sealed record SessionTaskProgress(
    Int32 SessionId,
    Int32 TaskId,
    Int32 EarnedPoints,
    Int32 PossiblePoints);
