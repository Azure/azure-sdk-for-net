// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// Implementation for  com.microsoft.azure.management.network.PacketCaptureStatus.
    /// </summary>

    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uUGFja2V0Q2FwdHVyZVN0YXR1c0ltcGw=
    internal partial class PacketCaptureStatusImpl  :
        Wrapper<Models.PacketCaptureQueryStatusResultInner>,
        IPacketCaptureStatus
    {
        
        ///GENMHASH:CE748D664EC5A1BCFA1EFDD771FAA21A:9B06DA9CD0B0565AD51711A34DC7477D
        public string StopReason()
        {
            return Inner.StopReason;
        }

        
        ///GENMHASH:3CADBFB102034B33BBBACF8D0CEE6326:DBD59E43FA6B6209ACBFB2AA00C9B19F
        public DateTime CaptureStartTime()
        {
            return Inner.CaptureStartTime.GetValueOrDefault();
        }

        
        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:0EDBC6F12844C2F2056BFF916F51853B
        public string Name()
        {
            return Inner.Name;
        }

        
        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:A3CF7B3DC953F353AAE8083D72F74056
        public string Id()
        {
            return Inner.Id;
       }

        
        ///GENMHASH:FD831087F4F6D367288620E870CFEADF:29B42AAA7BBB787804889088EECFB694
        public PcStatus PacketCaptureStatus()
        {
            return PcStatus.Parse(Inner.PacketCaptureStatus);
        }

        
        ///GENMHASH:36CA37785AAD9B44F61279A15F1053EB:C0C35E00AF4E17F141675A2C05C7067B
        internal  PacketCaptureStatusImpl(PacketCaptureQueryStatusResultInner innerObject)
            : base(innerObject)
        {
        }

        
        ///GENMHASH:DF758F93F01127457A65F7F07ACE8601:F9FB741DEB49EE11312ECA2C62648263
        public IReadOnlyList<Models.PcError> PacketCaptureErrors()
        {
            var list = new List<PcError>();
            foreach (var item in Inner.PacketCaptureError)
            {
                list.Add(PcError.Parse(item));
            }
            return list.AsReadOnly();
        }
    }
}
