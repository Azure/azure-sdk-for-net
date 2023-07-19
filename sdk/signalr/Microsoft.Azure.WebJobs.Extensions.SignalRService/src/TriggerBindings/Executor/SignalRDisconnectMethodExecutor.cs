// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.Azure.SignalR.Serverless.Protocols;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal class SignalRDisconnectMethodExecutor : SignalRMethodExecutor
    {
        public SignalRDisconnectMethodExecutor(IRequestResolver resolver, ExecutionContext executionContext) : base(resolver, executionContext)
        {
        }

        public override async Task<HttpResponseMessage> ExecuteAsync(HttpRequestMessage request)
        {
            if (!Resolver.TryGetInvocationContext(request, out var context))
            {
                //TODO: More detailed exception
                throw new SignalRTriggerException();
            }
            var (message, _) = await Resolver.GetMessageAsync<CloseConnectionMessage>(request).ConfigureAwait(false);
            context.Error = message.Error;

            await ExecuteWithAuthAsync(request, ExecutionContext, context).ConfigureAwait(false);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}