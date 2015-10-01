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
using Microsoft.Azure.Management.DataFactories.Registration.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Management.DataFactories.Conversion
{
    /// <summary>
    /// Used to de/serialize any polymorphic types inside the typeProperties section of a resource. 
    /// </summary>
    internal class GenericRegisteredTypeConverter<TRegistered> : PolymorphicTypeConverter<TRegistered> 
        where TRegistered : IRegisteredType
    {
        private static readonly object RegistrationLock = new object();

        // Delay evaluation until the first time (after the process is started) 
        // that the user needs to do local type registration or conversion.
        // This is done to prevent the need to iterate over the assembly more than once.  
        private static readonly Lazy<IDictionary<string, Type>> reservedTypesFromAssembly =
            new Lazy<IDictionary<string, Type>>(GetReservedTypes);

        // Delay copying the backing dictionary until the first time (after object initialization) 
        // that the user user needs to do local type registration or conversion. 
        private readonly Lazy<IDictionary<string, Type>> typeMapLazy;

        protected IDictionary<string, Type> TypeMap
        {
            get
            {
                return this.typeMapLazy.Value;
            }
        }
        
        public GenericRegisteredTypeConverter()
        {
            this.typeMapLazy = new Lazy<IDictionary<string, Type>>(GetReservedTypesForCopy);
        }

        /// <summary>
        /// Registers a type for conversion inside the TypeProperties of an ADF resource.
        /// </summary>
        /// <typeparam name="T">The type to register.</typeparam>
        /// <param name="force">If true, register the type <typeparamref name="T"/> 
        /// even if it has already been registered.</param>
        /// <param name="wrapperType">The type to use for displaying any error messages.</param>
        public virtual void RegisterType<T>(bool force, Type wrapperType = null)
        {
            this.EnsureIsAssignableRegisteredType<T>();

            Type type = typeof(T);
            string typeName = DataFactoryUtilities.GetResourceTypeName(type);
            string wrapperTypeName = wrapperType != null ? wrapperType.Name : typeof(TRegistered).Name;

            lock (RegistrationLock)
            {
                if (this.TypeMap.ContainsKey(typeName))
                {
                    if (force)
                    {
                        this.TypeMap.Remove(typeName);
                    }
                    else
                    {
                        throw new InvalidOperationException(string.Format(
                            CultureInfo.InvariantCulture,
                            "A {0} type with the name '{1}' is already registered.",
                            wrapperTypeName,
                            typeName));
                    }
                }

                this.TypeMap.Add(typeName, type);    
            }
        }

        public bool TypeIsRegistered<T>()
        {
            this.EnsureIsAssignableRegisteredType<T>();
            string typeName = DataFactoryUtilities.GetResourceTypeName(typeof(T));
 
            lock (RegistrationLock)
            {
                return this.TypeMap.ContainsKey(typeName);
            }
        }

        public bool TryGetRegisteredType(string typeName, out Type type)
        {           
            lock (RegistrationLock)
            {
                return this.TypeMap.TryGetValue(typeName, out type);
            }
        }

        protected override object ReadJsonWrapper(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);

            JToken token;
            if (!obj.TryGetTypeProperty(out token))
            {
                return null;
            }

            Type type;
            if (!this.TryGetRegisteredType(token.ToString(), out type))
            {
                return null;
            }

            TRegistered target = (TRegistered)Activator.CreateInstance(type);
            serializer.Populate(obj.CreateReader(), target);

            return target;
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

        private static IDictionary<string, Type> GetReservedTypes()
        {
            Type rootType = typeof(TRegistered);
            return rootType.Assembly.GetTypes()
                .Where(rootType.IsAssignableFrom)
                .ToDictionary(GetTypeName, StringComparer.OrdinalIgnoreCase);
        }

        private static IDictionary<string, Type> GetReservedTypesForCopy()
        {
            return new Dictionary<string, Type>(reservedTypesFromAssembly.Value, StringComparer.OrdinalIgnoreCase);
        }
    } 
}
