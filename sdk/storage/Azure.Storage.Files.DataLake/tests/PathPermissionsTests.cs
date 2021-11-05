// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.Files.DataLake.Tests
{
    public class PathPermissionsTests : PathAccessControlTestBase
    {
        private RolePermissions AllPermissions = RolePermissions.Read | RolePermissions.Write | RolePermissions.Execute;

        [Test]
        public void ParseOctalPermissions()
        {
            AssertPathPermissionsEquality(new PathPermissions(
                    owner: AllPermissions,
                    group: AllPermissions,
                    other: AllPermissions),
                PathPermissions.ParseOctalPermissions("0777"));

            AssertPathPermissionsEquality(new PathPermissions(
                owner: AllPermissions,
                group: AllPermissions,
                other: AllPermissions,
                stickyBit: true),
            PathPermissions.ParseOctalPermissions("1777"));
        }

        [Test]
        public void ParseOctalPermissions_invalid()
        {
            TestHelper.AssertExpectedException(
                () => PathPermissions.ParseOctalPermissions("777"),
                new ArgumentException("s must be 4 characters.  Value is \"777\""));

            TestHelper.AssertExpectedException(
                () => PathPermissions.ParseOctalPermissions("3777"),
                new ArgumentException("First digit of s must be 0 or 1.  Value is \"3777\""));
        }

        [Test]
        public void ParseSymbolicPermissions()
        {
            AssertPathPermissionsEquality(new PathPermissions(
                    owner: AllPermissions,
                    group: AllPermissions,
                    other: AllPermissions),
                PathPermissions.ParseSymbolicPermissions("rwxrwxrwx"));

            AssertPathPermissionsEquality(new PathPermissions(
                    owner: AllPermissions,
                    group: AllPermissions,
                    other: AllPermissions,
                    stickyBit: true),
                PathPermissions.ParseSymbolicPermissions("rwxrwxrwt"));

            AssertPathPermissionsEquality(new PathPermissions(
                    owner: AllPermissions,
                    group: AllPermissions,
                    other: AllPermissions,
                    extendedInfoInAcl: true),
                PathPermissions.ParseSymbolicPermissions("rwxrwxrwx+"));

            AssertPathPermissionsEquality(new PathPermissions(
                    owner: AllPermissions,
                    group: AllPermissions,
                    other: AllPermissions,
                    stickyBit: true,
                    extendedInfoInAcl: true),
                PathPermissions.ParseSymbolicPermissions("rwxrwxrwt+"));
        }

        [Test]
        public void ParseSymbolicPermissions_invalid()
        {
            TestHelper.AssertExpectedException(
                () => PathPermissions.ParseSymbolicPermissions("rwxrwxrw"),
                new ArgumentException("s must be 9 or 10 characters.  Value is \"rwxrwxrw\""));
        }

        [Test]
        public void ToOctalPermissions()
        {
            Assert.AreEqual("0777", new PathPermissions(
                owner: AllPermissions,
                group: AllPermissions,
                other: AllPermissions).ToOctalPermissions());

            Assert.AreEqual("1777", new PathPermissions(
                owner: AllPermissions,
                group: AllPermissions,
                other: AllPermissions,
                stickyBit: true).ToOctalPermissions());
        }

        [Test]
        public void ToSymbolicPermissions()
        {
            Assert.AreEqual("rwxrwxrwx", new PathPermissions(
                owner: AllPermissions,
                group: AllPermissions,
                other: AllPermissions).ToSymbolicPermissions());

            Assert.AreEqual("rwxrwxrwt", new PathPermissions(
                owner: AllPermissions,
                group: AllPermissions,
                other: AllPermissions,
                stickyBit: true).ToSymbolicPermissions());

            Assert.AreEqual("rwxrwxrwx+", new PathPermissions(
                owner: AllPermissions,
                group: AllPermissions,
                other: AllPermissions,
                extendedInfoInAcl: true).ToSymbolicPermissions());

            Assert.AreEqual("rwxrwxrwt+", new PathPermissions(
                owner: AllPermissions,
                group: AllPermissions,
                other: AllPermissions,
                stickyBit: true,
                extendedInfoInAcl: true).ToSymbolicPermissions());
        }
    }
}
