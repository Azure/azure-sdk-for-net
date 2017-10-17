// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Hyak.Common;
using Microsoft.Azure;
using Microsoft.Azure.Gallery;

namespace Microsoft.Azure.Gallery.Models
{
    /// <summary>
    /// List of gallery items.
    /// </summary>
    public partial class ItemListResult : AzureOperationResponse
    {
        private IList<GalleryItem> _items;
        
        /// <summary>
        /// Optional. Gets or sets the list of gallery items.
        /// </summary>
        public IList<GalleryItem> Items
        {
            get { return this._items; }
            set { this._items = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the ItemListResult class.
        /// </summary>
        public ItemListResult()
        {
            this.Items = new LazyList<GalleryItem>();
        }
    }
}
