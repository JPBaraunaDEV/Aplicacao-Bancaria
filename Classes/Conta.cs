using System;

namespace bank
{
    public class Conta
    {
        private Tipo_Conta Tipo_Conta { get; set; }
        private double Credito { get; set; }
        private double Saldo { get; set; }
        private string Nome { get; set; }

        public Conta(Tipo_Conta tipo_Conta, double credito, double saldo, string nome)
        {
            this.Tipo_Conta = tipo_Conta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valor_saque)
        {
            if(this.Saldo - valor_saque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo Insuficiente!");
                return false;
            }
            
            this.Saldo -= valor_saque;

            Console.WriteLine($"Cliente: {this.Nome} \nSaldo Disponível: R${this.Saldo}");
            return true;

        }

        public void Depositar(double valor_deposito)
        {
            this.Saldo += valor_deposito;

            Console.WriteLine($"Cliente: {this.Nome} \nSaldo Disponível: R${this.Saldo}");
        }

        public void Transferir(double valor_tranferencia, Conta conta_destino)
        {
            if(this.Sacar(valor_tranferencia))
            {
                conta_destino.Depositar(valor_tranferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            
            retorno += " Tipo_Conta: "    + this.Tipo_Conta +   " | ";
            retorno += " Nome: "          + this.Nome       +   " | ";
            retorno += " Saldo: R$ "      + this.Saldo      +   " | ";
            retorno += " Credito: R$ "    + this.Credito    +   " | ";

            return retorno;
        }

    }
}