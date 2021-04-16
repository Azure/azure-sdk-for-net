// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using Azure.Monitory.Query.Models;

namespace Azure.Monitory.Query
{
    internal class RowBinder
    {
        private TypeBinder _typeBinder = new();
        public RowBinder()
        {
        }

        internal IReadOnlyList<T> BindResults<T>(LogsQueryResult response)
        {
            // TODO: this is very slow
            List<T> results = new List<T>();
            if (typeof(IDictionary<string, object>).IsAssignableFrom(typeof(T)))
            {
                foreach (var table in response.Tables)
                {
                    foreach (var row in table.Rows)
                    {
                        IDictionary<string, object> rowObject =
                            typeof(T).IsInterface ? new Dictionary<string, object>() : (IDictionary<string, object>) Activator.CreateInstance<T>();

                        for (var i = 0; i < row.Count; i++)
                        {
                            rowObject[table.Columns[i].Name] = row.GetObject(i);
                        }

                        results.Add((T)rowObject);
                    }
                }
            }
            else if (typeof(T).IsValueType || typeof(T) == typeof(string))
            {
                foreach (var table in response.Tables)
                {
                    foreach (var row in table.Rows)
                    {
                        // TODO: Validate
                        results.Add((T)Convert.ChangeType(row.GetObject(0), typeof(T), CultureInfo.InvariantCulture));
                    }
                }
            }
            else
            {
                foreach (var table in response.Tables)
                {
                    foreach (var row in table.Rows)
                    {
                        results.Add(_typeBinder.Deserialize<T>(row));
                    }
                }
            }

            // TODO: Maybe support record construction
            return results;
        }
    }
}