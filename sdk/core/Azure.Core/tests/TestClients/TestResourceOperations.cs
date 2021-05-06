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

        public virtual ArmOperation<TestResource> GetPhArmOperation(CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResourceOperations.GetPhArmOperation");
            scope.Start();

            try
            {
                return new PhArmOperationTest<TestResource>(new TestResource());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual Task<ArmOperation<TestResource>> GetPhArmOperationAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResourceOperations.GetPhArmOperation");
            scope.Start();

            try
            {
                return Task.FromResult<ArmOperation<TestResource>>(new PhArmOperationTest<TestResource>(new TestResource()));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual ArmResponseTest<TestResource> GetPhArmResponse(CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResourceOperations.GetPhArmResponse");
            scope.Start();

            try
            {
                return new PhArmResponseTest<TestResource>(new TestResource());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual Task<ArmResponseTest<TestResource>> GetPhArmResponseAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResourceOperations.GetPhArmResponse");
            scope.Start();

            try
            {
                return Task.FromResult<ArmResponseTest<TestResource>>(new PhArmResponseTest<TestResource>(new TestResource()));
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

        public virtual string Method()
        {
            return "success";
        }
    }
}
