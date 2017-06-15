// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.TrafficManager.Fluent
{
    /// <summary>
    /// Possible endpoint types supported in a Traffic manager profile.
    /// </summary>
    public class EndpointType : ExpandableStringEnum<EndpointType>
    {
        public static readonly EndpointType Azure = Parse("Microsoft.Network/trafficManagerProfiles/azureEndpoints");
        public static readonly EndpointType External = Parse("Microsoft.Network/trafficManagerProfiles/externalEndpoints");
        public static readonly EndpointType NestedProfile = Parse("Microsoft.Network/trafficManagerProfiles/nestedEndpoints");

        /// <summary>
        /// Gets the local name of the endpoint type.
        /// </summary>
        public string LocalName
        {
            get
            {
                if (Value != null)
                {
                    return Value.Substring(Value.LastIndexOf('/') + 1);
                }
                return null;
            }
        }
    }
}