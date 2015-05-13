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

namespace Network.Tests.Routes.TestOperations
{
    using Microsoft.WindowsAzure.Management.Network;
    using Microsoft.WindowsAzure.Management.Network.Models;

    public class RemoveRouteTableFromSubnet : TestOperation
    {
        private readonly IRouteOperations routeOperations;
        private readonly string vnetName;
        private readonly string subnetName;

        private readonly string oldAssignedRouteTableName;

        public AzureOperationResponse InvokeResponse;

        public RemoveRouteTableFromSubnet(IRouteOperations routeOperations, string vnetName, string subnetName)
        {
            this.routeOperations = routeOperations;
            this.vnetName = vnetName;
            this.subnetName = subnetName;

            oldAssignedRouteTableName = RouteTestClient.GetRouteTableAssignedToSubnet(routeOperations, vnetName, subnetName);
        }
        public void Invoke()
        {
            InvokeResponse = routeOperations.RemoveRouteTableFromSubnet(vnetName, subnetName);
        }

        public void Undo()
        {
            if (oldAssignedRouteTableName != null)
            {
                routeOperations.AddRouteTableToSubnet(vnetName, subnetName, new AddRouteTableToSubnetParameters()
                {
                    RouteTableName = oldAssignedRouteTableName,
                });
            }
        }
    }
}
