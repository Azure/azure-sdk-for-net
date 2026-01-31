// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework.Mocks;

namespace Microsoft.ClientModel.TestFramework.Tests;

internal class TestClient
{
    public TestClient() : this(null)
    {
    }

    public TestClient(TestClientOptions options)
    {
        options ??= new TestClientOptions();
    }

    public virtual Task<string> MethodAsync(int i, CancellationToken cancellationToken = default)
    {
        return Task.FromResult("Async " + i + " " + cancellationToken.CanBeCanceled);
    }

    public virtual Task<string> MethodGenericAsync<T>(T i, CancellationToken cancellationToken = default)
    {
        return Task.FromResult($"Async {i} {cancellationToken.CanBeCanceled}");
    }

    public virtual string MethodGeneric<T>(T i, CancellationToken cancellationToken = default)
    {
        return $"Sync {i} {cancellationToken.CanBeCanceled}";
    }

    public virtual Task<string> NoAlternativeAsync(int i, CancellationToken cancellationToken = default)
    {
        return Task.FromResult("I don't have sync alternative");
    }

    public virtual string Method(int i, CancellationToken cancellationToken = default)
    {
        return "Sync " + i + " " + cancellationToken.CanBeCanceled;
    }

    public virtual string Method2()
    {
        return "Hello";
    }

    public virtual Task<ClientResult<T>> GetDataAsync<T>() =>
        Task.FromResult(ClientResult.FromOptionalValue(default(T), new MockPipelineResponse(200, "async - static")));
    public virtual ClientResult<T> GetData<T>(T arg) =>
        ClientResult.FromOptionalValue(default(T), new MockPipelineResponse(200, $"sync - static {arg}"));
    public virtual Task<ClientResult<T>> GetDataAsync<T>(T arg) =>
        Task.FromResult(ClientResult.FromOptionalValue(default(T), new MockPipelineResponse(200, $"async - static {arg}")));
    public virtual ClientResult<T> GetData<T>() =>
        ClientResult.FromOptionalValue(default(T), new MockPipelineResponse(200, "sync - static"));
    public virtual Task<ClientResult<object>> GetDataAsync() =>
        Task.FromResult(ClientResult.FromOptionalValue((object)null, new MockPipelineResponse(200, "async - dynamic")));
    public virtual ClientResult<object> GetData() =>
        ClientResult.FromOptionalValue((object)null, new MockPipelineResponse(200, "sync - dynamic"));

    public virtual Task<ClientResult<T>> GetFailureAsync<T>() =>
        throw new InvalidOperationException("async - static");
    public virtual ClientResult<T> GetFailure<T>() =>
        throw new InvalidOperationException("sync - static");
    public virtual Task<ClientResult<object>> GetFailureAsync() =>
        throw new InvalidOperationException("async - dynamic");
    public virtual ClientResult<object> GetFailure() =>
        throw new InvalidOperationException("sync - dynamic");

    public virtual TestClient GetAnotherTestClient()
    {
        return new TestClient();
    }

    public virtual TestClient GetInternalClient()
    {
        return new TestClient();
    }

    public virtual AnotherType SubClientProperty => new AnotherType();

    public virtual AnotherType GetAnotherType() => new AnotherType();

    public virtual InternalType GetInternalType() => new InternalType();
}

#pragma warning disable SA1402
public class AnotherType
#pragma warning restore SA1402
{
    public virtual ClientPipelineOptions Pipeline { get; }

    public virtual Task<string> MethodAsync(int i, CancellationToken cancellationToken = default)
    {
        return Task.FromResult("Async " + i + " " + cancellationToken.CanBeCanceled);
    }

    public virtual string Method(int i, CancellationToken cancellationToken = default)
    {
        return "Sync " + i + " " + cancellationToken.CanBeCanceled;
    }
}

#pragma warning disable SA1402
internal class InternalType
#pragma warning restore SA1402
{
    public virtual ClientPipeline Pipeline { get; }

    public virtual Task<string> MethodAsync(int i, CancellationToken cancellationToken = default)
    {
        return Task.FromResult("Async " + i + " " + cancellationToken.CanBeCanceled);
    }

    public virtual string Method(int i, CancellationToken cancellationToken = default)
    {
        return "Sync " + i + " " + cancellationToken.CanBeCanceled;
    }
}
