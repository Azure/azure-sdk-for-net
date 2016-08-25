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

    public class WorkflowTriggersInMemoryTests : BaseInMemoryTests
    {
        #region Constructor

        private StringContent Trigger { get; set; }

        private StringContent TriggerListResponse { get; set; }

        public WorkflowTriggersInMemoryTests()
        {
            var trigger = @"{
    'id':'/subscriptions/66666666-6666-6666-6666-666666666666/resourceGroups/rgName/providers/Microsoft.Logic/workflows/wfName/triggers/tName',
    'name':'tName',
    'type':'Microsoft.Logic/workflows/triggers',
    'properties':{
        'createdTime': '2015-06-23T21:47:00.0000001Z',
        'changedTime':'2015-06-23T21:47:30.0000002Z',
        'state':'Enabled',
        'status':'Waiting',
        'lastExecutionTime':'2015-01-01T01:01:01Z',
        'nextExecutionTime':'2015-01-01T02:01:01Z',
        'recurrence':{
            'frequency':'Hour',
            'interval':1
        },
        'workflow':{
            'name':'wfName/08587692632149400005',
            'id':'/subscriptions/66666666-6666-6666-6666-666666666666/resourceGroups/rgName/providers/Microsoft.Logic/workflows/wfName/versions/08587692632149400005',
            'type':'Microsoft.Logic/workflows/versions'
        }
    }
}";

            var triggerListResponseFormat = @"{{ 'value': [ {0} ], 'nextLink': 'http://management.azure.com/triggerNextLink' }}";

            this.Trigger = new StringContent(trigger);
            this.TriggerListResponse = new StringContent(string.Format(triggerListResponseFormat, trigger));
        }

        #endregion

        #region WorkflowTriggers_List

        [Fact]
        public void WorkflowTriggers_List_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = this.Empty
            };

            Assert.Throws<ValidationException>(() => client.WorkflowTriggers.List(null, "wfName"));
            Assert.Throws<ValidationException>(() => client.WorkflowTriggers.List("rgName", null));
            Assert.Throws<CloudException>(() => client.WorkflowTriggers.List("rgName", "wfName"));
        }

        [Fact]
        public void WorkflowTriggers_List_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.TriggerListResponse
            };

            var response = client.WorkflowTriggers.List("rgName", "wfName");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            // Validates result.
            this.ValidateTriggerListResponse1(response);
        }

        #endregion

        #region WorkflowTriggers_ListNext

        [Fact]
        public void WorkflowTriggers_ListNext_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = this.Empty
            };

            Assert.Throws<ValidationException>(() => client.WorkflowTriggers.ListNext(null));
            Assert.Throws<CloudException>(() => client.WorkflowTriggers.ListNext("http://management.azure.com/triggerNext"));
        }

        [Fact]
        public void WorkflowTriggers_ListNext_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.TriggerListResponse
            };

            var response = client.WorkflowTriggers.ListNext("http://management.azure.com/triggerNext");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            // Validates result.
            this.ValidateTriggerListResponse1(response);
        }

        #endregion

        #region WorkflowTriggers_Get

        [Fact]
        public void WorkflowTriggers_Get_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = this.Empty
            };

            Assert.Throws<ValidationException>(() => client.WorkflowTriggers.Get(null, "wfName", "triggerName"));
            Assert.Throws<ValidationException>(() => client.WorkflowTriggers.Get("rgName", null, "triggerName"));
            Assert.Throws<ValidationException>(() => client.WorkflowTriggers.Get("rgName", "wfName", null));
            Assert.Throws<CloudException>(() => client.WorkflowTriggers.Get("rgName", "wfName", "triggerName"));
        }

        [Fact]
        public void WorkflowTriggers_Get_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.Trigger
            };

            var trigger = client.WorkflowTriggers.Get("rgName", "wfName", "triggerName");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            // Validates result.
            this.ValidateTrigger1(trigger);
        }

        #endregion

        #region WorkflowTriggers_Run

        [Fact]
        public void WorkflowTriggers_Run_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = this.Empty
            };

            Assert.Throws<ValidationException>(() => client.WorkflowTriggers.Run(null, "wfName", "triggerName"));
            Assert.Throws<ValidationException>(() => client.WorkflowTriggers.Run("rgName", null, "triggerName"));
            Assert.Throws<ValidationException>(() => client.WorkflowTriggers.Run("rgName", "wfName", null));
            Assert.Throws<HttpOperationException>(() => client.WorkflowTriggers.Run("rgName", "wfName", "triggerName"));
        }

        [Fact]
        public void WorkflowTriggers_Run_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.Empty
            };

            client.WorkflowTriggers.Run("rgName", "wfName", "triggerName");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateAction("run");
        }

        [Fact]
        public void WorkflowTriggers_Run_OK_Accepted()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Accepted,
                Content = this.Empty
            };

            client.WorkflowTriggers.Run("rgName", "wfName", "triggerName");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateAction("run");
        }

        [Fact]
        public void WorkflowTriggers_Run_OK_NoContent()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NoContent,
                Content = this.Empty
            };

            client.WorkflowTriggers.Run("rgName", "wfName", "triggerName");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateAction("run");
        }

        #endregion

        #region WorkflowTriggers_ListCallbackUrl

        [Fact]
        public void WorkflowTriggers_ListCallbackUrl_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = this.Empty
            };

            Assert.Throws<ValidationException>(() => client.WorkflowTriggers.ListCallbackUrl(null, "wfName", "triggerName"));
            Assert.Throws<ValidationException>(() => client.WorkflowTriggers.ListCallbackUrl("rgName", null, "triggerName"));
            Assert.Throws<ValidationException>(() => client.WorkflowTriggers.ListCallbackUrl("rgName", "wfName", null));
            Assert.Throws<CloudException>(() => client.WorkflowTriggers.ListCallbackUrl("rgName", "wfName", "triggerName"));
        }

        [Fact]
        public void WorkflowTriggers_ListCallbackUrl_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            var triggerCallbackUrl = @"https://prod-07.westus.logic.azure.com:443" +
                @"/subscriptions/66666666-6666-6666-6666-666666666666/resourceGroups/rgName" +
                @"/providers/Microsoft.Logic/workflows/wfName/triggers/manual/listCallbackUrl";
            var responseContent = new StringContent($"{{ 'value' : '{triggerCallbackUrl}' }}");

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = responseContent,
            };

            var triggerUrl = client.WorkflowTriggers.ListCallbackUrl("rgName", "wfName", "triggerName");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Post);

            // Validates result.
            Assert.Equal(triggerCallbackUrl, triggerUrl.Value);
        }

        #endregion

        #region Validation

        private void ValidateTrigger1(WorkflowTrigger trigger)
        {
            Assert.Equal("/subscriptions/66666666-6666-6666-6666-666666666666/resourceGroups/rgName/providers/Microsoft.Logic/workflows/wfName/triggers/tName", trigger.Id);
            Assert.Equal("tName", trigger.Name);
            Assert.Equal("Microsoft.Logic/workflows/triggers", trigger.Type);

            Assert.Equal(2015, trigger.CreatedTime.Value.Year);
            Assert.Equal(06, trigger.CreatedTime.Value.Month);
            Assert.Equal(23, trigger.CreatedTime.Value.Day);
            Assert.Equal(21, trigger.CreatedTime.Value.Hour);
            Assert.Equal(47, trigger.CreatedTime.Value.Minute);
            Assert.Equal(00, trigger.CreatedTime.Value.Second);
            Assert.Equal(DateTimeKind.Utc, trigger.CreatedTime.Value.Kind);

            Assert.Equal(2015, trigger.ChangedTime.Value.Year);
            Assert.Equal(06, trigger.ChangedTime.Value.Month);
            Assert.Equal(23, trigger.ChangedTime.Value.Day);
            Assert.Equal(21, trigger.ChangedTime.Value.Hour);
            Assert.Equal(47, trigger.ChangedTime.Value.Minute);
            Assert.Equal(30, trigger.ChangedTime.Value.Second);
            Assert.Equal(DateTimeKind.Utc, trigger.ChangedTime.Value.Kind);

            Assert.Equal(WorkflowState.Enabled, trigger.State);
            Assert.Equal(WorkflowStatus.Waiting, trigger.Status);

            Assert.Equal(2015, trigger.LastExecutionTime.Value.Year);
            Assert.Equal(1, trigger.LastExecutionTime.Value.Month);
            Assert.Equal(1, trigger.LastExecutionTime.Value.Day);
            Assert.Equal(1, trigger.LastExecutionTime.Value.Hour);
            Assert.Equal(1, trigger.LastExecutionTime.Value.Minute);
            Assert.Equal(1, trigger.LastExecutionTime.Value.Second);
            Assert.Equal(DateTimeKind.Utc, trigger.LastExecutionTime.Value.Kind);

            Assert.Equal(2015, trigger.NextExecutionTime.Value.Year);
            Assert.Equal(1, trigger.NextExecutionTime.Value.Month);
            Assert.Equal(1, trigger.NextExecutionTime.Value.Day);
            Assert.Equal(2, trigger.NextExecutionTime.Value.Hour);
            Assert.Equal(1, trigger.NextExecutionTime.Value.Minute);
            Assert.Equal(1, trigger.NextExecutionTime.Value.Second);
            Assert.Equal(DateTimeKind.Utc, trigger.NextExecutionTime.Value.Kind);

            Assert.Equal(RecurrenceFrequency.Hour, trigger.Recurrence.Frequency);
            Assert.Equal(1, trigger.Recurrence.Interval);
            Assert.Equal("/subscriptions/66666666-6666-6666-6666-666666666666/resourceGroups/rgName/providers/Microsoft.Logic/workflows/wfName/versions/08587692632149400005", trigger.Workflow.Id);
            Assert.Equal("wfName/08587692632149400005", trigger.Workflow.Name);
            Assert.Equal("Microsoft.Logic/workflows/versions", trigger.Workflow.Type);

        }

        private void ValidateTriggerListResponse1(IPage<WorkflowTrigger> page)
        {
            Assert.Equal(1, page.Count());
            Assert.Equal("http://management.azure.com/triggerNextLink", page.NextPageLink);
            this.ValidateTrigger1(page.First());
        }

        #endregion
    }
}
