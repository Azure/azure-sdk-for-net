// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator
{
    /// <inheritdoc/>
    public class AzureInputLibrary : InputLibrary
    {
        private IReadOnlyDictionary<string, InputModelType>? _inputModelsByCrossLanguageDefinitionId = null;
        private IReadOnlyDictionary<string, InputModelType> InputModelsByCrossLanguageDefinitionId => _inputModelsByCrossLanguageDefinitionId ??= InputNamespace.Models.DistinctBy(x => x.CrossLanguageDefinitionId).ToDictionary(m => m.CrossLanguageDefinitionId, m => m);

        private IReadOnlyDictionary<string, InputModelType>? _inputModelsByName = null;
        private IReadOnlyDictionary<string, InputModelType> InputModelsByName => _inputModelsByName ??= InputNamespace.Models.ToDictionary(m => m.Name, m => m);

        /// <inheritdoc/>
        public AzureInputLibrary(string configPath) : base(configPath)
        {
        }

        internal InputModelType? GetModelByCrossLanguageDefinitionId(string crossLanguageDefinitionId) => InputModelsByCrossLanguageDefinitionId.TryGetValue(crossLanguageDefinitionId, out var model) ? model : null;

        internal InputModelType? GetModelByName(string name) => InputModelsByName.TryGetValue(name, out var model) ? model : null;
    }
}
