using System;
using System.Collections.Generic;

namespace bank
{
    class Program
    {
        static List<Conta> lista_contas = new List<Conta>();
        static void Main(string[] args)
        {
            string escolha = Menu();

            while(escolha.ToUpper() != "X")
            {
                switch (escolha)
                {
                    case "1":
                        Listar_Contas();
                        break;
                    case "2":
                        Inserir_Contas();
                        break;
                    case "3":
                        Transferencia();
                        break;
                    case "4":
                        Saque();
                        break;
                    case "5":
                        Deposite();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                escolha = Menu();

            }

            Console.WriteLine("AGRADECEMOS PELA PREFERENCIA!");
            Console.ReadLine();

        }

        private static string Menu()
        {
            Console.WriteLine();
            
            Console.WriteLine("SELECIONE A OPCAO DESEJADA: ");
            
            Console.WriteLine();
            
            Console.WriteLine("     1 >> LISTAR CONTAS");
            Console.WriteLine("     2 >> INSERIR NOVAS CONTAS");
            Console.WriteLine("     3 >> TRANSFERIR");
            Console.WriteLine("     4 >> SACAR");
            Console.WriteLine("     5 >> DEPOSITAR");

            Console.WriteLine();

            Console.WriteLine("C -- LIMPAR TELA");
            Console.WriteLine("X -- SAIR");

            Console.Write(">> ");

            string menu_escolha = Console.ReadLine().ToUpper();

            Console.WriteLine();

            return menu_escolha;
        }

        private static void Listar_Contas()
        {
            Console.WriteLine();
            
            Console.WriteLine("LISTAR CONTAS");
            
            if(lista_contas.Count == 0)
            {
                Console.WriteLine("NÃO HÁ NENHUM CLIENTE CADASTRADO!");
                return;
            }

            for(int i = 0; i < lista_contas.Count; i++)
            {
                Conta conta = lista_contas[i];
                Console.Write($"{i} -- ");
                Console.WriteLine(conta);
            }

        }
        
        private static void Inserir_Contas()
        {
            Console.WriteLine();

            Console.WriteLine("INSERIR NOVA CONTA");

            Console.Write("1 -- Pessoa Física \n2 -- Pessoa Jurídica \n>> ");
            int entrada_TipoConta = int.Parse(Console.ReadLine());

            Console.Write("NOME DO CLIENTE: ");
            string entrada_Nome = Console.ReadLine();

            Console.Write("SALDO INICIAL : R$ ");
            double entrada_Saldo = double.Parse(Console.ReadLine());

            Console.Write("VALOR CRÉDITO : R$ ");
            double entrada_Credito = double.Parse(Console.ReadLine());
            
            Conta nova_conta = new Conta(tipo_Conta: (Tipo_Conta)entrada_TipoConta,
                                         saldo: entrada_Saldo,
                                         credito: entrada_Credito,
                                         nome: entrada_Nome);
            
            lista_contas.Add(nova_conta);
        }

        private static void Transferencia()
        {
            Console.WriteLine("TRANSFERIR");

            Console.WriteLine("INSIRA O NÚMERO DA CONTA DE ORIGEM: ");
            int conta_origem = int.Parse(Console.ReadLine());

            Console.WriteLine("INSIRA O NÚMERO DA CONTA DE DESTINO: ");
            int conta_destino = int.Parse(Console.ReadLine());
            
            Console.WriteLine("INSIRA O VALOR A SER TRANSFERIDO: R$");
            double valor_tranferencia = double.Parse(Console.ReadLine());

            lista_contas[conta_origem].Transferir(valor_tranferencia, lista_contas[conta_destino]);
        }
        private static void Saque()
        {
            Console.WriteLine("SACAR");

            Console.WriteLine("INSIRA O NÚMERO DA CONTA: ");
            int indice_conta = int.Parse(Console.ReadLine());

            Console.WriteLine("INSIRA O VALOR DO SAQUE: R$");
            double valor_saque = double.Parse(Console.ReadLine());

            lista_contas[indice_conta].Sacar(valor_saque);
        }

        private static void Deposite()
        {
            Console.WriteLine("DEPOSITAR");

            Console.WriteLine("INSIRA O NÚMERO DA CONTA: ");
            int indice_conta = int.Parse(Console.ReadLine());

            Console.WriteLine("INSIRA O VALOR DO DEPOSITO: R$");
            double valor_deposito = double.Parse(Console.ReadLine());

            lista_contas[indice_conta].Depositar(valor_deposito);
        }

    }
}
