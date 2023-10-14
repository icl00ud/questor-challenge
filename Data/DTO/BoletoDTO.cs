using System.ComponentModel.DataAnnotations;

namespace questor_challenge.DTOs
{
    public class BoletoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "BankId is required.")]
        public int BankId { get; set; }

        [Required(ErrorMessage = "PayerName is required.")]
        public string PayerName { get; set; }

        [Required(ErrorMessage = "PayerIdentification is required.")]
        public string PayerIdentification { get; set; }

        [Required(ErrorMessage = "BeneficiaryName is required.")]
        public string BeneficiaryName { get; set; }

        [Required(ErrorMessage = "BeneficiaryIdentification is required.")]
        public string BeneficiaryIdentification { get; set; }

        [Required(ErrorMessage = "Value is required.")]
        public double Value { get; set; }

        [Required(ErrorMessage = "DueDate is required.")]
        public DateTime DueDate { get; set; }

        public string Observation { get; set; }
    }
}
