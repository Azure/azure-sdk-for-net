// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;

namespace Microsoft.Azure.Gallery
{
    /// <summary>
    /// A gallery item artifact.
    /// </summary>
    public partial class Artifact
    {
        private string _name;
        
        /// <summary>
        /// Optional. Gets or sets artifact name.
        /// </summary>
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }
        
        private string _type;
        
        /// <summary>
        /// Optional. Gets or sets artifact type.
        /// </summary>
        public string Type
        {
            get { return this._type; }
            set { this._type = value; }
        }
        
        private string _uri;
        
        /// <summary>
        /// Optional. Gets or sets artifact Uri.
        /// </summary>
        public string Uri
        {
            get { return this._uri; }
            set { this._uri = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the Artifact class.
        /// </summary>
        public Artifact()
        {
        }
    }
}
