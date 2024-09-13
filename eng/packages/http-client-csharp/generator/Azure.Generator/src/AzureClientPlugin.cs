// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Generator.CSharp;
using Microsoft.Generator.CSharp.ClientModel;
using System;
using System.ComponentModel.Composition;

namespace Azure.Generator;

/// <summary>
/// The Azure client plugin to generate the Azure client SDK.
/// </summary>
[Export(typeof(CodeModelPlugin))]
[ExportMetadata("PluginName", nameof(AzureClientPlugin))]
public class AzureClientPlugin : ClientModelPlugin
{
    private static AzureClientPlugin? _instance;
    internal static AzureClientPlugin Instance => _instance ?? throw new InvalidOperationException("ClientModelPlugin is not loaded.");

    /// <inheritdoc/>
    public override AzureTypeFactory TypeFactory { get; }

    /// <summary>
    /// The Azure client plugin to generate the Azure client SDK.
    /// </summary>
    /// <param name="context"></param>
    [ImportingConstructor]
    public AzureClientPlugin(GeneratorContext context) : base(context)
    {
        TypeFactory = new AzureTypeFactory();
        _instance = this;
    }

    /// <summary>
    /// Customize the generation output for Azure client SDK.
    /// </summary>
    public override void Configure()
    {
    }

    /// <summary>
    /// Customize the license string for Azure client SDK.
    /// </summary>
    public override string LicenseString => """
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
""";
}
