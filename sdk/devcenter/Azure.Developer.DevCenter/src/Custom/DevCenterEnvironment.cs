// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Developer.DevCenter.Models
{
    public partial class DevCenterEnvironment
    {
        /// <summary> The identifier of the resource group containing the environment's resources. </summary>
        public ResourceIdentifier ResourceGroupId { get; }
    }
}
