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
using Microsoft.WindowsAzure.Management.Network;
using Microsoft.WindowsAzure.Management.Network.Models;

namespace Network.Tests.ApplicationGateways.TestOperations
{
    public class CreateApplicationGateway : TestOperation
    {
        private readonly IApplicationGatewayOperations applicationGatewayClient;
        private readonly CreateApplicationGatewayParameters parameters;

        public ApplicationGatewayOperationResponse InvokeResponse { get; private set; }

        public CreateApplicationGateway(IApplicationGatewayOperations applicationGatewayClient, CreateApplicationGatewayParameters parameters)
        {
            this.applicationGatewayClient = applicationGatewayClient;
            this.parameters = parameters;
        }

        public void Invoke()
        {
            InvokeResponse = applicationGatewayClient.Create(parameters);
        }

        public void Undo()
        {
            applicationGatewayClient.Delete(parameters.Name);
        }
    }
}
