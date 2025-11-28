// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Visitors;
using Microsoft.CodeAnalysis;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.ClientModel;
using System;
using System.ComponentModel.Composition;
using System.IO;
using Azure.Generator.Providers;

namespace Azure.Generator;

/// <summary>
/// The Azure client generator to generate the Azure client SDK.
/// </summary>
[Export(typeof(CodeModelGenerator))]
[ExportMetadata(GeneratorMetadataName, nameof(AzureClientGenerator))]
public class AzureClientGenerator : ScmCodeModelGenerator
{
    private static AzureClientGenerator? _instance;
    internal static new AzureClientGenerator Instance => _instance ?? throw new InvalidOperationException("AzureClientGenerator is not loaded.");

    /// <inheritdoc/>
    public override AzureTypeFactory TypeFactory { get; }

    private AzureOutputLibrary? _azureOutputLibrary;
    /// <inheritdoc/>
    public override AzureOutputLibrary OutputLibrary => _azureOutputLibrary ??= new();

    internal RawRequestUriBuilderExtensionsDefinition RawRequestUriBuilderExtensionsDefinition { get; } = new();

    internal RequestHeaderExtensionsDefinition RequestHeaderExtensionsDefinition { get; } = new();

    /// <summary>
    /// Constructs the Azure client generator used to generate the Azure client SDK.
    /// </summary>
    /// <param name="context"></param>
    [ImportingConstructor]
    public AzureClientGenerator(GeneratorContext context) : base(context)
    {
        TypeFactory = new AzureTypeFactory();
        _instance = this;
    }

    /// <summary>
    /// Customize the generation output for Azure client SDK.
    /// </summary>
    protected override void Configure()
    {
        base.Configure();

        // Include Azure.Core
        AddMetadataReference(MetadataReference.CreateFromFile(typeof(Response).Assembly.Location));

        var sharedSourceDirectory = Path.Combine(Path.GetDirectoryName(typeof(AzureClientGenerator).Assembly.Location)!, "Shared", "Core");
        AddSharedSourceDirectory(sharedSourceDirectory);

        // Visitors that do any renaming must be added first so that any visitors relying on custom code view will have the CustomCodeView set.
        AddVisitor(new ModelFactoryRenamerVisitor());

        // Rest of the visitors can be added in any order.
        AddVisitor(new NamespaceVisitor());
        AddVisitor(new DistributedTracingVisitor());
        AddVisitor(new PipelinePropertyVisitor());
        AddVisitor(new LroVisitor());
        AddVisitor(new MatchConditionsHeadersVisitor());
        AddVisitor(new ClientRequestIdHeaderVisitor());
        AddVisitor(new SystemTextJsonConverterVisitor());
        AddVisitor(new MultiPartFormDataVisitor());
        AddVisitor(new InvokeDelimitedMethodVisitor());
    }
}