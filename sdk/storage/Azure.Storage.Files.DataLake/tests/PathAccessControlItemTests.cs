// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.Files.DataLake.Tests
{
    public class PathAccessControlItemTests : PathAccessControlTestBase
    {
        [Test]
        public void Constructor_Invalid()
        {
            TestHelper.AssertExpectedException(
            () => new PathAccessControlItem(AccessControlType.Other, RolePermissions.Read, entityId: _entityId),
            new ArgumentException("AccessControlType must be User or Group if entityId is specified.  Value is \"Other\""));
        }

        [Test]
        public void ToStringTest()
        {
            Assert.AreEqual("mask::rwx", new PathAccessControlItem(
                AccessControlType.Mask,
                permissions: _rolePermissions).ToString());

            Assert.AreEqual("user:entityId:rwx", new PathAccessControlItem(
                AccessControlType.User,
                permissions: _rolePermissions,
                entityId: _entityId).ToString());

            Assert.AreEqual("default:user:entityId:rwx", new PathAccessControlItem(
                AccessControlType.User,
                permissions: _rolePermissions,
                defaultScope: true,
                entityId: _entityId).ToString());
        }

        [Test]
        public void Parse()
        {
            AssertPathAccessControlEntryEquality(
                new PathAccessControlItem(
                    AccessControlType.Mask,
                    _rolePermissions),
                PathAccessControlItem.Parse("mask::rwx"));

            AssertPathAccessControlEntryEquality(
                new PathAccessControlItem(
                    AccessControlType.Mask,
                    _rolePermissions,
                    true),
                PathAccessControlItem.Parse("default:mask::rwx"));

            AssertPathAccessControlEntryEquality(
                new PathAccessControlItem(
                    AccessControlType.User,
                    _rolePermissions,
                    true,
                    _entityId),
                PathAccessControlItem.Parse("default:user:entityId:rwx"));
        }

        [Test]
        public void Parse_Invalid()
        {
            Assert.AreEqual(null, PathAccessControlItem.Parse(null));

            TestHelper.AssertExpectedException(
                () => PathAccessControlItem.Parse("a:b"),
                new ArgumentException("s should have 3 or 4 parts delimited by colons.  Value is \"a:b\""));

            TestHelper.AssertExpectedException(
                () => PathAccessControlItem.Parse("a:b:c:d:e"),
                new ArgumentException("s should have 3 or 4 parts delimited by colons.  Value is \"a:b:c:d:e\""));

            TestHelper.AssertExpectedException(
                () => PathAccessControlItem.Parse("a:b:c:d"),
                new ArgumentException("If s is 4 parts, the first must be \"default\".  Value is \"a:b:c:d\""));
        }
    }
}
