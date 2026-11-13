// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.OpenAI.Files;

/// <summary> Represents the processing status of a file uploaded to the Azure OpenAI service. </summary>
public enum AzureOpenAIFileStatus
{
    /// <summary> The file status is not recognized by this version of the client library. </summary>
    Unknown,
    /// <summary> The file has been uploaded but processing has not yet started. </summary>
    Uploaded,
    /// <summary> The file is queued and awaiting processing. </summary>
    Pending,
    /// <summary> The file is currently being processed by the service. </summary>
    Running,
    /// <summary> The file has been successfully processed and is ready for use. </summary>
    Processed,
    /// <summary> An error occurred during file processing. </summary>
    Error,
    /// <summary> The file is in the process of being deleted. </summary>
    Deleting,
    /// <summary> The file has been deleted. </summary>
    Deleted
}
