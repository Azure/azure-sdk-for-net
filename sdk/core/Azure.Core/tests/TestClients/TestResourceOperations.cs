// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core.Tests
{
    public class TestResourceOperations
    {
        private DiagnosticScopeFactory _diagnostic = new DiagnosticScopeFactory("Azure.Clients", "Microsoft.Azure.Core.Cool.Tests", true);

        public virtual TestResourceOperations GetAnotherOperations()
        {
            return new TestResourceOperations();
        }

        public virtual ArmOperationTest<TestResourceOperations> GetArmOperation(CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResourceOperations.GetArmOperation");
            scope.Start();

            try
            {
                return new ArmOperationTest<TestResourceOperations>(new TestResourceOperations());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual Task<ArmOperationTest<TestResourceOperations>> GetArmOperationAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResourceOperations.GetArmOperation");
            scope.Start();

            try
            {
                return Task.FromResult(new ArmOperationTest<TestResourceOperations>(new TestResourceOperations()));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual ArmResponseTest<TestResourceOperations> GetArmResponse(CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResourceOperations.GetArmResponse");
            scope.Start();

            try
            {
                return new ArmResponseTest<TestResourceOperations>(new TestResourceOperations());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual Task<ArmResponseTest<TestResourceOperations>> GetArmResponseAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResourceOperations.GetArmResponse");
            scope.Start();

            try
            {
                return Task.FromResult(new ArmResponseTest<TestResourceOperations>(new TestResourceOperations()));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual ArmOperationTest<TestResourceOperations> GetPhArmOperation(CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResourceOperations.GetPhArmOperation");
            scope.Start();

            try
            {
                return new PhArmOperationTest<TestResourceOperations>(new TestResourceOperations());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual Task<ArmOperationTest<TestResourceOperations>> GetPhArmOperationAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResourceOperations.GetPhArmOperation");
            scope.Start();

            try
            {
                return Task.FromResult<ArmOperationTest<TestResourceOperations>>(new PhArmOperationTest<TestResourceOperations>(new TestResourceOperations()));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual ArmResponseTest<TestResourceOperations> GetPhArmResponse(CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResourceOperations.GetPhArmResponse");
            scope.Start();

            try
            {
                return new PhArmResponseTest<TestResourceOperations>(new TestResourceOperations());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual Task<ArmResponseTest<TestResourceOperations>> GetPhArmResponseAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _diagnostic.CreateScope("TestResourceOperations.GetPhArmResponse");
            scope.Start();

            try
            {
                return Task.FromResult<ArmResponseTest<TestResourceOperations>>(new PhArmResponseTest<TestResourceOperations>(new TestResourceOperations()));
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
