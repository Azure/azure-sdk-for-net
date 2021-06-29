// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Runtime.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Azure.Messaging.WebPubSub
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MessageDataType
    {
        [EnumMember(Value = "binary")]
        Binary,
        [EnumMember(Value = "json")]
        Json,
        [EnumMember(Value = "text")]
        Text
    }
}
