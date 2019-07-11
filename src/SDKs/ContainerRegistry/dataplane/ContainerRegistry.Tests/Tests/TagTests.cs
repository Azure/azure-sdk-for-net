// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace ContainerRegistry.Tests
{
    using Microsoft.Azure.ContainerRegistry;
    using Microsoft.Azure.ContainerRegistry.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class TagTests
    {
        [Fact]
        public async Task GetAcrTagsMR()
        {
            using (var context = MockContext.Start(GetType().FullName, nameof(GetAcrTagsMR)))
            {
                var client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistry);
                var tags = await client.GetAcrTagsAsync(ACRTestUtil.ProdRepository);
                
                Assert.Equal(ACRTestUtil.ProdRepository, tags.ImageName);
                Assert.Equal(ACRTestUtil.ManagedTestRegistryFullName, tags.Registry);
                Assert.Equal(1, tags.TagsAttributes.Count);
                var tagAttributes = tags.TagsAttributes[0];
                Assert.Equal("latest", tagAttributes.Name);
                Assert.Equal("2018-09-28T23:37:52.0607161Z", tagAttributes.LastUpdateTime);
                Assert.Equal("2018-09-28T23:37:52.0607161Z", tagAttributes.CreatedTime);
                Assert.Equal("sha256:eabe547f78d4c18c708dd97ec3166cf7464cc651f1cbb67e70d407405b7ad7b6", tagAttributes.Digest);
                Assert.True(tagAttributes.ChangeableAttributes.DeleteEnabled);
                Assert.True(tagAttributes.ChangeableAttributes.ReadEnabled);
                Assert.True(tagAttributes.ChangeableAttributes.ListEnabled);
                Assert.True(tagAttributes.ChangeableAttributes.WriteEnabled);
            }
        }

        [Fact]
        public async Task GetAcrTagsCRThrowException()
        {
            using (var context = MockContext.Start(GetType().FullName, nameof(GetAcrTagsCRThrowException)))
            {
                var client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ClassicTestRegistry);
                await Assert.ThrowsAsync<AcrErrorsException>(() => client.GetAcrTagsAsync(ACRTestUtil.ProdRepository));
            }
        }

        [Fact]
        public async Task GetTagsMR()
        {
            using (var context = MockContext.Start(GetType().FullName, nameof(GetTagsMR)))
            {
                var client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistry);
                var tags = await client.GetTagListAsync(ACRTestUtil.ProdRepository);
                Assert.Equal(1, tags.Tags.Count);
                Assert.Equal("latest", tags.Tags[0]);
                Assert.Equal(ACRTestUtil.ProdRepository, tags.Name);
            }
        }

        [Fact]
        public async Task GetTagsCR()
        {
            using (var context = MockContext.Start(GetType().FullName, nameof(GetTagsCR)))
            {
                var client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ClassicTestRegistry);
                var tags = await client.GetTagListAsync(ACRTestUtil.ProdRepository);
                Assert.Equal(1, tags.Tags.Count);
                Assert.Equal("latest", tags.Tags[0]);
                Assert.Equal(ACRTestUtil.ProdRepository, tags.Name);
            }
        }

        [Fact]
        public async Task DeleteAcrTagMR()
        {
            using (var context = MockContext.Start(GetType().FullName, nameof(DeleteAcrTagMR)))
            {
                var client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistryForDeleting);
                await client.DeleteAcrTagAsync(ACRTestUtil.ProdRepository, "latest");
                var tags = await client.GetTagListAsync(ACRTestUtil.ProdRepository);
                Assert.Equal(0, tags.Tags.Count);
            }
        }

        [Fact]
        public async Task DeleteAcrTagCRThrowException()
        {
            using (var context = MockContext.Start(GetType().FullName, nameof(DeleteAcrTagCRThrowException)))
            {
                var client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ClassicTestRegistry);
                await Assert.ThrowsAsync<AcrErrorsException>(() => client.DeleteAcrTagAsync(ACRTestUtil.ProdRepository, "latest"));
            }
        }

        [Fact]
        public async Task UpdateAcrTagAttributesMR()
        {
            using (var context = MockContext.Start(GetType().FullName, nameof(UpdateAcrTagAttributesMR)))
            {
                var updateAttributes = new ChangeableAttributes() { DeleteEnabled = true, ListEnabled = true, ReadEnabled = true, WriteEnabled = false };
                var tag = "latest";
                var client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistry);
                await client.UpdateAcrTagAttributesAsync(ACRTestUtil.ProdRepository, tag, updateAttributes);
                var tagAttributes = await client.GetAcrTagAttributesAsync(ACRTestUtil.ProdRepository, tag);
                
                Assert.False(tagAttributes.TagAttributes.ChangeableAttributes.WriteEnabled);

                updateAttributes.WriteEnabled = true;
                await client.UpdateAcrTagAttributesAsync(ACRTestUtil.ProdRepository, tag, updateAttributes);
                tagAttributes = await client.GetAcrTagAttributesAsync(ACRTestUtil.ProdRepository, tag);

                Assert.True(tagAttributes.TagAttributes.ChangeableAttributes.WriteEnabled);
            }
        }

        [Fact]
        public async Task UpdateAcrTagAttributesCRThrowException()
        {
            using (var context = MockContext.Start(GetType().FullName, nameof(UpdateAcrTagAttributesCRThrowException)))
            {
                var client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ClassicTestRegistry);
                await Assert.ThrowsAsync<AcrErrorsException>(() => client.UpdateAcrTagAttributesAsync(ACRTestUtil.ProdRepository, "latest", default(ChangeableAttributes)));
            }
        }

        [Fact]
        public async Task GetAcrTagAttributesMR()
        {
            using (var context = MockContext.Start(GetType().FullName, nameof(GetAcrTagAttributesMR)))
            {
                var tag = "latest";
                var client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistry);
                var tagAttributes = await client.GetAcrTagAttributesAsync(ACRTestUtil.ProdRepository, tag);

                Assert.Equal(ACRTestUtil.ManagedTestRegistryFullName, tagAttributes.Registry);
                Assert.Equal(ACRTestUtil.ProdRepository, tagAttributes.ImageName);
                Assert.Equal("2018-09-28T23:37:52.0607161Z", tagAttributes.TagAttributes.CreatedTime);
                Assert.Equal("sha256:eabe547f78d4c18c708dd97ec3166cf7464cc651f1cbb67e70d407405b7ad7b6", tagAttributes.TagAttributes.Digest);
                Assert.Equal("2018-09-28T23:37:52.0607161Z", tagAttributes.TagAttributes.LastUpdateTime);
                Assert.Equal(tag, tagAttributes.TagAttributes.Name);
                Assert.False(tagAttributes.TagAttributes.Signed);
                Assert.True(tagAttributes.TagAttributes.ChangeableAttributes.DeleteEnabled);
                Assert.True(tagAttributes.TagAttributes.ChangeableAttributes.ReadEnabled);
                Assert.True(tagAttributes.TagAttributes.ChangeableAttributes.ListEnabled);
                Assert.True(tagAttributes.TagAttributes.ChangeableAttributes.WriteEnabled);
            }
        }

        [Fact]
        public async Task GetAcrTagAttributesCRThrowException()
        {
            using (var context = MockContext.Start(GetType().FullName, nameof(GetAcrTagAttributesCRThrowException)))
            {
                var client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ClassicTestRegistry);
                await Assert.ThrowsAsync<AcrErrorsException>(() => client.GetAcrTagAttributesAsync(ACRTestUtil.ProdRepository, "latest"));
            }
        }
    }
}
