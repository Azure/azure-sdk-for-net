// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Diagnostics;

namespace OpenAI.TestFramework.Utils;

/// <summary>
/// String related extension methods.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Ensures that a string ends with a specified suffix.
    /// </summary>
    /// <param name="value">The string value.</param>
    /// <param name="suffix">The suffix to check for.</param>
    /// <param name="comparison">The string comparison type. Default is <see cref="StringComparison.Ordinal"/>.</param>
    /// <returns>The original string if it ended in the suffix, or a new string value with the suffix appended.</returns>
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

    /// <summary>
    /// Ensures that a string ends with a specified suffix.
    /// </summary>
    /// <param name="value">The string value.</param>
    /// <param name="suffix">The suffix to check for.</param>
    /// <param name="comparison">The string comparison type. Default is <see cref="StringComparison.Ordinal"/>.</param>
    /// <returns>The original string if it ended in the suffix, or a new string value with the suffix appended.</returns>
    public static string EnsureEndsWith(this string value, char suffix, StringComparison comparison = StringComparison.Ordinal)
        => EnsureEndsWith(value, suffix.ToString(), comparison);
}

/// <summary>
/// Extension methods for <c>System.ClientModel</c> headers.
/// </summary>
public static class HeaderExtensions
{
    /// <summary>
    /// Gets the first value associated with the specified header name from the pipeline request headers.
    /// </summary>
    /// <param name="headers">The pipeline request headers.</param>
    /// <param name="name">The name of the header.</param>
    /// <returns>The first non-empty value associated with the specified header name, or null if the header is not found or has no non-empty values.</returns>
    public static string? GetFirstOrDefault(this PipelineRequestHeaders headers, string name)
    {
        if (headers?.TryGetValues(name, out IEnumerable<string>? values) == true)
        {
            return values?.FirstOrDefault(v => !string.IsNullOrWhiteSpace(v));
        }

        return null;
    }

    /// <summary>
    /// Gets the first value associated with the specified header name from the pipeline response headers.
    /// </summary>
    /// <param name="headers">The pipeline response headers.</param>
    /// <param name="name">The name of the header.</param>
    /// <returns>The first non-empty value associated with the specified header name, or null if the header is not found or has no non-empty values.</returns>
    public static string? GetFirstOrDefault(this PipelineResponseHeaders headers, string name)
    {
        if (headers?.TryGetValues(name, out IEnumerable<string>? values) == true)
        {
            return values?.FirstOrDefault(v => !string.IsNullOrWhiteSpace(v));
        }

        return null;
    }
}

/// <summary>
/// Extensions for collections
/// </summary>
public static class CollectionExtensions
{
    /// <summary>
    /// Joins the elements of a collection into a single string using the specified separator.
    /// Returns null if the collection is null or empty.
    /// </summary>
    /// <param name="values">The collection of strings to join.</param>
    /// <param name="separator">The separator string.</param>
    /// <returns>A string that consists of the elements of the collection joined by the separator, or null if the collection is null or empty.</returns>
    public static string? JoinOrNull(this IEnumerable<string> values, string separator)
    {
        if (values == null || !values.Any())
        {
            return null;
        }

        return string.Join(separator, values);
    }

    /// <summary>
    /// Gets the value associated with the specified key from the dictionary, or returns the default value if the key is not found.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
    /// <typeparam name="TVal">The type of the values in the dictionary.</typeparam>
    /// <param name="dict">The dictionary.</param>
    /// <param name="key">The key to locate.</param>
    /// <returns>The value associated with the specified key, or the default value if the key is not found.</returns>
    public static TVal? GetValueOrDefault<TKey, TVal>(this Dictionary<TKey, TVal> dict, TKey key) where TKey : notnull
        => GetValueOrDefault((IDictionary<TKey, TVal>)dict, key, default!);

    /// <summary>
    /// Gets the value associated with the specified key from the dictionary, or returns the specified default value if the key is not found.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
    /// <typeparam name="TVal">The type of the values in the dictionary.</typeparam>
    /// <param name="dict">The dictionary.</param>
    /// <param name="key">The key to locate.</param>
    /// <param name="defaultValue">The default value to return if the key is not found.</param>
    /// <returns>The value associated with the specified key, or the specified default value if the key is not found.</returns>
    public static TVal GetValueOrDefault<TKey, TVal>(this Dictionary<TKey, TVal> dict, TKey key, TVal defaultValue) where TKey : notnull
        => GetValueOrDefault((IDictionary<TKey, TVal>)dict, key, defaultValue);

    /// <summary>
    /// Gets the value associated with the specified key from the sorted dictionary, or returns the default value if the key is not found.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the sorted dictionary.</typeparam>
    /// <typeparam name="TVal">The type of the values in the sorted dictionary.</typeparam>
    /// <param name="dict">The sorted dictionary.</param>
    /// <param name="key">The key to locate.</param>
    /// <returns>The value associated with the specified key, or the default value if the key is not found.</returns>
    public static TVal? GetValueOrDefault<TKey, TVal>(this SortedDictionary<TKey, TVal> dict, TKey key) where TKey : notnull
        => GetValueOrDefault((IDictionary<TKey, TVal>)dict, key, default!);

    /// <summary>
    /// Gets the value associated with the specified key from the sorted dictionary, or returns the specified default value if the key is not found.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the sorted dictionary.</typeparam>
    /// <typeparam name="TVal">The type of the values in the sorted dictionary.</typeparam>
    /// <param name="dict">The sorted dictionary.</param>
    /// <param name="key">The key to locate.</param>
    /// <param name="defaultValue">The default value to return if the key is not found.</param>
    /// <returns>The value associated with the specified key, or the specified default value if the key is not found.</returns>
    public static TVal GetValueOrDefault<TKey, TVal>(this SortedDictionary<TKey, TVal> dict, TKey key, TVal defaultValue) where TKey : notnull
        => GetValueOrDefault((IDictionary<TKey, TVal>)dict, key, defaultValue);

    /// <summary>
    /// Gets the value associated with the specified key from the dictionary, or returns the default value if the key is not found.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
    /// <typeparam name="TVal">The type of the values in the dictionary.</typeparam>
    /// <param name="dict">The dictionary.</param>
    /// <param name="key">The key to locate.</param>
    /// <returns>The value associated with the specified key, or the default value if the key is not found.</returns>
    public static TVal? GetValueOrDefault<TKey, TVal>(this IDictionary<TKey, TVal> dict, TKey key)
        => GetValueOrDefault(dict, key, default!);

    /// <summary>
    /// Gets the value associated with the specified key from the dictionary, or returns the specified default value if the key is not found.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
    /// <typeparam name="TVal">The type of the values in the dictionary.</typeparam>
    /// <param name="dict">The dictionary.</param>
    /// <param name="key">The key to locate.</param>
    /// <param name="defaultValue">The default value to return if the key is not found.</param>
    /// <returns>The value associated with the specified key, or the specified default value if the key is not found.</returns>
    public static TVal GetValueOrDefault<TKey, TVal>(this IDictionary<TKey, TVal> dict, TKey key, TVal defaultValue)
    {
        if (dict?.TryGetValue(key, out TVal? value) == true)
        {
            return value;
        }

        return defaultValue;
    }
}

/// <summary>
/// Helpers for working with paths.
/// </summary>
public static class PathHelpers
{
    /// <summary>
    /// Create a relative path from one path to another. Paths will be resolved before calculating the difference.
    /// </summary>
    /// <param name="relativeTo">The source path the output should be relative to. This path is always considered to be a directory.</param>
    /// <param name="path">The destination path.</param>
    /// <returns>The relative path or <paramref name="path"/> if the paths don't share the same root.</returns>
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


/// <summary>
/// Extensions for types.
/// </summary>
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
