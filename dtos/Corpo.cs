namespace WebApplication1.dtos
{
    public class Corpo
    {
        public required string Nome { get; set; }
        public int? Idade { get; set; }

        public List<string>? Sobrenomes { get; set; }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
