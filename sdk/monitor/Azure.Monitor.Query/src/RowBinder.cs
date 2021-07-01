﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Monitor.Query.Models;

namespace Azure.Monitor.Query
{
    internal class RowBinder: TypeBinder<LogsQueryResultRow>
    {
        internal IReadOnlyList<T> BindResults<T>(IReadOnlyList<LogsQueryResultTable> tables)
        {
            List<T> results = new List<T>();
            if (typeof(IDictionary<string, object>).IsAssignableFrom(typeof(T)))
            {
                foreach (var table in tables)
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
                foreach (var table in tables)
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

            if (source.IsNull(column) &&
                (!typeof(T).IsValueType ||
                typeof(T).IsGenericType &&
                typeof(T).GetGenericTypeDefinition() == typeof(Nullable<>)))
            {
                value = default;
                return true;
            }

            if (typeof(T) == typeof(int)) value = (T)(object)source.GetInt32(column);
            else if (typeof(T) == typeof(string)) value = (T)(object)source.GetString(column);
            else if (typeof(T) == typeof(bool)) value = (T)(object)source.GetBoolean(column);
            else if (typeof(T) == typeof(long)) value = (T)(object)source.GetInt64(column);
            else if (typeof(T) == typeof(decimal)) value = (T)(object)source.GetDecimal(column);
            else if (typeof(T) == typeof(double)) value = (T)(object)source.GetDouble(column);
            else if (typeof(T) == typeof(object)) value = (T)source.GetObject(column);
            else if (typeof(T) == typeof(Guid)) value = (T)(object)source.GetGuid(column);
            else if (typeof(T) == typeof(DateTimeOffset)) value = (T)(object)source.GetDateTimeOffset(column);
            else if (typeof(T) == typeof(TimeSpan)) value = (T)(object)source.GetTimeSpan(column);

            else if (typeof(T) == typeof(int?)) value = (T)(object)(int?)source.GetInt32(column);
            else if (typeof(T) == typeof(bool?)) value = (T)(object)(bool?)source.GetBoolean(column);
            else if (typeof(T) == typeof(long?)) value = (T)(object)(long?)source.GetInt64(column);
            else if (typeof(T) == typeof(decimal?)) value = (T)(object)(decimal?)source.GetDecimal(column);
            else if (typeof(T) == typeof(double?)) value = (T)(object)(double?)source.GetDouble(column);
            else if (typeof(T) == typeof(Guid?)) value = (T)(object)(Guid?)source.GetGuid(column);
            else if (typeof(T) == typeof(DateTimeOffset?)) value = (T)(object)(DateTimeOffset?)source.GetDateTimeOffset(column);
            else if (typeof(T) == typeof(TimeSpan?)) value = (T)(object)(TimeSpan?)source.GetTimeSpan(column);

            else
            {
                throw new NotSupportedException($"The {typeof(T)} type is not supported as a deserialization target.");
            }

            return true;
        }
    }
}