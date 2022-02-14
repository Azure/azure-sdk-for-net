// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Core;

namespace Azure.Core.Tests
{
    public class TestResource : ArmResource
    {
        private DiagnosticScopeFactory _diagnostic = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true);

        public virtual TestResource GetAnotherOperations()
        {
            return new TestResource();
        }

        public virtual TestLroOperation GetLro(bool waitForCompletion, bool exceptionOnWait = false, CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResource.GetLro");
            scope.Start();

            try
            {
                var lro = new TestLroOperation(new TestResource(), exceptionOnWait);
                if (waitForCompletion)
                    lro.WaitForCompletion(cancellationToken);
                return lro;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual async Task<TestLroOperation> GetLroAsync(bool waitForCompletion, bool exceptionOnWait = false, CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResource.GetLro");
            scope.Start();

            try
            {
                var lro = new TestLroOperation(new TestResource(), exceptionOnWait);
                if (waitForCompletion)
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
        public async virtual Task<Response<TestResource>> GetForwardsCallTrueAsync(CancellationToken cancellationToken = default)
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
        public async virtual Task<Response<TestResource>> GetForwardsCallFalseAsync(CancellationToken cancellationToken = default)
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
        public async virtual Task<Response<TestResource>> GetForwardsCallDefaultAsync(CancellationToken cancellationToken = default)
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

        public virtual TestLroOperation GetLroException(bool waitForCompletion, CancellationToken cancellationToken = default)
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

        public virtual Task<TestLroOperation> GetLroExceptionAsync(bool waitForCompletion, CancellationToken cancellationToken = default)
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

        public virtual TestLroOperation StartLroWrapper(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResource.StartLroWrapper");
            scope.Start();

            try
            {
                var lro = new TestLroOperation(new TestResource());
                if (waitForCompletion)
                    lro.WaitForCompletion(cancellationToken);
                return lro;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual async Task<TestLroOperation> StartLroWrapperAsync(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResource.StartLroWrapper");
            scope.Start();

            try
            {
                var lro = new TestLroOperation(new TestResource());
                if (waitForCompletion)
                    await lro.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return lro;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual TestLroOperation StartLongLro(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResource.StartLongLro");
            scope.Start();

            try
            {
                var lro = new TestLroOperation(new TestResource(), delaySteps: 10);
                if (waitForCompletion)
                    lro.WaitForCompletion(cancellationToken);
                return lro;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public async virtual Task<TestLroOperation> StartLongLroAsync(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResource.StartLongLro");
            scope.Start();

            try
            {
                await Task.Delay(1);
                var lro = new TestLroOperation(new TestResource(), delaySteps: 10);
                if (waitForCompletion)
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
