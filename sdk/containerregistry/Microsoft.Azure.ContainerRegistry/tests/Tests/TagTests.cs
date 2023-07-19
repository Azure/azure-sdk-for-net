// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace ContainerRegistry.Tests
{
    using Microsoft.Azure.ContainerRegistry;
    using Microsoft.Azure.ContainerRegistry.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;

    public class TagTests
    {
        #region Test Values
        private static readonly TagList prodTags = new TagList()
        {
            Registry = ACRTestUtil.ManagedTestRegistry,
            ImageName = ACRTestUtil.ProdRepository,
            Tags = new List<TagAttributesBase>{
               new TagAttributesBase
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
               new TagAttributesBase
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
        #endregion

        [Fact]
        public async Task GetAcrTags()
        {
            using (var context = MockContext.Start(GetType(), nameof(GetAcrTags)))
            {
                var client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistry);
                var tags = await client.Tag.GetListAsync(ACRTestUtil.ProdRepository);

                Assert.Equal(ACRTestUtil.ProdRepository, tags.ImageName);
                Assert.Equal(ACRTestUtil.ManagedTestRegistryFullName, tags.Registry);
                Assert.Equal(2, tags.Tags.Count);
                ValidateTagAttributesBase(tags.Tags[0], prodTags.Tags[0]);
                ValidateTagAttributesBase(tags.Tags[1], prodTags.Tags[1]);

            }
        }

        [Fact]
        public async Task GetTags()
        {
            using (var context = MockContext.Start(GetType(), nameof(GetTags)))
            {
                var client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistry);
                var tags = await client.Tag.GetListAsync(ACRTestUtil.ProdRepository);
                Assert.Equal(2, tags.Tags.Count);
                Assert.Equal("latest", tags.Tags[1].Name);
                Assert.Equal(ACRTestUtil.ProdRepository, tags.ImageName);
            }
        }

        [Fact]
        public async Task DeleteAcrTag()
        {
            using (var context = MockContext.Start(GetType(), nameof(DeleteAcrTag)))
            {
                var client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistryForChanges);
                var tags = await client.Tag.GetListAsync(ACRTestUtil.deleteableRepository);
                await client.Tag.DeleteAsync(ACRTestUtil.deleteableRepository, tags.Tags[0].Name);
              
                var newTags = await client.Tag.GetListAsync(ACRTestUtil.deleteableRepository);
                Assert.DoesNotContain(newTags.Tags, tag => { return tag.Equals(tags.Tags[0]); });
            }
        }

        [Fact]
        public async Task UpdateAcrTagAttributes()
        {
            using (var context = MockContext.Start(GetType(), nameof(UpdateAcrTagAttributes)))
            {
                var updateAttributes = new ChangeableAttributes() { DeleteEnabled = true, ListEnabled = true, ReadEnabled = true, WriteEnabled = false };
                var tag = "latest";
                var client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistryForChanges);
                await client.Tag.UpdateAttributesAsync(ACRTestUtil.changeableRepository, tag, updateAttributes);

                var tagAttributes = await client.Tag.GetAttributesAsync(ACRTestUtil.changeableRepository, tag);
                Assert.False(tagAttributes.Attributes.ChangeableAttributes.WriteEnabled);

                updateAttributes.WriteEnabled = true;
                await client.Tag.UpdateAttributesAsync(ACRTestUtil.changeableRepository, tag, updateAttributes);
                tagAttributes = await client.Tag.GetAttributesAsync(ACRTestUtil.changeableRepository, tag);

                Assert.True(tagAttributes.Attributes.ChangeableAttributes.WriteEnabled);
            }
        }

        [Fact]
        public async Task GetAcrTagAttributes()
        {
            using (var context = MockContext.Start(GetType(), nameof(GetAcrTagAttributes)))
            {
                var tag = "latest";
                var client = await ACRTestUtil.GetACRClientAsync(context, ACRTestUtil.ManagedTestRegistry);
                var tagAttributes = await client.Tag.GetAttributesAsync(ACRTestUtil.ProdRepository, tag);
                Assert.Equal(ACRTestUtil.ProdRepository, tagAttributes.ImageName);
                Assert.Equal(ACRTestUtil.ManagedTestRegistryFullName, tagAttributes.Registry);
                ValidateTagAttributesBase(tagAttributes.Attributes, prodTags.Tags[1]);
            }
        }

        private void ValidateTagAttributesBase(TagAttributesBase toCheck, TagAttributesBase expected)
        {
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
