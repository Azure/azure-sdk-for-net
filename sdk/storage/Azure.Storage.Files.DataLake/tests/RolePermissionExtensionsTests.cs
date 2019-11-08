// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.Files.DataLake.Tests
{
    public class RolePermissionExtensionsTests
    {

        [Test]
        public void ParseOctal()
        {
            Assert.AreEqual(RolePermissions.None, RolePermissionsExtensions.ParseOctal('0'));
            Assert.AreEqual(RolePermissions.Execute, RolePermissionsExtensions.ParseOctal('1'));
            Assert.AreEqual(RolePermissions.Write, RolePermissionsExtensions.ParseOctal('2'));
            Assert.AreEqual(RolePermissions.Read, RolePermissionsExtensions.ParseOctal('4'));
            Assert.AreEqual(RolePermissions.Execute | RolePermissions.Write, RolePermissionsExtensions.ParseOctal('3'));
            Assert.AreEqual(RolePermissions.Read | RolePermissions.Execute, RolePermissionsExtensions.ParseOctal('5'));
            Assert.AreEqual(RolePermissions.Read | RolePermissions.Write, RolePermissionsExtensions.ParseOctal('6'));
            Assert.AreEqual(RolePermissions.Read | RolePermissions.Write | RolePermissions.Execute, RolePermissionsExtensions.ParseOctal('7'));
        }

        [Test]
        public void ParseOctal_OutOfRange()
        {
            TestHelper.AssertExpectedException(
                () => RolePermissionsExtensions.ParseOctal('/'),
                new ArgumentOutOfRangeException("octalRolePermission", "Value must be between 0 and 7 inclusive"));

            TestHelper.AssertExpectedException(
                () => RolePermissionsExtensions.ParseOctal('8'),
                new ArgumentOutOfRangeException("octalRolePermission", "Value must be between 0 and 7 inclusive"));
        }

        [Test]
        public void ParseSymbolic_NoSticky()
        {
            Assert.AreEqual(RolePermissions.None, RolePermissionsExtensions.ParseSymbolic("---", false));
            Assert.AreEqual(RolePermissions.Execute, RolePermissionsExtensions.ParseSymbolic("--x", false));
            Assert.AreEqual(RolePermissions.Write, RolePermissionsExtensions.ParseSymbolic("-w-", false));
            Assert.AreEqual(RolePermissions.Read, RolePermissionsExtensions.ParseSymbolic("r--", false));
            Assert.AreEqual(RolePermissions.Write | RolePermissions.Execute, RolePermissionsExtensions.ParseSymbolic("-wx", false));
            Assert.AreEqual(RolePermissions.Read | RolePermissions.Execute, RolePermissionsExtensions.ParseSymbolic("r-x", false));
            Assert.AreEqual(RolePermissions.Read | RolePermissions.Write, RolePermissionsExtensions.ParseSymbolic("rw-", false));
            Assert.AreEqual(RolePermissions.Read | RolePermissions.Write | RolePermissions.Execute, RolePermissionsExtensions.ParseSymbolic("rwx", false));
        }

        [Test]
        public void ParseSymbolic_NoSticky_InvalidCharacters()
        {
            TestHelper.AssertExpectedException(
                () => RolePermissionsExtensions.ParseSymbolic(null, false),
                new ArgumentNullException("symbolicRolePermissions"));

            TestHelper.AssertExpectedException(
                () => RolePermissionsExtensions.ParseSymbolic("a--", false),
                new ArgumentException("Role permission contains an invalid character"));

            TestHelper.AssertExpectedException(
                () => RolePermissionsExtensions.ParseSymbolic("-a-", false),
                new ArgumentException("Role permission contains an invalid character"));

            TestHelper.AssertExpectedException(
                () => RolePermissionsExtensions.ParseSymbolic("--a", false),
                new ArgumentException("Role permission contains an invalid character"));

            TestHelper.AssertExpectedException(
                () => RolePermissionsExtensions.ParseSymbolic("-", false),
                new ArgumentException("Role permission must be 3 characters"));

            TestHelper.AssertExpectedException(
                () => RolePermissionsExtensions.ParseSymbolic("----", false),
                new ArgumentException("Role permission must be 3 characters"));
        }

        [Test]
        public void ParseSymbolic_Sticky()
        {
            Assert.AreEqual(RolePermissions.None, RolePermissionsExtensions.ParseSymbolic("---", true));
            Assert.AreEqual(RolePermissions.Execute, RolePermissionsExtensions.ParseSymbolic("--x", true));
            Assert.AreEqual(RolePermissions.Write, RolePermissionsExtensions.ParseSymbolic("-w-", true));
            Assert.AreEqual(RolePermissions.Read, RolePermissionsExtensions.ParseSymbolic("r--", true));
            Assert.AreEqual(RolePermissions.Write | RolePermissions.Execute, RolePermissionsExtensions.ParseSymbolic("-wx", true));
            Assert.AreEqual(RolePermissions.Read | RolePermissions.Execute, RolePermissionsExtensions.ParseSymbolic("r-x", true));
            Assert.AreEqual(RolePermissions.Read | RolePermissions.Write, RolePermissionsExtensions.ParseSymbolic("rw-", true));
            Assert.AreEqual(RolePermissions.Read | RolePermissions.Write | RolePermissions.Execute, RolePermissionsExtensions.ParseSymbolic("rwx", true));

            Assert.AreEqual(RolePermissions.Execute, RolePermissionsExtensions.ParseSymbolic("--t", true));
            Assert.AreEqual(RolePermissions.Write | RolePermissions.Execute, RolePermissionsExtensions.ParseSymbolic("-wt", true));
            Assert.AreEqual(RolePermissions.Read | RolePermissions.Execute, RolePermissionsExtensions.ParseSymbolic("r-t", true));
            Assert.AreEqual(RolePermissions.Read | RolePermissions.Write | RolePermissions.Execute, RolePermissionsExtensions.ParseSymbolic("rwt", true));

            Assert.AreEqual(RolePermissions.None, RolePermissionsExtensions.ParseSymbolic("--T", true));
            Assert.AreEqual(RolePermissions.Write, RolePermissionsExtensions.ParseSymbolic("-wT", true));
            Assert.AreEqual(RolePermissions.Read, RolePermissionsExtensions.ParseSymbolic("r-T", true));
            Assert.AreEqual(RolePermissions.Read | RolePermissions.Write, RolePermissionsExtensions.ParseSymbolic("rwT", true));
        }

        [Test]
        public void ParseSymbolic_Sticky_Invalid()
        {
            TestHelper.AssertExpectedException(
                () => RolePermissionsExtensions.ParseSymbolic(null, true),
                new ArgumentNullException("symbolicRolePermissions"));

            TestHelper.AssertExpectedException(
                () => RolePermissionsExtensions.ParseSymbolic("a--", true),
                new ArgumentException("Role permission contains an invalid character"));

            TestHelper.AssertExpectedException(
                () => RolePermissionsExtensions.ParseSymbolic("-a-", true),
                new ArgumentException("Role permission contains an invalid character"));

            TestHelper.AssertExpectedException(
                () => RolePermissionsExtensions.ParseSymbolic("--a", true),
                new ArgumentException("Role permission contains an invalid character"));

            TestHelper.AssertExpectedException(
                () => RolePermissionsExtensions.ParseSymbolic("-", true),
                new ArgumentException("Role permission must be 3 characters"));

            TestHelper.AssertExpectedException(
                () => RolePermissionsExtensions.ParseSymbolic("----", true),
                new ArgumentException("Role permission must be 3 characters"));
        }

        [Test]
        public void ToOctalString()
        {
            Assert.AreEqual("0", RolePermissions.None.ToOctalString());
            Assert.AreEqual("1", RolePermissions.Execute.ToOctalString());
            Assert.AreEqual("2", RolePermissions.Write.ToOctalString());
            Assert.AreEqual("3", (RolePermissions.Write | RolePermissions.Execute).ToOctalString());
            Assert.AreEqual("4", (RolePermissions.Read).ToOctalString());
            Assert.AreEqual("5", (RolePermissions.Read | RolePermissions.Execute).ToOctalString());
            Assert.AreEqual("6", (RolePermissions.Read | RolePermissions.Write).ToOctalString());
            Assert.AreEqual("7", (RolePermissions.Read | RolePermissions.Write | RolePermissions.Execute).ToOctalString());
        }

        [Test]
        public void ToSymbolicString()
        {
            Assert.AreEqual("---", RolePermissions.None.ToSymbolicString());
            Assert.AreEqual("--x", RolePermissions.Execute.ToSymbolicString());
            Assert.AreEqual("-w-", RolePermissions.Write.ToSymbolicString());
            Assert.AreEqual("-wx", (RolePermissions.Write | RolePermissions.Execute).ToSymbolicString());
            Assert.AreEqual("r--", (RolePermissions.Read).ToSymbolicString());
            Assert.AreEqual("r-x", (RolePermissions.Read | RolePermissions.Execute).ToSymbolicString());
            Assert.AreEqual("rw-", (RolePermissions.Read | RolePermissions.Write).ToSymbolicString());
            Assert.AreEqual("rwx", (RolePermissions.Read | RolePermissions.Write | RolePermissions.Execute).ToSymbolicString());
        }
    }
}
