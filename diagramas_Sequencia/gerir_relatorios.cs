using System;
using System.Collections.Generic;

namespace SistemaFinanceiro
{
    // Classe que representa uma transação financeira
    // Cada transação tem uma descrição, um valor e um tipo (Receita ou Despesa)
    public class Transacao
    {
        // Descrição da transação
        private string descricao;

        // Valor da transação
        private double valor;

        // Tipo da transação (Receita ou Despesa)
        private string tipo; 

        // Construtor da transação
        // Recebe a descrição, o valor e o tipo e guarda esses dados
        public Transacao(string descricao, double valor, string tipo)
        {
            this.descricao = descricao;
            this.valor = valor;
            this.tipo = tipo;
        }

        // Devolve a descrição da transação
        public string GetDescricao() => descricao;

        // Devolve o valor da transação
        public double GetValor() => valor;

        // Devolve o tipo da transação
        public string GetTipo() => tipo;
    }

    // Classe responsável por guardar e fornecer as transações
    public class Persistencia
    {
        // Lista onde ficam guardadas todas as transações
        private List<Transacao> transacoes;

        // Construtor da persistência
        public Persistencia()
        {
            // Inicializa a lista de transações
            transacoes = new List<Transacao>();

            // Transações de exemplo para o sistema já ter dados
            transacoes.Add(new Transacao("Venda produto", 200, "Receita"));
            transacoes.Add(new Transacao("Compra material", 50, "Despesa"));
            transacoes.Add(new Transacao("Serviço prestado", 150, "Receita"));
            transacoes.Add(new Transacao("Conta de luz", 75, "Despesa"));
        }

        // Método que devolve as transações de um determinado período
        public List<Transacao> ObterTransacoes(string periodo)
        {
            // Devolve todas as transações existentes
            return transacoes;
        }
    }

    // Classe responsável por gerar relatórios financeiros
    public class Relatorio
    {
        // Lista de transações usada para criar o relatório
        private List<Transacao> transacoes;

        // Construtor do relatório
        // Recebe a lista de transações que vão ser analisadas
        public Relatorio(List<Transacao> transacoes)
        {
            this.transacoes = transacoes;
        }

        // Calcula o total de receitas
        public double CalcularTotalReceitas()
        {
            double total = 0;

            // Percorre todas as transações
            foreach (var t in transacoes)
            {
                // Se for receita, soma ao total
                if (t.GetTipo() == "Receita")
                    total += t.GetValor();
            }
            return total;
        }

        // Calcula o total de despesas
        public double CalcularTotalDespesas()
        {
            double total = 0;

            // Percorre todas as transações
            foreach (var t in transacoes)
            {
                // Se for despesa, soma ao total
                if (t.GetTipo() == "Despesa")
                    total += t.GetValor();
            }
            return total;
        }

        // Calcula o saldo final
        // Saldo = Total de Receitas - Total de Despesas
        public double CalcularSaldo()
        {
            return CalcularTotalReceitas() - CalcularTotalDespesas();
        }

        // Mostra o relatório completo no ecrã
        public void GerarRelatorio()
        {
            Console.WriteLine("=== Relatório Financeiro ===");

            // Mostra todas as transações
            Console.WriteLine("Transações:");
            foreach (var t in transacoes)
            {
                Console.WriteLine($"{t.GetTipo()}: {t.GetDescricao()} | Valor: {t.GetValor()}");
            }

            // Linha de separação visual
            Console.WriteLine("----------------------------");

            // Mostra os totais calculados
            Console.WriteLine($"Total Receitas: {CalcularTotalReceitas()}");
            Console.WriteLine($"Total Despesas: {CalcularTotalDespesas()}");
            
            // Mostra o saldo final
            Console.WriteLine($"Saldo: {CalcularSaldo()}");
        }
    }

    
    // Classe principal do programa
    public class Programa
    {
        //Método Main — ponto de entrada do programa
        public static void Main(string[] args)
        {
            // Cria o objeto responsável por guardar as transações 
            Persistencia persistencia = new Persistencia();

            // Mensagem inicial para o utilizador
            Console.WriteLine("=== Gerar Relatório Financeiro ===");

            // Pede ao utilizador o período (ex: Janeiro)
            Console.Write("Período (ex: Janeiro): ");
            string periodo = Console.ReadLine();

            // Obtém as transações do período escolhido
            List<Transacao> transacoesPeriodo = persistencia.ObterTransacoes(periodo);

            // Cria o relatório com as transações obtidas
            Relatorio relatorio = new Relatorio(transacoesPeriodo);

            // Gera e mostra o relatório no ecrã
            relatorio.GerarRelatorio();

            // Mantém o programa aberto
            Console.ReadLine();
        }
    }
}