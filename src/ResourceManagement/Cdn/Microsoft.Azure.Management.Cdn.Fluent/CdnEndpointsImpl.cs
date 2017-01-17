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
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNkbi5pbXBsZW1lbnRhdGlvbi5DZG5FbmRwb2ludHNJbXBs
    internal partial class CdnEndpointsImpl :
        ExternalChildResourcesCached<CdnEndpointImpl,ICdnEndpoint,EndpointInner,ICdnProfile,CdnProfileImpl>
    {
        private IEndpointsOperations client;
        private IOriginsOperations originsClient;
        private ICustomDomainsOperations customDomainsClient;
        ///GENMHASH:6A122C62EB559D6E6E53725061B422FB:8A24BA59C4D80CD9D76FF994C7632585
        protected override IList<Microsoft.Azure.Management.Cdn.Fluent.CdnEndpointImpl> ListChildResources()
        {
            List<CdnEndpointImpl> childResources = new List<CdnEndpointImpl>();

            foreach(var innerEndpoint in this.client.ListByProfile(
                this.Parent.ResourceGroupName,
                this.Parent.Name))
            {
                var endpoint = new CdnEndpointImpl(
                    innerEndpoint.Name,
                    this.Parent,
                    innerEndpoint,
                    this.client,
                    this.originsClient,
                    this.customDomainsClient);

                foreach (var customDomain in this.customDomainsClient.ListByEndpoint(
                    this.Parent.ResourceGroupName, 
                    this.Parent.Name, 
                    innerEndpoint.Name))
                {
                    endpoint.WithCustomDomain(customDomain.HostName);
                }

                childResources.Add(endpoint);
            }
            return childResources;
        }

        /// <summary>
        /// Adds the endpoint to the collection.
        /// </summary>
        /// <param name="endpoint">The endpoint.</param>
        ///GENMHASH:139ABD17A00CA3DF7EF66D0D82CA9A22:31C08CE442572994D91AB64D5DB46CB3
        public void AddEndpoint(CdnEndpointImpl endpoint)
        {
            this.AddChildResource(endpoint);
        }

        ///GENMHASH:6D9B76A803AB3F0D6DAD2C2BA4026481:3ED98565E46B42A1EBC01E891B9C218C
        public CdnEndpointImpl DefineNewEndpointWithOriginHostname(string endpointOriginHostname)
        {
            var endpointName = this.GenerateUniqueEndpointName("Endpoint");
            CdnEndpointImpl endpoint = this.DefineNewEndpoint(endpointName, "origin", endpointOriginHostname);
            return endpoint;
        }

        /// <return>The azure endpoints as a map indexed by name.</return>
        ///GENMHASH:B9E22CF70550E9F6850854C8E614BD8A:0B2B1F221703C7AE9B8FCB1CA33B02DE
        internal IReadOnlyDictionary<string,Microsoft.Azure.Management.Cdn.Fluent.ICdnEndpoint> EndpointsAsMap()
        {
            var result = new Dictionary<string, ICdnEndpoint>();
            foreach(var entry in this.Collection)
            {
                CdnEndpointImpl endpoint = entry.Value;
                result.Add(entry.Key, endpoint);
            }
            return result;
        }

        ///GENMHASH:1813B9F987B61B140F89FFDE640AC0CA:1DCB4684EDAA093B503026B94DA875BF
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

            if (parent.Id != null)
            {
                this.CacheCollection();
            }
        }

        ///GENMHASH:FCB8E9522304F2D6EDB1D6575D4FD5E5:766A5C37F4DA4720A8BBE728B7C7658C
        private string GenerateUniqueEndpointName(string endpointNamePrefix)
        {
            string endpointName = null;
            CheckNameAvailabilityResult result;

            do
            {
                endpointName = SharedSettings.RandomResourceName(endpointNamePrefix, 50);
                result = this.Parent.CheckEndpointNameAvailability(endpointName);
            } while (!result.NameAvailable);

            return endpointName;
        }

        ///GENMHASH:8E8DA5B84731A2D412247D25A544C502:5A9014B901131DE511752BB8941DE4EC
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

        ///GENMHASH:A0B0C406BF96B9B40A3A34687F4E17B2:51E2B88157BC18A1733D263CFDD19D70
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

        ///GENMHASH:391E96CD689B8A8B7D37B118706D13A5:51020309D68A9D47DC901FDD76CC79AA
        public CdnEndpointImpl DefineNewEndpoint(string endpointName, string endpointOriginHostname)
        {
            return this.DefineNewEndpoint(endpointName, "origin", endpointOriginHostname);
        }

        ///GENMHASH:9754CC4582FF9A2DB0A7695F48B2CEF6:BC2FC9D337780BCFC4B1E4C417B868E4
        public CdnEndpointImpl DefineNewEndpoint(string name)
        {
            CdnEndpointImpl endpoint = this.PrepareDefine(name);
            endpoint.Inner.Location = endpoint.Parent.Region.ToString();
            endpoint.Inner.Origins = new List<DeepCreatedOrigin>();
            return endpoint;
        }

        ///GENMHASH:CE727EB6CD3E52051798F68C984D8953:30E10F80821E5E3CFC28422E3B91A8EC
        public CdnEndpointImpl DefineNewEndpoint()
        {
            var endpointName = this.GenerateUniqueEndpointName("Endpoint");
            return this.DefineNewEndpoint(endpointName);
        }

        /// <summary>
        /// Mark the endpoint with given name as to be removed.
        /// </summary>
        /// <param name="name">The name of the endpoint to be removed.</param>
        ///GENMHASH:FC8ECF797E9AF86E82C3899A3D5C00BB:97028F0C4A32755497D72429D22C1125
        public void Remove(string name)
        {
            this.PrepareRemove(name);
        }
    }
}
