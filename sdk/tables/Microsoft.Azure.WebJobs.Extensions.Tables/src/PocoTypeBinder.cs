// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using Azure;
using Azure.Data.Tables;
using Azure.Monitor.Query;
using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.Extensions.Tables
{
    internal class PocoTypeBinder: TypeBinder<TableEntity>
    {
        public static PocoTypeBinder Shared { get; } = new();
        protected override void Set<T>(TableEntity destination, T value, BoundMemberInfo memberInfo)
        {
            // Remove the ETag and Timestamp properties, as they do not need to be serialized
            if (memberInfo.Name == TableConstants.PropertyNames.ETag || memberInfo.Name == TableConstants.PropertyNames.Timestamp)
            {
                return;
            }

            if (typeof(T) == typeof(bool) ||
                typeof(T) == typeof(bool?) ||
                typeof(T) == typeof(byte[]) ||
                typeof(T) == typeof(DateTime) ||
                typeof(T) == typeof(DateTime?) ||
                typeof(T) == typeof(DateTimeOffset) ||
                typeof(T) == typeof(DateTimeOffset?) ||
                typeof(T) == typeof(double) ||
                typeof(T) == typeof(double?) ||
                typeof(T) == typeof(Guid) ||
                typeof(T) == typeof(Guid?) ||
                typeof(T) == typeof(int) ||
                typeof(T) == typeof(int?) ||
                typeof(T) == typeof(long) ||
                typeof(T) == typeof(long?) ||
                typeof(T) == typeof(string))
            {
                destination[memberInfo.Name] = value;
            }
            else if (typeof(T).IsEnum)
            {
                destination[memberInfo.Name] = value.ToString();
            }
            else
            {
                // TODO: this is new. Who handled this before?
                // TODO: indented?
                destination[memberInfo.Name] = JsonConvert.SerializeObject(value, Formatting.Indented);
            }
        }

        protected override bool TryGet<T>(BoundMemberInfo memberInfo, TableEntity source, out T value)
        {
            value = default;

            var key = memberInfo.Name switch
            {
                nameof(TableConstants.PropertyNames.ETag) => TableConstants.PropertyNames.EtagOdata,
                _ => memberInfo.Name
            };

            if (!source.TryGetValue(key, out var propertyValue))
            {
                return false;
            }

            if (propertyValue == null)
            {
                value = default(T);
                return true;
            }

            if (typeof(T) == typeof(byte[]))
            {
                value = (T)(object)source.GetBinary(key);
            }
            else if (typeof(T) == typeof(BinaryData))
            {
                value = (T)(object)source.GetBinaryData(key);
            }
            else if (typeof(T) == typeof(long))
            {
                value = (T)(object) source.GetInt64(key);
            }
            else if (typeof(T) == typeof(long?))
            {
                value = (T)(object) source.GetInt64(key);
            }
            else if (typeof(T) == typeof(ulong))
            {
                value = (T)(object) source.GetInt64(key);
            }
            else if (typeof(T) == typeof(ulong?))
            {
                value = (T)(object) source.GetInt64(key);
            }
            else if (typeof(T) == typeof(double))
            {
                value = (T) Convert.ChangeType(propertyValue, typeof(double), CultureInfo.InvariantCulture);
            }
            else if (typeof(T) == typeof(double?))
            {
                value = (T)(object) source.GetDouble(key);
            }
            else if (typeof(T) == typeof(bool))
            {
                value = (T)(object) source.GetBoolean(key);
            }
            else if (typeof(T) == typeof(bool?))
            {
                value = (T)(object) source.GetBoolean(key);
            }
            else if (typeof(T) == typeof(Guid))
            {
                value = (T)(object) source.GetGuid(key);
            }
            else if (typeof(T) == typeof(Guid?))
            {
                value = (T)(object) source.GetGuid(key);
            }
            else if (typeof(T) == typeof(DateTimeOffset))
            {
                value = (T)(object) source.GetDateTimeOffset(key);
            }
            else if (typeof(T) == typeof(DateTimeOffset?))
            {
                value = (T)(object) source.GetDateTimeOffset(key);
            }
            else if (typeof(T) == typeof(DateTime))
            {
                value = (T)(object) source.GetDateTime(key);
            }
            else if (typeof(T) == typeof(DateTime?))
            {
                value = (T)(object) source.GetDateTime(key);
            }
            else if (typeof(T) == typeof(string))
            {
                value = (T)(object) source.GetString(key);
            }
            else if (typeof(T) == typeof(int))
            {
                value = (T)(object) source.GetInt32(key);
            }
            else if (typeof(T) == typeof(int?))
            {
                value = (T)(object) source.GetInt32(key);
            }
            else if (typeof(T).IsEnum)
            {
                value = (T)Enum.Parse(memberInfo.Type, propertyValue as string );
            }
            else if (typeof(T).IsGenericType &&
                     typeof(T).GetGenericTypeDefinition() == typeof(Nullable<>) &&
                     typeof(T).GetGenericArguments() is { Length: 1 } arguments &&
                     arguments[0].IsEnum)
            {
                value = (T)Enum.Parse(arguments[0], propertyValue as string );
            }
            else if (typeof(T) == typeof(ETag))
            {
                value = (T)(object) new ETag(source.GetString(key));
            }
            else if (typeof(T) == typeof(TimeSpan))
            {
                // TODO: this is new. Who handled this before?
                value = (T)JsonConvert.DeserializeObject<T>(source.GetString(key));
            }

            return true;
        }
    }
}