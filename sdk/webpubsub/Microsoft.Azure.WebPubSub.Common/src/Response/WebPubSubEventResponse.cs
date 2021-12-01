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
        ///
        /// </summary>
        [DataMember(Name = "code")]
        public WebPubSubStatusCode StatusCode { get; set; }
    }
}
