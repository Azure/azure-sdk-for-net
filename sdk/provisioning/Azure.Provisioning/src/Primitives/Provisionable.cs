﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Provisioning.Expressions;

namespace Azure.Provisioning.Primitives;

/// <summary>
/// Represents a provisionable resource, construct, or infrastructure.
/// </summary>
public abstract class Provisionable
{
    // TODO: Decide if we want to open this up for extension or keep it locked
    // to the package
    internal Provisionable() { }

    /// <summary>
    /// Get any resources represented by this object.  This will typically only
    /// be the object itself for everything but <see cref="Infrastructure"/>.
    /// </summary>
    /// <returns>Any resources represented by this object.</returns>
    public virtual IEnumerable<Provisionable> GetResources() { yield return this; }

    /// <summary>
    /// Resolve any resources or properties that were not explicitly specified.
    /// </summary>
    /// <param name="context">Optional <see cref="ProvisioningContext"/>.</param>
    protected internal virtual void Resolve(ProvisioningContext? context = default) { }

    /// <summary>
    /// Validate the presence of any required members.
    /// </summary>
    /// <param name="context">Optional <see cref="ProvisioningContext"/>.</param>
    protected internal virtual void Validate(ProvisioningContext? context = default) { }

    /// <summary>
    /// Compile the resource into a set of Bicep statements.
    /// </summary>
    /// <returns>Bicep representation of the resource.</returns>
    protected internal abstract IEnumerable<Statement> Compile();
}
