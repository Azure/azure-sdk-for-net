// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;

namespace Microsoft.Azure.Gallery
{
    /// <summary>
    /// A gallery item filter.
    /// </summary>
    public partial class Filter
    {
        private string _type;
        
        /// <summary>
        /// Optional. Gets or sets filter type.
        /// </summary>
        public string Type
        {
            get { return this._type; }
            set { this._type = value; }
        }
        
        private string _value;
        
        /// <summary>
        /// Optional. Gets or sets filter value.
        /// </summary>
        public string Value
        {
            get { return this._value; }
            set { this._value = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the Filter class.
        /// </summary>
        public Filter()
        {
        }
    }
}
