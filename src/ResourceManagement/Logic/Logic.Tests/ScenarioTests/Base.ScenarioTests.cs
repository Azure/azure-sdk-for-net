// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    public class BaseScenarioTests : TestBase
    {
        protected string resourceGroupName = "flowrg";
        protected string location = "westus";

        protected Sku sku = new Sku
        {
            Name = SkuName.Standard,
            Plan = new ResourceReference
            {
                Id = "/subscriptions/402177bc-c2ea-4a5d-98b3-7623eee7f0a1/resourceGroups/Default-SQL-EastAsia/providers/Microsoft.Web/serverFarms/Plan"
            }
        };

        protected LogicManagementClient GetLogicManagementClient(MockContext context)
        {
            return context.GetServiceClient<LogicManagementClient>();
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
