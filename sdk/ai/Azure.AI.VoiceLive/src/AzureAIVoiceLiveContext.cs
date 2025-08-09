// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;

namespace Azure.AI.VoiceLive
{
    [ModelReaderWriterBuildable(typeof(FunctionTool))]
    [ModelReaderWriterBuildable(typeof(ResponseUsageInputTokenDetails))]
    [ModelReaderWriterBuildable(typeof(ToolCall))]

    public partial class AzureAIVoiceLiveContext : ModelReaderWriterContext
    {
    }
}
