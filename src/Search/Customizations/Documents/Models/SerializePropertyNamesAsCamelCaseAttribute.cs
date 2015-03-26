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
using System.Linq;

namespace Microsoft.Azure.Search.Models
{
    /// <summary>
    /// Indicates that the public properties of a model class should be serialized as camel-case in order to match
    /// the field names of an Azure Search index.
    /// </summary>
    /// <remarks>
    /// Classes without this attribute are expected to have property names that exactly match their corresponding
    /// fields names in Azure Search. Otherwise, it would not be possible to use instances of the class to populate
    /// the index.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class SerializePropertyNamesAsCamelCaseAttribute : Attribute
    {
        internal static bool IsDefinedOnType<T>()
        {
            return typeof(T)
                .GetCustomAttributes(typeof(SerializePropertyNamesAsCamelCaseAttribute), inherit: true)
                .Any();
        }

    }
}
