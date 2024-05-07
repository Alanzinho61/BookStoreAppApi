namespace Entities.DataTransferObjects
{
    public record BookDto
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public decimal Price { get; set; }
    }
    
}
