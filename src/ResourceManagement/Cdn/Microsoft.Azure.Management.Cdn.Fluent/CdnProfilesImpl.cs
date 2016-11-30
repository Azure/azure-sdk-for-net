// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Cdn.Fluent
{
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using System.Threading;
    using Models;

    /// <summary>
    /// Implementation for CdnProfiles.
    /// </summary>
    public partial class CdnProfilesImpl  :
        GroupableResources<ICdnProfile,CdnProfileImpl,ProfileInner,IProfilesOperations,CdnManager>,
        ICdnProfiles
    {
        private IEndpointsOperations endpointsClient;
        private IOriginsOperations originsClient;
        private ICustomDomainsOperations customDomainsClient;
        private ICdnManagementClient cdnManagementClient;
        public PagedList<Operation> ListOperations()
        {
            //$ return (new PagedListConverter<OperationInner, Operation>() {
            //$ @Override
            //$ public Operation typeConvert(OperationInner inner) {
            //$ return new Operation(inner);
            //$ }
            //$ }).Convert(this.cdnManagementClient.ListOperations());

            return null;
        }

        public void LoadEndpointContent(string resourceGroupName, string profileName, string endpointName, IList<string> contentPaths)
        {
            //$ this.cdnManagementClient.Endpoints().LoadContent(resourceGroupName, profileName, endpointName, contentPaths);

        }

        public PagedList<ICdnProfile> List()
        {
            //$ return wrapList(this.InnerCollection.List());

            return null;
        }

        public void StartEndpoint(string resourceGroupName, string profileName, string endpointName)
        {
            //$ this.cdnManagementClient.Endpoints().Start(resourceGroupName, profileName, endpointName);

        }

        public void StopEndpoint(string resourceGroupName, string profileName, string endpointName)
        {
            //$ this.cdnManagementClient.Endpoints().Stop(resourceGroupName, profileName, endpointName);

        }

        public CheckNameAvailabilityResult CheckEndpointNameAvailability(string name)
        {
            //$ return new CheckNameAvailabilityResult(this.cdnManagementClient.CheckNameAvailability(name));

            return null;
        }

        public async Task DeleteByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return this.InnerCollection.DeleteAsync(groupName, name);

            return null;
        }

        public string GenerateSsoUri(string resourceGroupName, string profileName)
        {
            //$ SsoUriInner ssoUri = this.cdnManagementClient.Profiles().GenerateSsoUri(resourceGroupName, profileName);
            //$ if (ssoUri != null) {
            //$ return ssoUri.SsoUriValue();
            //$ }
            //$ return null;

            return null;
        }

        internal  CdnProfilesImpl(ICdnManagementClient cdnManagementClient, CdnManager cdnManager)
            : base(cdnManagementClient.Profiles, cdnManager)
        {
            //$ {
            //$ super(cdnManagementClient.Profiles(), cdnManager);
            //$ this.endpointsClient = cdnManagementClient.Endpoints();
            //$ this.originsClient = cdnManagementClient.Origins();
            //$ this.customDomainsClient = cdnManagementClient.CustomDomains();
            //$ this.cdnManagementClient = cdnManagementClient;
            //$ }

        }

        public CdnProfileImpl Define(string name)
        {
            //$ return wrapModel(name);

            return null;
        }

        public async Task<ICdnProfile> GetByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return wrapModel(this.InnerCollection.Get(groupName, name));

            return null;
        }

        public PagedList<ICdnProfile> ListByGroup(string groupName)
        {
            //$ return wrapList(this.InnerCollection.ListByResourceGroup(groupName));

            return null;
        }

        protected CdnProfileImpl WrapModel(string name)
        {
            //$ return new CdnProfileImpl(name,
            //$ new ProfileInner(),
            //$ this.InnerCollection,
            //$ this.endpointsClient,
            //$ this.originsClient,
            //$ this.customDomainsClient,
            //$ this.MyManager);

            return null;
        }

        protected CdnProfileImpl WrapModel(ProfileInner inner)
        {
            //$ return new CdnProfileImpl(inner.Name(),
            //$ inner,
            //$ this.InnerCollection,
            //$ this.endpointsClient,
            //$ this.originsClient,
            //$ this.customDomainsClient,
            //$ this.MyManager);

            return null;
        }

        public void PurgeEndpointContent(string resourceGroupName, string profileName, string endpointName, IList<string> contentPaths)
        {
            //$ this.cdnManagementClient.Endpoints().PurgeContent(resourceGroupName, profileName, endpointName, contentPaths);

        }
    }
}