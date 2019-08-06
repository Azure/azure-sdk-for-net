// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace ContainerRegistry.Tests
{
    using Microsoft.Azure.ContainerRegistry;
    using Microsoft.Azure.ContainerRegistry.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

  public class TagTests
    {
        AcrRepositoryTags prodTags = new AcrRepositoryTags()
        {
            Registry = "azuresdkunittest.azurecr.io",
            ImageName = "prod/bash",
            TagsAttributes = new List<AcrTagAttributesBase>{
               new AcrTagAttributesBase
               {
                   Name = "brandnew",
                   Digest = "sha256:3dfea53d16f8241fd606f8ceda4c8779ffae8e6b5e32c96e00f931de874ec709",
                   CreatedTime = "2019-08-06T19:25:00.2406558Z",
                   LastUpdateTime = "2019-08-06T19:25:00.2406558Z",
                   Signed = false,
                   ChangeableAttributes = new ChangeableAttributes
                   {
                       DeleteEnabled = true,
                       WriteEnabled = true,
                       ListEnabled = true,
                       ReadEnabled = true
                   }
               },
               new AcrTagAttributesBase
               {
                   Name = "latest",
                   Digest = "sha256:dbefd3c583a226ddcef02536cd761d2d86dc7e6f21c53f83957736d6246e9ed8",
                   CreatedTime = "2019-08-01T22:49:11.2741202Z",
                   LastUpdateTime = "2019-08-01T22:49:11.2741202Z",
                   Signed = false,
                   ChangeableAttributes = new ChangeableAttributes
                   {
                       DeleteEnabled = true,
                       WriteEnabled = true,
                       ListEnabled = true,
                       ReadEnabled = true
                   }
               }
           }
        };
       
        [Fact]
        public async Task GetAcrTags()
        {
            using (var context = MockContext.Start(GetType().FullName, nameof(GetAcrTags)))
            {
                var client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistry);
                var tags = await client.GetAcrTagsAsync(ACRTestUtil.ProdRepository);
                
                Assert.Equal(ACRTestUtil.ProdRepository, tags.ImageName);
                Assert.Equal(ACRTestUtil.ManagedTestRegistryFullName, tags.Registry);
                Assert.Equal(2, tags.TagsAttributes.Count);
                validateTagAttributesBase(tags.TagsAttributes[0], prodTags.TagsAttributes[0]);
                validateTagAttributesBase(tags.TagsAttributes[1], prodTags.TagsAttributes[1]);

            }
        }

        [Fact]
        public async Task GetTags()
        {
            using (var context = MockContext.Start(GetType().FullName, nameof(GetTags)))
            {
                var client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistry);
                var tags = await client.GetTagListAsync(ACRTestUtil.ProdRepository);
                Assert.Equal(2, tags.Tags.Count);
                Assert.Equal("latest", tags.Tags[1]);
                Assert.Equal(ACRTestUtil.ProdRepository, tags.Name);
            }
        }

        [Fact]
        public async Task DeleteAcrTag()
        {
            using (var context = MockContext.Start(GetType().FullName, nameof(DeleteAcrTag)))
            {
                var client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistryForChanges);
                await client.DeleteAcrTagAsync(ACRTestUtil.TestRepository, "deleteabletag");
                var tags = await client.GetTagListAsync(ACRTestUtil.TestRepository);
                Assert.DoesNotContain(tags.Tags, tag => { return tag.Equals("deletabletag"); });
            }
        }

        [Fact]
        public async Task UpdateAcrTagAttributes()
        {
            using (var context = MockContext.Start(GetType().FullName, nameof(UpdateAcrTagAttributes)))
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
        public async Task GetAcrTagAttributes()
        {
            using (var context = MockContext.Start(GetType().FullName, nameof(GetAcrTagAttributes)))
            {
                var tag = "latest";
                var client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistry);
                var tagAttributes = await client.GetAcrTagAttributesAsync(ACRTestUtil.ProdRepository, tag);
                Assert.Equal(ACRTestUtil.ProdRepository, tagAttributes.ImageName);
                Assert.Equal(ACRTestUtil.ManagedTestRegistryFullName, tagAttributes.Registry);
                validateTagAttributesBase(tagAttributes.TagAttributes, prodTags.TagsAttributes[1]);
            }
        }

        private void validateTagAttributesBase(AcrTagAttributesBase toCheck, AcrTagAttributesBase expected) {
            Assert.Equal(toCheck.Name, expected.Name);
            Assert.Equal(toCheck.Digest, expected.Digest);
            Assert.Equal(toCheck.CreatedTime, expected.CreatedTime);
            Assert.Equal(toCheck.LastUpdateTime, expected.LastUpdateTime);
            Assert.Equal(toCheck.Signed, expected.Signed);
            Assert.Equal(toCheck.ChangeableAttributes.DeleteEnabled, expected.ChangeableAttributes.DeleteEnabled);
            Assert.Equal(toCheck.ChangeableAttributes.ListEnabled, expected.ChangeableAttributes.ListEnabled);
            Assert.Equal(toCheck.ChangeableAttributes.ReadEnabled, expected.ChangeableAttributes.ReadEnabled);
            Assert.Equal(toCheck.ChangeableAttributes.WriteEnabled, expected.ChangeableAttributes.WriteEnabled);
        }
    }
}
