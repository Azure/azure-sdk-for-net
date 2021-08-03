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

        internal static void AssertAreEqual(this ComputeResource ws, ComputeResource ws2)
        {
            Assert.AreEqual(ws.Data.Id, ws2.Data.Id);
            Assert.AreEqual(ws.Data.Location, ws2.Data.Location);
            Assert.AreEqual(ws.Data.Name, ws2.Data.Name);
            //TODO: Add equal for Properties and Tags
        }

        internal static void AssertAreEqual(this WorkspaceConnection ws, WorkspaceConnection ws2)
        {
            Assert.AreEqual(ws.Data.Id, ws2.Data.Id);
            Assert.AreEqual(ws.Data.Name, ws2.Data.Name);
            //TODO: Add equal for Properties and Tags
        }

        internal static void AssertAreEqual(this EnvironmentContainerResource ws, EnvironmentContainerResource ws2)
        {
            Assert.AreEqual(ws.Data.Id, ws2.Data.Id);
            Assert.AreEqual(ws.Data.Name, ws2.Data.Name);
            //TODO: Add equal for Properties and Tags
            //Assert.IsTrue(ws.Data.Sku.Equals(ws2.Data.Sku));
            //Assert.IsTrue(ws.Data.Identity.Equals(ws2.Data.Identity));
        }

        internal static void AssertAreEqual(this EnvironmentSpecificationVersionResource ws, EnvironmentSpecificationVersionResource ws2)
        {
            Assert.AreEqual(ws.Data.Id, ws2.Data.Id);
            Assert.AreEqual(ws.Data.Name, ws2.Data.Name);
            //TODO: Add equal for Properties and Tags
        }

        internal static void AssertAreEqual(this BatchEndpointTrackedResource ws, BatchEndpointTrackedResource ws2)
        {
            Assert.AreEqual(ws.Data.Id, ws2.Data.Id);
            Assert.AreEqual(ws.Data.Name, ws2.Data.Name);
            //TODO: Add equal for Properties and Tags
        }

        internal static void AssertAreEqual(this CodeContainerResource ws, CodeContainerResource ws2)
        {
            Assert.AreEqual(ws.Data.Id, ws2.Data.Id);
            Assert.AreEqual(ws.Data.Name, ws2.Data.Name);
            //TODO: Add equal for Properties and Tags
        }

        internal static void AssertAreEqual(this DataContainerResource ws, DataContainerResource ws2)
        {
            Assert.AreEqual(ws.Data.Id, ws2.Data.Id);
            Assert.AreEqual(ws.Data.Name, ws2.Data.Name);
            //TODO: Add equal for Properties and Tags
        }

        internal static void AssertAreEqual(this DatastorePropertiesResource ws, DatastorePropertiesResource ws2)
        {
            Assert.AreEqual(ws.Data.Id, ws2.Data.Id);
            Assert.AreEqual(ws.Data.Name, ws2.Data.Name);
            //TODO: Add equal for Properties and Tags
        }

        internal static void AssertAreEqual(this DataVersionResource ws, DataVersionResource ws2)
        {
            Assert.AreEqual(ws.Data.Id, ws2.Data.Id);
            Assert.AreEqual(ws.Data.Name, ws2.Data.Name);
            //TODO: Add equal for Properties and Tags
        }

        internal static void AssertAreEqual(this JobBaseResource ws, JobBaseResource ws2)
        {
            Assert.AreEqual(ws.Data.Id, ws2.Data.Id);
            Assert.AreEqual(ws.Data.Name, ws2.Data.Name);
            //TODO: Add equal for Properties and Tags
        }

        internal static void AssertAreEqual(this LabelingJobResource ws, LabelingJobResource ws2)
        {
            Assert.AreEqual(ws.Data.Id, ws2.Data.Id);
            Assert.AreEqual(ws.Data.Name, ws2.Data.Name);
            //TODO: Add equal for Properties and Tags
        }

        internal static void AssertAreEqual(this ModelContainerResource ws, ModelContainerResource ws2)
        {
            Assert.AreEqual(ws.Data.Id, ws2.Data.Id);
            Assert.AreEqual(ws.Data.Name, ws2.Data.Name);
            //TODO: Add equal for Properties and Tags
        }

        internal static void AssertAreEqual(this OnlineEndpointTrackedResource ws, OnlineEndpointTrackedResource ws2)
        {
            Assert.AreEqual(ws.Data.Id, ws2.Data.Id);
            Assert.AreEqual(ws.Data.Name, ws2.Data.Name);
            //TODO: Add equal for Properties and Tags
        }

        internal static void AssertAreEqual(this PrivateEndpointConnection ws, PrivateEndpointConnection ws2)
        {
            Assert.AreEqual(ws.Data.Id, ws2.Data.Id);
            Assert.AreEqual(ws.Data.Name, ws2.Data.Name);
            //TODO: Add equal for Properties and Tags
        }

        internal static void AssertAreEqual(this BatchDeploymentTrackedResource ws, BatchDeploymentTrackedResource ws2)
        {
            Assert.AreEqual(ws.Data.Id, ws2.Data.Id);
            Assert.AreEqual(ws.Data.Name, ws2.Data.Name);
            //TODO: Add equal for Properties and Tags
        }

        internal static void AssertAreEqual(this CodeVersionResource ws, CodeVersionResource ws2)
        {
            Assert.AreEqual(ws.Data.Id, ws2.Data.Id);
            Assert.AreEqual(ws.Data.Name, ws2.Data.Name);
            //TODO: Add equal for Properties and Tags
        }

        internal static void AssertAreEqual(this ModelVersionResource ws, ModelVersionResource ws2)
        {
            Assert.AreEqual(ws.Data.Id, ws2.Data.Id);
            Assert.AreEqual(ws.Data.Name, ws2.Data.Name);
            //TODO: Add equal for Properties and Tags
        }

        internal static void AssertAreEqual(this OnlineDeploymentTrackedResource ws, OnlineDeploymentTrackedResource ws2)
        {
            Assert.AreEqual(ws.Data.Id, ws2.Data.Id);
            Assert.AreEqual(ws.Data.Name, ws2.Data.Name);
            //TODO: Add equal for Properties and Tags
        }
    }
}
