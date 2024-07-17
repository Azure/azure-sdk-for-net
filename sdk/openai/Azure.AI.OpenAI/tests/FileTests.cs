// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using OpenAI.Files;

namespace Azure.AI.OpenAI.Tests;

public class FileTests : AoaiTestBase<FileClient>
{
    public FileTests(bool isAsync) : base(isAsync)
    { }

    [Test]
    [Category("Smoke")]
    public void CanCreateClient() => Assert.That(GetTestClient(), Is.InstanceOf<FileClient>());

    [RecordedTest]
    public async Task CanUploadAndDeleteFiles()
    {
        FileClient client = GetTestClient();
        OpenAIFileInfo file = await client.UploadFileAsync(
            BinaryData.FromString("hello, world!"),
            "test_file_delete_me.txt",
            FileUploadPurpose.Assistants);
        Validate(file);
        bool deleted = await client.DeleteFileAsync(file);
        Assert.IsTrue(deleted);
    }

    [RecordedTest]
    public async Task CanListFiles()
    {
        FileClient client = GetTestClient();
        OpenAIFileInfoCollection files = await client.GetFilesAsync();
        Assert.That(files, Has.Count.GreaterThan(0));
    }
}
