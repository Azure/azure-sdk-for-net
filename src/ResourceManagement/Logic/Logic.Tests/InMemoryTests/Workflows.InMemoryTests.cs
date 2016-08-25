// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Xunit;

    public class WorkflowsInMemoryTests : BaseInMemoryTests
    {
        #region Constructor

        private StringContent Workflow { get; set; }

        private StringContent WorkflowRun { get; set; }

        private StringContent WorkflowList { get; set; }

        public WorkflowsInMemoryTests()
        {
            var workflow = @"{
    'id': '/subscriptions/66666666-6666-6666-6666-666666666666/resourceGroups/rgName/providers/Microsoft.Logic/workflows/wfName',
    'name': 'wfName',
    'type':'Microsoft.Logic/workflows',
    'location':'westus',
    'properties': {
        'createdTime': '2015-06-23T21:47:00.0000001Z',
        'changedTime':'2015-06-23T21:47:30.0000002Z',
        'state':'Enabled',
        'version':'08587717906782501130',
        'accessEndpoint':'https://westus.logic.azure.com/subscriptions/66666666-6666-6666-6666-666666666666/resourceGroups/rgName/providers/Microsoft.Logic/workflows/wfName',
        'sku':{
            'name':'Premium',
            'plan':{
                'id':'/subscriptions/66666666-6666-6666-6666-666666666666/resourceGroups/rgName/providers/Microsoft.Web/serverFarms/planName',
                'type':'Microsoft.Web/serverFarms',
                'name':'planName'
            }
        },
        'definition':{
            '$schema':'http://schema.management.azure.com/providers/Microsoft.Logic/schemas/2014-12-01-preview/workflowdefinition.json#',
            'contentVersion':'1.0.0.0',
            'parameters':{
                'runworkflowmanually':{
                    'defaultValue':true,
                    'type':'Bool'
                },
                'subscription':{
                    'defaultValue':'66666666-6666-6666-6666-666666666666',
                    'type':'String'
                },
                'resourceGroup':{
                    'defaultValue':'logicapps-e2e',
                    'type':'String'
                },
                'authentication':{
                    'defaultValue':{
                        'type':'ActiveDirectoryOAuth',
                        'audience':'https://management.azure.com/',
                        'tenant':'66666666-6666-6666-6666-666666666666',
                        'clientId':'66666666-6666-6666-6666-666666666666',
                        'secret':'<placeholder>'
                    },
                    'type':'Object'
                }
            },
            'triggers':{
            },
            'actions':{
                'listWorkflows':{
                    'type':'Http',
                    'inputs':{
                        'method':'GET',
                        'uri':'someUri',
                        'authentication':'@parameters(""authentication"")'
                    },
                    'conditions':[

                    ]
                }
            },
            'outputs':{
            }
        },
        'parameters':{
            'parameter1':{
                'type': 'string',
                'value': 'abc'
            },
            'parameter2':{
                'type': 'array',
                'value': [1, 2, 3]
            }
        }
    }
}";

            var run = @"{
    'id':'/subscriptions/66666666-6666-6666-6666-666666666666/resourceGroups/rgName/providers/Microsoft.Logic/workflows/wfName/runs/run87646872399558047',
    'name':'run87646872399558047',
    'type':'Microsoft.Logic/workflows/runs',
    'properties':{
        'startTime':'2015-06-23T21:47:00.0000000Z',
        'endTime':'2015-06-23T21:47:30.1300000Z',
        'status':'Succeeded',
        'correlationId':'a04da054-a1ae-409d-80ff-b09febefc357',
        'workflow':{
            'name':'wfName/ver87717906782501130',
            'id':'/subscriptions/66666666-6666-6666-6666-666666666666/resourceGroups/rgName/providers/Microsoft.Logic/workflows/wfName/versions/ver87717906782501130',
            'type':'Microsoft.Logic/workflows/versions'
        },
        'trigger':{
            'name':'6A65DA9E-CFF8-4D3E-B5FB-691739C7AD61'
        },
        'outputs':{
        }
    }
}";
            var workflowListFormat = @"{{ 'value':[ {0} ], 'nextLink': 'http://workflowlist1nextlink' }}";

            this.Workflow = new StringContent(workflow);
            this.WorkflowRun = new StringContent(run);
            this.WorkflowList = new StringContent(string.Format(workflowListFormat, workflow));
        }

        #endregion

        #region Workflows_ListBySubscription

        [Fact]
        public void Workflows_ListBySubscription_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<CloudException>(() => client.Workflows.ListBySubscription());
        }

        public void Workflows_ListBySubscription_Success()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.WorkflowList
            };

            var result = client.Workflows.ListByResourceGroup("rgName");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            // Validates result.
            this.ValidateWorkflowList1(result);
        }

        #endregion

        #region Workflows_ListBySubscriptionNext

        [Fact]
        public void Workflows_ListBySubscriptionNext_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(() => client.Workflows.ListBySubscriptionNext(null));
            Assert.Throws<CloudException>(() => client.Workflows.ListBySubscriptionNext("http://management.azure.com/nextLink"));
        }

        public void Workflows_ListBySubscriptionNext_Success()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.WorkflowList
            };

            var result = client.Workflows.ListBySubscriptionNext("http://management.azure.com/nextLink");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            // Validates result.
            this.ValidateWorkflowList1(result);
        }

        #endregion

        #region Workflows_ListByResourceGroup

        [Fact]
        public void Workflows_ListByResourceGroup_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(() => client.Workflows.ListByResourceGroup(null));
            Assert.Throws<CloudException>(() => client.Workflows.ListByResourceGroup("rgName"));
        }

        [Fact]
        public void Workflows_ListByResourceGroup_Success()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.WorkflowList
            };

            var result = client.Workflows.ListByResourceGroup("rgName");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            // Validates result.
            this.ValidateWorkflowList1(result);
        }

        #endregion

        #region Workflows_ListByResourceGroupNext

        [Fact]
        public void Workflows_ListByResourceGroupNext_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(() => client.Workflows.ListByResourceGroupNext(null));
            Assert.Throws<CloudException>(() => client.Workflows.ListByResourceGroupNext("http://management.azure.com/nextLink"));
        }

        public void Workflows_ListByResourceGroupNext_Success()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.WorkflowList
            };

            var result = client.Workflows.ListByResourceGroupNext("http://management.azure.com/nextLink");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            // Validates result.
            this.ValidateWorkflowList1(result);
        }

        #endregion

        #region Workflows_CreateOrUpdate

        [Fact]
        public void Workflows_CreateOrUpdate_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(() => client.Workflows.CreateOrUpdate(null, "wfName", new Workflow()));
            Assert.Throws<ValidationException>(() => client.Workflows.CreateOrUpdate("rgName", null, new Workflow()));
            Assert.Throws<ValidationException>(() => client.Workflows.CreateOrUpdate("rgName", "wfName", null));
            Assert.Throws<CloudException>(() => client.Workflows.CreateOrUpdate("rgName", "wfName", new Workflow()));
        }

        [Fact]
        public void Workflows_CreateOrUpdate_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.Workflow
            };

            var workflow = client.Workflows.CreateOrUpdate("rgName", "wfName", new Workflow());

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Put);

            // Validates result.
            this.ValidateWorkflow1(workflow);
        }

        [Fact]
        public void Workflows_CreateOrUpdate_Created()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Created,
                Content = this.Workflow
            };

            var workflow = client.Workflows.CreateOrUpdate("rgName", "wfName", new Workflow());

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Put);

            // Validates result.
            this.ValidateWorkflow1(workflow);
        }

        #endregion

        #region Workflows_Delete

        [Fact]
        public void Workflows_Delete_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound
            };

            Assert.Throws<ValidationException>(() => client.Workflows.Delete(null, "wfName"));
            Assert.Throws<ValidationException>(() => client.Workflows.Delete("rgName", null));
            Assert.Throws<CloudException>(() => client.Workflows.Delete("rgName", "wfName"));
        }

        [Fact]
        public void Workflows_Delete_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK
            };

            client.Workflows.Delete("rgName", "wfName");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Delete);
        }

        [Fact]
        public void Workflows_Delete_NoContent()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NoContent
            };

            client.Workflows.Delete("rgName", "wfName");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Delete);
        }

        #endregion

        #region Workflows_Get

        [Fact]
        public void Workflows_Get_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(() => client.Workflows.Get(null, "wfName"));
            Assert.Throws<ValidationException>(() => client.Workflows.Get("rgName", null));
            Assert.Throws<CloudException>(() => client.Workflows.Get("rgName", "wfName"));
        }

        [Fact]
        public void Workflows_Get_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.Workflow
            };

            var result = client.Workflows.Get("rgName", "wfName");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            // Validates result.
            this.ValidateWorkflow1(result);
        }

        #endregion

        #region Workflows_Update

        [Fact]
        public void Workflows_Update_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(() => client.Workflows.Update(null, "wfName", new Workflow()));
            Assert.Throws<ValidationException>(() => client.Workflows.Update("rgName", null, new Workflow()));
            Assert.Throws<ValidationException>(() => client.Workflows.Update("rgName", "wfName", null));
            Assert.Throws<CloudException>(() => client.Workflows.Update("rgName", "wfName", new Workflow()));
        }

        [Fact]
        public void Workflows_Update_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.Workflow
            };

            var workflow = new Workflow()
                {
                    Tags = new Dictionary<string, string>()
                };
            workflow.Tags.Add("abc", "def");
            workflow = client.Workflows.Update("rgName", "wfName", workflow);

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(new HttpMethod("PATCH"));

            // Validates result.
            this.ValidateWorkflow1(workflow);
        }

        #endregion

        #region Workflows_Disable

        [Fact]
        public void Workflows_Disable_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError
            };

            Assert.Throws<ValidationException>(() => client.Workflows.Disable(null, "wfName"));
            Assert.Throws<ValidationException>(() => client.Workflows.Disable("rgName", null));
            Assert.Throws<CloudException>(() => client.Workflows.Disable("rgName", "wfName"));
        }

        [Fact]
        public void Workflows_Disable_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK
            };

            client.Workflows.Disable("rgName", "wfName");

            // Validates requests.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateAction("disable");
        }

        #endregion

        #region Workflows_Enable

        [Fact]
        public void Workflows_Enable_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError
            };

            Assert.Throws<ValidationException>(() => client.Workflows.Enable(null, "wfName"));
            Assert.Throws<ValidationException>(() => client.Workflows.Enable("rgName", null));
            Assert.Throws<CloudException>(() => client.Workflows.Enable("rgName", "wfName"));
        }

        [Fact]
        public void Workflows_Enable_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK
            };

            client.Workflows.Enable("rgName", "wfName");

            // Validates requests.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateAction("enable");
        }

        #endregion

        #region Workflows_Validate

        [Fact]
        public void Workflows_Validate_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError
            };

            Assert.Throws<ValidationException>(() => client.Workflows.Validate(null, "wfName", "westus", new Workflow()));
            Assert.Throws<ValidationException>(() => client.Workflows.Validate("rgName", null, "westus", new Workflow()));
            Assert.Throws<ValidationException>(() => client.Workflows.Validate("rgName", "wfName", null, new Workflow()));
            Assert.Throws<ValidationException>(() => client.Workflows.Validate("rgName", "wfName", "westus", null));
            Assert.Throws<CloudException>(() => client.Workflows.Validate("rgName", "wfName", "westus", new Workflow()));
        }

        [Fact]
        public void Workflows_Validate_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK
            };

            client.Workflows.Validate("rgName", "wfName", "westus", new Workflow());

            // Validates requests.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateAction("validate");
        }

        #endregion

        #region Workflows_GenerateUpgradedDefinition

        [Fact]
        public void Workflows_GenerateUpgradedDefinition_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(() => client.Workflows.GenerateUpgradedDefinition(null, "wfName", "2016-04-01-preview"));
            Assert.Throws<ValidationException>(() => client.Workflows.GenerateUpgradedDefinition("rgName", null, "2016-04-01-preview"));
            // The Assert is disabled due to the following bug: https://github.com/Azure/autorest/issues/1288.
            // Assert.Throws<ValidationException>(() => client.Workflows.GenerateUpgradedDefinition("rgName", "wfName", null));
            Assert.Throws<CloudException>(() => client.Workflows.GenerateUpgradedDefinition("rgName", "wfName", "2016-04-01-preview"));
        }

        [Fact]
        public void Workflows_GenerateUpgradedDefinition_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.Workflow
            };

            client.Workflows.GenerateUpgradedDefinition("rgName", "wfName", "2016-04-01-preview");

            // Validates requests.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateAction("generateUpgradedDefinition");
        }

        #endregion

        #region Validation

        private void ValidateWorkflowRun1(WorkflowRun workflowRun)
        {
            Assert.Equal("/subscriptions/66666666-6666-6666-6666-666666666666/resourceGroups/rgName/providers/Microsoft.Logic/workflows/wfName/runs/run87646872399558047", workflowRun.Id);
            Assert.Equal("run87646872399558047", workflowRun.Name);
            Assert.Equal("Microsoft.Logic/workflows/runs", workflowRun.Type);

            Assert.Equal(2015, workflowRun.StartTime.Value.Year);
            Assert.Equal(06, workflowRun.StartTime.Value.Month);
            Assert.Equal(23, workflowRun.StartTime.Value.Day);
            Assert.Equal(21, workflowRun.StartTime.Value.Hour);
            Assert.Equal(47, workflowRun.StartTime.Value.Minute);
            Assert.Equal(00, workflowRun.StartTime.Value.Second);
            Assert.Equal(00, workflowRun.StartTime.Value.Millisecond);
            Assert.Equal(DateTimeKind.Utc, workflowRun.StartTime.Value.Kind);

            Assert.Equal(2015, workflowRun.EndTime.Value.Year);
            Assert.Equal(06, workflowRun.EndTime.Value.Month);
            Assert.Equal(23, workflowRun.EndTime.Value.Day);
            Assert.Equal(21, workflowRun.EndTime.Value.Hour);
            Assert.Equal(47, workflowRun.EndTime.Value.Minute);
            Assert.Equal(30, workflowRun.EndTime.Value.Second);
            Assert.Equal(130, workflowRun.EndTime.Value.Millisecond);
            Assert.Equal(DateTimeKind.Utc, workflowRun.EndTime.Value.Kind);

            Assert.Equal(WorkflowStatus.Succeeded, workflowRun.Status.Value);
            Assert.Equal("a04da054-a1ae-409d-80ff-b09febefc357", workflowRun.CorrelationId);
            Assert.Equal("/subscriptions/66666666-6666-6666-6666-666666666666/resourceGroups/rgName/providers/Microsoft.Logic/workflows/wfName/versions/ver87717906782501130", workflowRun.Workflow.Id);
            Assert.Equal("Microsoft.Logic/workflows/versions", workflowRun.Workflow.Type);
            Assert.Equal("wfName/ver87717906782501130", workflowRun.Workflow.Name);

            Assert.Equal("6A65DA9E-CFF8-4D3E-B5FB-691739C7AD61", workflowRun.Trigger.Name);
            Assert.Equal(0, workflowRun.Outputs.Count);
        }

        private void ValidateWorkflow1(Workflow workflow)
        {
            Assert.Equal("/subscriptions/66666666-6666-6666-6666-666666666666/resourceGroups/rgName/providers/Microsoft.Logic/workflows/wfName", workflow.Id);
            Assert.Equal("wfName", workflow.Name);
            Assert.Equal("Microsoft.Logic/workflows", workflow.Type);
            Assert.Equal("westus", workflow.Location);

            // 2015-06-23T21:47:00.0000001Z
            Assert.Equal(2015, workflow.CreatedTime.Value.Year);
            Assert.Equal(06, workflow.CreatedTime.Value.Month);
            Assert.Equal(23, workflow.CreatedTime.Value.Day);
            Assert.Equal(21, workflow.CreatedTime.Value.Hour);
            Assert.Equal(47, workflow.CreatedTime.Value.Minute);
            Assert.Equal(00, workflow.CreatedTime.Value.Second);
            Assert.Equal(DateTimeKind.Utc, workflow.CreatedTime.Value.Kind);

            // 2015-06-23T21:47:30.0000002Z
            Assert.Equal(2015, workflow.ChangedTime.Value.Year);
            Assert.Equal(06, workflow.ChangedTime.Value.Month);
            Assert.Equal(23, workflow.ChangedTime.Value.Day);
            Assert.Equal(21, workflow.ChangedTime.Value.Hour);
            Assert.Equal(47, workflow.ChangedTime.Value.Minute);
            Assert.Equal(30, workflow.ChangedTime.Value.Second);
            Assert.Equal(DateTimeKind.Utc, workflow.ChangedTime.Value.Kind);

            Assert.Equal(WorkflowState.Enabled, workflow.State);
            Assert.Equal("08587717906782501130", workflow.Version);
            Assert.Equal("https://westus.logic.azure.com/subscriptions/66666666-6666-6666-6666-666666666666/resourceGroups/rgName/providers/Microsoft.Logic/workflows/wfName", workflow.AccessEndpoint);
            Assert.Equal(SkuName.Premium, workflow.Sku.Name);
            Assert.Equal("/subscriptions/66666666-6666-6666-6666-666666666666/resourceGroups/rgName/providers/Microsoft.Web/serverFarms/planName", workflow.Sku.Plan.Id);
            Assert.Equal("Microsoft.Web/serverFarms", workflow.Sku.Plan.Type);
            Assert.Equal("planName", workflow.Sku.Plan.Name);
            Assert.NotEmpty(workflow.Definition.ToString());
            Assert.Equal(2, workflow.Parameters.Count);
            Assert.Equal(ParameterType.String, workflow.Parameters["parameter1"].Type);
            Assert.Equal(ParameterType.Array, workflow.Parameters["parameter2"].Type);
        }

        private void ValidateWorkflowList1(IPage<Workflow> result)
        {
            Assert.Equal(1, result.Count());
            this.ValidateWorkflow1(result.First());
            Assert.Equal("http://workflowlist1nextlink", result.NextPageLink);
        }

        #endregion
    }
}
