// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Network
{
    /// <summary>
    /// A class representing the NetworkGroup data model.
    /// The network group resource
    /// </summary>
    public partial class NetworkGroupData : ResourceData
    {
        /// <summary> Unique identifier for this resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Guid? ResourceGuid { get; }
    }
}
