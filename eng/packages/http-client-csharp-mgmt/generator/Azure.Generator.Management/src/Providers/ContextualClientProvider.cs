// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Azure.Generator.Management.Utilities;
using Microsoft.TypeSpec.Generator.Providers;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Azure.Generator.Management.Providers
{
    internal abstract class ContextualClientProvider : TypeProvider
    {
        private readonly RequestPathPattern _contextualRequestPattern;

        protected ContextualClientProvider(RequestPathPattern contextualRequestPattern) : base()
        {
            _contextualRequestPattern = contextualRequestPattern;
        }

        private IReadOnlyList<ContextualParameter>? _contextualParameters;
        internal IReadOnlyList<ContextualParameter> ContextualParameters => _contextualParameters ??= ContextualParameterBuilder.BuildContextualParameters(_contextualRequestPattern);

        private IReadOnlyDictionary<string, ContextualParameter>? _contextualParameterMap;
        internal bool TryGetContextualParameter(string parameterName, [NotNullWhen(true)] out ContextualParameter? contextualParameter)
        {
            _contextualParameterMap ??= ContextualParameters.ToDictionary(p => p.VariableName);
            return _contextualParameterMap.TryGetValue(parameterName, out contextualParameter);
        }
    }
}
