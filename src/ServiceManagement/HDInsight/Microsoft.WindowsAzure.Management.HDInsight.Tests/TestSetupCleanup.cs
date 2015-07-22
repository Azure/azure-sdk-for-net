﻿// Copyright (c) Microsoft Corporation
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
namespace Microsoft.WindowsAzure.Management.HDInsight.Tests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Hadoop.Client;
    using Microsoft.Hadoop.Client.HadoopJobSubmissionPocoClient;
    using Microsoft.Hadoop.Client.HadoopJobSubmissionPocoClient.RemoteHadoop;
    using Microsoft.Hadoop.Client.Storage;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.Configuration;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Asv;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.AzureManagementClient;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.RestClient;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Logging;
    using Microsoft.WindowsAzure.Management.HDInsight.Logging;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;
    using Microsoft.WindowsAzure.Management.HDInsight.JobSubmission.PocoClient;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities.RestSimulator;
    using Microsoft.WindowsAzure.Management.HDInsight.Tests.RestSimulator;

    [TestClass]
    public static class TestSetupCleanup
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            IntegrationTestBase.TestRunSetup();
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            IntegrationTestBase.TestRunCleanup();
        }
    }
}
