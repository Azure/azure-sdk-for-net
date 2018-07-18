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


using System.Collections.Generic;
using Microsoft.Azure.Common.OData;

namespace Microsoft.Azure.Gallery
{
    /// <summary>
    /// Class used to define a list filter.
    /// </summary>
    public class ItemListFilter
    {
        /// <summary>
        /// Gets or sets gallery item name to filter by.
        /// </summary>
        [FilterParameter("ItemName")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets gallery item publisher name to filter by.
        /// </summary>
        public string Publisher { get; set; }

        /// <summary>
        /// Gets or sets gallery items to filter by (using Contains method).
        /// </summary>
        public IList<string> CategoryIds { get; set; }
    }
}
