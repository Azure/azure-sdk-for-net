// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Developer.Playwright;

/// <summary>
/// Represents the connect options for a generic type.
/// </summary>
/// <typeparam name="T">The type parameter.</typeparam>
/// <remarks>
/// Initializes a new instance of the <see cref="ConnectOptions{T}"/> class.
/// </remarks>
/// <param name="WsEndpoint"></param>
/// <param name="Options"></param>
public class ConnectOptions<T>(string WsEndpoint, T Options) where T : class, new()
{
    /// <summary>
    /// A browser websocket endpoint to connect to.
    /// </summary>
    public string WsEndpoint { get; set; } = WsEndpoint;
    /// <summary>
    /// Connect options for the service.
    /// </summary>
    public T Options { get; set; } = Options;
}

internal class BrowserConnectOptions
{
    public string? ExposeNetwork { get; set; }
    public IEnumerable<KeyValuePair<string, string>>? Headers { get; set; }
    public float? SlowMo { get; set; }
    public float? Timeout { get; set; }
}

internal static class BrowserConnectOptionsConverter
{
    public static T Convert<T>(object source) where T : class, new()
    {
        var target = new T();
        System.Type sourceType = source.GetType();
        System.Type targetType = typeof(T);

        foreach (System.Reflection.PropertyInfo? sourceProperty in sourceType.GetProperties())
        {
            System.Reflection.PropertyInfo? targetProperty = targetType.GetProperty(sourceProperty.Name);
            if (targetProperty != null && targetProperty.CanWrite)
            {
                targetProperty.SetValue(target, sourceProperty.GetValue(source));
            }
        }

        return target;
    }
}
