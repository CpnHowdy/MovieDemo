using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MovieDemo.Services
{
    public static class QueryBuilder
    {
        public static string BuildQuery(Dictionary<string, string> dd)
        {
            var queryBuilder = new StringBuilder();
            var first = true;

            foreach (var pair in dd)
            {
                // Skip pairs without a key
                if (string.IsNullOrEmpty(pair.Key))
                    continue;

                // Handle absence of preceding ampersand
                if (first)
                    first = false;
                else
                    queryBuilder.Append('&');

                // Add item to string normally
                queryBuilder.Append(pair.Key);
                queryBuilder.Append('=');
                queryBuilder.Append(pair.Value ?? string.Empty);
            }

            return queryBuilder.ToString();
        }
    }
}