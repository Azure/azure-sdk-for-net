// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Azure.AI.AgentServer.A2A.Internal;

internal sealed class A2ATransportResult(Func<ValueTask<object?>> next) : IResult
{
    public async Task ExecuteAsync(HttpContext httpContext)
    {
        httpContext.Response.OnStarting(() =>
        {
            var response = httpContext.Response;
            if (response.StatusCode >= 400 && !response.Headers.ContainsKey(PlatformHeaders.ErrorSource))
            {
                response.Headers[PlatformHeaders.ErrorSource] = response.StatusCode < 500
                    ? PlatformHeaders.ErrorSourceUser
                    : PlatformHeaders.ErrorSourceUpstream;
            }

            return Task.CompletedTask;
        });

        try
        {
            var result = await next().ConfigureAwait(false);
            if (result is not IResult httpResult)
            {
                throw new InvalidOperationException("The native A2A endpoint did not return an HTTP result.");
            }

            await httpResult.ExecuteAsync(httpContext).ConfigureAwait(false);
        }
        catch (OperationCanceledException) when (httpContext.RequestAborted.IsCancellationRequested)
        {
            throw;
        }
        catch (BadHttpRequestException exception) when (!httpContext.Response.HasStarted)
        {
            httpContext.RequestServices.GetRequiredService<ILogger<A2ATransportResult>>()
                .LogWarning(exception, "Invalid HTTP request in A2A transport");
            httpContext.Response.StatusCode = exception.StatusCode;
            httpContext.Response.Headers[PlatformHeaders.ErrorSource] = PlatformHeaders.ErrorSourceUser;
            await httpContext.Response.WriteAsJsonAsync(
                new { detail = "Invalid HTTP request" }, httpContext.RequestAborted).ConfigureAwait(false);
        }
        catch (Exception exception) when (!httpContext.Response.HasStarted)
        {
            var logger = httpContext.RequestServices.GetRequiredService<ILogger<A2ATransportResult>>();
            logger.LogError(exception, "Unhandled A2A transport failure");
            bool platform = exception.Data["Azure.AI.AgentServer.PlatformError"] is true;
            httpContext.Response.Headers[PlatformHeaders.ErrorSource] = platform
                ? PlatformHeaders.ErrorSourcePlatform
                : PlatformHeaders.ErrorSourceUpstream;
            if (platform)
            {
                var detail = $"{exception.GetType().Name}: {exception.Message}";
                httpContext.Response.Headers[PlatformHeaders.ErrorDetail] =
                    new string(detail.Where(c => c >= ' ' && c <= '~').Take(2048).ToArray());
            }

            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await httpContext.Response.WriteAsJsonAsync(
                new { detail = "Internal server error" }, httpContext.RequestAborted).ConfigureAwait(false);
        }
    }
}
