namespace questor_challenge.Models
{
    public class Boleto
    {
        public int Id { get; set; }
        public int BankId { get; set; }
        public string PayerName { get; set; }
        public Identification PayerIdentification { get; private set; }
        public string BeneficiaryName { get; set; }
        public Identification BeneficiaryIdentification { get; private set; }
        public double Value { get; set; }
        public DateTime DueDate { get; set; }
        public string Observation { get; set; }
    }
}