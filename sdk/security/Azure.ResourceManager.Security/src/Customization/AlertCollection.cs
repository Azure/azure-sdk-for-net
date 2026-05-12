// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.Security
{
    public partial class AlertCollection
    {
        internal AlertCollection(ArmClient client, ResourceIdentifier id) : this(client, id, id.Name)
        {
        }
    }
}
