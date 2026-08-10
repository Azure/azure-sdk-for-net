// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Cdn.Models
{
    // Customization: Renames the generator-produced WebAgentKnowledgeSourcePatch back to the shipped name CdnWebAgentKnowledgeSourcePatch.
    // Reason: A csharp-scoped @@clientName override in the spec (KnowledgeSourceUpdateParameters -> "WebAgentKnowledgeSourcePatch")
    // drops the Cdn prefix that the mgmt generator's default {Resource}Patch auto-rename would produce now that csharp-scoped overrides are honored.
    // The spec-side override has been removed (azure-rest-api-specs follow-up PR); this customization can be deleted once tsp-location.yaml
    // is bumped to a commit that includes that spec fix.
    [CodeGenType("WebAgentKnowledgeSourcePatch")]
    public partial class CdnWebAgentKnowledgeSourcePatch
    { }
}
