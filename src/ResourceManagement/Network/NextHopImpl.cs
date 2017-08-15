// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Network.Fluent.NextHop.Definition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Implementation of NextHop.
    /// </summary>

    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uTmV4dEhvcEltcGw=
    internal partial class NextHopImpl  :
        Executable<Microsoft.Azure.Management.Network.Fluent.INextHop>,
        INextHop,
        IDefinition
    {
        private NetworkWatcherImpl parent;
        private NextHopParametersInner parameters = new NextHopParametersInner();
        private NextHopResultInner result;
        
        ///GENMHASH:CBA62609044BF002539F794F631D1AEF:319608FF6209541FDFD5A9FAD1FF1198
        public NextHopImpl WithSourceIPAddress(string sourceIPAddress)
        {
            this.parameters.SourceIPAddress = sourceIPAddress;
            return this;
        }

        
        ///GENMHASH:FD5D5A8D6904B467321E345BE1FA424E:8AB87020DE6C711CD971F3D80C33DD83
        public NetworkWatcherImpl Parent()
        {
            return parent;
        }

        
        ///GENMHASH:0327D01E82FA0628B767C58711824331:D0A5A9C0C70D7F7C1BBC0D81BB5C3017
        public string DestinationIPAddress()
        {
            return parameters.DestinationIPAddress;
        }

        
        ///GENMHASH:CB90C0E84B67B274003F62EFC644F855:885CBC5A9AE5A0893399AB84942F7BE5
        public string SourceIPAddress()
        {
            return parameters.SourceIPAddress;
        }

        
        ///GENMHASH:53EE7DE3CD008212386173AA5FD51DF3:D0A5A9C0C70D7F7C1BBC0D81BB5C3017
        public string TargetNetworkInterfaceId()
        {
            return parameters.DestinationIPAddress;
        }

        
        ///GENMHASH:41D73337A94BA1CFBD7B6D9FBD76CDA8:D00386D7D70F0650EF6FCDD113398AD0
        public NextHopType NextHopType()
        {
            return Models.NextHopType.Parse(result.NextHopType);

        }

        
        ///GENMHASH:DE2309F0433E6440B607ADF68B95E3C6:45C3FD2D95B0EA1F14CD52E301D414C5
        public NextHopImpl WithTargetResourceId(string targetResourceId)
        {
            this.parameters.TargetResourceId = targetResourceId;
            return this;
        }

        
        ///GENMHASH:52DF69E82E8D514EFD3A0DDD66762752:425AAA90FA44C25BF65D98CF87FB3E57
        internal  NextHopImpl(NetworkWatcherImpl parent)
        {
            this.parent = parent;
        }

        
        ///GENMHASH:763A4F005F7C78E516A5BD31336A01ED:30315B7FFC80799C8B336D5696B55132
        public NextHopImpl WithDestinationIPAddress(string destinationIPAddress)
        {
            this.parameters.DestinationIPAddress = destinationIPAddress;
            return this;
        }

        
        ///GENMHASH:54FF9EAE063A707BF467152E850B0B04:F49B330AD57E90EA0F9724A089EC8897
        public string TargetResourceId()
        {
            return parameters.TargetResourceId;
        }

        
        ///GENMHASH:A52B043B03F5F5DD10F6A96CBC569DBC:A2F0401498025DE3E7158D4E05E93353
        public string RouteTableId()
        {
            return result.RouteTableId;
        }

        
        ///GENMHASH:C735AF0BF8BEB3EB5BC91A83ED36EC28:E70D824EE07D78D1BDAF85A38B74C334
        public string NextHopIpAddress()
        {
            return result.NextHopIpAddress;
        }

        
        ///GENMHASH:F0DF1562B8B293A495AB4D86FA5FF5A2:A2B1C8AF4E3AC8DF0041FFAA7E2346FC
        public NextHopImpl WithTargetNetworkInterfaceId(string targetNetworkInterfaceId)
        {
            this.parameters.TargetNicResourceId = targetNetworkInterfaceId;
            return this;
        }

        public override async Task<INextHop> ExecuteAsync(CancellationToken cancellationToken = new CancellationToken(), bool multiThreaded = true)
        {
            this.result = await parent.Manager.Inner.NetworkWatchers
                .GetNextHopAsync(parent.ResourceGroupName, parent.Name, parameters);
            return this;
        }
    }
}
