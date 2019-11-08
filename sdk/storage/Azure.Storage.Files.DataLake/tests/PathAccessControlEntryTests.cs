// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.Files.DataLake.Tests
{
    public class PathAccessControlEntryTests
    {
        private readonly string _entityId = "entityId";
        private readonly RolePermissions _rolePermissions = RolePermissions.Read | RolePermissions.Write | RolePermissions.Execute;

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
            Assert.AreEqual(
                new PathAccessControlEntry(
                    AccessControlType.Mask,
                    _rolePermissions),
                PathAccessControlEntry.Parse("mask::rwx"));

            Assert.AreEqual(
                new PathAccessControlEntry(
                    AccessControlType.Mask,
                    _rolePermissions,
                    true),
                PathAccessControlEntry.Parse("default:mask::rwx"));

            Assert.AreEqual(
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
                new ArgumentException("aclString should have 3 or 4 parts delimited by colons"));

            TestHelper.AssertExpectedException(
                () => PathAccessControlEntry.Parse("a:b:c:d:e"),
                new ArgumentException("aclString should have 3 or 4 parts delimited by colons"));

            TestHelper.AssertExpectedException(
                () => PathAccessControlEntry.Parse("a:b:c:d"),
                new ArgumentException("If aclString is 4 parts, the first must be \"default\""));
        }

        [Test]
        public void SerializeList()
        {
            // Arrange
            PathAccessControlEntry accessControlEntry = new PathAccessControlEntry(
                AccessControlType.User,
                _rolePermissions,
                true,
                _entityId);

            // Act
            string result = PathAccessControlEntry.SerializeList(new List<PathAccessControlEntry>()
            {
                accessControlEntry
            });

            // Assert
            Assert.AreEqual("default:user:entityId:rwx", result);

            // Act
            result = PathAccessControlEntry.SerializeList(new List<PathAccessControlEntry>()
            {
                accessControlEntry,
                new PathAccessControlEntry(
                    AccessControlType.Mask,
                    _rolePermissions,
                    true),
            });

            // Assert
            Assert.AreEqual("default:user:entityId:rwx,default:mask::rwx", result);
        }

        [Test]
        public void SerializeList_Invalid()
        {
            Assert.AreEqual(null, PathAccessControlEntry.SerializeList(null));
        }

        [Test]
        public void DeserializeList()
        {
            // Arrange
            PathAccessControlEntry accessControlEntry = new PathAccessControlEntry(
                AccessControlType.User,
                _rolePermissions,
                true,
                _entityId);

            // Act
            IList<PathAccessControlEntry> list = PathAccessControlEntry.DeserializeList("default:user:entityId:rwx");

            // Assert
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(accessControlEntry,list[0]);

            // Act
            list = PathAccessControlEntry.DeserializeList("default:user:entityId:rwx,default:mask::rwx");

            // Assert
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(accessControlEntry, list[0]);
            Assert.AreEqual(new PathAccessControlEntry(
                    AccessControlType.Mask,
                    _rolePermissions,
                    true),
                list[1]);
        }

        [Test]
        public void DeserializeList_Invalid()
        {
            Assert.AreEqual(null, PathAccessControlEntry.DeserializeList(null));
        }
    }
}
