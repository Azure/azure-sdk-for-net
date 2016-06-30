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

    public class WorkflowRunsInMemoryTests : BaseInMemoryTests
    {
        #region Constructor

        private StringContent Run { get; set; }

        private StringContent RunListResponse { get; set; }

        public WorkflowRunsInMemoryTests()
        {
            var run = @"{
    'id':'/subscriptions/66666666-6666-6666-6666-666666666666/resourceGroups/rgName/providers/Microsoft.Logic/workflows/wfName/runs/08587692861242198730',
    'name':'08587692861242198730',
    'type':'Microsoft.Logic/workflows/runs',
    'properties':{
        'startTime': '2015-06-23T21:47:00.0000001Z',
        'endTime':'2015-06-23T21:47:30.0000002Z',
        'status':'Succeeded',
        'correlationId':'4701405c-1543-4127-adb9-a396717a4ffb',
        'workflow':{
            'name':'wfName/08587717906782501130',
            'id':'/subscriptions/66666666-6666-6666-6666-666666666666/resourceGroups/rgName/providers/Microsoft.Logic/workflows/wfName/versions/08587717906782501130',
            'type':'Microsoft.Logic/workflows/versions'
        },
        'trigger':{
            'outputsLink':{
                'uri':'https://someurl.blob.core.windows.net/someurl',
                'contentVersion':'""0x8D262D79DE77699""',
                'contentSize':2080,
                'contentHash':{
                    'algorithm':'md5',
                    'value':'4Ikl8rJkAg3bN8C9I6nKFQ=='
                }
            }
        },
        'outputs':{
        }
    }
}";

            var runListResponseFormat = @"{{ 'value': [ {0} ], 'nextLink': 'http://management.azure.com/runNextLink' }}";

            this.Run = new StringContent(run);
            this.RunListResponse = new StringContent(string.Format(runListResponseFormat, run));
        }

        #endregion

        #region WorkflowRuns_List

        [Fact]
        public void WorkflowRuns_List_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = this.Empty
            };

            Assert.Throws<ValidationException>(() => client.WorkflowRuns.List(null, "wfName"));
            Assert.Throws<ValidationException>(() => client.WorkflowRuns.List("rgName", null));
            Assert.Throws<CloudException>(() => client.WorkflowRuns.List("rgName", "wfName"));
        }

        [Fact]
        public void WorkflowRuns_List_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.RunListResponse
            };

            var response = client.WorkflowRuns.List("rgName", "wfName");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            // Validates result.
            this.ValidateRunListResponse1(response);
        }

        #endregion

        #region WorkflowRuns_ListNext

        [Fact]
        public void WorkflowRuns_ListNext_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = this.Empty
            };

            Assert.Throws<ValidationException>(() => client.WorkflowRuns.ListNext(null));
            Assert.Throws<CloudException>(() => client.WorkflowRuns.ListNext("http://management.azure.com/runNext"));
        }

        [Fact]
        public void WorkflowRuns_ListNext_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.RunListResponse
            };

            var response = client.WorkflowRuns.ListNext("http://management.azure.com/runNext");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            // Validates result.
            this.ValidateRunListResponse1(response);
        }

        #endregion

        #region WorkflowRuns_Get

        [Fact]
        public void WorkflowRuns_Get_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = this.Empty
            };

            Assert.Throws<ValidationException>(() => client.WorkflowRuns.Get(null, "wfName", "rName"));
            Assert.Throws<ValidationException>(() => client.WorkflowRuns.Get("rgName", null, "rName"));
            Assert.Throws<ValidationException>(() => client.WorkflowRuns.Get("rgName", "wfName", null));
            Assert.Throws<CloudException>(() => client.WorkflowRuns.Get("rgName", "wfName", "rName"));
        }

        [Fact]
        public void WorkflowRuns_Get_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.Run
            };

            var run = client.WorkflowRuns.Get("rgName", "wfName", "rName");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            // Validates result.
            this.ValidateRun1(run);
        }

        #endregion

        #region WorkflowRuns_Cancel

        [Fact]
        public void WorkflowRuns_Cancel_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = this.Empty
            };

            Assert.Throws<ValidationException>(() => client.WorkflowRuns.Cancel(null, "wfName", "rName"));
            Assert.Throws<ValidationException>(() => client.WorkflowRuns.Cancel("rgName", null, "rName"));
            Assert.Throws<ValidationException>(() => client.WorkflowRuns.Cancel("rgName", "wfName", null));
            Assert.Throws<CloudException>(() => client.WorkflowRuns.Cancel("rgName", "wfName", "rName"));
        }

        [Fact]
        public void WorkflowRuns_Cancel_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.Empty
            };

            client.WorkflowRuns.Cancel("rgName", "wfName", "rName");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateAction("cancel");
        }

        #endregion

        #region Validation

        private void ValidateRun1(WorkflowRun run)
        {
            Assert.Equal("/subscriptions/66666666-6666-6666-6666-666666666666/resourceGroups/rgName/providers/Microsoft.Logic/workflows/wfName/runs/08587692861242198730", run.Id);
            Assert.Equal("08587692861242198730", run.Name);
            Assert.Equal("Microsoft.Logic/workflows/runs", run.Type);

            Assert.Equal(2015, run.StartTime.Value.Year);
            Assert.Equal(06, run.StartTime.Value.Month);
            Assert.Equal(23, run.StartTime.Value.Day);
            Assert.Equal(21, run.StartTime.Value.Hour);
            Assert.Equal(47, run.StartTime.Value.Minute);
            Assert.Equal(00, run.StartTime.Value.Second);
            Assert.Equal(DateTimeKind.Utc, run.StartTime.Value.Kind);

            Assert.Equal(2015, run.EndTime.Value.Year);
            Assert.Equal(06, run.EndTime.Value.Month);
            Assert.Equal(23, run.EndTime.Value.Day);
            Assert.Equal(21, run.EndTime.Value.Hour);
            Assert.Equal(47, run.EndTime.Value.Minute);
            Assert.Equal(30, run.EndTime.Value.Second);
            Assert.Equal(DateTimeKind.Utc, run.EndTime.Value.Kind);

            Assert.Equal(WorkflowStatus.Succeeded, run.Status);
            Assert.Equal("4701405c-1543-4127-adb9-a396717a4ffb", run.CorrelationId);
            Assert.Equal("/subscriptions/66666666-6666-6666-6666-666666666666/resourceGroups/rgName/providers/Microsoft.Logic/workflows/wfName/versions/08587717906782501130", run.Workflow.Id);
            Assert.Equal("wfName/08587717906782501130", run.Workflow.Name);
            Assert.Equal("Microsoft.Logic/workflows/versions", run.Workflow.Type);
            Assert.Equal("https://someurl.blob.core.windows.net/someurl", run.Trigger.OutputsLink.Uri);
            Assert.Equal("\"0x8D262D79DE77699\"", run.Trigger.OutputsLink.ContentVersion);
            Assert.Equal(2080, run.Trigger.OutputsLink.ContentSize);
            Assert.Equal("md5", run.Trigger.OutputsLink.ContentHash.Algorithm);
            Assert.Equal("4Ikl8rJkAg3bN8C9I6nKFQ==", run.Trigger.OutputsLink.ContentHash.Value);
        }

        private void ValidateRunListResponse1(IPage<WorkflowRun> page)
        {
            Assert.Equal(1, page.Count());
            Assert.Equal("http://management.azure.com/runNextLink", page.NextPageLink);
            this.ValidateRun1(page.First());
        }

        #endregion
    }
}
