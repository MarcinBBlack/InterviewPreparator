using InterviewPreparator.Domain.Enums;

namespace InterviewPreparator.Domain.Entities;

public class Session : Entity
{
    #region Constants and Fields

    public const Int32 MaximumTaskCount = 5;

    private readonly List<SessionTask> _tasks = [];

    #endregion

    #region Properties

    /// <summary>
    /// Gets the ID of the user who owns this session.
    /// </summary>
    public Int32 UserId { get; private set; }

    /// <summary>
    /// Gets the programming language used in this session.
    /// </summary>
    public ProgrammingLanguage ProgrammingLanguage { get; private set; }

    /// <summary>
    /// Gets the selected experience level for this session.
    /// </summary>
    public ExperienceLevel ExperienceLevel { get; private set; }

    /// <summary>
    /// Gets the time limit for each task in this session.
    /// </summary>
    public TaskTimeLimit TimeLimitPerTask { get; private set; }

    /// <summary>
    /// Gets the session's current status.
    /// </summary>
    public SessionStatus Status { get; private set; }

    /// <summary>
    /// Gets the tasks in this session.
    /// </summary>
    public IReadOnlyCollection<SessionTask> Tasks => _tasks.AsReadOnly();

    /// <summary>
    /// Gets the points earned across the tasks in this session.
    /// </summary>
    public Int32 EarnedPoints => _tasks.Sum(sessionTask => sessionTask.EarnedPoints);

    /// <summary>
    /// Gets the points available across the tasks in this session.
    /// </summary>
    public Int32 PossiblePoints => _tasks.Sum(sessionTask => sessionTask.PossiblePoints);

    #endregion

    #region Constructors


    /// <summary>
    /// Creates a session with the selected language, experience level, and task time limit.
    /// </summary>
    /// <param name="userId">The ID of the user who owns this session.</param>
    /// <param name="programmingLanguage">The programming language for this session.</param>
    /// <param name="experienceLevel">The selected experience level.</param>
    /// <param name="timeLimitPerTask">The time limit for each task.</param>
    public Session(
        Int32 userId,
        ProgrammingLanguage programmingLanguage,
        ExperienceLevel experienceLevel,
        TaskTimeLimit timeLimitPerTask)
    {
        if (userId <= 0)
        {
            throw new ArgumentException("User ID cannot be empty.", nameof(userId));
        }

        if (!Enum.IsDefined(programmingLanguage))
        {
            throw new ArgumentOutOfRangeException(nameof(programmingLanguage));
        }

        if (!Enum.IsDefined(experienceLevel))
        {
            throw new ArgumentOutOfRangeException(nameof(experienceLevel));
        }

        if (!Enum.IsDefined(timeLimitPerTask))
        {
            throw new ArgumentOutOfRangeException(nameof(timeLimitPerTask));
        }

        UserId = userId;
        ProgrammingLanguage = programmingLanguage;
        ExperienceLevel = experienceLevel;
        TimeLimitPerTask = timeLimitPerTask;
        Status = SessionStatus.Open;
    }

    #endregion

    #region Methods


    /// <summary>
    /// Adds the next open task to this session.
    /// </summary>
    /// <param name="sessionTask">The task to add.</param>
    public void AddTask(SessionTask sessionTask)
    {
        ArgumentNullException.ThrowIfNull(sessionTask);

        if (Status == SessionStatus.Closed)
        {
            throw new InvalidOperationException("Cannot add a task to a closed session.");
        }

        if (sessionTask.SessionId != Id)
        {
            throw new ArgumentException("The task belongs to a different session.", nameof(sessionTask));
        }

        if (sessionTask.Status != SessionTaskStatus.Open)
        {
            throw new ArgumentException("A new session task must be open.", nameof(sessionTask));
        }

        if (_tasks.Count >= MaximumTaskCount)
        {
            throw new InvalidOperationException("The session has reached its task limit.");
        }

        if (_tasks.Any(existingTask => existingTask.Status == SessionTaskStatus.Open))
        {
            throw new InvalidOperationException("The current task must be closed before adding another.");
        }

        _tasks.Add(sessionTask);
    }

    /// <summary>
    /// Closes an open task with its awarded score and closes the session after its final task.
    /// </summary>
    /// <param name="taskId">The ID of the task to close.</param>
    /// <param name="earnedPoints">The points earned for the task.</param>
    public void CloseTask(Int32 taskId, Int32 earnedPoints)
    {
        if (Status == SessionStatus.Closed)
        {
            throw new InvalidOperationException("The session is already closed.");
        }

        var sessionTask = _tasks.SingleOrDefault(task => task.Id == taskId);

        if (sessionTask is null)
        {
            throw new ArgumentException("The task does not belong to this session.", nameof(taskId));
        }

        sessionTask.CloseWithScore(earnedPoints);

        if (_tasks.Count == MaximumTaskCount
            && _tasks.All(task => task.Status == SessionTaskStatus.Closed))
        {
            Status = SessionStatus.Closed;
        }
    }

    /// <summary>
    /// Closes this session and awards zero points for any currently open task.
    /// </summary>
    public void Close()
    {
        if (Status == SessionStatus.Closed)
        {
            return;
        }

        var openTask = _tasks.SingleOrDefault(task => task.Status == SessionTaskStatus.Open);

        if (openTask is not null)
        {
            openTask.CloseWithScore(0);
        }

        Status = SessionStatus.Closed;
    }

    #endregion
}
