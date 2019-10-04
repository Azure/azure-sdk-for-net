// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using System;
    using System.Globalization;
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Base class for scenario tests provides common methods and attributes.
    /// </summary>
    abstract public class ScenarioTestsBase : TestBase
    {
        /// <summary>
        /// Name of the test class
        /// </summary>
        protected Type TestClassType => this.GetType();

        /// <summary>
        /// Default Service Plan resource id 
        /// </summary>
        protected string ServicePlanResourceId
        {
            get
            {
                var val = string.Format(CultureInfo.InvariantCulture,
                    "/subscriptions/{0}/resourcegroups/{1}/providers/{2}/{3}",
                    Constants.DefaultSubscription,
                    Constants.DefaultResourceGroup,
                    "microsoft.web/serverfarms",
                    Constants.DefaultServicePlan);
                return val;
            }
        }

        protected void CleanResourceGroup(LogicManagementClient client, string resourceGroup = Constants.DefaultResourceGroup)
        {
            var integrationAccounts = client.IntegrationAccounts.ListByResourceGroup(resourceGroup);
            foreach(var integrationAccount in integrationAccounts)
            {
                client.IntegrationAccounts.Delete(resourceGroup, integrationAccount.Name);
            }

            var workflows = client.Workflows.ListByResourceGroup(resourceGroup);
            foreach(var workflow in workflows)
            {
                client.Workflows.Delete(resourceGroup, workflow.Name);
            }
        }

        protected LogicManagementClient GetClient(MockContext context)
        {
            return context.GetServiceClient<LogicManagementClient>();
        }

        /// <summary>
        /// Creates an Integartion account.
        /// </summary>
        /// <param name="integrationAccountName">Integration Account name</param>
        /// <returns>Integration Account instance</returns>
        protected IntegrationAccount CreateIntegrationAccount(string integrationAccountName)
        {
            var integrationAccount = new IntegrationAccount(name: integrationAccountName,
                location: Constants.DefaultLocation,
                properties: new JObject(),
                sku: new IntegrationAccountSku(IntegrationAccountSkuName.Standard));

            return integrationAccount;
        }

        /// <summary>
        /// Creates a workflow.
        /// </summary>
        /// <param name="workflowName">Workflow name</param>
        /// <returns>a workflow</returns>
        protected Workflow CreateWorkflow(string workflowName)
        {
            var workflow = new Workflow(name: workflowName,
                location: Constants.DefaultLocation,
                definition: this.WorkflowDefinition);

            return workflow;
        }


        private JToken WorkflowDefinition => JToken.Parse(@"
        {
            '$schema': 'https://schema.management.azure.com/providers/Microsoft.Logic/schemas/2016-06-01/workflowdefinition.json#',
            'contentVersion': '1.0.0.0',
            'parameters': {},
            'triggers': {
                'manual': {
                    'type': 'Request',
                    'kind': 'Http',
                    'inputs': {
                    'schema': {}
                    }
                }
            },
            'actions': {
                'Response': {
                    'runAfter': {},
                    'type': 'Response',
                    'kind': 'Http',
                    'inputs': {
                    'statusCode': 200
                    }
                }
            },
            'outputs': {}
        }");
    }
}

