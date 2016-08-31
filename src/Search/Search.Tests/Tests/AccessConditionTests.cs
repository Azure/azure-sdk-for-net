// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;
    using Microsoft.Azure.Search.Models;
    using Rest.Azure;
    using Xunit;

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

        public static void CreateOrUpdateIfNotExistsFailsOnExistingResource<T>(
            Func<T, SearchRequestOptions, AccessCondition, T> createOrUpdateFunc,
            Func<T> newResourceDefinition,
            Func<T, T> mutateResourceDefinition)
            where T : IResourceWithETag
        {
            Func<T, AccessCondition, T> createOrUpdate = (a, b) => createOrUpdateFunc(a, null, b);
            var createdResource = createOrUpdate(newResourceDefinition(), AccessCondition.GenerateEmptyCondition());
            var mutatedResource = mutateResourceDefinition(createdResource);

            SearchAssert.ThrowsCloudException(
                () => createOrUpdate(mutatedResource, AccessCondition.GenerateIfNotExistsCondition()),
                e => e.IsAccessConditionFailed());
        }

        public static void CreateOrUpdateIfNotExistsSucceedsOnNoResource<T>(
            Func<T, SearchRequestOptions, AccessCondition, T> createOrUpdateFunc,
            Func<T> newResourceDefinition)
            where T : IResourceWithETag
        {
            Func<T, AccessCondition, T> createOrUpdate = (a, b) => createOrUpdateFunc(a, null, b);
            var resource = newResourceDefinition();

            var updatedResource = createOrUpdate(resource, AccessCondition.GenerateIfNotExistsCondition());

            Assert.NotEmpty(updatedResource.ETag);
        }

        public static void UpdateIfExistsSucceedsOnExistingResource<T>(
            Func<T, SearchRequestOptions, AccessCondition, T> createOrUpdateFunc,
            Func<T> newResourceDefinition,
            Func<T, T> mutateResourceDefinition)
            where T : IResourceWithETag
        {
            Func<T, AccessCondition, T> createOrUpdate = (a, b) => createOrUpdateFunc(a, null, b);
            var createdResource = createOrUpdate(newResourceDefinition(), AccessCondition.GenerateEmptyCondition());
            var mutatedResource = mutateResourceDefinition(createdResource);

            var updatedResource = createOrUpdate(mutatedResource, AccessCondition.GenerateIfExistsCondition());

            Assert.NotEmpty(updatedResource.ETag);
            Assert.NotEqual(createdResource.ETag, updatedResource.ETag);
        }

        public static void UpdateIfExistsFailsOnNoResource<T>(
            Func<T, SearchRequestOptions, AccessCondition, T> createOrUpdateFunc,
            Func<T> newResourceDefinition)
            where T : IResourceWithETag
        {
            Func<T, AccessCondition, T> createOrUpdate = (a, b) => createOrUpdateFunc(a, null, b);
            var resource = newResourceDefinition();

            SearchAssert.ThrowsCloudException(
                () => createOrUpdate(resource, AccessCondition.GenerateIfExistsCondition()),
                e => e.IsAccessConditionFailed());

            // The resource should never have been created on the server, and thus it should not have an ETag
            Assert.Null(resource.ETag);
        }

        public static void UpdateIfNotChangedSucceedsWhenResourceUnchanged<T>(
            Func<T, SearchRequestOptions, AccessCondition, T> createOrUpdateFunc,
            Func<T> newResourceDefinition,
            Func<T, T> mutateResourceDefinition)
            where T : IResourceWithETag
        {
            Func<T, AccessCondition, T> createOrUpdate = (a, b) => createOrUpdateFunc(a, null, b);
            var createdResource = createOrUpdate(newResourceDefinition(), AccessCondition.GenerateEmptyCondition());
            var mutatedResource = mutateResourceDefinition(createdResource);

            var updatedResource = createOrUpdate(mutatedResource, AccessCondition.IfNotChanged(createdResource));

            Assert.NotEmpty(createdResource.ETag);
            Assert.NotEmpty(updatedResource.ETag);
            Assert.NotEqual(createdResource.ETag, updatedResource.ETag);
        }

        public static void UpdateIfNotChangedFailsWhenResourceChanged<T>(
            Func<T, SearchRequestOptions, AccessCondition, T> createOrUpdateFunc,
            Func<T> newResourceDefinition,
            Func<T, T> mutateResourceDefinition)
            where T : IResourceWithETag
        {
            Func<T, AccessCondition, T> createOrUpdate = (a, b) => createOrUpdateFunc(a, null, b);
            var createdResource = createOrUpdate(newResourceDefinition(), AccessCondition.GenerateEmptyCondition());
            var mutatedResource = mutateResourceDefinition(createdResource);
            var updatedResource = createOrUpdate(mutatedResource, AccessCondition.GenerateEmptyCondition());

            SearchAssert.ThrowsCloudException(
                () => createOrUpdate(updatedResource, AccessCondition.IfNotChanged(createdResource)),
                e => e.IsAccessConditionFailed());

            Assert.NotEmpty(createdResource.ETag);
            Assert.NotEmpty(updatedResource.ETag);
            Assert.NotEqual(createdResource.ETag, updatedResource.ETag);
        }

        public static void DeleteIfNotChangedWorksOnlyOnCurrentResource<T>(
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
                e => e.IsAccessConditionFailed());
            delete(resourceName, AccessCondition.IfNotChanged(currentResource));
        }

        public static void DeleteIfExistsWorksOnlyWhenResourceExists<T>(
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
                e => e.IsAccessConditionFailed());
        }

        private class AResourceWithETag : IResourceWithETag
        {
            public string ETag { get; set; }
        }
    }
}
