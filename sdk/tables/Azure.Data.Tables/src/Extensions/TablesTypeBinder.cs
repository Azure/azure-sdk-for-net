// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using Azure.Core;

namespace Azure.Data.Tables
{
    internal class TablesTypeBinder: TypeBinder<IDictionary<string, object>>
    {
        public static TablesTypeBinder Shared { get; } = new();
        protected override void Set<T>(IDictionary<string, object> destination, T value, BoundMemberInfo memberInfo)
        {
            // Remove the ETag and Timestamp properties, as they do not need to be serialized
            if (memberInfo.Name == TableConstants.PropertyNames.ETag || memberInfo.Name == TableConstants.PropertyNames.Timestamp)
            {
                return;
            }

            // Int64 / long / enum should be serialized as string.
            if (value is long or ulong or Enum)
            {
                destination[memberInfo.Name] = value.ToString();
            }
            else
            {
                destination[memberInfo.Name] = value;
            }

            switch (value)
            {
                case byte[]:
                case BinaryData:
                    destination[memberInfo.Name.ToOdataTypeString()] = TableConstants.Odata.EdmBinary;
                    break;
                case long:
                case ulong:
                    destination[memberInfo.Name.ToOdataTypeString()] = TableConstants.Odata.EdmInt64;
                    break;
                case double:
                    destination[memberInfo.Name.ToOdataTypeString()] = TableConstants.Odata.EdmDouble;
                    break;
                case Guid:
                    destination[memberInfo.Name.ToOdataTypeString()] = TableConstants.Odata.EdmGuid;
                    break;
                case DateTimeOffset:
                    destination[memberInfo.Name.ToOdataTypeString()] = TableConstants.Odata.EdmDateTime;
                    break;
                case DateTime:
                    destination[memberInfo.Name.ToOdataTypeString()] = TableConstants.Odata.EdmDateTime;
                    break;
            }
        }

        protected override bool TryGet<T>(BoundMemberInfo memberInfo, IDictionary<string, object> source, out T value)
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
                value = (T)(object) Convert.FromBase64String(propertyValue as string);
            }
            else if (typeof(T) == typeof(BinaryData))
            {
                value = (T)(object) BinaryData.FromBytes(Convert.FromBase64String(propertyValue as string));
            }
            else if (typeof(T) == typeof(long))
            {
                value = (T)(object) long.Parse(propertyValue as string, CultureInfo.InvariantCulture);
            }
            else if (typeof(T) == typeof(long?))
            {
                value = (T)(object) long.Parse(propertyValue as string, CultureInfo.InvariantCulture);
            }
            else if (typeof(T) == typeof(ulong))
            {
                value = (T)(object) ulong.Parse(propertyValue as string, CultureInfo.InvariantCulture);
            }
            else if (typeof(T) == typeof(ulong?))
            {
                value = (T)(object) ulong.Parse(propertyValue as string, CultureInfo.InvariantCulture);
            }
            else if (typeof(T) == typeof(double))
            {
                value = (T) Convert.ChangeType(propertyValue, typeof(double), CultureInfo.InvariantCulture);
            }
            else if (typeof(T) == typeof(double?))
            {
                value = (T)(object) (double?)Convert.ChangeType(propertyValue, typeof(double), CultureInfo.InvariantCulture);
            }
            else if (typeof(T) == typeof(bool))
            {
                value = (T)(object) (bool)propertyValue;
            }
            else if (typeof(T) == typeof(bool?))
            {
                value = (T)(object) (bool?)propertyValue;
            }
            else if (typeof(T) == typeof(Guid))
            {
                value = (T)(object) Guid.Parse(propertyValue as string);
            }
            else if (typeof(T) == typeof(Guid?))
            {
                value = (T)(object) Guid.Parse(propertyValue as string);
            }
            else if (typeof(T) == typeof(DateTimeOffset))
            {
                value = (T)(object) DateTimeOffset.Parse(propertyValue as string, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
            }
            else if (typeof(T) == typeof(DateTimeOffset?))
            {
                value = (T)(object) DateTimeOffset.Parse(propertyValue as string, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
            }
            else if (typeof(T) == typeof(DateTime))
            {
                value = (T)(object) DateTime.Parse((string)propertyValue, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
            }
            else if (typeof(T) == typeof(DateTime?))
            {
                value = (T)(object) DateTime.Parse(propertyValue as string, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
            }
            else if (typeof(T) == typeof(TimeSpan))
            {
                value = (T)(object)TypeFormatters.ParseTimeSpan(propertyValue as string, "P");
            }
            else if (typeof(T) == typeof(TimeSpan?))
            {
                value = (T)(object)TypeFormatters.ParseTimeSpan(propertyValue as string, "P");
            }
            else if (typeof(T) == typeof(string))
            {
                value = (T)(object)(propertyValue as string);
            }
            else if (typeof(T) == typeof(int))
            {
                value = (T)(object)(int)propertyValue;
            }
            else if (typeof(T) == typeof(int?))
            {
                value = (T)(object)(int?)propertyValue;
            }
            else if (typeof(T).IsEnum)
            {
                if (!Enum.IsDefined(memberInfo.Type, propertyValue as string))
                    return false;

                value = (T)Enum.Parse(memberInfo.Type, propertyValue as string);
            }
            else if (typeof(T).IsGenericType &&
                     typeof(T).GetGenericTypeDefinition() == typeof(Nullable<>) &&
                     typeof(T).GetGenericArguments() is { Length: 1 } arguments &&
                     arguments[0].IsEnum)
            {
                if (!Enum.IsDefined(arguments[0], propertyValue as string))
                    return false;

                value = (T)Enum.Parse(arguments[0], propertyValue as string);
            }
            else if (typeof(T) == typeof(ETag))
            {
                value = (T)(object)new ETag(propertyValue as string);
            }

            return true;
        }
    }
}
