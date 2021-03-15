// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Tests
{
    public class ManagementTestOperations
    {
        public virtual ManagementTestOperations GetAnotherOperations()
        {
            return new ManagementTestOperations();
        }

        public virtual ArmOperationTest<ManagementTestOperations> GetArmOperation(CancellationToken cancellationToken = default)
        {
            return new ArmOperationTest<ManagementTestOperations>(new ManagementTestOperations());
        }

        public virtual Task<ArmOperationTest<ManagementTestOperations>> GetArmOperationAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(new ArmOperationTest<ManagementTestOperations>(new ManagementTestOperations()));
        }

        public virtual ArmResponseTest<ManagementTestOperations> GetArmResponse(CancellationToken cancellationToken = default)
        {
            return new ArmResponseTest<ManagementTestOperations>(new ManagementTestOperations());
        }

        public virtual Task<ArmResponseTest<ManagementTestOperations>> GetArmResponseAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(new ArmResponseTest<ManagementTestOperations>(new ManagementTestOperations()));
        }

        public virtual string Method()
        {
            return "success";
        }
    }
}
