// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.Security
{
    // Generated AscLocationResource collection access does not pass ascLocation, but AlertCollection still requires it.
    // The resource identifier name is the location segment for this collection path.
    public partial class AlertCollection
    {
        internal AlertCollection(ArmClient client, ResourceIdentifier id) : this(client, id, id.Name)
        {
        }
    }
}
