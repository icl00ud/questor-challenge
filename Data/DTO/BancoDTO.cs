using System.ComponentModel.DataAnnotations;

namespace questor_challenge.Data.DTO
{
    /// <summary>
    /// Data transfer object for creating a new Bank.
    /// </summary>
    public class CreateBancoDTO
    {
        /// <summary>
        /// The name of the Bank.
        /// </summary>
        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; }

        /// <summary>
        /// The code of the Bank.
        /// </summary>
        [Required(ErrorMessage = "Code is required.")]
        public string? Code { get; set; }

        /// <summary>
        /// The interest percentage of the Bank.
        /// </summary>
        [Required(ErrorMessage = "Interest percentage is required.")]
        public decimal InterestPercentage { get; set; }
    }

    /// <summary>
    /// Data transfer object for reading a Bank entity.
    /// </summary>
    public class ReadBancoDTO
    {
        /// <summary>
        /// The ID of the Bank.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the Bank.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The code of the Bank.
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// The interest percentage of the Bank.
        /// </summary>
        public decimal InterestPercentage { get; set; }
    }
}