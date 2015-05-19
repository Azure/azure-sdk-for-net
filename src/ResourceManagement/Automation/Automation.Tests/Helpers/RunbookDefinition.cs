//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

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