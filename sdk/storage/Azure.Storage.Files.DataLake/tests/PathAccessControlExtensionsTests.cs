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
            Assert.That(PathAccessControlExtensions.ParseOctalRolePermissions('0'), Is.EqualTo(RolePermissions.None));
            Assert.That(PathAccessControlExtensions.ParseOctalRolePermissions('1'), Is.EqualTo(RolePermissions.Execute));
            Assert.That(PathAccessControlExtensions.ParseOctalRolePermissions('2'), Is.EqualTo(RolePermissions.Write));
            Assert.That(PathAccessControlExtensions.ParseOctalRolePermissions('4'), Is.EqualTo(RolePermissions.Read));
            Assert.That(PathAccessControlExtensions.ParseOctalRolePermissions('3'), Is.EqualTo(RolePermissions.Execute | RolePermissions.Write));
            Assert.That(PathAccessControlExtensions.ParseOctalRolePermissions('5'), Is.EqualTo(RolePermissions.Read | RolePermissions.Execute));
            Assert.That(PathAccessControlExtensions.ParseOctalRolePermissions('6'), Is.EqualTo(RolePermissions.Read | RolePermissions.Write));
            Assert.That(PathAccessControlExtensions.ParseOctalRolePermissions('7'), Is.EqualTo(RolePermissions.Read | RolePermissions.Write | RolePermissions.Execute));
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
            Assert.That(PathAccessControlExtensions.ParseSymbolicRolePermissions("---"), Is.EqualTo(RolePermissions.None));
            Assert.That(PathAccessControlExtensions.ParseSymbolicRolePermissions("--x"), Is.EqualTo(RolePermissions.Execute));
            Assert.That(PathAccessControlExtensions.ParseSymbolicRolePermissions("-w-"), Is.EqualTo(RolePermissions.Write));
            Assert.That(PathAccessControlExtensions.ParseSymbolicRolePermissions("r--"), Is.EqualTo(RolePermissions.Read));
            Assert.That(PathAccessControlExtensions.ParseSymbolicRolePermissions("-wx"), Is.EqualTo(RolePermissions.Write | RolePermissions.Execute));
            Assert.That(PathAccessControlExtensions.ParseSymbolicRolePermissions("r-x"), Is.EqualTo(RolePermissions.Read | RolePermissions.Execute));
            Assert.That(PathAccessControlExtensions.ParseSymbolicRolePermissions("rw-"), Is.EqualTo(RolePermissions.Read | RolePermissions.Write));
            Assert.That(PathAccessControlExtensions.ParseSymbolicRolePermissions("rwx", false), Is.EqualTo(RolePermissions.Read | RolePermissions.Write | RolePermissions.Execute));
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
            Assert.That(PathAccessControlExtensions.ParseSymbolicRolePermissions("---", true), Is.EqualTo(RolePermissions.None));
            Assert.That(PathAccessControlExtensions.ParseSymbolicRolePermissions("--x", true), Is.EqualTo(RolePermissions.Execute));
            Assert.That(PathAccessControlExtensions.ParseSymbolicRolePermissions("-w-", true), Is.EqualTo(RolePermissions.Write));
            Assert.That(PathAccessControlExtensions.ParseSymbolicRolePermissions("r--", true), Is.EqualTo(RolePermissions.Read));
            Assert.That(PathAccessControlExtensions.ParseSymbolicRolePermissions("-wx", true), Is.EqualTo(RolePermissions.Write | RolePermissions.Execute));
            Assert.That(PathAccessControlExtensions.ParseSymbolicRolePermissions("r-x", true), Is.EqualTo(RolePermissions.Read | RolePermissions.Execute));
            Assert.That(PathAccessControlExtensions.ParseSymbolicRolePermissions("rw-", true), Is.EqualTo(RolePermissions.Read | RolePermissions.Write));
            Assert.That(PathAccessControlExtensions.ParseSymbolicRolePermissions("rwx", true), Is.EqualTo(RolePermissions.Read | RolePermissions.Write | RolePermissions.Execute));

            Assert.That(PathAccessControlExtensions.ParseSymbolicRolePermissions("--T", true), Is.EqualTo(RolePermissions.None));
            Assert.That(PathAccessControlExtensions.ParseSymbolicRolePermissions("-wT", true), Is.EqualTo(RolePermissions.Write));
            Assert.That(PathAccessControlExtensions.ParseSymbolicRolePermissions("r-T", true), Is.EqualTo(RolePermissions.Read));
            Assert.That(PathAccessControlExtensions.ParseSymbolicRolePermissions("rwT", true), Is.EqualTo(RolePermissions.Read | RolePermissions.Write));

            Assert.That(PathAccessControlExtensions.ParseSymbolicRolePermissions("--t", true), Is.EqualTo(RolePermissions.Execute));
            Assert.That(PathAccessControlExtensions.ParseSymbolicRolePermissions("-wt", true), Is.EqualTo(RolePermissions.Write | RolePermissions.Execute));
            Assert.That(PathAccessControlExtensions.ParseSymbolicRolePermissions("r-t", true), Is.EqualTo(RolePermissions.Read | RolePermissions.Execute));
            Assert.That(PathAccessControlExtensions.ParseSymbolicRolePermissions("rwt", true), Is.EqualTo(RolePermissions.Read | RolePermissions.Write | RolePermissions.Execute));
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
            Assert.That(RolePermissions.None.ToOctalRolePermissions(), Is.EqualTo("0"));
            Assert.That(RolePermissions.Execute.ToOctalRolePermissions(), Is.EqualTo("1"));
            Assert.That(RolePermissions.Write.ToOctalRolePermissions(), Is.EqualTo("2"));
            Assert.That((RolePermissions.Write | RolePermissions.Execute).ToOctalRolePermissions(), Is.EqualTo("3"));
            Assert.That((RolePermissions.Read).ToOctalRolePermissions(), Is.EqualTo("4"));
            Assert.That((RolePermissions.Read | RolePermissions.Execute).ToOctalRolePermissions(), Is.EqualTo("5"));
            Assert.That((RolePermissions.Read | RolePermissions.Write).ToOctalRolePermissions(), Is.EqualTo("6"));
            Assert.That((RolePermissions.Read | RolePermissions.Write | RolePermissions.Execute).ToOctalRolePermissions(), Is.EqualTo("7"));
        }

        [Test]
        public void ToSymbolicString()
        {
            Assert.That(RolePermissions.None.ToSymbolicRolePermissions(), Is.EqualTo("---"));
            Assert.That(RolePermissions.Execute.ToSymbolicRolePermissions(), Is.EqualTo("--x"));
            Assert.That(RolePermissions.Write.ToSymbolicRolePermissions(), Is.EqualTo("-w-"));
            Assert.That((RolePermissions.Write | RolePermissions.Execute).ToSymbolicRolePermissions(), Is.EqualTo("-wx"));
            Assert.That((RolePermissions.Read).ToSymbolicRolePermissions(), Is.EqualTo("r--"));
            Assert.That((RolePermissions.Read | RolePermissions.Execute).ToSymbolicRolePermissions(), Is.EqualTo("r-x"));
            Assert.That((RolePermissions.Read | RolePermissions.Write).ToSymbolicRolePermissions(), Is.EqualTo("rw-"));
            Assert.That((RolePermissions.Read | RolePermissions.Write | RolePermissions.Execute).ToSymbolicRolePermissions(), Is.EqualTo("rwx"));
            Assert.That((RolePermissions.Read | RolePermissions.Write).ToSymbolicRolePermissions(true), Is.EqualTo("rwT"));
            Assert.That((RolePermissions.Read | RolePermissions.Write | RolePermissions.Execute).ToSymbolicRolePermissions(true), Is.EqualTo("rwt"));
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
            Assert.That(result, Is.EqualTo("default:user:entityId:rwx"));

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
            Assert.That(result, Is.EqualTo("default:user:entityId:rwx,default:mask::rwx"));
        }

        [Test]
        public void SerializeAccessControlList_Invalid()
        {
            Assert.That(PathAccessControlExtensions.ToAccessControlListString(null), Is.EqualTo(null));
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
            Assert.That(list.Count, Is.EqualTo(1));
            AssertPathAccessControlEntryEquality(accessControlEntry, list[0]);

            // Act
            list = PathAccessControlExtensions.ParseAccessControlList("default:user:entityId:rwx,default:mask::rwx");

            // Assert
            Assert.That(list.Count, Is.EqualTo(2));
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
            Assert.That(PathAccessControlExtensions.ParseAccessControlList(null), Is.EqualTo(null));
        }
    }
}
