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
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.WindowsAzure.Management.HDInsight.Tests.ProcDetails
{
    using System.Collections.Generic;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities;
    using ProcDetailsTestApplication;

    [TestClass]
    public class SerializerTest : IntegrationTestBase
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
        public void ICanSerializeAndDeserializeProcDetailData()
        {
            Sections procData = new Sections();
            string[] args = new string[] { "a", "b", "c" };
            IDictionary<string, string> vars = new Dictionary<string, string>() { { "a", "1" }, { "b", "2" }, { "c", "3" } };
            ProcDetails procDetails = new ProcDetails(args);
            procData.Add(ProcDetails.CommandLineArguments, Entries.MakeEntries(args));
            procData.Add(ProcDetails.EnvironmentVariables, new Entries(vars));
            procData.Add(ProcDetails.CoreSiteSettings, new Entries(vars));
            procData.Add(ProcDetails.HiveSiteSettings, new Entries(vars));
            procData.Add(ProcDetails.MapRedSiteSettings, new Entries(vars));

            SectionsSerializer ser = new SectionsSerializer();
            var content = ser.Serialize(procData);
            Sections deserialized = ser.Deserialize(content);
            Help.DoNothing(deserialized);
            Help.DoNothing(procDetails);
        }
    }
}
