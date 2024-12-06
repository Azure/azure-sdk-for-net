// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.OpenAI.Files;

public enum AzureOpenAIFileStatus
{
    Unknown,
    Uploaded,
    Pending,
    Running,
    Processed,
    Error,
    Deleting,
    Deleted
}
