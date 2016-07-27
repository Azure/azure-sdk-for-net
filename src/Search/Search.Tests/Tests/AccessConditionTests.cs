// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;
    using Microsoft.Azure.Search.Models;
    using Xunit;
    using Rest.Azure;
    using System.Net;

    public sealed class AccessConditionTests
    {
        [Fact]
        public void IfNotChangedThrowsOnNullResource()
        {
            Assert.Throws<ArgumentNullException>(() => AccessCondition.IfNotChanged(null));
        }

        [Fact]
        public void IfNotChangedThrowsOnNullETag()
        {
            IResourceWithETag aResourceWithETag = new AResourceWithETag();

            Assert.Throws<ArgumentNullException>(() => AccessCondition.IfNotChanged(aResourceWithETag));
        }

        [Fact]
        public void IfNotChangedThrowsOnEmptyETag()
        {
            IResourceWithETag aResourceWithETag = new AResourceWithETag() { ETag = string.Empty };

            Assert.Throws<ArgumentException>(() => AccessCondition.IfNotChanged(aResourceWithETag));
        }

        [Fact]
        public void IfNotChangedReturnsIfMatchAccessCondition()
        {
            IResourceWithETag aResourceWithETag = new AResourceWithETag() { ETag = "IHazETag" };

            AccessCondition result = AccessCondition.IfNotChanged(aResourceWithETag);

            Assert.Equal(aResourceWithETag.ETag, result.IfMatch);
            Assert.Null(result.IfNoneMatch);
        }

        [Fact]
        public void GenerateEmptyConditionReturnsEmptyAccessCondition()
        {
            AccessCondition result = AccessCondition.GenerateEmptyCondition();

            Assert.Null(result.IfMatch);
            Assert.Null(result.IfNoneMatch);
        }

        [Fact]
        public void GenerateIfExistsConditionReturnsIfMatchAccessCondition()
        {
            AccessCondition result = AccessCondition.GenerateIfExistsCondition();

            Assert.Equal("*", result.IfMatch);
            Assert.Null(result.IfNoneMatch);
        }

        [Fact]
        public void GenerateIfMatchConditionThrowsOnNullETag()
        {
            Assert.Throws<ArgumentNullException>(() => AccessCondition.GenerateIfMatchCondition(null));
        }

        [Fact]
        public void GenerateIfMatchConditionThrowsOnEmptyETag()
        {
            Assert.Throws<ArgumentException>(() => AccessCondition.GenerateIfMatchCondition(string.Empty));
        }

        [Fact]
        public void GenerateIfMatchConditionReturnsIfMatchAccessCondition()
        {
            string eTag = "IHazETag";

            AccessCondition result = AccessCondition.GenerateIfMatchCondition(eTag);

            Assert.Equal(eTag, result.IfMatch);
            Assert.Null(result.IfNoneMatch);
        }

        [Fact]
        public void GenerateIfNotExistsConditionReturnsIfNoneMatchAccessCondition()
        {
            AccessCondition result = AccessCondition.GenerateIfNotExistsCondition();

            Assert.Equal("*", result.IfNoneMatch);
            Assert.Null(result.IfMatch);
        }

        [Fact]
        public void GenerateIfNoneMatchConditionThrowsOnNullETag()
        {
            Assert.Throws<ArgumentNullException>(() => AccessCondition.GenerateIfNoneMatchCondition(null));
        }

        [Fact]
        public void GenerateIfNoneMatchConditionThrowsOnEmptyETag()
        {
            Assert.Throws<ArgumentException>(() => AccessCondition.GenerateIfNoneMatchCondition(string.Empty));
        }

        [Fact]
        public void GenerateIfMatchConditionReturnsIfNoneMatchAccessCondition()
        {
            string eTag = "IHazETag";

            AccessCondition result = AccessCondition.GenerateIfNoneMatchCondition(eTag);

            Assert.Equal(eTag, result.IfNoneMatch);
            Assert.Null(result.IfMatch);
        }

        public static void UpdateIfExistsSucceedsOnExistingResource<T>(
            Func<T, SearchRequestOptions, AccessCondition, T> updateOrCreateFunc,
            Func<T> newResourceDefinition,
            Func<T, T> mutateResourceDefinition)
            where T : IResourceWithETag
        {
            Func<T, AccessCondition, T> updateOrCreate = (a, b) => updateOrCreateFunc(a, null, b);
            var createdResource = updateOrCreate(newResourceDefinition(), AccessCondition.GenerateEmptyCondition());
            var mutatedResource = mutateResourceDefinition(createdResource);

            var updatedResource = updateOrCreate(mutatedResource, AccessCondition.GenerateIfExistsCondition());

            Assert.NotEmpty(updatedResource.ETag);
            Assert.NotEqual(createdResource.ETag, updatedResource.ETag);
        }

        public static void UpdateIfExistsFailsOnNoResource<T>(
            Func<T, SearchRequestOptions, AccessCondition, T> updateOrCreateFunc,
            Func<T> newResourceDefinition)
            where T : IResourceWithETag
        {
            Func<T, AccessCondition, T> updateOrCreate = (a, b) => updateOrCreateFunc(a, null, b);
            var resource = newResourceDefinition();

            SearchAssert.ThrowsCloudException(
                () => updateOrCreate(resource, AccessCondition.GenerateIfExistsCondition()),
                HttpStatusCode.PreconditionFailed);

            // The resource should never have been created on the server, and thus it should not have an ETag
            Assert.Null(resource.ETag);
        }

        public static void UpdateIfNotChangedSucceedsWhenResourceUnchanged<T>(
            Func<T, SearchRequestOptions, AccessCondition, T> updateOrCreateFunc,
            Func<T> newResourceDefinition,
            Func<T, T> mutateResourceDefinition)
            where T : IResourceWithETag
        {
            Func<T, AccessCondition, T> updateOrCreate = (a, b) => updateOrCreateFunc(a, null, b);
            var createdResource = updateOrCreate(newResourceDefinition(), AccessCondition.GenerateEmptyCondition());
            var mutatedResource = mutateResourceDefinition(createdResource);

            var updatedResource = updateOrCreate(mutatedResource, AccessCondition.IfNotChanged(createdResource));

            Assert.NotEmpty(createdResource.ETag);
            Assert.NotEmpty(updatedResource.ETag);
            Assert.NotEqual(createdResource.ETag, updatedResource.ETag);
        }

        public static void UpdateIfNotChangedFailsWhenResourceChanged<T>(
            Func<T, SearchRequestOptions, AccessCondition, T> updateOrCreateFunc,
            Func<T> newResourceDefinition,
            Func<T, T> mutateResourceDefinition)
            where T : IResourceWithETag
        {
            Func<T, AccessCondition, T> updateOrCreate = (a, b) => updateOrCreateFunc(a, null, b);
            var createdResource = updateOrCreate(newResourceDefinition(), AccessCondition.GenerateEmptyCondition());
            var mutatedResource = mutateResourceDefinition(createdResource);
            var updatedResource = updateOrCreate(mutatedResource, AccessCondition.GenerateEmptyCondition());

            SearchAssert.ThrowsCloudException(
                () => updateOrCreate(updatedResource, AccessCondition.IfNotChanged(createdResource)),
                HttpStatusCode.PreconditionFailed);

            Assert.NotEmpty(createdResource.ETag);
            Assert.NotEmpty(updatedResource.ETag);
            Assert.NotEqual(createdResource.ETag, updatedResource.ETag);
        }

        public static void TestDeleteIfNotChangedWorksOnlyOnCurrentResource<T>(
            Action<string, SearchRequestOptions, AccessCondition> deleteAction,
            Func<T> createResource,
            Func<T, T> updateResource,
            string resourceName)
            where T : IResourceWithETag
        {
            Action<string, AccessCondition> delete = (a, b) => deleteAction(a, null, b);
            var staleResource = createResource();
            var currentResource = updateResource(staleResource);

            SearchAssert.ThrowsCloudException(
                () => delete(resourceName, AccessCondition.IfNotChanged(staleResource)),
                HttpStatusCode.PreconditionFailed);
            delete(resourceName, AccessCondition.IfNotChanged(currentResource));
        }

        public static void TestDeleteIfExistsWorksOnlyWhenResourceExists<T>(
            Action<string, SearchRequestOptions, AccessCondition> deleteAction,
            Func<T> createResource,
            string resourceName)
            where T : IResourceWithETag
        {
            Action<string, AccessCondition> delete = (a, b) => deleteAction(a, null, b);
            createResource();

            delete(resourceName, AccessCondition.GenerateIfExistsCondition());
            SearchAssert.ThrowsCloudException(
                () => delete(resourceName, AccessCondition.GenerateIfExistsCondition()),
                HttpStatusCode.PreconditionFailed);
        }

        private class AResourceWithETag : IResourceWithETag
        {
            public string ETag { get; set; }
        }
    }
}
