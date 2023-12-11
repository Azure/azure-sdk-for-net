// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.AI.OpenAI;

public partial class Choice
{
    internal Choice(string text, int index, CompletionsLogProbabilityModel logProbabilityModel, CompletionsFinishReason finishReason)
    {
        Argument.AssertNotNull(text, nameof(text));
        // CUSTOM: pending codegen update for non-optional nullables, this needs to be manually
        //          allowed to be null.
        // Argument.AssertNotNull(logProbabilityModel, nameof(logProbabilityModel));

        Text = text;
        Index = index;
        LogProbabilityModel = logProbabilityModel;
        FinishReason = finishReason;
    }
}
