// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace SampleApp;

public static class WebPubSubOutputFunction
{
    [Function("Notification")]
    [WebPubSubOutput(Hub = "notification")]
    public static WebPubSubAction Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
    {
        return new SendToAllAction
        {
            Data = BinaryData.FromString($"Hello SendToAll."),
            DataType = WebPubSubDataType.Text
        };
    }

    [Function("Notification1")]
    public static MultipleActions MultipleActions([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
    {
        return new MultipleActions
        {
            SendToAll = new SendToAllAction
            {
                Data = BinaryData.FromString($"Hello SendToAll."),
                DataType = WebPubSubDataType.Text
            },
            AddUserToGroup = new AddUserToGroupAction
            {
                UserId = "user A",
                Group = "group A"
            }
        };
    }
}

public class MultipleActions
{
    [WebPubSubOutput(Hub = "notification")]
    public SendToAllAction SendToAll { get; set; }
    [WebPubSubOutput(Hub = "notification")]
    public AddUserToGroupAction AddUserToGroup { get; set; }
}
