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
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.HDInsight.JobSubmission;
    using TechTalk.SpecFlow;

    [Binding]
    class UriResolverSteps
    {
        private string uri;
        private Version version = null;
        private Uri resolvedUri;
            
        [Given(@"I have the uri ""(.*)""")]
        public void GivenIHaveTheUri_uri(string uri)
        {
            this.uri = uri;
        }

        [Given(@"I have a version (.*) cluster")]
        public void GivenIHaveAVersion_version_Cluster(string version)
        {
            if (version == "unknown")
            {
                this.version = new Version(0, 0);
            }
            else
            {
                this.version = Version.Parse(version);
            }
        }

        [When(@"I resolve the cluster url")]
        public void WhenIResolveTheClusterUri()
        {
            this.resolvedUri = GatewayUriResolver.GetGatewayUri(this.uri, this.version);
        }

        [Then(@"the resolved uri should be equal to ""(.*)""")]
        public void ThenTheResolvedUriShouldBeEqualTo(string uri)
        {
            Assert.AreEqual(new Uri(uri), this.resolvedUri);
        }
    }
}
