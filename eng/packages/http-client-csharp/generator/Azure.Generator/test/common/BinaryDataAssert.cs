// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Generator.Tests.Common
{
    public static class BinaryDataAssert
    {
        public static void AreEqual(BinaryData expected, BinaryData result)
        {
            Assert.That(result?.ToArray(), Is.EqualTo(expected?.ToArray()));
        }
    }
}