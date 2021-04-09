// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Azure.Monitory.Query.Models;

namespace Azure.Monitory.Query
{
    internal class RowBinder
    {
        internal static IReadOnlyList<T> BindResults<T>(LogsQueryResult response)
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
                    var columnMap = table.Columns
                        .Select((column, index) => (Property: typeof(T).GetProperty(column.Name, BindingFlags.Instance | BindingFlags.Public), index))
                        .Where(columnMapping => columnMapping.Property?.SetMethod != null)
                        .ToArray();

                    foreach (var row in table.Rows)
                    {
                        T rowObject = Activator.CreateInstance<T>();

                        foreach (var (property, index) in columnMap)
                        {
                            property.SetValue(rowObject, Convert.ChangeType(row.GetObject(index), property.PropertyType, CultureInfo.InvariantCulture));
                        }

                        results.Add(rowObject);
                    }
                }
            }

            // TODO: Maybe support record construction
            return results;
        }
    }
}