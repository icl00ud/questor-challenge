using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace questor_challenge.Models
{
    /// <summary>
    /// Represents a Boleto (bank slip) entity.
    /// </summary>
    public class Boleto
    {
        /// <summary>
        /// The unique identifier of the boleto.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The ID of the bank where the boleto will be paid.
        /// </summary>
        [Required]
        public int BankId { get; set; }
        
        /// <summary>
        /// The bank associated with the boleto.
        /// </summary>
        [NotMapped]
        public Banco? Banco { get; set; }
        
        /// <summary>
        /// The name of the payer who will pay the boleto.
        /// </summary>
        [Required]
        public string? PayerName { get; set; }

        /// <summary>
        /// The identification number of the payer who will pay the boleto.
        /// </summary>
        [Required]
        public string? PayerIdentification { get; set; }

        /// <summary>
        /// The name of the beneficiary who will receive the payment of the boleto.
        /// </summary>
        [Required]
        public string? BeneficiaryName { get; set; }

        /// <summary>
        /// The identification number of the beneficiary who will receive the payment of the boleto.
        /// </summary>
        [Required]
        public string? BeneficiaryIdentification { get; set; }

        /// <summary>
        /// The value of the boleto.
        /// </summary>
        [Required]
        public double Value { get; set; }

        /// <summary>
        /// The fee charged for processing the boleto.
        /// </summary>
        [NotMapped]
        public double Fee { get; set; }

        /// <summary>
        /// The due date of the boleto.
        /// </summary>
        [Required]
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Additional observation about the boleto.
        /// </summary>
        [Range(0, 120, ErrorMessage = "Observation cannot exceed 120 characters.")]
        public string? Observation { get; set; }
    }
}