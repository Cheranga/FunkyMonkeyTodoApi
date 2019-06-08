using System.Reflection.Metadata;

namespace Todo.Domain
{
    public class Paging
    {
        public int PageSize { get; set; }
        public int Page { get; set; }
        public int TotalCount { get; set; }

        public bool IsValid() => Page >= 1 && PageSize >= 1;
    }
}