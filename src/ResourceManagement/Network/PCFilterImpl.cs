// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.PCFilter.Definition;
    using Microsoft.Azure.Management.Network.Fluent.PacketCapture.Definition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.HasProtocol.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using System.Collections.Generic;

    /// <summary>
    /// Represents Packet Capture filter.
    /// </summary>
    
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uUENGaWx0ZXJJbXBs
    internal partial class PCFilterImpl :
        IndexableWrapper<Models.PacketCaptureFilter>,
        IPCFilter,
        IDefinition<PacketCapture.Definition.IWithCreate>
    {
        private static string DELIMITER = ";";
        private static string RANGE_DELIMITER = "-";
        private PacketCaptureImpl parent;

        
        ///GENMHASH:FD5D5A8D6904B467321E345BE1FA424E:8AB87020DE6C711CD971F3D80C33DD83
        public IPacketCapture Parent()
        {
            return parent;
        }

        
        ///GENMHASH:338B7728A13D85D7ACAC8732699C7C37:294650B9B2C42571BFFDBCB5EBB76B45
        public IDefinition<PacketCapture.Definition.IWithCreate> WithLocalPorts(IList<int> ports)
        {
            Inner.LocalPort = string.Join(DELIMITER, ports.ToArray());
            return this;
        }

        
        ///GENMHASH:36E0ABC85D8EBF145E7F9BF8BE6D495C:4209AB8E9A77A8D03CA7C320B203586B
        public IDefinition<PacketCapture.Definition.IWithCreate> WithRemoteIPAddressesRange(string startIPAddress,
            string endIPAddress)
        {
            Inner.RemoteIPAddress = startIPAddress + RANGE_DELIMITER + endIPAddress;
            return this;
        }

        
        ///GENMHASH:38FB152C2AD4799D6CD511EBE4F6079C:12993AB7055D2E298DB4AA07C089043C
        public string LocalPort()
        {
            return Inner.LocalPort;
        }

        
        ///GENMHASH:96D02FBE55488E00AEE491603ECDA545:8E47A7551FAA8958BCB5314D0E665506
        public PCFilterImpl WithProtocol(PcProtocol protocol)
        {
            Inner.Protocol = protocol.Value;
            return this;
        }

        
        ///GENMHASH:D497E01A2A784007CB38C3BA617F0D8B:F5EA0186176CDA88952561B719FCEDC5
        public string RemotePort()
        {
            return Inner.RemotePort;
        }

        
        ///GENMHASH:6499EBB78DEEDAB2CB7A015C719C5491:D1032913DA15030F65F71EAD08CCE977
        public PCFilterImpl WithRemoteIPAddress(string ipAddress)
        {
            Inner.RemoteIPAddress = ipAddress;
            return this;
        }

        
        ///GENMHASH:D36C3D0547BD33C476E2848081356ECB:D1BA9015C65A5379B5AD75E108923D91
        public string LocalIPAddress()
        {
            return Inner.LocalIPAddress;
        }

        
        ///GENMHASH:AF99AAD4C5EAD3F935A485B37854B17A:E211556588CB8D9692EBA641934E5090
        public IDefinition<PacketCapture.Definition.IWithCreate> WithRemotePorts(IList<int> ports)
        {
            Inner.RemotePort = string.Join(DELIMITER, ports.ToArray());
            return this;
        }

        
        ///GENMHASH:C98638A316A8335D71A0C304CD5F3223:182CBE57D223CBF80D660B56C0A1A758
        public PCFilterImpl WithLocalIPAddress(string ipAddress)
        {
            Inner.LocalIPAddress = ipAddress;
            return this;
        }

        
        ///GENMHASH:F028360F9A532A0859235A6639624F60:A794808CCB429729D19B024D35DF9AB3
        public IDefinition<PacketCapture.Definition.IWithCreate> WithLocalPort(int port)
        {
            Inner.LocalPort = port.ToString();
            return this;
        }

        
        ///GENMHASH:887C2A0E5287839F96B28FB718A8E46C:CA53B7BE62B1D1854755EDD010D28892
        internal PCFilterImpl(PacketCaptureFilter inner, PacketCaptureImpl parent)
            : base(inner)
        {
            this.parent = parent;
        }

        
        ///GENMHASH:D684E7477889A9013C81FAD82F69C54F:BD249A015EF71106387B78281489583A
        public PcProtocol Protocol()
        {
            return PcProtocol.Parse(Inner.Protocol);
        }

        
        ///GENMHASH:F3D63E57E88AC8C9AFA83AF03F2F7EDF:EF05CE77E1EACCC5612385E3927A8D37
        public IDefinition<PacketCapture.Definition.IWithCreate> WithRemotePort(int port)
        {
            Inner.RemotePort = port.ToString();
            return this;
        }

        
        ///GENMHASH:FF031057823E23CE10AFFA7E62AB0465:39E81967E81E8BFD05F5F87AAFEBC6F1
        public IDefinition<PacketCapture.Definition.IWithCreate> WithLocalIPAddressesRange(string startIPAddress,
            string endIPAddress)
        {
            Inner.LocalIPAddress = startIPAddress + RANGE_DELIMITER + endIPAddress;
            return this;
        }

        
        ///GENMHASH:7BA8F5AB8871662E51A848AB375A9CA1:C65768438907C2111030DF316BE0E02C
        public IDefinition<PacketCapture.Definition.IWithCreate> WithLocalPortRange(int startPort, int endPort)
        {
            Inner.LocalPort = startPort + RANGE_DELIMITER + endPort;
            return this;
        }

        
        ///GENMHASH:4737692B4FCAF7D93CC4359D9E85A7CB:9037A4F46E3A608E4A9ADEAD19AFE03B
        public string RemoteIPAddress()
        {
            return this.Inner.RemoteIPAddress;
        }

        
        ///GENMHASH:CD818ED94CF11744CAF70EED383B8DE7:29CCDB22365554D7D141CD630728A92F
        public IDefinition<PacketCapture.Definition.IWithCreate> WithLocalIPAddresses(IList<string> ipAddresses)
        {
            Inner.LocalIPAddress = string.Join(DELIMITER, ipAddresses.ToArray());
            return this;
        }

        
        ///GENMHASH:1B9EBB774A7EB18DCD2777D35E30AFDA:1E62177E7C664BA83251E7AEB64DB658
        public IDefinition<PacketCapture.Definition.IWithCreate> WithRemotePortRange(int startPort, int endPort)
        {
            Inner.RemotePort = startPort + RANGE_DELIMITER + endPort;
            return this;
        }

        
        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:919F78CEC5318B5B238E1545449321D3
        public PacketCaptureImpl Attach()
        {
            parent.AttachPCFilter(this);
            return parent;
        }

        
        ///GENMHASH:AA20AAF839D759CC8BAB1F83CCC39246:2965BC21296977F42867ABB25FB4E0BE
        public IDefinition<PacketCapture.Definition.IWithCreate> WithRemoteIPAddresses(IList<string> ipAddresses)
        {
            Inner.RemoteIPAddress = string.Join(DELIMITER, ipAddresses.ToArray());
            return this;
        }
    }
}
