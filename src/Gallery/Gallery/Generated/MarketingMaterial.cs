// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;

namespace Microsoft.Azure.Gallery
{
    /// <summary>
    /// Gallery item mMarketing material.
    /// </summary>
    public partial class MarketingMaterial
    {
        private string _path;
        
        /// <summary>
        /// Optional. Gets or sets marketing web page relative path - Relative
        /// to http://azure.com.
        /// </summary>
        public string Path
        {
            get { return this._path; }
            set { this._path = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the MarketingMaterial class.
        /// </summary>
        public MarketingMaterial()
        {
        }
    }
}
