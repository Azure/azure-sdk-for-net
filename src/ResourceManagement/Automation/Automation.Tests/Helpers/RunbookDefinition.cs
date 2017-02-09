// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Automation.Testing
{
    public class RunbookDefinition
    {
        private readonly string psScript;
        private readonly string runbookName;

        public RunbookDefinition(string runbookName, string psScript)
        {
            this.runbookName = runbookName;
            this.psScript = psScript;
        }

        public string PsScript
        {
            get { return psScript; }
        }

        public string RunbookName
        {
            get { return runbookName; }
        }

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

        public static RunbookDefinition TestFasterWorkflow_V2 = new RunbookDefinition(
            "TestFasterWorkflow", @"Workflow TestFasterWorkflow {
                get-date
                start-sleep -s 10
            }");
    }
}