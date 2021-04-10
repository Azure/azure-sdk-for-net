using System;
using System.Data;
using Microsoft.Azure.CognitiveServices.ContentModerator.Models;
using Microsoft.Azure.CognitiveServices.ContentModerator;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using Microsoft.Rest;
using ContentModeratorTests.Helpers;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Test.HttpRecorder;
using System.IO;
using System.Text;

namespace ContentModeratorTests
{
        public class TextModerator :TestBase
    {
        ContentModeratorClient client = null;
        Responses results = new Responses();
        static ContentModeratorAPI api;
        public static List<TermList> allTermLists;
        public static Terms allTerms;
        string TermListId;
        public TextModerator()
        {
            TestSetUpConfiguration();
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6215")]
        public void GetTermLists()
        {
            try
            {
                using (MockContext context = MockContext.Start("TextModerator"))
                {
                    HttpMockServer.Initialize("TextModerator", "GetTermLists");
                    api = ContentModeratorAPI.GET_ALL_TERM_LIST;
                    client = Constants.GenerateClient(api, HttpMockServer.CreateInstance());
                    results = Constants.GetResponse(client, api, string.Empty);
                    Assert.NotNull(results.GetAllTermLists);
                    Assert.Equal(HttpStatusCode.OK, results.GetAllTermLists.Response.StatusCode);
                    allTermLists = results.GetAllTermLists.Body.ToList();
                    Assert.True(allTermLists.Count > 0, "Failed to get the result");
                    Assert.True(allTermLists.TrueForAll(x => !string.IsNullOrEmpty(((int)x.Id).ToString()) && !string.IsNullOrEmpty(x.Name) && x.Metadata != null), "Failed to get the result");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region BVT


        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6215")]
        public void DetectLanguage()
        {
            try
            {
                using (MockContext context = MockContext.Start("TextModerator"))
                {
                    HttpMockServer.Initialize("TextModerator", "DetectLanguage");
                    wait(2);
                    TermListId = "";
                    byte[] byteArray = Encoding.UTF8.GetBytes("Ciao buongiorno stronzo");
                    MemoryStream stream = new MemoryStream(byteArray);
                    api = ContentModeratorAPI.DETECT_LANGUAGE;
                    client = Constants.GenerateClient(api, HttpMockServer.CreateInstance());
                    results = Constants.GetTextResponse(client, api, TermListId, stream);

                    var detectLanguage = results.DetectLanguage;
                    Assert.NotNull(detectLanguage);
                    Assert.Equal(HttpStatusCode.OK, detectLanguage.Response.StatusCode);
                    Assert.True(Helpers.Utilities.VerifyDetectLanguage(detectLanguage.Body), TestBase.ErrorMessage);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }



        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6215")]
        public void ScreenText()
        {
            try
            {
                using (MockContext context = MockContext.Start("TextModerator"))
                {
                    HttpMockServer.Initialize("TextModerator", "ScreenText");
                    byte[] byteArray = Encoding.UTF8.GetBytes("crap 764-87-9887");
                    MemoryStream stream = new MemoryStream(byteArray);
                    api = ContentModeratorAPI.SCREEN_TEXT;
                    client = Constants.GenerateClient(api, HttpMockServer.CreateInstance());
                    results = Constants.GetTextResponse(client, api, "", stream);
                    var screenText = results.ScreenText;
                    Assert.NotNull(screenText);
                    Assert.Equal(HttpStatusCode.OK, screenText.Response.StatusCode);
                    Assert.True(Helpers.Utilities.VerifyScreenText(screenText.Body), TestBase.ErrorMessage);
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
