// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// The implementation of Topology.
    /// </summary>
    
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uVG9wb2xvZ3lJbXBs
    internal partial class TopologyImpl :
        IndexableRefreshableWrapper<Microsoft.Azure.Management.Network.Fluent.ITopology, TopologyInner>,
        ITopology
    {
        private Dictionary<string, TopologyResource> resources;
        private NetworkWatcherImpl parent;
        private string groupName;

        
        ///GENMHASH:FD5D5A8D6904B467321E345BE1FA424E:8AB87020DE6C711CD971F3D80C33DD83
        public INetworkWatcher Parent()
        {
            return parent;
        }

        
        ///GENMHASH:E9EDBD2E8DC2C547D1386A58778AA6B9:860929086EE8E13003F5F7348930ACEC
        public string ResourceGroupName()
        {
            return groupName;
        }

        
        ///GENMHASH:5ED618DE41DCDE9DBC9F8179EF143BC3:976080A1C501F480EBF3B1F05875F199
        public DateTime LastModifiedTime()
        {
            return Inner.LastModified.GetValueOrDefault();
        }

        
        ///GENMHASH:5995F84711525BE1DF7039D80FA0DB81:0643202CC76D12C6FF1D8572DE9E7E85
        public DateTime CreatedTime()
        {
            return Inner.CreatedDateTime.GetValueOrDefault();
        }

        
        ///GENMHASH:272D43EFAA6C6AE625C0BC8C8FB25122:17D30BB94758BE3383DDEAF359B1D080
        public IReadOnlyDictionary<string, Models.TopologyResource> Resources()
        {
            return resources;
        }

        
        ///GENMHASH:5A2D79502EDA81E37A36694062AEDC65:DC2FE8DCFD4679FCC8C9396AEBC74919
        public override async Task<Microsoft.Azure.Management.Network.Fluent.ITopology> RefreshAsync(
            CancellationToken cancellationToken = default(CancellationToken))
        {
            await base.RefreshAsync();
            InitializeResourcesFromInner();
            return this;
        }

        
        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:A3CF7B3DC953F353AAE8083D72F74056
        public string Id()
        {
            return Inner.Id;
        }

        
        ///GENMHASH:432D1607DC634180D9215162AB0A4606:4E97D9B69941FDA55FB8CA87259B7D25
        internal TopologyImpl(NetworkWatcherImpl parent, TopologyInner innerObject, string groupName)
            : base(innerObject.Id, innerObject)
        {
            this.parent = parent;
            this.groupName = groupName;
            InitializeResourcesFromInner();
        }

        
        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:407DF2FB896AD0A714F7B557BFA97C87
        protected override async Task<Models.TopologyInner> GetInnerAsync(
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return await parent.Manager.Inner.NetworkWatchers
                .GetTopologyAsync(parent.ResourceGroupName, parent.Name, groupName);
        }

        
        ///GENMHASH:2C6EAE1A0B195DB734B33ADDB4203F3F:DE9D26C56D3E36A7300D87DFF280D5C5
        private void InitializeResourcesFromInner()
        {
            resources = new Dictionary<string, TopologyResource>();
            IList<TopologyResource> inners = Inner.Resources;
            if (inners != null)
            {
                foreach (var inner in inners)
                {
                    resources[inner.Id] = inner;
                }
            }
        }
    }
}
