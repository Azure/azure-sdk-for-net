// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.Provisioning.Expressions;

namespace Azure.Provisioning.Primitives;

/// <summary>
/// Represents an Azure resource.
/// </summary>
/// <param name="resourceName">The friendly name of the resource.</param>
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
    /// Declares explicit dependencies on other resources.
    /// </summary>
    /// <remarks>
    /// <para>
    /// While you may be inclined to use dependsOn to map relationships between
    /// your resources, it's important to understand why you're doing it.  For
    /// example, to document how resources are interconnected, dependsOn isn't
    /// the right approach. After deployment, the resource doesn't retain
    /// deployment dependencies in its properties, so there are no commands or
    /// operations that let you see dependencies. Setting unnecessary
    /// dependencies slows deployment time because Resource Manager can't
    /// deploy those resources in parallel.
    /// </para>
    /// <para>
    /// Even though explicit dependencies are sometimes required, the need for
    /// them is rare. In most cases, you can use a symbolic name to imply the
    /// dependency between resources. If you find yourself setting explicit
    /// dependencies, you should consider if there's a way to remove it.
    /// </para>
    /// </remarks>
    public IList<Resource> DependsOn { get; } = [];
    // TODO: Decide whether we want to support ResourceIdentifier in addition
    // to actual Resources.  Given it's a niche scenario, right now I'd lean
    // toward making people use Foo.FromExisting("...") if they wanted to add a
    // dependency to an external resource.

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

        if (DependsOn.Count > 0 && (IsExistingResource || ExpressionOverride is not null))
        {
            throw new InvalidOperationException($"{GetType().Name} resource {ResourceName} cannot have dependencies if it's an existing resource or an expression override.");
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

        // Compile the properties into an object
        Expression body = CompileProperties();

        // Optionally add any explicit dependencies
        if (DependsOn.Count > 0)
        {
            // This should be caught by Validate above
            if (body is not ObjectExpression obj)
            {
                throw new InvalidOperationException($"{GetType().Name} resource {ResourceName} cannot have dependencies if it's an existing resource or an expression override.");
            }

            // Add the dependsOn property
            ArrayExpression dependencies = new(DependsOn.Select(r => BicepSyntax.Var(r.ResourceName)).ToArray());
            body = new ObjectExpression([.. obj.Properties, new PropertyExpression("dependsOn", dependencies)]);
        }

        // Create a resource declaration
        ResourceStatement resource = BicepSyntax.Declare.Resource(
            ResourceName,
            $"{ResourceType}@{ResourceVersion}",
            body);
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
