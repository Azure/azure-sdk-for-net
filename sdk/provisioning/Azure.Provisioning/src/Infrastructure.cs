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
/// <param name="bicepName">
/// A friendly name that can also be used as a file name if compiling to a
/// module.
/// </param>
public class Infrastructure(string bicepName = "main") : Provisionable
{
    /// <summary>
    /// A friendly name that can also be used as a file name if compiling to a
    /// module.
    /// </summary>
    public string BicepName { get; private set; } = bicepName;

    /// <summary>
    /// Optional target scope for the infrastructure.  If left empty, then
    /// <see cref="DeploymentScope.ResourceGroup"/> is assumed.
    /// </summary>
    public DeploymentScope? TargetScope { get; set; }

    // Placeholder until we get module splitting handled
    private Infrastructure? _parent = null;

    /// <inheritdoc/>
    public override IEnumerable<Provisionable> GetProvisionableResources() => _resources;
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
        if (resource is ProvisionableConstruct construct &&
            construct.ParentInfrastructure != this)
        {
            // Don't parent expression references
            if (((IBicepValue)construct).Kind == BicepValueKind.Expression) { return; }

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
            resource is ProvisionableConstruct || resource is Infrastructure,
            $"{nameof(Infrastructure)} needs to be updated if you add a new fork in the hierarchy derived from {nameof(Provisionable)}!");
    }

    /// <summary>
    /// Remove a provisionable construct from this Infrastructure.
    /// </summary>
    /// <param name="resource">The provisionable construct to remove.</param>
    public virtual void Remove(Provisionable resource)
    {
        if (resource is ProvisionableConstruct construct &&
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

    private static bool IsAsciiLetterOrDigit(char ch) =>
        'a' <= ch && ch <= 'z' ||
        'A' <= ch && ch <= 'Z' ||
        '0' <= ch && ch <= '9';

    /// <summary>
    /// Checks whether an name is a valid bicep identifier name comprised of
    /// letters, digits, and underscores.
    /// </summary>
    /// <param name="bicepIdentifier">The proposed identifier.</param>
    /// <returns>Whether the name is a valid bicep identifier.</returns>
    public static bool IsValidBicepIdentifier(string? bicepIdentifier)
    {
        if (string.IsNullOrEmpty(bicepIdentifier)) { return false; }
        if (char.IsDigit(bicepIdentifier![0])) { return false; }
        foreach (char ch in bicepIdentifier)
        {
            if (!IsAsciiLetterOrDigit(ch) && ch != '_')
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
    /// <param name="bicepIdentifier">The proposed bicep identifier.</param>
    /// <param name="paramName">Optional parameter name to use for exceptions.</param>
    /// <exception cref="ArgumentNullException">Throws if null.</exception>
    /// <exception cref="ArgumentException">Throws if empty or invalid.</exception>
    public static void ValidateBicepIdentifier(string? bicepIdentifier, string? paramName = default)
    {
        paramName ??= nameof(bicepIdentifier);
        if (bicepIdentifier is null)
        {
            throw new ArgumentNullException(paramName, $"{paramName} cannot be null.");
        }
        else if (bicepIdentifier.Length == 0)
        {
            throw new ArgumentException($"{paramName} cannot be empty.", paramName);
        }
        else if (char.IsDigit(bicepIdentifier[0]))
        {
            throw new ArgumentException($"{paramName} cannot start with a number: \"{bicepIdentifier}\"", paramName);
        }

        foreach (var ch in bicepIdentifier)
        {
            if (!IsAsciiLetterOrDigit(ch) && ch != '_')
            {
                throw new ArgumentException($"{paramName} should only contain letters, numbers, and underscores: \"{bicepIdentifier}\"", paramName);
            }
        }
    }

    /// <summary>
    /// Normalizes a proposed bicep identifier name.  Any invalid characters
    /// will be replaced with underscores.
    /// </summary>
    /// <param name="bicepIdentifier">The proposed bicep identifier.</param>
    /// <returns>A valid bicep identifier name.</returns>
    /// <exception cref="ArgumentNullException">Throws if null.</exception>
    /// <exception cref="ArgumentException">Throws if empty.</exception>
    public static string NormalizeBicepIdentifier(string? bicepIdentifier)
    {
        if (IsValidBicepIdentifier(bicepIdentifier))
        {
            return bicepIdentifier!;
        }

        if (bicepIdentifier is null)
        {
            // TODO: This may be relaxed in the future to generate an automatic
            // name rather than throwing
            throw new ArgumentNullException(nameof(bicepIdentifier), $"{nameof(bicepIdentifier)} cannot be null.");
        }
        else if (bicepIdentifier.Length == 0)
        {
            throw new ArgumentException($"{nameof(bicepIdentifier)} cannot be empty.", nameof(bicepIdentifier));
        }

        StringBuilder builder = new(bicepIdentifier.Length);

        // Digits are not allowed as the first character, so prepend an
        // underscore if the bicepIdentifier starts with a digit
        if (char.IsDigit(bicepIdentifier[0]))
        {
            builder.Append('_');
        }

        foreach (char ch in bicepIdentifier)
        {
            // TODO: Consider opening this up to other naming strategies if
            // someone can do something more intelligent for their usage/domain
            builder.Append(IsAsciiLetterOrDigit(ch) ? ch : '_');
        }

        return builder.ToString();
    }

    /// <inheritdoc/>
    protected internal override void Validate(ProvisioningBuildOptions? options = null)
    {
        options ??= new();
        base.Validate(options);
        foreach (Provisionable resource in GetProvisionableResources()) { resource.Validate(options); }
    }

    /// <inheritdoc/>
    protected internal override void Resolve(ProvisioningBuildOptions? options = default)
    {
        options ??= new();
        base.Resolve(options);

        Provisionable[] cached = [.. GetProvisionableResources()]; // Copy so Resolve can mutate
        foreach (Provisionable resource in cached) { resource.Resolve(options); }

        foreach (InfrastructureResolver resolver in options.InfrastructureResolvers)
        {
            resolver.ResolveInfrastructure(this, options);
        }
    }

    /// <inheritdoc/>
    protected internal override IEnumerable<BicepStatement> Compile() =>
        CompileInternal(options: null);

    /// <summary>
    /// Compile this infrastructure into a set of bicep modules.
    /// </summary>
    /// <param name="options">Provisioning options.</param>
    /// <returns>Dictionary mapping module names to module definitions.</returns>
    protected internal IDictionary<string, IEnumerable<BicepStatement>> CompileModules(ProvisioningBuildOptions? options = default)
    {
        // This API shape will eventually help us grow into compiling multiple
        // modules at once and automatically splitting resources across them.
        options ??= new();
        Dictionary<string, IEnumerable<BicepStatement>> modules = [];
        modules.Add(BicepName, CompileInternal(options));

        // Optionally add any nested modules
        List<Infrastructure> nested = [];
        foreach (InfrastructureResolver resolver in options.InfrastructureResolvers)
        {
            nested.AddRange(resolver.GetNestedInfrastructure(this, options));
        }
        foreach (Infrastructure infra in nested)
        {
            modules.Add(infra.BicepName, infra.CompileInternal(options));
        }

        return modules;
    }

    /// <inheritdoc/>
    private List<BicepStatement> CompileInternal(ProvisioningBuildOptions? options)
    {
        List<BicepStatement> statements = [];
        if (TargetScope is not null)
        {
            statements.Add(
                new TargetScopeStatement(
                    TargetScope switch
                    {
                        DeploymentScope.ResourceGroup => "resourceGroup",
                        DeploymentScope.Subscription => "subscription",
                        DeploymentScope.ManagementGroup => "managementGroup",
                        DeploymentScope.Tenant => "tenant",
                        _ => throw new InvalidOperationException($"Unknown deployment scope: {TargetScope}")
                    }));
        }

        IEnumerable<Provisionable> resources = GetProvisionableResources();

        // Optionally customize the resources with the extensibility hooks on
        // ProvisioningBuildOptions.
        if (options is not null)
        {
            foreach (InfrastructureResolver resolver in options.InfrastructureResolvers)
            {
                resources = resolver.ResolveResources(resources, options);
            }
        }

        foreach (Provisionable resource in resources)
        {
            if (resource is ProvisionableConstruct construct)
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
    /// <param name="options">
    /// The build options to use for composing resources.
    /// </param>
    /// <returns>
    /// A <see cref="ProvisioningPlan"/> that can be compiled into Bicep,
    /// deployed, etc.
    /// </returns>
    public virtual ProvisioningPlan Build(ProvisioningBuildOptions? options = default)
    {
        options ??= new();
        Resolve(options);
        Validate(options);
        return new ProvisioningPlan(this, options);
    }
}
