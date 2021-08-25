// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.Management.Security.Models;

namespace Microsoft.Azure.Management.Security
{
    
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.Serialization;
    using System.Linq;

    public partial class SecurityCenterClient: ServiceClient<SecurityCenterClient>, ISecurityCenterClient, IAzureClient
    {
        partial void CustomInitialize()
        {
            // ResourceDetails should support both pascal cased 'Source' as well as lowercase 'source'
            var firstDiscriminator = "Source";
            var secondDiscriminator = "source";

            // first remove the converters added by generated code for all of the ResourceDetails types
            DeserializationSettings.Converters.Remove(DeserializationSettings.Converters.FirstOrDefault(c => c.GetType() == typeof(PolymorphicDeserializeJsonConverter<ResourceDetails>)));
            SerializationSettings.Converters.Remove(SerializationSettings.Converters.FirstOrDefault(c => c.GetType() == typeof(PolymorphicSerializeJsonConverter<ResourceDetails>)));

            // now add the correct converters
            DeserializationSettings.Converters.Add(new PolymorphicJsonCustomConverter<ResourceDetails, ResourceDetails>(firstDiscriminator, secondDiscriminator));
            SerializationSettings.Converters.Add(new PolymorphicJsonCustomConverter<ResourceDetails, ResourceDetails>(firstDiscriminator, secondDiscriminator));
        }
    }
}
