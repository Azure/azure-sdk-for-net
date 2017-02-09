// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Scheduler.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for SkuDefinition.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SkuDefinition
    {
        [EnumMember(Value = "Standard")]
        Standard,
        [EnumMember(Value = "Free")]
        Free,
        [EnumMember(Value = "P10Premium")]
        P10Premium,
        [EnumMember(Value = "P20Premium")]
        P20Premium
    }
}
