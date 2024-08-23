// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Generator.CSharp;
using Microsoft.Generator.CSharp.ClientModel;
using System.ComponentModel.Composition;

namespace Azure.Generator;

/// <summary>
/// XXX
/// </summary>
[Export(typeof(CodeModelPlugin))]
[ExportMetadata("PluginName", nameof(AzureClinetPlugin))]
public class AzureClinetPlugin : ClientModelPlugin
{
    /// <summary>
    /// XXX
    /// </summary>
    /// <param name="context"></param>
    [ImportingConstructor]
    public AzureClinetPlugin(GeneratorContext context) : base(context) { }

    /// <summary>
    /// XXX
    /// </summary>
    public override void Configure()
    {
    }
}
