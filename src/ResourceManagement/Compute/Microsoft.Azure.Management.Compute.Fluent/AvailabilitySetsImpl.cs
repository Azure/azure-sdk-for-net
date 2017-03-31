// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Compute.Fluent
{
    /// <summary>
    /// The implementation for AvailabilitySets.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uQXZhaWxhYmlsaXR5U2V0c0ltcGw=
    internal partial class AvailabilitySetsImpl :
        GroupableResources<
            IAvailabilitySet,
            AvailabilitySetImpl,
            AvailabilitySetInner,
            IAvailabilitySetsOperations,
            IComputeManager>,
        IAvailabilitySets
    {
        ///GENMHASH:8CC9050C7F8D33DF867D6102B6152B2E:872A681ED7AE386A7C237A1C77E3E12A
        internal AvailabilitySetsImpl(IComputeManager computeManager) : base(computeManager.Inner.AvailabilitySets, computeManager)
        {}

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public AvailabilitySetImpl Define(string name)
        {
            return WrapModel(name);
        }

        ///GENMHASH:0679DF8CA692D1AC80FC21655835E678:B9B028D620AC932FDF66D2783E476B0D
        public async override Task DeleteByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:E05BE5112BBF24DC07F63B90A384905C
        public IEnumerable<IAvailabilitySet> List()
        {
            // There is no API supporting listing of availability set across subscription so enumerate all RGs and then
            // flatten the "list of list of availability sets" as "list of availability sets" .
            return Manager.ResourceManager.ResourceGroups.List()
                                          .SelectMany(rg => ListByGroup(rg.Name));
        }

        ///GENMHASH:95834C6C7DA388E666B705A62A7D02BF:3953AC722DFFCDF40E1EEF787AFD1326
        public IEnumerable<IAvailabilitySet> ListByGroup(string resourceGroupName)
        {
            return WrapList(Inner.List(resourceGroupName));
        }

        public Task<IEnumerable<IAvailabilitySet>> ListByGroupAsync(string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken))
        {
            // ListByGroupAsync sholud be removed
            throw new NotSupportedException();
        }

        ///GENMHASH:AB63F782DA5B8D22523A284DAD664D17:7CC0F8C63730735B2D69A34858088DFD
        public async override Task<IAvailabilitySet> GetByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var availabilitySetInner = await Inner.GetAsync(groupName, name, cancellationToken);
            return WrapModel(availabilitySetInner);
        }

        ///GENMHASH:08094366E86F6F96174452394778C4F6:ACF6A3952D2A0F720A28B7BE9957D330
        protected override IAvailabilitySet WrapModel(AvailabilitySetInner availabilitySetInner)
        {
            return new AvailabilitySetImpl(availabilitySetInner.Name, availabilitySetInner, Manager);
        }

        /// <summary>
        /// Fluent model helpers.
        /// </summary>

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:0BFDE6A0F400FA3705EAC9170F74F0CB
        protected override AvailabilitySetImpl WrapModel(string name)
        {
            return new AvailabilitySetImpl(name, new AvailabilitySetInner(), Manager);
        }
    }
}
