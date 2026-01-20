// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core.Tools.Models;
using Azure.AI.AgentServer.Core.Tools.Runtime.User;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Azure.AI.AgentServer.Core.Server.Middleware;

/// <summary>
/// Middleware that resolves user information from HTTP headers and stores it in AsyncLocal storage.
/// This makes user context available throughout the async request flow.
/// </summary>
public class UserInfoContextMiddleware
{
    private readonly RequestDelegate _next;
    private readonly Func<HttpContext, Task<UserInfo?>> _userResolver;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserInfoContextMiddleware"/> class.
    /// </summary>
    /// <param name="next">The next middleware in the pipeline.</param>
    /// <param name="userResolver">
    /// Optional custom user resolver function. If not provided, uses the default header-based resolver
    /// that extracts user info from x-aml-oid and x-aml-tid headers.
    /// </param>
    public UserInfoContextMiddleware(
        RequestDelegate next,
        Func<HttpContext, Task<UserInfo?>>? userResolver = null)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
        _userResolver = userResolver ?? DefaultUserResolver;
    }

    /// <summary>
    /// Invokes the middleware to resolve and set user context.
    /// </summary>
    /// <param name="httpContext">The HTTP context.</param>
    public async Task InvokeAsync(HttpContext httpContext)
    {
        // Resolve user information
        var user = await _userResolver(httpContext).ConfigureAwait(false);

        // Set user in AsyncLocal storage for the duration of this request
        await using var userScope = AsyncLocalUserProvider.SetUser(user).ConfigureAwait(false);

        // Continue to next middleware
        await _next(httpContext).ConfigureAwait(false);
    }

    /// <summary>
    /// Default user resolver that extracts user information from HTTP headers.
    /// </summary>
    private static Task<UserInfo?> DefaultUserResolver(HttpContext context)
    {
        var user = UserResolvers.ResolveFromHeaders(context.Request.Headers);
        return Task.FromResult(user);
    }
}

/// <summary>
/// Extension methods for registering user info context middleware.
/// </summary>
public static class UserInfoContextMiddlewareExtensions
{
    /// <summary>
    /// Adds the user info context middleware to the application pipeline.
    /// </summary>
    /// <param name="app">The application builder.</param>
    /// <param name="userResolver">
    /// Optional custom user resolver function. If not provided, uses the default header-based resolver.
    /// </param>
    /// <returns>The application builder for chaining.</returns>
    public static IApplicationBuilder UseUserInfoContext(
        this IApplicationBuilder app,
        Func<HttpContext, Task<UserInfo?>>? userResolver = null)
    {
        return userResolver == null
            ? app.UseMiddleware<UserInfoContextMiddleware>()
            : app.UseMiddleware<UserInfoContextMiddleware>(userResolver);
    }
}
