// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;

namespace Microsoft.Azure.Gallery
{
    /// <summary>
    /// A gallery item link.
    /// </summary>
    public partial class Link
    {
        private string _displayName;
        
        /// <summary>
        /// Optional. Gets or sets link display name.
        /// </summary>
        public string DisplayName
        {
            get { return this._displayName; }
            set { this._displayName = value; }
        }
        
        private string _identifier;
        
        /// <summary>
        /// Optional. Gets or sets link identifier.
        /// </summary>
        public string Identifier
        {
            get { return this._identifier; }
            set { this._identifier = value; }
        }
        
        private string _uri;
        
        /// <summary>
        /// Optional. Gets or sets link Uri.
        /// </summary>
        public string Uri
        {
            get { return this._uri; }
            set { this._uri = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the Link class.
        /// </summary>
        public Link()
        {
        }
    }
}
