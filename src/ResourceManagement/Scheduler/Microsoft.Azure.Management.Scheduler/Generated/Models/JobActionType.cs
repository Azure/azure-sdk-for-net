// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Scheduler.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for JobActionType.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum JobActionType
    {
        [EnumMember(Value = "Http")]
        Http,
        [EnumMember(Value = "Https")]
        Https,
        [EnumMember(Value = "StorageQueue")]
        StorageQueue,
        [EnumMember(Value = "ServiceBusQueue")]
        ServiceBusQueue,
        [EnumMember(Value = "ServiceBusTopic")]
        ServiceBusTopic
    }
}
