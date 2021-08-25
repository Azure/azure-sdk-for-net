using System;
using Microsoft.Azure.CognitiveServices.ContentModerator;
using Microsoft.Azure.CognitiveServices.ContentModerator.Models;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using ContentModeratorTests.Helpers;
using System.IO;
using d = System.Drawing;
using ContentModeratorTests.Data;
using System.Reflection;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Test.HttpRecorder;

namespace ContentModeratorTests
{
        public class ImageModerator : TestBase
    {

        ContentModeratorClient client = null;
        Helpers.Utilities u = new Helpers.Utilities();
        Responses results = new Responses();
        static ContentModeratorAPI api;
        public static List<ImageList> allImageLists;
        public static ImageIds allImages;


        BodyModel ImageUrlToModerate = new BodyModel ("URL", "https://pbs.twimg.com/media/BfopodJCUAAjmkU.jpg:large");
        BodyModel ImageUrlToModerate1 = new BodyModel ("URL", "https://hashblobsm2.blob.core.windows.net/testimages/BMPOCR_lessthan_128px.bmp");
        ImageListManagement ilm = new ImageListManagement();



        public ImageModerator()
        {
            TestSetUpConfiguration();

        }

        internal void TestCleanup()
        {
            TestCleanupConfiguration();
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6215")]
        public void GetImageLists()
        {
            try
            {
                using (MockContext context = MockContext.Start("ImageModerator"))
                {
                    HttpMockServer.Initialize("ImageModerator", "GetImageLists");
                    api = ContentModeratorAPI.GET_ALL_IMAGE_LIST;
                    client = Constants.GenerateClient(api, HttpMockServer.CreateInstance());
                    results = Constants.GetResponse(client, api, string.Empty);
                    Assert.NotNull(results.GetAllImageLists);
                    Assert.Equal(HttpStatusCode.OK, results.GetAllImageLists.Response.StatusCode);
                    allImageLists = results.GetAllImageLists.Body.ToList();
                    Assert.True(allImageLists.Count > 0, "Failed to get the result");
                    Assert.True(allImageLists.TrueForAll(x => !string.IsNullOrEmpty(((int)x.Id).ToString()) && !string.IsNullOrEmpty(x.Name) && x.Metadata != null), "Failed to get the result");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region BVTURL



        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6215")]
        public void Evaluate()
        {
            try
            {
                using (MockContext context = MockContext.Start("ImageModerator"))
                {
                    HttpMockServer.Initialize("ImageModerator", "Evaluate");
                    //GetImageLists();

                    //imageListId = ((int)allImageLists[1].Id).ToString();

                    api = ContentModeratorAPI.EVALUATE;
                    client = Constants.GenerateClient(api, HttpMockServer.CreateInstance());
                    results = Constants.GetImageResponse(client, api, "", ImageUrlToModerate);

                    var evaluate = results.Evaluate;
                    Assert.NotNull(evaluate);
                    Assert.Equal(HttpStatusCode.OK,evaluate.Response.StatusCode);

                }
            }
            catch (Exception)
            {
                throw;
            }
        }




        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6215")]
        public void FindFaces()
        {
            try
            {
                using (MockContext context = MockContext.Start("ImageModerator"))
                {
                    HttpMockServer.Initialize("ImageModerator", "FindFaces");
                    //GetImageLists();

                    //imageListId = ((int)allImageLists[1].Id).ToString();

                    api = ContentModeratorAPI.FIND_FACES;
                    client = Constants.GenerateClient(api, HttpMockServer.CreateInstance());
                    results = Constants.GetImageResponse(client, api, "", ImageUrlToModerate);

                    var findfaces = results.FoundFaces;
                    Assert.NotNull(findfaces);
                    Assert.Equal(HttpStatusCode.OK, findfaces.Response.StatusCode);
                    Assert.True(Helpers.Utilities.VerifyFoundFaces(findfaces.Body), TestBase.ErrorMessage);

                }
            }
            catch (Exception)
            {
                throw;
            }
        }



        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6215")]
        public void Match()
        {
            try
            {
                using (MockContext context = MockContext.Start("ImageModerator"))
                {
                    HttpMockServer.Initialize("ImageModerator", "Match");

                    api = ContentModeratorAPI.MATCH;
                    client = Constants.GenerateClient(api, HttpMockServer.CreateInstance());
                    results = Constants.GetImageResponse(client, api, "", ImageUrlToModerate);
                    if (results != null)
                    {
                        var match = results.MatchImage;
                        Assert.NotNull(match);
                        Assert.Equal(HttpStatusCode.OK, match.Response.StatusCode);
                        Assert.True(Helpers.Utilities.VerifyMatchResponse(match.Body), TestBase.ErrorMessage);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
        }



        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6215")]
        public void OCR()
        {
            try
            {
                using (MockContext context = MockContext.Start("ImageModerator"))
                {
                    HttpMockServer.Initialize("ImageModerator", "OCR");
                    //GetImageLists();
                    //imageListId = ((int)allImageLists[1].Id).ToString();

                    api = ContentModeratorAPI.OCR;
                    client = Constants.GenerateClient(api, HttpMockServer.CreateInstance());
                    results = Constants.GetImageResponse(client, api, "", ImageUrlToModerate);

                    var ocr = results.OCR;
                    Assert.NotNull(ocr);
                    Assert.Equal(HttpStatusCode.OK, ocr.Response.StatusCode);
                    Assert.True(Helpers.Utilities.VerifyOCR(ocr.Body), TestBase.ErrorMessage);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion



        #region INLINE



        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6215")]
        public void EvaluateRaw()
        {
            try
            {
                using (MockContext context = MockContext.Start("ImageModerator"))
                {
                    HttpMockServer.Initialize("ImageModerator", "EvaluateRaw");

                    wait(2);

                    Stream imgStream = new FileStream(rawImageCurrentPath, FileMode.Open, FileAccess.Read);
                    api = ContentModeratorAPI.EVALUATE;
                    client = Constants.GenerateClient(api, HttpMockServer.CreateInstance());

                    results = Constants.GetImageResponseRaw(client, api, "", imgStream, MIMETypes.IMAGE_JPEG.GetDescription());
                    if (results.InnerException == null)
                    {
                        var evaluate = results.Evaluate;
                        Assert.NotNull(evaluate);
                        Assert.Equal(HttpStatusCode.OK, evaluate.Response.StatusCode);
                        Assert.True(Helpers.Utilities.VerifyEvaluate(evaluate.Body), TestBase.ErrorMessage);
                    }
                    else
                    {
                        var ex = results.InnerException;
                        Assert.NotNull(ex);
                        Assert.Equal(HttpStatusCode.BadRequest, ex.Response.StatusCode);

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6215")]
        public void FindFacesRaw()
        {
            try
            {
                using (MockContext context = MockContext.Start("ImageModerator"))
                {
                    HttpMockServer.Initialize("ImageModerator", "FindFacesRaw");

                    //wait(2);


                    Stream imgStream = new FileStream(rawImageCurrentPath, FileMode.Open, FileAccess.Read);
                    api = ContentModeratorAPI.FIND_FACES;
                    client = Constants.GenerateClient(api, HttpMockServer.CreateInstance());

                    results = Constants.GetImageResponseRaw(client, api, "", imgStream, MIMETypes.IMAGE_JPEG.GetDescription());
                    if (results.InnerException == null)
                    {
                        var findfaces = results.FoundFaces;
                        Assert.NotNull(findfaces);
                        Assert.Equal(HttpStatusCode.OK, findfaces.Response.StatusCode);
                        Assert.True(Helpers.Utilities.VerifyFoundFaces(findfaces.Body), TestBase.ErrorMessage);
                    }
                    else
                    {
                        var ex = results.InnerException;
                        Assert.NotNull(ex);
                        Assert.Equal(HttpStatusCode.BadRequest, ex.Response.StatusCode);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6215")]
        public void MatchRaw()
        {
            try
            {
                using (MockContext context = MockContext.Start("ImageModerator"))
                {
                    HttpMockServer.Initialize("ImageModerator", "MatchRaw");
                    //wait(2);
                    Stream imgStream = new FileStream(rawImageCurrentPath, FileMode.Open, FileAccess.Read);
                    api = ContentModeratorAPI.MATCH;
                    client = Constants.GenerateClient(api, HttpMockServer.CreateInstance());

                    results = Constants.GetImageResponseRaw(client, api, "", imgStream, MIMETypes.IMAGE_JPEG.GetDescription());
                    if (results.InnerException == null)
                    {
                        var match = results.MatchImage;
                        Assert.NotNull(match);
                        Assert.Equal(HttpStatusCode.OK, match.Response.StatusCode);
                        Assert.True(Helpers.Utilities.VerifyMatchResponse(match.Body), TestBase.ErrorMessage);
                    }
                    else
                    {
                        var ex = results.InnerException;
                        Assert.NotNull(ex);
                        Assert.Equal(HttpStatusCode.BadRequest, ex.Response.StatusCode);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }



        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6215")]
        public void OCRRaw()
        {
            try
            {
                using (MockContext context = MockContext.Start("ImageModerator"))
                {
                    HttpMockServer.Initialize("ImageModerator", "OCRRaw");
                    //wait(2);
                    Stream imgStream = new FileStream(rawImageCurrentPath, FileMode.Open, FileAccess.Read);
                    api = ContentModeratorAPI.OCR;
                    client = Constants.GenerateClient(api,HttpMockServer.CreateInstance());

                    results = Constants.GetImageResponseRaw(client, api, "", imgStream, MIMETypes.IMAGE_JPEG.GetDescription());
                    if (results.InnerException == null)
                    {
                        var ocr = results.OCR;
                        Assert.NotNull(ocr);
                        Assert.Equal(HttpStatusCode.OK, ocr.Response.StatusCode);
                        Assert.True(Helpers.Utilities.VerifyOCR(ocr.Body), TestBase.ErrorMessage);
                    }
                    else
                    {
                        var ex = results.InnerException;
                        Assert.NotNull(ex);
                        Assert.Equal(HttpStatusCode.BadRequest, ex.Response.StatusCode);
                    }
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
