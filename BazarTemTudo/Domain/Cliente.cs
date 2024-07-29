namespace BazarTemTudo.Domain
{
    public class Cliente
    {
        public int Id { get; set; }
        public required string Cpf { get; set; }
        public required string Email_cliente { get; set; }
        public required string Nome_cliente { get; set; }
        public required string Tel_cliente { get; set; }
    }
}
