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
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using Microsoft.Azure.Management.DataFactories.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using IRegisteredType = Microsoft.Azure.Management.DataFactories.Registration.Models.IRegisteredType;

namespace Microsoft.Azure.Management.DataFactories.Conversion
{
    /// <summary>
    /// Used to de/serialize any polymorphic types inside the typeProperties section of a resource. 
    /// </summary>
    internal class GenericRegisteredTypeConverter<TRegistered> : PolymorphicTypeConverter<TRegistered> 
        where TRegistered : IRegisteredType
    {
        protected IDictionary<string, Type> TypeMap { get; set; }

        public GenericRegisteredTypeConverter()
        {
            this.TypeMap = new Dictionary<string, Type>();
        }

        /// <summary>
        /// Registers a type for conversion inside the TypeProperties of an ADF resource.
        /// </summary>
        /// <typeparam name="T">The type to register.</typeparam>
        /// <param name="wrapperType">The type to use for displaying any error messages.</param>
        public virtual void RegisterType<T>(Type wrapperType = null)
        {
            this.EnsureIsAssignableRegisteredType<T>();

            Type type = typeof(T);
            string typeName = type.Name;
            string wrapperTypeName = wrapperType != null ? wrapperType.Name : typeof(TRegistered).Name;

            if (ReservedTypes.ContainsKey(typeName))
            {
                throw new InvalidOperationException(string.Format(
                        CultureInfo.InvariantCulture,
                        "{0} type '{1}' cannot be locally registered because it has the same name as a built-in ADF {0} type.",
                        wrapperTypeName,
                        typeName));
            }

            if (this.TypeMap.ContainsKey(typeName))
            {
                throw new InvalidOperationException(string.Format(
                        CultureInfo.InvariantCulture,
                        "A {0} type with the name '{1}' is already registered.",
                        wrapperTypeName,
                        typeName));
            }

            this.TypeMap.Add(typeName, type);
        }

        public bool TypeIsRegistered<T>()
        {
            this.EnsureIsAssignableRegisteredType<T>();

            string typeName = typeof(T).Name;
            return ReservedTypes.ContainsKey(typeName) || this.TypeMap.ContainsKey(typeName);
        }

        public bool TryGetRegisteredType(string typeName, out Type type)
        {
            return ReservedTypes.TryGetValue(typeName, out type) || this.TypeMap.TryGetValue(typeName, out type);
        }

        protected virtual void EnsureIsAssignableRegisteredType<T>()
        {
            Type type = typeof(T);

            if (!typeof(TRegistered).IsAssignableFrom(type))
            {
                throw new InvalidOperationException(string.Format(
                        CultureInfo.InvariantCulture,
                        "'{0}' cannot be locally registered because it is not assignable from type {1}.",
                        type.FullName,
                        typeof(TRegistered).FullName));
            }
        }
    }
}
