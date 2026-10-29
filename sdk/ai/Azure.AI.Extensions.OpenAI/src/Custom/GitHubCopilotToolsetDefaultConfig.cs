// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Extensions.OpenAI;
public partial class GitHubCopilotToolsetDefaultConfig
{
    /// <summary> Initializes a new instance of <see cref="GitHubCopilotToolsetDefaultConfig"/>. </summary>
    /// <param name="enabled"> Whether built-in tools are enabled by default. Defaults to true. </param>
    public GitHubCopilotToolsetDefaultConfig(bool? enabled) : this(enabled: enabled, additionalBinaryDataProperties: null)
    {
    }
}
