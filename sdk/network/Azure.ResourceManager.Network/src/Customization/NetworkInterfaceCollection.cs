// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.ResourceManager.Network
{
    public partial class NetworkInterfaceCollection
    {
        internal NetworkInterfaceCollection(ArmClient client, ResourceIdentifier id, string cloudServiceName, string roleInstanceName) : this(client, id)
        {
        }
    }
}
