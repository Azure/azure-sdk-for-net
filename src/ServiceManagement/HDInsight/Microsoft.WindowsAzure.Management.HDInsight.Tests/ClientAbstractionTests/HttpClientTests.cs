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
namespace Microsoft.WindowsAzure.Management.HDInsight.Tests.ClientAbstractionTests
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.WebRequest;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.InversionOfControl;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities;

    [TestClass]
    public class HttpClientTests : IntegrationTestBase
    {
        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CanPrettyPrintXmlContent()
        {
            var unindentedContent = "<root><key>phani</key><value></value></root>";
            var expectedIndentedContnet =
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<root>\r\n  <key>phani</key>\r\n  <value>\r\n  </value>\r\n</root>";
            string indentedContent;
            Assert.IsTrue(HttpClientAbstraction.TryPrettyPrintXml(unindentedContent, out indentedContent));
            Assert.AreEqual(expectedIndentedContnet, indentedContent);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CannotPrettyPrintEmptyXmlContent()
        {
            var unindentedContent = string.Empty;
            var expectedIndentedContnet = string.Empty;
            string indentedContent;
            Assert.IsFalse(HttpClientAbstraction.TryPrettyPrintXml(unindentedContent, out indentedContent));
            Assert.AreEqual(expectedIndentedContnet, indentedContent);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        public void CannotPrettyPrintInvalidXmlContent()
        {
            var invalidXmlContent = "<root>PhaniRaj";
            string indentedContent;
            Assert.IsFalse(HttpClientAbstraction.TryPrettyPrintXml(invalidXmlContent, out indentedContent));
            Assert.AreEqual(invalidXmlContent, indentedContent);
        }
    }
}
