// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.Security
{
    // Generated resource-group extension access passes ascLocation, but TaskCollection no longer needs it.
    public partial class TaskCollection
    {
        internal TaskCollection(ArmClient client, ResourceIdentifier id, string ascLocation) : this(client, id)
        {
        }
    }
}
