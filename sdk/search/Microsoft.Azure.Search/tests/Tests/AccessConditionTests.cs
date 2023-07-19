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

            var result = AccessCondition.GenerateIfNoneMatchCondition(eTag);

            Assert.Equal(eTag, result.IfNoneMatch);
            Assert.Null(result.IfMatch);
        }

        internal static void CreateOrUpdateIfNotExistsFailsOnExistingResource<T>(
            Func<T, SearchRequestOptions, AccessCondition, T> createOrUpdateFunc,
            Func<T> newResourceDefinition,
            Func<T, T> mutateResourceDefinition)
            where T : IResourceWithETag
        {
            T CreateOrUpdate(T a, AccessCondition b) => createOrUpdateFunc(a, null, b);
            var createdResource = CreateOrUpdate(newResourceDefinition(), AccessCondition.GenerateEmptyCondition());
            var mutatedResource = mutateResourceDefinition(createdResource);

            SearchAssert.ThrowsCloudException(
                () => CreateOrUpdate(mutatedResource, AccessCondition.GenerateIfNotExistsCondition()),
                e => e.IsAccessConditionFailed());
        }

        internal static void CreateOrUpdateIfNotExistsSucceedsOnNoResource<T>(
            Func<T, SearchRequestOptions, AccessCondition, T> createOrUpdateFunc,
            Func<T> newResourceDefinition)
            where T : IResourceWithETag
        {
            T CreateOrUpdate(T a, AccessCondition b) => createOrUpdateFunc(a, null, b);
            var resource = newResourceDefinition();

            var updatedResource = CreateOrUpdate(resource, AccessCondition.GenerateIfNotExistsCondition());

            Assert.NotEmpty(updatedResource.ETag);
        }

        internal static void UpdateIfExistsSucceedsOnExistingResource<T>(
            Func<T, SearchRequestOptions, AccessCondition, T> createOrUpdateFunc,
            Func<T> newResourceDefinition,
            Func<T, T> mutateResourceDefinition)
            where T : IResourceWithETag
        {
            T CreateOrUpdate(T a, AccessCondition b) => createOrUpdateFunc(a, null, b);
            var createdResource = CreateOrUpdate(newResourceDefinition(), AccessCondition.GenerateEmptyCondition());
            var mutatedResource = mutateResourceDefinition(createdResource);

            var updatedResource = CreateOrUpdate(mutatedResource, AccessCondition.GenerateIfExistsCondition());

            Assert.NotEmpty(updatedResource.ETag);
            Assert.NotEqual(createdResource.ETag, updatedResource.ETag);
        }

        internal static void UpdateIfExistsFailsOnNoResource<T>(
            Func<T, SearchRequestOptions, AccessCondition, T> createOrUpdateFunc,
            Func<T> newResourceDefinition)
            where T : IResourceWithETag
        {
            T CreateOrUpdate(T a, AccessCondition b) => createOrUpdateFunc(a, null, b);
            var resource = newResourceDefinition();

            SearchAssert.ThrowsCloudException(
                () => CreateOrUpdate(resource, AccessCondition.GenerateIfExistsCondition()),
                e => e.IsAccessConditionFailed());

            // The resource should never have been created on the server, and thus it should not have an ETag
            Assert.Null(resource.ETag);
        }

        internal static void UpdateIfNotChangedSucceedsWhenResourceUnchanged<T>(
            Func<T, SearchRequestOptions, AccessCondition, T> createOrUpdateFunc,
            Func<T> newResourceDefinition,
            Func<T, T> mutateResourceDefinition)
            where T : IResourceWithETag
        {
            T CreateOrUpdate(T a, AccessCondition b) => createOrUpdateFunc(a, null, b);
            var createdResource = CreateOrUpdate(newResourceDefinition(), AccessCondition.GenerateEmptyCondition());
            var mutatedResource = mutateResourceDefinition(createdResource);

            var updatedResource = CreateOrUpdate(mutatedResource, AccessCondition.IfNotChanged(createdResource));

            Assert.NotEmpty(createdResource.ETag);
            Assert.NotEmpty(updatedResource.ETag);
            Assert.NotEqual(createdResource.ETag, updatedResource.ETag);
        }

        internal static void UpdateIfNotChangedFailsWhenResourceChanged<T>(
            Func<T, SearchRequestOptions, AccessCondition, T> createOrUpdateFunc,
            Func<T> newResourceDefinition,
            Func<T, T> mutateResourceDefinition)
            where T : IResourceWithETag
        {
            T CreateOrUpdate(T a, AccessCondition b) => createOrUpdateFunc(a, null, b);
            var createdResource = CreateOrUpdate(newResourceDefinition(), AccessCondition.GenerateEmptyCondition());
            var mutatedResource = mutateResourceDefinition(createdResource);
            var updatedResource = CreateOrUpdate(mutatedResource, AccessCondition.GenerateEmptyCondition());

            SearchAssert.ThrowsCloudException(
                () => CreateOrUpdate(updatedResource, AccessCondition.IfNotChanged(createdResource)),
                e => e.IsAccessConditionFailed());

            Assert.NotEmpty(createdResource.ETag);
            Assert.NotEmpty(updatedResource.ETag);
            Assert.NotEqual(createdResource.ETag, updatedResource.ETag);
        }

        internal static void DeleteIfNotChangedWorksOnlyOnCurrentResource<T>(
            Action<string, SearchRequestOptions, AccessCondition> deleteAction,
            Func<T> createResource,
            Func<T, T> updateResource,
            string resourceName)
            where T : IResourceWithETag
        {
            void Delete(string a, AccessCondition b) => deleteAction(a, null, b);
            var staleResource = createResource();
            var currentResource = updateResource(staleResource);

            SearchAssert.ThrowsCloudException(
                () => Delete(resourceName, AccessCondition.IfNotChanged(staleResource)),
                e => e.IsAccessConditionFailed());
            Delete(resourceName, AccessCondition.IfNotChanged(currentResource));
        }

        internal static void DeleteIfExistsWorksOnlyWhenResourceExists<T>(
            Action<string, SearchRequestOptions, AccessCondition> deleteAction,
            Func<T> createResource,
            string resourceName)
            where T : IResourceWithETag
        {
            void Delete(string a, AccessCondition b) => deleteAction(a, null, b);
            createResource();

            Delete(resourceName, AccessCondition.GenerateIfExistsCondition());
            SearchAssert.ThrowsCloudException(
                () => Delete(resourceName, AccessCondition.GenerateIfExistsCondition()),
                e => e.IsAccessConditionFailed());
        }

        private class AResourceWithETag : IResourceWithETag
        {
            public string ETag { get; set; }
        }
    }
}
