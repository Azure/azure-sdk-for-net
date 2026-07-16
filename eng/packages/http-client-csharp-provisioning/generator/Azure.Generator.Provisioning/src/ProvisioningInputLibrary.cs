// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management;
using Azure.Generator.Management.Models;
using Azure.Generator.Provisioning.Primitives;
using Microsoft.TypeSpec.Generator.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Azure.Generator.Provisioning
{
    /// <summary>
    /// Input library for the provisioning generator.
    /// </summary>
    public class ProvisioningInputLibrary : ManagementInputLibrary
    {
        private const string ProvisioningProviderSchemaDecoratorName = "Azure.ClientGenerator.Core.@provisioningProviderSchema";
        private IReadOnlyList<ProvisioningResourceProjection>? _resourceProjections;
        private Dictionary<string, bool>? _modelSettableUsage;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProvisioningInputLibrary"/> class.
        /// </summary>
        /// <param name="configPath">The generator configuration path.</param>
        public ProvisioningInputLibrary(string configPath) : base(configPath)
        {
        }

        internal IReadOnlyList<ProvisioningResourceProjection> ResourceProjections
        {
            get
            {
                EnsureProvisioningMetadata();
                return _resourceProjections!;
            }
        }

        internal bool IsModelSettable(InputModelType model)
        {
            EnsureProvisioningMetadata();
            if (_modelSettableUsage!.TryGetValue(model.CrossLanguageDefinitionId, out var isSettable))
            {
                return isSettable;
            }

            throw new KeyNotFoundException($"Model '{model.Namespace}.{model.Name}' ('{model.CrossLanguageDefinitionId}') was not present in provisioning settable analysis.");
        }

        internal bool IsModelReachable(InputModelType model)
        {
            EnsureProvisioningMetadata();
            return _modelSettableUsage!.ContainsKey(model.CrossLanguageDefinitionId);
        }

        private void EnsureProvisioningMetadata()
        {
            if (_resourceProjections != null && _modelSettableUsage != null)
            {
                return;
            }

            var rootClient = InputNamespace.RootClients.FirstOrDefault()
                ?? throw new InvalidOperationException("The provisioning code model does not contain a root client.");
            var decorator = rootClient.Decorators.SingleOrDefault(d => d.Name == ProvisioningProviderSchemaDecoratorName)
                ?? throw new InvalidOperationException($"The provisioning code model does not contain the '{ProvisioningProviderSchemaDecoratorName}' decorator.");
            var arguments = decorator.Arguments
                ?? throw new InvalidOperationException($"The '{ProvisioningProviderSchemaDecoratorName}' decorator does not contain arguments.");

            var resourcesByIdPattern = ArmProviderSchema.Resources.ToDictionary(
                resource => resource.ResourceIdPattern.SerializedPath,
                StringComparer.Ordinal);
            var projections = new List<ProvisioningResourceProjection>();
            if (arguments.TryGetValue("resourceProjections", out var projectionsData))
            {
                using var document = JsonDocument.Parse(projectionsData);
                foreach (var projectionElement in document.RootElement.EnumerateArray())
                {
                    var resources = new List<ArmResourceMetadata>();
                    foreach (var resourceIdElement in projectionElement.GetProperty("resourceIdPatterns").EnumerateArray())
                    {
                        var resourceIdPattern = resourceIdElement.GetString()
                            ?? throw new JsonException("A provisioning resource ID pattern cannot be null.");
                        if (!resourcesByIdPattern.TryGetValue(resourceIdPattern, out var resource))
                        {
                            throw new JsonException($"Provisioning resource ID pattern '{resourceIdPattern}' was not found in the ARM provider schema.");
                        }
                        resources.Add(resource);
                    }
                    projections.Add(ProvisioningResourceProjection.Create(resources).Single());
                }
            }

            var modelSettableUsage = new Dictionary<string, bool>(StringComparer.Ordinal);
            if (arguments.TryGetValue("modelSettableUsage", out var usageData))
            {
                using var document = JsonDocument.Parse(usageData);
                foreach (var usageElement in document.RootElement.EnumerateArray())
                {
                    var modelId = usageElement.GetProperty("modelId").GetString()
                        ?? throw new JsonException("A provisioning model ID cannot be null.");
                    modelSettableUsage.Add(modelId, usageElement.GetProperty("isSettable").GetBoolean());
                }
            }

            _resourceProjections = projections;
            _modelSettableUsage = modelSettableUsage;
        }
    }
}
