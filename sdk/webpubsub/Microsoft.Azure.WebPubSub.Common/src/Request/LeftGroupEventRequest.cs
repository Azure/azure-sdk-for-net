// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.Common
{
    /// <summary>
    /// Group presence left event request.
    /// </summary>
    [DataContract]
    public class LeftGroupEventRequest : WebPubSubEventRequest
    {
        internal const string GroupProperty = "group";

        /// <summary>
        /// Group name.
        /// </summary>
        [DataMember(Name = GroupProperty)]
        [JsonPropertyName(GroupProperty)]
        public string Group { get; }

        /// <summary>
        /// The group presence left event request.
        /// </summary>
        /// <param name="context">Connection context.</param>
        /// <param name="group">Group name.</param>
        public LeftGroupEventRequest(WebPubSubConnectionContext context, string group)
            : base(context)
        {
            Group = group;
        }
    }
}
