// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
                RemovePathAccessControlItem.Parse("mask"));

            AssertRemovePathAccessControlEntryEquality(
                new RemovePathAccessControlItem(
                    AccessControlType.Mask),
                RemovePathAccessControlItem.Parse("mask:"));

            AssertRemovePathAccessControlEntryEquality(
                new RemovePathAccessControlItem(
                    AccessControlType.Mask,
                    true),
                RemovePathAccessControlItem.Parse("default:mask"));

            AssertRemovePathAccessControlEntryEquality(
                new RemovePathAccessControlItem(
                    AccessControlType.User,
                    true,
                    _entityId),
                RemovePathAccessControlItem.Parse("default:user:entityId"));
        }

        [Test]
        public void Parse_Invalid()
        {
            Assert.AreEqual(null, PathAccessControlItem.Parse(null));

            TestHelper.AssertExpectedException(
                () => RemovePathAccessControlItem.Parse(""),
                new ArgumentException("s is invalid"));

            TestHelper.AssertExpectedException(
                () => RemovePathAccessControlItem.Parse("a:b:c:d"),
                new ArgumentException("s should have 1 to 3 parts delimited by colons.  Value is \"a:b:c:d\""));

            TestHelper.AssertExpectedException(
                () => RemovePathAccessControlItem.Parse("a:b:c"),
                new ArgumentException("If s is 3 parts, the first must be \"default\".  Value is \"a:b:c\""));
        }
    }
}
