using questor_challenge.Data;
using questor_challenge.Models;

namespace questor_challenge.Services
{
    /// <summary>
    /// Interface for calculating fees for a Boleto.
    /// </summary>
    public interface IFeeServices
    {
        /// <summary>
        /// Calculates the daily fee for a Boleto based on the number of days past due.
        /// </summary>
        /// <param name="boleto">The Boleto to calculate the fee for.</param>
        /// <param name="daysPast">The number of days past due.</param>
        /// <returns>A tuple containing the value of the Boleto with the fee added and the fee amount.</returns>
        public Task<(double valueWithFee, double fee)> CalculateDailyFee(Boleto boleto, int daysPast);
    }

    /// <summary>
    /// Service for calculating fees for a Boleto.
    /// </summary>
    public class FeeServices : IFeeServices
    {
        private QuestorContext Context { get; }

        public FeeServices(QuestorContext context)
        {
            Context = context;
        }

        /// <inheritdoc/>
        public async Task<(double valueWithFee, double fee)> CalculateDailyFee(Boleto boleto, int daysPast)
        {
            Banco? bank = await Context.Bancos.FindAsync(boleto.BankId) ?? throw new ArgumentNullException("CalculateDailyFee: The bill is not linked to any bank.");

            // Calcula o valor dos juros diários
            double fee = bank.InterestPercentage / 100 * boleto.Value * daysPast;
            double valueWithFee = boleto.Value + fee;

            return (Math.Round(valueWithFee, 2), Math.Round(fee, 2));
        }
    }
}