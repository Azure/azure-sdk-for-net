// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Invocations.Voice;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.AI.AgentServer.Invocations.Internal;

internal sealed class VoiceRegistrationGuardFilter : IEndpointFilter
{
    private const string VoiceOverrideError =
        "Voice registration was overridden by another InvocationHandler. Voice must remain the only InvocationHandler after AddVoice<THandler>().";

    public ValueTask<object?> InvokeAsync(
        EndpointFilterInvocationContext context,
        EndpointFilterDelegate next)
    {
#pragma warning disable AAAS001 // Detect the experimental Voice type only to reject the wrong registration API.
        var requestServices = context.HttpContext.RequestServices;
        var invocationHandlers = context.Arguments.OfType<InvocationHandler>().Take(2).ToArray();
        if (invocationHandlers.Length == 1)
        {
            var marker = requestServices.GetService<VoiceRegistrationMarker>();
            if (marker is not null)
            {
                if (invocationHandlers[0].GetType() != marker.HandlerType)
                {
                    ThrowRegistrationError(context.HttpContext, VoiceOverrideError);
                }
            }
            else if (invocationHandlers[0] is VoiceHandler)
            {
                ThrowRegistrationError(
                    context.HttpContext,
                    InvocationsBuilderExtensions.VoiceRegistrationError);
            }
        }
#pragma warning restore AAAS001

        return next(context);
    }

    private static void ThrowRegistrationError(HttpContext httpContext, string message)
    {
        var exception = new InvalidOperationException(message);
        exception.Data[InvocationsErrorSourceFilter.PlatformErrorDataKey] = true;
        InvocationsErrorSourceFilter.SetErrorSourceHeaders(
            httpContext,
            PlatformHeaders.ErrorSourcePlatform);
        throw exception;
    }
}
