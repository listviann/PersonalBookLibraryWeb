namespace PersonalBookLibraryWeb.Models
{
    // view model for pagination
    public class PageViewModel
    {
        public int PageNumber { get; } // number of a current page
        public int TotalPages { get; } // total number of pages
        public bool HasPreviousPage => PageNumber > 1; 
        public bool HasNextPage => PageNumber < TotalPages;

        public PageViewModel(int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }
    }
}
