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

namespace Microsoft.Azure.Common.OData
{
    /// <summary>
    /// Parameter attribute used with OData filters.
    /// </summary>
    public class FilterParameterAttribute : Attribute
    {
        /// <summary>
        /// Property name to use in the filter.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Format of the value.
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FilterParameterAttribute"/> class.
        /// </summary>
        /// <param name="name">Property name to use in the filter.</param>
        public FilterParameterAttribute(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FilterParameterAttribute"/> class.
        /// </summary>
        /// <param name="name">Property name to use in the filter.</param>
        /// <param name="format">Format of the value.</param>
        public FilterParameterAttribute(string name, string format)
        {
            Name = name;
            Format = format;
        }
    }
}
