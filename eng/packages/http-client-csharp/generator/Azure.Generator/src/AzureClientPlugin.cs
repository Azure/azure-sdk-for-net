// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Generator.CSharp;
using Microsoft.Generator.CSharp.ClientModel;
using System.ComponentModel.Composition;

namespace Azure.Generator;

/// <summary>
/// The Azure client plugin to generate the Azure client SDK.
/// </summary>
[Export(typeof(CodeModelPlugin))]
[ExportMetadata("PluginName", nameof(AzureClientPlugin))]
public class AzureClientPlugin : ClientModelPlugin
{
    /// <summary>
    /// The Azure client plugin to generate the Azure client SDK.
    /// </summary>
    /// <param name="context"></param>
    [ImportingConstructor]
    public AzureClientPlugin(GeneratorContext context) : base(context)
    {
        TypeFactory = new AzureTypeFactory();
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

    /// <summary>
    /// Returns the Azure type factory
    /// </summary>
    public override AzureTypeFactory TypeFactory { get; }
}
