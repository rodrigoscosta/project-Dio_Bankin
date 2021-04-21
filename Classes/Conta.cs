using System;

namespace Bankin
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }

        private double Saldo { get; set; }

        private double Credito { get; set; }

        private string Nome { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

            // Valida se o usuário possui saldo suficiente
        public bool SacarDinheiro(double valorSaque)
        {
            if (this.Saldo - valorSaque < (this.Credito *- 1))
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            this.Saldo -= valorSaque;
            
            Console.WriteLine("{0}, o saldo atual da sua conta é de {1}", this.Nome, this.Saldo);
            return true;
        }

        public void DepositarDinheiro(double valorDeposito)
        {
            this.Saldo += valorDeposito;

            Console.WriteLine("{0}, o saldo atual da sua conta é de {1}", this.Nome, this.Saldo);
        }

        public void TransferirDinheiro(double valorTransferencia, Conta contaDestino)
        {
            if (this.SacarDinheiro(valorTransferencia))
            {
                contaDestino.DepositarDinheiro(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Crédito " + this.Credito;
            return retorno;
        }
    }
}