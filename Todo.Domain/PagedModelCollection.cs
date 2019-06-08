using System.Collections.Generic;

namespace Todo.Domain
{
    public class PagedModelCollection<T> where T:class
    {
        public int TotalCount { get; }
        public int CurrentPage { get; }
        public int PageSize { get; }
        public IEnumerable<T> Tasks { get; }

        public PagedModelCollection(int totalCount, int currentPage, int pageSize, IEnumerable<T> tasks)
        {
            TotalCount = totalCount;
            CurrentPage = currentPage;
            PageSize = pageSize;
            Tasks = tasks;
        }
    }
}