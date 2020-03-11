// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Files.DataLake.Models;
using NUnit.Framework;

namespace Azure.Storage.Files.DataLake.Tests
{
    public class RemovePathAccessControlTestBase
    {
        public readonly string _entityId = "entityId";

        public void AssertRemovePathAccessControlEntryEquality(RemovePathAccessControlItem expected, RemovePathAccessControlItem actual)
        {
            Assert.AreEqual(expected.DefaultScope, actual.DefaultScope);
            Assert.AreEqual(expected.AccessControlType, actual.AccessControlType);
            Assert.AreEqual(expected.EntityId, actual.EntityId);
        }
    }
}
