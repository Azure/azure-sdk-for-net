// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.TrafficManager.Fluent
{
    using Management.TrafficManager.Fluent;
    using Management.TrafficManager.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Implementation for TrafficManagerNestedProfileEndpoint.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnRyYWZmaWNtYW5hZ2VyLmltcGxlbWVudGF0aW9uLlRyYWZmaWNNYW5hZ2VyTmVzdGVkUHJvZmlsZUVuZHBvaW50SW1wbA==
    internal partial class TrafficManagerNestedProfileEndpointImpl  :
        TrafficManagerEndpointImpl,
        ITrafficManagerNestedProfileEndpoint
    {

        ///GENMHASH:FE4BD2ACA7E297312697D10EB6E88C35:F1D888A0B0ADA9B0BB01B024FD2C692B
        public Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region SourceTrafficLocation()
        {
            return Region.Create(Inner.EndpointLocation);
        }

        ///GENMHASH:ED2AE24D8510FB354BA31316B335750F:2682BD2661D3A018D6E09706819D354F
        internal  TrafficManagerNestedProfileEndpointImpl(string name, TrafficManagerProfileImpl parent, EndpointInner inner) : base(name, parent, inner)
        {
        }

        ///GENMHASH:AE37BAC5F19AB659638F1E713178B1BD:973D938738DE9E8778E1E82F3F5CC564
        public int MinimumChildEndpointCount()
        {
            if (Inner.MinChildEndpoints == null) {
                return 0;
            }
            return (int) Inner.MinChildEndpoints.Value;
        }

        ///GENMHASH:1E025F6B638523DB9CF4695094FC6419:A01C5FFE224D1492FE3A3B71BFD3B1A1
        public string NestedProfileId()
        {
            return Inner.TargetResourceId;
        }
    }
}
