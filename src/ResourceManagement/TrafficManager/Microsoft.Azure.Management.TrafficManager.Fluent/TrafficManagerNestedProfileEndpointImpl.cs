// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Trafficmanager.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// Implementation for TrafficManagerNestedProfileEndpoint.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnRyYWZmaWNtYW5hZ2VyLmltcGxlbWVudGF0aW9uLlRyYWZmaWNNYW5hZ2VyTmVzdGVkUHJvZmlsZUVuZHBvaW50SW1wbA==
    internal partial class TrafficManagerNestedProfileEndpointImpl  :
        TrafficManagerEndpointImpl,
        ITrafficManagerNestedProfileEndpoint
    {
        ///GENMHASH:FE4BD2ACA7E297312697D10EB6E88C35:F1D888A0B0ADA9B0BB01B024FD2C692B
        public Region SourceTrafficLocation()
        {
            //$ return Region.FromName((Inner.EndpointLocation()));

            return null;
        }

        ///GENMHASH:ED2AE24D8510FB354BA31316B335750F:2682BD2661D3A018D6E09706819D354F
        internal  TrafficManagerNestedProfileEndpointImpl(string name, TrafficManagerProfileImpl parent, EndpointInner inner, EndpointsInner client)
        {
            //$ {
            //$ super(name, parent, inner, client);
            //$ }

        }

        ///GENMHASH:AE37BAC5F19AB659638F1E713178B1BD:5FA4034CCC6BEA402A8572B453BEA4BD
        public int MinimumChildEndpointCount()
        {
            //$ if (Inner.MinChildEndpoints() == null) {
            //$ return 0;
            //$ }
            //$ return Inner.MinChildEndpoints().IntValue();

            return 0;
        }

        ///GENMHASH:1E025F6B638523DB9CF4695094FC6419:A01C5FFE224D1492FE3A3B71BFD3B1A1
        public string NestedProfileId()
        {
            //$ return Inner.TargetResourceId();

            return null;
        }
    }
}