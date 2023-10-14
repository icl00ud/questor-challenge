using System;
using System.Text.RegularExpressions;

namespace questor_challenge.Models
{
    public class Identification
    {
        public string Value { get; private set; }

        public Identification(string value)
        {
            if (IsValidCPF(value) || IsValidCNPJ(value))
            {
                Value = value;
            }
            else
            {
                throw new ArgumentException("Invalid CPF or CNPJ");
            }
        }

        private bool IsValidCPF(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            cpf = Regex.Replace(cpf, "[^0-9]", ""); // Remoção de caracteres

            if (cpf.Length != 11)
                return false;

            // Início do algorítmo de verificação do CPF
            int[] cpfDigits = new int[11];
            for (int i = 0; i < 11; i++)
                cpfDigits[i] = int.Parse(cpf[i].ToString());

            int sum1 = 0;
            int sum2 = 0;

            for (int i = 0; i < 9; i++)
            {
                sum1 += cpfDigits[i] * (10 - i);
                sum2 += cpfDigits[i] * (11 - i);
            }

            int remainder1 = (sum1 % 11) < 2 ? 0 : 11 - (sum1 % 11);
            int remainder2 = (sum2 % 11) < 2 ? 0 : 11 - (sum2 % 11);

            return cpfDigits[9] == remainder1 && cpfDigits[10] == remainder2;
        }

        private bool IsValidCNPJ(string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj))
                return false;

            cnpj = Regex.Replace(cnpj, "[^0-9]", ""); // Remoção de caracteres

            if (cnpj.Length != 14)
                return false;

            // Início do algorítmo de verificação do CNPJ
            int[] cnpjDigits = new int[14];
            for (int i = 0; i < 14; i++)
                cnpjDigits[i] = int.Parse(cnpj[i].ToString());

            int[] weight1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] weight2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int sum1 = 0;
            int sum2 = 0;

            for (int i = 0; i < 12; i++)
            {
                sum1 += cnpjDigits[i] * weight1[i];
                sum2 += cnpjDigits[i] * weight2[i];
            }

            int remainder1 = (sum1 % 11) < 2 ? 0 : 11 - (sum1 % 11);
            int remainder2 = (sum2 % 11) < 2 ? 0 : 11 - (sum2 % 11);

            return cnpjDigits[12] == remainder1 && cnpjDigits[13] == remainder2;
        }
    }
}
