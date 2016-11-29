// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Trafficmanager.Fluent
{
    using Management.TrafficManager.Fluent;
    using Management.TrafficManager.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// Implementation for  TrafficManagerExternalEndpoint.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnRyYWZmaWNtYW5hZ2VyLmltcGxlbWVudGF0aW9uLlRyYWZmaWNNYW5hZ2VyRXh0ZXJuYWxFbmRwb2ludEltcGw=
    internal partial class TrafficManagerExternalEndpointImpl  :
        TrafficManagerEndpointImpl,
        ITrafficManagerExternalEndpoint
    {
        ///GENMHASH:FE4BD2ACA7E297312697D10EB6E88C35:F1D888A0B0ADA9B0BB01B024FD2C692B
        public Region SourceTrafficLocation()
        {
            return Region.Create(Inner.EndpointLocation);
        }

        ///GENMHASH:577F8437932AEC6E08E1A137969BDB4A:3CC692393857371CADD3A0EF3687C595
        public string Fqdn()
        {
            return Inner.Target;
        }

        ///GENMHASH:3D7D84BE9718103D55B181E59FCB60F7:2682BD2661D3A018D6E09706819D354F
        internal  TrafficManagerExternalEndpointImpl(string name, TrafficManagerProfileImpl parent, EndpointInner inner, IEndpointsOperations client) : base(name, parent, inner, client)
        {
        }
    }
}