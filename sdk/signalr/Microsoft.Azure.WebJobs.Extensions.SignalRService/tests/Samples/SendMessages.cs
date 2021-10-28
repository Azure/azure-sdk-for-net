// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService.Tests.Samples
{
    public static class SendMessages
    {
        #region Snippet:SendMessageWithReturnValueBinding
        [FunctionName("sendOneMessageWithReturnValueBinding")]
        [return: SignalR(HubName = "<hub_name>")]
        public static SignalRMessage SendMessage(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req)
        {
            return new SignalRMessage
            {
                Target = "<target>",
                Arguments = new[] { "<here_can_be_multiple_objects>" }
            };
        }
        #endregion

        #region Snippet:SendMessageWithOutParameterBinding
        [FunctionName("messages")]
        public static void SendMessage(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req, [SignalR(HubName = "<hub_name>")] out SignalRMessage message)
        {
            message = new SignalRMessage
            {
                Target = "<target>",
                Arguments = new[] { "<here_can_be_multiple_objects>" }
            };
        }
        #endregion

        #region  Snippet:SendMessageWithAsyncCollector
        [FunctionName("messages")]
        public static Task SendMessage(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req,
            [SignalR(HubName = "<hub_name>")] IAsyncCollector<SignalRMessage> signalRMessages)
        {
            return signalRMessages.AddAsync(
            new SignalRMessage
            {
                Target = "<target>",
                Arguments = new[] { "<here_can_be_multiple_objects>" }
            });
        }
        #endregion

        #region Snippet:SendMessageToUser
        [FunctionName("messages")]
        [return: SignalR(HubName = "<hub_name>")]
        public static SignalRMessage SendMessageToUser(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req)
        {
            return new SignalRMessage
            {
                UserId = "<user_id>",
                Target = "<target>",
                Arguments = new[] { "<here_can_be_multiple_objects>" }
            };
        }
        #endregion
    }
}