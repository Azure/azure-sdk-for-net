// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using Xunit;

namespace Fluent.Tests.Storage
{
    public class Usages
    {
        [Fact]
        public void CanList()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var storageManger = TestHelper.CreateStorageManager();
                var usages = storageManger.Usages.List();
                Assert.NotNull(usages);
            }
        }
    }
}
