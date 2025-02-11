// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.OpenAI.Files;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI;

[Experimental("AOAI001")]
public static partial class OpenAIFileExtensions
{
    [Experimental("AOAI001")]
    public static AzureOpenAIFileStatus GetAzureOpenAIFileStatus(this OpenAIFile file)
    {
        if (file is not AzureOpenAIFile azureFile)
        {
            throw new InvalidOperationException($"Azure OpenAI file status is only available on {nameof(OpenAIFile)} instances returned from a client configured for Azure OpenAI.");
        }
        return azureFile.Status.ToAzureOpenAIFileStatus();
    }
}