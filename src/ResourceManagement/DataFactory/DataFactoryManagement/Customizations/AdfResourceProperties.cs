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
using System.Globalization;
using System.Reflection;

namespace Microsoft.Azure.Management.DataFactories.Models
{
    public abstract class AdfResourceProperties<TExtensibleTypeProperties, TGenericTypeProperties> 
        where TExtensibleTypeProperties : TypeProperties 
        where TGenericTypeProperties : TExtensibleTypeProperties
    {
        /// <summary>
        /// The type of the resource. May be the name of a built-in ADF type or 
        /// a type registered by a user and available to the data factory this resource
        /// is a member of.
        /// </summary>
        [AdfRequired]
        public string Type { get; private set; }

        private TExtensibleTypeProperties typeProperties;

        /// <summary>
        /// The properties specific to the resource type. 
        /// </summary>
        [AdfRequired]
        public TExtensibleTypeProperties TypeProperties
        {
            get
            {
                return this.typeProperties;
            }

            set
            {
                this.SetTypeProperties(value);
            }
        }

        protected AdfResourceProperties()
        {
        }

        protected AdfResourceProperties(TExtensibleTypeProperties properties, string typeName = null)
            : this()
        {
            this.SetTypeProperties(properties, typeName);
        }

        private void SetTypeProperties(TExtensibleTypeProperties properties, string typeName = null)
        {
            this.typeProperties = properties;

            Type type = properties.GetType();
            Type genericTypePropertiesType = typeof(TGenericTypeProperties);
            if (type == genericTypePropertiesType)
            {
                if (typeName == null)
                {
                    throw new ArgumentException(
                        string.Format(
                            CultureInfo.InvariantCulture,
                            "'typeName' cannot be null if 'properties' is a {0} instance. The setter "
                            + "for 'typeProperties' cannot be used if its value is GenericLinkedService, GenericTable or GenericActivity.",
                            genericTypePropertiesType.Name));
                }

                this.Type = typeName;
            }
            else
            {
                this.Type = GetTypeName(type, typeName);
            }
        }

        private static string GetTypeName(Type type, string actualTypeName)
        {
            if (type == typeof(TGenericTypeProperties))
            {
                Ensure.IsNotNullOrEmpty(actualTypeName, "actualTypeName");
                return actualTypeName;
            }

            return DataFactoryUtilities.GetResourceTypeName(type);
        }
    }
}
