using Dio.Bank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.Bank
{
    internal class Menu
    {
        static List<Conta> listContas = new List<Conta>();
        public static int ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Sejam bem-vindos(a) ao DIO Bank a seu dispor!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Cadastrar nova conta ");
            Console.WriteLine("2- Listar contas");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("6- Sair");
            Console.WriteLine();

            int opcaoUsuario = int.Parse(Console.ReadLine());

            while (opcaoUsuario != 6)
            {
                switch (opcaoUsuario)
                {
                    case 1:
                        CadastrarConta();
                        break;
                    case 2:
                        ListarContas();
                        break;
                    case 3:
                        Transferir();
                        break;
                    case 4:
                        Sacar();
                        break;
                    case 5:
                        Depositar();
                        break;
                    case 6:
                        Console.WriteLine();
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Opção inválida"); ObterOpcaoUsuario();
                        break;
                }
            }

            return opcaoUsuario;
            
        }

        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Didite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);

            Console.WriteLine("Pressione ENTER para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            ObterOpcaoUsuario();

        }

        private static void Sacar()
        {

            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
            
            Console.WriteLine("Pressione ENTER para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            ObterOpcaoUsuario();

        }

        private static void ListarContas()
        {
            Console.Clear();
            Console.WriteLine("Listando contas cadastradas...");
            Thread.Sleep(3000);
            Console.WriteLine("Aguarde...");
            Thread.Sleep(2000);
            Console.Clear();
            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada!");
                Console.WriteLine("Você será redirecionado para o menu principal em 5 segundos...");
                Thread.Sleep(5000);
                Console.Clear();
                ObterOpcaoUsuario();
            }
            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.WriteLine($"Número da conta: {i}");
                Console.WriteLine($"{conta}");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Aqui estão todas as contas cadastradas até o momento!");
            Console.WriteLine("Pressione ENTER para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            ObterOpcaoUsuario();


        }

        private static void CadastrarConta()
        {
            Console.Clear();
            Console.Write("Inserir nova conta ");

            Console.Write("Digite 1 para Conta Física ou 2 para Jurídica:");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                         saldo: entradaSaldo,
                                         credito: entradaCredito,
                                         nome: entradaNome);
            listContas.Add(novaConta);

            Console.WriteLine("Cliente cadastrado com sucesso!");
            Console.WriteLine("Precione enter para voltar ao Menu principal");
            Console.ReadKey();
            Console.Clear();
            ObterOpcaoUsuario();
        }
    }
}
