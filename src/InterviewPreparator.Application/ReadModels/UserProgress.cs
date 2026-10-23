using InterviewPreparator.Domain.Entities;

namespace InterviewPreparator.Application.ReadModels;

/// <summary>
/// Represents a user's calculated progress across their sessions.
/// </summary>
public sealed class UserProgress
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
    /// Gets the points earned by the user across their tasks.
    /// </summary>
    public Int32 TotalEarnedPoints { get; }

    /// <summary>
    /// Gets the total points available across the user's tasks.
    /// </summary>
    public Int32 TotalPossiblePoints { get; }

    /// <summary>
    /// Gets the points earned and available for each task.
    /// </summary>
    public IReadOnlyCollection<SessionTaskProgress> Tasks => _taskProgress;

    #endregion

    #region Constructors

    /// <summary>
    /// Creates a progress summary from the specified user's sessions.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <param name="sessions">The sessions used to calculate progress.</param>
    public UserProgress(Int32 userId, IEnumerable<Session> sessions)
    {
        if (userId <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(userId),
                "User ID must be greater than zero.");
        }

        ArgumentNullException.ThrowIfNull(sessions);

        var userSessions = sessions.ToArray();

        if (userSessions.Any(session => session.UserId != userId))
        {
            throw new ArgumentException(
                "All sessions must belong to the specified user.",
                nameof(sessions));
        }

        UserId = userId;

        var taskProgress = userSessions
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
/// Represents a task's contribution to a user's progress summary.
/// </summary>
/// <param name="SessionId">The ID of the session containing the task.</param>
/// <param name="TaskId">The ID of the task.</param>
/// <param name="EarnedPoints">The points earned for the task.</param>
/// <param name="PossiblePoints">The points available for the task.</param>
public sealed record SessionTaskProgress(
    Int32 SessionId,
    Int32 TaskId,
    Int32 EarnedPoints,
    Int32 PossiblePoints);
