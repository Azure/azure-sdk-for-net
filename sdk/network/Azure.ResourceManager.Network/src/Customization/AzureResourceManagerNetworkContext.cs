// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;

namespace Azure.ResourceManager.Network
{
    // The previous GA version mistakenly exposed SubscriptionNetworkManagerConnectionData. Registering the
    // compatibility type here preserves ModelReaderWriter support and prevents the generator from duplicating
    // this registration in generated code.
#pragma warning disable CS0618 // Type is retained solely for backward compatibility.
    [ModelReaderWriterBuildable(typeof(SubscriptionNetworkManagerConnectionData))]
#pragma warning restore CS0618
    public partial class AzureResourceManagerNetworkContext
    {
    }
}
