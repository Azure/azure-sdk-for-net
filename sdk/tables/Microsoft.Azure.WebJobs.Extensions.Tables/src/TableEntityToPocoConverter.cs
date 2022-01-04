// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Azure.Data.Tables;

namespace Microsoft.Azure.WebJobs.Extensions.Tables
{
    internal class TableEntityToPocoConverter<TOutput> : IConverter<TableEntity, TOutput>
    {
        public TableEntityToPocoConverter()
        {
            TableClientHelpers.VerifyDefaultConstructor(typeof(TOutput));
            ValidateSetter("PartitionKey", PocoTypeBinder.PartitionKeyTypes);
            ValidateSetter("RowKey", PocoTypeBinder.RowKeyTypes);
            ValidateSetter("Timestamp", PocoTypeBinder.TimestampTypes);
            ValidateSetter("ETag", PocoTypeBinder.ETagTypes);
        }

        public TOutput Convert(TableEntity input)
        {
            return input == null ? default : PocoTypeBinder.Shared.Deserialize<TOutput>(input);
        }

        private static void ValidateSetter(string propertyName, Type[] allowedTypes)
        {
            PropertyInfo property = typeof(TOutput).GetProperty(propertyName,
                BindingFlags.Instance | BindingFlags.Public);
            if (property == null || !property.CanWrite || !property.HasPublicSetMethod())
            {
                return;
            }

            if (!allowedTypes.Contains(property.PropertyType))
            {
                string message = String.Format(CultureInfo.InvariantCulture,
                    "If the {0} property is present, it must be a {1}.", propertyName, string.Join(" or ", (IEnumerable<object>)allowedTypes));
                throw new InvalidOperationException(message);
            }

            if (property.GetIndexParameters().Length != 0)
            {
                string message = String.Format(CultureInfo.InvariantCulture,
                    "If the {0} property is present, it must not be an indexer.", propertyName);
                throw new InvalidOperationException(message);
            }
        }
    }
}