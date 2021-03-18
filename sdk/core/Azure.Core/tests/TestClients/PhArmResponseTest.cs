// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Tests
{
    public class PhArmResponseTest<T> : ArmResponseTest<T>
    {
        protected PhArmResponseTest()
        {
        }

        public PhArmResponseTest(T value) : base(value)
        {
        }
    }
}
