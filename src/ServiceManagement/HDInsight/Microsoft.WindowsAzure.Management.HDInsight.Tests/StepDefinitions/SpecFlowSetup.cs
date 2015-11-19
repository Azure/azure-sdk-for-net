// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.WindowsAzure.Management.HDInsight.Tests.StepDefinitions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;
    using TechTalk.SpecFlow;

    [Binding]
    public class SpecFlowSetup
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeScenario]
        public void BeforeScenario()
        {
            var manager = ServiceLocator.Instance.Locate<IServiceLocationSimulationManager>();
            manager.MockingLevel = ServiceLocationMockingLevel.ApplyFullMocking;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var manager = ServiceLocator.Instance.Locate<IServiceLocationSimulationManager>();
            manager.MockingLevel = ServiceLocationMockingLevel.ApplyFullMocking;
        }
    }
}
