//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Microsoft.Azure.Management.DataFactories.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Management.DataFactories.Conversion
{
    internal abstract class CoreTypeConverter<TCore, TWrapper, TExtensibleTypeProperties, TGenericTypeProperties> :
        GenericRegisteredTypeConverter<TExtensibleTypeProperties>
        where TExtensibleTypeProperties : TypeProperties
        where TGenericTypeProperties : TExtensibleTypeProperties, IGenericTypeProperties, new()
    {       
       #region Abstract methods

        /// <summary>
        /// Converts <paramref name="wrappedObject"/> from type TCore to TWrapper.
        /// </summary>
        /// <param name="wrappedObject">
        /// The object to convert to its generic/core type equivalent.
        /// </param>
        /// <returns>The generic representation of <paramref name="wrappedObject"/>.</returns>
        public abstract TCore ToCoreType(TWrapper wrappedObject);

        /// <summary>
        /// Converts <paramref name="coreObject"/> from type TWrapper to TCore.
        /// </summary>
        /// <param name="coreObject">
        /// The object to convert to its strong/wrapped type equivalent.
        /// </param>
        /// <returns>The wrapped representation of <paramref name="coreObject"/>.</returns>
        public abstract TWrapper ToWrapperType(TCore coreObject);

        /// <summary>
        /// Checks if <paramref name="wrappedObject"/> is valid.
        /// </summary>
        /// <param name="wrappedObject">The object to validate.</param>
        public abstract void ValidateWrappedObject(TWrapper wrappedObject);

        #endregion

        protected virtual TExtensibleTypeProperties DeserializeTypeProperties(
            string typeName,
            string json,
            out Type type)
        {
            TExtensibleTypeProperties typeProperties;
            if (this.TryGetRegisteredType(typeName, out type))
            {
                if (string.IsNullOrEmpty(json))
                {
                    // No typeProperties exist to deserialize, just initialize a default instance
                    typeProperties = (TExtensibleTypeProperties)Activator.CreateInstance(type);
                }
                else
                {
                    typeProperties = (TExtensibleTypeProperties)TypeProperties.DeserializeObject(json, type);
                }
            }
            else
            {
                Dictionary<string, JToken> serviceExtraProperties =
                    JsonConvert.DeserializeObject<Dictionary<string, JToken>>(
                        json,
                        ConversionCommon.DefaultSerializerSettings);

                typeProperties = new TGenericTypeProperties() { ServiceExtraProperties = serviceExtraProperties };
                type = typeof(TGenericTypeProperties);
            }

            return typeProperties;
        }

        protected static string GetTypeName(Type type, string actualTypeName)
        {
            return type == typeof(TGenericTypeProperties)
                       ? actualTypeName
                       : DataFactoryUtilities.GetResourceTypeName(type);
        }

        protected virtual void ValidateTypeProperties(TExtensibleTypeProperties properties, Type type)
        {
            Ensure.IsNotNullNoStackTrace(properties, "properties");

            // ADF level properties will be validated by the Core layer 
            // TODO brgold: what about things hyak cannot validate?
            foreach (PropertyInfo property in
                    type.GetProperties(ConversionCommon.DefaultBindingFlags)
                        .Where(p => !p.Name.Equals("ServiceExtraProperties", StringComparison.Ordinal)))
            {
                this.ValidateTypeProperty(property, properties);
            }
        }

        private void ValidateTypeProperty(PropertyInfo property, object value)
        {
            object requiredAttribute =
                property.GetCustomAttributes(typeof(AdfRequiredAttribute), true).FirstOrDefault();
            object actualValue = GetPropertyValue(property, value);

            if (requiredAttribute != null && actualValue == null)
            {
                throw new InvalidOperationException(
                    string.Format(CultureInfo.InvariantCulture, "The property '{0}' is required.", property.Name));
            }

            if (actualValue == null)
            {
                return;
            }

            if (ImplementsIList(property))
            {
#if NET45
                this.ValidateList(actualValue as IList);
#endif
                return;
            }

            if (ImplementsIDictionary(property))
            {
#if NET45
                this.ValidateDictionary(actualValue as IDictionary);
#endif
                return;
            }
                
            if (ImplementsIDictionary(property) || !ShouldValidateMembers(property))
            {
                return;
            }

            IEnumerable<PropertyInfo> props = property.PropertyType.GetProperties(ConversionCommon.DefaultBindingFlags);

            // Validate properties of value
            foreach (var prop in props)
            {
                this.ValidateTypeProperty(prop, actualValue);
            }
        }

        private static object GetPropertyValue(PropertyInfo property, object value)
        {
            try
            {
                return property.GetValue(value, null);
            }
            catch (Exception ex)
            {
                string message = "Unable to get value for the property '" + property.Name + "' of type '"
                                 + property.PropertyType.FullName
                                 + "'. The type must be a primitive type, value type, List<T>, Dictionary<TKey, TValue>, or some custom class.";

                throw new InvalidOperationException(message, ex);
            }
        }

#if NET45
        private void ValidateList(IList list)
        {
            if (list == null)
            {
                throw new ArgumentNullException("list", "Some properties of the type cannot be cast to IList.");
            }

            Type type = list.GetType().GetTypeInfo().GenericTypeArguments[0];
            if (!ShouldValidateMembers(type))
            {
                return;
            }

            List<PropertyInfo> props = type.GetProperties(ConversionCommon.DefaultBindingFlags).ToList();

            foreach (object item in list)
            {
                foreach (PropertyInfo property in props)
                {
                    this.ValidateTypeProperty(property, item);
                }
            }
        }

        private void ValidateDictionary(IDictionary list)
        {
            if (list == null)
            {
                throw new ArgumentNullException("list", "Some properties of the type cannot be cast to IDictionary.");
            }

            Type type = list.GetType().GetTypeInfo().GenericTypeArguments[1];
            if (!ShouldValidateMembers(type))
            {
                return;
            }

            List<PropertyInfo> props =
                type.GetProperties(ConversionCommon.DefaultBindingFlags).ToList();

            foreach (DictionaryEntry item in list)
            {
                foreach (PropertyInfo property in props)
                {
                    this.ValidateTypeProperty(property, item.Value);
                }
            }
        }
#endif

        private static bool ImplementsIList(PropertyInfo property)
        {
            Type type = property.PropertyType;
            return type == typeof(IList<>) || (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IList<>))
                   || type.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IList<>));
        }

        private static bool ImplementsIDictionary(PropertyInfo property)
        {
            Type type = property.PropertyType;
            return type == typeof(IDictionary<,>)
                   || (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IDictionary<,>))
                   || type.GetInterfaces()
                          .Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IDictionary<,>));
        }

        // Get the properties of value that are not primitive/value types 
        // and cannot be indexed (e.g. not an array)
        private static bool ShouldValidateMembers(PropertyInfo propertyInfo)
        {
            Type type = propertyInfo.PropertyType;
            bool preCheck = type.IsPrimitive || type.IsValueType || type.BaseType == typeof(object)
                            || propertyInfo.GetIndexParameters().Any();

            return !preCheck && IsNotNullable(type);
        }

        private static bool ShouldValidateMembers(Type type)
        {
            bool preCheck = type.IsPrimitive || type.IsValueType || type == typeof(string) || type == typeof(object);
            return !preCheck && IsNotNullable(type);
        }

        private static bool IsNotNullable(Type type)
        {
            Type underlyingType = Nullable.GetUnderlyingType(type);
            if (underlyingType != null)
            {
                return !underlyingType.IsValueType && !underlyingType.IsPrimitive;
            }

            return true;
        }
    }
}
