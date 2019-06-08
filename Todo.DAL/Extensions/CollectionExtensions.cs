using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Todo.Domain;

namespace Todo.DAL.Extensions
{
    public static class CollectionExtensions
    {
        public static IEnumerable<T> ToPaging<T>(this IEnumerable<T> items, Paging paging, Func<T, object> orderByFunc, ILogger logger = null) where T : class
        {
            if (items == null)
            {
                return items;
            }

            if (!paging.IsValid())
            {
                logger?.LogError("Invalid paging data");

                return items;
            }

            var pagedCollection = items.OrderBy(orderByFunc)
                .Skip((paging.Page - 1) * paging.PageSize)
                .Take(paging.PageSize);

            return pagedCollection;
        }
    }
}
