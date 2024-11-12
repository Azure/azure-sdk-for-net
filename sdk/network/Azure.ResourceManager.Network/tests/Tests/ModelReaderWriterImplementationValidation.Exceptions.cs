// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.TestFramework
{
    public sealed partial class ModelReaderWriterImplementationValidation
    {
        public ModelReaderWriterImplementationValidation()
        {
            ExceptionList = new[]
            {
                "Azure.ResourceManager.Network.Models.PeerRouteList",
                "Azure.ResourceManager.Network.Models.ProtocolCustomSettings",
                "Azure.ResourceManager.Network.Models.VpnClientParameters",
                "Azure.ResourceManager.Network.Models.VpnPacketCaptureStartParameters",
                "Azure.ResourceManager.Network.Models.VpnPacketCaptureStopParameters"
            };
        }
    }
}
