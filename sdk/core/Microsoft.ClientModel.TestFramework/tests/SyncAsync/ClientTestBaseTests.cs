// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Microsoft.ClientModel.TestFramework.Tests;

public class ClientTestBaseTests : ClientTestBase
{
    public ClientTestBaseTests(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    public void AllowsUsingSyncMethodsWithoutAsyncAlternative()
    {
        TestClient client = CreateProxyFromClient(new TestClient());
        var result = client.Method2();

        Assert.That(result, Is.EqualTo("Hello"));
    }

    [Test]
    public async Task CallsCorrectMethodBasedOnCtorArgument()
    {
        TestClient client = CreateProxyFromClient(new TestClient());
        var result = await client.MethodAsync(123);

        Assert.That(result, Is.EqualTo(IsAsync ? "Async 123 False" : "Sync 123 False"));
    }

    [Test]
    public async Task CallsCorrectGenericParameterMethodBasedOnCtorArgument()
    {
        TestClient client = CreateProxyFromClient(new TestClient());
        var result = await client.MethodGenericAsync(123);

        Assert.That(result, Is.EqualTo(IsAsync ? "Async 123 False" : "Sync 123 False"));
    }

    [Test]
    public async Task WorksWithCancellationToken()
    {
        TestClient client = CreateProxyFromClient(new TestClient());
        var result = await client.MethodAsync(123, new CancellationTokenSource().Token);

        Assert.That(result, Is.EqualTo(IsAsync ? "Async 123 True" : "Sync 123 True"));
    }

    [Test]
    public void ThrowsForInvalidClientTypes()
    {
        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => CreateProxyFromClient(new InvalidTestClient()));
        Assert.That(exception.Message, Is.EqualTo("Client type contains public non-virtual async method MethodAsync"));
    }

    [Test]
    public void ThrowsForSyncCallsInAsyncContext()
    {
        if (IsAsync)
        {
            TestClient client = CreateProxyFromClient(new TestClient());
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => client.Method(123));
            Assert.That(exception.Message, Is.EqualTo("Async method call expected for Method"));
        }
    }

    [Test]
    public void ThrowsWhenSyncMethodIsNotAvailable()
    {
        if (!IsAsync)
        {
            TestClient client = CreateProxyFromClient(new TestClient());
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => client.NoAlternativeAsync(123));
            Assert.That(exception.Message, Is.EqualTo("Unable to find a method with name NoAlternative and System.Int32,System.Threading.CancellationToken parameters." +
                            " Make sure both methods have the same signature including the cancellationToken parameter"));
        }
    }

    /// <summary>
    /// Validate the interceptor is ignored when we're using SyncOnly.
    /// </summary>
    [Test]
    [SyncOnly]
    public void SyncOnlyDoesNotIntercept()
    {
        TestClient client = CreateProxyFromClient(new TestClient());
        client.Method(42);
    }

    /// <summary>
    /// Ensure we can resolve sync/async methods that only vary based on
    /// generic type parameters.
    /// </summary>
    [Test]
    public async Task CustomUserSchemaPatternResolves()
    {
        TestClient client = CreateProxyFromClient(new TestClient());
        string responseDataPrefix = IsAsync ? "async" : "sync";
        const string arg = "genericArg";

        // Static schema
        ClientResult<string> staticData = await client.GetDataAsync<string>();
        Assert.That(staticData.GetRawResponse().ReasonPhrase, Is.EqualTo($"{responseDataPrefix} - static"));

        // Static schema with generic arg
        ClientResult<string> staticGenericData = await client.GetDataAsync<string>(arg);
        Assert.That(staticGenericData.GetRawResponse().ReasonPhrase, Is.EqualTo($"{responseDataPrefix} - static {arg}"));

        // Dynamic schema
        ClientResult<object> dynamicData = await client.GetDataAsync();
        Assert.That(dynamicData.GetRawResponse().ReasonPhrase, Is.EqualTo($"{responseDataPrefix} - dynamic"));
    }

    /// <summary>
    /// Ensure failures in sync/async methods that only vary based on
    /// generic type parameters are thrown correctly.
    /// </summary>
    [Test]
    public async Task CustomUserSchemaPatternThrows()
    {
        TestClient client = CreateProxyFromClient(new TestClient());
        string exceptionPrefix = IsAsync ? "async" : "sync";

        // Static schema
        try
        { await client.GetFailureAsync<string>(); }
        catch (InvalidOperationException ex)
        {
            Assert.That(ex.Message, Is.EqualTo($"{exceptionPrefix} - static"));
        }

        // Dynamic schema
        try
        { await client.GetFailureAsync(); }
        catch (InvalidOperationException ex)
        {
            Assert.That(ex.Message, Is.EqualTo($"{exceptionPrefix} - dynamic"));
        }
    }

    [Test]
    public async Task GetClientCallsAreAutoInstrumented()
    {
        TestClient client = CreateProxyFromClient(new TestClient());

        TestClient subClient = client.GetAnotherTestClient();
        var result = await subClient.MethodAsync(123);

        Assert.That(result, Is.EqualTo(IsAsync ? "Async 123 False" : "Sync 123 False"));
    }

    [Test]
    public async Task SubClientPropertyWithoutClientSuffixIsAutoInstrumented()
    {
        TestClient client = CreateProxyFromClient(new TestClient());

        AnotherType subClient = client.SubClientProperty;
        var result = await subClient.MethodAsync(123);

        Assert.That(result, Is.EqualTo(IsAsync ? "Async 123 False" : "Sync 123 False"));
    }

    [Test]
    public async Task SubClientWithoutClientSuffixIsAutoInstrumented()
    {
        TestClient client = CreateProxyFromClient(new TestClient());

        AnotherType subClient = client.GetAnotherType();
        var result = await subClient.MethodAsync(123);

        Assert.That(result, Is.EqualTo(IsAsync ? "Async 123 False" : "Sync 123 False"));
    }

    [Test]
    public void NonPublicSubClientPropertyCallsAreNotAutoInstrumented()
    {
        TestClient client = CreateProxyFromClient(new TestClient());

        InternalType subClient = client.GetInternalType();
        // should not throw
        var result = subClient.Method(123);
        Assert.That(result, Is.EqualTo("Sync 123 False"));
    }

    [Test]
    public void CanGetUninstrumentedClient()
    {
        var testClient = new TestClient();
        TestClient client = CreateProxyFromClient(testClient);

        Assert.That(GetOriginal(client), Is.SameAs(testClient));
    }
}
