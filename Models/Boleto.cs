using System.ComponentModel.DataAnnotations;
using Questor.Services;

namespace questor_challenge.Models
{
    public class Boleto
    {
        CommonServices _commonServices = new CommonServices();

        [Key]
        public int Id { get; set; }
        [Required]
        public int BankId { get; set; }
        [Required]
        public string PayerName { get; set; }
        [Required]
        public string PayerIdentification
        {
            get => PayerIdentification;
            set
            {
                if (_commonServices.IsValidCPF(value) || _commonServices.IsValidCNPJ(value))
                {
                    PayerIdentification = value;
                }
                else
                {
                    throw new ArgumentException("Invalid CPF or CNPJ");
                }
            }
        }
        [Required]
        public string BeneficiaryName { get; set; }
        [Required]
        public string BeneficiaryIdentification
        {
            get => BeneficiaryIdentification;
            set
            {
                if (_commonServices.IsValidCPF(value) || _commonServices.IsValidCNPJ(value))
                {
                    BeneficiaryIdentification = value;
                }
                else
                {
                    throw new ArgumentException("Invalid CPF or CNPJ");
                }
            }
        }
        [Required]
        public double Value { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        public string Observation { get; set; }
    }
}