// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Snippets extracted from articles/batch/batch-task-output-files.md.
// Uses Azure.Storage.Blobs (BlobContainerClient) and Azure.Compute.Batch (OutputFile).

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Compute.Batch;
using Azure.Core;
using Azure.Storage.Blobs;
using Azure.Storage.Sas;

namespace BatchDocSamples;

internal static class TaskOutputFiles
{
    public static async Task CreateContainerAsync(BlobServiceClient storageAccount, string containerName)
    {
        #region Snippet:task_output_create_container
        BlobContainerClient container = storageAccount.GetBlobContainerClient(containerName);
        await container.CreateIfNotExistsAsync();
        #endregion
    }

    public static string BuildContainerSasUrl(BlobContainerClient container)
    {
        #region Snippet:task_output_container_sas
        BlobSasBuilder sasBuilder = new BlobSasBuilder(BlobContainerSasPermissions.Write, DateTimeOffset.UtcNow.AddDays(1))
        {
            BlobContainerName = container.Name,
            Resource = "c"
        };

        Uri containerSasUrl = container.GenerateSasUri(sasBuilder);
        #endregion
        return containerSasUrl.AbsoluteUri;
    }

    public static BatchTaskCreateOptions CreateTaskWithOutputFiles(string taskId, string containerSasUrl)
    {
        Uri containerSasUri = new Uri(containerSasUrl);
        #region Snippet:task_output_task_with_outputs
        BatchTaskCreateOptions task = new BatchTaskCreateOptions(taskId,
            "cmd /v:ON /c \"echo off && set && (FOR /L %i IN (1,1,100000) DO (ECHO !RANDOM!)) > output.txt\"")
        {
            OutputFiles =
            {
                new OutputFile(
                    filePattern: @"..\std*.txt",
                    destination: new OutputFileDestination()
                    {
                        Container = new OutputFileBlobContainerDestination(containerSasUri) { Path = taskId }
                    },
                    uploadOptions: new OutputFileUploadConfig(OutputFileUploadCondition.TaskCompletion)),
                new OutputFile(
                    filePattern: @"output.txt",
                    destination: new OutputFileDestination()
                    {
                        Container = new OutputFileBlobContainerDestination(containerSasUri) { Path = taskId + @"\output.txt" }
                    },
                    uploadOptions: new OutputFileUploadConfig(OutputFileUploadCondition.TaskCompletion)),
            }
        };
        #endregion
        return task;
    }

    public static BatchTaskCreateOptions CreateTaskWithOutputsManagedIdentity(
        string taskId,
        Uri containerUri,
        string identityResourceId)
    {
        #region Snippet:task_output_managed_identity
        BatchTaskCreateOptions task = new BatchTaskCreateOptions(taskId,
            "cmd /v:ON /c \"echo off && set && (FOR /L %i IN (1,1,100000) DO (ECHO !RANDOM!)) > output.txt\"")
        {
            OutputFiles =
            {
                new OutputFile(
                    filePattern: @"..\std*.txt",
                    destination: new OutputFileDestination()
                    {
                        Container = new OutputFileBlobContainerDestination(containerUri)
                        {
                            Path = taskId,
                            IdentityReference = new BatchNodeIdentityReference()
                            {
                                ResourceId = new ResourceIdentifier(identityResourceId)
                            }
                        }
                    },
                    uploadOptions: new OutputFileUploadConfig(OutputFileUploadCondition.TaskCompletion)),
            }
        };
        #endregion
        return task;
    }

    public static string ConventionsContainerName(string jobId)
    {
        #region Snippet:task_output_conventions_container_name
        // Convention used by Azure.Batch.Conventions.Files: "job-{jobId}".
        string containerName = $"job-{jobId.ToLowerInvariant()}";
        #endregion
        return containerName;
    }
}
