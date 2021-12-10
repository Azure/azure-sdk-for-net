// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

namespace Microsoft.Azure.WebPubSub.AspNetCore.Internal
{
    internal class WebPubSubAuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly string _audiance;

        /// <summary>
        /// Authorization middleware
        /// </summary>
        /// <param name="next"></param>
        /// <param name="audience"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public WebPubSubAuthorizationMiddleware(
            RequestDelegate next,
            string audience
            )
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _audiance = audience;
        }

        /// <summary>
        /// Invoke
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            var claims = context.User.Claims;
            foreach (var claim in claims)
            {
                if (claim.Type == "aud" && claim.Value == _audiance)
                {
                    await _next(context).ConfigureAwait(false);
                    return;
                }
            }
            throw new UnauthorizedAccessException("audience mismatch");
        }
    }
}
