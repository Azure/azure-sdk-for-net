// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Extensions.OpenAI;
public partial class GitHubCopilotToolsetConfig
{
    /// <summary> Initializes a new instance of <see cref="GitHubCopilotToolsetConfig"/>. </summary>
    /// <param name="name"> The built-in tool to configure. </param>
    /// <param name="enabled"> Whether the built-in tool is enabled. If omitted, the toolset default applies. </param>
    public GitHubCopilotToolsetConfig(GitHubCopilotBuiltInTool name, bool? enabled = null) :this(
        name: name,
        enabled: enabled,
        additionalBinaryDataProperties: null
        )
    {
    }
}
