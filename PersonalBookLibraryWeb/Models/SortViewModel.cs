namespace PersonalBookLibraryWeb.Models
{
    // view model for sorting
    public class SortViewModel
    {
        public SortState BookNameSort { get; } // book name sorting value
        public SortState AuthorNameSort { get; } // author name sorting value
        public SortState RatingSort { get; } // book rating sorting value
        public SortState ShortDescriptionSort { get; } // short decription sorting value
        public SortState SectionSort { get; } // library section sorting value
        public SortState Current { get; } // current sorting value

        public SortViewModel(SortState sortOrder)
        {
            BookNameSort = sortOrder == SortState.BookNameAsc ? SortState.BookNameDesc : SortState.BookNameAsc;
            AuthorNameSort = sortOrder == SortState.AuthorNameAsc ? SortState.AuthorNameDesc : SortState.AuthorNameAsc;
            RatingSort = sortOrder == SortState.RatingAsc ? SortState.RatingDesc : SortState.RatingAsc;
            ShortDescriptionSort = sortOrder == SortState.ShortDescriptionAsc ? SortState.ShortDescriptionDesc : SortState.ShortDescriptionAsc;
            SectionSort = sortOrder == SortState.SectionAsc ? SortState.SectionDesc : SortState.SectionAsc;
            Current = sortOrder;
        }
    }
}
