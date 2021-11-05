using System;
using Microsoft.Azure.CognitiveServices.ContentModerator;
using Microsoft.Azure.CognitiveServices.ContentModerator.Models;
using Newtonsoft.Json;
using System.Net;
using System.Linq;
using System.Collections.Generic;
using ContentModeratorTests.Helpers;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Test.HttpRecorder;

namespace ContentModeratorTests
{
        public class TextListManagement :TestBase
    {
        ContentModeratorClient client = null;
        Responses results = new Responses();
        static ContentModeratorAPI api;
        public static List<TermList> allTermLists;
        public static Terms allTerms;
        string TermListIdToUpdate;

        public TextListManagement()
        {
            TestSetUpConfiguration();
        }

        #region ListManagementTermLists



        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6215")]
        public void GetTermLists()
        {
            try
            {
                using (MockContext context = MockContext.Start("TextListManagement"))
                {
                    api = ContentModeratorAPI.GET_ALL_TERM_LIST;
                    HttpMockServer.Initialize("TextListManagement", "GetTermLists");
                    client = Constants.GenerateClient(api, HttpMockServer.CreateInstance());
                    results = Constants.GetResponse(client, api, string.Empty);
                    Assert.NotNull(results.GetAllTermLists);
                    Assert.Equal(HttpStatusCode.OK,results.GetAllTermLists.Response.StatusCode);

                    allTermLists = results.GetAllTermLists.Body.ToList();
                    if (allTermLists.Count > 0)
                    {
                        Assert.True(allTermLists.TrueForAll(x => !string.IsNullOrEmpty(((int)x.Id).ToString()) && !string.IsNullOrEmpty(x.Name) && x.Metadata != null), "Failed to get the result");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6215")]
        public void DeleteTermList()
        {
            try
            {
                using (MockContext context = MockContext.Start("TextListManagement"))
                {
                    //GetTermLists();
                    //wait(2);// should wait as the plan permits 1 trans/sec
                    api = ContentModeratorAPI.DELETE_TERM_LIST;
                    //TermListIdToDelete = ((int)allTermLists[0].Id).ToString();
                    HttpMockServer.Initialize("TextListManagement", "DeleteTermList");
                    client = Constants.GenerateClient(api, HttpMockServer.CreateInstance());
                    results = Constants.GetResponse(client, api, "66");
                    var deleteTermLists = results.DeleteTermLists;
                    Assert.NotNull(deleteTermLists);
                    Assert.Equal(HttpStatusCode.OK, deleteTermLists.Response.StatusCode);
                    Assert.Equal("", deleteTermLists.Body);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6215")]
        public void CreateTermLists()
        {
            try
            {
                using (MockContext context = MockContext.Start("TextListManagement"))
                {

                    //int counter = 0;
                    //GetTermLists();
                    //wait(2);


                    //counter = allTermLists.Count;
                    //if (counter == 5)
                    //{
                    //    DeleteTermList();
                    //    counter--;
                    //    wait(2);
                    //}
                    // Create TermLIsts
                    api = ContentModeratorAPI.CREATE_TERM_LIST;
                    //while (counter < 5)
                    {
                        HttpMockServer.Initialize("TextListManagement", "CreateTermLists");
                        client = Constants.GenerateClient(api, HttpMockServer.CreateInstance());
                        results = Constants.GetResponse(client, api, string.Empty);

                        var createTermList = results.CreateTermList;
                        Assert.NotNull(createTermList);
                        Assert.Equal(HttpStatusCode.OK, createTermList.Response.StatusCode);

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
        public void UpdateTermList()
        {
            try
            {
                using (MockContext context = MockContext.Start("TextListManagement"))
                {
                    //GetTermLists();
                    // wait(2);
                    api = ContentModeratorAPI.UPDATE_TERM_LIST;
                    //TermListIdToUpdate = ((int)allTermLists[1].Id).ToString();
                    HttpMockServer.Initialize("TextListManagement", "UpdateTermList");
                    client = Constants.GenerateClient(api, HttpMockServer.CreateInstance());
                    //results = Constants.GetResponse(client, api, TermListIdToUpdate);
                    results = Constants.GetResponse(client, api, "67");
                    var updateTermLists = results.UpdateTermList;
                    Assert.NotNull(updateTermLists);
                    Assert.Equal(HttpStatusCode.OK, updateTermLists.Response.StatusCode);
                    Assert.Equal("67", updateTermLists.Body.Id.ToString());
                    //Assert.Equal(TermListIdToUpdate, updateTermLists.Body.Id.ToString());

                }
            }
            catch (Exception)
            {
                throw;
            }
        }



        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6215")]
        public void GetDetailsTermList()
        {
            try
            {
                using (MockContext context = MockContext.Start("TextListManagement"))
                {

                    //GetTermLists();
                    // wait(2);
                    api = ContentModeratorAPI.GET_DETAILS_TERM_LIST;
                    //TermListIdToUpdate = ((int)allTermLists[1].Id).ToString();
                    HttpMockServer.Initialize("TextListManagement", "GetDetailsTermList");
                    client = Constants.GenerateClient(api, HttpMockServer.CreateInstance());
                    //results = Constants.GetResponse(client, api, TermListIdToUpdate);
                    results = Constants.GetResponse(client, api, "67");
                    var getdetailsTermList = results.GetDetailsTermList;
                    Assert.NotNull(getdetailsTermList);
                    Assert.Equal(HttpStatusCode.OK,getdetailsTermList.Response.StatusCode);
                    Assert.Equal("67", getdetailsTermList.Body.Id.ToString());
                    //Assert.Equal(TermListIdToUpdate, getdetailsTermList.Body.Id.ToString());


                }
            }
            catch (Exception)
            {
                throw;
            }
        }




        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6215")]
        public void RefreshIndexTermList()
        {
            try
            {
                using (MockContext context = MockContext.Start("TextListManagement"))
                {

                    //GetTermLists();
                    //wait(2);
                    api = ContentModeratorAPI.REFRESH_INDEX_TERM_LIST;
                    TermListIdToUpdate = ((int)allTermLists[1].Id).ToString();
                    HttpMockServer.Initialize("TextListManagement", "RefreshIndexTermList");
                    client = Constants.GenerateClient(api, HttpMockServer.CreateInstance());
                    //results = Constants.GetResponse(client, api, TermListIdToUpdate);
                    results = Constants.GetResponse(client, api, "67");
                    var refreshIndexTermList = results.RefreshIndexTermList;

                    Assert.NotNull(refreshIndexTermList);
                    Assert.Equal(HttpStatusCode.OK,refreshIndexTermList.Response.StatusCode);
                    Assert.True(Helpers.Utilities.VerifyRefreshIndex(refreshIndexTermList.Body));
                    Assert.Equal("RefreshIndex successfully completed.",refreshIndexTermList.Body.Status.Description);

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
        public void GetAllTerms()
        {
            try
            {
                using (MockContext context = MockContext.Start("TextListManagement"))
                {
                    //GetTermLists();
                    //wait(2);
                    api = ContentModeratorAPI.GET_ALL_TERMS;
                    //TermListId = ((int)allTermLists[1].Id).ToString();

                    HttpMockServer.Initialize("TextListManagement", "GetAllTerms");
                    client = Constants.GenerateClient(api, HttpMockServer.CreateInstance());
                    //results = Constants.GetResponse(client, api, TermListId);
                    results = Constants.GetResponse(client, api, "67");
                    var getAllTermsFromListId = results.GetAllTerms;


                    allTerms = getAllTermsFromListId.Body;
                    Assert.NotNull(getAllTermsFromListId);
                    Assert.NotNull(getAllTermsFromListId.Body.Data);
                    Assert.NotNull(getAllTermsFromListId.Body.Paging);
                    Assert.Equal(HttpStatusCode.OK,getAllTermsFromListId.Response.StatusCode);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6215")]
        public void AddTerm()
        {
            try
            {
                using (MockContext context = MockContext.Start("TextListManagement"))
                {
                    //GetTermLists();
                    //wait(2);
                    //if (allTermLists.Count == 1)
                    //{
                    //    CreateTermLists();
                    //}
                    //TermListId = ((int)allTermLists[1].Id).ToString();

                    api = ContentModeratorAPI.ADD_TERM;
                    HttpMockServer.Initialize("TextListManagement", "AddTerm");
                    client = Constants.GenerateClient(api, HttpMockServer.CreateInstance());
                    results = Constants.GetResponse(client, api, "67");

                    var addTermToListId = results.AddTerm;
                    Assert.NotNull(addTermToListId);
                    Assert.Equal(HttpStatusCode.Created,addTermToListId.Response.StatusCode);

                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6215")]
        public void DeleteTerm()
        {
            try
            {
                using (MockContext context = MockContext.Start("TextListManagement"))
                {

                    //GetAllTerms();
                    //wait(2);
                    //if (allTerms.Data.Terms.Count == 0)
                    //{
                    //    AddTerm();
                    //    GetAllTerms();
                    //}

                    api = ContentModeratorAPI.DELETE_TERM;

                    HttpMockServer.Initialize("TextListManagement", "DeleteTerm");
                    client = Constants.GenerateClient(api, HttpMockServer.CreateInstance());
                    //results = Constants.GetResponse(client, api, TermListId, MIMETypes.JSON.GetDescription(), "eng", "test");
                    results = Constants.GetResponse(client, api, "67", MIMETypes.JSON.GetDescription(), "eng", "test");


                    var deleteTermFromListId = results.DeleteTerm;
                    Assert.NotNull(deleteTermFromListId);
                    Assert.Equal(HttpStatusCode.NoContent, deleteTermFromListId.Response.StatusCode);

                }
            }
            catch (Exception)
            {
                throw;
            }
        }




        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6215")]
        public void DeleteAllTerms()
        {
            try
            {
                using (MockContext context = MockContext.Start("TextListManagement"))
                {
                    //GetTermLists();
                    //wait(2);
                    //TermListId = ((int)allTermLists[1].Id).ToString();

                    api = ContentModeratorAPI.DELETE_ALL_TERM;
                    HttpMockServer.Initialize("TextListManagement", "DeleteAllTerms");
                    client = Constants.GenerateClient(api, HttpMockServer.CreateInstance());
                    //results = Constants.GetResponse(client, api, TermListId);
                    results = Constants.GetResponse(client, api, "67");

                    var deleteAllTermFromListId = results.DeleteTerms;
                    Assert.NotNull(deleteAllTermFromListId);
                    Assert.Equal(HttpStatusCode.NoContent, deleteAllTermFromListId.Response.StatusCode);

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
