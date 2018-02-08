// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using Microsoft.Azure;
using Microsoft.Azure.Gallery;

namespace Microsoft.Azure.Gallery.Models
{
    /// <summary>
    /// Gallery item information.
    /// </summary>
    public partial class ItemGetParameters : AzureOperationResponse
    {
        private GalleryItem _item;
        
        /// <summary>
        /// Optional. Gets or sets a gallery item.
        /// </summary>
        public GalleryItem Item
        {
            get { return this._item; }
            set { this._item = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the ItemGetParameters class.
        /// </summary>
        public ItemGetParameters()
        {
        }
    }
}
