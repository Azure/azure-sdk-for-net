// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
using Microsoft.AspNetCore.Http;

namespace Azure.AI.AgentServer.Invocations.Internal;

internal static class InvocationPlatformContextResolver
{
    public static bool TryFromRequest(HttpContext httpContext, out PlatformContext platformContext)
    {
        try
        {
            platformContext = PlatformContext.FromRequest(httpContext.Request);
            return true;
        }
        catch (FormatException)
        {
            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            httpContext.Response.Headers[PlatformHeaders.ErrorSource] = PlatformHeaders.ErrorSourcePlatform;
            httpContext.Response.Headers[PlatformHeaders.ErrorDetail] = "invalid_original_subject";
            platformContext = PlatformContext.Empty;
            return false;
        }
    }
}
