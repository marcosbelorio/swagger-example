namespace ExemploSwagger.Interface.Entities
{
    public class UsuarioEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public int TipoUsuario { get; set; }
    }

    public enum TipoUsuario
    {
        PessoaFisica = 1,
        PessoaJuridica = 2
    }
}