using System.ComponentModel.DataAnnotations.Schema;

namespace InterviewPreparator.Domain.Entities;

public abstract class Entity
{
    #region Properties

    /// <summary>
    /// Gets or sets the entity's unique identifier.
    /// </summary>
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Int32 Id { get; set; }

    #endregion
}
