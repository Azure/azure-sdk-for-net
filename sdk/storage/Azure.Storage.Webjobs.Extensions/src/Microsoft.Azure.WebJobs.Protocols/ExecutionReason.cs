// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#if PUBLICPROTOCOL
namespace Microsoft.Azure.WebJobs.Protocols
#else
namespace Microsoft.Azure.WebJobs.Host.Protocols
#endif
{
    /// <summary>Defines constants for reasons a function is executed.</summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ExecutionReason
    {
        /// <summary>Indicates a function executed because of an automatic trigger.</summary>
        AutomaticTrigger,

        /// <summary>Indicates a function executed because of a programmatic host call.</summary>
        HostCall,

        /// <summary>Indicates a function executed because of a request from a dashboard user.</summary>
        Dashboard
    }
}
