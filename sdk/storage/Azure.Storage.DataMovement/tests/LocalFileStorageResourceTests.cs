// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.DataMovement;
using Azure.Storage.DataMovement.Shared;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    public class LocalFileStorageResourceTests
    {
        [Test]
        [TestCase("C:\\Users\\user1\\Documents\file.txt")]
        [TestCase("C:\\Users\\user1\\Documents\file")]
        [TestCase("C:\\Users\\user1\\Documents\file\\")]
        [TestCase("user1\\Documents\file\\")]
        public void LocalFileStorageResource_Factory(string filePath)
        {
            // Act
            LocalFileStorageResource resource = LocalStorageResourceFactory.GetFile(filePath);

            // Assert
            Assert.NotNull(resource);
            Assert.Equals(StreamReadableOptions.Consumable, resource.CanConsumeReadableStream());
        }
    }
}
