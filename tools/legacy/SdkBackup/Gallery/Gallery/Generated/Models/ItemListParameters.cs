// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;

namespace Microsoft.Azure.Gallery.Models
{
    /// <summary>
    /// Gallery items list parameters.
    /// </summary>
    public partial class ItemListParameters
    {
        private string _filter;
        
        /// <summary>
        /// Optional. Gets or sets OData filter. Optional.
        /// </summary>
        public string Filter
        {
            get { return this._filter; }
            set { this._filter = value; }
        }
        
        private int? _top;
        
        /// <summary>
        /// Optional. Number of items to return. Optional.
        /// </summary>
        public int? Top
        {
            get { return this._top; }
            set { this._top = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the ItemListParameters class.
        /// </summary>
        public ItemListParameters()
        {
        }
    }
}
