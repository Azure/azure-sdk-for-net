// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using Azure;
using Azure.Core;
using Azure.Data.Tables;
using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.Extensions.Tables
{
    internal class PocoTypeBinder: TypeBinder<TableEntity>
    {
        public const string ETagKeyName = "odata.etag";
        public static PocoTypeBinder Shared { get; } = new();

        public static Type[] ETagTypes = { typeof(string), typeof(ETag) };
        public static Type[] RowKeyTypes = { typeof(string) };
        public static Type[] PartitionKeyTypes = { typeof(string) };
        public static Type[] TimestampTypes = { typeof(DateTimeOffset), typeof(DateTimeOffset?) };

        protected override void Set<T>(TableEntity destination, T value, BoundMemberInfo memberInfo)
        {
            var key = memberInfo.Name switch
            {
                nameof(TableEntity.ETag) => ETagKeyName,
                _ => memberInfo.Name
            };

            if (value == null)
            {
                destination[key] = null;
                return;
            }

            var type = typeof(T);

            if (type.IsGenericType &&
                type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                type = type.GetGenericArguments()[0];
            }

            if (type == typeof(bool) ||
                type == typeof(byte[]) ||
                type == typeof(DateTimeOffset) ||
                type == typeof(double) ||
                type == typeof(Guid) ||
                type == typeof(int) ||
                type == typeof(long) ||
                type == typeof(string))
            {
                destination[key] = value;
            }
            else if (type == typeof(DateTime))
            {
                destination[key] = new DateTimeOffset((DateTime)(object)value);
            }
            else if (type.IsEnum || type == typeof(ETag))
            {
                destination[key] = value.ToString();
            }
            else
            {
                destination[key] = JsonConvert.SerializeObject(value, Formatting.Indented);
            }
        }

        protected override bool TryGet<T>(BoundMemberInfo memberInfo, TableEntity source, out T value)
        {
            value = default;

            var key = memberInfo.Name switch
            {
                nameof(TableEntity.ETag) => ETagKeyName,
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
            else if (typeof(T) == typeof(long) ||
                     typeof(T) == typeof(long?) ||
                     typeof(T) == typeof(double?) ||
                     typeof(T) == typeof(bool) ||
                     typeof(T) == typeof(bool?) ||
                     typeof(T) == typeof(Guid) ||
                     typeof(T) == typeof(Guid?) ||
                     typeof(T) == typeof(DateTimeOffset) ||
                     typeof(T) == typeof(DateTimeOffset?) ||
                     typeof(T) == typeof(string) ||
                     typeof(T) == typeof(int) ||
                     typeof(T) == typeof(int?))
            {
                value = (T)propertyValue;
            }
            else if (typeof(T) == typeof(DateTime))
            {
                value = (T)(object) source.GetDateTime(key);
            }
            else if (typeof(T) == typeof(DateTime?))
            {
                value = (T)(object) source.GetDateTime(key);
            }
            else if (typeof(T) == typeof(double))
            {
                value = (T)Convert.ChangeType(propertyValue, typeof(double), CultureInfo.InvariantCulture);
            }
            // SDK encodes ulongs as longs but T1 and T2 extension use string
            // handle both
            else if (typeof(T) == typeof(ulong) && propertyValue is long l)
            {
                value = (T)(object) (ulong) l;
            }
            else if (typeof(T) == typeof(ulong?) && propertyValue is long l2)
            {
                value = (T)(object) (ulong) l2;
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
            else if (typeof(T) == typeof(ETag) ||
                     typeof(T) == typeof(ETag?))
            {
                value = (T)(object) new ETag(source.GetString(key));
            }
            else
            {
                value = JsonConvert.DeserializeObject<T>(source.GetString(key));
            }

            return true;
        }
    }
}