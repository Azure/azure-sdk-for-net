// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework.Tests.MockClient;
using NUnit.Framework;

namespace Microsoft.ClientModel.TestFramework.Tests;

[NonParallelizable]
public class MultipartTests : FakeFileRecordedTestBase
{
    private readonly List<TestFile> _filesToDelete = [];

    public MultipartTests(bool isAsync)
        : base(isAsync, RecordedTestMode.Playback)
    {
    }

    [Test]
    [AsyncOnly]
    public async Task MultipartBoundaryMismatchDemonstration()
    {
        FakeFileClient client = GetProxiedFakeFileClient();

        string content = "Test file for boundary mismatch demonstration";
        var options = new FileUploadOptions { Purpose = "testing" };

        // Make the same logical request multiple times
        List<string> boundaries = [];
        
        for (int i = 0; i < 3; i++)
        {
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));
            
            // Each upload creates a new multipart request with a different boundary
            TestFile file = await client.UploadFileAsync(stream, "test-file.txt", options);
            Validate(file);
        }
    }

    [TearDown]
    protected void Cleanup()
    {
        // In a real client, you'd delete uploaded files
        // Here we just clear our tracking list
        _filesToDelete.Clear();
    }

    private void Validate(TestFile file)
    {
        Assert.That(file, Is.Not.Null);
        Assert.That(file.Id, Is.Not.Null.And.Not.Empty);
        Assert.That(file.Name, Is.Not.Null.And.Not.Empty);
        _filesToDelete.Add(file);
    }
}
