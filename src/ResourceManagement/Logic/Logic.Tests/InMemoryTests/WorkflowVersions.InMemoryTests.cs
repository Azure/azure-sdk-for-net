// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using System;
    using System.Net;
    using System.Net.Http;
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Xunit;

    public class WorkflowVersionsInMemoryTests : BaseInMemoryTests
    {
        #region Constructor

        private StringContent WorkflowVersion { get; set; }

        public WorkflowVersionsInMemoryTests()
        {
            var workflowVersion = @"{
    'id': '/subscriptions/66666666-6666-6666-6666-666666666666/resourceGroups/rgName/providers/Microsoft.Logic/workflows/wfName/versions/08587668503212262209',
    'name': '08587668503212262209',
    'type':'Microsoft.Logic/workflows/versions',
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
            this.WorkflowVersion = new StringContent(workflowVersion);
        }

        #endregion

        #region WorkflowVersions_Get

        [Fact]
        public void WorkflowVersions_Get_Exception()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent(string.Empty)
            };

            Assert.Throws<ValidationException>(() => client.WorkflowVersions.Get(null, "wfName", "version"));
            Assert.Throws<ValidationException>(() => client.WorkflowVersions.Get("rgName", null, "version"));
            Assert.Throws<ValidationException>(() => client.WorkflowVersions.Get("rgName", "wfName", null));
            Assert.Throws<CloudException>(() => client.WorkflowVersions.Get("rgName", "wfName", "version"));
        }

        public void WorkflowVersions_Get_OK()
        {
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);

            handler.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = this.WorkflowVersion
            };

            var result = client.WorkflowVersions.Get("rgName", "wfName", "08587668503212262209");

            // Validates request.
            handler.Request.ValidateAuthorizationHeader();
            handler.Request.ValidateMethod(HttpMethod.Get);

            // Validates result.
            this.ValidateWorkflowVersion1(result);
        }

        #endregion

        #region Validation

        private void ValidateWorkflowVersion1(WorkflowVersion workflow)
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

        #endregion
    }
}
