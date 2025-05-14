// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator.Management
{
    /// <inheritdoc/>
    public class ManagementInputLibrary : InputLibrary
    {
        private IReadOnlyDictionary<string, InputModelType>? _inputModelsByCrossLanguageDefinitionId = null;
        private IReadOnlyDictionary<string, InputModelType> InputModelsByCrossLanguageDefinitionId => _inputModelsByCrossLanguageDefinitionId ??= InputNamespace.Models.DistinctBy(x => x.CrossLanguageDefinitionId).ToDictionary(m => m.CrossLanguageDefinitionId, m => m);

        /// <inheritdoc/>
        public ManagementInputLibrary(string configPath) : base(configPath)
        {
        }

        internal InputModelType? GetModelByCrossLanguageDefinitionId(string crossLanguageDefinitionId) => InputModelsByCrossLanguageDefinitionId.TryGetValue(crossLanguageDefinitionId, out var model) ? model : null;
    }
}
