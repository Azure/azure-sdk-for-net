// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.CodeAnalysis;
using Microsoft.Generator.CSharp;
using Microsoft.Generator.CSharp.ClientModel;
using System;
using System.ClientModel;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;

namespace Azure.Generator;

/// <summary>
/// The Azure client plugin to generate the Azure client SDK.
/// </summary>
[Export(typeof(CodeModelPlugin))]
[ExportMetadata("PluginName", nameof(AzureClientPlugin))]
public class AzureClientPlugin : ClientModelPlugin
{
    private static AzureClientPlugin? _instance;
    internal static AzureClientPlugin Instance => _instance ?? throw new InvalidOperationException("AzureClientPlugin is not loaded.");

    /// <inheritdoc/>
    public override AzureTypeFactory TypeFactory { get; }

    private AzureOutputLibrary? _azureOutputLibrary;
    /// <inheritdoc/>
    public override AzureOutputLibrary OutputLibrary => _azureOutputLibrary ??= new();

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
        base.Configure();
        AddMetadataReference(MetadataReference.CreateFromFile(typeof(Response).Assembly.Location));
        AddSharedSourceDirectory(Path.Combine(GetRepositoryRootPath(), "sdk/core/Azure.Core/src/Shared"));
    }

    private string GetRepositoryRootPath()
    {
        // This assumes we're always running in place, in the repo
        string? path = Environment.CurrentDirectory;
        while (path is not null && !Directory.Exists(Path.Combine(path, ".git")))
        {
            // Walk up a level
            path = Path.GetDirectoryName(path);
        }
        return path ?? throw new InvalidOperationException("Can't find the repository root directory.");
    }

    /// <summary>
    /// Customize the license string for Azure client SDK.
    /// </summary>
    public override string LicenseString => """
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
""";
}
