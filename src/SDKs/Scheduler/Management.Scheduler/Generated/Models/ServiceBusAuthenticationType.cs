// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Scheduler.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for ServiceBusAuthenticationType.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ServiceBusAuthenticationType
    {
        [EnumMember(Value = "NotSpecified")]
        NotSpecified,
        [EnumMember(Value = "SharedAccessKey")]
        SharedAccessKey
    }
}
