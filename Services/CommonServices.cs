namespace Questor.Services
{
    /// <summary>
    /// Interface for common services.
    /// </summary>
    public interface ICommonServices
    {
        /// <summary>
        /// Validates a CPF number.
        /// </summary>
        /// <param name="cpf">The CPF number to validate.</param>
        /// <returns>True if the CPF is valid, false otherwise.</returns>
        public bool IsValidCPF(string? cpf);

        /// <summary>
        /// Validates a CNPJ number.
        /// </summary>
        /// <param name="cnpj">The CNPJ number to validate.</param>
        /// <returns>True if the CNPJ is valid, false otherwise.</returns>
        public bool IsValidCNPJ(string? cnpj);
    }

    public class CommonServices : ICommonServices
    {
        public bool IsValidCPF(string? cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                return false;

            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            bool allEqual = true;
            for (int i = 1; i < cpf.Length; i++)
            {
                if (cpf[i] != cpf[0])
                {
                    allEqual = false;
                    break;
                }
            }

            if (allEqual)
                return false;

            int[] multiplier1 = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier2 = new int[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf = cpf[..9];
            int sum = 0;

            for (int i = 0; i < 9; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplier1[i];

            int remainder = sum % 11;
            remainder = remainder < 2 ? 0 : 11 - remainder;

            string digit = remainder.ToString();
            tempCpf += digit;
            sum = 0;

            for (int i = 0; i < 10; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplier2[i];

            remainder = sum % 11;
            remainder = remainder < 2 ? 0 : 11 - remainder;

            digit += remainder.ToString();
            return cpf.EndsWith(digit);
        }

        public bool IsValidCNPJ(string? cnpj)
        {
            if (string.IsNullOrEmpty(cnpj))
                return false;

            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14)
                return false;

            bool allEqual = true;
            for (int i = 1; i < cnpj.Length; i++)
            {
                if (cnpj[i] != cnpj[0])
                {
                    allEqual = false;
                    break;
                }
            }

            if (allEqual)
                return false;

            int[] multiplier1 = new int[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier2 = new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCnpj = cnpj[..12];
            int sum = 0;

            for (int i = 0; i < 12; i++)
                sum += int.Parse(tempCnpj[i].ToString()) * multiplier1[i];

            int remainder = sum % 11;
            remainder = remainder < 2 ? 0 : 11 - remainder;

            string digit = remainder.ToString();
            tempCnpj += digit;
            sum = 0;

            for (int i = 0; i < 13; i++)
                sum += int.Parse(tempCnpj[i].ToString()) * multiplier2[i];

            remainder = sum % 11;
            remainder = remainder < 2 ? 0 : 11 - remainder;

            digit += remainder.ToString();
            return cnpj.EndsWith(digit);
        }
    }
}