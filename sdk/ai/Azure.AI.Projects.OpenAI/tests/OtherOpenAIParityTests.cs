// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.ClientModel;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI;
using OpenAI.Files;

namespace Azure.AI.Projects.OpenAI.Tests;

public class OtherOpenAIParityTests : ProjectsOpenAITestBase
{
    public OtherOpenAIParityTests(bool isAsync) : base(isAsync)
    {
    }

    [RecordedTest]
    [TestCase(OpenAIClientMode.UseExternalOpenAI, "assistants")]
    [TestCase(OpenAIClientMode.UseExternalOpenAI, "fine-tune")]
    [TestCase(OpenAIClientMode.UseFDPOpenAI, "assistants")]
    [TestCase(OpenAIClientMode.UseFDPOpenAI, "fine-tune")]
    public async Task FileUploadWorks(OpenAIClientMode clientMode, string rawPurpose)
    {
        OpenAIClient openAIClient = clientMode switch
        {
            OpenAIClientMode.UseExternalOpenAI => GetTestBaseOpenAIClient(),
            OpenAIClientMode.UseFDPOpenAI => GetTestProjectOpenAIClient(),
            _ => throw new NotImplementedException()
        };
        OpenAIFileClient fileClient = openAIClient.GetOpenAIFileClient();

        (string filename, string rawFileData) = rawPurpose switch
        {
            "assistants" => ("test_data_delete_me.txt", "hello, world"),
            "fine-tune" => ("test_data_delete_me.jsonl", @"{""messages"": [{""role"": ""system"", ""content"": """"}]}"),
            _ => throw new NotImplementedException()
        };

        OpenAIFile newFile = await fileClient.UploadFileAsync(BinaryData.FromString(rawFileData), filename, rawPurpose);
        Assert.That(newFile.SizeInBytesLong, Is.GreaterThan(0));
#pragma warning disable CS0618 // Status is obsolete
        Assert.That(newFile.Status, Is.EqualTo(FileStatus.Processed));
#pragma warning restore
        if (rawPurpose == "fine-tune" && clientMode == OpenAIClientMode.UseFDPOpenAI)
        {
            Assert.That(newFile.GetAzureFileStatus(), Is.EqualTo("pending"));
        }

        OpenAIFile retrievedFile = await fileClient.GetFileAsync(newFile.Id);
#pragma warning disable CS0618 // Status is obsolete
        Assert.That(retrievedFile.Status, Is.EqualTo(newFile.Status).Or.EqualTo(FileStatus.Uploaded));
#pragma warning restore

        if (rawPurpose == "fine-tune" && clientMode == OpenAIClientMode.UseFDPOpenAI)
        {
            Assert.That(retrievedFile.GetAzureFileStatus(), Is.EqualTo(newFile.GetAzureFileStatus()).Or.EqualTo("processed"));
        }
    }
}
