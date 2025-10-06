// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

using Azure.AI.OpenAI.Files;

namespace Azure.AI.OpenAI;

internal static partial class AzureOpenAIFileStatusExtensions
{
    public static string ToSerialString(this AzureOpenAIFileStatus value) => value switch
    {
        AzureOpenAIFileStatus.Uploaded => "uploaded",
        AzureOpenAIFileStatus.Pending => "pending",
        AzureOpenAIFileStatus.Running => "running",
        AzureOpenAIFileStatus.Processed => "processed",
        AzureOpenAIFileStatus.Error => "error",
        AzureOpenAIFileStatus.Deleting => "deleting",
        AzureOpenAIFileStatus.Deleted => "deleted",
        _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown AzureOpenAIFileStatus value.")
    };

    public static AzureOpenAIFileStatus ToAzureOpenAIFileStatus(this string value)
    {
        if (StringComparer.OrdinalIgnoreCase.Equals(value, "uploaded")) return AzureOpenAIFileStatus.Uploaded;
        if (StringComparer.OrdinalIgnoreCase.Equals(value, "pending")) return AzureOpenAIFileStatus.Pending;
        if (StringComparer.OrdinalIgnoreCase.Equals(value, "running")) return AzureOpenAIFileStatus.Running;
        if (StringComparer.OrdinalIgnoreCase.Equals(value, "processed")) return AzureOpenAIFileStatus.Processed;
        if (StringComparer.OrdinalIgnoreCase.Equals(value, "error")) return AzureOpenAIFileStatus.Error;
        if (StringComparer.OrdinalIgnoreCase.Equals(value, "deleting")) return AzureOpenAIFileStatus.Deleting;
        if (StringComparer.OrdinalIgnoreCase.Equals(value, "deleted")) return AzureOpenAIFileStatus.Deleted;
        throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown AzureOpenAIFileStatus value.");
    }
}
