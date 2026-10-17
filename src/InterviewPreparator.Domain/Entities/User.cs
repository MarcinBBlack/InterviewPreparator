namespace InterviewPreparator.Domain.Entities;

public class User : Entity
{
    #region Properties

    /// <summary>
    /// Gets the user's login.
    /// </summary>
    public string Login { get; private set; }

    /// <summary>
    /// Gets the user's hashed password.
    /// </summary>
    public string PasswordHash { get; private set; }

    #endregion

    #region Constructors

    /// <summary>
    /// Creates a user account.
    /// </summary>
    /// <param name="login">The user's login.</param>
    /// <param name="passwordHash">The user's hashed password.</param>
    public User(string login, string passwordHash)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(login);
        ArgumentException.ThrowIfNullOrWhiteSpace(passwordHash);

        Login = login.Trim();
        PasswordHash = passwordHash;
    }

    #endregion
}
