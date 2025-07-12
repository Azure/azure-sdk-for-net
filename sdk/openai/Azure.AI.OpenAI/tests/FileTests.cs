// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using OpenAI.Files;
using OpenAI.TestFramework;

using Azure.AI.OpenAI.Files;

namespace Azure.AI.OpenAI.Tests;

public class FileTests : AoaiTestBase<OpenAIFileClient>
{
    public FileTests(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    [Category("Smoke")]
    public void CanCreateClient() => Assert.That(GetTestClient(), Is.InstanceOf<OpenAIFileClient>());

    [RecordedTest]
#if !AZURE_OPENAI_GA
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_10_01_Preview)]
    //[TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_12_01_Preview)]
    //[TestCase(AzureOpenAIClientOptions.ServiceVersion.V2025_01_01_Preview)]
#else
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_10_21)]
#endif
    [TestCase(null)]
    public async Task CanUploadAndDeleteFiles(AzureOpenAIClientOptions.ServiceVersion? version)
    {
        OpenAIFileClient client = GetTestClient(GetTestClientOptions(version));
        OpenAIFile file = await client.UploadFileAsync(
            BinaryData.FromString("hello, world!"),
            "test_file_delete_me.txt",
            FileUploadPurpose.Assistants);
        Validate(file);
        FileDeletionResult deletionResult = await client.DeleteFileAsync(file.Id);
        Assert.That(deletionResult.FileId, Is.EqualTo(file.Id));
        Assert.IsTrue(deletionResult.Deleted);

        file = await client.UploadFileAsync(
            BinaryData.FromString(@"{""text"":""hello, world!""}"),
            "test_file_delete_me.jsonl",
            FileUploadPurpose.Batch);
        Validate(file);
    }

    [RecordedTest]
#if !AZURE_OPENAI_GA
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_10_01_Preview)]
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_12_01_Preview)]
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2025_01_01_Preview)]
#else
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_10_21)]
#endif
    [TestCase(null)]
    public async Task CanListFiles(AzureOpenAIClientOptions.ServiceVersion? version)
    {
        OpenAIFileClient client = GetTestClient(GetTestClientOptions(version));
        OpenAIFileCollection files = await client.GetFilesAsync();
        Assert.That(files, Has.Count.GreaterThan(0));
    }

    [RecordedTest]
    [TestCase(null)]
    public async Task CanUploadWithExpiration(AzureOpenAIClientOptions.ServiceVersion? version)
    {
        OpenAIFileClient client = GetTestClient(GetTestClientOptions(version));
        AzureFileExpirationOptions expirationOptions = new(3600, AzureFileExpirationAnchor.CreatedAt);
        OpenAIFile file = await client.UploadFileAsync(
            BinaryData.FromString(@"{""text"":""hello, there, world!""}"),
            "test_file_delete_me_please.jsonl",
            FileUploadPurpose.Batch,
            expirationOptions);
        Validate(file);
        Assert.That(file.GetAzureOpenAIFileStatus(), Is.EqualTo(AzureOpenAIFileStatus.Processed));
    }

    private static TestClientOptions GetTestClientOptions(AzureOpenAIClientOptions.ServiceVersion? version)
    {
        return version is null ? new TestClientOptions() : new TestClientOptions(version.Value);
    }
}
