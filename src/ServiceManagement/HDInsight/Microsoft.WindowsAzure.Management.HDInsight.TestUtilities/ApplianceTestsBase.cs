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
namespace Microsoft.WindowsAzure.Management.HDInsight.TestUtilities
{
    using System;
    using Microsoft.Hadoop.Client.HadoopStorageClientLayer;
    using Microsoft.Hadoop.Client.HadoopStoragePocoClient;
    using Microsoft.Hadoop.Client.HadoopStorageRestClient;
    using Microsoft.HadoopAppliance.Client;
    using Microsoft.HadoopAppliance.Client.HadoopStorageClientLayer;
    using Microsoft.HadoopAppliance.Client.HadoopStoragePocoClient;
    using Microsoft.HadoopAppliance.Client.HadoopStorageRestClient;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.RestClient;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Logging;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.ServiceLocation;
    using Microsoft.WindowsAzure.Management.HDInsight.Logging;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities.RestSimulator;

    public class ApplianceTestsBase : TestsBase
    {
        public ApplianceTestsBase()
        {
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        public static StorageClientBasicAuthCredential StorageCredentials { get; private set; }

        protected static string ClusterPrefix;

        public static void TestRunCleanup()
        {
        }

        public static void TestRunSetup()
        {
            // Sets the simulator
            var runManager = ServiceLocator.Instance.Locate<IServiceLocationSimulationManager>();
            ServiceLocator.Instance.Locate<ILogger>().AddWriter(new ConsoleLogWriter(Severity.None, Verbosity.Diagnostic));
            runManager.RegisterType<IHadoopStorageClientFactory, HadoopApplianceStorageClientFactory>();
            runManager.RegisterType<IHadoopStoragePocoClientFactory, HadoopApplianceStoragePocoClientFactory>();
            runManager.RegisterType<IHadoopStorageRestClientFactory, HadoopApplianceStorageRestSimulatorClientFactory>();
            runManager.RegisterType<IHadoopApplianceStoragePocoClientFactory, HadoopApplianceStoragePocoClientFactory>();
            runManager.RegisterType<IHadoopApplianceStorageRestClientFactory, HadoopApplianceStorageRestSimulatorClientFactory>();
        }
    }
}