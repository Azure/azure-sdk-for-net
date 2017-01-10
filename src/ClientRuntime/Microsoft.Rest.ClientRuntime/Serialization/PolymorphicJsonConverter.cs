// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace Microsoft.Rest.Serialization
{
    /// <summary>
    /// Base JSON converter for polymorphic objects.
    /// </summary>
    public abstract class PolymorphicJsonConverter : JsonConverter
    {
        /// <summary>
        /// Discriminator property name.
        /// </summary>
        public string Discriminator { get; protected set; }

        /// <summary>
        /// Returns type that matches specified name.
        /// </summary>
        /// <param name="baseType">Base type.</param>
        /// <param name="name">Derived type name</param>
        /// <returns></returns>
        public static Type GetDerivedType(Type baseType, string name)
        {
            if (baseType == null)
            {
                throw new ArgumentNullException("baseType");
            }
            foreach (TypeInfo type in baseType.GetTypeInfo().Assembly.DefinedTypes
                .Where(t => t.Namespace == baseType.Namespace && t != baseType.GetTypeInfo() && t.IsSubclassOf(baseType)))
            {
                string typeName = type.Name;
                if (type.GetCustomAttributes<JsonObjectAttribute>().Any())
                {
                    typeName = type.GetCustomAttribute<JsonObjectAttribute>().Id;
                }
                if (typeName != null && typeName.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return type.AsType();
                }
            }

            return null;
        }
    }
}
