// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.VerificationIPFlow.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasProtocol.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Implementation of VerificationIPFlow.
    /// </summary>

    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uVmVyaWZpY2F0aW9uSVBGbG93SW1wbA==
    internal partial class VerificationIPFlowImpl  :
        Executable<IVerificationIPFlow>,
        IVerificationIPFlow,
        IDefinition
    {
        private NetworkWatcherImpl parent;
        private VerificationIPFlowParametersInner parameters = new VerificationIPFlowParametersInner();
        private VerificationIPFlowResultInner result;
        
        ///GENMHASH:FD5D5A8D6904B467321E345BE1FA424E:8AB87020DE6C711CD971F3D80C33DD83
        public NetworkWatcherImpl Parent()
        {
            return parent;
        }

        
        ///GENMHASH:AD2631B1DB33BADA121356C1B30A8CEF:22CA551C34302C2ECB41398C91A06993
        public Models.Access Access()
        {
            return Models.Access.Parse(result.Access);
        }

        
        ///GENMHASH:BB86B1F07AADE33841AA4762FF3CC20E:B387E3DD8624B2499C0BDB4DDC202E72
        public VerificationIPFlowImpl WithProtocol(Protocol protocol)
        {
            parameters.Protocol = protocol.Value;
            return this;
        }

        
        ///GENMHASH:DE00C0DF19344C15ADA6AF7BD28212E7:9E9C85330F832940548437E0BFF4F648
        public IWithProtocol Inbound()
        {
            return WithDirection(Direction.Inbound);
        }

        
        ///GENMHASH:DE2309F0433E6440B607ADF68B95E3C6:D6EED079B4F833CC4BCDBCF8CD8719CC
        public VerificationIPFlowImpl WithTargetResourceId(string targetResourceId)
        {
            parameters.TargetResourceId = targetResourceId;
            return this;
        }

        
        ///GENMHASH:6499EBB78DEEDAB2CB7A015C719C5491:28FF3BD80B363A30E762A1D67C60B919
        public VerificationIPFlowImpl WithRemoteIPAddress(string remoteIPAddress)
        {
            parameters.RemoteIPAddress = remoteIPAddress;
            return this;
        }

        
        ///GENMHASH:D5B82639CB07FC30A417D79D5029D509:425AAA90FA44C25BF65D98CF87FB3E57
        internal  VerificationIPFlowImpl(NetworkWatcherImpl parent)
        {
            this.parent = parent;
        }

        
        ///GENMHASH:C98638A316A8335D71A0C304CD5F3223:11AAB96226F6631FB069A24E580A4F44
        public VerificationIPFlowImpl WithLocalIPAddress(string localIPAddress)
        {
            parameters.LocalIPAddress = localIPAddress;
            return this;
        }

        
        ///GENMHASH:D5128E88467A6B172A89A50F0F0F88D9:FDFF64DEFBB7046083446D549F1CC328
        public VerificationIPFlowImpl WithLocalPort(string localPort)
        {
            parameters.LocalPort = localPort;
            return this;
        }

        
        ///GENMHASH:474E02257E2AE7663EEAFE7D2306F217:AE52C01285A7507D3FF8B55101140BF3
        public VerificationIPFlowImpl WithRemotePort(string remotePort)
        {
            parameters.RemotePort = remotePort;
            return this;
        }

        
        ///GENMHASH:CD439A9A0EEB2CF0133E315FD689D362:5889115CA9827174846B143D1E5C28CE
        public VerificationIPFlowImpl WithDirection(Direction direction)
        {
            parameters.Direction = direction.Value;
            return this;
        }

        
        ///GENMHASH:9EF9E4B3FA586E17D14DE931AC742510:42AD059E7262C5A8AAA92E41CFD44B75
        public IWithProtocol Outbound()
        {
            return WithDirection(Direction.Outbound);
        }

        
        ///GENMHASH:B4858D1B3832472F65F15B5A90B1AA9A:E902986261253137210F32831D73A99F
        public string RuleName()
        {
            return this.result.RuleName;
        }

        
        ///GENMHASH:F0DF1562B8B293A495AB4D86FA5FF5A2:8668EBCD576CE12CC0DF56FC49AA4BDF
        public IVerificationIPFlow WithTargetNetworkInterfaceId(string targetNetworkInterfaceId)
        {
            parameters.TargetNicResourceId = targetNetworkInterfaceId;
            return this;
        }

        
        ///GENMHASH:FA2535431E8DE1A68BC05577993DEAFF:D55D5BD9867C55095428F74D81048912
        public IWithLocalIP WithTCP()
        {
            return WithProtocol(Protocol.TCP);
        }

        
        ///GENMHASH:D36AEA2E8788C46661B7C3DA03646E23:4082802774A0A2A4DD57F3F46876C1CE
        public IWithLocalIP WithUDP()
        {
            return WithProtocol(Protocol.UDP);
        }

        public override async Task<IVerificationIPFlow> ExecuteAsync(CancellationToken cancellationToken = new CancellationToken(), bool multiThreaded = true)
        {
            result = await parent.Manager.Inner.NetworkWatchers
                .VerifyIPFlowAsync(parent.ResourceGroupName, parent.Name, parameters, cancellationToken);
            return this;
        }
    }
}
