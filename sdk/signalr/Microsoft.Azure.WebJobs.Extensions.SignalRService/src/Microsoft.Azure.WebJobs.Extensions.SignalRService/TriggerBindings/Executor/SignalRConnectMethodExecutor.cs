// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

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

            var result = await ExecuteWithAuthAsync(request, ExecutionContext, context);
            if (!result.Succeeded)
            {
                return new HttpResponseMessage(HttpStatusCode.Forbidden);
            }
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}