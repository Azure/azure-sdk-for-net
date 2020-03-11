// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Storage.Files.DataLake.Models;
using NUnit.Framework;

namespace Azure.Storage.Files.DataLake.Tests
{
    public class RemovePathAccessControlExtensionsTests : RemovePathAccessControlTestBase
    {
        [Test]
        public void SerializeRemoveAccessControlList()
        {
            // Arrange
            RemovePathAccessControlItem accessControlEntry = new RemovePathAccessControlItem(
                AccessControlType.User,
                true,
                _entityId);

            // Act
            string result = RemovePathAccessControlExtensions.ToAccessControlListString(new List<RemovePathAccessControlItem>()
            {
                accessControlEntry
            });

            // Assert
            Assert.AreEqual("default:user:entityId", result);

            // Act
            result = RemovePathAccessControlExtensions.ToAccessControlListString(new List<RemovePathAccessControlItem>()
            {
                accessControlEntry,
                new RemovePathAccessControlItem(
                    AccessControlType.Mask,
                    true),
            });

            // Assert
            Assert.AreEqual("default:user:entityId,default:mask", result);
        }

        [Test]
        public void SerializeRemoveAccessControlList_Invalid()
        {
            Assert.AreEqual(null, RemovePathAccessControlExtensions.ToAccessControlListString(null));
        }

        [Test]
        public void DeserializeRemoveAccessControlList()
        {
            // Arrange
            RemovePathAccessControlItem accessControlEntry = new RemovePathAccessControlItem(
                AccessControlType.User,
                true,
                _entityId);

            // Act
            IList<RemovePathAccessControlItem> list = RemovePathAccessControlExtensions.ParseAccessControlList("default:user:entityId");

            // Assert
            Assert.AreEqual(1, list.Count);
            AssertRemovePathAccessControlEntryEquality(accessControlEntry, list[0]);

            // Act
            list = RemovePathAccessControlExtensions.ParseAccessControlList("default:user:entityId,default:mask");

            // Assert
            Assert.AreEqual(2, list.Count);
            AssertRemovePathAccessControlEntryEquality(accessControlEntry, list[0]);
            AssertRemovePathAccessControlEntryEquality(new RemovePathAccessControlItem(
                    AccessControlType.Mask,
                    true),
                list[1]);
        }

        [Test]
        public void DeserializeRemoveAccessControlList_Invalid()
        {
            Assert.AreEqual(null, RemovePathAccessControlExtensions.ParseAccessControlList(null));
        }
    }
}
