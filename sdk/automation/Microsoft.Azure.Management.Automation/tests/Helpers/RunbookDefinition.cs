// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Automation.Tests.Helpers
{
    public class RunbookDefinition
    {
        public RunbookDefinition(string runbookName, string psScript)
        {
            RunbookName = runbookName;
            PsScript = psScript;
        }

        public string PsScript { get; }

        public string RunbookName { get; }

        public static RunbookDefinition TestLongRunningWorkflow = new RunbookDefinition(
            "TestLongRunningWorkflow", @"Workflow TestLongRunningWorkflow {  
                param([int] $maxCount = 20)
                ""maxCount  is "" + $maxCount 
                for ($i = 0; $i -lt $maxCount; $i++ )
                {
                    write-progress -activity ""Long running workflow in Progress out of $maxCount"" -status ""% Complete:"" -percentcomplete $i;                                
                    get-date
                    start-sleep -Seconds 2
                    pspersist
                }
            }");

        public static RunbookDefinition TestFasterWorkflow = new RunbookDefinition(
            "TestFasterWorkflow", @"Workflow TestFasterWorkflow {
                get-date
            }");

        public static RunbookDefinition TestFasterWorkflowV2 = new RunbookDefinition(
            "TestFasterWorkflow", @"Workflow TestFasterWorkflow {
                get-date
                start-sleep -s 10
            }");

        public static RunbookDefinition TestPSScript = new RunbookDefinition(
            "TestPSScript", @"get-date");

        public static RunbookDefinition TestPSScriptV2 = new RunbookDefinition(
            "TestPSScript", @"get-date; start-sleep -seconds 10");
    }
}