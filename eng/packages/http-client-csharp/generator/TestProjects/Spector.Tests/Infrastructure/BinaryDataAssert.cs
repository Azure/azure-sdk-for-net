// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace TestProjects.Spector.Tests
{
    public static class BinaryDataAssert
    {
        public static void AreEqual(BinaryData expected, BinaryData result)
        {
            CollectionAssert.AreEqual(expected?.ToArray(), result?.ToArray());
        }
    }
}