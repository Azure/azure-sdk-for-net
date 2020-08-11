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

    public class WorkflowRunActionsInMemoryTests : InMemoryTestsBase
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
        },
        'retryHistory':[
            {
                'startTime': '2017-03-28T01:17:07.7366759Z',
                'endTime': '2017-03-28T01:17:22.7694973Z',
                'code': 'BadRequest',
                'clientRequestId': '2fabdcf3-4c32-4bbd-af19-e0642c38c645',
                'serviceRequestId': '22222222-4c32-4bbd-aaaa-e0642c38c645',
                'error': {
                    'error': {
                        'code': 'BadRequest',
                        'message': 'Http request failed: the timeout was reached.'
                     }
                 }
             },
             {
                'startTime': '2017-03-28T01:17:38.8875713Z',
                'endTime': '2017-03-28T01:17:39.9061247Z',
                'code': 'ServiceUnavailable',
                'clientRequestId': '015cece2-1149-4eba-8970-06b9286a1a30'
             }
         ]
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
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(() => client.WorkflowRunActions.List(null, "wfName", "rName"));
            Assert.Throws<ValidationException>(() => client.WorkflowRunActions.List("rgName", null, "rName"));
            Assert.Throws<ValidationException>(() => client.WorkflowRunActions.List("rgName", "wfName", null));
            Assert.Throws<ErrorResponseException>(() => client.WorkflowRunActions.List("rgName", "wfName", "rName"));
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
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(() => client.WorkflowRunActions.ListNext(null));
            Assert.Throws<ErrorResponseException>(() => client.WorkflowRunActions.ListNext("http://management.azure.com/actionLink"));
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
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(() => client.WorkflowRunActions.Get(null, "wfName", "rName", "actName"));
            Assert.Throws<ValidationException>(() => client.WorkflowRunActions.Get("rgName", null, "rName", "actName"));
            Assert.Throws<ValidationException>(() => client.WorkflowRunActions.Get("rgName", "wfName", null, "actName"));
            Assert.Throws<ValidationException>(() => client.WorkflowRunActions.Get("rgName", "wfName", "rName", null));
            Assert.Throws<ErrorResponseException>(() => client.WorkflowRunActions.Get("rgName", "wfName", "rName", "actName"));
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
            Assert.True(this.ValidateIdFormat(id: action.Id, entityTypeName: "workflows", entitySubtypeName: "runs", entityMicrotypeName: "actions"));
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

            Assert.NotNull(action.RetryHistory);
            var retryHistory0 = action.RetryHistory[0];
            var retryHistory1 = action.RetryHistory[1];

            Assert.Equal(2017, retryHistory0.StartTime.Value.Year);
            Assert.Equal(03, retryHistory0.StartTime.Value.Month);
            Assert.Equal(28, retryHistory0.StartTime.Value.Day);
            Assert.Equal(01, retryHistory0.StartTime.Value.Hour);
            Assert.Equal(17, retryHistory0.StartTime.Value.Minute);
            Assert.Equal(07, retryHistory0.StartTime.Value.Second);
            Assert.Equal(DateTimeKind.Utc, retryHistory0.StartTime.Value.Kind);

            Assert.Equal(2017, retryHistory0.EndTime.Value.Year);
            Assert.Equal(03, retryHistory0.EndTime.Value.Month);
            Assert.Equal(28, retryHistory0.EndTime.Value.Day);
            Assert.Equal(01, retryHistory0.EndTime.Value.Hour);
            Assert.Equal(17, retryHistory0.EndTime.Value.Minute);
            Assert.Equal(22, retryHistory0.EndTime.Value.Second);
            Assert.Equal(DateTimeKind.Utc, retryHistory0.EndTime.Value.Kind);

            Assert.Equal("BadRequest", retryHistory0.Code);
            Assert.Equal("2fabdcf3-4c32-4bbd-af19-e0642c38c645", retryHistory0.ClientRequestId);
            Assert.Equal("22222222-4c32-4bbd-aaaa-e0642c38c645", retryHistory0.ServiceRequestId);
            Assert.Equal("BadRequest", retryHistory0.Error.Error.Code);
            Assert.Equal("Http request failed: the timeout was reached.", retryHistory0.Error.Error.Message);

            Assert.Equal(2017, retryHistory1.StartTime.Value.Year);
            Assert.Equal(03, retryHistory1.StartTime.Value.Month);
            Assert.Equal(28, retryHistory1.StartTime.Value.Day);
            Assert.Equal(01, retryHistory1.StartTime.Value.Hour);
            Assert.Equal(17, retryHistory1.StartTime.Value.Minute);
            Assert.Equal(38, retryHistory1.StartTime.Value.Second);
            Assert.Equal(DateTimeKind.Utc, retryHistory1.StartTime.Value.Kind);

            Assert.Equal(2017, retryHistory1.EndTime.Value.Year);
            Assert.Equal(03, retryHistory1.EndTime.Value.Month);
            Assert.Equal(28, retryHistory1.EndTime.Value.Day);
            Assert.Equal(01, retryHistory1.EndTime.Value.Hour);
            Assert.Equal(17, retryHistory1.EndTime.Value.Minute);
            Assert.Equal(39, retryHistory1.EndTime.Value.Second);
            Assert.Equal(DateTimeKind.Utc, retryHistory1.EndTime.Value.Kind);

            Assert.Equal("ServiceUnavailable", retryHistory1.Code);
            Assert.Equal("015cece2-1149-4eba-8970-06b9286a1a30", retryHistory1.ClientRequestId);
            Assert.Null(retryHistory1.Error);

        }

        private void ValidateRunActionListResponse1(IPage<WorkflowRunAction> page)
        {
            Assert.Single(page);
            Assert.Equal("http://management.azure.com/actionNextLink", page.NextPageLink);
            this.ValidateRunAction1(page.First());
        }

        #endregion
    }
}
