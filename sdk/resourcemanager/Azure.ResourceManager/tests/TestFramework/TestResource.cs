// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.Tests;
using Azure.ResourceManager;

namespace Azure.Core.TestFramework
{
    public class TestResource : ArmResource
    {
        private DiagnosticScopeFactory _diagnostic = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true, true, false);
        private static MockResponse mockResponse = new(200);
        private Func<MockResponse> mockResponseFactory = () => mockResponse;

        public virtual TestResource GetAnotherOperations()
        {
            return new TestResource();
        }

        public virtual MockOperation<TestResource> GetLro(WaitUntil waitUntil, bool exceptionOnWait = false, CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResource.GetLro");
            scope.Start();

            try
            {
                var updateResult = exceptionOnWait ? UpdateResult.Failure : UpdateResult.Pending;
                var lro = new MockOperation<TestResource>(new TestResource(), updateResult, mockResponseFactory, callsToComplete: 2);
                if (waitUntil == WaitUntil.Completed)
                    lro.WaitForCompletion(cancellationToken);
                return lro;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual async Task<MockOperation<TestResource>> GetLroAsync(WaitUntil waitUntil, bool exceptionOnWait = false, CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResource.GetLro");
            scope.Start();

            try
            {
                var updateResult = exceptionOnWait ? UpdateResult.Failure : UpdateResult.Pending;
                var lro = new MockOperation<TestResource>(new TestResource(), updateResult, mockResponseFactory, callsToComplete: 2);
                if (waitUntil == WaitUntil.Completed)
                    await lro.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return lro;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        [ForwardsClientCalls(true)]
        public virtual Response<TestResource> GetForwardsCallTrue(CancellationToken cancellationToken = default)
        {
            return Response.FromValue(new TestResource(), new MockResponse(200));
        }

        [ForwardsClientCalls(true)]
        public virtual async Task<Response<TestResource>> GetForwardsCallTrueAsync(CancellationToken cancellationToken = default)
        {
            await Task.Delay(1);
            return Response.FromValue(new TestResource(), new MockResponse(200));
        }

        [ForwardsClientCalls(false)]
        public virtual Response<TestResource> GetForwardsCallFalse(CancellationToken cancellationToken = default)
        {
            return Response.FromValue(new TestResource(), new MockResponse(200));
        }

        [ForwardsClientCalls(false)]
        public virtual async Task<Response<TestResource>> GetForwardsCallFalseAsync(CancellationToken cancellationToken = default)
        {
            await Task.Delay(1);
            return Response.FromValue(new TestResource(), new MockResponse(200));
        }

        [ForwardsClientCalls]
        public virtual Response<TestResource> GetForwardsCallDefault(CancellationToken cancellationToken = default)
        {
            return Response.FromValue(new TestResource(), new MockResponse(200));
        }

        [ForwardsClientCalls]
        public virtual async Task<Response<TestResource>> GetForwardsCallDefaultAsync(CancellationToken cancellationToken = default)
        {
            await Task.Delay(1);
            return Response.FromValue(new TestResource(), new MockResponse(200));
        }

        public virtual Response<TestResource> GetResponse(CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResource.GetResponse");
            scope.Start();

            try
            {
                return Response.FromValue(new TestResource(), new MockResponse(200));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public async virtual Task<Response<TestResource>> GetResponseAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResource.GetResponse");
            scope.Start();

            try
            {
                await Task.Delay(1);
                return Response.FromValue(new TestResource(), new MockResponse(200));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual Response<TestResource> GetResponseException(CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResource.GetResponseException");
            scope.Start();

            try
            {
                throw new ArgumentException("FakeArg");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual Task<Response<TestResource>> GetResponseExceptionAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResource.GetResponseException");
            scope.Start();

            try
            {
                throw new ArgumentException("FakeArg");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual TestResourceOperation GetLroException(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResource.GetLroException");
            scope.Start();

            try
            {
                throw new ArgumentException("FakeArg");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual Task<TestResourceOperation> GetLroExceptionAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResource.GetLroException");
            scope.Start();

            try
            {
                throw new ArgumentException("FakeArg");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual TestResourceOperation StartLroWrapper(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResource.StartLroWrapper");
            scope.Start();

            try
            {
                var lro = new TestResourceOperation(new TestResource());
                if (waitUntil == WaitUntil.Completed)
                    lro.WaitForCompletion(cancellationToken);
                return lro;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual async Task<TestResourceOperation> StartLroWrapperAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResource.StartLroWrapper");
            scope.Start();

            try
            {
                var lro = new TestResourceOperation(new TestResource());
                if (waitUntil == WaitUntil.Completed)
                    await lro.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return lro;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual TestResourceOperation StartLongLro(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResource.StartLongLro");
            scope.Start();

            try
            {
                var lro = new TestResourceOperation(new TestResource(), delaySteps: 10);
                if (waitUntil == WaitUntil.Completed)
                    lro.WaitForCompletion(cancellationToken);
                return lro;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual async Task<TestResourceOperation> StartLongLroAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResource.StartLongLro");
            scope.Start();

            try
            {
                await Task.Delay(1);
                var lro = new TestResourceOperation(new TestResource(), delaySteps: 10);
                if (waitUntil == WaitUntil.Completed)
                    await lro.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return lro;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual string Method()
        {
            return "success";
        }
    }
}
