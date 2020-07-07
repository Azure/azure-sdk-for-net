// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Newtonsoft.Json;

#if PUBLICPROTOCOL
namespace Microsoft.Azure.WebJobs.Protocols
#else
namespace Microsoft.Azure.WebJobs.Host.Protocols
#endif
{
    /// <summary>Represents a message to any instance of a host.</summary>
    [JsonConverter(typeof(HostMessageConverter))]
#if PUBLICPROTOCOL
    public class HostMessage
#else
    internal class HostMessage
#endif
    {
        /// <summary>Gets or set the message type.</summary>
        public string Type { get; set; }

        private class HostMessageConverter : PolymorphicJsonConverter
        {
            public HostMessageConverter()
                : base("Type", PolymorphicJsonConverter.GetTypeMapping<HostMessage>())
            {
            }
        }
    }
}
