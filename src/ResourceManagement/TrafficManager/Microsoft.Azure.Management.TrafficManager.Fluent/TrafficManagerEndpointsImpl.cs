// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Trafficmanager.Fluent
{
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using System;
    using Management.TrafficManager.Fluent;
    using Management.TrafficManager.Fluent.Models;

    /// <summary>
    /// Represents an endpoint collection associated with a traffic manager profile.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnRyYWZmaWNtYW5hZ2VyLmltcGxlbWVudGF0aW9uLlRyYWZmaWNNYW5hZ2VyRW5kcG9pbnRzSW1wbA==
    internal partial class TrafficManagerEndpointsImpl  :
        ExternalChildResourcesCached<TrafficManagerEndpointImpl, ITrafficManagerEndpoint,EndpointInner, ITrafficManagerProfile, TrafficManagerProfileImpl>
    {
        private IEndpointsOperations client;
        /// <summary>
        /// Adds the endpoint to the collection.
        /// </summary>
        /// <param name="endpoint">The endpoint.</param>
        ///GENMHASH:8CB67A1B3CF8E6894B88F02B1AE365EC:31C08CE442572994D91AB64D5DB46CB3
        public void AddEndpoint(TrafficManagerEndpointImpl endpoint)
        {
            this.AddChildResource(endpoint);
        }

        /// <return>The nested profile endpoints as a map indexed by name.</return>
        ///GENMHASH:B49B27ECF031E10A22023E6336E734E5:CE6855352C0CC1F5B88859811F7E2029
        internal IReadOnlyDictionary<string,ITrafficManagerNestedProfileEndpoint> NestedProfileEndpointsAsMap()
        {
            Dictionary<string, ITrafficManagerNestedProfileEndpoint> result = new Dictionary<string, ITrafficManagerNestedProfileEndpoint>();
            foreach (var entry in this.Collection) {
                TrafficManagerEndpointImpl endpoint = entry.Value;
                if (endpoint.EndpointType() == EndpointType.NESTED_PROFILE) {
                    ITrafficManagerNestedProfileEndpoint nestedProfileEndpoint = new TrafficManagerNestedProfileEndpointImpl(entry.Key,
                        this.Parent,
                        endpoint.Inner,
                        this.client);
                    result.Add(entry.Key, nestedProfileEndpoint);
                }
            }
            return result;
        }

        /// <summary>
        /// Mark the endpoint with given name as to be removed.
        /// </summary>
        /// <param name="name">The name of the endpoint to be removed.</param>
        ///GENMHASH:FC8ECF797E9AF86E82C3899A3D5C00BB:97028F0C4A32755497D72429D22C1125
        public void Remove(string name)
        {
            base.PrepareRemove(name);
        }

        /// <return>The external endpoints as a map indexed by name.</return>
        ///GENMHASH:9E9CCBF47923D34FC60535C1BF252975:241C2E97F7493232FD204964162A4C4D
        internal IReadOnlyDictionary<string,ITrafficManagerExternalEndpoint> ExternalEndpointsAsMap()
        {
            Dictionary<string, ITrafficManagerExternalEndpoint> result = new Dictionary<string, ITrafficManagerExternalEndpoint>();
            foreach (var entry in this.Collection)
            {
                TrafficManagerEndpointImpl endpoint = entry.Value;
                if (endpoint.EndpointType() == EndpointType.EXTERNAL)
                {
                    ITrafficManagerExternalEndpoint externalEndpoint = new TrafficManagerExternalEndpointImpl(entry.Key,
                        this.Parent,
                        endpoint.Inner,
                        this.client);
                    result.Add(entry.Key, externalEndpoint);
                }
            }
            return result;
        }

        ///GENMHASH:6A122C62EB559D6E6E53725061B422FB:E362A504788CC2639B19EB2A280DC22C
        protected override IList<TrafficManagerEndpointImpl> ListChildResources()
        {
            List<TrafficManagerEndpointImpl> childResources = new List<TrafficManagerEndpointImpl>();
            if (Parent.Inner.Endpoints != null) {
                foreach(var inner in Parent.Inner.Endpoints)  {
                    childResources.Add(new TrafficManagerEndpointImpl(inner.Name,
                        this.Parent,
                        inner,
                        this.client));
                }
            }
            return childResources;
        }

        /// <return>The azure endpoints as a map indexed by name.</return>
        ///GENMHASH:6ADF0039F06A892E8F3B1C405F538F3C:9442957E47473D025199992BF235E603
        internal IReadOnlyDictionary<string,ITrafficManagerAzureEndpoint> AzureEndpointsAsMap()
        {
            Dictionary<string, ITrafficManagerAzureEndpoint> result = new Dictionary<string, ITrafficManagerAzureEndpoint>();
            foreach (var entry in this.Collection)
            {
                TrafficManagerEndpointImpl endpoint = entry.Value;
                if (endpoint.EndpointType() == EndpointType.AZURE)
                {
                    ITrafficManagerAzureEndpoint azureEndpoint = new TrafficManagerAzureEndpointImpl(entry.Key,
                        this.Parent,
                        endpoint.Inner,
                        this.client);
                    result.Add(entry.Key, azureEndpoint);
                }
            }
            return result;
        }

        /// <summary>
        /// Starts an external endpoint update chain.
        /// </summary>
        /// <param name="name">The name of the endpoint to be updated.</param>
        /// <return>The endpoint.</return>
        ///GENMHASH:DCEFD84C43018F459854BC29B1935412:461635A9A465B4AC37C1544F187F8CCB
        public TrafficManagerEndpointImpl UpdateExternalEndpoint(string name)
        {
            TrafficManagerEndpointImpl endpoint = base.PrepareUpdate(name);
            if (endpoint.EndpointType() != EndpointType.EXTERNAL) {
                throw new ArgumentException($"An external endpoint with name {name} not found in the profile");
            }
            return endpoint;
        }

        /// <summary>
        /// Creates new EndpointsImpl.
        /// </summary>
        /// <param name="client">The client to perform REST calls on endpoints.</param>
        /// <param name="parent">The parent traffic manager profile of the endpoints.</param>
        ///GENMHASH:4D0E5B9E7FAF82899EC6E6B3762A42CE:86647EE6A7C92249B46A6C7B4A2F9A64
        internal  TrafficManagerEndpointsImpl(IEndpointsOperations client, TrafficManagerProfileImpl parent) : base(parent, "Endpoint")
        {
            this.client = client;
            this.CacheCollection();
        }

        /// <summary>
        /// Starts an nested profile endpoint definition chain.
        /// </summary>
        /// <param name="name">The name of the endpoint to be added.</param>
        /// <return>The endpoint.</return>
        ///GENMHASH:E299B5EC44792111DF66BBF20E5DD793:3D2F0EDDDDF7C14C2BD25AD76310C6D0
        public TrafficManagerEndpointImpl DefineNestedProfileTargetEndpoint(string name)
        {
            TrafficManagerEndpointImpl endpoint = base.PrepareDefine(name);
            endpoint.Inner.Type = EndpointType.NESTED_PROFILE.ToString();
            return endpoint;
        }

        /// <summary>
        /// Starts an external endpoint definition chain.
        /// </summary>
        /// <param name="name">The name of the endpoint to be added.</param>
        /// <return>The endpoint.</return>
        ///GENMHASH:92CB7AA7AD787F0DF94966625C981BF2:21E3F1E2671256798F0DEB88891E678D
        public TrafficManagerEndpointImpl DefineExteralTargetEndpoint(string name)
        {
            TrafficManagerEndpointImpl endpoint = base.PrepareDefine(name);
            endpoint.Inner.Type = EndpointType.EXTERNAL.ToString();
            return endpoint;
        }

        /// <summary>
        /// Starts an azure endpoint update chain.
        /// </summary>
        /// <param name="name">The name of the endpoint to be updated.</param>
        /// <return>The endpoint.</return>
        ///GENMHASH:24E62EC73B5276BE1A4C9512125E5F24:567851E04A4537D499D352E5C6B37E4D
        public TrafficManagerEndpointImpl UpdateAzureEndpoint(string name)
        {
            TrafficManagerEndpointImpl endpoint = base.PrepareUpdate(name);
            if (endpoint.EndpointType() != EndpointType.AZURE) {
                throw new ArgumentException($"An azure endpoint with name { name } not found in the profile");
            }
            return endpoint;
        }

        ///GENMHASH:8E8DA5B84731A2D412247D25A544C502:37DC546F8DB33DF63F6C1EF339D32991
        protected override TrafficManagerEndpointImpl NewChildResource(string name)
        {
            TrafficManagerEndpointImpl endpoint = new TrafficManagerEndpointImpl(name,
                this.Parent, new EndpointInner { Name = name }, this.client);
            return endpoint
                .WithRoutingWeight(1)
                .WithTrafficEnabled();
        }

        /// <summary>
        /// Starts an Azure endpoint definition chain.
        /// </summary>
        /// <param name="name">The name of the endpoint to be added.</param>
        /// <return>The endpoint.</return>
        ///GENMHASH:A912B64DAA5D27988A4E605BC2374EEA:7E23814F3155E7732156E4EB5E17C0BC
        public TrafficManagerEndpointImpl DefineAzureTargetEndpoint(string name)
        {
            TrafficManagerEndpointImpl endpoint = base.PrepareDefine(name);
            endpoint.Inner.Type = EndpointType.AZURE.ToString();
            return endpoint;
        }

        /// <summary>
        /// Starts a nested profile endpoint update chain.
        /// </summary>
        /// <param name="name">The name of the endpoint to be updated.</param>
        /// <return>The endpoint.</return>
        ///GENMHASH:7D642A8E2F1E22246EC9157C176A5B30:C705D303B24BFD0020C12D616A005882
        public TrafficManagerEndpointImpl UpdateNestedProfileEndpoint(string name)
        {
            TrafficManagerEndpointImpl endpoint = base.PrepareUpdate(name);
            if (endpoint.EndpointType() != EndpointType.NESTED_PROFILE) {
                throw new ArgumentException($"A nested profile endpoint with name { name } not found in the profile");
            }
            return endpoint;
        }
    }
}