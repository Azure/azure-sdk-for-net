// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
using Microsoft.Azure.Management.Fluent.Resource;
using Microsoft.Azure.Management.Fluent.Resource.Core;
using Microsoft.Azure.Management.Fluent.Resource.Core.CollectionActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Azure.Tests.Common
{
    public abstract class TestTemplate<T, C>
        where T : IGroupableResource
        where C : ISupportsListing<T>, ISupportsGettingByGroup<T>, ISupportsDeleting, ISupportsGettingById<T>
    {
        protected string testId = "" + DateTime.Now.Ticks % 100000L;
        private T resource;
        private C collection;
        private IResourceGroups resourceGroups;

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
            var resources = this.collection.List();
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
            T resourceByGroup = this.collection.GetByGroup(this.resource.ResourceGroupName, this.resource.Name);
            T resourceById = this.collection.GetById(resourceByGroup.Id);
            Assert.True(resourceById.Id.Equals(resourceByGroup.Id, StringComparison.OrdinalIgnoreCase));
            return resourceById;
        }

        /**
         * Tests the deletion logic.
         * @throws Exception if anything goes wrong
         */
        public void VerifyDeleting()
        {
            var groupName = this.resource.ResourceGroupName;
            this.collection.Delete(this.resource.Id);
            this.resourceGroups.Delete(groupName);
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
            this.resource = CreateResource(collection);
            TestHelper.WriteLine("\n------------\nAfter creation:\n");
            Print(this.resource);

            // Verify listing
            Assert.True(VerifyListing() - initialCount == 1);

            // Verify getting
            this.resource = VerifyGetting();
            Assert.NotNull(this.resource);
            TestHelper.WriteLine("\n------------\nRetrieved resource:\n");
            Print(this.resource);

            // Verify update
            this.resource = UpdateResource(this.resource);
            Assert.NotNull(this.resource);
            TestHelper.WriteLine("\n------------\nUpdated resource:\n");
            Print(this.resource);

            // Verify deletion
            VerifyDeleting();
        }
    }
}
