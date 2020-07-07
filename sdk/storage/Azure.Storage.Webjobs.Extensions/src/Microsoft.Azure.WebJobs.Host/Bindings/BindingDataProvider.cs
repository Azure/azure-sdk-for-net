// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.Azure.WebJobs.Host.Bindings.Path;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    /// <summary>
    /// This class is used to generate binding contracts as well as binding data
    /// based on those contracts.
    /// </summary>
    public class BindingDataProvider : IBindingDataProvider
    {
        private readonly Type _type;
        private readonly IReadOnlyDictionary<string, Type> _contract;
        private readonly IEnumerable<PropertyHelper> _propertyHelpers;
        private readonly BindingTemplateSource _bindingTemplateSource;

        internal BindingDataProvider(Type type, IReadOnlyDictionary<string, Type> contract, IEnumerable<PropertyHelper> propertyHelpers)
        {
            _type = type;
            _contract = contract;
            _propertyHelpers = propertyHelpers;
        }

        internal BindingDataProvider(string template, bool ignoreCase = false)
        {
            _bindingTemplateSource = BindingTemplateSource.FromString(template, ignoreCase);

            Dictionary<string, Type> contract = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase);
            foreach (string parameterName in _bindingTemplateSource.ParameterNames)
            {
                contract.Add(parameterName, typeof(string));
            }
            _contract = contract;
            _type = typeof(string);
        }

        /// <inheritdoc/>
        public IReadOnlyDictionary<string, Type> Contract
        {
            get { return _contract; }
        }

        /// <inheritdoc/>
        public IReadOnlyDictionary<string, object> GetBindingData(object value)
        {
            if (value != null && !_type.IsAssignableFrom(value.GetType()))
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "The supplied value was not of type '{0}'.", _type), "value");
            }

            if (Contract == null || value == null)
            {
                return null;
            }

            if (_bindingTemplateSource != null && value.GetType() == typeof(string))
            {
                return _bindingTemplateSource.CreateBindingData((string)value);
            }
            else
            {
                Dictionary<string, object> bindingData = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
                foreach (var propertyHelper in _propertyHelpers)
                {
                    object propertyValue = propertyHelper.GetValue(value);
                    bindingData.Add(propertyHelper.Name, propertyValue);
                }
                return bindingData;
            }
        }

        /// <summary>
        /// Creates a <see cref="BindingDataProvider"/> instance for the specified Type.
        /// </summary>
        /// <param name="type">The Type to return a <see cref="BindingDataProvider"/> for.</param>
        /// <returns>A <see cref="BindingDataProvider"/> instance or null for unsupported types.</returns>
        public static BindingDataProvider FromType(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            if ((type == typeof(object)) ||
                (type == typeof(string)) ||
                (type == typeof(byte[])))
            {
                // No binding data is available for primitive types.
                return null;
            }

            // The properties on user-defined types are valid binding data.
            IReadOnlyList<PropertyHelper> bindingDataProperties = PropertyHelper.GetProperties(type);
            if (bindingDataProperties.Count == 0)
            {
                return null;
            }

            Dictionary<string, Type> contract = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase);
            foreach (PropertyHelper property in bindingDataProperties)
            {
                if (contract.ContainsKey(property.Name))
                {
                    throw new InvalidOperationException(
                        string.Format(CultureInfo.InvariantCulture,
                        "Multiple properties named '{0}' found in type '{1}'.", property.Name, type.Name));
                }
                contract.Add(property.Name, property.Property.PropertyType);
            }

            return new BindingDataProvider(type, contract, bindingDataProperties);
        }

        /// <summary>
        /// Create a <see cref="BindingDataProvider"/> instance for the specified binding template.
        /// </summary>
        /// <param name="template">The binding template.</param>
        /// <param name="ignoreCase">True if matches should be case insensitive.</param>
        /// <returns>A <see cref="BindingDataProvider"/> instance.</returns>
        public static BindingDataProvider FromTemplate(string template, bool ignoreCase = false)
        {
            return new BindingDataProvider(template, ignoreCase);
        }
    }
}
