// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using OpenAI.Files;
using OpenAI.TestFramework;

namespace Azure.AI.OpenAI.Tests;

public class FileTests : AoaiTestBase<OpenAIFileClient>
{
    public FileTests(bool isAsync) : base(isAsync)
    { }

#if !AZURE_OPENAI_GA

    [Test]
    [Category("Smoke")]
    public void CanCreateClient() => Assert.That(GetTestClient(), Is.InstanceOf<OpenAIFileClient>());

    [RecordedTest]
    public async Task CanUploadAndDeleteFiles()
    {
        OpenAIFileClient client = GetTestClient();
        OpenAIFile file = await client.UploadFileAsync(
            BinaryData.FromString("hello, world!"),
            "test_file_delete_me.txt",
            FileUploadPurpose.Assistants);
        Validate(file);
        FileDeletionResult deletionResult = await client.DeleteFileAsync(file.Id);
        Assert.That(deletionResult.FileId, Is.EqualTo(file.Id));
        Assert.IsTrue(deletionResult.Deleted);
    }

    [RecordedTest]
    public async Task CanListFiles()
    {
        OpenAIFileClient client = GetTestClient();
        OpenAIFileCollection files = await client.GetFilesAsync();
        Assert.That(files, Has.Count.GreaterThan(0));
    }

#else

    [Test]
    [SyncOnly]
    public void UnsupportedVersionFileClientThrows()
    {
        Assert.Throws<InvalidOperationException>(() => GetTestClient());
    }

#endif
}
