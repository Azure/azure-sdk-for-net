// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using System;
using System.Collections.Generic;

namespace DataFactory.Tests.Framework
{
    /// <summary>
    /// Contains JSON sample metadata used by test automation
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class JsonSampleAttribute : Attribute
    {
        /// <summary>
        /// Paths of property names that are user-specified. That is, in the OM they are a keys in a property bag dictionary and not
        /// first-class citizens of the object model. Such properties should always be represented with the exact
        /// casing specified by the user. Unlike first-class object model properties, the des/ser process should not convert them to camel/Pascal case.
        /// </summary>
        public HashSet<string> PropertyBagKeys
        {
            get;
            private set;
        }

        public string Version
        {
            get;
            private set;
        }

        public JsonSampleAttribute()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="version">
        /// Json Payload may be only effect to some version of API, test should be able to specify which API version to be used.
        /// </param>
        public JsonSampleAttribute(string version) 
            : this()
        {
            if (!string.IsNullOrEmpty(version))
            {
                this.Version = version;
            }
        }

        public JsonSampleAttribute(string version, params string[] propertyBagKeys)
            : this(propertyBagKeys)
        {
            if (!string.IsNullOrEmpty(version))
            {
                this.Version = version;
            }
        }        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyBagKeys">
        /// Paths of property names that are user-specified. That is, in the OM they are a keys in a property bag dictionary and not
        /// first-class citizens of the object model. Such properties should always be represented with the exact
        /// casing specified by the user. Unlike first-class object model properties, the des/ser process should not convert them to camel/Pascal case.
        /// </param>
        public JsonSampleAttribute(params string[] propertyBagKeys) 
            : this()
        {
            this.PropertyBagKeys = new HashSet<string>(JsonUtilities.PropertyNameComparer);

            if (propertyBagKeys != null)
            {
                foreach (var key in propertyBagKeys)
                {
                    this.PropertyBagKeys.Add(key);
                }
            }
        }
    }
}
