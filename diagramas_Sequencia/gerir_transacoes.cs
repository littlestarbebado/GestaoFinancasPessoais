using System;
using System.Collections.Generic;

namespace SistemaFinanceiro
{
    // Classe responsável por representar uma categoria de transação
    public class Categoria
    {
        // Guarda o nome da categoria
        private string nome;
        
        // Construtor da categoria
        // Recebe o nome e guarda-o
        public Categoria(string nome)
        {
            this.nome = nome;
        }

        // Método que devolve o nome da categoria
        public string GetNome() => nome;

        // Verifica se a categoria é válida
        public bool Validar()
        {
            // Se o nome estiver vazio ou só com espaços, não é válido
            if (string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine(" Categoria inválida!");
                return false;
            }
            // Caso contrário, a categoria é válida
            return true;
        }
    }

    // Classe responsável por representar uma transação financeira
    // Pode ser uma receita ou uma despesa
    public class Transacao
    {
        // Descrição da transação
        private string descricao;
        // Valor da transação
        private double valor;
        // Tipo da transação (Receita ou Despesa)   
        private string tipo; 
        // Categoria associada à transação
        private Categoria categoria;

        // Define a descrição da transação
        public void SetDescricao(string descricao) => this.descricao = descricao;
        // Define o valor da transação
        public void SetValor(double valor) => this.valor = valor;
        // Define o tipo da transação
        public void SetTipo(string tipo) => this.tipo = tipo;
        // Define a categoria da transação
        public void SetCategoria(Categoria categoria) => this.categoria = categoria;

        // Verifica se a transação é válida antes de ser guardada
        public bool Validar()
        {
            // A descrição não pode estar vazia
            if (string.IsNullOrWhiteSpace(descricao))
            {
                Console.WriteLine(" Descrição inválida!");
                return false;
            }

            // O valor tem de ser maior que zero
            if (valor <= 0)
            {
                Console.WriteLine(" Valor inválido!");
                return false;
            }

            // O tipo só pode ser Receita ou Despesa
            if (tipo != "Receita" && tipo != "Despesa")
            {
                Console.WriteLine(" Tipo inválido! Use 'Receita' ou 'Despesa'.");
                return false;
            }
            
            // A categoria também tem de ser válida
            if (!categoria.Validar())
            {
                return false;
            }

            // Se passar em todas as verificações, a transação é válida
            return true;
        }

        // Devolve um resumo da transação para mostrar no ecrã
        public string GetResumo()
        {
            return $"{tipo}: {descricao} | Valor: {valor} | Categoria: {categoria.GetNome()}";
        }
    }

    // Classe responsável por guardar e listar transações
    public class Persistencia
    {
        // Lista onde ficam guardadas todas as transações
        private List<Transacao> transacoes = new List<Transacao>();

        // Guarda uma transação na lista
        public void GuardarTransacao(Transacao t)
        {
            transacoes.Add(t);
            Console.WriteLine(" Transação guardada com sucesso!");
        }

        // Lista todas as transações guardadas
        public void ListarTransacoes()
        {
            Console.WriteLine("=== Todas as Transações ===");

            // Percorre a lista e mostra cada transação
            foreach (var t in transacoes)
            {
                Console.WriteLine(t.GetResumo());
            }
        }
    }

    // Classe principal do programa
    public class Programa
    {
        // Método Main — ponto de entrada do programa
        public static void Main(string[] args)
        {
            // Cria o objeto responsável por guardar transações
            Persistencia persistencia = new Persistencia();

            // Mensagem inicial para o utilizador
            Console.WriteLine("=== Gestor de Transações ===");

            // Cria uma nova transação
            Transacao t = new Transacao();

            // Pede a descrição da transação
            Console.Write("Descrição: ");
            t.SetDescricao(Console.ReadLine());

            // Pede o valor da transação
            Console.Write("Valor: ");
            double valor;

            // Garante que o utilizador insere um número válido
            while (!double.TryParse(Console.ReadLine(), out valor))
            {
                Console.Write("Valor inválido. Digite um número: ");
            }
            t.SetValor(valor);

            // Pede o tipo da transação
            Console.Write("Tipo (Receita/Despesa): ");
            string tipo = Console.ReadLine();
            t.SetTipo(tipo);

            // Pede o nome da categoria
            Console.Write("Categoria: ");
            string nomeCategoria = Console.ReadLine();

            // Cria a categoria e associa à transação
            Categoria c = new Categoria(nomeCategoria);
            t.SetCategoria(c);

            // Valida a transação antes de guardar
            if (t.Validar())
            {
                persistencia.GuardarTransacao(t);
            }
            else
            {
                Console.WriteLine(" Transação inválida. Não foi guardada.");
            }

            // Mostra todas as transações guardadas
            persistencia.ListarTransacoes();

            // Mantém o programa aberto
            Console.ReadLine();
        }
    }
}