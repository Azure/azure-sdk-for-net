﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
/// The Azure client generator to generate the Azure client SDK.
/// </summary>
[Export(typeof(CodeModelGenerator))]
[ExportMetadata(GeneratorMetadataName, nameof(AzureClientGenerator))]
public class AzureClientGenerator : ScmCodeModelGenerator
{
    private static AzureClientGenerator? _instance;
    internal static AzureClientGenerator Instance => _instance ?? throw new InvalidOperationException("AzureClientGenerator is not loaded.");

    /// <inheritdoc/>
    public override AzureTypeFactory TypeFactory { get; }

    private AzureOutputLibrary? _azureOutputLibrary;
    /// <inheritdoc/>
    public override AzureOutputLibrary OutputLibrary => _azureOutputLibrary ??= new();

    /// <inheritdoc/>
    public override AzureInputLibrary InputLibrary { get; }

    /// <summary>
    /// Constructs the Azure client generator used to generate the Azure client SDK.
    /// </summary>
    /// <param name="context"></param>
    [ImportingConstructor]
    public AzureClientGenerator(GeneratorContext context) : base(context)
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
        var sharedSourceDirectory = Path.Combine(Path.GetDirectoryName(typeof(AzureClientGenerator).Assembly.Location)!, "Shared", "Core");
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
