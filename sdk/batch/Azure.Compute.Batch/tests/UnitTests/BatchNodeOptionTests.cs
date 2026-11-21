// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using NUnit.Framework;

namespace Azure.Compute.Batch.Tests.UnitTests
{
    public class BatchNodeOptionTests
    {
        [TestCase(typeof(BatchNodeDeallocateOption))]
        [TestCase(typeof(BatchNodeDeallocationOption))]
        [TestCase(typeof(BatchNodeRebootKind))]
        [TestCase(typeof(BatchNodeReimageOption))]
        public void RetainedDataIsNotExposed(Type optionType)
        {
            Assert.IsNull(optionType.GetProperty("RetainedData", BindingFlags.Public | BindingFlags.Static));
            Assert.IsNull(optionType.GetField("RetainedDataValue", BindingFlags.NonPublic | BindingFlags.Static));
            CollectionAssert.AreEquivalent(
                new[] { "requeue", "terminate", "taskcompletion" },
                Array.ConvertAll(
                    optionType.GetProperties(BindingFlags.Public | BindingFlags.Static),
                    property => property.GetValue(null).ToString()));
        }
    }
}
