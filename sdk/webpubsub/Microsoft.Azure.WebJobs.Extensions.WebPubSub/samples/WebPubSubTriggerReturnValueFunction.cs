// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.WebJobs.Extensions.WebPubSub;

namespace Microsoft.Azure.WebJobs.Samples
{
    #region Snippet:WebPubSubTriggerReturnValueFunction
    public static class WebPubSubTriggerReturnValueFunction
    {
        [FunctionName("WebPubSubTriggerReturnValueFunction")]
        public static MessageResponse Run(
            [WebPubSubTrigger("hub", WebPubSubEventType.User, "message")] ConnectionContext context)
        {
            return new MessageResponse
            {
                Message = BinaryData.FromString("ack"),
                DataType = MessageDataType.Text
            };
        }
    }
    #endregion
}
