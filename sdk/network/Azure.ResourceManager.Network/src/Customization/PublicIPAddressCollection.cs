// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.ResourceManager.Network
{
    public partial class PublicIPAddressCollection
    {
        internal PublicIPAddressCollection(ArmClient client, ResourceIdentifier id, string ipConfigurationName) : this(client, id)
        {
        }
    }
}
