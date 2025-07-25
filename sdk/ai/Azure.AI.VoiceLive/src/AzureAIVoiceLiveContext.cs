// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;

namespace Azure.AI.VoiceLive
{
    [ModelReaderWriterBuildable(typeof(VoiceLiveFunctionTool))]
    [ModelReaderWriterBuildable(typeof(VoiceLiveResponseUsageInputTokenDetails))]
    [ModelReaderWriterBuildable(typeof(VoiceLiveTool))]

    public partial class AzureAIVoiceLiveContext : ModelReaderWriterContext
    {
    }
}
