using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuiverPro.ClassesNavega
{
    class GeradorCpfCnpj
    {
        #region Gera CPF
        public string CadastroPF()
        {

            int soma = 0, resto = 0;
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            Random rnd = new Random();
            string semente = rnd.Next(100000000, 999999999).ToString();

            for (int i = 0; i < 9; i++)
                soma += int.Parse(semente[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            semente = semente + resto;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(semente[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            semente = semente + resto;
            return semente;

        }
        #endregion

        #region Gera CNPJ
        public string GerarCNPJ()
        {
            // Gerar 8 números aleatórios de 0 a 9 e 4 números (0001), e depois calcular eles
            // Colocar eles na maskedTextBox

            Random rnd = new Random();
            int n1 = rnd.Next(0, 10);
            int n2 = rnd.Next(0, 10);
            int n3 = rnd.Next(0, 10);
            int n4 = rnd.Next(0, 10);
            int n5 = rnd.Next(0, 10);
            int n6 = rnd.Next(0, 10);
            int n7 = rnd.Next(0, 10);
            int n8 = rnd.Next(0, 10);
            int n9 = 0;
            int n10 = 0;
            int n11 = 0;
            int n12 = 1;

            int Soma1 = n1 * 5 + n2 * 4 + n3 * 3 + n4 * 2 + n5 * 9 + n6 * 8 + n7 * 7 + n8 * 6 + n9 * 5 + n10 * 4 + n11 * 3 + n12 * 2;

            int DV1 = Soma1 % 11;

            if (DV1 < 2)
            {
                DV1 = 0;
            }
            else
            {
                DV1 = 11 - DV1;
            }

            int Soma2 = n1 * 6 + n2 * 5 + n3 * 4 + n4 * 3 + n5 * 2 + n6 * 9 + n7 * 8 + n8 * 7 + n9 * 6 + n10 * 5 + n11 * 4 + n12 * 3 + DV1 * 2;

            int DV2 = Soma2 % 11;

            if (DV2 < 2)
            {
                DV2 = 0;
            }
            else
            {
                DV2 = 11 - DV2;
            }

            return n1.ToString() + n2 + n3 + n4 + n5 + n6 + n7 + n8 + n9 + n10 + n11 + n12 + DV1 + DV2;
        }
        #endregion

        #region Gera RG
        public string GerarRG()
        {
            // Gerar 8 números aleatórios de 0 a 9
            // Calcular esses 8 números e gerar o Dígito Verificador
            // Se o resto for igual a 0, DV = 0.
            // Se o resto for igual a 1, DV = X.
            // Se não, DV = 11 - resto.

            Random rnd = new Random();

            int n1 = rnd.Next(0, 10);
            int n2 = rnd.Next(0, 10);
            int n3 = rnd.Next(0, 10);
            int n4 = rnd.Next(0, 10);
            int n5 = rnd.Next(0, 10);
            int n6 = rnd.Next(0, 10);
            int n7 = rnd.Next(0, 10);
            int n8 = rnd.Next(0, 10);

            int soma = (n1 * 2) + (n2 * 3) + (n3 * 4) + (n4 * 5) + (n5 * 6) + (n6 * 7) + (n7 * 8) + (n8 * 9);

            int resto = soma % 11;
            string DV;

            if (resto == 0)
            {
                DV = "0";
            }
            else if (resto == 1)
            {
                DV = "X";
            }
            else
            {
                DV = (11 - resto).ToString();
            }

            return n1.ToString() + n2 + n3 + n4 + n5 + n6 + n7 + n8 + DV;
        }
        #endregion

    }
}
