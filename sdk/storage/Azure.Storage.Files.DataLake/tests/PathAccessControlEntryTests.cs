// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.Files.DataLake.Tests
{
    public class PathAccessControlEntryTests : PathAccessControlTestBase
    {
        [Test]
        public void Constructor_Invalid()
        {
            TestHelper.AssertExpectedException(
            () => new PathAccessControlEntry(AccessControlType.Other, RolePermissions.Read, entityId: _entityId),
            new ArgumentException("AccessControlType must be User or Group if entityId is specified."));
        }

        [Test]
        public void ToStringTest()
        {
            Assert.AreEqual("mask::rwx", new PathAccessControlEntry(
                AccessControlType.Mask,
                permissions: _rolePermissions).ToString());

            Assert.AreEqual("user:entityId:rwx", new PathAccessControlEntry(
                AccessControlType.User,
                permissions: _rolePermissions,
                entityId: _entityId).ToString());

            Assert.AreEqual("default:user:entityId:rwx", new PathAccessControlEntry(
                AccessControlType.User,
                permissions: _rolePermissions,
                defaultScope: true,
                entityId: _entityId).ToString());
        }

        [Test]
        public void Parse()
        {
            AssertPathAccessControlEntryEquality(
                new PathAccessControlEntry(
                    AccessControlType.Mask,
                    _rolePermissions),
                PathAccessControlEntry.Parse("mask::rwx"));

            AssertPathAccessControlEntryEquality(
                new PathAccessControlEntry(
                    AccessControlType.Mask,
                    _rolePermissions,
                    true),
                PathAccessControlEntry.Parse("default:mask::rwx"));

            AssertPathAccessControlEntryEquality(
                new PathAccessControlEntry(
                    AccessControlType.User,
                    _rolePermissions,
                    true,
                    _entityId),
                PathAccessControlEntry.Parse("default:user:entityId:rwx"));
        }

        [Test]
        public void Parse_Invalid()
        {
            Assert.AreEqual(null, PathAccessControlEntry.Parse(null));

            TestHelper.AssertExpectedException(
                () => PathAccessControlEntry.Parse("a:b"),
                new ArgumentException("s should have 3 or 4 parts delimited by colons"));

            TestHelper.AssertExpectedException(
                () => PathAccessControlEntry.Parse("a:b:c:d:e"),
                new ArgumentException("s should have 3 or 4 parts delimited by colons"));

            TestHelper.AssertExpectedException(
                () => PathAccessControlEntry.Parse("a:b:c:d"),
                new ArgumentException("If s is 4 parts, the first must be \"default\""));
        }
    }
}
