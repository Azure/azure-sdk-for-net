// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Cdn.Fluent
{
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;
    using Resource.Fluent;

    /// <summary>
    /// Represents an endpoint collection associated with a CDN manager profile.
    /// </summary>
    public partial class CdnEndpointsImpl  :
        ExternalChildResourcesCached<CdnEndpointImpl,ICdnEndpoint,EndpointInner,ICdnProfile,CdnProfileImpl>
    {
        private IEndpointsOperations client;
        private IOriginsOperations originsClient;
        private ICustomDomainsOperations customDomainsClient;

        protected override IList<CdnEndpointImpl> ListChildResources()
        {
            List<CdnEndpointImpl> childResources = new List<CdnEndpointImpl>();

            foreach(var innerEndpoint in this.client.ListByProfile(
                this.Parent.ResourceGroupName,
                this.Parent.Name))
                {
                    childResources.Add(new CdnEndpointImpl(
                        innerEndpoint.Name,
                        this.Parent,
                        innerEndpoint,
                        this.client,
                        this.originsClient,
                        this.customDomainsClient));
            }
            return childResources;
        }

        /// <summary>
        /// Adds the endpoint to the collection.
        /// </summary>
        /// <param name="endpoint">The endpoint.</param>
        public void AddEndpoint(CdnEndpointImpl endpoint)
        {
            this.AddChildResource(endpoint);
        }

        public CdnEndpointImpl DefineNewEndpointWithOriginHostname(string endpointOriginHostname)
        {
            var endpointName = this.GenerateUniqueEndpointName("Endpoint");
            CdnEndpointImpl endpoint = this.DefineNewEndpoint(endpointName, "origin", endpointOriginHostname);
            return endpoint;
        }

        /// <return>The azure endpoints as a map indexed by name.</return>
        internal IReadOnlyDictionary<string,ICdnEndpoint> EndpointsAsMap()
        {
            var result = new Dictionary<string, ICdnEndpoint>();
            foreach(var entry in this.Collection)
            {
                CdnEndpointImpl endpoint = entry.Value;
                result.Add(entry.Key, endpoint);
            }
            return result;
        }

        public CdnEndpointImpl UpdateEndpoint(string name)
        {
            return this.PrepareUpdate(name);
        }

        internal  CdnEndpointsImpl(
            IEndpointsOperations client, 
            IOriginsOperations originsClient, 
            ICustomDomainsOperations customDomainsClient, 
            CdnProfileImpl parent) 
            : base(parent, "Endpoint")
        {
            this.client = client;
            this.originsClient = originsClient;
            this.customDomainsClient = customDomainsClient;
        }

        private string GenerateUniqueEndpointName(string endpointNamePrefix)
        {
            string endpointName = null;
            CheckNameAvailabilityResult result;

            do
            {
                endpointName = ResourceNamer.RandomResourceName(endpointNamePrefix, 50);
                result = this.Parent.CheckEndpointNameAvailability(endpointName);
            } while (!result.NameAvailable);

            return endpointName;
        }

        protected override CdnEndpointImpl NewChildResource(string name)
        {
            return new CdnEndpointImpl(
                name,
                this.Parent,
                new EndpointInner(),
                this.client,
                this.originsClient,
                this.customDomainsClient);
        }

        public CdnEndpointImpl DefineNewEndpoint(string endpointName, string originName, string endpointOriginHostname)
        {
            CdnEndpointImpl endpoint = this.DefineNewEndpoint(endpointName);
            endpoint.Inner.Origins.Add(
                new DeepCreatedOrigin
                {
                    Name = originName,
                    HostName = endpointOriginHostname
                });
            return endpoint;
        }

        public CdnEndpointImpl DefineNewEndpoint(string endpointName, string endpointOriginHostname)
        {
            return this.DefineNewEndpoint(endpointName, "origin", endpointOriginHostname);
        }

        public CdnEndpointImpl DefineNewEndpoint(string name)
        {
            CdnEndpointImpl endpoint = this.PrepareDefine(name);
            endpoint.Inner.Location = endpoint.Parent.Region.ToString();
            endpoint.Inner.Origins = new List<DeepCreatedOrigin>();
            return endpoint;
        }

        public CdnEndpointImpl DefineNewEndpoint()
        {
            var endpointName = this.GenerateUniqueEndpointName("Endpoint");
            return this.DefineNewEndpoint(endpointName);
        }

        /// <summary>
        /// Mark the endpoint with given name as to be removed.
        /// </summary>
        /// <param name="name">The name of the endpoint to be removed.</param>
        public void Remove(string name)
        {
            this.PrepareRemove(name);
        }
    }
}