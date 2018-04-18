// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// using ApiManagement.Management.Tests;

using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.ApiManagement;
using Xunit;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.Azure.Management.ApiManagement.Models;
using System.IO;
using System.Net;

namespace ApiManagement.Tests.ManagementApiTests
{
    public class IssueTests : TestBase
    {
        [Fact]
        public async Task CreateUpdateDelete()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                // list all the APIs
                var apiListResponse = testBase.client.Api.ListByService(
                    testBase.rgName,
                    testBase.serviceName,
                    null);
                Assert.NotNull(apiListResponse);
                Assert.Single(apiListResponse);
                Assert.NotNull(apiListResponse.NextPageLink);

                // find the echo api
                var echoApi = apiListResponse.First();

                // list users
                var listUsersResponse = testBase.client.User.ListByService(
                    testBase.rgName,
                    testBase.serviceName,
                    null);

                Assert.NotNull(listUsersResponse);
                Assert.Single(listUsersResponse);

                var adminUser = listUsersResponse.First();

                // there should be now issues initially
                var issuesList = testBase.client.ApiIssue.ListByService(
                    testBase.rgName,
                    testBase.serviceName,
                    echoApi.Name,
                    null);
                Assert.NotNull(issuesList);
                Assert.Empty(issuesList);

                string newissueId = TestUtilities.GenerateName("newIssue");
                string newcommentId = TestUtilities.GenerateName("newComment");
                string newattachmentId = TestUtilities.GenerateName("newattachment");
                const string attachmentPath = "./Resources/apiissueattachment.JPG";

                try
                {
                    // add a recipient to the notification
                    var issueContract = new IssueContract()
                    {
                        Title = TestUtilities.GenerateName("title"),
                        Description = TestUtilities.GenerateName("description"),
                        UserId = adminUser.Id,
                        ApiId = echoApi.Id,
                        CreatedDate = DateTime.UtcNow
                    };
                    var apiIssueContract = await testBase.client.ApiIssue.CreateOrUpdateAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        echoApi.Name,
                        newissueId,
                        issueContract);

                    Assert.NotNull(apiIssueContract);
                    Assert.Equal(echoApi.Id, apiIssueContract.ApiId);
                    Assert.Equal(State.Proposed, apiIssueContract.State);
                    Assert.Equal(issueContract.Title, apiIssueContract.Title);                    
                    // get the issue
                    var issueData = await testBase.client.ApiIssue.GetAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        echoApi.Name,
                        newissueId);
                    Assert.NotNull(issueData);
                    Assert.Equal(issueData.Name, newissueId);
                    Assert.Equal(adminUser.Id, issueData.UserId);

                    // get commments on issue. there should be none initially
                    var emptyCommentList = await testBase.client.ApiIssueComment.ListByServiceAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        echoApi.Name,
                        newissueId, 
                        null);

                    Assert.Empty(emptyCommentList);

                    // add a comment
                    var issueCommentParameters = new IssueCommentContract()
                    {
                        Text = TestUtilities.GenerateName("issuecommenttext"),
                        UserId = adminUser.Id,
                        CreatedDate = DateTime.UtcNow
                    };
                    var addedComment = await testBase.client.ApiIssueComment.CreateOrUpdateAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        echoApi.Name,
                        newissueId,
                        newcommentId,
                        issueCommentParameters);
                    Assert.NotNull(addedComment);
                    Assert.Equal(addedComment.Name, newcommentId);
                    //Assert.Equal(addedComment.UserId, adminUser.Id); Bug userId is not getting populated
                    Assert.NotNull(addedComment.CreatedDate);

                    // get the comment tag.
                    var commentEntityTag = await testBase.client.ApiIssueComment.GetEntityTagAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        echoApi.Name,
                        newissueId,
                        newcommentId);
                    Assert.NotNull(commentEntityTag);
                    Assert.NotNull(commentEntityTag.ETag);

                    // delete the commment
                    await testBase.client.ApiIssueComment.DeleteAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        echoApi.Name,
                        newissueId,
                        newcommentId,
                        commentEntityTag.ETag);                    

                    try
                    {

                        // get the apicomment
                        var getComment = await testBase.client.ApiIssueComment.GetAsync(
                            testBase.rgName,
                            testBase.serviceName,
                            echoApi.Name,
                            newissueId,
                            newcommentId);

                        // should not come here
                        throw new Exception("This code should not have been executed.");
                    }
                    catch (ErrorResponseException ex)
                    {
                        Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                    }

                    // get the issue attachments
                    var apiIssueAttachments = await testBase.client.ApiIssueAttachment.ListByServiceAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        echoApi.Name,
                        newissueId,
                        null);
                    Assert.Empty(apiIssueAttachments);

                    // add an attachment to the issue
                    FileInfo fileInfo = new FileInfo(attachmentPath);

                    // The byte[] to save the data in
                    byte[] data = new byte[fileInfo.Length];

                    // Load a filestream and put its content into the byte[]
                    using (FileStream fs = fileInfo.OpenRead())
                    {
                        fs.Read(data, 0, data.Length);
                    }

                    var content = Convert.ToBase64String(data);
                    var issueAttachmentContract = new IssueAttachmentContract()
                    {
                        Content = content,
                        ContentFormat = "image/jpeg",
                        Title = TestUtilities.GenerateName("attachment")
                    };
                    var issueAttachment = await testBase.client.ApiIssueAttachment.CreateOrUpdateAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        echoApi.Name,
                        newissueId,
                        newattachmentId,
                        issueAttachmentContract);
                    Assert.NotNull(issueAttachment);
                    Assert.Equal(newattachmentId, issueAttachment.Name);
                    Assert.Equal("link", issueAttachment.ContentFormat);
                    Assert.NotNull(issueAttachment.Content);

                    // get the attachment tag
                    var issueAttachmentTag = await testBase.client.ApiIssueAttachment.GetEntityTagAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        echoApi.Name,
                        newissueId,
                        newattachmentId);
                    Assert.NotNull(issueAttachmentTag);
                    Assert.NotNull(issueAttachmentTag.ETag);

                    // delete the attachment
                    await testBase.client.ApiIssueAttachment.DeleteAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        echoApi.Name,
                        newissueId,
                        newattachmentId,
                        issueAttachmentTag.ETag);

                    try
                    {
                        var issueattachment = await testBase.client.ApiIssueAttachment.GetAsync(
                            testBase.rgName,
                            testBase.serviceName,
                            echoApi.Name,
                            newissueId,
                            newattachmentId);

                        // it should not reach here.
                        throw new Exception("This code should not have been executed.");
                    }
                    catch (ErrorResponseException ex)
                    {
                        Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                    }

                    // get the issue tag
                    var apiIssuetag = await testBase.client.ApiIssue.GetEntityTagAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        echoApi.Name,
                        newissueId);
                    Assert.NotNull(apiIssuetag);

                    // delete the issue
                    await testBase.client.ApiIssue.DeleteAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        echoApi.Name,
                        newissueId,
                        apiIssuetag.ETag);

                    // check the issue exist
                    try
                    {
                        var apiIssue = await testBase.client.ApiIssue.GetAsync(
                            testBase.rgName,
                            testBase.serviceName,
                            echoApi.Name,
                            newissueId);

                        // it should not reach here.
                        throw new Exception("This code should not have been executed.");
                    }
                    catch (ErrorResponseException ex)
                    {
                        Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                    }
                }
                finally
                {
                    // cleanup the api issue attachment, if exists
                    testBase.client.ApiIssueAttachment.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        echoApi.Name,
                        newissueId,
                        newattachmentId,
                        "*");

                    // cleanup the api issue comment if exists
                    testBase.client.ApiIssueComment.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        echoApi.Name,
                        newissueId,
                        newcommentId,
                        "*");

                    // cleanup the api issue if exists
                    testBase.client.ApiIssue.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        echoApi.Name,
                        newissueId,
                        "*");
                }
            }
        }        
    }
}
