// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning;

/// <summary>
/// Collect resources and other constructs like parameters together.
/// </summary>
/// <param name="name"></param>
public class Infrastructure(string name) : Provisionable
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

    // TODO: Figure out the right way to expose ethis publicly
    protected internal override IEnumerable<Provisionable> GetResources() => _resources;
    private readonly List<Provisionable> _resources = [];

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
    }

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

    protected internal override void Validate(ProvisioningContext? context = null)
    {
        context ??= ProvisioningContext.Provider.GetProvisioningContext();
        base.Validate(context);
        foreach (Provisionable resource in GetResources()) { resource.Validate(context); }
    }

    protected internal override void Resolve(ProvisioningContext? context = default)
    {
        context ??= ProvisioningContext.Provider.GetProvisioningContext();
        base.Resolve(context);

        Provisionable[] cached = [.. GetResources()]; // Copy so Resolve can mutate
        foreach (Provisionable resource in cached) { resource.Resolve(context); }
    }

    protected internal override IEnumerable<Statement> Compile(ProvisioningContext? context = default)
    {
        context ??= ProvisioningContext.Provider.GetProvisioningContext();
        List<Statement> statements = [];
        if (TargetScope is not null)
        {
            statements.Add(new TargetScopeStatement(TargetScope));
        }
        foreach (Provisionable resource in GetResources())
        {
            if (resource is ProvisioningConstruct construct)
            {
                statements.AddRange(construct.Compile(context));
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

    protected internal IDictionary<string, IEnumerable<Statement>> CompileModules(ProvisioningContext? context = default)
    {
        // This API shape will eventually help us grow into compiling multiple
        // modules at once and automatically splitting resources across them.
        context ??= ProvisioningContext.Provider.GetProvisioningContext();
        Dictionary<string, IEnumerable<Statement>> modules = [];
        modules.Add(Name, Compile(context));
        return modules;
    }

    public virtual ProvisioningPlan Build(ProvisioningContext? context = default)
    {
        context ??= ProvisioningContext.Provider.GetProvisioningContext();
        Resolve(context);
        Validate(context);

        // Reset the default infrastructure so the context can continue to be
        // used for additional provisioning.
        context.DefaultInfrastructure = context.DefaultInfrastructureProvider();

        return new ProvisioningPlan(this, context);
    }
}
