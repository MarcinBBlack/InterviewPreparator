using InterviewPreparator.Domain.Enums;

namespace InterviewPreparator.Domain.Entities;

public sealed class SessionTask : Entity
{
    #region Constants and Fields

    private const Int32 MinimumPossiblePoints = 3;
    private const Int32 MaximumPossiblePoints = 12;
    private const Int32 PointsPerError = 3;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the ID of the session containing this task.
    /// </summary>
    public Int32 SessionId { get; private set; }

    /// <summary>
    /// Gets the points earned for this task.
    /// </summary>
    public Int32 EarnedPoints { get; private set; }

    /// <summary>
    /// Gets the points available for this task.
    /// </summary>
    public Int32 PossiblePoints { get; private set; }

    /// <summary>
    /// Gets the task's current status.
    /// </summary>
    public SessionTaskStatus Status { get; private set; }

    #endregion

    #region Constructors

    /// <summary>
    /// Creates a task belonging to a session.
    /// </summary>
    /// <param name="sessionId">The ID of the session containing this task.</param>
    /// <param name="possiblePoints">The points available for this task.</param>
    public SessionTask(Int32 sessionId, Int32 possiblePoints)
    {
        if (sessionId <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(sessionId),
                "Session ID must be greater than zero.");
        }

        if (possiblePoints < MinimumPossiblePoints
            || possiblePoints > MaximumPossiblePoints
            || possiblePoints % PointsPerError != 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(possiblePoints),
                "Possible points must represent one to four errors at three points per error.");
        }

        SessionId = sessionId;
        PossiblePoints = possiblePoints;
        Status = SessionTaskStatus.Open;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Closes the task with the score awarded by the evaluation process.
    /// </summary>
    /// <param name="earnedPoints">The points earned for this task.</param>
    public void CloseWithScore(Int32 earnedPoints)
    {
        if (Status == SessionTaskStatus.Closed)
        {
            throw new InvalidOperationException("The task is already closed.");
        }

        if (earnedPoints < 0 || earnedPoints > PossiblePoints)
        {
            throw new ArgumentOutOfRangeException(
                nameof(earnedPoints),
                "Earned points must be between zero and the possible points.");
        }

        EarnedPoints = earnedPoints;
        Status = SessionTaskStatus.Closed;
    }

    #endregion
}
