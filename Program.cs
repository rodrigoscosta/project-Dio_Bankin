using System;
using System.Collections.Generic;

namespace Bankin
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();

        static void Main(string[] args)
        {
            string opcaoDoUsuario = ObterOpcaoDoUsuario();

            while (opcaoDoUsuario.ToUpper() != "E")
            {
                switch (opcaoDoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        CadastrarConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoDoUsuario = ObterOpcaoDoUsuario();
            }

            Console.WriteLine("Obrigado(a) por utilizar nossos serviços, até breve!!");
            Console.ReadLine();
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listra contas");

            if (listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta encontrada.");
                Console.WriteLine();
                return;
            }

            for (int i = 0; i < listaContas.Count; i++)
            {
                Conta conta = listaContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static void CadastrarConta()
        {
            Console.WriteLine("Cadastrar nova conta");
            
            Console.Write("Digite 1 para Pessoa Física ou 2 para Pessoa Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do titular da conta: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial da conta: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o saldo de crédito inicial da conta: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);

            listaContas.Add(novaConta);
        }

        private static Transferir()
        {
            Console.Write("Digite o ID da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o ID da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite a quantia a ser transferida: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listaContas[indiceContaOrigem].Transferir(valorTransferencia, listaContas[indiceContaDestino]);
        }

        private static void Sacar()
        {
            Console.Write("Digite o ID da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite a quantia a ser sacada: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorSaque);
        }

        private static void Depositar()
        {
            Console.Write("Digite o ID da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite a quantia a ser depositada: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Depositar(valorDeposito);
        }

        private static string ObterOpcaoDoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Bem vindo(a) ao Bankin!!!");
            Console.WriteLine();
            Console.WriteLine("Digite a opção desejada: ");

            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Cadastrar uma conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar terminal");
            Console.WriteLine("E - Sair");
            Console.WriteLine();

            string opcaoDoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoDoUsuario;
        }
    }
}