// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.ResourceMover.Models
{
    /// <summary> Defines the resource group resource settings. </summary>
    public partial class ResourceGroupResourceSettings : MoverResourceSettings
    {
        /// <summary> Initializes a new instance of ResourceGroupResourceSettings. </summary>
        public ResourceGroupResourceSettings(string targetResourceName) : base(targetResourceName)
        {
            Argument.AssertNotNull(targetResourceName, nameof(targetResourceName));
            ResourceType = "resourceGroups";
        }
    }
}
