// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

using Azure.AI.OpenAI.Files;

namespace Azure.AI.OpenAI;

#pragma warning disable CS0618

[Experimental("AOAI001")]
public static partial class AzureFileExtensions
{
    [Experimental("AOAI001")]
    public static FileStatus ToFileStatus(this AzureOpenAIFileStatus azureStatus)
    {
        return azureStatus switch
        {
            AzureOpenAIFileStatus.Uploaded => FileStatus.Uploaded,
            AzureOpenAIFileStatus.Processed => FileStatus.Processed,
            AzureOpenAIFileStatus.Error => FileStatus.Error,
            _ => (FileStatus)(-1 * Math.Abs(azureStatus.ToSerialString().GetHashCode()))
        };
    }

    [Experimental("AOAI001")]
    public static AzureOpenAIFileStatus ToAzureOpenAIFileStatus(this FileStatus fileStatus)
    {
        if (fileStatus == FileStatus.Uploaded) return AzureOpenAIFileStatus.Uploaded;
        if (fileStatus == FileStatus.Processed) return AzureOpenAIFileStatus.Processed;
        if (fileStatus == FileStatus.Error) return AzureOpenAIFileStatus.Error;

        List<AzureOpenAIFileStatus> otherEncodedStatuses =
            [
                AzureOpenAIFileStatus.Pending,
                AzureOpenAIFileStatus.Running,
                AzureOpenAIFileStatus.Deleting,
                AzureOpenAIFileStatus.Deleted,
            ];

        foreach (AzureOpenAIFileStatus otherEncodedStatus in otherEncodedStatuses)
        {
            if ((int)fileStatus == -1 * Math.Abs(otherEncodedStatus.ToSerialString().GetHashCode()))
            {
                return otherEncodedStatus;
            }
        }

        throw new ArgumentOutOfRangeException(nameof(fileStatus), (int)fileStatus, "Unknown AzureOpenAIFileStatus value.");
    }
}