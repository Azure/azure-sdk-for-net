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
    internal class TableEntityToPocoConverter<TOutput> : IConverter<ITableEntity, TOutput> where TOutput : new()
    {
        private readonly IPropertySetter<TOutput, string> _partitionKeySetter;
        private readonly IPropertySetter<TOutput, string> _rowKeySetter;
        private readonly IPropertySetter<TOutput, DateTimeOffset> _timestampSetter;
        private readonly IPropertySetter<TOutput, string> _eTagSetter;
        private readonly IReadOnlyDictionary<string, IPropertySetter<TOutput, EntityProperty>> _otherPropertySetters;

        private TableEntityToPocoConverter(
            IPropertySetter<TOutput, string> partitionKeySetter,
            IPropertySetter<TOutput, string> rowKeySetter,
            IPropertySetter<TOutput, DateTimeOffset> timestampSetter,
            IPropertySetter<TOutput, string> eTagSetter,
            IReadOnlyDictionary<string, IPropertySetter<TOutput, EntityProperty>> otherPropertySetters)
        {
            Debug.Assert(otherPropertySetters != null);
            _partitionKeySetter = partitionKeySetter;
            _rowKeySetter = rowKeySetter;
            _timestampSetter = timestampSetter;
            _eTagSetter = eTagSetter;
            _otherPropertySetters = otherPropertySetters;
        }

        public TOutput Convert(ITableEntity input)
        {
            if (input == null)
            {
                return default(TOutput);
            }

            TOutput result = new TOutput();
            if (_partitionKeySetter != null)
            {
                _partitionKeySetter.SetValue(ref result, input.PartitionKey);
            }

            if (_rowKeySetter != null)
            {
                _rowKeySetter.SetValue(ref result, input.RowKey);
            }

            if (_timestampSetter != null)
            {
                _timestampSetter.SetValue(ref result, input.Timestamp);
            }

            IDictionary<string, EntityProperty> properties = input.WriteEntity(operationContext: null);
            if (properties != null)
            {
                foreach (KeyValuePair<string, IPropertySetter<TOutput, EntityProperty>> pair in _otherPropertySetters)
                {
                    string propertyName = pair.Key;
                    if (properties.ContainsKey(propertyName))
                    {
                        IPropertySetter<TOutput, EntityProperty> setter = pair.Value;
                        Debug.Assert(setter != null);
                        EntityProperty propertyValue = properties[propertyName];
                        setter.SetValue(ref result, propertyValue);
                    }
                }
            }

            if (_eTagSetter != null)
            {
                _eTagSetter.SetValue(ref result, input.ETag);
            }

            return result;
        }

        public static TableEntityToPocoConverter<TOutput> Create()
        {
            IPropertySetter<TOutput, string> partitionKeySetter = GetSetter<string>("PartitionKey");
            IPropertySetter<TOutput, string> rowKeySetter = GetSetter<string>("RowKey");
            IPropertySetter<TOutput, DateTimeOffset> timestampSetter = GetSetter<DateTimeOffset>("Timestamp");
            IPropertySetter<TOutput, string> eTagSetter = GetSetter<string>("ETag");
            Dictionary<string, IPropertySetter<TOutput, EntityProperty>> otherPropertySetters =
                new Dictionary<string, IPropertySetter<TOutput, EntityProperty>>();
            PropertyInfo[] properties = typeof(TOutput).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            Debug.Assert(properties != null);
            foreach (PropertyInfo property in properties)
            {
                Debug.Assert(property != null);
                if (TableClient.IsSystemProperty(property.Name) || !property.CanWrite ||
                    property.GetIndexParameters().Length != 0 || !property.HasPublicSetMethod())
                {
                    continue;
                }

                IPropertySetter<TOutput, EntityProperty> otherPropertySetter = GetOtherSetter(property);
                otherPropertySetters.Add(property.Name, otherPropertySetter);
            }

            return new TableEntityToPocoConverter<TOutput>(partitionKeySetter, rowKeySetter, timestampSetter,
                eTagSetter, otherPropertySetters);
        }

        private static IPropertySetter<TOutput, TProperty> GetSetter<TProperty>(string propertyName)
        {
            PropertyInfo property = typeof(TOutput).GetProperty(propertyName,
                BindingFlags.Instance | BindingFlags.Public);
            if (property == null || !property.CanWrite || !property.HasPublicSetMethod())
            {
                return null;
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

            return PropertyAccessorFactory<TOutput>.CreateSetter<TProperty>(property);
        }

        private static IPropertySetter<TOutput, EntityProperty> GetOtherSetter(PropertyInfo property)
        {
            MethodInfo genericMethodTemplate = typeof(TableEntityToPocoConverter<TOutput>).GetMethod(
                "GetOtherSetterGeneric", BindingFlags.Static | BindingFlags.NonPublic);
            MethodInfo genericMethod = genericMethodTemplate.MakeGenericMethod(property.PropertyType);
            Func<PropertyInfo, IPropertySetter<TOutput, EntityProperty>> invoker =
                (Func<PropertyInfo, IPropertySetter<TOutput, EntityProperty>>)genericMethod.CreateDelegate(
                    typeof(Func<PropertyInfo, IPropertySetter<TOutput, EntityProperty>>));
            return invoker.Invoke(property);
        }

        private static IPropertySetter<TOutput, EntityProperty> GetOtherSetterGeneric<TProperty>(PropertyInfo property)
        {
            IConverter<EntityProperty, TProperty> converter = EntityPropertyToTConverterFactory.Create<TProperty>();
            IPropertySetter<TOutput, TProperty> propertySetter =
                PropertyAccessorFactory<TOutput>.CreateSetter<TProperty>(property);
            return new ConverterPropertySetter<TOutput, TProperty, EntityProperty>(converter, propertySetter);
        }
    }
}