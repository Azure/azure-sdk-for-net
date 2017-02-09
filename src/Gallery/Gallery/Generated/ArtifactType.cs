// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;

namespace Microsoft.Azure.Gallery
{
    /// <summary>
    /// Gallery artifact type.
    /// </summary>
    public static partial class ArtifactType
    {
        /// <summary>
        /// Deployment template.
        /// </summary>
        public const string Template = "template";
        
        /// <summary>
        /// Deployment fragment.
        /// </summary>
        public const string Fragment = "fragment";
        
        /// <summary>
        /// Custom element.
        /// </summary>
        public const string Custom = "custom";
        
        /// <summary>
        /// Artifact specific metadata.
        /// </summary>
        public const string Metadata = "metadata";
    }
}
