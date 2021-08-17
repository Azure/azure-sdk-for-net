// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.ResourceManager.Storage.Tests.Tests.Helpers
{
    public class FileHelper
    {
        public static void AssertFileShare(FileShare fileShare1, FileShare fileShare2)
        {
            Assert.AreEqual(fileShare1.Id.Name, fileShare2.Id.Name);
            Assert.AreEqual(fileShare1.Id.Location, fileShare2.Id.Location);
        }
    }
}
