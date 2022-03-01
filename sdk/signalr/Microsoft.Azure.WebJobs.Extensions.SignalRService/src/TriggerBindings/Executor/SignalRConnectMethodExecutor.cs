// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal class SignalRConnectMethodExecutor : SignalRMethodExecutor
    {
        public SignalRConnectMethodExecutor(IRequestResolver resolver, ExecutionContext executionContext) : base(resolver, executionContext)
        {
        }

        public override async Task<HttpResponseMessage> ExecuteAsync(HttpRequestMessage request)
        {
            if (!Resolver.TryGetInvocationContext(request, out var context))
            {
                //TODO: More detailed exception
                throw new SignalRTriggerException();
            }

            var result = await ExecuteWithAuthAsync(request, ExecutionContext, context).ConfigureAwait(false);
            if (!result.Succeeded)
            {
                return new HttpResponseMessage(HttpStatusCode.Forbidden);
            }
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}