// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.Fluent.Dns.Models
{
    /// <summary>
    /// Defines values for OperationStatus.
    /// </summary>
    [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum OperationStatus
    {
        [System.Runtime.Serialization.EnumMember(Value = "InProgress")]
        IN_PROGRESS,
        [System.Runtime.Serialization.EnumMember(Value = "Succeeded")]
        SUCCEEDED,
        [System.Runtime.Serialization.EnumMember(Value = "Failed")]
        FAILED
    }
}
