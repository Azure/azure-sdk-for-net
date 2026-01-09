// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ApiManagement.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ApiManagement.Tests
{
    public class IssueTests : ApiManagementManagementTestBase
    {
        public IssueTests(bool isAsync)
                    : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        private ResourceGroupResource ResourceGroup { get; set; }

        private ApiManagementServiceResource ApiServiceResource { get; set; }

        private ApiManagementServiceCollection ApiServiceCollection { get; set; }

        private async Task SetCollectionsAsync()
        {
            ResourceGroup = await CreateResourceGroupAsync(AzureLocation.EastUS);
            ApiServiceCollection = ResourceGroup.GetApiManagementServices();
        }

        private async Task CreateApiServiceAsync()
        {
            await SetCollectionsAsync();
            var apiName = Recording.GenerateAssetName("testapi-");
            var data = new ApiManagementServiceData(AzureLocation.EastUS, new ApiManagementServiceSkuProperties(ApiManagementServiceSkuType.Developer, 1), "Sample@Sample.com", "sample")
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };
            ApiServiceResource = (await ApiServiceCollection.CreateOrUpdateAsync(WaitUntil.Completed, apiName, data)).Value;
        }

        [Test]
        public async Task CRUD()
        {
            await CreateApiServiceAsync();
            var apiCollection = ApiServiceResource.GetApis();
            var userCollection = ApiServiceResource.GetApiManagementUsers();

            // list all the APIs
            var apiListResponse = await apiCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(apiListResponse.Count, Is.EqualTo(1));

            // find the echo api
            var echoApi = apiListResponse.FirstOrDefault();
            var issueCollection = echoApi.GetApiIssues();

            // list users
            var listUsersResponse = await userCollection.GetAllAsync().ToEnumerableAsync();

            Assert.That(listUsersResponse.Count, Is.EqualTo(1));

            var adminUser = listUsersResponse.FirstOrDefault();

            // there should be now issues initially
            var issuesList = await issueCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(issuesList, Is.Empty);

            string newissueId = Recording.GenerateAssetName("newIssue");
            string newcommentId = Recording.GenerateAssetName("newComment");
            string newattachmentId = Recording.GenerateAssetName("newattachment");
            const string attachmentPath = "./Resources/apiissueattachment.JPG";

            // add a recipient to the notification
            var issueContract = new IssueContractData()
            {
                Title = Recording.GenerateAssetName("title"),
                Description = Recording.GenerateAssetName("description"),
                UserId = adminUser.Id,
                ApiId = echoApi.Id,
                CreatedOn = DateTime.Parse("2018-02-01T22:21:20.467Z")
            };
            var apiIssueContract = (await issueCollection.CreateOrUpdateAsync(WaitUntil.Completed, newissueId, issueContract)).Value;

            Assert.That(apiIssueContract, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(apiIssueContract.Data.ApiId, Is.EqualTo(echoApi.Id));
                Assert.That(apiIssueContract.Data.State, Is.EqualTo(IssueState.Proposed));
                Assert.That(apiIssueContract.Data.Title, Is.EqualTo(issueContract.Title));
            });
            // get the issue
            var issueData = (await issueCollection.GetAsync(newissueId)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(issueData, Is.Not.Null);
                Assert.That(newissueId, Is.EqualTo(issueData.Data.Name));
            });
            Assert.That(issueData.Data.UserId, Is.EqualTo(adminUser.Id));

            // update the issue
            var updateTitle = Recording.GenerateAssetName("updatedTitle");
            var updateDescription = Recording.GenerateAssetName("updateddescription");

            var issueUpdateContract = new ApiIssuePatch()
            {
                Description = updateDescription,
                Title = updateTitle
            };

            await issueData.UpdateAsync(ETag.All, issueUpdateContract);

            // get the issue
            issueData = await issueData.GetAsync();
            Assert.Multiple(() =>
            {
                Assert.That(issueData, Is.Not.Null);
                Assert.That(newissueId, Is.EqualTo(issueData.Data.Name));
            });
            Assert.That(issueData.Data.UserId, Is.EqualTo(adminUser.Id));
            Assert.That(issueData.Data.Title, Is.EqualTo(updateTitle));
            Assert.That(issueData.Data.Description, Is.EqualTo(updateDescription));

            // get commments on issue. there should be none initially
            var commentCollection = issueData.GetApiIssueComments();
            var emptyCommentList = await commentCollection.GetAllAsync().ToEnumerableAsync();

            Assert.That(emptyCommentList, Is.Empty);

            // add a comment
            var issueCommentParameters = new ApiIssueCommentData()
            {
                Text = Recording.GenerateAssetName("issuecommenttext"),
                UserId = adminUser.Id,
                CreatedOn = DateTime.Parse("2018-02-01T22:21:20.467Z")
            };
            var addedComment = (await commentCollection.CreateOrUpdateAsync(WaitUntil.Completed, newcommentId, issueCommentParameters)).Value;
            Assert.Multiple(() =>
            {
                Assert.That(addedComment, Is.Not.Null);
                Assert.That(newcommentId, Is.EqualTo(addedComment.Data.Name));
            });
            // https://msazure.visualstudio.com/DefaultCollection/One/_workitems/edit/4402087
            //Assert.Equal(addedComment.UserId, adminUser.Id); //Bug userId is not getting populated
            Assert.That(addedComment.Data.CreatedOn, Is.Not.Null);

            // delete the commment
            await addedComment.DeleteAsync(WaitUntil.Completed, ETag.All);
            var resultFalse = (await commentCollection.ExistsAsync(newcommentId)).Value;
            Assert.That(resultFalse, Is.False);

            // get the issue attachments
            var attachmentsCollection = issueData.GetApiIssueAttachments();
            var apiIssueAttachments = await attachmentsCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(apiIssueAttachments, Is.Empty);

            // add an attachment to the issue
            FileInfo fileInfo = new FileInfo(attachmentPath);

            // The byte[] to save the data in
            byte[] data = new byte[fileInfo.Length];

            // Load a filestream and put its content into the byte[]
            using (FileStream fs = fileInfo.OpenRead())
            {
#if NET6_0_OR_GREATER
                fs.ReadExactly(data, 0, data.Length);
#else
                fs.Read(data, 0, data.Length);
#endif
            }

            var content = Convert.ToBase64String(data);
            var issueAttachmentContract = new ApiIssueAttachmentData()
            {
                Content = content,
                ContentFormat = "image/jpeg",
                Title = Recording.GenerateAssetName("attachment")
            };
            var issueAttachment = (await attachmentsCollection.CreateOrUpdateAsync(WaitUntil.Completed, newattachmentId, issueAttachmentContract)).Value;
            Assert.That(issueAttachment, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(issueAttachment.Data.Name, Is.EqualTo(newattachmentId));
                Assert.That(issueAttachment.Data.ContentFormat, Is.EqualTo("link"));
                Assert.That(issueAttachment.Data.Content, Is.Not.Null);
            });

            // delete the attachment
            await issueAttachment.DeleteAsync(WaitUntil.Completed, ETag.All);
            resultFalse = (await attachmentsCollection.ExistsAsync(newattachmentId)).Value;
            Assert.That(resultFalse, Is.False);

            // delete the issue
            await issueData.DeleteAsync(WaitUntil.Completed, ETag.All);
            resultFalse = (await issueCollection.ExistsAsync(newissueId)).Value;
            Assert.That(resultFalse, Is.False);
        }
    }
}
