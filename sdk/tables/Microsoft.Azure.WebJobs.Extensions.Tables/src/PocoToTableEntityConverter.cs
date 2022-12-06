// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Azure.Core;
using Azure.Data.Tables;

namespace Microsoft.Azure.WebJobs.Extensions.Tables
{
    internal class PocoToTableEntityConverter<TInput> : IConverter<TInput, TableEntity>
    {
        private readonly TypeBinder<TableEntity>.BoundTypeInfo _info;

        public PocoToTableEntityConverter()
        {
            _info = typeof(ITableEntity).IsAssignableFrom(typeof(TInput)) ?
              PocoTypeBinder.Shared.GetBinderInfo(typeof(TInput), typeof(ITableEntity)) :
              PocoTypeBinder.Shared.GetBinderInfo(typeof(TInput));
            ValidateGetter("PartitionKey", PocoTypeBinder.PartitionKeyTypes);
            ValidateGetter("RowKey", PocoTypeBinder.RowKeyTypes);
            ValidateGetter("ETag", PocoTypeBinder.ETagTypes);
            ValidateGetter("Timestamp", PocoTypeBinder.TimestampTypes);
        }

        public TableEntity Convert(TInput input)
        {
            if (input == null)
            {
                return null;
            }

            TableEntity result = new TableEntity();
            _info.Serialize(input, result);
            return result;
        }

        private static void ValidateGetter(string propertyName, Type[] allowedTypes)
        {
            PropertyInfo property = typeof(TInput).GetProperty(propertyName,
                BindingFlags.Instance | BindingFlags.Public);

            if (property == null || !property.CanRead || !property.HasPublicGetMethod())
            {
                return;
            }

            if (!allowedTypes.Contains(property.PropertyType))
            {
                string message = String.Format(CultureInfo.CurrentCulture,
                    "If the {0} property is present, it must be a {1}.", propertyName, string.Join(" or ", (IEnumerable<object>)allowedTypes));
                throw new InvalidOperationException(message);
            }

            if (property.GetIndexParameters().Length != 0)
            {
                string message = String.Format(CultureInfo.CurrentCulture,
                    "If the {0} property is present, it must not be an indexer.", propertyName);
                throw new InvalidOperationException(message);
            }
        }
    }
}
