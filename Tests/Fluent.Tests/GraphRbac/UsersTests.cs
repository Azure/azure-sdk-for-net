﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
using Microsoft.Azure.Management.KeyVault.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.KeyVault.Fluent.Models;
using System.Linq;
using Xunit;
using System;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Azure.Tests;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.Graph.RBAC.Fluent;

namespace Fluent.Tests.Graph.RBAC
{

    public class UsersTests {
        
        [Fact]
        public void CanGetUserByEmail()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                IGraphRbacManager manager = TestHelper.CreateGraphRbacManager();
                var user = manager.Users.GetByName("admin@azuresdkteam.onmicrosoft.com");
                Assert.Equal("Admin", user.Name);
            }
        }

        [Fact]
        public void CanGetUserByForeignEmail()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                IGraphRbacManager manager = TestHelper.CreateGraphRbacManager();
                var user = manager.Users.GetByName("jianghlu@microsoft.com");
                Assert.Equal("Jianghao Lu", user.Name);
            }
        }

        [Fact]
        public void CanGetUserByDisplayName()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                IGraphRbacManager manager = TestHelper.CreateGraphRbacManager();
                var user = manager.Users.GetByName("Reader zero");
                Assert.Equal("Reader zero", user.Name);
            }
        }
    }
}