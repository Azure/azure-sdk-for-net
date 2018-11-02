// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace ContainerRegistry.Tests
{
    using Microsoft.Azure.ContainerRegistry;
    using Microsoft.Azure.ContainerRegistry.Models;
    using Microsoft.Rest;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System.Threading.Tasks;
    using Xunit;

    public class RepositoryTests
    {
        [Fact]
        public async Task ListRepositoryCR()
        {
            using (var context = MockContext.Start(GetType().FullName, nameof(ListRepositoryCR)))
            {
                var client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ClassicTestRegistry);
                var repositories = await client.GetRepositoriesAsync();
                
                Assert.Equal(2, repositories.Names.Count);
                Assert.Collection(repositories.Names, name => Assert.Equal(ACRTestUtil.ProdRepository, name),
                                                      name => Assert.Equal(ACRTestUtil.TestRepository, name));
            }
        }

        [Fact]
        public async Task ListRepositoryMR()
        {
            using (var context = MockContext.Start(GetType().FullName, nameof(ListRepositoryMR)))
            {
                var client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistry);
                var repositories = await client.GetRepositoriesAsync();

                Assert.Equal(2, repositories.Names.Count);
                Assert.Collection(repositories.Names, name => Assert.Equal(ACRTestUtil.ProdRepository, name),
                                                      name => Assert.Equal(ACRTestUtil.TestRepository, name));
            }
        }

        [Fact]
        public async Task GetAcrRepositoryDetailsMR()
        {
            using (var context = MockContext.Start(GetType().FullName, nameof(GetAcrRepositoryDetailsMR)))
            {
                var client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistry);
                var repositoryDetails = await client.GetAcrRepositoryAttributesAsync(ACRTestUtil.ProdRepository);
                
                Assert.Equal(ACRTestUtil.ManagedTestRegistryFullName, repositoryDetails.Registry);
                Assert.Equal(1, repositoryDetails.TagCount);
                Assert.Equal(1, repositoryDetails.ManifestCount);
                Assert.Equal("2018-09-28T23:37:52.0356217Z", repositoryDetails.LastUpdateTime);
                Assert.Equal("2018-09-28T23:37:51.9668212Z", repositoryDetails.CreatedTime);
                Assert.Equal(ACRTestUtil.ProdRepository, repositoryDetails.ImageName);
                Assert.True(repositoryDetails.ChangeableAttributes.DeleteEnabled);
                Assert.True(repositoryDetails.ChangeableAttributes.ListEnabled);
                Assert.True(repositoryDetails.ChangeableAttributes.ReadEnabled);
                Assert.True(repositoryDetails.ChangeableAttributes.WriteEnabled);
            }
        }

        [Fact]
        public async Task GetAcrRepositoryDetailsCRThrowException()
        {
            using (var context = MockContext.Start(GetType().FullName, nameof(GetAcrRepositoryDetailsCRThrowException)))
            {
                var client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ClassicTestRegistry);
                await Assert.ThrowsAsync<AcrErrorsException>(() => client.GetAcrRepositoryAttributesAsync(ACRTestUtil.ProdRepository));
            }
        }

        [Fact]
        public async Task GetAcrRepositoriesMR()
        {
            using (var context = MockContext.Start(GetType().FullName, nameof(GetAcrRepositoriesMR)))
            {
                var client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistry);
                var repositories = await client.GetAcrRepositoriesAsync();

                Assert.Equal(2, repositories.Names.Count);
                Assert.Collection(repositories.Names, name => Assert.Equal(ACRTestUtil.ProdRepository, name),
                                                      name => Assert.Equal(ACRTestUtil.TestRepository, name));
            }
        }

        [Fact]
        public async Task GetAcrRepositoriesCRThrowException()
        {
            using (var context = MockContext.Start(GetType().FullName, nameof(GetAcrRepositoriesCRThrowException)))
            {
                var client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ClassicTestRegistry);
                await Assert.ThrowsAsync<AcrErrorsException>(() => client.GetAcrRepositoriesAsync());                
            }
        }

        [Fact]
        public async Task DeleteAcrRepositoryMR()
        {
            using (var context = MockContext.Start(GetType().FullName, nameof(DeleteAcrRepositoryMR)))
            {
                var client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistryForDeleting);
                var deletedRepo = await client.DeleteAcrRepositoryAsync(ACRTestUtil.TestRepository);

                Assert.Equal(1, deletedRepo.ManifestsDeleted.Count);
                Assert.Equal("sha256:eabe547f78d4c18c708dd97ec3166cf7464cc651f1cbb67e70d407405b7ad7b6", deletedRepo.ManifestsDeleted[0]);
                Assert.Equal(2, deletedRepo.TagsDeleted.Count);
                Assert.Collection(deletedRepo.TagsDeleted, tag => Assert.Equal("01", tag), 
                                                           tag => Assert.Equal("latest", tag));
            }
        }

        [Fact]
        public async Task DeleteAcrRepositoryCRThrowException()
        {
            using (var context = MockContext.Start(GetType().FullName, nameof(DeleteAcrRepositoryCRThrowException)))
            {
                var client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ClassicTestRegistryForDeleting);
                await Assert.ThrowsAsync<AcrErrorsException>(() => client.DeleteAcrRepositoryAsync("prod/bash"));
            }            
        }

        [Fact]
        public async Task UpdateAcrRepositoryAttributesMR()
        {
            using (var context = MockContext.Start(GetType().FullName, nameof(UpdateAcrRepositoryAttributesMR)))
            {
                var client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistry);
                var updateAttributes = new ChangeableAttributes() { DeleteEnabled = true, ListEnabled = true, ReadEnabled = true, WriteEnabled = false };
                await client.UpdateAcrRepositoryAttributesAsync(ACRTestUtil.ProdRepository, updateAttributes);
                var repositoryDetails = await client.GetAcrRepositoryAttributesAsync(ACRTestUtil.ProdRepository);

                Assert.Equal(ACRTestUtil.ManagedTestRegistryFullName, repositoryDetails.Registry);
                Assert.Equal(1, repositoryDetails.TagCount);
                Assert.Equal(1, repositoryDetails.ManifestCount);
                Assert.Equal("2018-09-28T23:37:52.0356217Z", repositoryDetails.LastUpdateTime);
                Assert.Equal("2018-09-28T23:37:51.9668212Z", repositoryDetails.CreatedTime);
                Assert.Equal(ACRTestUtil.ProdRepository, repositoryDetails.ImageName);
                Assert.True(repositoryDetails.ChangeableAttributes.DeleteEnabled);
                Assert.True(repositoryDetails.ChangeableAttributes.ListEnabled);
                Assert.True(repositoryDetails.ChangeableAttributes.ReadEnabled);
                Assert.False(repositoryDetails.ChangeableAttributes.WriteEnabled);

                updateAttributes.WriteEnabled = true;
                await client.UpdateAcrRepositoryAttributesAsync(ACRTestUtil.ProdRepository, updateAttributes);
            }
        }
    }
}
