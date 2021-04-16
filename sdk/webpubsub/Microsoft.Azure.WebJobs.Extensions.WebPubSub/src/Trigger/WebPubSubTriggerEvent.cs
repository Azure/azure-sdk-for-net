// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal class WebPubSubTriggerEvent
    {
        /// <summary>
        /// Web PubSub common request context from cloud event headers.
        /// </summary>
        public ConnectionContext ConnectionContext { get; set; }

        public WebPubSubMessage Message { get; set; }

        public MessageDataType DataType { get; set; }

        public string[] Subprotocols { get; set; }

        public IDictionary<string, string[]> Claims { get; set; }

        public IDictionary<string, string[]> Query { get; set; }

        public ClientCertificateInfo[] ClientCertificaties { get; set; }

        public string Reason { get; set; }

        /// <summary>
        /// A TaskCompletionSource will set result when the function invocation has finished.
        /// </summary>
        public TaskCompletionSource<object> TaskCompletionSource { get; set; }
    }
}
