// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;

namespace Azure.Core.Tests
{
    public class TestResource : ArmResource
    {
        private DiagnosticScopeFactory _diagnostic = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true);

        protected override ResourceType ValidResourceType => ResourceIdentifier.Root.ResourceType;

        public virtual TestResource GetAnotherOperations()
        {
            return new TestResource();
        }

        public virtual TestLroOperation GetLro(bool exceptionOnWait = false, CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResource.GetLro");
            scope.Start();

            try
            {
                return new TestLroOperation(new TestResource(), exceptionOnWait);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual Task<TestLroOperation> GetLroAsync(bool exceptionOnWait = false, CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResource.GetLro");
            scope.Start();

            try
            {
                return Task.FromResult(new TestLroOperation(new TestResource(), exceptionOnWait));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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

        public virtual TestLroOperation GetLroException(CancellationToken cancellationToken = default)
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

        public virtual Task<TestLroOperation> GetLroExceptionAsync(CancellationToken cancellationToken = default)
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

        public virtual Response<TestResource> LroWrapper(CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResource.LroWrapper");
            scope.Start();

            try
            {
                var operation = StartLroWrapper(cancellationToken);
                return operation.WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual TestLroOperation StartLroWrapper(CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResource.StartLroWrapper");
            scope.Start();

            try
            {
                return new TestLroOperation(new TestResource());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual async Task<Response<TestResource>> LroWrapperAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResource.LroWrapper");
            scope.Start();

            try
            {
                var operation = await StartLroWrapperAsync(cancellationToken);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual async Task<TestLroOperation> StartLroWrapperAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResource.StartLroWrapper");
            scope.Start();

            try
            {
                await Task.Delay(1);
                return new TestLroOperation(new TestResource());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual Response<TestResource> LongLro(CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResource.LongLro");
            scope.Start();

            try
            {
                var operation = StartLongLro(cancellationToken);
                return operation.WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public async virtual Task<Response<TestResource>> LongLroAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResource.LongLro");
            scope.Start();

            try
            {
                var operation = await StartLongLroAsync(cancellationToken);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual TestLroOperation StartLongLro(CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResource.StartLongLro");
            scope.Start();

            try
            {
                return new TestLroOperation(new TestResource(), delaySteps: 10);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public async virtual Task<TestLroOperation> StartLongLroAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResource.StartLongLro");
            scope.Start();

            try
            {
                await Task.Delay(1);
                return new TestLroOperation(new TestResource(), delaySteps: 10);
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
