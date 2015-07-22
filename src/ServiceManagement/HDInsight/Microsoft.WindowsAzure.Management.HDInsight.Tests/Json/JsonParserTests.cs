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
namespace Microsoft.WindowsAzure.Management.HDInsight.Tests.Json
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Hadoop.Client;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.Json;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities;

    [TestClass]
    public class SyncClientScenarioTests : IntegrationTestBase
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

        private const int AzureTestTimeout = 35 * 60 * 1000;

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Defect")]
        public void JsonParserFailsToRecoverFromEscapeSequences()
        {
            string createTableJsonResponse =
            "{\"status\": \" abc\\t abc\\r abc\\n abc\\b abc\\f abc\\\\ abc\\f abc\\u0041 \", \"number\" : 2 }";
            JsonItem job;
            using (var jsonParser = new JsonParser(createTableJsonResponse))
            {
                job = jsonParser.ParseNext();
                if (job.IsError)
                {
                    JsonParseError error = (JsonParseError)job;
                    Assert.Fail(error.ToString());
                }
            }
            string statusString;
            Assert.IsTrue(job.GetProperty("status").TryGetValue(out statusString), "unable to retrieve the status string");
            Assert.AreEqual(" abc\t abc\r abc\n abc\b abc\f abc\\ abc\f abcA ", statusString);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Defect")]
        public void JsonParserFailsToParseEmptyObject()
        {
            string createTableJsonResponse =
            "{\"status\": \" abc\\t abc\\r abc\\n abc\\b abc\\f abc\\\\ abc\\f abc\\u0041 \", \"number\" : 2 }";
            JsonItem job;
            using (var jsonParser = new JsonParser(createTableJsonResponse))
            {
                job = jsonParser.ParseNext();
                if (job.IsError)
                {
                    JsonParseError error = (JsonParseError)job;
                    Assert.Fail(error.ToString());
                }
            }
            string statusString;
            Assert.IsTrue(job.GetProperty("status").TryGetValue(out statusString), "unable to retrieve the status string");
            Assert.AreEqual(" abc\t abc\r abc\n abc\b abc\f abc\\ abc\f abcA ", statusString);
        }

        [TestMethod]
        [TestCategory("CheckIn")]
        [TestCategory("Defect")]
        public void JsonParserFailsToParseDoubleDoubleQuotes()
        {
            string createTableJsonResponse = GetReportTextContent();
            JsonItem job;
            using (var jsonParser = new JsonParser(createTableJsonResponse))
            {
                job = jsonParser.ParseNext();
                if (job.IsError)
                {
                    JsonParseError error = (JsonParseError)job;
                    Assert.Fail(error.ToString());
                }
            }
            string queryText;
            Assert.IsTrue(job.GetProperty("execute").TryGetValue(out queryText), "unable to retrieve the query text string");
            Assert.AreEqual("\"select * from hivesampletable limit10\"", queryText);
        }

        private static string GetReportTextContent()
        {
            var resourceStream =
                typeof(SyncClientScenarioTests).Assembly.GetManifestResourceStream(
                    "Microsoft.WindowsAzure.Management.HDInsight.Tests.Json.1599940_repro.txt");

            var streamReader = new StreamReader(resourceStream);
            return streamReader.ReadToEnd();
        }
    }
}
