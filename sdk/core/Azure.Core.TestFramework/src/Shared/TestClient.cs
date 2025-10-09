// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core.TestFramework
{
    internal class TestClient
    {
        private readonly ClientDiagnostics _diagnostics;

        public TestClient() : this(null)
        {
        }

        public TestClient(TestClientOptions options)
        {
            options ??= new TestClientOptions();
            _diagnostics = new ClientDiagnostics(options);
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

        // These four follow the new pattern for custom users schemas
        public virtual Task<Response<T>> GetDataAsync<T>() =>
            Task.FromResult(Response.FromValue(default(T), new MockResponse(200, "async - static")));
        public virtual Response<T> GetData<T>(T arg) =>
            Response.FromValue(default(T), new MockResponse(200, $"sync - static {arg}"));
        public virtual Task<Response<T>> GetDataAsync<T>(T arg) =>
            Task.FromResult(Response.FromValue(default(T), new MockResponse(200, $"async - static {arg}")));
        public virtual Response<T> GetData<T>() =>
            Response.FromValue(default(T), new MockResponse(200, "sync - static"));
        public virtual Task<Response<object>> GetDataAsync() =>
            Task.FromResult(Response.FromValue((object)null, new MockResponse(200, "async - dynamic")));
        public virtual Response<object> GetData() =>
            Response.FromValue((object)null, new MockResponse(200, "sync - dynamic"));

        // These four follow the new pattern for custom users schemas and
        // throw exceptions
        public virtual Task<Response<T>> GetFailureAsync<T>() =>
            throw new InvalidOperationException("async - static");
        public virtual Response<T> GetFailure<T>() =>
            throw new InvalidOperationException("sync - static");
        public virtual Task<Response<object>> GetFailureAsync() =>
            throw new InvalidOperationException("async - dynamic");
        public virtual Response<object> GetFailure() =>
            throw new InvalidOperationException("sync - dynamic");

        public virtual TestClient GetAnotherTestClient()
        {
            return new TestClient();
        }
        public virtual TestClientOperations SubProperty => new TestClientOperations();

        public virtual AnotherType SubClientProperty => new AnotherType();

        public virtual AnotherType GetAnotherType() => new AnotherType();

        public virtual string MethodA()
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TestClient)}.{nameof(MethodA)}");
            scope.Start();

            return nameof(MethodA);
        }

        public virtual async Task<string> MethodAAsync()
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TestClient)}.{nameof(MethodA)}");
            scope.Start();

            await Task.Yield();
            return nameof(MethodAAsync);
        }

        public virtual string MethodB()
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TestClient)}.{nameof(MethodB)}");
            scope.Start();

            return nameof(MethodB);
        }

        public virtual async Task<string> MethodBAsync()
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(TestClient)}.{nameof(MethodB)}");
            scope.Start();

            await Task.Yield();
            return nameof(MethodAAsync);
        }
    }

#pragma warning disable SA1402
    internal class AnotherType
#pragma warning restore SA1402
    {
        public virtual HttpPipeline Pipeline { get; }

        public virtual Task<string> MethodAsync(int i, CancellationToken cancellationToken = default)
        {
            return Task.FromResult("Async " + i + " " + cancellationToken.CanBeCanceled);
        }

        public virtual string Method(int i, CancellationToken cancellationToken = default)
        {
            return "Sync " + i + " " + cancellationToken.CanBeCanceled;
        }
    }
}
