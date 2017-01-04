// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
using Xunit;

namespace Fluent.Tests.Storage
{
    public class StorageUsagesTests
    {
        [Fact(Skip = "TODO: Convert to recorded tests")]
        public void CanListUsages()
        {
            var storageManger = TestHelper.CreateStorageManager();
            var usages = storageManger.Usages.List();

            Assert.NotNull(usages);
        }
    }
}
