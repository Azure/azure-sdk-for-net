// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    public class BaseScenarioTests : TestBase
    {
        protected string resourceGroupName = "flowrg";
        protected string location = "westus";

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
                'tenant':'72f988bf-86f1-41af-91ab-2d7cd011db47',
                'clientId':'64011f29-3932-4168-b73d-adc835a56732',
                'secret':'q8Wf7SwoM4iSVgaHZdghScLX8xDxMMUATWvRalclJjo='
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
