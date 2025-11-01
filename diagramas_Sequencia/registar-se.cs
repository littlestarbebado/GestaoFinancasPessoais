using System;

namespace SistemaFinanceiro
{
    public class Utilizador
    {
        private string nome;
        private string email;
        private string password;

        public void SetNome(string nome)
        {
            this.nome = nome;
        }

        public void SetEmail(string email)
        {
            this.email = email;
        }

        public void SetPassword(string password)
        {
            this.password = password;
        }

        public bool ValidarDados()
        {
            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine(" Erro: Todos os campos são obrigatórios.");
                return false;
            }

            if (!email.Contains("@"))
            {
                Console.WriteLine(" Erro: Email inválido.");
                return false;
            }

            return true;
        }

        public string GetNome() => nome;
        public string GetEmail() => email;
        public string GetPassword() => password;
    }

    public class Persistencia
    {
        public void GuardarUtilizador(Utilizador u)
        {
            
            Console.WriteLine($" Utilizador '{u.GetNome()}' guardado na base de dados!");
        }
    }

    public class Programa
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== Criar Conta ===");

            
            Utilizador u = new Utilizador();

            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            u.SetNome(nome);

            Console.Write("Email: ");
            string email = Console.ReadLine();
            u.SetEmail(email);

            Console.Write("Password: ");
            string password = Console.ReadLine();
            u.SetPassword(password);

            
            if (u.ValidarDados())
            {
                Persistencia p = new Persistencia();
                p.GuardarUtilizador(u);
                Console.WriteLine(" Conta criada com sucesso!");
            }
            else
            {
                Console.WriteLine(" Não foi possível criar a conta. Verifica os dados e tenta novamente.");
            }

            Console.ReadLine();
        }
    }
}