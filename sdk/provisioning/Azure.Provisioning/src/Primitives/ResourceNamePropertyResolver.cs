// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Resources;

namespace Azure.Provisioning.Primitives;

/// <summary>
/// Classes of characters that are valid for naming a given resource.
/// </summary>
[Flags]
public enum ResourceNameCharacters
{
    /// <summary>
    /// Lowercase letters (a-z).
    /// </summary>
    LowercaseLetters = 1,

    /// <summary>
    /// Uppercase letters (A-Z).
    /// </summary>
    UppercaseLetters = 2,

    /// <summary>
    /// Lower or uppercase letters (a-z, A-Z).
    /// </summary>
    Letters = LowercaseLetters | UppercaseLetters,

    /// <summary>
    /// Numbers (0-9).
    /// </summary>
    Numbers = 4,

    /// <summary>
    /// Alphanumeric characters (a-z, A-Z, 0-9).
    /// </summary>
    Alphanumeric = Letters | Numbers,

    /// <summary>
    /// Hyphens (-).
    /// </summary>
    Hyphen = 8,

    /// <summary>
    /// Underscores (_).
    /// </summary>
    Underscore = 16,

    /// <summary>
    /// Periods (.).
    /// </summary>
    Period = 32,

    /// <summary>
    /// Parentheses ( (, ) ).
    /// </summary>
    Parentheses = 64,
}

/// <summary>
/// Define the requirements to name a resource.
/// </summary>
/// <param name="minLength">The minimum length of the name.</param>
/// <param name="maxLength">The maximum length of the name.</param>
/// <param name="validCharacters">
/// The set of valid characters in the resource name.
/// </param>
public readonly struct ResourceNameRequirements(
    int minLength,
    int maxLength,
    ResourceNameCharacters validCharacters)
{
    /// <summary>
    /// Gets the minimum length of the name.
    /// </summary>
    public int MinLength { get; } = minLength;

    /// <summary>
    /// Gets the maximum length of the name.
    /// </summary>
    public int MaxLength { get; } = maxLength;

    /// <summary>
    /// Gets the set of valid characters in the resource name.
    /// </summary>
    public ResourceNameCharacters ValidCharacters { get; } = validCharacters;
}

/// <summary>
/// Provides a strategy for resolving Azure names using their resource name as
/// a prefix, the set of valid characters, the max length allowed, and an
/// optional min length.
/// </summary>
/// <remarks>
/// You can learn more about Azure's resource naming rules at
/// <see href="https://learn.microsoft.com/azure/azure-resource-manager/management/resource-name-rules">
/// https://learn.microsoft.com/azure/azure-resource-manager/management/resource-name-rules
/// </see>.
/// </remarks>
public abstract class ResourceNamePropertyResolver : InfrastructureResolver
{
    /// <inheritdoc />
    public override void ResolveProperties(ProvisionableConstruct construct, ProvisioningBuildOptions options)
    {
        // We only need to name resources
        if (construct is not ProvisionableResource resource) { return; }

        // We only need to create a name if one doesn't already exist
        if (resource.ProvisionableProperties.TryGetValue("Name", out IBicepValue? name) &&
            name.Kind == BicepValueKind.Unset &&
            !name.IsOutput)
        {
            BicepValue<string>? resolved = ResolveName(options, resource, resource.GetResourceNameRequirements());
            if (resolved is not null)
            {
                construct.SetProvisioningProperty(name, resolved);
            }
        }
    }

    /// <summary>
    /// Resolve a name for the given resource.
    /// </summary>
    /// <param name="options">The build options for this resource.</param>
    /// <param name="resource">The resource with an unset Name property.</param>
    /// <param name="requirements">Requirements to name the resource.</param>
    /// <returns>A name for the resource, if one could be created.</returns>
    public abstract BicepValue<string>? ResolveName(
        ProvisioningBuildOptions options,
        ProvisionableResource resource,
        ResourceNameRequirements requirements);

    /// <summary>
    /// Get a sanitized version of the given text according to the set of valid
    /// characters.  Case will be changed as needed, but any other invalid
    /// characters are ignored.
    /// </summary>
    /// <param name="text">The unsanitized text to append.</param>
    /// <param name="validCharacters">
    /// The set of characters that will be appended.
    /// </param>
    /// <returns>A sanitized version of the text.</returns>
    protected static string SanitizeText(string text, ResourceNameCharacters validCharacters)
    {
        if (string.IsNullOrEmpty(text)) { return text; }

        StringBuilder builder = new(capacity: text.Length);
        foreach (char ch in text)
        {
            if ((validCharacters.HasFlag(ResourceNameCharacters.LowercaseLetters) && 'a' <= ch && ch <= 'z') ||
                (validCharacters.HasFlag(ResourceNameCharacters.UppercaseLetters) && 'A' <= ch && ch <= 'Z') ||
                (validCharacters.HasFlag(ResourceNameCharacters.Numbers) && '0' <= ch && ch <= '9') ||
                (validCharacters.HasFlag(ResourceNameCharacters.Hyphen) && ch == '-') ||
                (validCharacters.HasFlag(ResourceNameCharacters.Underscore) && ch == '_') ||
                (validCharacters.HasFlag(ResourceNameCharacters.Period) && ch == '.') ||
                (validCharacters.HasFlag(ResourceNameCharacters.Parentheses) && (ch == '(' || ch == ')')))
            {
                // Just append if it's a valid character
                builder.Append(ch);
            }
            else if (validCharacters.HasFlag(ResourceNameCharacters.LowercaseLetters) && 'A' <= ch && ch <= 'Z')
            {
                // Change to lowercase if required
                builder.Append(char.ToLowerInvariant(ch));
            }
            else if (validCharacters.HasFlag(ResourceNameCharacters.UppercaseLetters) && 'a' <= ch && ch <= 'z')
            {
                // Change to uppercase if required
                builder.Append(char.ToUpperInvariant(ch));
            }
            // Otherwise ignore this character
        }
        return builder.ToString();
    }
}

/// <summary>
/// Generate a unique name for a resource by combining the resource's
/// <see cref="NamedProvisionableConstruct.BicepIdentifier"/> as a prefix and a
/// unique suffix based on the current resource group's ID.
/// </summary>
public class DynamicResourceNamePropertyResolver : ResourceNamePropertyResolver
{
    // TODO: Consider making this more configurable by providing different
    // sources besides just the current resource group's ID, potentially
    // padding the length to a minimum value, etc.

    /// <summary>
    /// Generate a unique name for a resource by combining the resource's
    /// <see cref="NamedProvisionableConstruct.BicepIdentifier"/> as a prefix and a
    /// unique suffix based on the current resource group's ID.
    /// </summary>
    /// <param name="options">The build options for this resource.</param>
    /// <param name="resource">The resource with an unset Name property.</param>
    /// <param name="requirements">Requirements to name the resource.</param>
    /// <returns>A name for the resource.</returns>
    public override BicepValue<string>? ResolveName(
        ProvisioningBuildOptions options,
        ProvisionableResource resource,
        ResourceNameRequirements requirements)
    {
        string prefix = SanitizeText(resource.BicepIdentifier, requirements.ValidCharacters);
        string separator =
            requirements.ValidCharacters.HasFlag(ResourceNameCharacters.Hyphen) ? "-" :
            requirements.ValidCharacters.HasFlag(ResourceNameCharacters.Underscore) ? "_" :
            requirements.ValidCharacters.HasFlag(ResourceNameCharacters.Period) ? "." :
            "";
        BicepValue<string> suffix = GetUniqueSuffix(options, resource);
        return BicepFunction.Take(BicepFunction.Interpolate($"{prefix}{separator}{suffix}"), requirements.MaxLength);
    }

    /// <summary>
    /// Get a unique dynamic name suffix for the given resource.
    /// </summary>
    /// <param name="options">The build options for this resource.</param>
    /// <param name="resource">The resource with an unset Name property.</param>
    /// <returns>A unique dynamic name suffix for the resource.</returns>
    /// <remarks>
    /// This defaults to `uniqueString(resourceGroup().id)` for most resources
    /// and `uniqueString(deployment().id)` for resource groups.  This can be
    /// overridden to provide a different "entropy source."
    /// </remarks>
    protected virtual BicepValue<string> GetUniqueSuffix(ProvisioningBuildOptions options, ProvisionableResource resource) =>
        BicepFunction.GetUniqueString(
            resource is not ResourceGroup ?
                BicepFunction.GetResourceGroup().Id :
                BicepFunction.GetDeployment().Id);
}

/// <summary>
/// Generate a unique name for a resource by combining the resource's
/// <see cref="NamedProvisionableConstruct.BicepIdentifier"/> as a prefix and a
/// randomly generated suffix of allowed characters.
/// </summary>
public class StaticResourceNamePropertyResolver : ResourceNamePropertyResolver
{
    private static readonly char[] s_lower = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'];
    private static readonly char[] s_upper = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'];
    private static readonly char[] s_digits = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];

    public override BicepValue<string>? ResolveName(ProvisioningBuildOptions options, ProvisionableResource resource, ResourceNameRequirements requirements)
    {
        StringBuilder name = new(capacity: requirements.MaxLength);

        // Start with the sanitized resource name
        name.Append(SanitizeText(resource.BicepIdentifier, requirements.ValidCharacters));
        if (name.Length >= requirements.MaxLength)
        {
            return name.ToString(0, requirements.MaxLength);
        }

        // Try to add a separator if allowed
        if (requirements.ValidCharacters.HasFlag(ResourceNameCharacters.Hyphen)) { name.Append('-'); }
        else if (requirements.ValidCharacters.HasFlag(ResourceNameCharacters.Underscore)) { name.Append('_'); }
        else if (requirements.ValidCharacters.HasFlag(ResourceNameCharacters.Period)) { name.Append('.'); }

        // Fill the rest of the name with random characters (just using allowed
        // alphanumerics to avoid nuanced restrictions of non-alphanumeric
        // characters)
        List<char> chars = [];
        if (requirements.ValidCharacters.HasFlag(ResourceNameCharacters.LowercaseLetters)) { chars.AddRange(s_lower); }
        if (requirements.ValidCharacters.HasFlag(ResourceNameCharacters.UppercaseLetters)) { chars.AddRange(s_upper); }
        if (requirements.ValidCharacters.HasFlag(ResourceNameCharacters.Numbers)) { chars.AddRange(s_digits); }
        while (name.Length < requirements.MaxLength)
        {
            name.Append(chars[options.Random.Next(chars.Count)]);
        }

        return name.ToString();
    }
}
