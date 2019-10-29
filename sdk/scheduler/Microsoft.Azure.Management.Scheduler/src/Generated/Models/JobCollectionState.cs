// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Scheduler.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for JobCollectionState.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum JobCollectionState
    {
        [EnumMember(Value = "Enabled")]
        Enabled,
        [EnumMember(Value = "Disabled")]
        Disabled,
        [EnumMember(Value = "Suspended")]
        Suspended,
        [EnumMember(Value = "Deleted")]
        Deleted
    }
}
