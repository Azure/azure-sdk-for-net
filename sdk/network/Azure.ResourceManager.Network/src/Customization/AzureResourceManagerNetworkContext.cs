// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;

namespace Azure.ResourceManager.Network
{
    // The released model-valued appliance operation projects native resource data through this compatibility model.
#pragma warning disable CS0618 // The model is retained for the released model-valued operation.
    [ModelReaderWriterBuildable(typeof(Models.InboundSecurityRule))]
#pragma warning restore CS0618
    public partial class AzureResourceManagerNetworkContext
    {
    }
}
