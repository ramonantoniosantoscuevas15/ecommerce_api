namespace ecommerce_api.DTOs
{
    public class ProductFilterDto
    {
        public int Page { get; set; }
        public int RecordsPerPage { get; set; }
        internal PaginationDto Pagination { get
            {
                return new PaginationDto() { Page = Page, RecordsPerPage = RecordsPerPage };

            } }
        public string? brand { get; set; }
        public string? type { get; set; }
        public string? name { get; set; }
    }
}
