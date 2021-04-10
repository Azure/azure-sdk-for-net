// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.Files.DataLake.Tests
{
    public class PathAccessControlExtensionsTests : PathAccessControlTestBase
    {
        [Test]
        public void ParseOctal()
        {
            Assert.AreEqual(RolePermissions.None, PathAccessControlExtensions.ParseOctalRolePermissions('0'));
            Assert.AreEqual(RolePermissions.Execute, PathAccessControlExtensions.ParseOctalRolePermissions('1'));
            Assert.AreEqual(RolePermissions.Write, PathAccessControlExtensions.ParseOctalRolePermissions('2'));
            Assert.AreEqual(RolePermissions.Read, PathAccessControlExtensions.ParseOctalRolePermissions('4'));
            Assert.AreEqual(RolePermissions.Execute | RolePermissions.Write, PathAccessControlExtensions.ParseOctalRolePermissions('3'));
            Assert.AreEqual(RolePermissions.Read | RolePermissions.Execute, PathAccessControlExtensions.ParseOctalRolePermissions('5'));
            Assert.AreEqual(RolePermissions.Read | RolePermissions.Write, PathAccessControlExtensions.ParseOctalRolePermissions('6'));
            Assert.AreEqual(RolePermissions.Read | RolePermissions.Write | RolePermissions.Execute, PathAccessControlExtensions.ParseOctalRolePermissions('7'));
        }

        [Test]
        public void ParseOctal_OutOfRange()
        {
            TestHelper.AssertExpectedException(
                () => PathAccessControlExtensions.ParseOctalRolePermissions('/'),
                new ArgumentOutOfRangeException("c", "Value must be between 0 and 7 inclusive, not -1"));

            TestHelper.AssertExpectedException(
                () => PathAccessControlExtensions.ParseOctalRolePermissions('8'),
                new ArgumentOutOfRangeException("c", "Value must be between 0 and 7 inclusive, not 8"));
        }

        [Test]
        public void ParseSymbolic_NoSticky()
        {
            Assert.AreEqual(RolePermissions.None, PathAccessControlExtensions.ParseSymbolicRolePermissions("---"));
            Assert.AreEqual(RolePermissions.Execute, PathAccessControlExtensions.ParseSymbolicRolePermissions("--x"));
            Assert.AreEqual(RolePermissions.Write, PathAccessControlExtensions.ParseSymbolicRolePermissions("-w-"));
            Assert.AreEqual(RolePermissions.Read, PathAccessControlExtensions.ParseSymbolicRolePermissions("r--"));
            Assert.AreEqual(RolePermissions.Write | RolePermissions.Execute, PathAccessControlExtensions.ParseSymbolicRolePermissions("-wx"));
            Assert.AreEqual(RolePermissions.Read | RolePermissions.Execute, PathAccessControlExtensions.ParseSymbolicRolePermissions("r-x"));
            Assert.AreEqual(RolePermissions.Read | RolePermissions.Write, PathAccessControlExtensions.ParseSymbolicRolePermissions("rw-"));
            Assert.AreEqual(RolePermissions.Read | RolePermissions.Write | RolePermissions.Execute, PathAccessControlExtensions.ParseSymbolicRolePermissions("rwx", false));
        }

        [Test]
        public void ParseSymbolic_NoSticky_InvalidCharacters()
        {
            TestHelper.AssertExpectedException(
                () => PathAccessControlExtensions.ParseSymbolicRolePermissions(null),
                new ArgumentNullException("s"));

            TestHelper.AssertExpectedException(
                () => PathAccessControlExtensions.ParseSymbolicRolePermissions("a--"),
                new ArgumentException("Role permission contains an invalid character.  Value is \"a--\""));

            TestHelper.AssertExpectedException(
                () => PathAccessControlExtensions.ParseSymbolicRolePermissions("-a-"),
                new ArgumentException("Role permission contains an invalid character.  Value is \"-a-\""));

            TestHelper.AssertExpectedException(
                () => PathAccessControlExtensions.ParseSymbolicRolePermissions("--a"),
                new ArgumentException("Role permission contains an invalid character.  Value is \"--a\""));

            TestHelper.AssertExpectedException(
                () => PathAccessControlExtensions.ParseSymbolicRolePermissions("-"),
                new ArgumentException("Role permission must be 3 characters.  Value is \"-\""));

            TestHelper.AssertExpectedException(
                () => PathAccessControlExtensions.ParseSymbolicRolePermissions("----"),
                new ArgumentException("Role permission must be 3 characters.  Value is \"----\""));
        }

        [Test]
        public void ParseSymbolic_Sticky()
        {
            Assert.AreEqual(RolePermissions.None, PathAccessControlExtensions.ParseSymbolicRolePermissions("---", true));
            Assert.AreEqual(RolePermissions.Execute, PathAccessControlExtensions.ParseSymbolicRolePermissions("--x", true));
            Assert.AreEqual(RolePermissions.Write, PathAccessControlExtensions.ParseSymbolicRolePermissions("-w-", true));
            Assert.AreEqual(RolePermissions.Read, PathAccessControlExtensions.ParseSymbolicRolePermissions("r--", true));
            Assert.AreEqual(RolePermissions.Write | RolePermissions.Execute, PathAccessControlExtensions.ParseSymbolicRolePermissions("-wx", true));
            Assert.AreEqual(RolePermissions.Read | RolePermissions.Execute, PathAccessControlExtensions.ParseSymbolicRolePermissions("r-x", true));
            Assert.AreEqual(RolePermissions.Read | RolePermissions.Write, PathAccessControlExtensions.ParseSymbolicRolePermissions("rw-", true));
            Assert.AreEqual(RolePermissions.Read | RolePermissions.Write | RolePermissions.Execute, PathAccessControlExtensions.ParseSymbolicRolePermissions("rwx", true));

            Assert.AreEqual(RolePermissions.Execute, PathAccessControlExtensions.ParseSymbolicRolePermissions("--t", true));
            Assert.AreEqual(RolePermissions.Write | RolePermissions.Execute, PathAccessControlExtensions.ParseSymbolicRolePermissions("-wt", true));
            Assert.AreEqual(RolePermissions.Read | RolePermissions.Execute, PathAccessControlExtensions.ParseSymbolicRolePermissions("r-t", true));
            Assert.AreEqual(RolePermissions.Read | RolePermissions.Write | RolePermissions.Execute, PathAccessControlExtensions.ParseSymbolicRolePermissions("rwt", true));

            Assert.AreEqual(RolePermissions.None, PathAccessControlExtensions.ParseSymbolicRolePermissions("--T", true));
            Assert.AreEqual(RolePermissions.Write, PathAccessControlExtensions.ParseSymbolicRolePermissions("-wT", true));
            Assert.AreEqual(RolePermissions.Read, PathAccessControlExtensions.ParseSymbolicRolePermissions("r-T", true));
            Assert.AreEqual(RolePermissions.Read | RolePermissions.Write, PathAccessControlExtensions.ParseSymbolicRolePermissions("rwT", true));
        }

        [Test]
        public void ParseSymbolic_Sticky_Invalid()
        {
            TestHelper.AssertExpectedException(
                () => PathAccessControlExtensions.ParseSymbolicRolePermissions(null, true),
                new ArgumentNullException("s"));

            TestHelper.AssertExpectedException(
                () => PathAccessControlExtensions.ParseSymbolicRolePermissions("a--", true),
                new ArgumentException("Role permission contains an invalid character.  Value is \"a--\""));

            TestHelper.AssertExpectedException(
                () => PathAccessControlExtensions.ParseSymbolicRolePermissions("-a-", true),
                new ArgumentException("Role permission contains an invalid character.  Value is \"-a-\""));

            TestHelper.AssertExpectedException(
                () => PathAccessControlExtensions.ParseSymbolicRolePermissions("--a", true),
                new ArgumentException("Role permission contains an invalid character.  Value is \"--a\""));

            TestHelper.AssertExpectedException(
                () => PathAccessControlExtensions.ParseSymbolicRolePermissions("-", true),
                new ArgumentException("Role permission must be 3 characters.  Value is \"-\""));

            TestHelper.AssertExpectedException(
                () => PathAccessControlExtensions.ParseSymbolicRolePermissions("----", true),
                new ArgumentException("Role permission must be 3 characters.  Value is \"----\""));
        }

        [Test]
        public void ToOctalString()
        {
            Assert.AreEqual("0", RolePermissions.None.ToOctalRolePermissions());
            Assert.AreEqual("1", RolePermissions.Execute.ToOctalRolePermissions());
            Assert.AreEqual("2", RolePermissions.Write.ToOctalRolePermissions());
            Assert.AreEqual("3", (RolePermissions.Write | RolePermissions.Execute).ToOctalRolePermissions());
            Assert.AreEqual("4", (RolePermissions.Read).ToOctalRolePermissions());
            Assert.AreEqual("5", (RolePermissions.Read | RolePermissions.Execute).ToOctalRolePermissions());
            Assert.AreEqual("6", (RolePermissions.Read | RolePermissions.Write).ToOctalRolePermissions());
            Assert.AreEqual("7", (RolePermissions.Read | RolePermissions.Write | RolePermissions.Execute).ToOctalRolePermissions());
        }

        [Test]
        public void ToSymbolicString()
        {
            Assert.AreEqual("---", RolePermissions.None.ToSymbolicRolePermissions());
            Assert.AreEqual("--x", RolePermissions.Execute.ToSymbolicRolePermissions());
            Assert.AreEqual("-w-", RolePermissions.Write.ToSymbolicRolePermissions());
            Assert.AreEqual("-wx", (RolePermissions.Write | RolePermissions.Execute).ToSymbolicRolePermissions());
            Assert.AreEqual("r--", (RolePermissions.Read).ToSymbolicRolePermissions());
            Assert.AreEqual("r-x", (RolePermissions.Read | RolePermissions.Execute).ToSymbolicRolePermissions());
            Assert.AreEqual("rw-", (RolePermissions.Read | RolePermissions.Write).ToSymbolicRolePermissions());
            Assert.AreEqual("rwx", (RolePermissions.Read | RolePermissions.Write | RolePermissions.Execute).ToSymbolicRolePermissions());
        }

        [Test]
        public void SerializeAccessControlList()
        {
            // Arrange
            PathAccessControlItem accessControlEntry = new PathAccessControlItem(
                AccessControlType.User,
                _rolePermissions,
                true,
                _entityId);

            // Act
            string result = PathAccessControlExtensions.ToAccessControlListString(new List<PathAccessControlItem>()
            {
                accessControlEntry
            });

            // Assert
            Assert.AreEqual("default:user:entityId:rwx", result);

            // Act
            result = PathAccessControlExtensions.ToAccessControlListString(new List<PathAccessControlItem>()
            {
                accessControlEntry,
                new PathAccessControlItem(
                    AccessControlType.Mask,
                    _rolePermissions,
                    true),
            });

            // Assert
            Assert.AreEqual("default:user:entityId:rwx,default:mask::rwx", result);
        }

        [Test]
        public void SerializeAccessControlList_Invalid()
        {
            Assert.AreEqual(null, PathAccessControlExtensions.ToAccessControlListString(null));
        }

        [Test]
        public void DeserializeAccessControlList()
        {
            // Arrange
            PathAccessControlItem accessControlEntry = new PathAccessControlItem(
                AccessControlType.User,
                _rolePermissions,
                true,
                _entityId);

            // Act
            IList<PathAccessControlItem> list = PathAccessControlExtensions.ParseAccessControlList("default:user:entityId:rwx");

            // Assert
            Assert.AreEqual(1, list.Count);
            AssertPathAccessControlEntryEquality(accessControlEntry, list[0]);

            // Act
            list = PathAccessControlExtensions.ParseAccessControlList("default:user:entityId:rwx,default:mask::rwx");

            // Assert
            Assert.AreEqual(2, list.Count);
            AssertPathAccessControlEntryEquality(accessControlEntry, list[0]);
            AssertPathAccessControlEntryEquality(new PathAccessControlItem(
                    AccessControlType.Mask,
                    _rolePermissions,
                    true),
                list[1]);
        }

        [Test]
        public void DeserializeAccessControlList_Invalid()
        {
            Assert.AreEqual(null, PathAccessControlExtensions.ParseAccessControlList(null));
        }
    }
}
