// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using Azure.AI.OpenAI.Files;

namespace Azure.AI.OpenAI;

/// <summary> Provides extension methods for <see cref="OpenAIFile"/> instances returned from Azure OpenAI. </summary>
[Experimental("AOAI001")]
public static partial class OpenAIFileExtensions
{
    /// <summary> Gets the Azure-specific file processing status for an <see cref="OpenAIFile"/> retrieved from Azure OpenAI. </summary>
    /// <param name="file"> The <see cref="OpenAIFile"/> instance to retrieve the status from. </param>
    /// <returns> The <see cref="AzureOpenAIFileStatus"/> representing the current processing state. </returns>
    /// <exception cref="InvalidOperationException"> Thrown when the file was not retrieved from an Azure OpenAI-configured client. </exception>
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
