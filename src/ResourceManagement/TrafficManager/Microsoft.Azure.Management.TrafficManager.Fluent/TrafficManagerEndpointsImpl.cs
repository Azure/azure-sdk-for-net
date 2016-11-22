// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Trafficmanager.Fluent
{
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// Represents an endpoint collection associated with a traffic manager profile.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnRyYWZmaWNtYW5hZ2VyLmltcGxlbWVudGF0aW9uLlRyYWZmaWNNYW5hZ2VyRW5kcG9pbnRzSW1wbA==
    internal partial class TrafficManagerEndpointsImpl  :
        ExternalChildResourcesCachedImpl<TrafficManagerEndpointImpl,ITrafficManagerEndpoint,EndpointInner,TrafficManagerProfileImpl,ITrafficManagerProfile>
    {
        private EndpointsInner client;
        /// <summary>
        /// Adds the endpoint to the collection.
        /// </summary>
        /// <param name="endpoint">The endpoint.</param>
        ///GENMHASH:8CB67A1B3CF8E6894B88F02B1AE365EC:31C08CE442572994D91AB64D5DB46CB3
        public void AddEndpoint(TrafficManagerEndpointImpl endpoint)
        {
            //$ this.AddChildResource(endpoint);
            //$ }

        }

        /// <return>The nested profile endpoints as a map indexed by name.</return>
        ///GENMHASH:B49B27ECF031E10A22023E6336E734E5:CE6855352C0CC1F5B88859811F7E2029
        internal IReadOnlyDictionary<string,ITrafficManagerNestedProfileEndpoint> NestedProfileEndpointsAsMap()
        {
            //$ Map<String, TrafficManagerNestedProfileEndpoint> result = new HashMap<>();
            //$ for (Map.Entry<String, TrafficManagerEndpointImpl> entry : this.Collection().EntrySet()) {
            //$ TrafficManagerEndpointImpl endpoint = entry.GetValue();
            //$ if (endpoint.EndpointType() == EndpointType.NESTED_PROFILE) {
            //$ TrafficManagerNestedProfileEndpoint nestedProfileEndpoint = new TrafficManagerNestedProfileEndpointImpl(entry.GetKey(),
            //$ this.Parent(),
            //$ endpoint.Inner,
            //$ this.client);
            //$ result.Put(entry.GetKey(), nestedProfileEndpoint);
            //$ }
            //$ }
            //$ return Collections.UnmodifiableMap(result);
            //$ }

            return null;
        }

        /// <summary>
        /// Mark the endpoint with given name as to be removed.
        /// </summary>
        /// <param name="name">The name of the endpoint to be removed.</param>
        ///GENMHASH:FC8ECF797E9AF86E82C3899A3D5C00BB:97028F0C4A32755497D72429D22C1125
        public void Remove(string name)
        {
            //$ this.PrepareRemove(name);
            //$ }

        }

        /// <return>The external endpoints as a map indexed by name.</return>
        ///GENMHASH:9E9CCBF47923D34FC60535C1BF252975:241C2E97F7493232FD204964162A4C4D
        internal IReadOnlyDictionary<string,ITrafficManagerExternalEndpoint> ExternalEndpointsAsMap()
        {
            //$ Map<String, TrafficManagerExternalEndpoint> result = new HashMap<>();
            //$ for (Map.Entry<String, TrafficManagerEndpointImpl> entry : this.Collection().EntrySet()) {
            //$ TrafficManagerEndpointImpl endpoint = entry.GetValue();
            //$ if (endpoint.EndpointType() == EndpointType.EXTERNAL) {
            //$ TrafficManagerExternalEndpoint externalEndpoint = new TrafficManagerExternalEndpointImpl(entry.GetKey(),
            //$ this.Parent(),
            //$ endpoint.Inner,
            //$ this.client);
            //$ result.Put(entry.GetKey(), externalEndpoint);
            //$ }
            //$ }
            //$ return Collections.UnmodifiableMap(result);
            //$ }

            return null;
        }

        ///GENMHASH:6A122C62EB559D6E6E53725061B422FB:E362A504788CC2639B19EB2A280DC22C
        protected IList<TrafficManagerEndpointImpl> ListChildResources()
        {
            //$ List<TrafficManagerEndpointImpl> childResources = new ArrayList<>();
            //$ if (parent().Inner.Endpoints() != null) {
            //$ foreach(var inner in parent().Inner.Endpoints())  {
            //$ childResources.Add(new TrafficManagerEndpointImpl(inner.Name(),
            //$ this.Parent(),
            //$ inner,
            //$ this.client));
            //$ }
            //$ }
            //$ return childResources;

            return null;
        }

        /// <return>The azure endpoints as a map indexed by name.</return>
        ///GENMHASH:6ADF0039F06A892E8F3B1C405F538F3C:9442957E47473D025199992BF235E603
        internal IReadOnlyDictionary<string,ITrafficManagerAzureEndpoint> AzureEndpointsAsMap()
        {
            //$ Map<String, TrafficManagerAzureEndpoint> result = new HashMap<>();
            //$ for (Map.Entry<String, TrafficManagerEndpointImpl> entry : this.Collection().EntrySet()) {
            //$ TrafficManagerEndpointImpl endpoint = entry.GetValue();
            //$ if (endpoint.EndpointType() == EndpointType.AZURE) {
            //$ TrafficManagerAzureEndpoint azureEndpoint = new TrafficManagerAzureEndpointImpl(entry.GetKey(),
            //$ this.Parent(),
            //$ endpoint.Inner,
            //$ this.client);
            //$ result.Put(entry.GetKey(), azureEndpoint);
            //$ }
            //$ }
            //$ return Collections.UnmodifiableMap(result);
            //$ }

            return null;
        }

        /// <summary>
        /// Starts an external endpoint update chain.
        /// </summary>
        /// <param name="name">The name of the endpoint to be updated.</param>
        /// <return>The endpoint.</return>
        ///GENMHASH:DCEFD84C43018F459854BC29B1935412:461635A9A465B4AC37C1544F187F8CCB
        public TrafficManagerEndpointImpl UpdateExternalEndpoint(string name)
        {
            //$ TrafficManagerEndpointImpl endpoint = this.PrepareUpdate(name);
            //$ if (endpoint.EndpointType() != EndpointType.EXTERNAL) {
            //$ throw new IllegalArgumentException("An external endpoint with name " + name + " not found in the profile");
            //$ }
            //$ return endpoint;
            //$ }

            return null;
        }

        /// <summary>
        /// Creates new EndpointsImpl.
        /// </summary>
        /// <param name="client">The client to perform REST calls on endpoints.</param>
        /// <param name="parent">The parent traffic manager profile of the endpoints.</param>
        ///GENMHASH:4D0E5B9E7FAF82899EC6E6B3762A42CE:86647EE6A7C92249B46A6C7B4A2F9A64
        internal  TrafficManagerEndpointsImpl(EndpointsInner client, TrafficManagerProfileImpl parent)
        {
            //$ super(parent, "Endpoint");
            //$ this.client = client;
            //$ this.CacheCollection();
            //$ }

        }

        /// <summary>
        /// Starts an nested profile endpoint definition chain.
        /// </summary>
        /// <param name="name">The name of the endpoint to be added.</param>
        /// <return>The endpoint.</return>
        ///GENMHASH:E299B5EC44792111DF66BBF20E5DD793:3D2F0EDDDDF7C14C2BD25AD76310C6D0
        public TrafficManagerEndpointImpl DefineNestedProfileTargetEndpoint(string name)
        {
            //$ TrafficManagerEndpointImpl endpoint = this.PrepareDefine(name);
            //$ endpoint.Inner.WithType(EndpointType.NESTED_PROFILE.ToString());
            //$ return endpoint;
            //$ }

            return null;
        }

        /// <summary>
        /// Starts an external endpoint definition chain.
        /// </summary>
        /// <param name="name">The name of the endpoint to be added.</param>
        /// <return>The endpoint.</return>
        ///GENMHASH:92CB7AA7AD787F0DF94966625C981BF2:21E3F1E2671256798F0DEB88891E678D
        public TrafficManagerEndpointImpl DefineExteralTargetEndpoint(string name)
        {
            //$ TrafficManagerEndpointImpl endpoint = this.PrepareDefine(name);
            //$ endpoint.Inner.WithType(EndpointType.EXTERNAL.ToString());
            //$ return endpoint;
            //$ }

            return null;
        }

        /// <summary>
        /// Starts an azure endpoint update chain.
        /// </summary>
        /// <param name="name">The name of the endpoint to be updated.</param>
        /// <return>The endpoint.</return>
        ///GENMHASH:24E62EC73B5276BE1A4C9512125E5F24:567851E04A4537D499D352E5C6B37E4D
        public TrafficManagerEndpointImpl UpdateAzureEndpoint(string name)
        {
            //$ TrafficManagerEndpointImpl endpoint = this.PrepareUpdate(name);
            //$ if (endpoint.EndpointType() != EndpointType.AZURE) {
            //$ throw new IllegalArgumentException("An azure endpoint with name " + name + " not found in the profile");
            //$ }
            //$ return endpoint;
            //$ }

            return null;
        }

        ///GENMHASH:8E8DA5B84731A2D412247D25A544C502:37DC546F8DB33DF63F6C1EF339D32991
        protected TrafficManagerEndpointImpl NewChildResource(string name)
        {
            //$ TrafficManagerEndpointImpl endpoint = new TrafficManagerEndpointImpl(name,
            //$ this.Parent(),
            //$ new EndpointInner().WithName(name),
            //$ this.client);
            //$ return endpoint
            //$ .WithRoutingWeight(1)
            //$ .WithTrafficEnabled();

            return null;
        }

        /// <summary>
        /// Starts an Azure endpoint definition chain.
        /// </summary>
        /// <param name="name">The name of the endpoint to be added.</param>
        /// <return>The endpoint.</return>
        ///GENMHASH:A912B64DAA5D27988A4E605BC2374EEA:7E23814F3155E7732156E4EB5E17C0BC
        public TrafficManagerEndpointImpl DefineAzureTargetEndpoint(string name)
        {
            //$ TrafficManagerEndpointImpl endpoint = this.PrepareDefine(name);
            //$ endpoint.Inner.WithType(EndpointType.AZURE.ToString());
            //$ return endpoint;
            //$ }

            return null;
        }

        /// <summary>
        /// Starts a nested profile endpoint update chain.
        /// </summary>
        /// <param name="name">The name of the endpoint to be updated.</param>
        /// <return>The endpoint.</return>
        ///GENMHASH:7D642A8E2F1E22246EC9157C176A5B30:C705D303B24BFD0020C12D616A005882
        public TrafficManagerEndpointImpl UpdateNestedProfileEndpoint(string name)
        {
            //$ TrafficManagerEndpointImpl endpoint = this.PrepareUpdate(name);
            //$ if (endpoint.EndpointType() != EndpointType.NESTED_PROFILE) {
            //$ throw new IllegalArgumentException("A nested profile endpoint with name " + name + " not found in the profile");
            //$ }
            //$ return endpoint;
            //$ }

            return null;
        }
    }
}