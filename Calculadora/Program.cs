using Application;
using Application.Context;
using System;
using System.IO;
using System.Linq;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();

            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("1 - Soma");
            Console.WriteLine("2 - Subtração");
            Console.WriteLine("3 - Divisão");
            Console.WriteLine("4 - Multiplicação");
            Console.WriteLine("5 - Sair");
            Console.WriteLine("6 - Arquivo");

            Console.WriteLine("----------");
            Console.WriteLine("Selecione uma opção: ");

            short res = short.Parse(Console.ReadLine());

            switch (res)
            {
                case 1: Soma(); break;
                case 2: Subtracao(); break;
                case 3: Divisao(); break;
                case 4: Multiplicacao(); break;
                case 5: Environment.Exit(0); break;
                default: Menu(); break;
            }
        }

        static void Soma()
        {
            Console.Clear();

            Console.WriteLine("Primeiro valor: ");
            float v1 = float.Parse(Console.ReadLine());
           
            Console.WriteLine("Segundo valor:");
            float v2 = float.Parse(Console.ReadLine());

            Console.WriteLine("");

            using (var context = new CalculadoraContext())
            {
                var operacao = new Operacoes("Soma", Operacoes.Soma(v1, v2), DateTime.Now);
                Console.WriteLine($"O resultado da soma é {operacao.Resultado}");

                context.Operacoes.Add(operacao);
                context.SaveChanges();

                Arquivo();

                Console.ReadKey();
                Menu();
            }
               
        }

        static void Subtracao()
        {
            Console.Clear();

            Console.WriteLine("Primeiro valor: ");
            float v1 = float.Parse(Console.ReadLine());

            Console.WriteLine("Segundo valor:");
            float v2 = float.Parse(Console.ReadLine());

            Console.WriteLine("");

            using (var context = new CalculadoraContext())
            {
                var operacao = new Operacoes("Subtração", Operacoes.Subtracao(v1, v2), DateTime.Now);
                Console.WriteLine($"O resultado da subtração é {operacao.Resultado}");

                context.Operacoes.Add(operacao);
                context.SaveChanges();

                Arquivo();

                Console.ReadKey();
                Menu();
            }
        }

        static void Divisao()
        {
            Console.Clear();

            Console.WriteLine("Primeiro valor: ");
            float v1 = float.Parse(Console.ReadLine());

            Console.WriteLine("Segundo valor:");
            float v2 = float.Parse(Console.ReadLine());

            Console.WriteLine("");

            using (var context = new CalculadoraContext())
            {
                var operacao = new Operacoes("Divisão", Operacoes.Divisao(v1, v2), DateTime.Now);
                Console.WriteLine($"O resultado da divisão é {operacao.Resultado}");
                
                context.Operacoes.Add(operacao);
                context.SaveChanges();

                Arquivo();

                Console.ReadKey();
                Menu();
            }
        }

        static void Multiplicacao()
        {
            Console.Clear();

            Console.WriteLine("Primeiro valor: ");
            float v1 = float.Parse(Console.ReadLine());

            Console.WriteLine("Segundo valor:");
            float v2 = float.Parse(Console.ReadLine());

            Console.WriteLine("");

            using (var context = new CalculadoraContext())
            {
                var operacao = new Operacoes("Multiplicação", Operacoes.Multiplicacao(v1, v2), DateTime.Now);
                Console.WriteLine($"O resultado da multiplicação é {operacao.Resultado}");

                context.Operacoes.Add(operacao);
                context.SaveChanges();

                Arquivo();

                Console.ReadKey();
                Menu();
            }
        }

        static void Arquivo()
        {
            Console.Clear();
            string path = @"C:\Users\Public\Documents\ultimo_comando.txt";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    using (var context = new CalculadoraContext())
                    {
                        var content = context.Operacoes.ToList();
                        foreach(var line in content)
                        {
                            sw.WriteLine($"{line.Id}: {line.NomeOperacao} - Resuldato: {line.Resultado} - Data: {line.DataHoraOperacao.ToString("dd/MM/yyyy HH:mm")}");
                        }
                    }
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    using (var context = new CalculadoraContext())
                    {
                        var content = context.Operacoes.ToList().LastOrDefault();
                        sw.WriteLine($"{content.Id}: {content.NomeOperacao} - Resuldato: {content.Resultado} - Data: {content.DataHoraOperacao.ToString("dd/MM/yyyy HH:mm")}");
                    }
                }
            }
            Menu();
        }
    }
}
