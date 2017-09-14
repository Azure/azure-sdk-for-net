// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.PowerBIEmbedded.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for AccessKeyName.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AccessKeyName
    {
        [EnumMember(Value = "key1")]
        Key1,
        [EnumMember(Value = "key2")]
        Key2
    }
}
