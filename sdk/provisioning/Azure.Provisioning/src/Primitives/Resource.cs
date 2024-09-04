// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.Provisioning.Expressions;

namespace Azure.Provisioning.Primitives;

/// <summary>
/// Represents an Azure resource.
/// </summary>
/// <param name="resourceName">The friendly namee of the resource.</param>
/// <param name="resourceType">The type of the resource.</param>
/// <param name="resourceVersion">The version of the resource.</param>
/// <param name="context">Optional ProvisioningContext.</param>
public abstract class Resource(string resourceName, ResourceType resourceType, string? resourceVersion = default, ProvisioningContext? context = default)
    : NamedProvisioningConstruct(resourceName, context)
{
    /// <summary>
    /// Gets the type of the resource.
    /// </summary>
    public ResourceType ResourceType { get; private set; } = resourceType;

    /// <summary>
    /// Gets or sets the version of the resource.
    /// </summary>
    public string? ResourceVersion { get; set; } = resourceVersion;

    /// <summary>
    /// Gets whether this is referencing an existing resource or we're defining
    /// a new resource.
    /// </summary>
    public bool IsExistingResource { get; protected set; } = false;

    /// <summary>
    /// Compose the resource into a provisioning plan that can be saved as
    /// Bicep or deployed directly.
    /// </summary>
    /// <param name="context">Optional ProvisioningContext.</param>
    /// <returns>
    /// A provisioning plan that can be saved as Bicep or deployed directly.
    /// </returns>
    public virtual ProvisioningPlan Build(ProvisioningContext? context = default)
    {
        context ??= DefaultProvisioningContext;
        return context.DefaultInfrastructure.Build(context);
    }

    /// <inheritdoc />
    protected internal override void Validate(ProvisioningContext? context = null)
    {
        base.Validate(context);

        if (ResourceVersion is null)
        {
            throw new InvalidOperationException($"{GetType().Name} resource {ResourceName} must have {nameof(ResourceVersion)} specified.");
        }

        if (IsExistingResource)
        {
            // We only want to validate the name if we're linking to an existing resource
            if (ProvisioningProperties.TryGetValue("Name", out BicepValue? name) && name.IsRequired)
            {
                RequireProperty(name);
            }
        }
        else
        {
            // Otherwise validate everything
            ValidateProperties();
        }
    }

    /// <inheritdoc />
    protected internal override IEnumerable<Statement> Compile(ProvisioningContext? context = default)
    {
        if (ExpressionOverride is not null)
        {
            yield return new ExprStatement(ExpressionOverride);
            yield break;
        }

        // Create a resource declaration
        ResourceStatement resource = BicepSyntax.Declare.Resource(
            ResourceName,
            $"{ResourceType}@{ResourceVersion}",
            CompileProperties());
        if (IsExistingResource)
        {
            resource.Existing = true;
        }

        yield return resource;
    }

    /// <summary>
    /// Get the requirements for naming this resource.  This is primarily for
    /// use by property and resource resolvers.
    /// </summary>
    /// <returns>Naming requirements.</returns>
    /// <remarks>
    /// This uses conservative defaults that should work for most resources
    /// with a minLength of 1, a maxLength of 24, and only lowercase letters.
    /// It should be overridden to customize.
    /// </remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ResourceNameRequirements GetResourceNameRequirements() =>
        new(minLength: 1, maxLength: 24, validCharacters: ResourceNameCharacters.LowercaseLetters);
}
