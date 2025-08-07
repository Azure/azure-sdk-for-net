// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.StorageMover.Models
{
    /// <summary> The Endpoint resource. </summary>
    public partial class StorageMoverEndpointPatch
    {
        /// <summary> A description for the Endpoint. </summary>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string EndpointBaseUpdateDescription
        {
            get => Properties is null ? default : Properties.Description;
            set
            {
                if (Properties is null)
                    Properties = new UnknownEndpointBaseUpdateProperties();
                Properties.Description = value;
            }
        }
    }
}
