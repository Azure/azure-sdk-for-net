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

            var modelsById = new Dictionary<string, InputModelType>(StringComparer.Ordinal);
            foreach (var model in InputNamespace.Models)
            {
                modelsById.TryAdd(model.CrossLanguageDefinitionId, model);
            }
            var methodsById = new Dictionary<string, ResourceMethod>(StringComparer.Ordinal);
            foreach (var resource in ArmProviderSchema.Resources)
            {
                foreach (var method in resource.Methods)
                {
                    methodsById.TryAdd(method.InputMethod.CrossLanguageDefinitionId, method);
                }
            }

            var projections = new List<ProvisioningResourceProjection>();
            if (arguments.TryGetValue("resourceProjections", out var projectionsData))
            {
                using var document = JsonDocument.Parse(projectionsData);
                foreach (var projectionElement in document.RootElement.EnumerateArray())
                {
                    projections.Add(ProvisioningResourceProjection.Deserialize(projectionElement, modelsById, methodsById));
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
