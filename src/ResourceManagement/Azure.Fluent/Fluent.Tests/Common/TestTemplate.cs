﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using Xunit;

namespace Azure.Tests.Common
{
    public abstract class TestTemplate<T, C, ManagerT>
        where T : IGroupableResource<ManagerT>
        where C : ISupportsListing<T>, ISupportsGettingByGroup<T>, ISupportsDeletingById, ISupportsGettingById<T>
    {
        protected string TestId { get; private set; }
        private T resource;
        private C collection;
        private IResourceGroups resourceGroups;
        protected string MethodName { get; set; }

        protected TestTemplate(string methodName)
        {
            this.MethodName = methodName;
            TestId = TestUtilities.GenerateName("");
        }

        /*Resource creation logic.
        @param resources collection of resources
        @return created resource
        @throws Exception if anything goes wrong
        */

        public abstract T CreateResource(C resources);

        /**
         * Resource update logic.
         * @param resource the resource to update
         * @return the updated resource
         * @throws Exception if anything goes wrong
         */
        public abstract T UpdateResource(T resource);

        /**
         * Tests the listing logic.
         * @return number of resources in the list
         * @throws CloudException if anything goes wrong
         * @throws IOException if anything goes wrong
         */
        public int VerifyListing()
        {
            var resources = collection.List();
            foreach (T r in resources)
            {
                TestHelper.WriteLine("resource id: " + r.Id);
            }

            return resources.Count;
        }

        /**
         * Tests the getting logic.
         * @return the gotten resource
         * @throws CloudException if anything goes wrong
         * @throws IOException if anything goes wrong
         */
        public T VerifyGetting()
        {
            T resourceByGroup = collection.GetByGroup(resource.ResourceGroupName, resource.Name);
            T resourceById = collection.GetById(resourceByGroup.Id);
            Assert.True(resourceById.Id.Equals(resourceByGroup.Id, StringComparison.OrdinalIgnoreCase));
            return resourceById;
        }

        /**
         * Tests the deletion logic.
         * @throws Exception if anything goes wrong
         */
        public void VerifyDeleting()
        {
            var groupName = resource.ResourceGroupName;
            collection.DeleteById(resource.Id);
            resourceGroups.DeleteByName(groupName);
        }

        /**
         * Prints information about the resource.
         *
         * @param resource resource to print
         */
        public abstract void Print(T resource);

        /**
         * Runs the test.
         * @param collection collection of resources to test
         * @param resourceGroups the resource groups collection
         * @throws Exception if anything goes wrong
         */
        public void RunTest(C collection, IResourceGroups resourceGroups)
        {
            this.collection = collection;
            this.resourceGroups = resourceGroups;

            // Initial listing
            int initialCount = VerifyListing();

            // Verify creation
            resource = CreateResource(collection);
            TestHelper.WriteLine("\n------------\nAfter creation:\n");
            Print(resource);

            // Verify listing
            VerifyListing();

            // Verify getting
            resource = VerifyGetting();
            Assert.NotNull(resource);
            TestHelper.WriteLine("\n------------\nRetrieved resource:\n");
            Print(resource);

            // Verify update
            resource = UpdateResource(resource);
            Assert.NotNull(resource);
            TestHelper.WriteLine("\n------------\nUpdated resource:\n");
            Print(resource);

            // Verify deletion
            VerifyDeleting();
        }
    }
}
