using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.Azure.Management.Compute;
using System.Diagnostics;
using Microsoft.Rest.Azure;
using System.Linq;

namespace Compute.Tests
{
    public class CommunityGalleryTests : VMTestBase
    {
        // these needs to be decided and created
        // Gallery team is responsible for maintaining these long lived gallery
        protected const string PublicGalleryName = "PIRBVT-6c64f11e-ad23-4737-a58a-4f3c85acadbf";
        protected const string GalleryImageName = "communitygallerylrwah";
        protected const string GalleryImageVersionName = "1.0.0";

        private string galleryAccessLocation = "eastus2euap";

        [Fact]
        public void CommunityGallery_Get_Tests()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);

                CommunityGallery communityGalleryOut = m_CrpClient.CommunityGalleries.Get(galleryAccessLocation, PublicGalleryName);
                Trace.TraceInformation("Got the community gallery {0} which is shared to public.", PublicGalleryName);
                Assert.NotNull(communityGalleryOut);
                ValidateCommunityGallery(communityGalleryOut);
            }
        }

        [Fact]
        public void CommunityGalleryImage_GetAndList_Tests()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);

                CommunityGalleryImage communityGalleryImageOut = m_CrpClient.CommunityGalleryImages.Get(galleryAccessLocation, PublicGalleryName, GalleryImageName);
                Trace.TraceInformation("Got the community gallery image {0} which is shared to public.", GalleryImageName);
                Assert.NotNull(communityGalleryImageOut);

                ValidateCommunityGalleryImage(communityGalleryImageOut);


                IPage<CommunityGalleryImage> communityGalleryImagesList = m_CrpClient.CommunityGalleryImages.List(galleryAccessLocation, PublicGalleryName);
                Trace.TraceInformation("Got the community gallery image list which are shared to public.");

                int count = communityGalleryImagesList.Count();
                Assert.Equal(1, count);

                foreach (CommunityGalleryImage galleryImage in communityGalleryImagesList)
                {
                    if (galleryImage.Name == GalleryImageName)
                    {
                        ValidateCommunityGalleryImage(galleryImage);
                        break;
                    }
                }
            }
        }

        [Fact]
        public void CommunityGalleryImageVersion_GetAndList_Tests()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);

                CommunityGalleryImageVersion communityGalleryImageVersionOut = m_CrpClient.CommunityGalleryImageVersions.Get(galleryAccessLocation, PublicGalleryName, GalleryImageName, GalleryImageVersionName);
                Trace.TraceInformation("Got the community gallery image name {0} which is shared to public.", GalleryImageVersionName);
                Assert.NotNull(communityGalleryImageVersionOut);
                ValidateCommunityGalleryImageVersion(communityGalleryImageVersionOut);

                IPage<CommunityGalleryImageVersion> communityGalleryImageVersionsList = m_CrpClient.CommunityGalleryImageVersions.List(galleryAccessLocation, PublicGalleryName, GalleryImageName);
                Trace.TraceInformation("Got the community gallery image versions which are shared to public.");

                int count = communityGalleryImageVersionsList.Count();
                Assert.Equal(1, count);

                foreach (CommunityGalleryImageVersion galleryImageVersion in communityGalleryImageVersionsList)
                {
                    if (galleryImageVersion.Name == GalleryImageVersionName)
                    {
                        ValidateCommunityGalleryImageVersion(galleryImageVersion);
                        break;
                    }
                }
            }
        }

        private void ValidateCommunityGallery(CommunityGallery communityGallery)
        {
            string expectedId = "/CommunityGalleries/" + PublicGalleryName;
            Assert.Equal(expectedId, communityGallery.UniqueId);
        }

        private void ValidateCommunityGalleryImage(CommunityGalleryImage communityGalleryImage)
        {
            string expectedId = "/CommunityGalleries/" + PublicGalleryName + "/Images/" + GalleryImageName;
            Assert.Equal(expectedId, communityGalleryImage.UniqueId);
            Assert.NotNull(communityGalleryImage.Eula);
            Assert.NotNull(communityGalleryImage.PrivacyStatementUri);
        }

        private void ValidateCommunityGalleryImageVersion(CommunityGalleryImageVersion communityGalleryImageVersion)
        {
            string expectedId = "/CommunityGalleries/" + PublicGalleryName + "/Images/" + GalleryImageName + "/Versions/" + GalleryImageVersionName;
            Assert.Equal(expectedId, communityGalleryImageVersion.UniqueId);
            Assert.NotNull(communityGalleryImageVersion.StorageProfile);
            Assert.NotNull(communityGalleryImageVersion.ExcludeFromLatest);
            Assert.NotNull(communityGalleryImageVersion.StorageProfile.OsDiskImage);
        }

    }
}
