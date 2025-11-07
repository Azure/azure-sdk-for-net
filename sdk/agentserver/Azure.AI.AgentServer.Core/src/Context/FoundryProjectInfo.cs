// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Globalization;

namespace Azure.AI.AgentServer.Core.Context;

/// <summary>
/// Represents Azure AI Foundry project information including account and project identifiers.
/// </summary>
/// <param name="Account">The Foundry account identifier.</param>
/// <param name="Project">The Foundry project identifier.</param>
[TypeConverter(typeof(FoundryProjectInfoConverter))]
public record FoundryProjectInfo(string Account, string Project)
{
    /// <summary>
    /// Gets the project endpoint URI.
    /// </summary>
    public Uri ProjectEndpoint { get; } = new Uri($"https://{Account}.services.ai.azure.com/api/projects/{Project}");

    /// <summary>
    /// Parses a Foundry project string into a <see cref="FoundryProjectInfo"/> instance.
    /// </summary>
    /// <param name="foundryProject">The project string in the format "account@project".</param>
    /// <returns>A <see cref="FoundryProjectInfo"/> instance, or null if the input is null or whitespace.</returns>
    /// <exception cref="ArgumentException">Thrown when the project string format is invalid.</exception>
    public static FoundryProjectInfo? Parse(string? foundryProject)
    {
        if (string.IsNullOrWhiteSpace(foundryProject))
        {
            return null;
        }

        var lastPart = foundryProject.Split('/').Last();
        var parts = lastPart.Split('@');
        if (parts.Length < 2)
        {
            throw new ArgumentException($"Invalid foundry project format: {foundryProject}");
        }

        return new FoundryProjectInfo(parts[0], parts[1]);
    }
}

/// <summary>
/// Type converter for <see cref="FoundryProjectInfo"/> to support conversion from string.
/// </summary>
public sealed class FoundryProjectInfoConverter : TypeConverter
{
    /// <summary>
    /// Determines whether this converter can convert from the specified source type.
    /// </summary>
    /// <param name="context">The type descriptor context.</param>
    /// <param name="sourceType">The source type.</param>
    /// <returns>True if conversion from the source type is supported; otherwise, false.</returns>
    public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
        => sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);

    /// <summary>
    /// Converts the specified value to a <see cref="FoundryProjectInfo"/> instance.
    /// </summary>
    /// <param name="context">The type descriptor context.</param>
    /// <param name="culture">The culture information.</param>
    /// <param name="value">The value to convert.</param>
    /// <returns>A <see cref="FoundryProjectInfo"/> instance if the value is a string; otherwise, null.</returns>
    public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
        => value is string s ? FoundryProjectInfo.Parse(s) : null;
}
