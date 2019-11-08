// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.Files.DataLake.Tests
{
    public class PathPermissionsTests
    {
        private RolePermissions AllPermissions = RolePermissions.Read | RolePermissions.Write | RolePermissions.Execute;

        [Test]
        public void ParseOctal()
        {
            Assert.AreEqual(new PathPermissions(
                    owner: AllPermissions,
                    group: AllPermissions,
                    other: AllPermissions),
                PathPermissions.ParseOctal("0777"));

            Assert.AreEqual(new PathPermissions(
                owner: AllPermissions,
                group: AllPermissions,
                other: AllPermissions,
                stickyBit: true),
            PathPermissions.ParseOctal("1777"));
        }

        [Test]
        public void ParseOctal_invalid()
        {
            TestHelper.AssertExpectedException(
                () => PathPermissions.ParseOctal("777"),
                new ArgumentException("octalString must be 4 characters"));

            TestHelper.AssertExpectedException(
                () => PathPermissions.ParseOctal("3777"),
                new ArgumentException("First digit of octalString must be 0 or 1"));
        }

        [Test]
        public void ParseSymbolic()
        {
            Assert.AreEqual(new PathPermissions(
                    owner: AllPermissions,
                    group: AllPermissions,
                    other: AllPermissions),
                PathPermissions.ParseSymbolic("rwxrwxrwx"));

            Assert.AreEqual(new PathPermissions(
                    owner: AllPermissions,
                    group: AllPermissions,
                    other: AllPermissions,
                    stickyBit: true),
                PathPermissions.ParseSymbolic("rwxrwxrwt"));

            Assert.AreEqual(new PathPermissions(
                    owner: AllPermissions,
                    group: AllPermissions,
                    other: AllPermissions,
                    extendedInfoInAcl: true),
                PathPermissions.ParseSymbolic("rwxrwxrwx+"));

            Assert.AreEqual(new PathPermissions(
                    owner: AllPermissions,
                    group: AllPermissions,
                    other: AllPermissions,
                    stickyBit: true,
                    extendedInfoInAcl: true),
                PathPermissions.ParseSymbolic("rwxrwxrwt+"));
        }

        [Test]
        public void ParseSymbolic_invalid()
        {
            TestHelper.AssertExpectedException(
                () => PathPermissions.ParseSymbolic("rwxrwxrw"),
                new ArgumentException("symbolicString must be 9 or 10 characters"));
        }

        [Test]
        public void ToOctalString()
        {
            Assert.AreEqual("0777", new PathPermissions(
                owner: AllPermissions,
                group: AllPermissions,
                other: AllPermissions).ToOctalString());

            Assert.AreEqual("1777", new PathPermissions(
                owner: AllPermissions,
                group: AllPermissions,
                other: AllPermissions,
                stickyBit: true).ToOctalString());
        }

        [Test]
        public void ToSymbolicString()
        {
            Assert.AreEqual("rwxrwxrwx", new PathPermissions(
                owner: AllPermissions,
                group: AllPermissions,
                other: AllPermissions).ToSymbolicString());

            Assert.AreEqual("rwxrwxrwt", new PathPermissions(
                owner: AllPermissions,
                group: AllPermissions,
                other: AllPermissions,
                stickyBit: true).ToSymbolicString());

            Assert.AreEqual("rwxrwxrwx+", new PathPermissions(
                owner: AllPermissions,
                group: AllPermissions,
                other: AllPermissions,
                extendedInfoInAcl: true).ToSymbolicString());

            Assert.AreEqual("rwxrwxrwt+", new PathPermissions(
                owner: AllPermissions,
                group: AllPermissions,
                other: AllPermissions,
                stickyBit: true,
                extendedInfoInAcl: true).ToSymbolicString());
        }
    }
}
