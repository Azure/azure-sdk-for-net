// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;
using System.Reflection;
using Azure.Data.Tables;

namespace Microsoft.Azure.WebJobs.Extensions.Tables
{
    internal class TableEntityToPocoConverter<TOutput> : IConverter<TableEntity, TOutput> where TOutput : new()
    {
        public TableEntityToPocoConverter()
        {
            CheckSetter<string>("PartitionKey");
            CheckSetter<string>("RowKey");
            CheckSetter<DateTimeOffset>("Timestamp");
            CheckSetter<string>("ETag");
        }

        public TOutput Convert(TableEntity input)
        {
            return input == null ? default : PocoTypeBinder.Shared.Deserialize<TOutput>(input);
        }
        //
        // public static TableEntityToPocoConverter<TOutput> Create()
        // {
        //     IPropertySetter<TOutput, string> partitionKeySetter = GetSetter<string>("PartitionKey");
        //     IPropertySetter<TOutput, string> rowKeySetter = GetSetter<string>("RowKey");
        //     IPropertySetter<TOutput, DateTimeOffset> timestampSetter = GetSetter<DateTimeOffset>("Timestamp");
        //     IPropertySetter<TOutput, string> eTagSetter = GetSetter<string>("ETag");
        //     Dictionary<string, IPropertySetter<TOutput, EntityProperty>> otherPropertySetters =
        //         new Dictionary<string, IPropertySetter<TOutput, EntityProperty>>();
        //     PropertyInfo[] properties = typeof(TOutput).GetProperties(BindingFlags.Instance | BindingFlags.Public);
        //     Debug.Assert(properties != null);
        //     foreach (PropertyInfo property in properties)
        //     {
        //         Debug.Assert(property != null);
        //         if (TableClientHelpers.IsSystemProperty(property.Name) || !property.CanWrite ||
        //             property.GetIndexParameters().Length != 0 || !property.HasPublicSetMethod())
        //         {
        //             continue;
        //         }
        //
        //         IPropertySetter<TOutput, EntityProperty> otherPropertySetter = GetOtherSetter(property);
        //         otherPropertySetters.Add(property.Name, otherPropertySetter);
        //     }
        //
        //     return new TableEntityToPocoConverter<TOutput>(partitionKeySetter, rowKeySetter, timestampSetter,
        //         eTagSetter, otherPropertySetters);
        // }
        //
        private static bool CheckSetter<TProperty>(string propertyName)
        {
            PropertyInfo property = typeof(TOutput).GetProperty(propertyName,
                BindingFlags.Instance | BindingFlags.Public);
            if (property == null || !property.CanWrite || !property.HasPublicSetMethod())
            {
                return false;
            }

            if (property.PropertyType != typeof(TProperty))
            {
                string message = String.Format(CultureInfo.InvariantCulture,
                    "If the {0} property is present, it must be a {1}.", propertyName, typeof(TProperty).Name);
                throw new InvalidOperationException(message);
            }

            if (property.GetIndexParameters().Length != 0)
            {
                string message = String.Format(CultureInfo.InvariantCulture,
                    "If the {0} property is present, it must not be an indexer.", propertyName);
                throw new InvalidOperationException(message);
            }

            return true;
        }
    }
}