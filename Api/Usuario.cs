namespace Api
{
    public class Usuario
    {
        public Usuario(string? nome, string? password)
        {
            Nome = nome;
            Password = password;
        }
        public string ?Nome { get; set; }

        public string ?Password { get; set; }
    }
}
