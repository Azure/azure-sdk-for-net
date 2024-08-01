// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OpenAI.TestFramework.Utils;

public static class StringExtensions
{
    public static string EnsureEndsWith(this string value, string suffix, StringComparison comparison = StringComparison.Ordinal)
    {
        if (value == null)
        {
            return null!;
        }

        if (value.EndsWith(suffix, comparison))
        {
            return value;
        }

        return value + suffix;
    }

    public static string EnsureEndsWith(this string value, char suffix, StringComparison comparison = StringComparison.Ordinal)
        => EnsureEndsWith(value, suffix.ToString(), comparison);
}

public static class HeaderExtensions
{
    public static string? GetFirstOrDefault(this PipelineResponseHeaders headers, string name)
    {
        if (headers?.TryGetValues(name, out IEnumerable<string>? values) == true)
        {
            return values?.FirstOrDefault(v => !string.IsNullOrWhiteSpace(v));
        }

        return null;
    }

    public static string? GetFirstOrDefault(this PipelineRequestHeaders headers, string name)
    {
        if (headers?.TryGetValues(name, out IEnumerable<string>? values) == true)
        {
            return values?.FirstOrDefault(v => !string.IsNullOrWhiteSpace(v));
        }

        return null;
    }
}

public static class CollectionExtensions
{
    public static string? JoinOrNull(this IEnumerable<string> values, string separator)
    {
        if (values == null || !values.Any())
        {
            return null;
        }

        return string.Join(separator, values);
    }

    public static TVal? GetValueOrDefault<TKey, TVal>(this Dictionary<TKey, TVal> dict, TKey key) where TKey : notnull
        => GetValueOrDefault((IDictionary<TKey, TVal>)dict, key, default!);

    public static TVal GetValueOrDefault<TKey, TVal>(this Dictionary<TKey, TVal> dict, TKey key, TVal defaultValue) where TKey : notnull
        => GetValueOrDefault((IDictionary<TKey, TVal>)dict, key, defaultValue);

    public static TVal? GetValueOrDefault<TKey, TVal>(this IDictionary<TKey, TVal> dict, TKey key)
        => GetValueOrDefault(dict, key, default!);

    public static TVal GetValueOrDefault<TKey, TVal>(this IDictionary<TKey, TVal> dict, TKey key, TVal defaultValue)
    {
        if (dict?.TryGetValue(key, out TVal? value) == true)
        {
            return value;
        }

        return defaultValue;
    }
}

public static class FileExtensions
{
    public static string GetRelativePath(string relativeTo, string path)
    {
#if NET
        return Path.GetRelativePath(relativeTo, path);
#else
        relativeTo = Path.GetFullPath(relativeTo).EnsureEndsWith(Path.DirectorySeparatorChar);
        path = Path.GetFullPath(path).EnsureEndsWith(Path.DirectorySeparatorChar);

        Uri relativeToUri = new Uri(relativeTo);
        Uri pathUri = new Uri(path);

        if (relativeToUri.Scheme != pathUri.Scheme)
        {
            return path;
        }

        Uri relative = relativeToUri.MakeRelativeUri(pathUri);
        return Uri.UnescapeDataString(relative.ToString())
            .Replace('/', '\\');
#endif
    }
}

public static class JsonExtensions
{
    public static void Serialize<T>(Stream stream, T data, JsonSerializerOptions? options = null)
    {
#if NET
        JsonSerializer.Serialize<T>(stream, data, options);
#else
        using (Utf8JsonWriter writer = new(stream))
        {
            JsonSerializer.Serialize<T>(writer, data, options);
            writer.Flush();
        }
#endif
    }

    public static T? Deserialize<T>(Stream stream, JsonSerializerOptions? options = null)
    {
#if NET
        return JsonSerializer.Deserialize<T>(stream, options);
#else
        // For now let's keep it simple and load entire JSON bytes into memory
        using MemoryStream buffer = new();
        stream.CopyTo(buffer);

        ReadOnlySpan<byte> jsonBytes = buffer.GetBuffer().AsSpan(0, (int)buffer.Length);
        return JsonSerializer.Deserialize<T>(jsonBytes, options);
#endif
    }

    public static JsonSerializerOptions Clone(this JsonSerializerOptions options, Predicate<JsonConverter>? converterFilter = null)
    {
#if NET
        JsonSerializerOptions cloned = new JsonSerializerOptions(options);
        if (converterFilter != null)
        {
            cloned.Converters.Clear();
            foreach (var converter in options.Converters.Where(c => converterFilter(c)))
            {
                cloned.Converters.Add(converter);
            }
        }

        return cloned;
#else
        JsonSerializerOptions clone = new()
        {
            AllowTrailingCommas = options.AllowTrailingCommas,
            DefaultBufferSize = options.DefaultBufferSize,
            DictionaryKeyPolicy = options.DictionaryKeyPolicy,
            Encoder = options.Encoder,
            IgnoreNullValues = options.IgnoreNullValues,
            IgnoreReadOnlyProperties = options.IgnoreReadOnlyProperties,
            MaxDepth = options.MaxDepth,
            PropertyNameCaseInsensitive = options.PropertyNameCaseInsensitive,
            PropertyNamingPolicy = options.PropertyNamingPolicy,
            ReadCommentHandling = options.ReadCommentHandling,
            WriteIndented = options.WriteIndented,
        };

        foreach (var converter in options.Converters.Where(c => converterFilter?.Invoke(c) ?? true))
        {
            clone.Converters.Add(converter);
        }

        return clone;
#endif
    }
}

public static class TypeExtensions
{
    /// <summary>
    /// Determines whether the specified type either implements the open generic type specified,
    /// or inherits from the open generic type specified.
    /// </summary>
    /// <param name="type">The type to inspect.</param>
    /// <param name="openGeneric">The open generic type.</param>
    /// <param name="closedTypeArguments">The arguments of the closed generic type.</param>
    /// <returns>True if the type implements, or inherits, or is a closed version of the open type.</returns>
    [DebuggerStepThrough]
    public static bool IsClosedGenericOf(this Type type, Type openGeneric, out Type[] closedTypeArguments)
    {
        Type? closedType;

        if (openGeneric.IsInterface)
        {
            closedType = type.GetInterfaces()
                .FirstOrDefault(iType => IsAssignableToOpen(iType, openGeneric));
        }
        else
        {
            closedType = null;
            for (Type? current = type; current != null && closedType == null; current = current.BaseType)
            {
                if (IsAssignableToOpen(current, openGeneric))
                {
                    closedType = current;
                }
            }
        }

        closedTypeArguments = closedType?.GetGenericArguments() ?? Array.Empty<Type>();
        return closedType != null;
    }

    /// <summary>
    /// Determines if the type is or inherits from the open generic type.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <param name="openGeneric">The open generic type.</param>
    /// <returns>True if the open generic type could be assigned from the type.</returns>
    [DebuggerStepThrough]
    public static bool IsAssignableToOpen(this Type type, Type openGeneric)
    {
        if (!type.IsGenericType || !type.IsConstructedGenericType)
        {
            return false;
        }

        return openGeneric.IsAssignableFrom(type.GetGenericTypeDefinition());
    }
}
