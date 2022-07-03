namespace PersonalBookLibraryWeb.Models
{
    public class SortViewModel
    {
        public SortState BookNameSort { get; }
        public SortState AuthorNameSort { get; }
        public SortState RatingSort { get; }
        public SortState ShortDescriptionSort { get; }
        public SortState SectionSort { get; }
        public SortState Current { get; }

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
