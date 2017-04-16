// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Dns.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for OperationStatus.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OperationStatus
    {
        [EnumMember(Value = "InProgress")]
        InProgress,
        [EnumMember(Value = "Succeeded")]
        Succeeded,
        [EnumMember(Value = "Failed")]
        Failed
    }
}
