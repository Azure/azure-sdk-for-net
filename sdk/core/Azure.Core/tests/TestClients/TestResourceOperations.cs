// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;

namespace Azure.Core.Tests
{
    public class TestResourceOperations
    {
        private DiagnosticScopeFactory _diagnostic = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true);

        public virtual TestResourceOperations GetAnotherOperations()
        {
            return new TestResource();
        }

        public virtual ArmOperationTest GetArmOperation(bool exceptionOnWait = false, CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResourceOperations.GetArmOperation");
            scope.Start();

            try
            {
                return new ArmOperationTest(new TestResource(), exceptionOnWait);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual Task<ArmOperationTest> GetArmOperationAsync(bool exceptionOnWait = false, CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResourceOperations.GetArmOperation");
            scope.Start();

            try
            {
                return Task.FromResult(new ArmOperationTest(new TestResource(), exceptionOnWait));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual ArmResponseTest<TestResource> GetArmResponse(CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResourceOperations.GetArmResponse");
            scope.Start();

            try
            {
                return new ArmResponseTest<TestResource>(new TestResource());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual Task<ArmResponseTest<TestResource>> GetArmResponseAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResourceOperations.GetArmResponse");
            scope.Start();

            try
            {
                return Task.FromResult(new ArmResponseTest<TestResource>(new TestResource()));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual ArmResponseTest<TestResource> GetArmResponseException(CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResourceOperations.GetArmResponseException");
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

        public virtual Task<ArmResponseTest<TestResource>> GetArmResponseExceptionAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResourceOperations.GetArmResponseException");
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

        public virtual ArmOperationTest GetArmOperationException(CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResourceOperations.GetArmOperationException");
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

        public virtual Task<ArmOperationTest> GetArmOperationExceptionAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResourceOperations.GetArmOperationException");
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
            using var scope = _diagnostic.CreateScope("TestResourceOperations.LroWrapper");
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

        public virtual ArmOperationTest StartLroWrapper(CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResourceOperations.StartLroWrapper");
            scope.Start();

            try
            {
                return new ArmOperationTest(new TestResource());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual async Task<Response<TestResource>> LroWrapperAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResourceOperations.LroWrapper");
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

        public virtual async Task<ArmOperationTest> StartLroWrapperAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResourceOperations.StartLroWrapper");
            scope.Start();

            try
            {
                await Task.Delay(1);
                return new ArmOperationTest(new TestResource());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual Response<TestResource> LongLro(CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResourceOperations.LongLro");
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
            using var scope = _diagnostic.CreateScope("TestResourceOperations.LongLro");
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

        public virtual ArmOperationTest StartLongLro(CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResourceOperations.StartLongLro");
            scope.Start();

            try
            {
                return new ArmOperationTest(new TestResource(), delaySteps: 10);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public async virtual Task<ArmOperationTest> StartLongLroAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResourceOperations.StartLongLro");
            scope.Start();

            try
            {
                await Task.Delay(1);
                return new ArmOperationTest(new TestResource(), delaySteps: 10);
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
