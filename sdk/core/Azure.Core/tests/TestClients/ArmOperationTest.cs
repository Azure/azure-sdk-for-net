// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Tests
{
    public class ArmOperationTest<T>
    {
        protected ArmOperationTest()
        {
        }

        public ArmOperationTest(T value)
        {
            Value = value;
        }

        public virtual T Value { get; private set; }
    }
}
