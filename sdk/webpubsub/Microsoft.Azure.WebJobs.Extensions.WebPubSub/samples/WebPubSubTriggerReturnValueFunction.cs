// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.WebJobs.Extensions.WebPubSub;
using Microsoft.Azure.WebPubSub.Common;

namespace Microsoft.Azure.WebJobs.Samples
{
    #region Snippet:WebPubSubTriggerReturnValueFunction
    public static class WebPubSubTriggerReturnValueFunction
    {
        [FunctionName("WebPubSubTriggerReturnValueFunction")]
        public static UserEventResponse Run(
            [WebPubSubTrigger("hub", WebPubSubEventType.User, "message")] UserEventRequest request)
        {
            return request.CreateResponse(BinaryData.FromString("ack"), WebPubSubDataType.Text);
        }
    }
    #endregion
}
