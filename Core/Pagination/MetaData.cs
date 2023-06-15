namespace Core.Pagination
{
    public class MetaData
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasPrevious
        {
            get => CurrentPage > 1;
        }

        public bool HasNext
        {
            get => CurrentPage < TotalPages;
        }
    }
}
