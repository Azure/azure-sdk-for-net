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
namespace Microsoft.WindowsAzure.Management.HDInsight.TestUtilities.RestSimulator
{
    using System.Collections.Generic;
    using Microsoft.Hadoop.Client;
    using Microsoft.Hadoop.Client.Storage;

    internal class StorageAccountSimulatorFactory : IWabStorageAbstractionFactory
    {
        private IDictionary<string, WabStorageAbstractionSimulator> simulators;

        public StorageAccountSimulatorFactory()
        {
            this.simulators = new Dictionary<string, WabStorageAbstractionSimulator>();
        }

        private static StorageAccountSimulatorFactory instance = new StorageAccountSimulatorFactory();
        public static StorageAccountSimulatorFactory Instance 
        {
            get { return instance; }
        }

        public IStorageAbstraction Create(WindowsAzureStorageAccountCredentials credentials)
        {
            WabStorageAbstractionSimulator simulator;
            if (!this.simulators.TryGetValue(credentials.Name, out simulator))
            {
                simulator = new WabStorageAbstractionSimulator(credentials);
                this.simulators.Add(credentials.Name, simulator);
            }
            return simulator;
        }
    }
}
