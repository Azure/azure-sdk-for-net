// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning;

/// <summary>
/// Declares a Bicep extension and its configuration in an infrastructure.
/// </summary>
/// <remarks>
/// Add configuration values to <see cref="ProvisionableConstruct.ProvisionableProperties"/>,
/// or derive from this class to expose strongly typed configuration properties.
/// Extension resource declarations are separate provisioning constructs.
/// </remarks>
public class BicepExtensionConstruct : ProvisionableConstruct
{
    /// <summary>
    /// Gets the extension name or artifact reference.
    /// </summary>
    public string Reference { get; }

    /// <summary>
    /// Gets or sets the optional Bicep namespace alias.
    /// </summary>
    public string? Alias
    {
        get => _alias;
        set
        {
            if (value is not null)
            {
                Infrastructure.ValidateBicepIdentifier(value, nameof(value));
            }
            _alias = value;
        }
    }
    private string? _alias;

    /// <summary>
    /// Creates a Bicep extension declaration.
    /// </summary>
    /// <param name="reference">
    /// An extension name, such as <c>kubernetes</c>, or an artifact reference,
    /// such as <c>br:mcr.microsoft.com/bicep/extensions/microsoftgraph/v1.0:1.0.0</c>.
    /// Names that are valid Bicep identifiers are emitted without quotes.
    /// Other references are emitted as escaped Bicep string literals.
    /// Do not include surrounding quotes in the reference.
    /// </param>
    /// <param name="alias">An optional Bicep namespace alias.</param>
    public BicepExtensionConstruct(string reference, string? alias = null)
    {
        if (reference is null)
        {
            throw new ArgumentNullException(nameof(reference));
        }
        if (string.IsNullOrWhiteSpace(reference))
        {
            throw new ArgumentException("The extension reference cannot be empty or whitespace.", nameof(reference));
        }
        Reference = reference;
        Alias = alias;
    }

    /// <inheritdoc />
    protected internal override void Validate(ProvisioningBuildOptions? options = null)
    {
        base.Validate(options);
        ValidateProperties();
        if (((IBicepValue)this).Kind == BicepValueKind.Expression)
        {
            throw new InvalidOperationException("An extension declaration cannot be replaced with an expression.");
        }
    }

    /// <inheritdoc />
    protected internal override IEnumerable<BicepStatement> Compile()
    {
        BicepExpression reference = Infrastructure.IsValidBicepIdentifier(Reference) ?
            BicepSyntax.Var(Reference) : BicepSyntax.Value(Reference);
        ObjectExpression configuration = (ObjectExpression)CompileProperties();
        yield return BicepSyntax.Declare.Extension(
            reference,
            configuration.Properties.Length == 0 ? null : configuration,
            Alias);
    }
}
