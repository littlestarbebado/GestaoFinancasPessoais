using System;
using System.Collections.Generic;

namespace SistemaFinanceiro
{
    
    public class Utilizador
    {
        private int id;
        private string nome;
        private string email;

        public Utilizador(int id, string nome, string email)
        {
            this.id = id;
            this.nome = nome;
            this.email = email;
        }

        public int GetId() => id;
        public string GetNome() => nome;
        public string GetEmail() => email;

        public void SetNome(string nome) => this.nome = nome;
        public void SetEmail(string email) => this.email = email;

        public string GetResumo() => $"ID: {id} | Nome: {nome} | Email: {email}";
    }

    
    public class Persistencia
    {
        private List<Utilizador> utilizadores;

        public Persistencia()
        {
            utilizadores = new List<Utilizador>();

            // utilizadores teste
            utilizadores.Add(new Utilizador(1, "Emma Santos", "emma@example.com"));
            utilizadores.Add(new Utilizador(2, "João Silva", "joao@example.com"));
            utilizadores.Add(new Utilizador(3, "Ana Costa", "ana@example.com"));
        }

        public List<Utilizador> ListarUtilizadores() => utilizadores;

        public Utilizador CarregarDetalhes(int id)
        {
            foreach (var u in utilizadores)
            {
                if (u.GetId() == id)
                    return u;
            }
            return null;
        }

        public void GuardarUtilizador(Utilizador u)
        {
            
            Console.WriteLine($" Utilizador '{u.GetNome()}' atualizado com sucesso!");
        }

        public void RemoverUtilizador(int id)
        {
            Utilizador u = CarregarDetalhes(id);
            if (u != null)
            {
                utilizadores.Remove(u);
                Console.WriteLine($" Utilizador '{u.GetNome()}' removido com sucesso!");
            }
            else
            {
                Console.WriteLine(" Utilizador não encontrado!");
            }
        }
    }

    
    public class Programa
    {
        public static void Main(string[] args)
        {
            Persistencia persistencia = new Persistencia();
            bool continuar = true;

            Console.WriteLine("=== Gestor de Utilizadores ===");

            while (continuar)
            {
                Console.WriteLine("\nOpções:");
                Console.WriteLine("1 - Listar utilizadores");
                Console.WriteLine("2 - Atualizar utilizador");
                Console.WriteLine("3 - Remover utilizador");
                Console.WriteLine("4 - Sair");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.WriteLine("\n=== Lista de Utilizadores ===");
                        foreach (var u in persistencia.ListarUtilizadores())
                        {
                            Console.WriteLine(u.GetResumo());
                        }
                        break;

                    case "2":
                        Console.Write("Digite o ID do utilizador a atualizar: ");
                        int idAtualizar;
                        if (int.TryParse(Console.ReadLine(), out idAtualizar))
                        {
                            Utilizador u = persistencia.CarregarDetalhes(idAtualizar);
                            if (u != null)
                            {
                                Console.Write("Novo nome: ");
                                string novoNome = Console.ReadLine();
                                Console.Write("Novo email: ");
                                string novoEmail = Console.ReadLine();

                                u.SetNome(novoNome);
                                u.SetEmail(novoEmail);
                                persistencia.GuardarUtilizador(u);
                            }
                            else
                            {
                                Console.WriteLine("Utilizador não encontrado!");
                            }
                        }
                        break;

                    case "3":
                        Console.Write("Digite o ID do utilizador a remover: ");
                        int idRemover;
                        if (int.TryParse(Console.ReadLine(), out idRemover))
                        {
                            persistencia.RemoverUtilizador(idRemover);
                        }
                        break;

                    case "4":
                        continuar = false;
                        Console.WriteLine("Saindo do gestor de utilizadores...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }

            Console.ReadLine();
        }
    }
}