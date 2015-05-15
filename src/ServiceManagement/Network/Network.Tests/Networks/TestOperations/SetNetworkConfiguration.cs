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

using Microsoft.Azure;

namespace Network.Tests.Networks.TestOperations
{
    using System;
    using System.IO;
    using System.Net;
    using Microsoft.WindowsAzure.Management.Network;
    using Microsoft.WindowsAzure.Management.Network.Models;

    public class SetNetworkConfiguration : TestOperation
    {
        private readonly NetworkManagementClient networkClient;
        private readonly NetworkSetConfigurationParameters parameters;
        private readonly string oldNetworkConfiguration;
        
        public OperationStatusResponse InvokeResponse { get; private set; }

        public SetNetworkConfiguration(NetworkManagementClient networkClient, NetworkSetConfigurationParameters parameters)
        {
            this.networkClient = networkClient;
            this.parameters = parameters;
            oldNetworkConfiguration = GetConfigurationSafe();
        }

        public void Invoke()
        {
            InvokeResponse = networkClient.Networks.SetConfiguration(parameters);
        }

        public void Undo()
        {
            string currentNetworkConfiguration = GetConfigurationSafe();
            if (oldNetworkConfiguration != currentNetworkConfiguration)
            {
                bool setConfigurationComplete = false;
                while (setConfigurationComplete == false)
                {
                    try
                    {
                        OperationStatusResponse setConfigurationResponse = networkClient.Networks.SetConfiguration(new NetworkSetConfigurationParameters()
                        {
                            Configuration = oldNetworkConfiguration,
                        });

                        if (setConfigurationResponse.HttpStatusCode == HttpStatusCode.OK)
                        {
                            setConfigurationComplete = true;
                        }
                    }
                    catch (Hyak.Common.CloudException e)
                    {
                        if (e.Error.Code != "BadRequest")
                        {
                            throw;
                        }
                    }
                }
            }
        }

        private string GetConfigurationSafe()
        {
            string configuration;
            try
            {
                configuration = networkClient.Networks.GetConfiguration().Configuration;
            }
            catch (Hyak.Common.CloudException e)
            {
                if (e.Error.Code == "ResourceNotFound")
                {
                    configuration = File.ReadAllText(@"TestData\DeleteNetworkConfiguration.xml");
                }
                else
                {
                    throw;
                }
            }
            return configuration;
        }
    }
}
