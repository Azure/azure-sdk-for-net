// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Xunit;

    public class WorkflowRunActionsInMemoryTests : BaseInMemoryTests
    {
        #region Constructor

        private StringContent RunAction { get; set; }

        private StringContent RunActionListResponse { get; set; }

        public WorkflowRunActionsInMemoryTests()
        {
            var runAction = @"{
    'id':'/subscriptions/66666666-6666-6666-6666-666666666666/resourceGroups/rgName/providers/Microsoft.Logic/workflows/wfName/runs/08587692861242198730/actions/actName',
    'name':'actName',
    'type':'Microsoft.Logic/workflows/runs/actions',
    'properties':{
        'startTime': '2015-06-23T21:47:00.0000001Z',
        'endTime':'2015-06-23T21:47:30.0000002Z',
        'status':'Succeeded',
        'code':'OK',
        'trackingId':'2c9e4726-a395-4841-bf54-5e826ec04c30',
        'inputsLink':{
            'uri':'https://input.blob.core.windows.net/',
            'contentVersion':'""0x8D262D79EB296A8""',
            'contentSize':453,
            'contentHash':{
                'algorithm':'md5',
                'value':'ivHEPG5bzwNB9IFYRqsqOw=='
            }
        },
        'outputsLink':{
            'uri':'https://output.blob.core.windows.net/',
            'contentVersion':'""0x8D262D79EB296A8""',
            'contentSize':713,
            'contentHash':{
                'algorithm':'md5',
                'value':'BWhA5Z1Rxaz0MwuDeQBykw=='
            }
        }
    }
}";

            var runActionListResponseFormat = @"{{ 'value': [ {0} ], 'nextLink': 'http://management.azure.com/actionNextLink' }}";

            this.RunAction = new StringContent(runAction);
            this.RunActionListResponse = new StringContent(string.Format(runActionListResponseFormat, runAction));
        }

        #endregion

        #region WorkflowRunActions_List

        [Fact]
        public void WorkflowRunActions_List_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = this.Empty
            };

            Assert.Throws<ValidationException>(() => client.WorkflowRunActions.List(null, "wfName", "rName"));
            Assert.Throws<ValidationException>(() => client.WorkflowRunActions.List("rgName", null, "rName"));
            Assert.Throws<ValidationException>(() => client.WorkflowRunActions.List("rgName", "wfName", null));
            Assert.Throws<CloudException>(() => client.WorkflowRunActions.List("rgName", "wfName", "rName"));
        }

        [Fact]
        public void WorkflowRunActions_List_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.RunActionListResponse
            };

            var response = client.WorkflowRunActions.List("rgName", "wfName", "rName");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            // Validates result.
            this.ValidateRunActionListResponse1(response);
        }

        #endregion

        #region WorkflowRunActions_ListNext

        [Fact]
        public void WorkflowRunActions_ListNext_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = this.Empty
            };

            Assert.Throws<ValidationException>(() => client.WorkflowRunActions.ListNext(null));
            Assert.Throws<CloudException>(() => client.WorkflowRunActions.ListNext("http://management.azure.com/actionLink"));
        }

        [Fact]
        public void WorkflowRunActions_ListNext_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.RunActionListResponse
            };

            var response = client.WorkflowRunActions.ListNext("http://management.azure.com/actionLink");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            // Validates result.
            this.ValidateRunActionListResponse1(response);
        }

        #endregion

        #region WorkflowRunActions_Get

        [Fact]
        public void WorkflowRunActions_Get_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = this.Empty
            };

            Assert.Throws<ValidationException>(() => client.WorkflowRunActions.Get(null, "wfName", "rName", "actName"));
            Assert.Throws<ValidationException>(() => client.WorkflowRunActions.Get("rgName", null, "rName", "actName"));
            Assert.Throws<ValidationException>(() => client.WorkflowRunActions.Get("rgName", "wfName", null, "actName"));
            Assert.Throws<ValidationException>(() => client.WorkflowRunActions.Get("rgName", "wfName", "rName", null));
            Assert.Throws<CloudException>(() => client.WorkflowRunActions.Get("rgName", "wfName", "rName", "actName"));
        }

        [Fact]
        public void WorkflowRunActions_Get_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.RunAction
            };

            var action = client.WorkflowRunActions.Get("rgName", "wfName", "rName", "actName");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            // Validates result.
            this.ValidateRunAction1(action);
        }

        #endregion

        #region Validation

        private void ValidateRunAction1(WorkflowRunAction action)
        {
            Assert.Equal("/subscriptions/66666666-6666-6666-6666-666666666666/resourceGroups/rgName/providers/Microsoft.Logic/workflows/wfName/runs/08587692861242198730/actions/actName", action.Id);
            Assert.Equal("actName", action.Name);
            Assert.Equal("Microsoft.Logic/workflows/runs/actions", action.Type);

            Assert.Equal(2015, action.StartTime.Value.Year);
            Assert.Equal(06, action.StartTime.Value.Month);
            Assert.Equal(23, action.StartTime.Value.Day);
            Assert.Equal(21, action.StartTime.Value.Hour);
            Assert.Equal(47, action.StartTime.Value.Minute);
            Assert.Equal(00, action.StartTime.Value.Second);
            Assert.Equal(DateTimeKind.Utc, action.StartTime.Value.Kind);

            Assert.Equal(2015, action.EndTime.Value.Year);
            Assert.Equal(06, action.EndTime.Value.Month);
            Assert.Equal(23, action.EndTime.Value.Day);
            Assert.Equal(21, action.EndTime.Value.Hour);
            Assert.Equal(47, action.EndTime.Value.Minute);
            Assert.Equal(30, action.EndTime.Value.Second);
            Assert.Equal(DateTimeKind.Utc, action.EndTime.Value.Kind);

            Assert.Equal(WorkflowStatus.Succeeded, action.Status);
            Assert.Equal("OK", action.Code);
            Assert.Equal("2c9e4726-a395-4841-bf54-5e826ec04c30", action.TrackingId);

            Assert.Equal("https://input.blob.core.windows.net/", action.InputsLink.Uri);
            Assert.Equal("\"0x8D262D79EB296A8\"", action.InputsLink.ContentVersion);
            Assert.Equal(453, action.InputsLink.ContentSize);
            Assert.Equal("md5", action.InputsLink.ContentHash.Algorithm);
            Assert.Equal("ivHEPG5bzwNB9IFYRqsqOw==", action.InputsLink.ContentHash.Value);

            Assert.Equal("https://output.blob.core.windows.net/", action.OutputsLink.Uri);
            Assert.Equal("\"0x8D262D79EB296A8\"", action.OutputsLink.ContentVersion);
            Assert.Equal(713, action.OutputsLink.ContentSize);
            Assert.Equal("md5", action.OutputsLink.ContentHash.Algorithm);
            Assert.Equal("BWhA5Z1Rxaz0MwuDeQBykw==", action.OutputsLink.ContentHash.Value);
        }

        private void ValidateRunActionListResponse1(IPage<WorkflowRunAction> page)
        {
            Assert.Equal(1, page.Count());
            Assert.Equal("http://management.azure.com/actionNextLink", page.NextPageLink);
            this.ValidateRunAction1(page.First());
        }

        #endregion
    }
}
