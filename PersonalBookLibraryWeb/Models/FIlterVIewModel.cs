using System.Collections.Generic;

namespace PersonalBookLibraryWeb.Models
{
    // view model for filtering
    public class FilterViewModel
    {
        public string? SelectedName { get; }

        public FilterViewModel(string name)
        {
            SelectedName = name;
        }
    }
}
