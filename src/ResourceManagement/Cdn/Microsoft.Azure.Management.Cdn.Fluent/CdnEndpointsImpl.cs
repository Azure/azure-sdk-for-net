// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Cdn.Fluent
{
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;

    /// <summary>
    /// Represents an endpoint collection associated with a CDN manager profile.
    /// </summary>
    public partial class CdnEndpointsImpl  :
        ExternalChildResourcesCached<CdnEndpointImpl,ICdnEndpoint,EndpointInner,ICdnProfile,CdnProfileImpl>
    {
        private IEndpointsOperations client;
        private IOriginsOperations originsClient;
        private ICustomDomainsOperations customDomainsClient;
        protected IList<CdnEndpointImpl> ListChildResources()
        {
            //$ List<CdnEndpointImpl> childResources = new ArrayList<>();
            //$ 
            //$ for (EndpointInner innerEndpoint : this.client.ListByProfile(
            //$ this.Parent().ResourceGroupName(),
            //$ this.Parent().Name())) {
            //$ childResources.Add(new CdnEndpointImpl(innerEndpoint.Name(),
            //$ this.Parent(),
            //$ innerEndpoint,
            //$ this.client,
            //$ this.originsClient,
            //$ this.customDomainsClient));
            //$ }
            //$ return Collections.UnmodifiableList(childResources);

            return null;
        }

        /// <summary>
        /// Adds the endpoint to the collection.
        /// </summary>
        /// <param name="endpoint">The endpoint.</param>
        public void AddEndpoint(CdnEndpointImpl endpoint)
        {
            //$ this.AddChildResource(endpoint);
            //$ }

        }

        public CdnEndpointImpl DefineNewEndpointWithOriginHostname(string endpointOriginHostname)
        {
            //$ String endpointName = this.GenerateUniqueEndpointName("Endpoint");
            //$ CdnEndpointImpl endpoint = this.DefineNewEndpoint(endpointName, "origin", endpointOriginHostname);
            //$ return endpoint;
            //$ }

            return null;
        }

        /// <return>The azure endpoints as a map indexed by name.</return>
        internal IReadOnlyDictionary<string,ICdnEndpoint> EndpointsAsMap()
        {
            //$ Map<String, CdnEndpoint> result = new HashMap<>();
            //$ for (Map.Entry<String, CdnEndpointImpl> entry : this.Collection().EntrySet()) {
            //$ CdnEndpointImpl endpoint = entry.GetValue();
            //$ result.Put(entry.GetKey(), endpoint);
            //$ }
            //$ return Collections.UnmodifiableMap(result);
            //$ }

            return null;
        }

        public CdnEndpointImpl UpdateEndpoint(string name)
        {
            //$ CdnEndpointImpl endpoint = this.PrepareUpdate(name);
            //$ return endpoint;
            //$ }

            return null;
        }

        internal  CdnEndpointsImpl(IEndpointsOperations client, IOriginsOperations originsClient, ICustomDomainsOperations customDomainsClient, CdnProfileImpl parent) 
            : base(parent, "Endpoint")
        {
            //$ {
            //$ super(parent, "Endpoint");
            //$ this.client = client;
            //$ this.originsClient = originsClient;
            //$ this.customDomainsClient = customDomainsClient;
            //$ }

        }

        private string GenerateUniqueEndpointName(string endpointNamePrefix)
        {
            //$ String endpointName;
            //$ CheckNameAvailabilityResult result;
            //$ 
            //$ do {
            //$ endpointName = ResourceNamer.RandomResourceName(endpointNamePrefix, 50);
            //$ 
            //$ result = this.Parent().CheckEndpointNameAvailability(endpointName);
            //$ 
            //$ } while (!result.NameAvailable());
            //$ 
            //$ return endpointName;
            //$ }

            return null;
        }

        protected CdnEndpointImpl NewChildResource(string name)
        {
            //$ CdnEndpointImpl endpoint = new CdnEndpointImpl(name,
            //$ this.Parent(),
            //$ new EndpointInner(),
            //$ this.client,
            //$ this.originsClient,
            //$ this.customDomainsClient);
            //$ 
            //$ return endpoint;

            return null;
        }

        public CdnEndpointImpl DefineNewEndpoint(string endpointName, string originName, string endpointOriginHostname)
        {
            //$ CdnEndpointImpl endpoint = this.DefineNewEndpoint(endpointName);
            //$ endpoint.Inner.Origins().Add(
            //$ new DeepCreatedOrigin()
            //$ .WithName(originName)
            //$ .WithHostName(endpointOriginHostname));
            //$ return endpoint;
            //$ }

            return null;
        }

        public CdnEndpointImpl DefineNewEndpoint(string endpointName, string endpointOriginHostname)
        {
            //$ return this.DefineNewEndpoint(endpointName, "origin", endpointOriginHostname);
            //$ }

            return null;
        }

        public CdnEndpointImpl DefineNewEndpoint(string name)
        {
            //$ CdnEndpointImpl endpoint = this.PrepareDefine(name);
            //$ endpoint.Inner.WithLocation(endpoint.Parent().Region().ToString());
            //$ endpoint.Inner.WithOrigins(new ArrayList<DeepCreatedOrigin>());
            //$ return endpoint;
            //$ }

            return null;
        }

        public CdnEndpointImpl DefineNewEndpoint()
        {
            //$ String endpointName = this.GenerateUniqueEndpointName("Endpoint");
            //$ return this.DefineNewEndpoint(endpointName);
            //$ }

            return null;
        }

        /// <summary>
        /// Mark the endpoint with given name as to be removed.
        /// </summary>
        /// <param name="name">The name of the endpoint to be removed.</param>
        public void Remove(string name)
        {
            //$ this.PrepareRemove(name);
            //$ }

        }
    }
}