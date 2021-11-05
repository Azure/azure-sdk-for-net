using System;
using System.Net.Http;
using Microsoft.Rest.Serialization;
using Microsoft.Azure.CognitiveServices.ContentModerator.Models;
using Microsoft.Azure.CognitiveServices.ContentModerator;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using ContentModeratorTests.Helpers;
using ContentModeratorTests.Data;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Test.HttpRecorder;

namespace ContentModeratorTests
{
    public class ImageListManagement : TestBase
    {

        ContentModeratorClient client = null;
        Responses results = new Responses();
        static ContentModeratorAPI api;
        public static List<ImageList> allImageLists;
        public static ImageIds allImages;


        public ImageListManagement()
        {
            TestSetUpConfiguration();
        }


        internal void TestSetUp()
        {
            TestSetUpConfiguration();
        }

        internal void TestCleanup()
        {
            TestCleanupConfiguration();
        }


        #region ListManagementImageLists

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6215")]
        public void GetImageLists()
        {
            try
            {
                using (MockContext context = MockContext.Start("ImageListManagement"))
                {
                    HttpMockServer.Initialize("ImageListManagement", "GetImageLists");
                    api = ContentModeratorAPI.GET_ALL_IMAGE_LIST;
                    client = Constants.GenerateClient(api, HttpMockServer.CreateInstance());
                    results = Constants.GetResponse(client, api, string.Empty);
                    Assert.NotNull(results.GetAllImageLists);
                    Assert.Equal(HttpStatusCode.OK, results.GetAllImageLists.Response.StatusCode);

                    allImageLists = results.GetAllImageLists.Body.ToList();
                    if (allImageLists.Count > 0)
                    {
                        Assert.True(allImageLists.TrueForAll(x => !string.IsNullOrEmpty(((int)x.Id).ToString()) && !string.IsNullOrEmpty(x.Name) && x.Metadata != null), "Failed to get the result");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6215")]
        public void DeleteImageList()
        {
            try
            {
                using (MockContext context = MockContext.Start("ImageListManagement"))
                {

                    //GetImageLists();
                    //wait(2);
                    api = ContentModeratorAPI.DELETE_IMAGE_LIST;
                    //imageListIdToDelete = ((int)allImageLists[0].Id).ToString();
                    HttpMockServer.Initialize("ImageListManagement", "DeleteImageList");
                    client = Constants.GenerateClient(api, HttpMockServer.CreateInstance());
                    //results = Constants.GetResponse(client, api, imageListIdToDelete);
                    results = Constants.GetResponse(client, api, "157298");
                    var deleteImageLists = results.DeleteImageLists;
                    Assert.NotNull(deleteImageLists);
                    Assert.Equal(HttpStatusCode.OK, deleteImageLists.Response.StatusCode);
                    Assert.Equal("",deleteImageLists.Body);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6215")]
        public void CreateImageLists()
        {
            try
            {
                using (MockContext context = MockContext.Start("ImageListManagement"))
                {

                    //int counter = 0;
                    //GetImageLists();
                    //wait(2);
                    //counter = allImageLists.Count;
                    //if (counter == 5)
                    //{
                    //    DeleteImageList();
                    //    counter--;
                    //    wait(2);
                    //}

                    // Create ImageLIsts
                    api = ContentModeratorAPI.CREATE_IMAGE_LIST;
                    //while (counter < 5)
                    {
                        HttpMockServer.Initialize("ImageListManagement", "CreateImageLists");
                        client = Constants.GenerateClient(api, HttpMockServer.CreateInstance());
                        results = Constants.GetResponse(client, api, string.Empty);

                        var createImageList = results.CreateImageList;
                        Assert.NotNull(createImageList);
                        Assert.Equal(HttpStatusCode.OK, createImageList.Response.StatusCode);

                        //counter++;
                        wait(2);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6215")]
        public void UpdateImageList()
        {
            try
            {
                using (MockContext context = MockContext.Start("ImageListManagement"))
                {

                    //GetImageLists();
                    //wait(2);
                    api = ContentModeratorAPI.UPDATE_IMAGE_LIST;
                    //imageListIdToUpdate = ((int)allImageLists[1].Id).ToString();
                    HttpMockServer.Initialize("ImageListManagement", "UpdateImageList");
                    client = Constants.GenerateClient(api, HttpMockServer.CreateInstance());
                    //results = Constants.GetResponse(client, api, imageListIdToUpdate);
                    results = Constants.GetResponse(client, api, "157184");
                    var updateImageLists = results.UpdateImageList;
                    Assert.NotNull(updateImageLists);
                    Assert.Equal(HttpStatusCode.OK, updateImageLists.Response.StatusCode);
                    Assert.Equal("157184", updateImageLists.Body.Id.ToString());
                    //Assert.Equal(imageListIdToUpdate, updateImageLists.Body.Id.ToString());


                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6215")]
        public void GetDetailsImageList()
        {
            try
            {
                using (MockContext context = MockContext.Start("ImageListManagement"))
                {

                    GetImageLists();
                    // wait(2);
                    api = ContentModeratorAPI.GET_DETAILS_IMAGE_LIST;
                    //imageListIdToUpdate = ((int)allImageLists[1].Id).ToString();
                    HttpMockServer.Initialize("ImageListManagement", "GetDetailsImageList");
                    client = Constants.GenerateClient(api, HttpMockServer.CreateInstance());
                    //results = Constants.GetResponse(client, api, imageListIdToUpdate);
                    results = Constants.GetResponse(client, api, "157299");
                    var getdetailsImageList = results.GetDetailsImageList;
                    Assert.NotNull(getdetailsImageList);
                    Assert.Equal(HttpStatusCode.OK, getdetailsImageList.Response.StatusCode);
                    Assert.Equal("157299", getdetailsImageList.Body.Id.ToString());
                    //Assert.Equal(imageListIdToUpdate, getdetailsImageList.Body.Id.ToString());


                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6215")]
        public void RefreshIndexImageList()
        {
            try
            {
                using (MockContext context = MockContext.Start("ImageListManagement"))
                {

                    //GetImageLists();
                    //wait(2);
                    api = ContentModeratorAPI.REFRESH_INDEX_IMAGE_LIST;
                    //imageListIdToUpdate = ((int)allImageLists[1].Id).ToString();
                    HttpMockServer.Initialize("ImageListManagement", "RefreshIndexImageList");
                    client = Constants.GenerateClient(api, HttpMockServer.CreateInstance());
                    //results = Constants.GetResponse(client, api, imageListIdToUpdate);
                    results = Constants.GetResponse(client, api, "157299");
                    var refreshIndexImageList = results.RefreshIndexImageList;

                    Assert.NotNull(refreshIndexImageList);
                    Assert.Equal(HttpStatusCode.OK, refreshIndexImageList.Response.StatusCode);
                    Assert.True(Helpers.Utilities.VerifyRefreshIndex(refreshIndexImageList.Body));
                    Assert.Equal("RefreshIndex successfully completed.",refreshIndexImageList.Body.Status.Description);

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region ListManagementImages



        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6215")]
        public void GetAllImages()
        {
            try
            {
                using (MockContext context = MockContext.Start("ImageListManagement"))
                {

                    //GetImageLists();
                    // wait(2);
                    api = ContentModeratorAPI.GET_ALL_IMAGES;
                    //imageListId = ((int)allImageLists[0].Id).ToString();
                    HttpMockServer.Initialize("ImageListManagement", "GetAllImages");
                    client = Constants.GenerateClient(api, HttpMockServer.CreateInstance());
                    //results = Constants.GetResponse(client, api, imageListId);
                    results = Constants.GetResponse(client, api, "157299");
                    var getAllImagesFromListId = results.GetAllImages;
                    allImages = getAllImagesFromListId.Body;
                    Assert.NotNull(getAllImagesFromListId);
                    Assert.Equal(HttpStatusCode.OK,getAllImagesFromListId.Response.StatusCode);
                    Assert.Equal("157299", getAllImagesFromListId.Body.ContentSource);
                    //Assert.Equal(imageListId, getAllImagesFromListId.Body.ContentSource);

                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6215")]
        public void AddImage()
        {
            try
            {
                using (MockContext context = MockContext.Start("ImageListManagement"))
                {

                    //GetImageLists();
                    //wait(2);
                    //imageListId = ((int)allImageLists[1].Id).ToString();

                    Constants.AddImage = new BodyModel ("URL", "https://moderatorsampleimages.blob.core.windows.net/samples/sample.jpg");
                    api = ContentModeratorAPI.ADD_IMAGE;
                    HttpMockServer.Initialize("ImageListManagement", "AddImage");
                    client = Constants.GenerateClient(api,HttpMockServer.CreateInstance());
                    //results = Constants.GetResponse(client, api, imageListId);
                    results = Constants.GetResponse(client, api, "157299");
                    if (results.InnerException != null)
                    {
                        DeleteImage();
                        api = ContentModeratorAPI.ADD_IMAGE;
                        HttpMockServer.Initialize("ImageListManagement", "AddImage");
                        client = Constants.GenerateClient(api, HttpMockServer.CreateInstance());
                        results = Constants.GetResponse(client, api, null);
                    }
                    var addImgeToListId = results.AddImage;

                    Assert.NotNull(addImgeToListId);
                    Assert.Equal(HttpStatusCode.OK, addImgeToListId.Response.StatusCode);
                    Assert.True(Helpers.Utilities.VerifyAddImageResponse(addImgeToListId.Body), "Add Image Response verification failed." + TestBase.ErrorMessage);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6215")]
        public void DeleteImage()
        {
            try
            {
                using (MockContext context = MockContext.Start("ImageListManagement"))
                {
                    //GetAllImages();
                    //wait(2);
                    //if (allImages.ContentIds.Count == 0)
                    //{
                    //    AddImage();
                    //    GetAllImages();
                    //}

                    api = ContentModeratorAPI.DELETE_IMAGE;
                    HttpMockServer.Initialize("ImageListManagement", "DeleteImage");
                    client = Constants.GenerateClient(api, HttpMockServer.CreateInstance());
                    //string imageId = allImages.ContentIds[0].Value.ToString();

                    //results = Constants.GetResponse(client, api, imageListId, MIMETypes.JSON.GetDescription(), "eng", string.Empty, false, imageId);
                    results = Constants.GetResponse(client, api, "157299", MIMETypes.JSON.GetDescription(), "eng", string.Empty, false, "157332");
                    var deleteImageFromListId = results.DeleteImage;
                    Assert.NotNull(deleteImageFromListId);
                    Assert.Equal(HttpStatusCode.OK, deleteImageFromListId.Response.StatusCode);

                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6215")]
        public void DeleteAllImages()
        {
            try
            {
                using (MockContext context = MockContext.Start("ImageListManagement"))
                {
                     //GetImageLists();
                     //wait(2);
                     //imageListId = ((int)allImageLists[1].Id).ToString();

                    api = ContentModeratorAPI.DELETE_ALL_IMAGE;
                    HttpMockServer.Initialize("ImageListManagement", "DeleteAllImages");
                    client = Constants.GenerateClient(api, HttpMockServer.CreateInstance());
                    //results = Constants.GetResponse(client, api, imageListId);
                    results = Constants.GetResponse(client, api, "157299");

                    var deleteAllImageFromListId = results.DeleteImages;
                    Assert.NotNull(deleteAllImageFromListId);
                    Assert.Equal(HttpStatusCode.OK, deleteAllImageFromListId.Response.StatusCode);

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion




    }
}
