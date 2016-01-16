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

namespace Network.Tests
{
    using System;
    using System.Threading;
    using ApplicationGateways.TestOperations;
    using Microsoft.WindowsAzure.Management.Network;
    using Microsoft.WindowsAzure.Management.Network.Models;

    public class ApplicationGatewayTestClient
    {
        private readonly NetworkTestClient testClient;
        private readonly IApplicationGatewayOperations applicationGatewayClient;

        public ApplicationGatewayTestClient(NetworkTestClient testClient, IApplicationGatewayOperations applicationGatewayClient)
        {
            this.testClient = testClient;
            this.applicationGatewayClient = applicationGatewayClient;
        }

        public void EnsureNoApplicationGatewayExists()
        {

        }

        public ApplicationGatewayGetResponse GetApplicationGateway(string gatewayName)
        {
            return applicationGatewayClient.Get(gatewayName);
        }

        public ApplicationGatewayListResponse GetApplicationGateway()
        {
            return applicationGatewayClient.List();
        }
        public ApplicationGatewayOperationResponse CreateApplicationGateway(CreateApplicationGatewayParameters parameters)
        {
            CreateApplicationGateway operation = new CreateApplicationGateway(applicationGatewayClient, parameters);

            testClient.InvokeTestOperation(operation);

            return operation.InvokeResponse;
        }

        public ApplicationGatewayOperationResponse DeleteApplicationGateway(string gatewayName)
        {
            DeleteApplicationGateway operation = new DeleteApplicationGateway(applicationGatewayClient, gatewayName);

            testClient.InvokeTestOperation(operation);

            return operation.InvokeResponse;
        }

        public ApplicationGatewayOperationResponse SetConfigApplicationGateway(string gatewayName, ApplicationGatewaySetConfiguration config)
        {
            SetConfigApplicationGateway operation = new SetConfigApplicationGateway(applicationGatewayClient, gatewayName, config);

            testClient.InvokeTestOperation(operation);

            return operation.InvokeResponse;
        }

        public ApplicationGatewayGetConfiguration GetConfigApplicationGateway(string gatewayName)
        {
            return applicationGatewayClient.GetConfig(gatewayName);
        }
        public ApplicationGatewayOperationResponse StartApplicationGateway(string gatewayName)
        {
            StartApplicationGateway operation = new StartApplicationGateway(applicationGatewayClient, gatewayName);

            testClient.InvokeTestOperation(operation);

            return operation.InvokeResponse;
        }
    }
}
