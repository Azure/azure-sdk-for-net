// Copyright (c) Microsoft Corporation. All rights reserved.
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
            Assert.That(actual.DefaultScope, Is.EqualTo(expected.DefaultScope));
            Assert.That(actual.AccessControlType, Is.EqualTo(expected.AccessControlType));
            Assert.That(actual.EntityId, Is.EqualTo(expected.EntityId));
            Assert.That(actual.Permissions, Is.EqualTo(expected.Permissions));
        }
        public void AssertPathPermissionsEquality(PathPermissions expected, PathPermissions actual)
        {
            Assert.That(actual.Owner, Is.EqualTo(expected.Owner));
            Assert.That(actual.Group, Is.EqualTo(expected.Group));
            Assert.That(actual.Other, Is.EqualTo(expected.Other));
            Assert.That(actual.StickyBit, Is.EqualTo(expected.StickyBit));
            Assert.That(actual.ExtendedAcls, Is.EqualTo(expected.ExtendedAcls));
        }
    }
}
