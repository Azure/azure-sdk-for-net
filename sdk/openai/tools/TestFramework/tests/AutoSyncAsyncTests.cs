// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using NUnit.Framework;
using OpenAI.TestFramework.Tests.Helpers;

namespace OpenAI.TestFramework.Tests;

public class AutoSyncAsyncTests(bool useAsync) : ClientTestBase(useAsync)
{
    private static readonly string EX_MSG = Guid.NewGuid().ToString();

    [Test]
    [SyncOnly]
    public void OnlyInSyncMode()
    {
        Assert.That(IsAsync, Is.False);
    }

    [Test]
    [AsyncOnly]
    public void OnlyInAsyncMode()
    {
        Assert.That(IsAsync, Is.True);
    }

    [Test]
    public void CanGetOriginal()
    {
        MockClient original = new MockClient();

        MockClient instrumented = WrapClient(original);
        Assert.That(instrumented, Is.Not.Null);
        Assert.That(ReferenceEquals(original, instrumented), Is.False);
        Assert.That(typeof(MockClient).IsAssignableFrom(instrumented.GetType()), Is.True);

        MockClient recovered = UnWrap(instrumented);
        Assert.That(recovered, Is.Not.Null);
        Assert.That(ReferenceEquals(original, recovered), Is.True);
    }

    [Test]
    public void CanGetContext()
    {
        var context = new MockClientContext();

        MockClient client = WrapClient(new MockClient(), context);
        Assert.That(client, Is.Not.Null);

        var recoveredContext = GetClientContext(client) as MockClientContext;
        Assert.That(recoveredContext, Is.Not.Null);
        Assert.That(recoveredContext!.Id, Is.EqualTo(context.Id));
        Assert.That(ReferenceEquals(recoveredContext, context), Is.True);
    }

    [Test]
    public async Task TaskWorks()
    {
        MockClient client = WrapClient(new MockClient());
        await client.DoAsync();
        AssertCorrectFunctionCalled(client);
    }

    [Test]
    public void FailedTaskWorks()
    {
        MockClient client = WrapClient(new MockClient());
        ArgumentException? ex = Assert.ThrowsAsync<ArgumentException>(() => client.FailAsync(EX_MSG));
        Assert.That(ex, Is.Not.Null);
        Assert.That(ex!.Message, Is.EqualTo(EX_MSG));
        AssertCorrectFunctionCalled(client);
    }

    [Test]
    public async Task TaskWithResultWorks()
    {
        MockClient client = WrapClient(new MockClient());
        int count = await client.CountAsync();
        Assert.That(count, Is.EqualTo(IsAsync ? 12 : 5));
        AssertCorrectFunctionCalled(client);
    }

    [Test]
    public void FailedTaskWithResultWorks()
    {
        MockClient client = WrapClient(new MockClient());
        ArgumentException? ex = Assert.ThrowsAsync<ArgumentException>(() => client.FailWithResultAsync(EX_MSG));
        Assert.That(ex, Is.Not.Null);
        Assert.That(ex!.Message, Is.EqualTo(EX_MSG));
        AssertCorrectFunctionCalled(client);
    }

    [Test]
    public async Task ResultCollectionWorks()
    {
        const int num = 3;
        const int increment = 2;

        MockClient client = WrapClient(new MockClient());
        AsyncCollectionResult<int> coll = client.ResultCollectionAsync(num, increment);

        Assert.IsNotNull(coll);

        int numResults = 0;
        await foreach (int i in coll)
        {
            Assert.That(i, Is.EqualTo(numResults * increment));
            numResults++;
        }

        Assert.That(numResults, Is.EqualTo(num));
        AssertCorrectFunctionCalled(client);
    }

    [Test]
    public void FailedResultCollection()
    {
        MockClient client = WrapClient(new MockClient());

        // For now we mimic how the OpenAI and Azure OpenAI libraries work in that no service requests are sent
        // until we try to enumerate the async collections. So exceptions aren't expected initially
        AsyncCollectionResult<int> coll = client.FailResultCollectionAsync(EX_MSG);
        Assert.That(coll, Is.Not.Null);

        IAsyncEnumerator<int> enumerator = coll.GetAsyncEnumerator();
        Assert.That(enumerator, Is.Not.Null);
        ArgumentException? ex = Assert.ThrowsAsync<ArgumentException>(() => enumerator.MoveNextAsync().AsTask());
        Assert.That(ex, Is.Not.Null);
        Assert.That(ex!.Message, Is.EqualTo(EX_MSG));
        AssertCorrectFunctionCalled(client);
    }

    private void AssertCorrectFunctionCalled(MockClient client, int expectedCalls = 1)
    {
        if (IsAsync)
        {
            Assert.That(client.AsyncHit, Is.EqualTo(expectedCalls));
            Assert.That(client.SyncHit, Is.EqualTo(0));
        }
        else
        {
            Assert.That(client.AsyncHit, Is.EqualTo(0));
            Assert.That(client.SyncHit, Is.EqualTo(expectedCalls));
        }
    }
}
