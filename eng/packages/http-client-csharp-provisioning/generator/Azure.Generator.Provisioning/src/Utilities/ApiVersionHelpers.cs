// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Provisioning.Utilities
{
    internal static class ApiVersionHelpers
    {
        internal static bool IsPreviewApiVersion(string version)
            => version.Contains("preview", StringComparison.OrdinalIgnoreCase);

        internal static IReadOnlyList<AttributeStatement> BuildExperimentalAttributes(IReadOnlyList<string> apiVersions)
            => apiVersions.Count > 0 && apiVersions.All(IsPreviewApiVersion)
                ? [new AttributeStatement(typeof(ExperimentalAttribute), [Literal("AZPROVISION001")])]
                : [];
    }
}
