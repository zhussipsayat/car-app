namespace api.Dtos
{
    public class UpdateCarRequestDto
    {
        public string BrandName { get; set; } = string.Empty;
        public string ModelName { get; set; } = string.Empty;
        public int? HColorId { get; set; }
    }
}
