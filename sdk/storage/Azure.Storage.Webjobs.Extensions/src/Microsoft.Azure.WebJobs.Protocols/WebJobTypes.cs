// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#if PUBLICPROTOCOL
namespace Microsoft.Azure.WebJobs.Protocols
#else
namespace Microsoft.Azure.WebJobs.Host.Protocols
#endif
{
    /// <summary>Represents the WebJob type.</summary>
    [JsonConverter(typeof(StringEnumConverter))]
#if PUBLICPROTOCOL
    public enum WebJobTypes
#else
    internal enum WebJobTypes
#endif
    {
        /// <summary>The WebJob runs when triggered.</summary>
        Triggered,

        /// <summary>The WebJob runs continuously.</summary>
        Continuous
    }
}
