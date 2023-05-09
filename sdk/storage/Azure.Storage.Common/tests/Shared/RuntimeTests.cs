// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.Storage
{
    public class RuntimeTests
    {
        [Test]
        public void RunsIn64BitProcess()
        {
            // Large payload tests don't like 32 bit processes. It's been an issue with net462 running 32bit by default, so guarding against it.
            Assert.IsTrue(System.Environment.Is64BitProcess);
        }
    }
}
