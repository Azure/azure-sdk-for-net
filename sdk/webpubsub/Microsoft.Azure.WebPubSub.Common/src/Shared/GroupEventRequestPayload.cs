// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.Common
{
    [DataContract]
    internal class GroupEventRequestPayload
    {
        internal const string GroupProperty = "group";

        [DataMember(Name = GroupProperty)]
        [JsonPropertyName(GroupProperty)]
        public string Group { get; set; }
    }
}
