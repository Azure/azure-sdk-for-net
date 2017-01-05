// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using Xunit;

namespace Fluent.Tests.Storage
{
    public class StorageUsagesTests
    {
        [Fact]
        public void CanListUsages()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var storageManger = TestHelper.CreateStorageManager();
                var usages = storageManger.Usages.List();

                Assert.NotNull(usages);
            }
        }
    }
}
