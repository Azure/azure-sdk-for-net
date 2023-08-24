// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Serialization;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class MergePatchChangesTests
    {
        [Test]
        public void CanSetChanges()
        {
            MergePatchChanges changes = new(100);
            for (int i = 0; i < 100; i++)
            {
                Assert.IsFalse(changes.HasChanged(i), $"{i}");

                changes.SetChanged(i);

                Assert.IsTrue(changes.HasChanged(i), $"{i}");
            }
        }
    }
}
