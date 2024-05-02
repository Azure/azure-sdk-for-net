// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using ClientModel.Tests.Mocks;
using NUnit.Framework;
using SyncAsyncTestBase = ClientModel.Tests.SyncAsyncTestBase;

namespace System.ClientModel.Tests.Results;

public class ClientResultCollectionTests : SyncAsyncTestBase
{
    public ClientResultCollectionTests(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    public async Task CreatesAsyncResultCollection()
    {
        MockPipelineResponse response = new();
        response.SetContent("[DONE]");

        AsyncClientResultCollection<MockJsonModel> results =
            AsyncClientResultCollection<MockJsonModel>.Create<MockJsonModel>(response);

        bool empty = true;
        await foreach (MockJsonModel result in results)
        {
            empty = false;
        }

        Assert.IsNotNull(results);
        Assert.AreEqual(results.GetRawResponse(), response);
        Assert.IsTrue(empty);
    }
}
