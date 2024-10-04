// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning;

/// <summary>
/// Collect resources and other constructs like parameters together.
/// </summary>
/// <param name="name"></param>
public class Infrastructure(string name = "main") : Provisionable
{
    /// <summary>
    /// A friendly name that can also be used if compiling to a module.
    /// </summary>
    public string Name { get; private set; } = name;

    /// <summary>
    /// Optional target scope for the infrastructure.  If left empty, then
    /// <c>resourcegroup</c> is assumed.
    /// </summary>
    public string? TargetScope { get; set; }

    // Placeholder until we get module splitting handled
    private Infrastructure? _parent = null;

    /// <inheritdoc/>
    public override IEnumerable<Provisionable> GetResources() => _resources;
    private readonly List<Provisionable> _resources = [];

    /// <summary>
    /// Adds a provisionable construct to this Infrastructure.
    /// </summary>
    /// <param name="resource">The provisionable construct to add.</param>
    /// <remarks>
    /// This will remove any existing association between this provisionable
    /// construct and other Infrastructure instances.
    /// </remarks>
    public virtual void Add(Provisionable resource)
    {
        if (resource is ProvisioningConstruct construct &&
            construct.ParentInfrastructure != this)
        {
            // Don't parent expression references
            if (construct.ExpressionOverride is not null) { return; }

            // Remove it from any existing Infrastructure first
            construct.ParentInfrastructure?.Remove(this);

            // Add and associate the resource
            _resources.Add(construct);
            construct.ParentInfrastructure = this;
        }
        else if (resource is Infrastructure nested &&
            nested._parent != this)
        {
            // Remove it from any existing Infrastructure first
            nested._parent?.Remove(this);

            // Add and associate the resource
            _resources.Add(nested);
            nested._parent = this;
        }

        // Ensure all cases are covered
        Debug.Assert(
            resource is ProvisioningConstruct || resource is Infrastructure,
            $"{nameof(Infrastructure)} needs to be updated if you add a new fork in the hierarchy derived from {nameof(Provisionable)}!");
    }

    /// <summary>
    /// Remove a provisionable construct from this Infrastructure.
    /// </summary>
    /// <param name="resource">The provisionable construct to remove.</param>
    public virtual void Remove(Provisionable resource)
    {
        if (resource is ProvisioningConstruct construct &&
            construct.ParentInfrastructure == this)
        {
            construct.ParentInfrastructure = null;
            _resources.Remove(construct);
        }
        else if (resource is Infrastructure nested &&
            nested._parent == this)
        {
            nested._parent = null;
            _resources.Remove(nested);
        }
    }

    /// <summary>
    /// Checks whether an name is a valid bicep identifier name comprised of
    /// letters, digits, and underscores.
    /// </summary>
    /// <param name="identifierName">The proposed identifier name.</param>
    /// <returns>Whether the name is a valid bicep identifier name.</returns>
    public static bool IsValidIdentifierName(string? identifierName)
    {
        if (string.IsNullOrEmpty(identifierName)) { return false; }
        if (char.IsDigit(identifierName![0])) { return false; }
        foreach (char ch in identifierName)
        {
            if (!char.IsLetterOrDigit(ch) && ch != '_')
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Validates whether a given bicep identifier name is correctly formed of
    /// letters, numbers, and underscores.
    /// </summary>
    /// <param name="identifierName">The proposed bicep identifier name.</param>
    /// <exception cref="ArgumentNullException">Throws if null.</exception>
    /// <exception cref="ArgumentException">Throws if empty or invalid.</exception>
    public static void ValidateIdentifierName(string? identifierName)
    {
        if (identifierName is null)
        {
            throw new ArgumentNullException(nameof(identifierName), $"{nameof(identifierName)} cannot be null.");
        }
        else if (identifierName.Length == 0)
        {
            throw new ArgumentException($"{nameof(identifierName)} cannot be empty.", nameof(identifierName));
        }
        else if (char.IsDigit(identifierName[0]))
        {
            throw new ArgumentException($"{nameof(identifierName)} cannot start with a number: \"{identifierName}\"", nameof(identifierName));
        }

        foreach (var ch in identifierName)
        {
            if (!char.IsLetterOrDigit(ch) && ch != '_')
            {
                throw new ArgumentException($"{nameof(identifierName)} should only contain letters, numbers, and underscores: \"{identifierName}\"", nameof(identifierName));
            }
        }
    }

    /// <summary>
    /// Normalizes a proposed bicep identifier name.  Any invalid characters
    /// will be replaced with underscores.
    /// </summary>
    /// <param name="identifierName">The proposed bicep identifier name.</param>
    /// <returns>A valid bicep identifier name.</returns>
    /// <exception cref="ArgumentNullException">Throws if null.</exception>
    /// <exception cref="ArgumentException">Throws if empty.</exception>
    public static string NormalizeIdentifierName(string? identifierName)
    {
        if (identifierName is null)
        {
            // TODO: This may be relaxed in the future to generate an automatic
            // name rather than throwing
            throw new ArgumentNullException(nameof(identifierName), $"{nameof(identifierName)} cannot be null.");
        }
        else if (identifierName.Length == 0)
        {
            throw new ArgumentException($"{nameof(identifierName)} cannot be empty.", nameof(identifierName));
        }

        StringBuilder builder = new(identifierName.Length);

        // Digits are not allowed as the first character, so prepend an
        // underscore if the identifierName starts with a digit
        if (char.IsDigit(identifierName[0]))
        {
            builder.Append('_');
        }

        foreach (char ch in identifierName)
        {
            // TODO: Consider opening this up to other naming strategies if
            // someone can do something more intelligent for their usage/domain
            builder.Append(char.IsLetterOrDigit(ch) ? ch : '_');
        }

        return builder.ToString();
    }

    /// <inheritdoc/>
    protected internal override void Validate(ProvisioningContext? context = null)
    {
        context ??= new();
        base.Validate(context);
        foreach (Provisionable resource in GetResources()) { resource.Validate(context); }
    }

    /// <inheritdoc/>
    protected internal override void Resolve(ProvisioningContext? context = default)
    {
        context ??= new();
        base.Resolve(context);

        Provisionable[] cached = [.. GetResources()]; // Copy so Resolve can mutate
        foreach (Provisionable resource in cached) { resource.Resolve(context); }

        foreach (InfrastructureResolver resolver in context.InfrastructureResolvers)
        {
            resolver.ResolveInfrastructure(context, this);
        }
    }

    /// <inheritdoc/>
    protected internal override IEnumerable<Statement> Compile() =>
        // TODO: For now I'm letting this through in case someone calls Compile
        // before Build while debugging.  We could also make it a little less
        // friendly and more predictable by throwing here.
        CompileInternal(context: null);

    /// <summary>
    /// Compile this infrastructure into a set of bicep modules.
    /// </summary>
    /// <param name="context">Provisioning context.</param>
    /// <returns>Dictionary mapping module names to module definitions.</returns>
    protected internal IDictionary<string, IEnumerable<Statement>> CompileModules(ProvisioningContext? context = default)
    {
        // This API shape will eventually help us grow into compiling multiple
        // modules at once and automatically splitting resources across them.
        context ??= new();
        Dictionary<string, IEnumerable<Statement>> modules = [];
        modules.Add(Name, CompileInternal(context));

        // Optionally add any nested modules
        List<Infrastructure> nested = [];
        foreach (InfrastructureResolver resolver in context.InfrastructureResolvers)
        {
            nested.AddRange(resolver.GetNestedInfrastructure(context, this));
        }
        foreach (Infrastructure infra in nested)
        {
            modules.Add(infra.Name, infra.CompileInternal(context));
        }

        return modules;
    }

    /// <inheritdoc/>
    private List<Statement> CompileInternal(ProvisioningContext? context)
    {
        List<Statement> statements = [];
        if (TargetScope is not null)
        {
            statements.Add(new TargetScopeStatement(TargetScope));
        }

        IEnumerable<Provisionable> resources = GetResources();

        // Optionally customize the resources with the extensibility hooks on
        // ProvisioningContext.
        if (context is not null)
        {
            foreach (InfrastructureResolver resolver in context.InfrastructureResolvers)
            {
                resources = resolver.ResolveResources(context, resources);
            }
        }

        foreach (Provisionable resource in resources)
        {
            if (resource is ProvisioningConstruct construct)
            {
                statements.AddRange(construct.Compile());
            }
            else if (resource is Infrastructure nested)
            {
                // We'll eventually add support for auto module splitting and
                // be able to do smart things here.  We're going to intentionally
                // fail for now though so we have more flexibility in the future.
                // We fail here instead of Add so folks have a chance to move it
                // around between different Infrastructure classes if they want
                throw new NotSupportedException($"Nested {nameof(Infrastructure)} is not currently supported.  Please build them separately and use {nameof(ModuleImport)} to link them together.");
            }
        }
        return statements;
    }

    /// <summary>
    /// Compose all the resources into a concrete <see cref="ProvisioningPlan"/>
    /// that can be compiled into Bicep, deployed, etc.
    /// </summary>
    /// <param name="context">
    /// The provisioning context to use for composing resources.
    /// </param>
    /// <returns>
    /// A <see cref="ProvisioningPlan"/> that can be compiled into Bicep,
    /// deployed, etc.
    /// </returns>
    public virtual ProvisioningPlan Build(ProvisioningContext? context = default)
    {
        context ??= new();
        Resolve(context);
        Validate(context);
        return new ProvisioningPlan(this, context);
    }
}
