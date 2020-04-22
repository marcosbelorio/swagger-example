namespace ExemploSwagger.Interface.Entities.Model
{
    public class Usuario
    {
        public int Id { get; set; }
        
        public string Nome { get; set; }

        public string Login { get; set; }

        public int TipoUsuario { get; set; }
    }
}