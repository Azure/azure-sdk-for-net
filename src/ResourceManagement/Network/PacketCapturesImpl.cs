// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;

namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Network.Fluent.PacketCapture.Definition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Rest;

    /// <summary>
    /// Represents Packet Captures collection associated with Network Watcher.
    /// </summary>

    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uUGFja2V0Q2FwdHVyZXNJbXBs
    internal partial class PacketCapturesImpl  :
        CreatableResources<IPacketCapture,
            PacketCaptureImpl,
            PacketCaptureResultInner>,
        IPacketCaptures
    {
        private NetworkWatcherImpl parent;
        protected IPacketCapturesOperations innerCollection;
        
        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:B286BEB4529EB2A020B2C37E224A5577
        public PacketCaptureImpl Define(string name)
        {
            return new PacketCaptureImpl(name, parent, new PacketCaptureResultInner(), innerCollection);
        }

        
        ///GENMHASH:5C58E472AE184041661005E7B2D7EE30:6B6D1D91AC2FCE3076EBD61D0DB099CF
        public IPacketCapture GetByName(string name)
        {
            return Extensions.Synchronize(() => GetByNameAsync(name));
        }

        /// <summary>
        /// Creates a new PacketCapturesImpl.
        /// </summary>
        /// <param name="parent">The Network Watcher associated with Packet Captures.</param>
        
        ///GENMHASH:750F0D1D5E828511C6FDB39095E47895:8DA68F36B326063647048D7F9A34FC05
        internal  PacketCapturesImpl(IPacketCapturesOperations innerCollection, NetworkWatcherImpl parent)
        {
            this.parent = parent;
            this.innerCollection = innerCollection;
        }

        ///GENMHASH:C852FF1A7022E39B3C33C4B996B5E6D6:694E1B056CDD411C7CC3F8EDCE9A49AF
        public IPacketCapturesOperations Inner
        {
            get
            {
                return innerCollection;
            }
        }

        public override void DeleteById(string id)
        {
            throw new System.NotImplementedException();
        }

        
        ///GENMHASH:4D33A73A344E127F784620E76B686786:B016E9F1E898A15E4995A241E8FB38A5
        public override async Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            ResourceId resourceId = ResourceId.FromString(id);
            await this.innerCollection.DeleteAsync(resourceId.ResourceGroupName, resourceId.Parent.Name, resourceId.Name);
        }

        
        ///GENMHASH:885F10CFCF9E6A9547B0702B4BBD8C9E:174049B94B417C1B8FBE2D335A520FD6
        public async Task<IPacketCapture> GetByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await innerCollection.GetAsync(parent.ResourceGroupName, parent.Name, name);
            return (WrapModel(inner));  
        }

        
        ///GENMHASH:C2DC9CFAB6C291D220DD4F29AFF1BBEC:7459D8B9F8BB0A1EBD2FC4702A86F2F5
        public void DeleteByName(string name)
        {
            Extensions.Synchronize(() => DeleteByNameAsync(name));
        }

        
        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:A848F2676FADFFFDD0FBF4834FC5D602
        public IEnumerable<Microsoft.Azure.Management.Network.Fluent.IPacketCapture> List()
        {
            Func<PacketCaptureResultInner, IPacketCapture> converter = inner =>
            {
                return ((PacketCaptureImpl)WrapModel(inner));
            };
            return Extensions.Synchronize(() => Inner.ListAsync(parent.ResourceGroupName, parent.Name))
                .Select(inner => converter(inner));
        }

        /// <return>An observable emits packet captures in this collection.</return>
        
        ///GENMHASH:7F5BEBF638B801886F5E13E6CCFF6A4E:D4D129DBA16DC8F826460DF133372FD4
        public async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IPacketCapture>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            var innerPacketCaptures = await Inner.ListAsync(parent.ResourceGroupName, parent.Name, cancellationToken);
            var result = innerPacketCaptures.Select((innerPacketCapture) => WrapModel(innerPacketCapture));
            return PagedCollection<IPacketCapture, PacketCaptureResultInner>.CreateFromEnumerable(result);
        }

        
        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:B286BEB4529EB2A020B2C37E224A5577
        protected override PacketCaptureImpl WrapModel(string name)
        {
            return new PacketCaptureImpl(name, parent, new PacketCaptureResultInner(), innerCollection);
        }

        
        ///GENMHASH:B4038EF37E912E1388AC6C11E7D32E98:14FFE1F1075202D270B459A1EBFCC607
        protected override IPacketCapture WrapModel(PacketCaptureResultInner inner)
        {
            return (inner == null) ? null : new PacketCaptureImpl(inner.Name, parent, inner, innerCollection);
        }

        
        ///GENMHASH:971272FEE209B8A9A552B92179C1F926:E5B162BD6005B3BA236ADFAE6CA0A4CF
        public async Task DeleteByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.innerCollection.DeleteAsync(parent.ResourceGroupName, parent.Name, name);
        }

        IPacketCapturesOperations IHasInner<IPacketCapturesOperations>.Inner
        {
            get { return innerCollection; }
        }
    }
}
