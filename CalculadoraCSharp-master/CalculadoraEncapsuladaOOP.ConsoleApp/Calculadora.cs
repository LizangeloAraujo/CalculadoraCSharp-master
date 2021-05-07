using System.Linq;
using System;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Calculadora.ConsoleApp
{   
    public class Calculadora
    {
        public string primeiroValor;
        public string segundoValor;
        public string operador;
        public string[] calculosRealizados = new string[100];

        public bool TentaCalcular(string expressao, out double resultado, out string mensagem)
        {
            double primeiroNumero, segundoNumero;
            mensagem = " ";
            resultado = 0.0;

            if (!VerificaExpressao(expressao))
            {
                mensagem = " Entrada inválida, por favor insira uma entrada válida ";
                return false;
            }

            
            // VALIDAÇÃO
            if (double.TryParse(primeiroValor, out primeiroNumero) == false)
            {
                mensagem = "Primeiro número inválido";
                return false;
            }
            if (double.TryParse(segundoValor, out segundoNumero) == false)
            {
                mensagem = "Segundo número inválido";
                return false;
            }
            if (operador != "+" && operador != "-" && operador != "*" && operador != "/")
            {
                mensagem = "Operador inválido";
                return false;
            }
            if (operador == "/" && segundoNumero == 0)
            {
                mensagem = "Não é possível dividir por zero";
                return false;
            }

            if (operador == "+")
                resultado = primeiroNumero + segundoNumero;

            else if (operador == "-")
                resultado = primeiroNumero - segundoNumero;

            else if (operador == "*")
                resultado = primeiroNumero * segundoNumero;

            else if (operador == "/")
                resultado = primeiroNumero / segundoNumero;


            calculosRealizados[ObterPosicaoVazia()] = $" {primeiroNumero}  {operador}  {segundoNumero}  = {resultado.ToString("F3", CultureInfo.InvariantCulture)} ";

            return true;
        }

        // Verifica operadores

        public bool VerificaExpressao(string expressao)
        {

            if (VerificarSimboloAdicao(expressao))
            {
                if ((VerificarSimboloSubtracao(expressao)) || (VerificarSimboloMultiplicacao(expressao)) ||
                   (VerificarSimboloDivisao(expressao)))
                {
                    return false;
                }
                if (Regex.Matches(expressao, "\\+").Count > 1)
                {
                    return false;
                }
                primeiroValor = expressao.Split('+')[0];
                segundoValor = expressao.Split('+')[1];
                operador = "+";
                return true;
            }

            if (VerificarSimboloSubtracao(expressao))
            {
                if ((VerificarSimboloAdicao(expressao)) || (VerificarSimboloMultiplicacao(expressao)) ||
                   (VerificarSimboloDivisao(expressao)))
                {
                    return false;
                }
                if (Regex.Matches(expressao, "-").Count > 1)
                {
                    return false;
                }
                primeiroValor = expressao.Split('-')[0];
                segundoValor = expressao.Split('-')[1];
                operador = "-";
                return true;
            }

            if (VerificarSimboloMultiplicacao(expressao))
            {
                if ((VerificarSimboloSubtracao(expressao)) || (VerificarSimboloAdicao(expressao)) ||
                   (VerificarSimboloDivisao(expressao)))
                {
                    return false;
                }
                if (Regex.Matches(expressao, "\\*").Count > 1)
                {
                    return false;
                }
                primeiroValor = expressao.Split('*')[0];
                segundoValor = expressao.Split('*')[1];
                operador = "*";
                return true;
            }

            if (VerificarSimboloDivisao(expressao))
            {
                if ((VerificarSimboloSubtracao(expressao)) || (VerificarSimboloMultiplicacao(expressao)) ||
                    (VerificarSimboloAdicao(expressao)))
                {
                    return false;
                }
                if (Regex.Matches(expressao, "/").Count > 1)
                {
                    return false;
                }
                primeiroValor = expressao.Split('/')[0];
                segundoValor = expressao.Split('/')[1];
                operador = "/";
                return true;
            }
            return false;
            
        }

        public bool VerificarSimboloSubtracao(string expressao)
        {
            if (expressao.Contains("-"))
            {
                return true;           
            }
            return false;
        }

        public bool VerificarSimboloMultiplicacao(string expressao)
        {
            if (expressao.Contains("*"))
            {
                return true;
            }
            return false;
        }

        public bool VerificarSimboloDivisao(string expressao)
        {
            if (expressao.Contains("/"))
            {
                return true;
            }
            return false;
        }

        public bool VerificarSimboloAdicao(string expressao)
        {
            if (expressao.Contains("+"))
            {
                return true;
            }
            return false;
        }

        public int ObterPosicaoVazia()
        {
            int posicaoVazia = 0;

            for (int i = 0; i < calculosRealizados.Length; i++)
            {
                if (calculosRealizados[i] == null)
                {
                    posicaoVazia = i; break;
                }
            }
            return posicaoVazia;
        }

        public int QuantidadeCalculosRealizados()
        {
            int qtdCalculos = 0;

            for (int i = 0; i < calculosRealizados.Length; i++)
            {
                if (calculosRealizados[i] != null)
                {
                    qtdCalculos++;
                }
            }
            return qtdCalculos;
        }

        public string[] CalculosRealizados()
        {
            int qtd = QuantidadeCalculosRealizados();

            string[] calculosRealizadosAux = new string[qtd];

            for (int i = 0; i < qtd; i++)
            {
                calculosRealizadosAux[i] = calculosRealizados[i];
            }

            return calculosRealizadosAux;
        }
    }
}