// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Trafficmanager.Fluent
{
    /// <summary>
    /// Implementation for TrafficManagerAzureEndpoint.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnRyYWZmaWNtYW5hZ2VyLmltcGxlbWVudGF0aW9uLlRyYWZmaWNNYW5hZ2VyQXp1cmVFbmRwb2ludEltcGw=
    internal partial class TrafficManagerAzureEndpointImpl  :
        TrafficManagerEndpointImpl,
        ITrafficManagerAzureEndpoint
    {
        ///GENMHASH:ADDA04C7700D3A4F0C913857C08BC9EB:2682BD2661D3A018D6E09706819D354F
        internal  TrafficManagerAzureEndpointImpl(string name, TrafficManagerProfileImpl parent, EndpointInner inner, EndpointsInner client)
        {
            //$ {
            //$ super(name, parent, inner, client);
            //$ }

        }

        ///GENMHASH:93CA13EA4FD328313051AE12DACC2329:A01C5FFE224D1492FE3A3B71BFD3B1A1
        public string TargetAzureResourceId()
        {
            //$ return Inner.TargetResourceId();

            return null;
        }

        ///GENMHASH:93C902BC902B35473FB3D9995465DF70:2DF9D0FE123AD1B00DD21B7F4652C17A
        public TargetAzureResourceType TargetResourceType()
        {
            //$ return new TargetAzureResourceType(ResourceUtils.ResourceProviderFromResourceId(targetAzureResourceId()),
            //$ ResourceUtils.ResourceTypeFromResourceId(targetAzureResourceId()));

            return null;
        }
    }
}