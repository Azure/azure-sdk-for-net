// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Visitors;
using Microsoft.CodeAnalysis;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.ClientModel;
using System;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Azure.Core.Expressions.DataFactory;
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

    internal bool HasDataFactoryElement => _hasDataFactoryElement ??= BuildHasDataFactoryElement();
    private bool? _hasDataFactoryElement;
    internal const string DataFactoryElementIdentity = "Azure.Core.Expressions.DataFactoryElement";

    private bool BuildHasDataFactoryElement()
    {
        foreach (var model in InputLibrary.InputNamespace.Models)
        {
            foreach (var property in model.Properties)
            {
                if (property.Type.External?.Identity == DataFactoryElementIdentity)
                {
                    return true;
                }
            }
        }
        return false;
    }

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
        if (HasDataFactoryElement)
        {
            AddMetadataReference(MetadataReference.CreateFromFile(typeof(DataFactoryElement<>).Assembly.Location));
        }

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
        AddVisitor(new XmlSerializableVisitor());
        AddVisitor(new ClientSettingsVisitor());
    }

    /// <summary>
    /// Writes additional files for the Azure client SDK.
    /// Overrides the base implementation to use "AzureClients" section and "azureOptions"
    /// instead of the default "Clients" and "options", and suppresses the NuGet.targets
    /// file which is handled centrally by the Azure SDK build infrastructure.
    /// </summary>
    public override async Task WriteAdditionalFiles(string outputPath)
    {
        // Let the base generate ConfigurationSchema.json and NuGet.targets
        await base.WriteAdditionalFiles(outputPath);

        // Adjust ConfigurationSchema.json for Azure conventions
        var schemaPath = Path.Combine(outputPath, "schema", "ConfigurationSchema.json");
        if (File.Exists(schemaPath))
        {
            var json = JsonNode.Parse(await File.ReadAllTextAsync(schemaPath));
            if (json is JsonObject root)
            {
                AdjustSchemaForAzure(root);
                var options = new JsonSerializerOptions { WriteIndented = true };
                await File.WriteAllTextAsync(schemaPath, root.ToJsonString(options).ReplaceLineEndings("\n") + "\n");
            }
        }

        // Remove the NuGet.targets file — Azure SDK handles this centrally
        // via eng/ConfigurationSchema.targets and Directory.Build.Common.targets
        var targetsPath = Path.Combine(outputPath, $"{Configuration.PackageName}.NuGet.targets");
        if (File.Exists(targetsPath))
        {
            File.Delete(targetsPath);
        }
    }

    /// <summary>
    /// Adjusts the generated ConfigurationSchema.json for Azure SDK conventions:
    /// renames the "Clients" section to "AzureClients" and replaces references
    /// to the base "options" definition with "azureOptions".
    /// </summary>
    private static void AdjustSchemaForAzure(JsonObject root)
    {
        // Rename "Clients" → "AzureClients" in the top-level properties
        if (root["properties"] is JsonObject properties &&
            properties.ContainsKey("Clients"))
        {
            var clientsNode = properties["Clients"];
            properties.Remove("Clients");
            properties["AzureClients"] = clientsNode;
        }

        // Replace all $ref values from "#/definitions/options" to "#/definitions/azureOptions"
        ReplaceRefValues(root, "#/definitions/options", "#/definitions/azureOptions");
    }

    private static void ReplaceRefValues(JsonNode node, string oldRef, string newRef)
    {
        if (node is JsonObject obj)
        {
            if (obj.TryGetPropertyValue("$ref", out var refValue) &&
                refValue?.GetValue<string>() == oldRef)
            {
                obj["$ref"] = newRef;
            }

            foreach (var property in obj.ToArray())
            {
                if (property.Value != null)
                {
                    ReplaceRefValues(property.Value, oldRef, newRef);
                }
            }
        }
        else if (node is JsonArray array)
        {
            foreach (var item in array)
            {
                if (item != null)
                {
                    ReplaceRefValues(item, oldRef, newRef);
                }
            }
        }
    }
}