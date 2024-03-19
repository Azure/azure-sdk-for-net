// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using ClientModel.Tests.Mocks;
using NUnit.Framework;
using SyncAsyncTestBase = ClientModel.Tests.SyncAsyncTestBase;

namespace System.ClientModel.Tests.Message;

internal class MultipartBinaryContentTests : SyncAsyncTestBase
{
    public MultipartBinaryContentTests(bool isAsync) : base(isAsync)
    {
    }

    // TODO: add boundary tests
    // Add other tests
    // Remove unneeded tests below

    [Test]
    public void BoundaryIsSeventyCharacters()
    {
        MultipartFormDataBinaryContent content = new();
        string contentType = content.ContentType!;
    }
}
