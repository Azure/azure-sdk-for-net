// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Azure.AI.AgentServer.Invocations.Internal;

/// <summary>
/// Cached <see cref="MethodInfo"/> lookup for detecting whether a concrete
/// <see cref="InvocationHandler"/> subclass overrides
/// <see cref="InvocationHandler.HandleWebSocketAsync"/>.
/// </summary>
/// <remarks>
/// <para>Matches the Python side's lazy <c>WebSocketRoute</c> registration:
/// when the handler does not implement the WS protocol, the endpoint
/// short-circuits to HTTP 404, so a client attempting a WebSocket upgrade
/// receives the same "endpoint not registered" signal it would on the
/// Python host.</para>
/// <para>The lookup is cached per <see cref="Type"/> so the reflection
/// cost is paid once per handler type, not per request.</para>
/// </remarks>
internal static class InvocationHandlerCapabilities
{
    private const string HandleWebSocketAsyncMethodName = nameof(InvocationHandler.HandleWebSocketAsync);

    private static readonly ConcurrentDictionary<Type, bool> WebSocketOverrideCache = new();

    /// <summary>
    /// Returns <see langword="true"/> when <paramref name="handlerType"/>
    /// overrides <see cref="InvocationHandler.HandleWebSocketAsync"/>.
    /// </summary>
    /// <param name="handlerType">The concrete handler subclass.</param>
    [UnconditionalSuppressMessage(
        "Trimming",
        "IL2070:'this' argument does not satisfy 'DynamicallyAccessedMembersAttribute' in call to target method. The parameter of method does not have matching annotations.",
        Justification = "Method is declared on the well-known InvocationHandler base type, which is preserved.")]
    public static bool SupportsWebSocket(Type handlerType)
    {
        ArgumentNullException.ThrowIfNull(handlerType);
        return WebSocketOverrideCache.GetOrAdd(handlerType, IsWebSocketMethodOverridden);
    }

    [UnconditionalSuppressMessage(
        "Trimming",
        "IL2070:'this' argument does not satisfy 'DynamicallyAccessedMembersAttribute' in call to target method. The parameter of method does not have matching annotations.",
        Justification = "Method is declared on the well-known InvocationHandler base type, which is preserved.")]
    private static bool IsWebSocketMethodOverridden(Type handlerType)
    {
        // Use Public | Instance binding because the base method is public.
        // GetMethod's `types` parameter constrains overload resolution and
        // makes the lookup robust against future overloads.
        var method = handlerType.GetMethod(
            HandleWebSocketAsyncMethodName,
            BindingFlags.Public | BindingFlags.Instance,
            binder: null,
            types: WebSocketMethodSignature,
            modifiers: null);

        return method is not null
            && method.DeclaringType != typeof(InvocationHandler);
    }

    private static readonly Type[] WebSocketMethodSignature =
    [
        typeof(System.Net.WebSockets.WebSocket),
        typeof(InvocationContext),
        typeof(CancellationToken),
    ];
}
