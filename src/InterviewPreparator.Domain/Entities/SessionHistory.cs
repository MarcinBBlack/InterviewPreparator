namespace InterviewPreparator.Domain.Entities;

public class SessionHistory : Entity
{
    #region Fields

    private readonly List<Session> _sessions;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the ID of the user whose sessions are recorded.
    /// </summary>
    public Int32 UserId { get; }

    /// <summary>
    /// Gets the user's recorded sessions.
    /// </summary>
    public IReadOnlyCollection<Session> Sessions => _sessions.AsReadOnly();

    /// <summary>
    /// Gets the total points earned across the recorded sessions.
    /// </summary>
    public Int32 TotalEarnedPoints => _sessions.Sum(session => session.EarnedPoints);

    /// <summary>
    /// Gets the total points available across the recorded sessions.
    /// </summary>
    public Int32 TotalPossiblePoints => _sessions.Sum(session => session.PossiblePoints);

    #endregion

    #region Constructors

    /// <summary>
    /// Creates a history containing sessions belonging to one user.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <param name="sessions">The user's sessions.</param>
    public SessionHistory(Int32 userId, IEnumerable<Session> sessions)
    {
        if (userId <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(userId),
                "User ID must be greater than zero.");
        }

        ArgumentNullException.ThrowIfNull(sessions);

        _sessions = sessions.ToList();

        if (_sessions.Any(session => session.UserId != userId))
        {
            throw new ArgumentException("All sessions must belong to the specified user.", nameof(sessions));
        }

        UserId = userId;
    }

    #endregion
}
