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
        protected const string SubscriptionId = "galleryPsTestRg";
        protected const string GalleryUniqueName = "galleryPsTestGallery";
        protected const string GalleryImageName = "galleryPsTestGalleryImage";
        protected const string GalleryImageVersionName = "1.0.0";
        
        private string galleryHomeLocation = "eastus2";

        [Fact]
        public void SharedGallery_GetAndList_Tests()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);

                SharedGallery sharedGalleryOut = m_CrpClient.SharedGalleries.Get(galleryHomeLocation, GalleryUniqueName);
                Trace.TraceInformation("Got the shared gallery {0} which is shared to subscription {1}.", GalleryUniqueName, SubscriptionId);
                Assert.NotNull(sharedGalleryOut);
                ValidateSharedGallery(sharedGalleryOut);


                IPage<SharedGallery> sharedGalleriesList = m_CrpClient.SharedGalleries.List(galleryHomeLocation, "tenant");
                Trace.TraceInformation("Got the shared galleries which are shared to tenant of subscription {0}.", SubscriptionId);

                int count = sharedGalleriesList.Count();
                Assert.Equal(2, count);

                foreach(SharedGallery gallery in sharedGalleriesList)
                {
                    if(gallery.Name == GalleryUniqueName)
                    {
                        ValidateSharedGallery(gallery);
                        break;
                    }
                }

                sharedGalleriesList = m_CrpClient.SharedGalleries.List(galleryHomeLocation);

                count = sharedGalleriesList.Count();
                Assert.Equal(1, count);
                Trace.TraceInformation("Got the shared gallery {0} which is shared to subscription {1}.", GalleryUniqueName, SubscriptionId);

                ValidateSharedGallery(sharedGalleriesList.First());

            }
        }

        [Fact]
        public void SharedGalleryImage_GetAndList_Tests()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);

                SharedGalleryImage sharedGalleryImageOut = m_CrpClient.SharedGalleryImages.Get(galleryHomeLocation, GalleryUniqueName, GalleryImageName);
                Trace.TraceInformation("Got the shared gallery image {0} which is shared to subscription {1}.", GalleryImageName, SubscriptionId);
                Assert.NotNull(sharedGalleryImageOut);
                ValidateSharedGalleryImage(sharedGalleryImageOut);


                IPage<SharedGalleryImage> sharedGalleryImagesList = m_CrpClient.SharedGalleryImages.List(galleryHomeLocation, GalleryUniqueName, "tenant");
                Trace.TraceInformation("Got the shared gallery images which are shared to tenant of subscription {0}.", SubscriptionId);

                int count = sharedGalleryImagesList.Count();
                Assert.Equal(2, count);

                foreach (SharedGalleryImage galleryImage in sharedGalleryImagesList)
                {
                    if (galleryImage.Name == GalleryImageName)
                    {
                        ValidateSharedGalleryImage(galleryImage);
                        break;
                    }
                }

                sharedGalleryImagesList = m_CrpClient.SharedGalleryImages.List(galleryHomeLocation, GalleryUniqueName);

                count = sharedGalleryImagesList.Count();
                Assert.Equal(1, count);
                Trace.TraceInformation("Got the shared gallery {0} which is shared to subscription {1}.", GalleryUniqueName, SubscriptionId);

                ValidateSharedGalleryImage(sharedGalleryImagesList.First());
            }
        }

        [Fact]
        public void SharedGalleryImageVersion_GetAndList_Tests()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                EnsureClientsInitialized(context);

                SharedGalleryImageVersion sharedGalleryImageVersionOut = m_CrpClient.SharedGalleryImageVersions.Get(galleryHomeLocation, GalleryUniqueName, GalleryImageName, GalleryImageVersionName);
                Trace.TraceInformation("Got the shared gallery image name {0} which is shared to subscription {1}.", GalleryImageVersionName, SubscriptionId);
                Assert.NotNull(sharedGalleryImageVersionOut);
                ValidateSharedGalleryImageVersion(sharedGalleryImageVersionOut);

                IPage<SharedGalleryImageVersion> sharedGalleryImageVersionsList = m_CrpClient.SharedGalleryImageVersions.List(galleryHomeLocation, GalleryUniqueName, GalleryImageName, "tenant");
                Trace.TraceInformation("Got the shared gallery image versions which are shared to tenant of subscription {0}.", SubscriptionId);

                int count = sharedGalleryImageVersionsList.Count();
                Assert.Equal(2, count);

                foreach (SharedGalleryImageVersion galleryImageVersion in sharedGalleryImageVersionsList)
                {
                    if (galleryImageVersion.Name == GalleryImageVersionName)
                    {
                        ValidateSharedGalleryImageVersion(galleryImageVersion);
                        break;
                    }
                }

                sharedGalleryImageVersionsList = m_CrpClient.SharedGalleryImageVersions.List(galleryHomeLocation, GalleryUniqueName, GalleryImageName);
                
                count = sharedGalleryImageVersionsList.Count();
                Assert.Equal(1, count);
                Trace.TraceInformation("Got the shared gallery {0} which is shared to  subscription {1}.", GalleryUniqueName, SubscriptionId);

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
        }
    }
}
