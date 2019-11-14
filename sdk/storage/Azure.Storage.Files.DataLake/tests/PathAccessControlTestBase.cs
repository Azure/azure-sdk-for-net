﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Storage.Files.DataLake.Models;
using NUnit.Framework;

namespace Azure.Storage.Files.DataLake.Tests
{
    public class PathAccessControlTestBase
    {
        public readonly string _entityId = "entityId";
        public readonly RolePermissions _rolePermissions = RolePermissions.Read | RolePermissions.Write | RolePermissions.Execute;

        public void AssertPathAccessControlEntryEquality(PathAccessControlItem expected, PathAccessControlItem actual)
        {
            Assert.AreEqual(expected.DefaultScope, actual.DefaultScope);
            Assert.AreEqual(expected.AccessControlType, actual.AccessControlType);
            Assert.AreEqual(expected.EntityId, actual.EntityId);
            Assert.AreEqual(expected.Permissions, actual.Permissions);
        }
        public void AssertPathPermissionsEquality(PathPermissions expected, PathPermissions actual)
        {
            Assert.AreEqual(expected.Owner, actual.Owner);
            Assert.AreEqual(expected.Group, actual.Group);
            Assert.AreEqual(expected.Other, actual.Other);
            Assert.AreEqual(expected.StickyBit, actual.StickyBit);
            Assert.AreEqual(expected.ExtendedAcls, actual.ExtendedAcls);
        }
    }
}
