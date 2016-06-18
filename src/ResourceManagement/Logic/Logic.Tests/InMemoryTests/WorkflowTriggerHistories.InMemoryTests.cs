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

    public class WorkflowTriggerHistoriesInMemoryTests : BaseInMemoryTests
    {
        #region Constructor

        private StringContent TriggerHistory { get; set; }

        private StringContent TriggerHistoryListResponse { get; set; }

        public WorkflowTriggerHistoriesInMemoryTests()
        {
            var triggerHistory = @"{
    'id':'/subscriptions/66666666-6666-6666-6666-666666666666/resourceGroups/rgName/providers/Microsoft.Logic/workflows/wfName/triggers/tName/histories/08587646315851320553',
    'name':'08587646315851320553',
    'type':'Microsoft.Logic/workflows/triggers/histories',
    'properties':{
        'startTime': '2015-06-23T21:47:00.0000001Z',
        'endTime':'2015-06-23T21:47:30.0000002Z',
        'status':'Succeeded',
        'code':'OK',
        'trackingId':'bfeb415e-0419-4c6e-8b1f-31b2bc0ba431',
        'inputsLink':{
            'uri':'https://flow.blob.core.windows.net/in',
            'contentVersion':'""0x8D28D2CDBC725AF""',
            'contentSize':690,
            'contentHash':{
                'algorithm':'md5',
                'value':'f2fmvRYYLWeo4OQ1djP0hQ=='
            }
        },
        'outputsLink':{
            'uri':'https://flow.blob.core.windows.net/out',
            'contentVersion':'""0x8D28D2CDBE8B850""',
            'contentSize':543,
            'contentHash':{
                'algorithm':'md5',
                'value':'Fq2wzoMQpAJYmc7wm/nqHg=='
            }
        },
        'fired':false
    }
}";

            var triggerHistoryListResponseFormat = @"{{ 'value': [ {0} ], 'nextLink': 'http://management.azure.com/keyNextLink' }}";

            this.TriggerHistory = new StringContent(triggerHistory);
            this.TriggerHistoryListResponse = new StringContent(string.Format(triggerHistoryListResponseFormat, triggerHistory));
        }

        #endregion

        #region WorkflowTriggerHistories_List

        [Fact]
        public void WorkflowTriggerHistories_List_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);            
            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = this.Empty
            };

            Assert.Throws<ValidationException>(() => client.WorkflowTriggerHistories.List(null, "wfName", "triggerName"));
            Assert.Throws<ValidationException>(() => client.WorkflowTriggerHistories.List("rgName", null, "triggerName"));
            Assert.Throws<ValidationException>(() => client.WorkflowTriggerHistories.List("rgName", "wfName", null));
            Assert.Throws<CloudException>(() => client.WorkflowTriggerHistories.List("rgName", "wfName", "triggerName"));
        }

        [Fact]
        public void WorkflowTriggerHistories_List_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);
            
            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.TriggerHistoryListResponse
            };

            var response = client.WorkflowTriggerHistories.List("rgName", "wfName", "triggerName");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            // Validates result.
            this.ValidateTriggerHistoryListResponse1(response);
        }

        #endregion

        #region WorkflowTriggerHistories_ListNext

        [Fact]
        public void WorkflowTriggerHistories_ListNext_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);
            
            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = this.Empty
            };

            Assert.Throws<ValidationException>(() => client.WorkflowTriggerHistories.ListNext(null));
            Assert.Throws<CloudException>(() => client.WorkflowTriggerHistories.ListNext("http://management.azure.com/historyLink"));
        }

        [Fact]
        public void WorkflowTriggerHistories_ListNext_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.TriggerHistoryListResponse
            };

            var response = client.WorkflowTriggerHistories.ListNext("http://management.azure.com/historyLink");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            // Validates result.
            this.ValidateTriggerHistoryListResponse1(response);
        }

        #endregion

        #region WorkflowTriggerHistories_Get

        [Fact]
        public void WorkflowTriggerHistories_Get_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);
            
            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = this.Empty
            };

            Assert.Throws<ValidationException>(() => client.WorkflowTriggerHistories.Get(null, "wfName", "triggerName", "historyName"));
            Assert.Throws<ValidationException>(() => client.WorkflowTriggerHistories.Get("rgName", null, "triggerName", "historyName"));
            Assert.Throws<ValidationException>(() => client.WorkflowTriggerHistories.Get("rgName", "wfName", null, "historyName"));
            Assert.Throws<ValidationException>(() => client.WorkflowTriggerHistories.Get("rgName", "wfName", "triggerName", null));
            Assert.Throws<CloudException>(() => client.WorkflowTriggerHistories.Get("rgName", "wfName", "triggerName", "historyName"));
        }

        [Fact]
        public void WorkflowTriggerHistories_Get_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);
            
            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.TriggerHistory
            };

            var hitory = client.WorkflowTriggerHistories.Get("rgName", "wfName", "triggerName", "historyName");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            // Validates result.
            this.ValidateTriggerHistory1(hitory);
        }

        #endregion

        #region Validation

        private void ValidateTriggerHistory1(WorkflowTriggerHistory history)
        {
            Assert.Equal("/subscriptions/66666666-6666-6666-6666-666666666666/resourceGroups/rgName/providers/Microsoft.Logic/workflows/wfName/triggers/tName/histories/08587646315851320553", history.Id);
            Assert.Equal("08587646315851320553", history.Name);
            Assert.Equal("Microsoft.Logic/workflows/triggers/histories", history.Type);

            Assert.Equal(2015, history.StartTime.Value.Year);
            Assert.Equal(06, history.StartTime.Value.Month);
            Assert.Equal(23, history.StartTime.Value.Day);
            Assert.Equal(21, history.StartTime.Value.Hour);
            Assert.Equal(47, history.StartTime.Value.Minute);
            Assert.Equal(00, history.StartTime.Value.Second);
            Assert.Equal(DateTimeKind.Utc, history.StartTime.Value.Kind);

            Assert.Equal(2015, history.EndTime.Value.Year);
            Assert.Equal(06, history.EndTime.Value.Month);
            Assert.Equal(23, history.EndTime.Value.Day);
            Assert.Equal(21, history.EndTime.Value.Hour);
            Assert.Equal(47, history.EndTime.Value.Minute);
            Assert.Equal(30, history.EndTime.Value.Second);
            Assert.Equal(DateTimeKind.Utc, history.EndTime.Value.Kind);

            Assert.Equal(WorkflowStatus.Succeeded, history.Status);
            Assert.Equal("OK", history.Code);
            Assert.Equal("bfeb415e-0419-4c6e-8b1f-31b2bc0ba431", history.TrackingId);

            Assert.Equal("https://flow.blob.core.windows.net/in", history.InputsLink.Uri);
            Assert.Equal("\"0x8D28D2CDBC725AF\"", history.InputsLink.ContentVersion);
            Assert.Equal(690, history.InputsLink.ContentSize);
            Assert.Equal("md5", history.InputsLink.ContentHash.Algorithm);
            Assert.Equal("f2fmvRYYLWeo4OQ1djP0hQ==", history.InputsLink.ContentHash.Value);

            Assert.Equal("https://flow.blob.core.windows.net/out", history.OutputsLink.Uri);
            Assert.Equal("\"0x8D28D2CDBE8B850\"", history.OutputsLink.ContentVersion);
            Assert.Equal(543, history.OutputsLink.ContentSize);
            Assert.Equal("md5", history.OutputsLink.ContentHash.Algorithm);
            Assert.Equal("Fq2wzoMQpAJYmc7wm/nqHg==", history.OutputsLink.ContentHash.Value);
        }

        private void ValidateTriggerHistoryListResponse1(IPage<WorkflowTriggerHistory> page)
        {
            Assert.Equal(1, page.Count());
            Assert.Equal("http://management.azure.com/keyNextLink", page.NextPageLink);
            this.ValidateTriggerHistory1(page.First());
        }

        #endregion
    }
}
