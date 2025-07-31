// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Azure.Generator.Management
{
    internal class InputModelReplacement
    {
        private static readonly Lazy<InputModelReplacement> _instance = new Lazy<InputModelReplacement>(() => new InputModelReplacement());
        private IReadOnlyDictionary<string, CSharpType>? _modelIdToReplacementType;

        private InputModelReplacement()
        {
        }

        public static InputModelReplacement Instance => _instance.Value;

        private IReadOnlyDictionary<string, CSharpType> ModelIdToReplacementType => _modelIdToReplacementType ??= BuildModelReplacementMap();

        public bool TryFindModelReplacementType(string modelId, [NotNullWhen(true)] out CSharpType? replacementType)
        {
            return ModelIdToReplacementType.TryGetValue(modelId, out replacementType);
        }

        private Dictionary<string, CSharpType> BuildModelReplacementMap()
        {
            var map = new Dictionary<string, CSharpType>();
            var inputModels = ManagementClientGenerator.Instance.InputLibrary.InputNamespace.Models;
            foreach (var model in inputModels)
            {
                foreach (var rule in ReplacementRules)
                {
                    var replacementType = rule(model);
                    if (replacementType != null)
                    {
                        map[model.CrossLanguageDefinitionId] = replacementType;
                        break; // First hit wins
                    }
                }
            }
            return map;
        }

        private static readonly Func<InputModelType, Type?> SubResourceRule = model =>
        {
            // Check if this model should be replaced with SubResource
            // Logic from BuildSubResourcePlaceableModelsCache: models with single armResourceIdentifier property
            if (model.Properties.Count == 1)
            {
                var prop = model.Properties[0];
                if (prop.Type is InputPrimitiveType primitiveType &&
                    primitiveType.CrossLanguageDefinitionId == "Azure.Core.armResourceIdentifier")
                {
                    return typeof(SubResource);
                }
            }
            return null;
        };

        private static readonly List<Func<InputModelType, Type?>> ReplacementRules = new List<Func<InputModelType, Type?>>
        {
            SubResourceRule
            // TODO: Add more replacement rules as needed
        };
    }
}
