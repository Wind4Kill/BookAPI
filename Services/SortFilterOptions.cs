using System;

namespace NewBookApi.Services;

public class SortFilterOptions
{
      public FilterOptions Filtering { get; set; }

      public SortingOptions Sorting { get; set; }

      public string FilterValue { get; set; }

      public int PageNumber { get; set; }


      public SortFilterOptions()

      {
            Sorting = SortingOptions.Id;
            Filtering = FilterOptions.None;
            FilterValue = string.Empty;
            PageNumber = 1;
      }
}
