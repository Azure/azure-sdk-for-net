using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.ResourceManager;
using System.Diagnostics;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Rest.Azure;
using System.Linq;
using Microsoft.Azure.Management.Compute;


namespace Compute.Tests
{
    public class SharedGalleryTests : VMTestBase
    {
        // these needs to be decided and created, especially subscription.
        // two gallery shared to the tenant, but only one gallery shared to the sub
        protected const string GalleryUniqueName = "97f78232-382b-46a7-8a72-964d692c4f3f-LONGLIVEGALLERYFOJNVV";
        protected const string GalleryImageName = "jmaesscc";
        protected const string GalleryImageVersionName = "1.0.0";
        
        private string galleryAccessLocation = "eastus2euap";

        [Fact]
        public void SharedGallery_GetAndList_Tests()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);

                SharedGallery sharedGalleryOut = m_CrpClient.SharedGalleries.Get(galleryAccessLocation, GalleryUniqueName);
                Trace.TraceInformation("Got the shared gallery {0} which is shared to current subscription.", GalleryUniqueName);
                Assert.NotNull(sharedGalleryOut);
                ValidateSharedGallery(sharedGalleryOut);


                IPage<SharedGallery> sharedGalleriesList = m_CrpClient.SharedGalleries.List(galleryAccessLocation, "tenant");
                Trace.TraceInformation("Got the shared galleries which are shared to tenant of current subscription.");

                int count = sharedGalleriesList.Count();
                Assert.True(count > 0);
                foreach (SharedGallery gallery in sharedGalleriesList)
                {
                    if(gallery.Name == GalleryUniqueName)
                    {
                        ValidateSharedGallery(gallery);
                        break;
                    }
                }

                sharedGalleriesList = m_CrpClient.SharedGalleries.List(galleryAccessLocation);

                count = sharedGalleriesList.Count();
                Assert.True(count > 0);
                Trace.TraceInformation("Got the shared gallery {0} which is shared to current subscription.", GalleryUniqueName);
                foreach (SharedGallery gallery in sharedGalleriesList)
                {
                    if (gallery.Name == GalleryUniqueName)
                    {
                        ValidateSharedGallery(gallery);
                        break;
                    }
                }

            }
        }

        [Fact]
        public void SharedGalleryImage_GetAndList_Tests()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);

                SharedGalleryImage sharedGalleryImageOut = m_CrpClient.SharedGalleryImages.Get(galleryAccessLocation, GalleryUniqueName, GalleryImageName);
                Trace.TraceInformation("Got the shared gallery image {0} which is shared to current subscription.", GalleryImageName);
                Assert.NotNull(sharedGalleryImageOut);
                
                ValidateSharedGalleryImage(sharedGalleryImageOut);
                

                IPage<SharedGalleryImage> sharedGalleryImagesList = m_CrpClient.SharedGalleryImages.List(galleryAccessLocation, GalleryUniqueName, "tenant");
                Trace.TraceInformation("Got the shared gallery images which are shared to tenant of current subscription.");

                int count = sharedGalleryImagesList.Count();
                Assert.Equal(1, count);

                foreach (SharedGalleryImage galleryImage in sharedGalleryImagesList)
                {
                    if (galleryImage.Name == GalleryImageName)
                    {
                        ValidateSharedGalleryImage(galleryImage);
                        break;
                    }
                }

                sharedGalleryImagesList = m_CrpClient.SharedGalleryImages.List(galleryAccessLocation, GalleryUniqueName);

                count = sharedGalleryImagesList.Count();
                Assert.Equal(1, count);
                Trace.TraceInformation("Got the shared gallery {0} which is shared to current subscription.", GalleryUniqueName);

                ValidateSharedGalleryImage(sharedGalleryImagesList.First());

                sharedGalleryImagesList = m_CrpClient.SharedGalleryImages.List(galleryAccessLocation, GalleryUniqueName, sharedTo: SharedToValues.Tenant);

                count = sharedGalleryImagesList.Count();
                Assert.Equal(1, count);
                Trace.TraceInformation("Got the shared gallery {0} which is shared to current tenant.", GalleryUniqueName);

                ValidateSharedGalleryImage(sharedGalleryImagesList.First());
            }
        }

        [Fact]
        public void SharedGalleryImageVersion_GetAndList_Tests()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);

                SharedGalleryImageVersion sharedGalleryImageVersionOut = m_CrpClient.SharedGalleryImageVersions.Get(galleryAccessLocation, GalleryUniqueName, GalleryImageName, GalleryImageVersionName);
                Trace.TraceInformation("Got the shared gallery image name {0} which is shared to current subscription.", GalleryImageVersionName);
                Assert.NotNull(sharedGalleryImageVersionOut);
                ValidateSharedGalleryImageVersion(sharedGalleryImageVersionOut);

                IPage<SharedGalleryImageVersion> sharedGalleryImageVersionsList = m_CrpClient.SharedGalleryImageVersions.List(galleryAccessLocation, GalleryUniqueName, GalleryImageName, "tenant");
                Trace.TraceInformation("Got the shared gallery image versions which are shared to tenant of current subscription.");

                int count = sharedGalleryImageVersionsList.Count();
                Assert.Equal(1, count);

                foreach (SharedGalleryImageVersion galleryImageVersion in sharedGalleryImageVersionsList)
                {
                    if (galleryImageVersion.Name == GalleryImageVersionName)
                    {
                        ValidateSharedGalleryImageVersion(galleryImageVersion);
                        break;
                    }
                }

                sharedGalleryImageVersionsList = m_CrpClient.SharedGalleryImageVersions.List(galleryAccessLocation, GalleryUniqueName, GalleryImageName);
                
                count = sharedGalleryImageVersionsList.Count();
                Assert.Equal(1, count);
                Trace.TraceInformation("Got the shared gallery {0} which is shared to current subscription.", GalleryUniqueName);

                ValidateSharedGalleryImageVersion(sharedGalleryImageVersionsList.First());

                sharedGalleryImageVersionsList = m_CrpClient.SharedGalleryImageVersions.List(galleryAccessLocation, GalleryUniqueName, GalleryImageName,
                    sharedTo: SharedToValues.Tenant);

                count = sharedGalleryImageVersionsList.Count();
                Assert.Equal(1, count);
                Trace.TraceInformation("Got the shared gallery {0} which is shared to current tenant.", GalleryUniqueName);

                ValidateSharedGalleryImageVersion(sharedGalleryImageVersionsList.First());
            }
        }

        private void ValidateSharedGallery(SharedGallery sharedGallery)
        {
            string expectedId = "/SharedGalleries/" + GalleryUniqueName;
            Assert.Equal(expectedId, sharedGallery.UniqueId);
        }

        private void ValidateSharedGalleryImage(SharedGalleryImage sharedGalleryImage)
        {
            string expectedId = "/SharedGalleries/" + GalleryUniqueName + "/Images/" + GalleryImageName;
            Assert.Equal(expectedId, sharedGalleryImage.UniqueId);
        }

        private void ValidateSharedGalleryImageVersion(SharedGalleryImageVersion sharedGalleryImageVersion)
        {
            string expectedId = "/SharedGalleries/" + GalleryUniqueName + "/Images/" + GalleryImageName + "/Versions/" + GalleryImageVersionName;
            Assert.Equal(expectedId, sharedGalleryImageVersion.UniqueId);
            Assert.NotNull(sharedGalleryImageVersion.StorageProfile);
            Assert.NotNull(sharedGalleryImageVersion.ExcludeFromLatest);
            Assert.NotNull(sharedGalleryImageVersion.StorageProfile.OsDiskImage);
        }
    }
}
