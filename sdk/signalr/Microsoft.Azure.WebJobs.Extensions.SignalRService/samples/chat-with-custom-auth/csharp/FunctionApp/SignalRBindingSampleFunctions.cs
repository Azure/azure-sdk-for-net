// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService.Samples
{
    public static class SignalRBindingSampleFunctions
    {
        [FunctionName("negotiate")]
        public static Task<HttpResponseMessage> GetSignalRInfo(
            [HttpTrigger(AuthorizationLevel.Anonymous)] HttpRequestMessage req,
            [SecurityTokenValidation] SecurityTokenResult tokenResult,
            [SignalRConnectionInfo(HubName = Constants.HubName)] SignalRConnectionInfo connectionInfo)
        {
            return tokenResult.Status == SecurityTokenStatus.Valid
                ? Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = JsonContent.Create(connectionInfo) })
                : Task.FromResult(new HttpResponseMessage(HttpStatusCode.Unauthorized) { Content = new StringContent($"Validation result: {tokenResult.Status.ToString()}; Message: {tokenResult.Exception?.Message}") });
        }

        [FunctionName("messages")]
        public static async Task<HttpResponseMessage> SendMessage(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")]HttpRequestMessage req,
            [SecurityTokenValidation] SecurityTokenResult tokenResult,
            [SignalR(HubName = Constants.HubName)]IAsyncCollector<SignalRMessage> signalRMessages)
        {
            if (!PassTokenValidation(req, tokenResult, out var unauthorizedActionResult, out var isAdmin))
            {
                return unauthorizedActionResult;
            }

            var message = new JsonSerializer().Deserialize<ChatMessage>(new JsonTextReader(new StreamReader(await req.Content.ReadAsStreamAsync())));

            // prevent broadcast on non-administrator caller
            if (!isAdmin && message.Recipient == null && message.GroupName == null)
            {
                return req.CreateErrorResponse(HttpStatusCode.Forbidden, "Non administrator cannot broadcast messages");
            }

            return await BuildResponseAsync(req, signalRMessages.AddAsync(
                new SignalRMessage
                {
                    UserId = message.Recipient,
                    GroupName = message.GroupName,
                    Target = "newMessage",
                    Arguments = new[] { message }
                }));
        }

        [FunctionName("addToGroup")]
        public static async Task<HttpResponseMessage> AddToGroup(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")]HttpRequestMessage req,
            [SecurityTokenValidation] SecurityTokenResult tokenResult,
            [SignalR(HubName = Constants.HubName)]IAsyncCollector<SignalRGroupAction> signalRGroupActions)
        {
            if (!PassTokenValidation(req, tokenResult, out var unauthorizedActionResult, out _))
            {
                return unauthorizedActionResult;
            }

            var message = new JsonSerializer().Deserialize<ChatMessage>(new JsonTextReader(new StreamReader(await req.Content.ReadAsStreamAsync())));

            var decodedfConnectionId = GetBase64DecodedString(message.ConnectionId);

            return await BuildResponseAsync(req, signalRGroupActions.AddAsync(
                new SignalRGroupAction
                {
                    ConnectionId = decodedfConnectionId,
                    UserId = message.Recipient,
                    GroupName = message.GroupName,
                    Action = GroupAction.Add
                }));
        }

        [FunctionName("removeFromGroup")]
        public static async Task<HttpResponseMessage> RemoveFromGroup(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")]HttpRequestMessage req,
            [SecurityTokenValidation] SecurityTokenResult tokenResult,
            [SignalR(HubName = Constants.HubName)]IAsyncCollector<SignalRGroupAction> signalRGroupActions)
        {
            if (!PassTokenValidation(req, tokenResult, out var unauthorizedActionResult, out _))
            {
                return unauthorizedActionResult;
            }
            var message = new JsonSerializer().Deserialize<ChatMessage>(new JsonTextReader(new StreamReader(await req.Content.ReadAsStreamAsync())));

            return await BuildResponseAsync(req, signalRGroupActions.AddAsync(
                new SignalRGroupAction
                {
                    ConnectionId = message.ConnectionId,
                    UserId = message.Recipient,
                    GroupName = message.GroupName,
                    Action = GroupAction.Remove
                }));
        }

        private static string GetBase64DecodedString(string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                return source;
            }

            return Encoding.UTF8.GetString(Convert.FromBase64String(source));
        }

        private static bool PassTokenValidation(HttpRequestMessage req, SecurityTokenResult securityTokenResult, out HttpResponseMessage unauthorizedActionResult, out bool isAdmin)
        {
            isAdmin = false;

            if (securityTokenResult.Status != SecurityTokenStatus.Valid)
            {
                // failed to pass auth check
                unauthorizedActionResult =
                    req.CreateErrorResponse(HttpStatusCode.Unauthorized, securityTokenResult.Exception.Message);
                return false;
            }

            unauthorizedActionResult = null;
            foreach (var claim in securityTokenResult.Principal.Claims)
            {
                if (claim.Type == "admin")
                {
                    isAdmin = Boolean.Parse(claim.Value);
                }
            }

            return true;
        }

        private static async Task<HttpResponseMessage> BuildResponseAsync(HttpRequestMessage req, Task task)
        {
            try
            {
                await task;
            }
            catch (Exception ex)
            {
                return req.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return req.CreateResponse(HttpStatusCode.Accepted);
        }

        public static class Constants
        {
            public const string HubName = "simplechat";
        }

        public class ChatMessage
        {
            public string Sender { get; set; }
            public string Text { get; set; }
            public string GroupName { get; set; }
            public string Recipient { get; set; }
            public string ConnectionId { get; set; }
            public bool IsPrivate { get; set; }
        }
    }
}
