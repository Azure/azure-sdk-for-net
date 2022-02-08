// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.ResourceManager
{
    /// <summary>
    /// The entry point for all ARM clients.
    /// </summary>
    [CodeGenSuppress("GetTenant", typeof(ResourceIdentifier))]
    public partial class ArmClient
    {
    }
}
