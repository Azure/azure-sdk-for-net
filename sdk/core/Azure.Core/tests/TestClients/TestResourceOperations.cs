// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Tests
{
    public class TestResourceOperations
    {
        public virtual TestResourceOperations GetAnotherOperations()
        {
            return new TestResourceOperations();
        }

        public virtual ArmOperationTest<TestResourceOperations> GetArmOperation(CancellationToken cancellationToken = default)
        {
            return new ArmOperationTest<TestResourceOperations>(new TestResourceOperations());
        }

        public virtual Task<ArmOperationTest<TestResourceOperations>> GetArmOperationAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(new ArmOperationTest<TestResourceOperations>(new TestResourceOperations()));
        }

        public virtual ArmResponseTest<TestResourceOperations> GetArmResponse(CancellationToken cancellationToken = default)
        {
            return new ArmResponseTest<TestResourceOperations>(new TestResourceOperations());
        }

        public virtual Task<ArmResponseTest<TestResourceOperations>> GetArmResponseAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(new ArmResponseTest<TestResourceOperations>(new TestResourceOperations()));
        }

        public virtual ArmOperationTest<TestResourceOperations> GetPhArmOperation(CancellationToken cancellationToken = default)
        {
            return new PhArmOperationTest<TestResourceOperations>(new TestResourceOperations());
        }

        public virtual Task<ArmOperationTest<TestResourceOperations>> GetPhArmOperationAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult<ArmOperationTest<TestResourceOperations>>(new PhArmOperationTest<TestResourceOperations>(new TestResourceOperations()));
        }

        public virtual ArmResponseTest<TestResourceOperations> GetPhArmResponse(CancellationToken cancellationToken = default)
        {
            return new PhArmResponseTest<TestResourceOperations>(new TestResourceOperations());
        }

        public virtual Task<ArmResponseTest<TestResourceOperations>> GetPhArmResponseAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult<ArmResponseTest<TestResourceOperations>>(new PhArmResponseTest<TestResourceOperations>(new TestResourceOperations()));
        }

        public virtual string Method()
        {
            return "success";
        }
    }
}
