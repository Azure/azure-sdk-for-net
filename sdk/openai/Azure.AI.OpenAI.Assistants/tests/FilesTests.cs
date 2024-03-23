// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Assistants.Tests;

public class FilesTests : AssistantsTestBase
{
    public FilesTests(bool isAsync)
        : base(isAsync)//, RecordedTestMode.Live)
    {
    }

    [RecordedTest]
    [TestCase(OpenAIClientServiceTarget.NonAzure)]
    [TestCase(OpenAIClientServiceTarget.Azure)]
    public async Task CanWorkWithFiles(OpenAIClientServiceTarget target)
    {
        AssistantsClient client = GetTestClient(target);

        // Uploading a file should work
        OpenAIFile uploadedFile = null;
        using (TestRecording.DisableRecordingScope disableBodyRecordingScope = Recording.DisableRequestBodyRecording())
        {
            Response<OpenAIFile> uploadFileResponse = await client.UploadFileAsync(
                BinaryData.FromString("Hello, world! This is a test."),
                OpenAIFilePurpose.Assistants);
            AssertSuccessfulResponse(uploadFileResponse);
            EnsuredFileDeletions.Add((client, uploadFileResponse.Value.Id));
            uploadedFile = uploadFileResponse.Value;
        }

        // Listing files with no purpose filter should work, and our uploaded file should be there
        Response<IReadOnlyList<OpenAIFile>> listAllFilesResponse = await client.GetFilesAsync();
        AssertSuccessfulResponse(listAllFilesResponse);
        IReadOnlyList<OpenAIFile> allFiles = listAllFilesResponse.Value;
        Assert.That(allFiles.Any(file => file.Id == uploadedFile.Id));

        // Listing files with the same purpose should work, and our uploaded file should still be there
        Response<IReadOnlyList<OpenAIFile>> listMatchingPurposeFilesResponse
            = await client.GetFilesAsync(OpenAIFilePurpose.Assistants);
        AssertSuccessfulResponse(listMatchingPurposeFilesResponse);
        IReadOnlyList<OpenAIFile> matchingPurposeFiles = listMatchingPurposeFilesResponse.Value;
        Assert.That(matchingPurposeFiles.All(file => file.Purpose == OpenAIFilePurpose.Assistants));
        Assert.That(matchingPurposeFiles.Any(file => file.Id == uploadedFile.Id));

        // Listing files with a different purpose should work, and our uploaded file should not be there
        if (target != OpenAIClientServiceTarget.Azure)
        {
            Response<IReadOnlyList<OpenAIFile>> listNotMatchingPurposeFilesResponse
                = await client.GetFilesAsync(OpenAIFilePurpose.FineTuneResults);
            AssertSuccessfulResponse(listNotMatchingPurposeFilesResponse);
            IReadOnlyList<OpenAIFile> notMatchingPurposeFiles = listNotMatchingPurposeFilesResponse.Value;
            Assert.That(notMatchingPurposeFiles.All(file => file.Purpose == OpenAIFilePurpose.FineTuneResults));
            Assert.That(!notMatchingPurposeFiles.Any(file => file.Id == uploadedFile.Id));
        }

        // Retrieving file information should work
        Response<OpenAIFile> retrieveFileResponse = await client.GetFileAsync(uploadedFile.Id);
        AssertSuccessfulResponse(retrieveFileResponse);
        OpenAIFile retrievedFile = retrieveFileResponse.Value;
        Assert.That(retrievedFile.Id, Is.EqualTo(uploadedFile.Id));
        Assert.That(retrievedFile.Purpose, Is.EqualTo(uploadedFile.Purpose));

        // Note: can't retrieve Assistants file contents

        // Deleting a file should work
        Response<bool> fileDeleteResponse = await client.DeleteFileAsync(uploadedFile.Id);
        AssertSuccessfulResponse(fileDeleteResponse);
        Assert.That(fileDeleteResponse.Value, Is.True);
        EnsuredFileDeletions.Remove((client, uploadedFile.Id));
    }

    [RecordedTest]
    [TestCase(OpenAIClientServiceTarget.NonAzure)]
    [TestCase(OpenAIClientServiceTarget.Azure)]
    public async Task ConvenienceMethodWorks(OpenAIClientServiceTarget target)
    {
        AssistantsClient client = GetTestClient(target);

        string temporaryFilePath = Path.GetTempFileName();
        FileInfo temporaryFileInfo = new(temporaryFilePath);
        File.WriteAllText(temporaryFilePath, "Hello, world! This is a test. Please delete me.");

        OpenAIFile uploadedFile = null;
        using (TestRecording.DisableRecordingScope disableBodyRecordingScope = Recording.DisableRequestBodyRecording())
        {
            Response<OpenAIFile>  uploadFileResponse
                = await client.UploadFileAsync(temporaryFilePath, OpenAIFilePurpose.Assistants);
            AssertSuccessfulResponse(uploadFileResponse);
            EnsuredFileDeletions.Add((client, uploadFileResponse.Value.Id));
            uploadedFile = uploadFileResponse.Value;
        }

        if (Recording.Mode != RecordedTestMode.Playback)
        {
            Assert.That(uploadedFile.Filename, Is.EqualTo(temporaryFileInfo.Name));
        }
        Assert.That(uploadedFile.Size, Is.EqualTo(temporaryFileInfo.Length));
    }
}
