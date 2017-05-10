﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
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
        protected string testClassName { get { return this.GetType().FullName; } }

        /// <summary>
        /// Default serviceplan Resource id 
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

        /// <summary>
        /// Default SKU reference.
        /// </summary>
        protected Sku Sku => new Sku
        {
            Name = SkuName.Standard,
            Plan = new ResourceReference(id: ServicePlanResourceId)
        };

        protected LogicManagementClient GetIntegrationAccountClient(MockContext context)
        {
            var client = context.GetServiceClient<LogicManagementClient>();
            return client;
        }

        /// <summary>
        /// Creates an Integartion account.
        /// </summary>
        /// <param name="integrationAccountName">Integration AccountName</param>
        /// <returns>IntegrationAccount instance</returns>
        protected IntegrationAccount CreateIntegrationAccountInstance(string integrationAccountName)
        {
            var createdAccount = new IntegrationAccount
            {                
                Sku = new IntegrationAccountSku()
                {
                    Name = IntegrationAccountSkuName.Standard
                },                
                Properties = new JObject(),
                Location = Constants.DefaultLocation
            };
            return createdAccount;
        }

        protected string resourceGroupName = "flowrg";

        protected string location = "westus";

        protected LogicManagementClient GetWorkflowClient(MockContext context)
        {
            var client = context.GetServiceClient<LogicManagementClient>();
            return client;
        }

        #region Data

        protected string definition = @"{
    '$schema':'http://schema.management.azure.com/providers/Microsoft.Logic/schemas/2014-12-01-preview/workflowdefinition.json#',
    'contentVersion':'1.0.0.0',
    'parameters':{
        'runworkflowmanually':{
            'defaultValue':true,
            'type':'Bool'
        },
        'subscription':{
            'defaultValue':'1a66ce04-b633-4a0b-b2bc-a912ec8986a6',
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
                'tenant':'00000000-0000-0000-0000-000000000000',
                'clientId':'00000000-0000-0000-0000-000000000000',
                'secret':'Dummy'
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
                'authentication':'@parameters(\'authentication\')'
            },
            'conditions':[

            ]
        }
    },
    'outputs':{
    }
}";

        protected string simpleDefinition = @"{
    '$schema':'http://schema.management.azure.com/providers/Microsoft.Logic/schemas/2014-12-01-preview/workflowdefinition.json#',
    'contentVersion':'1.0.0.0',
    'parameters':{
    },
    'triggers':{
    },
    'actions':{
        'httpAction':{
            'type':'Http',
            'inputs':{
                'method':'GET',
                'uri':'invalidUri'
            },
            'conditions':[
            ]
        }
    },
    'outputs':{
    }
}";

        protected string regenerateAccessKeyDefinition = @"{
    '$schema': 'http://json-schema.org/draft-04/schema/2016-06-01/workflowdefinition.json#',
    'triggers': {
        'manual': {
            'type':'request',
            'kind':'http'
        },
    },
    'actions': {
        'response': {
            'type': 'response',
            'inputs': {
                'statusCode': '200',
                'body': {
                    'value': 'test',
                },
                'headers': {
                }
            }
        }
    }
}";

        protected string listSwaggerDefinition = @"{
    '$schema': 'http://json-schema.org/draft-04/schema/2016-06-01',
    'triggers': {
        'request': {
            'type': 'Request',
            'kind': 'Http',
            'inputs': {
                'relativePath': 'abc/{xyz}',
                'method': 'get'
            }
        }
    },
    'actions': {
        'response': {
            'type': 'response',
            'inputs': {
                'statusCode': '200',
                'body': {},
                'headers': {}
            }
        }
    },
    'outputs': {}
}";

        protected string simpleTriggerDefinition = @"{
    '$schema':'http://schema.management.azure.com/providers/Microsoft.Logic/schemas/2014-12-01-preview/workflowdefinition.json#',
    'contentVersion':'1.0.0.0',
    'parameters':{
    },
    'triggers':{
        'httpTrigger':{
            'type':'Http',
            'inputs':{
                'method':'GET',
                'uri':'invalidUri'
            },
            'recurrence':{
                'frequency':'Minute',
                'interval':60
            }
        }
    },
    'actions':{
    },
    'outputs':{
        'output1':{
            'type':'string',
            'value':'@trigger().outputs',
        }
    }
}";
        #endregion
    }
}
