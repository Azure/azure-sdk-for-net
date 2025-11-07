// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Azure.AI.AgentServer.Core.Common.Http.Json;

/// <summary>
/// Provides extension methods for JSON serialization and deserialization.
/// </summary>
[SuppressMessage("Usage", "AZC0014:Avoid using banned types in public API")]
public static class JsonExtensions
{
    /// <summary>
    /// Gets the default JSON serializer options used throughout the application.
    /// </summary>
    public static readonly JsonSerializerOptions DefaultJsonSerializerOptions = GetDefaultJsonSerializerOptions();

    /// <summary>
    /// Gets the JSON serializer options from the HTTP context.
    /// </summary>
    /// <param name="ctx">The HTTP context.</param>
    /// <returns>The JSON serializer options configured for the context.</returns>
    public static JsonSerializerOptions GetJsonSerializerOptions(this HttpContext ctx)
    {
        // Prefer Minimal API (Http.Json) options if present
        var httpJson = ctx.RequestServices.GetService(typeof(IOptions<Microsoft.AspNetCore.Http.Json.JsonOptions>));
        if (httpJson is IOptions<Microsoft.AspNetCore.Http.Json.JsonOptions> httpJsonOptions)
        {
            return httpJsonOptions.Value.SerializerOptions;
        }

        // Fallback to MVC options (if you’re inside MVC)
        var mvcJson = ctx.RequestServices.GetService(typeof(IOptions<Microsoft.AspNetCore.Mvc.JsonOptions>));
        if (mvcJson is IOptions<Microsoft.AspNetCore.Mvc.JsonOptions> mvcJsonOptions)
        {
            return mvcJsonOptions.Value.JsonSerializerOptions;
        }

        return GetDefaultJsonSerializerOptions();
    }

    /// <summary>
    /// Gets the default JSON serializer options with web defaults and custom converters.
    /// </summary>
    /// <returns>A configured <see cref="JsonSerializerOptions"/> instance.</returns>
    public static JsonSerializerOptions GetDefaultJsonSerializerOptions()
    {
        var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
        options.Converters.Add(new JsonModelConverter());
        return options;
    }

    /// <summary>
    /// Converts binary data to an object of the specified type using JSON deserialization.
    /// </summary>
    /// <typeparam name="T">The type to deserialize to.</typeparam>
    /// <param name="data">The binary data to deserialize.</param>
    /// <param name="options">Optional JSON serializer options. If null, uses default options.</param>
    /// <returns>The deserialized object, or null if deserialization fails.</returns>
    public static T? ToObject<T>(this BinaryData data, JsonSerializerOptions? options = null) where T : class
    {
        options ??= DefaultJsonSerializerOptions;

        try
        {
            return data.ToObjectFromJson<T>(options);
        }
        catch (JsonException)
        {
            return null;
        }
    }
}
