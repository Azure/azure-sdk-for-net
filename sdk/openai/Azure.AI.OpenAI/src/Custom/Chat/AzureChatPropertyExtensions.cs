// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable AZC0112

namespace Azure.AI.OpenAI.Chat;

public static class AzureChatPropertyExtensions
{
    extension(ChatCompletionOptions source)
    {
        public IReadOnlyList<ChatDataSource> DataSources => source.GetDataSources();
    }
}