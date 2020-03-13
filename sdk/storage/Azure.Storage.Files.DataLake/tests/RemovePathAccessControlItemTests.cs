// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.Files.DataLake.Tests
{
    public class RemovePathAccessControlItemTests : RemovePathAccessControlTestBase
    {
        [Test]
        public void Constructor_Invalid()
        {
            TestHelper.AssertExpectedException(
            () => new RemovePathAccessControlItem(AccessControlType.Other, entityId: _entityId),
            new ArgumentException("AccessControlType must be User or Group if entityId is specified.  Value is \"Other\""));
        }

        [Test]
        public void ToStringTest()
        {
            Assert.AreEqual("mask", new RemovePathAccessControlItem(
                AccessControlType.Mask).ToString());

            Assert.AreEqual("default:user", new RemovePathAccessControlItem(
                AccessControlType.User,
                defaultScope: true).ToString());

            Assert.AreEqual("user:entityId", new RemovePathAccessControlItem(
                AccessControlType.User,
                entityId: _entityId).ToString());

            Assert.AreEqual("default:user:entityId", new RemovePathAccessControlItem(
                AccessControlType.User,
                defaultScope: true,
                entityId: _entityId).ToString());
        }

        [Test]
        public void Parse()
        {
            AssertRemovePathAccessControlEntryEquality(
                new RemovePathAccessControlItem(
                    AccessControlType.Mask),
                new RemovePathAccessControlItem("mask"));

            AssertRemovePathAccessControlEntryEquality(
                new RemovePathAccessControlItem(
                    AccessControlType.Mask),
                new RemovePathAccessControlItem("mask:"));

            AssertRemovePathAccessControlEntryEquality(
                new RemovePathAccessControlItem(
                    AccessControlType.Mask,
                    true),
                new RemovePathAccessControlItem("default:mask"));

            AssertRemovePathAccessControlEntryEquality(
                new RemovePathAccessControlItem(
                    AccessControlType.User,
                    true,
                    _entityId),
                new RemovePathAccessControlItem("default:user:entityId"));
        }

        [Test]
        public void Parse_Invalid()
        {
            Assert.AreEqual(null, PathAccessControlItem.Parse(null));

            TestHelper.AssertExpectedException(
                () => new RemovePathAccessControlItem(""),
                new ArgumentException("s must have 1 to 3 parts delimited by colons.  Value is \"\""));

            TestHelper.AssertExpectedException(
                () => new RemovePathAccessControlItem("a:b:c:d"),
                new ArgumentException("s must have 1 to 3 parts delimited by colons.  Value is \"a:b:c:d\""));

            TestHelper.AssertExpectedException(
                () => new RemovePathAccessControlItem("a:b:c"),
                new ArgumentException("If s is 3 parts, the first must be \"default\".  Value is \"a:b:c\""));
        }

        [Test]
        public void SerializeRemoveAccessControlList()
        {
            // Arrange
            RemovePathAccessControlItem accessControlEntry = new RemovePathAccessControlItem(
                AccessControlType.User,
                true,
                _entityId);

            // Act
            string result = RemovePathAccessControlItem.ToAccessControlListString(new List<RemovePathAccessControlItem>()
            {
                accessControlEntry
            });

            // Assert
            Assert.AreEqual("default:user:entityId", result);

            // Act
            result = RemovePathAccessControlItem.ToAccessControlListString(new List<RemovePathAccessControlItem>()
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
            Assert.AreEqual(null, RemovePathAccessControlItem.ToAccessControlListString(null));
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
            IList<RemovePathAccessControlItem> list = RemovePathAccessControlItem.ParseAccessControlList("default:user:entityId");

            // Assert
            Assert.AreEqual(1, list.Count);
            AssertRemovePathAccessControlEntryEquality(accessControlEntry, list[0]);

            // Act
            list = RemovePathAccessControlItem.ParseAccessControlList("default:user:entityId,default:mask");

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
            Assert.AreEqual(null, RemovePathAccessControlItem.ParseAccessControlList(null));
        }
    }
}
