// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Tests
{
    public class PhArmOperationTest<T> : ArmOperationTest<T>
        where T : class
    {
        protected PhArmOperationTest()
        {
        }

        public PhArmOperationTest(T value) : base(value)
        {
        }
    }
}
