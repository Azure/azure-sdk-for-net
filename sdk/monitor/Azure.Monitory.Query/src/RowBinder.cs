// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Monitory.Query.Models;

namespace Azure.Monitory.Query
{
    internal class RowBinder: TypeBinder<LogsQueryResultRow>
    {
        internal IReadOnlyList<T> BindResults<T>(LogsQueryResult response)
        {
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
            else
            {
                foreach (var table in response.Tables)
                {
                    foreach (var row in table.Rows)
                    {
                        results.Add(Deserialize<T>(row));
                    }
                }
            }

            return results;
        }

        protected override void Set<T>(LogsQueryResultRow destination, T value, BoundMemberInfo memberInfo)
        {
            throw new NotSupportedException();
        }

        protected override bool TryGet<T>(BoundMemberInfo memberInfo, LogsQueryResultRow source, out T value)
        {
            int column;

            // Binding entire row to a primitive
            if (memberInfo == null)
            {
                column = 0;
            }
            else if (!source.TryGetColumn(memberInfo.Name, out column))
            {
                value = default;
                return false;
            }

            if (typeof(T) == typeof(int)) value = (T)(object)source.GetInt32(column);
            else if (typeof(T) == typeof(string)) value = (T)(object)source.GetString(column);
            else if (typeof(T) == typeof(bool)) value = (T)(object)source.GetBoolean(column);
            else if (typeof(T) == typeof(long)) value = (T)(object)source.GetInt64(column);
            else if (typeof(T) == typeof(decimal)) value = (T)(object)source.GetDecimal(column);
            else if (typeof(T) == typeof(object)) value = (T)source.GetObject(column);
            else
            {
                throw new NotSupportedException();
            }

            return true;
        }
    }
}