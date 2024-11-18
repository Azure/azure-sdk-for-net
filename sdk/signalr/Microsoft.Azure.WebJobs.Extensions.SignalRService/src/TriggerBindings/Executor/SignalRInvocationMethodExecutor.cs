// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.AspNetCore.SignalR.Protocol;
using Newtonsoft.Json.Linq;
using InvocationMessage = Microsoft.Azure.SignalR.Serverless.Protocols.InvocationMessage;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal class SignalRInvocationMethodExecutor : SignalRMethodExecutor
    {
        public SignalRInvocationMethodExecutor(IRequestResolver resolver, ExecutionContext executionContext) : base(resolver, executionContext)
        {
        }

        public override async Task<HttpResponseMessage> ExecuteAsync(HttpRequestMessage request)
        {
            if (!Resolver.TryGetInvocationContext(request, out var context))
            {
                //TODO: More detailed exception
                throw new SignalRTriggerException();
            }
            var (message, protocol) = await Resolver.GetMessageAsync<InvocationMessage>(request).ConfigureAwait(false);
            AssertConsistency(context, message);
            context.Arguments = message.Arguments;

            // Only when it's an invoke, we need the result from function execution.
            TaskCompletionSource<object> tcs = null;
            if (!string.IsNullOrEmpty(message.InvocationId))
            {
                tcs = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);
            }

            HttpResponseMessage response;
            CompletionMessage completionMessage = null;

            var functionResult = await ExecuteWithAuthAsync(request, ExecutionContext, context, tcs).ConfigureAwait(false);
            if (tcs != null)
            {
                if (!functionResult.Succeeded)
                {
                    var errorMessage = functionResult.Exception?.InnerException?.Message ??
                                       functionResult.Exception?.Message ??
                                       "Method execution failed.";
                    completionMessage = CompletionMessage.WithError(message.InvocationId, errorMessage);
                    response = new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                {
                    var result = await tcs.Task.ConfigureAwait(false);
                    completionMessage = CompletionMessage.WithResult(message.InvocationId, ToSafeSerializationType(result));
                    response = new HttpResponseMessage(HttpStatusCode.OK);
                }
            }
            else
            {
                response = new HttpResponseMessage(HttpStatusCode.OK);
            }

            if (completionMessage != null)
            {
                response.Content = new ByteArrayContent(protocol.GetMessageBytes(completionMessage).ToArray());
            }
            return response;
        }

        private static object ToSafeSerializationType(object result)
        {
            if (result is JToken jtoken)
            {
                return new JTokenWrapper(jtoken);
            }
            else
            {
                return result;
            }
        }

        private static void AssertConsistency(InvocationContext context, InvocationMessage message)
        {
            if (!string.Equals(context.Event, message.Target, StringComparison.OrdinalIgnoreCase))
            {
                // TODO: More detailed exception
                throw new SignalRTriggerException();
            }
        }
    }
}