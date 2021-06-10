using System;
using System.Collections.Generic;
using System.IO;

namespace GeradorNumerosAleatorios
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Para criar um arquivo digite 'C' ");
            try
            {
                string CL = Console.ReadLine().ToUpper();
                if (CL == "C")
                {
                    Criar();
                }
                else
                {
                    Console.WriteLine("FIM");
                }

            }
            catch (FormatException)
            {

                Console.WriteLine("Tipo de dado incorreto, insira Apenas Letras");
            }


            Console.WriteLine("Concluido");
            Console.ReadKey();

        }
        public static void Criar()
        {
            bool value = true;
            int nDados = 0;

            do
            {
                Console.WriteLine("DIGITE O NUMERO DE DADOS A SEREM GERADOS :");
                try
                {
                    nDados = Convert.ToInt32(Console.ReadLine());
                    EscreveArquivo(nDados, CriaArquivo(CriaPasta(), nDados));

                    Console.WriteLine("Gerar Mais? S/N");
                    string val = Console.ReadLine().ToUpper();
                    if (!(val == "S"))
                        value = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Tipo de dado incorreto, insira valores inteiros");
                }

            } while (value);

        }
        private static DirectoryInfo CriaPasta()
        {
            String path = AppDomain.CurrentDomain.BaseDirectory.ToString();
            DirectoryInfo di = Directory.CreateDirectory($"{path}\\Arquivos");
            return di;
        }

        private static StreamWriter CriaArquivo(DirectoryInfo directory, int nDados)
        {
            string CaminhoNome = $"{directory}\\{nDados}-Dados.csv";

            return File.CreateText(CaminhoNome);
        }

        private static void EscreveArquivo(int nDados, StreamWriter sw)
        {

            List<int> numeros = new List<int>();
            Random rnd = new Random();

            for (int i = 0; i < nDados; i++)
            {
                int numero = rnd.Next(1, nDados + 1);

                while (numeros.Contains(numero))
                {
                    numero = rnd.Next(1, nDados + 1);
                }
                //Console.WriteLine($"{numero},");
                numeros.Add(numero);
                sw.Write($"{numero},");

            }
            sw.Close();

        }
    }
}
