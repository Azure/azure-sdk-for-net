// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace SampleApp;

public static class WebPubSubOutputFunction
{
    #region Snippet:WebPubSubOutputFunction
    [Function("Notification")]
    [WebPubSubOutput(Hub = "<web_pubsub_hub>", Connection = "<web_pubsub_connection_name>")]
    public static WebPubSubAction Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
    {
        return new SendToAllAction
        {
            Data = BinaryData.FromString($"Hello SendToAll."),
            DataType = WebPubSubDataType.Text
        };
    }
    #endregion

    #region Snippet:WebPubSubOutputFunction_Multiple
    // multiple output
    [Function("Notification1")]
    [WebPubSubOutput(Hub = "<web_pubsub_hub>", Connection = "<web_pubsub_connection_name>")]
    public static WebPubSubAction[] MultipleActions([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
    {
        return new WebPubSubAction[]
        {
            new SendToAllAction
            {
                Data = BinaryData.FromString($"Hello SendToAll."),
                DataType = WebPubSubDataType.Text
            },
            new AddUserToGroupAction
            {
                UserId = "user A",
                Group = "group A"
            }
        };
    }
    #endregion
}