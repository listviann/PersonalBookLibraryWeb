using System.Collections.Generic;

namespace PersonalBookLibraryWeb.Models
{
    public class FilterViewModel
    {
        public string? SelectedName { get; }

        public FilterViewModel(string name)
        {
            SelectedName = name;
        }
    }
}
