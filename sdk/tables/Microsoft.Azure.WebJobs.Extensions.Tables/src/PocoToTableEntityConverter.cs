// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;
using System.Reflection;
using Azure.Data.Tables;
using Azure.Monitor.Query;

namespace Microsoft.Azure.WebJobs.Extensions.Tables
{
    internal class PocoToTableEntityConverter<TInput> : IConverter<TInput, TableEntity>
    {
        private readonly TypeBinder<TableEntity>.BoundTypeInfo _info;

        public PocoToTableEntityConverter()
        {
            _info = PocoTypeBinder.Shared.GetBinderInfo(typeof(TInput));

            ConvertsPartitionKey = HasGetter<string>("PartitionKey");
            ConvertsRowKey = HasGetter<string>("RowKey");
            ConvertsETag = HasGetter<string>("ETag");
            HasGetter<DateTimeOffset>("Timestamp");
        }

        public bool ConvertsPartitionKey { get; }

        public bool ConvertsRowKey { get; }

        public bool ConvertsETag { get; }

        public TableEntity Convert(TInput input)
        {
            if (input == null)
            {
                return null;
            }

            if (input is TableEntity te)
            {
                return te;
            }

            TableEntity result = new TableEntity();
            _info.Serialize(input, result);
            return result;
        }

        private static bool HasGetter<TProperty>(string propertyName)
        {
            PropertyInfo property = typeof(TInput).GetProperty(propertyName,
                BindingFlags.Instance | BindingFlags.Public);

            if (property == null || !property.CanRead || !property.HasPublicGetMethod())
            {
                return false;
            }

            if (property.PropertyType != typeof(TProperty))
            {
                string message = String.Format(CultureInfo.CurrentCulture,
                    "If the {0} property is present, it must be a {1}.", propertyName, typeof(TProperty).Name);
                throw new InvalidOperationException(message);
            }

            if (property.GetIndexParameters().Length != 0)
            {
                string message = String.Format(CultureInfo.CurrentCulture,
                    "If the {0} property is present, it must not be an indexer.", propertyName);
                throw new InvalidOperationException(message);
            }

            return true;
        }
    }
}