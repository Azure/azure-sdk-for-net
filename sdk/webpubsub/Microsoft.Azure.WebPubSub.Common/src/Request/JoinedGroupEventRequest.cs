// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebPubSub.Common
{
    /// <summary>
    /// Group presence joined event request.
    /// </summary>
    [DataContract]
    public class JoinedGroupEventRequest : WebPubSubEventRequest
    {
        internal const string GroupProperty = "group";

        /// <summary>
        /// Group name.
        /// </summary>
        [DataMember(Name = GroupProperty)]
        [JsonPropertyName(GroupProperty)]
        public string Group { get; }

        /// <summary>
        /// The group presence joined event request.
        /// </summary>
        /// <param name="context">Connection context.</param>
        /// <param name="group">Group name.</param>
        public JoinedGroupEventRequest(WebPubSubConnectionContext context, string group)
            : base(context)
        {
            Group = group;
        }
    }
}
