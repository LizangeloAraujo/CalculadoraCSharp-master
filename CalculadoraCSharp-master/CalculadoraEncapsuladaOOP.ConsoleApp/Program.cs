using System;
using System.Globalization;


namespace Calculadora.ConsoleApp
{
    class ProgramaOrientadoObjetos
    {
        
        static void Main(string[] args)
        {
           
            Calculadora minhaCalculadora = new Calculadora();

            while (true)
            {
                string opcao = Menu();

                if (opcao.Equals("sair", StringComparison.OrdinalIgnoreCase))
                    break;

                else if (opcao == "1")
                    RealizarCalculos(minhaCalculadora);

                else if (opcao == "2")
                    VisualizarHistoricoCalculos(minhaCalculadora);
                                
                Console.Clear();
            }
        }

        private static void VisualizarHistoricoCalculos(Calculadora minhaCalculadora)
        {
            Console.Clear();

            Console.WriteLine("Visualizando o histórico de calculos...\n");

            string[] calculosRealizados = minhaCalculadora.CalculosRealizados();

            foreach (string calculoRealizado in calculosRealizados)
                Console.WriteLine(calculoRealizado);

            Console.ReadLine();
        }

        private static void RealizarCalculos(Calculadora minhaCalculadora)
        {
            double resultado;
            string mensagem;
            bool conseguiuCalcular;
            string expressao;
            do
            {
                Console.Clear();

                Console.WriteLine("Digite a expressão conforme o exemplo → 123 + 12");
                Console.Write("Expressão: ");
                expressao = Console.ReadLine();

                conseguiuCalcular = minhaCalculadora.TentaCalcular(expressao, out resultado, out mensagem);

                if (conseguiuCalcular == false)
                {
                    Console.WriteLine(mensagem);
                    Console.ReadLine();
                }

            } while (conseguiuCalcular == false);

            Console.WriteLine($" O resultado é: {resultado}");

            Console.ReadLine();
        }

        private static string Menu()
        {
            Console.WriteLine(" ========== x CALCULADORA x ==========\n");

            Console.WriteLine("   Escolha a opção desejada abaixo ");

            Console.WriteLine("   # → 1 - para realizar o cálculo ");            

            Console.WriteLine("  # → SAIR - para encerrar o programa ");

            string opcao = Console.ReadLine();

            return opcao;
        }
    }
}