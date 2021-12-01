// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.Serialization;

namespace Microsoft.Azure.WebPubSub.Common
{
    /// <summary>
    /// A general type of Web PubSub service response to send to service.
    /// </summary>
    [DataContract]
    public abstract class WebPubSubEventResponse
    {
        /// <summary>
        /// Reserved code for json deserilize to correct derived response.
        /// Set to <see cref="WebPubSubStatusCode.Success"/> as default.
        /// </summary>
        [DataMember(Name = "code")]
        internal WebPubSubStatusCode StatusCode { get; set; } = WebPubSubStatusCode.Success;
    }
}
