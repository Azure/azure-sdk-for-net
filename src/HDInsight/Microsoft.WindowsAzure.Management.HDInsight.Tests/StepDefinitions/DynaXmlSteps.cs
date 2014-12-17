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
    using System.Xml;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.DynamicXml.Reader;
    using Microsoft.WindowsAzure.Management.HDInsight.JobSubmission.Data;
    using TechTalk.SpecFlow;

    [Binding]
    public class DynaXmlSteps
    {
        private XmlDocument document;
        private DynaXmlNamespaceTable namespaceTable;

        [Given(@"I have the xml content with:")]
        public void GivenIHaveTheXmlContentWith(string xml)
        {
            XmlDocumentConverter documentConverter = new XmlDocumentConverter();
            this.document = documentConverter.GetXmlDocument(xml);
        }

        [When(@"I generate the namespace table")]
        public void WhenIGenerateTheNamespaceTable()
        {
            this.namespaceTable = new DynaXmlNamespaceTable(this.document);
        }

        [Then(@"the namespace table should have (\d+) prefix matches defined")]
        public void TheNamespaceTableShouldHave_number_PrefixMatchesDefined(int number)
        {
            Assert.AreEqual(number, this.namespaceTable.Mappings.Count());
        }

        [Then(@"the namespace table should have (\d+) namespace matches defined")]
        public void TheNamespaceTableShouldHave_number_NamespaceMatchesDefined(int number)
        {
            Assert.AreEqual(number, this.namespaceTable.NamespaceMatches.Count());
        }

        [Then(@"the namespace table should match the prefix ""(.*)"" to the namespace ""(.*)""")]
        public void ThePrefix_prefix_ShouldBeMatchedToTheNamespace_xmlNamespace(string prefix, string xmlNamespace)
        {
            Assert.AreEqual(xmlNamespace, this.namespaceTable[prefix]);
        }

        [Then(@"the namespace table should match the uri ""(.*)"" to the prefixes ""(.*)""")]
        public void TheNamespace_namespace_ShouldBeMatchedToThePrefixes_prefixes(string xmlNamespace, string prefixes)
        {
            string[] list = prefixes.Split(',');
            IEnumerable<string> foundPrefixes = this.namespaceTable.NamespaceMatches[xmlNamespace];
            Assert.IsTrue(foundPrefixes.SequenceEqual(list));
        }
    }
}
