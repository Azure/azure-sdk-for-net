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
/// <param name="bicepIdentifier">The bicep identifier name of the resource.</param>
/// <param name="resourceType">The type of the resource.</param>
/// <param name="resourceVersion">The version of the resource.</param>
public abstract class ProvisionableResource(string bicepIdentifier, ResourceType resourceType, string? resourceVersion = default)
    : NamedProvisionableConstruct(bicepIdentifier)
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
    public bool IsExistingResource
    {
        get => _isExisting;
        protected set
        {
            _isExisting = value;
            if (_isExisting)
            {
                Initialize();
                foreach (IBicepValue property in ProvisionableProperties.Values)
                {
                    // Name is the only property that's still settable
                    if (property.Self?.PropertyName == "Name") { continue; }
                    property.SetReadOnly();
                }
            }
        }
    }
    private bool _isExisting = false;

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
    public IList<ProvisionableResource> DependsOn { get; } = [];

    /// <summary>
    /// Compose the resource into a provisioning plan that can be saved as
    /// Bicep or deployed directly.
    /// </summary>
    /// <param name="options">Optional ProvisioningBuildOptions.</param>
    /// <returns>
    /// A provisioning plan that can be saved as Bicep or deployed directly.
    /// </returns>
    public virtual ProvisioningPlan Build(ProvisioningBuildOptions? options = default) =>
        ParentInfrastructure?.Build(options ?? new()) ??
            throw new InvalidOperationException($"Cannot build a provisioning plan for {GetType().Name} resource {BicepIdentifier} before it has been added to {nameof(Infrastructure)}.");

    /// <inheritdoc />
    protected internal override void Validate(ProvisioningBuildOptions? options = null)
    {
        base.Validate(options);

        if (ResourceVersion is null)
        {
            throw new InvalidOperationException($"{GetType().Name} resource {BicepIdentifier} must have {nameof(ResourceVersion)} specified.");
        }

        if (DependsOn.Count > 0 && (IsExistingResource || ((IBicepValue)this).Kind == BicepValueKind.Expression))
        {
            throw new InvalidOperationException($"{GetType().Name} resource {BicepIdentifier} cannot have dependencies if it's an existing resource or an expression override.");
        }

        if (IsExistingResource)
        {
            // We only want to validate the name if we're linking to an existing resource
            if (ProvisionableProperties.TryGetValue("Name", out IBicepValue? name) && name.IsRequired)
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
    protected internal override IEnumerable<BicepStatement> Compile()
    {
        if (((IBicepValue)this).Kind == BicepValueKind.Expression)
        {
            yield return new ExpressionStatement(CompileProperties());
            yield break;
        }

        // Compile the properties into an object
        BicepExpression body = CompileProperties();

        // Optionally add any explicit dependencies
        if (DependsOn.Count > 0)
        {
            // This should be caught by Validate above
            if (body is not ObjectExpression obj)
            {
                throw new InvalidOperationException($"{GetType().Name} resource {BicepIdentifier} cannot have dependencies if it's an existing resource or an expression override.");
            }

            // Add the dependsOn property
            ArrayExpression dependencies = new(DependsOn.Select(r => BicepSyntax.Var(r.BicepIdentifier)).ToArray());
            body = new ObjectExpression([.. obj.Properties, new PropertyExpression("dependsOn", dependencies)]);
        }

        // Create a resource declaration
        ResourceStatement resource = BicepSyntax.Declare.Resource(
            BicepIdentifier,
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

    protected ResourceReference<T> DefineResource<T>(
        string propertyName,
        string[]? bicepPath,
        bool isOutput = false,
        bool isRequired = false,
        T? defaultValue = null)
        where T : ProvisionableResource
    {
        ResourceReference<T> resource = new(
            DefineProperty<string>(propertyName, bicepPath, isOutput: isOutput, isRequired: isRequired));
        if (defaultValue is not null)
        {
            resource.Value = defaultValue;
        }
        return resource;
    }
}
