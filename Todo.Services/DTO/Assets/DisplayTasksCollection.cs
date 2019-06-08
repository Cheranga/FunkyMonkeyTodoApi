using System.Collections.Generic;

namespace Todo.Services.DTO.Assets
{
    public class DisplayTasksCollection
    {
        public int TotalCount { get; }
        public int CurrentPage { get; }
        public int PageSize { get; }
        public IEnumerable<DisplayTodo> Tasks { get; }

        public DisplayTasksCollection(int totalCount, int currentPage, int pageSize, IEnumerable<DisplayTodo> tasks)
        {
            TotalCount = totalCount;
            CurrentPage = currentPage;
            PageSize = pageSize;
            Tasks = tasks;
        }
    }
}