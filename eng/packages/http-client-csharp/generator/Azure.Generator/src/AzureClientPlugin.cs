// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager;
using Microsoft.CodeAnalysis;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.ClientModel;
using System;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using Azure.Generator.Primitives;

namespace Azure.Generator;

/// <summary>
/// The Azure client plugin to generate the Azure client SDK.
/// </summary>
[Export(typeof(CodeModelPlugin))]
[ExportMetadata("PluginName", nameof(AzureClientPlugin))]
public class AzureClientPlugin : ScmCodeModelPlugin
{
    private static AzureClientPlugin? _instance;
    internal static AzureClientPlugin Instance => _instance ?? throw new InvalidOperationException("AzureClientPlugin is not loaded.");

    /// <inheritdoc/>
    public override AzureTypeFactory TypeFactory { get; }

    private AzureOutputLibrary? _azureOutputLibrary;
    /// <inheritdoc/>
    public override AzureOutputLibrary OutputLibrary => _azureOutputLibrary ??= new();

    /// <inheritdoc/>
    public override AzureInputLibrary InputLibrary { get; }

    /// <summary>
    /// The Azure client plugin to generate the Azure client SDK.
    /// </summary>
    /// <param name="context"></param>
    [ImportingConstructor]
    public AzureClientPlugin(GeneratorContext context) : base(context)
    {
        InputLibrary = new AzureInputLibrary(Configuration.OutputDirectory);
        TypeFactory = new AzureTypeFactory();
        _instance = this;
    }

    /// <summary>
    /// Customize the generation output for Azure client SDK.
    /// </summary>
    public override void Configure()
    {
        base.Configure();
        // Include Azure.Core
        AddMetadataReference(MetadataReference.CreateFromFile(typeof(Response).Assembly.Location));
        var sharedSourceDirectory = Path.Combine(Path.GetDirectoryName(typeof(AzureClientPlugin).Assembly.Location)!, "Shared", "Core");
        AddSharedSourceDirectory(sharedSourceDirectory);
        AddVisitor(new NamespaceVisitor());
        if (IsAzureArm.Value)
        {
            // Include Azure.ResourceManager
            AddMetadataReference(MetadataReference.CreateFromFile(typeof(ArmClient).Assembly.Location));
            AddVisitor(new RestClientVisitor());
            AddVisitor(new ResourceVisitor());
        }
    }

    /// <summary>
    /// Customize the license string for Azure client SDK.
    /// </summary>
    public override string LicenseString => """
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
""";

    /// <summary>
    /// Identify if the input is generated for Azure ARM.
    /// </summary>
    internal Lazy<bool> IsAzureArm => new Lazy<bool>(() => InputLibrary.InputNamespace.Clients.Any(c => c.Decorators.Any(d => d.Name.Equals(KnownDecorators.ArmProviderNamespace))));
}
