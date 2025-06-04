// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.WebPubSub.Common;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal class WebPubSubTriggerEvent
    {
        /// <summary>
        /// Web PubSub common request context from cloud event headers.
        /// </summary>
        public WebPubSubConnectionContext ConnectionContext { get; set; }

        public BinaryData Data { get; set; }

        public WebPubSubDataType DataType { get; set; }

        public IReadOnlyList<string> Subprotocols { get; set; }

        public IReadOnlyDictionary<string, string[]> Claims { get; set; }

        public IReadOnlyDictionary<string, string[]> Query { get; set; }

        public IReadOnlyList<WebPubSubClientCertificate> ClientCertificates { get; set; }

        public string Reason { get; set; }

        public WebPubSubEventRequest Request { get; set; }

        /// <summary>
        /// A TaskCompletionSource will set result when the function invocation has finished.
        /// </summary>
        public TaskCompletionSource<object> TaskCompletionSource { get; set; }
    }
}
