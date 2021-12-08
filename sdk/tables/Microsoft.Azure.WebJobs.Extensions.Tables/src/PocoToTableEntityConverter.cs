// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Azure.WebJobs.Host;

namespace Microsoft.Azure.WebJobs.Extensions.Tables
{
    internal class PocoToTableEntityConverter<TInput> : IConverter<TInput, ITableEntity>
    {
        private readonly IPropertyGetter<TInput, string> _partitionKeyGetter;
        private readonly IPropertyGetter<TInput, string> _rowKeyGetter;
        private readonly IPropertyGetter<TInput, DateTimeOffset> _timestampGetter;
        private readonly IPropertyGetter<TInput, string> _eTagKeyGetter;
        private readonly IReadOnlyDictionary<string, IPropertyGetter<TInput, EntityProperty>> _otherPropertyGetters;

        private PocoToTableEntityConverter(
            IPropertyGetter<TInput, string> partitionKeyGetter,
            IPropertyGetter<TInput, string> rowKeyGetter,
            IPropertyGetter<TInput, DateTimeOffset> timestampGetter,
            IPropertyGetter<TInput, string> eTagKeyGetter,
            IReadOnlyDictionary<string, IPropertyGetter<TInput, EntityProperty>> otherPropertyGetters)
        {
            Debug.Assert(otherPropertyGetters != null);
            _partitionKeyGetter = partitionKeyGetter;
            _rowKeyGetter = rowKeyGetter;
            _timestampGetter = timestampGetter;
            _eTagKeyGetter = eTagKeyGetter;
            _otherPropertyGetters = otherPropertyGetters;
        }

        public bool ConvertsPartitionKey => _partitionKeyGetter != null;

        public bool ConvertsRowKey => _rowKeyGetter != null;

        public bool ConvertsETag => _eTagKeyGetter != null;

        public ITableEntity Convert(TInput input)
        {
            if (input == null)
            {
                return null;
            }

            DynamicTableEntity result = new DynamicTableEntity();
            if (_partitionKeyGetter != null)
            {
                result.PartitionKey = _partitionKeyGetter.GetValue(input);
            }

            if (_rowKeyGetter != null)
            {
                result.RowKey = _rowKeyGetter.GetValue(input);
            }

            if (_timestampGetter != null)
            {
                result.Timestamp = _timestampGetter.GetValue(input);
            }

            IDictionary<string, EntityProperty> properties = new Dictionary<string, EntityProperty>();
            foreach (KeyValuePair<string, IPropertyGetter<TInput, EntityProperty>> pair in _otherPropertyGetters)
            {
                string propertyName = pair.Key;
                IPropertyGetter<TInput, EntityProperty> getter = pair.Value;
                Debug.Assert(getter != null);
                EntityProperty propertyValue = getter.GetValue(input);
                properties.Add(propertyName, propertyValue);
            }

            result.ReadEntity(properties, operationContext: null);
            if (_eTagKeyGetter != null)
            {
                result.ETag = _eTagKeyGetter.GetValue(input);
            }

            return result;
        }

        public static PocoToTableEntityConverter<TInput> Create()
        {
            IPropertyGetter<TInput, string> partitionKeyGetter = GetGetter<string>("PartitionKey");
            IPropertyGetter<TInput, string> rowKeyGetter = GetGetter<string>("RowKey");
            IPropertyGetter<TInput, DateTimeOffset> timestampGetter = GetGetter<DateTimeOffset>("Timestamp");
            IPropertyGetter<TInput, string> eTagGetter = GetGetter<string>("ETag");
            Dictionary<string, IPropertyGetter<TInput, EntityProperty>> otherPropertyGetters =
                new Dictionary<string, IPropertyGetter<TInput, EntityProperty>>();
            PropertyInfo[] properties = typeof(TInput).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            Debug.Assert(properties != null);
            foreach (PropertyInfo property in properties)
            {
                Debug.Assert(property != null);
                if (TableClient.IsSystemProperty(property.Name) || !property.CanRead ||
                    property.GetIndexParameters().Length != 0 || !property.HasPublicGetMethod())
                {
                    continue;
                }

                IPropertyGetter<TInput, EntityProperty> otherPropertyGetter = GetOtherGetter(property);
                otherPropertyGetters.Add(property.Name, otherPropertyGetter);
            }

            return new PocoToTableEntityConverter<TInput>(partitionKeyGetter, rowKeyGetter, timestampGetter, eTagGetter,
                otherPropertyGetters);
        }

        private static IPropertyGetter<TInput, TProperty> GetGetter<TProperty>(string propertyName)
        {
            PropertyInfo property = typeof(TInput).GetProperty(propertyName,
                BindingFlags.Instance | BindingFlags.Public);
            if (property == null || !property.CanRead || !property.HasPublicGetMethod())
            {
                return null;
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

            return PropertyAccessorFactory<TInput>.CreateGetter<TProperty>(property);
        }

        private static IPropertyGetter<TInput, EntityProperty> GetOtherGetter(PropertyInfo property)
        {
            MethodInfo genericMethodTemplate = typeof(PocoToTableEntityConverter<TInput>).GetMethod(
                "GetOtherGetterGeneric", BindingFlags.Static | BindingFlags.NonPublic);
            MethodInfo genericMethod = genericMethodTemplate.MakeGenericMethod(property.PropertyType);
            Func<PropertyInfo, IPropertyGetter<TInput, EntityProperty>> invoker =
                (Func<PropertyInfo, IPropertyGetter<TInput, EntityProperty>>)genericMethod.CreateDelegate(
                    typeof(Func<PropertyInfo, IPropertyGetter<TInput, EntityProperty>>));
            return invoker.Invoke(property);
        }

        private static IPropertyGetter<TInput, EntityProperty> GetOtherGetterGeneric<TProperty>(PropertyInfo property)
        {
            IPropertyGetter<TInput, TProperty> propertyGetter =
                PropertyAccessorFactory<TInput>.CreateGetter<TProperty>(property);
            IConverter<TProperty, EntityProperty> converter = TToEntityPropertyConverterFactory.Create<TProperty>();
            return new ConverterPropertyGetter<TInput, TProperty, EntityProperty>(propertyGetter, converter);
        }
    }
}