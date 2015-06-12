//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using Microsoft.Azure;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Management.RemoteApp;
using Microsoft.WindowsAzure.Management.RemoteApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace RemoteApp.Tests
{
    /// <summary>
    /// RemoteApp template image specific test cases
    /// </summary>
    public class TemplateImageTests : RemoteAppTestBase
    {
        private const string testRegion = "West US";
        private const double defaultTimeoutMs = 30000;

        private static string GetTestImageName()
        {
            return string.Format("image{0}", Guid.NewGuid().ToString());
        }

        /// <summary>
        /// Testing of creation of a template image
        /// </summary>
        [Fact]
        public void CanCreateTemplateImagesSuccessfully()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                string imageName = "my_unit_test_created_templateimage";
                string returnedImageName = null;
                HttpRecorderMode mode = HttpMockServer.GetCurrentMode();
                RemoteAppManagementClient client = GetRemoteAppManagementClient();
                TemplateImageResult setResponse;
                AzureOperationResponse deleteResponse;
                TemplateImageListResult listResponse = null;
                IList<TemplateImage> imageList;
                TemplateImage myImage = null;
                bool foundTestImage = false;
                string newName = "renamed_my_test_image";
                TemplateImageDetails renameDetails = null;

                TemplateImageDetails newImageDetails = new TemplateImageDetails()
                {
                    Name = imageName,
                    Region = "West US"
                };

                Assert.DoesNotThrow(() =>
                {
                    setResponse = client.TemplateImages.Set(newImageDetails);
                });

                // now check the list
                Assert.DoesNotThrow(() =>
                {
                    listResponse = client.TemplateImages.List();
                    imageList = listResponse.RemoteAppTemplateImageList;

                    foreach (TemplateImage image in imageList)
                    {
                        if ((image.Name == imageName))
                        {
                            foreach (string region in image.RegionList)
                            {
                                if (region == newImageDetails.Region)
                                {
                                    foundTestImage = true;
                                    // cleanup
                                    returnedImageName = image.Name;
                                    myImage = image;

                                    break;
                                }
                            }
                        }
                    }
                });

                Assert.True(foundTestImage);
                Assert.False(string.IsNullOrEmpty(returnedImageName));
                Assert.NotNull(myImage);

                // rename the image
                renameDetails = new TemplateImageDetails()
                {
                    Id = myImage.Id,
                    Name = newName,
                    Region = "West US"
                };

                setResponse = null;

                Assert.DoesNotThrow(() =>
                {
                    setResponse = client.TemplateImages.Set(renameDetails);
                });

                Assert.NotNull(setResponse);
                Assert.NotNull(setResponse.TemplateImage);
                Assert.Equal(System.Net.HttpStatusCode.OK, setResponse.StatusCode);

                // verify that we have an image with the new name
                TemplateImageResult imageResponse = null;

                Assert.DoesNotThrow(() =>
                {
                    imageResponse = client.TemplateImages.Get(newName);
                });

                Assert.NotNull(imageResponse);
                Assert.NotNull(imageResponse.TemplateImage);
                Assert.Equal(newName, imageResponse.TemplateImage.Name);
                Assert.True(imageResponse.TemplateImage.RegionList.Contains("West US"), "Unexpected region of the renamed image: " + String.Join(", ", imageResponse.TemplateImage.RegionList));

                Assert.DoesNotThrow(() =>
                {
                    deleteResponse = client.TemplateImages.Delete(newName);
                });
            }
        }

        /// <summary>
        /// Testing of querying of a list of template images
        /// </summary>
        [Fact]
        public void CanListTemplateImagesSuccessfully()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                HttpRecorderMode mode = HttpMockServer.GetCurrentMode();
                RemoteAppManagementClient remoteAppManagementClient = GetRemoteAppManagementClient();

                Assert.DoesNotThrow(() =>
                {
                    TemplateImageListResult response = remoteAppManagementClient.TemplateImages.List();
                    IList<TemplateImage> templateImageList = response.RemoteAppTemplateImageList;
                });
            }
        }

        /// <summary>
        /// Testing of getting the upload template image script
        /// </summary>
        [Fact]
        public void CanGetUploadScript()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                HttpRecorderMode mode = HttpMockServer.GetCurrentMode();
                RemoteAppManagementClient remoteAppManagementClient = GetRemoteAppManagementClient();

                UploadScriptResult scriptResult = remoteAppManagementClient.TemplateImages.GetUploadScript();
                Assert.NotNull(scriptResult);
                Assert.NotNull(scriptResult.Script);
            }
        }

        /// <summary>
        /// Testing of ensuring the storage in a given region for template image
        /// </summary>
        [Fact]
        public void CanEnsureStorageInRegion()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                HttpRecorderMode mode = HttpMockServer.GetCurrentMode();
                RemoteAppManagementClient remoteAppManagementClient = GetRemoteAppManagementClient();

                // Assume region to be "West US" for test purposes
                OperationResultWithTrackingId ensureResult = remoteAppManagementClient.TemplateImages.EnsureStorageInRegion("West US");
                Assert.NotNull(ensureResult);
            }
        }

        /// <summary>
        /// Testing of querying of template image details by name
        /// </summary>
        [Fact]
        public void CanGetTemplateImageByName()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                RemoteAppManagementClient client = GetRemoteAppManagementClient();

                TemplateImageListResult templatImagesList = client.TemplateImages.List();

                Assert.NotNull(templatImagesList);
                Assert.NotEmpty(templatImagesList.RemoteAppTemplateImageList);
                Assert.True(templatImagesList.StatusCode == System.Net.HttpStatusCode.OK);

                foreach (TemplateImage image in templatImagesList.RemoteAppTemplateImageList)
                {
                    TemplateImageResult imageByNameResponse = client.TemplateImages.Get(image.Name);

                    Assert.NotNull(imageByNameResponse);
                    Assert.NotNull(imageByNameResponse.TemplateImage);
                    Assert.True(imageByNameResponse.TemplateImage.Id == image.Id);
                    Assert.True(imageByNameResponse.TemplateImage.Name == image.Name);
                }
            }
        }
    }
}
