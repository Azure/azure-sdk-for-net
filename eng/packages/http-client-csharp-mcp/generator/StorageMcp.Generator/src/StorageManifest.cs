// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text.Json;
using System.Text.Json.Serialization;

namespace StorageMcp.Generator;

public sealed record StorageManifest(ToolSelection[] Operations, CompositeSelection[] Composites)
{
    public static StorageManifest Load(string path)
    {
        var manifest = JsonSerializer.Deserialize<StorageManifest>(File.ReadAllText(path), new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow,
            RespectRequiredConstructorParameters = true,
            RespectNullableAnnotations = true,
            AllowDuplicateProperties = false
        }) ?? throw new InvalidOperationException("The Storage manifest cannot be null.");
        manifest.Validate();
        return manifest;
    }

    public void Validate()
    {
        if (Operations is null || Operations.Length != 1)
        {
            throw new InvalidOperationException("This bounded pilot requires exactly one selected operation.");
        }

        var tool = Operations[0];
        if (tool is null || string.IsNullOrWhiteSpace(tool.OperationId) ||
            !Guid.TryParse(tool.Id, out _) || string.IsNullOrWhiteSpace(tool.Title))
        {
            throw new InvalidOperationException("Selected operations require an operation ID, GUID and title.");
        }

        if (tool.Group is null || !tool.Group.SequenceEqual(["storage", "blob", "container"]) || tool.Name != "create")
        {
            throw new InvalidOperationException("This pilot supports only the existing 'storage blob container create' path.");
        }

        if (tool.Binding != "blob-container-create-private")
        {
            throw new InvalidOperationException($"Unsupported SDK binding '{tool.Binding}'.");
        }

        if (tool.AmbientParameters is null || !tool.AmbientParameters.SequenceEqual(["account", "tenant"]))
        {
            throw new InvalidOperationException("The Storage create binding requires account and tenant ambient parameters, without subscription.");
        }

        if (tool.Safety is null)
        {
            throw new InvalidOperationException("A reviewed safety override object is required.");
        }

        if (Composites is null || Composites.Any(c => c is null ||
            string.IsNullOrWhiteSpace(c.Path) || string.IsNullOrWhiteSpace(c.Reason)) ||
            Composites.Select(c => c.Path).Distinct(StringComparer.Ordinal).Count() != Composites.Length ||
            Composites.Any(c => c.Path == string.Join(' ', tool.Group.Append(tool.Name))))
        {
            throw new InvalidOperationException("Composite exclusions require unique paths, reasons and no generated-path collision.");
        }
    }

    public void ValidateOperationIds(IEnumerable<string> availableIds)
    {
        foreach (var tool in Operations)
        {
            var count = availableIds.Count(id => id == tool.OperationId);
            if (count != 1)
            {
                throw new InvalidOperationException($"Selected operation '{tool.OperationId}' resolved {count} times; exactly one match is required.");
            }
        }
    }
}
