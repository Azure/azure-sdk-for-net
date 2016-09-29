// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.V2.Resource;
using Microsoft.Azure.Management.V2.Resource.Core;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Compute
{
    /// <summary>
    /// The implementation for AvailabilitySets.
    /// </summary>
    internal partial class AvailabilitySetsImpl :
        GroupableResources<IAvailabilitySet,
            AvailabilitySetImpl,
            AvailabilitySetInner,
            IAvailabilitySetsOperations, 
            IComputeManager>,
        IAvailabilitySets
    {
        internal AvailabilitySetsImpl(IAvailabilitySetsOperations client, IComputeManager computeManager) : base(client, computeManager)
        {}

        public AvailabilitySetImpl Define(string name)
        {
            return WrapModel(name);
        }

        public void Delete(string id)
        {
            DeleteAsync(id).Wait();
        }

        public void Delete(string groupName, string name)
        {
            DeleteAsync(groupName, name).Wait();
        }

        public Task DeleteAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return DeleteAsync(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id));
        }

        public Task DeleteAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return InnerCollection.DeleteAsync(groupName, name, cancellationToken);
        }

        public PagedList<IAvailabilitySet> List()
        {
            // There is no API supporting listing of availabiltiy set across subscription so enumerate all RGs and then
            // flatten the "list of list of availibility sets" as "list of availibility sets" .
            return new ChildListFlattener<IResourceGroup, IAvailabilitySet>(Manager.ResourceManager.ResourceGroups.List(), (IResourceGroup resourceGroup) =>
            {
                return ListByGroup(resourceGroup.Name);
            }).Flatten();
        }

        public PagedList<IAvailabilitySet> ListByGroup(string resourceGroupName)
        {
            var pagedList = new PagedList<AvailabilitySetInner>(InnerCollection.List(resourceGroupName));
            return WrapList(pagedList);
        }

        public Task<PagedList<IAvailabilitySet>> ListByGroupAsync(string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken))
        {
            // ListByGroupAsync sholud be removed
            throw new NotSupportedException();
        }

        #region Implementation of Abstract members in GroupableResources

        public override async Task<IAvailabilitySet> GetByGroupAsync(string groupName, string name)
        {
            var availabilitySetInner = await InnerCollection.GetAsync(groupName, name);
            return WrapModel(availabilitySetInner);
        }

        protected override IAvailabilitySet WrapModel(AvailabilitySetInner availabilitySetInner)
        {
            return new AvailabilitySetImpl(availabilitySetInner.Name, availabilitySetInner, InnerCollection, Manager);
        }

        protected override AvailabilitySetImpl WrapModel(string name)
        {
            return new AvailabilitySetImpl(name, new AvailabilitySetInner(), InnerCollection, Manager);
        }

        #endregion
    }
}
