// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using Azure.Monitory.Query.Models;

namespace Azure.Monitory.Query
{
    internal class RowBinder: IBinderImplementation<LogsQueryResultRow>
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
                        results.Add(_typeBinder.Deserialize<T, LogsQueryResultRow>(row, this));
                    }
                }
            }

            // TODO: Maybe support record construction
            return results;
        }

        public void Set<T>(LogsQueryResultRow destination, T value, BoundMemberInfo memberInfo)
        {
            throw new NotSupportedException();
        }

        public bool TryGet<T>(BoundMemberInfo memberInfo, LogsQueryResultRow source, out T value)
        {
            if (!source.TryGetColumn(memberInfo.Name, out int column))
            {
                value = default;
                return false;
            }

            if (typeof(T) == typeof(int)) value = (T)(object)source.GetInt32(column);
            else if (typeof(T) == typeof(string)) value = (T)(object)source.GetString(column);
            else if (typeof(T) == typeof(bool)) value = (T)(object)source.GetBoolean(column);
            else if (typeof(T) == typeof(long)) value = (T)(object)source.GetInt64(column);
            else if (typeof(T) == typeof(object)) value = (T)source.GetObject(column);
            else
            {
                throw new NotSupportedException();
            }

            return true;
        }
    }
}