// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Implementation for Network Watchers.
    /// </summary>

    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uTmV0d29ya1dhdGNoZXJzSW1wbA==
    internal partial class NetworkWatchersImpl  :
        GroupableResources<INetworkWatcher,
            NetworkWatcherImpl,
            NetworkWatcherInner,
            INetworkWatchersOperations,
            INetworkManager>,
        INetworkWatchers
    {
        
        ///GENMHASH:3A03D39CB6798E01F6AE75EACB2C1BE6:E3EBF0BC1484E8FD120E4E5A1D237F6A
        internal  NetworkWatchersImpl(INetworkManager networkManager)
            : base(networkManager.Inner.NetworkWatchers, 
                  networkManager)
        {
        }

        
        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public NetworkWatcherImpl Define(string name)
        {
            return WrapModel(name);
        }

        
        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:9501D4AC00C1A480FAA373B4EE254723
        protected override NetworkWatcherImpl WrapModel(string name)
        {
            return new NetworkWatcherImpl(name, new NetworkWatcherInner(), Manager);
        }

        
        ///GENMHASH:92D118F36540A41689B877C0F901DCF1:236C90C989FEDAE7886278AFFE6FD7B0
        protected override INetworkWatcher WrapModel(NetworkWatcherInner inner)
        {
            if (inner == null) {
                return null;
            }
            return new NetworkWatcherImpl(inner.Name, inner, Manager);           
        }

        protected async override Task<NetworkWatcherInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await Inner.GetAsync(groupName, name, cancellationToken: cancellationToken);
        }

        protected async override Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken);
        }

        public IEnumerable<INetworkWatcher> List()
        {
            return WrapList(Extensions.Synchronize(() => Inner.ListAllAsync()));
        }

        public async Task<IPagedCollection<INetworkWatcher>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = new CancellationToken())
        {
            var innerNetworkWatchers = await Inner.ListAllAsync(cancellationToken);
            var result = innerNetworkWatchers.Select((innerNetworkWatcher) => WrapModel(innerNetworkWatcher));
            return PagedCollection<INetworkWatcher, NetworkWatcherInner>.CreateFromEnumerable(result);
        }

        public IEnumerable<INetworkWatcher> ListByResourceGroup(string resourceGroupName)
        {
            return WrapList(Extensions.Synchronize(() => Inner.ListAsync(resourceGroupName)));
        }

        public async Task<IPagedCollection<INetworkWatcher>> ListByResourceGroupAsync(string resourceGroupName, bool loadAllPages = true,
            CancellationToken cancellationToken = new CancellationToken())
        {
            var innerNetworkWatchers = await Inner.ListAsync(resourceGroupName, cancellationToken);
            var result = innerNetworkWatchers.Select((innerNetworkWatcher) => WrapModel(innerNetworkWatcher));
            return PagedCollection<INetworkWatcher, NetworkWatcherInner>.CreateFromEnumerable(result);
        }

        public async Task<IEnumerable<string>> DeleteByIdsAsync(IList<string> ids, CancellationToken cancellationToken = new CancellationToken())
        {
            var taskList = ids.Select(id => DeleteByIdAsync(id, cancellationToken)).ToList();
            await Task.WhenAll(taskList);
            return ids;
        }

        public Task<IEnumerable<string>> DeleteByIdsAsync(string[] ids, CancellationToken cancellationToken = new CancellationToken())
        {
            return DeleteByIdsAsync(new List<string>(ids), cancellationToken);
        }

        public void DeleteByIds(IList<string> ids)
        {
            DeleteByIdsAsync(ids).Wait();
        }

        public void DeleteByIds(params string[] ids)
        {
            DeleteByIdsAsync(ids).Wait();
        }
    }
}
