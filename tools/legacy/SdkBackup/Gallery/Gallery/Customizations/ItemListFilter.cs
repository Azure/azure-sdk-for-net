// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


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
