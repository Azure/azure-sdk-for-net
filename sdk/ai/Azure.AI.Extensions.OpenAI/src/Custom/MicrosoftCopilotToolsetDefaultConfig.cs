// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Extensions.OpenAI;

public partial class MicrosoftCopilotToolsetDefaultConfig
{
    /// <summary> Initializes a new instance of <see cref="MicrosoftCopilotToolsetDefaultConfig"/>. </summary>
    /// <param name="enabled"> Whether built-in tools are enabled by default. Defaults to true. </param>
    public MicrosoftCopilotToolsetDefaultConfig(bool? enabled) : this(enabled: enabled, additionalBinaryDataProperties: null)
    {
    }
}
