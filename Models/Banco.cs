using System.ComponentModel.DataAnnotations;

/// <summary>
/// Represents a bank entity.
/// </summary>
public class Banco
{
    /// <summary>
    /// The unique identifier of the bank.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// The name of the bank.
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    /// The code of the bank.
    /// </summary>
    [Required]
    public string Code { get; set; }

    /// <summary>
    /// The interest percentage of the bank.
    /// </summary>
    [Required]
    public decimal InterestPercentage { get; set; }
}