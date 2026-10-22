// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Extensions.OpenAI;
public partial class GitHubCopilotToolsetConfig
{
    /// <summary> Initializes a new instance of <see cref="GitHubCopilotToolsetConfig"/>. </summary>
    /// <param name="name"> The built-in tool to configure. </param>
    public GitHubCopilotToolsetConfig(GitHubCopilotBuiltInTool name)
    {
        Name = name;
    }
}
