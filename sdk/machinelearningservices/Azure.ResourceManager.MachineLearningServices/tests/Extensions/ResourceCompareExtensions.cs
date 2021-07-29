// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.MachineLearningServices.Tests.Extensions
{
    internal static class ResourceCompareExtensions
    {
        internal static void AssertAreEqual(this Workspace ws, Workspace ws2)
        {
            Assert.AreEqual(ws.Data.Id, ws2.Data.Id);
            Assert.AreEqual(ws.Data.Location, ws2.Data.Location);
            Assert.AreEqual(ws.Data.Name, ws2.Data.Name);
            Assert.AreEqual(ws.Data.WorkspaceId, ws2.Data.WorkspaceId);
            //TODO: Add equal for Properties and Tags
            //Assert.IsTrue(ws.Data.Sku.Equals(ws2.Data.Sku));
            //Assert.IsTrue(ws.Data.Identity.Equals(ws2.Data.Identity));
        }
    }
}
