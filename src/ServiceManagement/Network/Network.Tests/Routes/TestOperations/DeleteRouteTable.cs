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

    public class DeleteRouteTable : TestOperation
    {
        private readonly IRouteOperations routeOperations;
        private readonly string routeTableName;

        private readonly RouteTable oldRouteTable;

        public AzureOperationResponse InvokeResponse;

        public DeleteRouteTable(IRouteOperations routeOperations, string routeTableName)
        {
            this.routeOperations = routeOperations;
            this.routeTableName = routeTableName;

            if (string.IsNullOrEmpty(routeTableName))
            {
                oldRouteTable = null;
            }
            else
            {
                oldRouteTable = RouteTestClient.GetRouteTableSafe(routeOperations, routeTableName);
            }
        }
        public void Invoke()
        {
            InvokeResponse = routeOperations.DeleteRouteTable(routeTableName);
        }

        public void Undo()
        {
            if (oldRouteTable != null)
            {
                CreateRouteTableParameters createParameters = new CreateRouteTableParameters()
                {
                    Name = oldRouteTable.Name,
                    Label = oldRouteTable.Label,
                    Location = oldRouteTable.Location,
                };
                routeOperations.CreateRouteTable(createParameters);

                if (oldRouteTable.RouteList != null)
                {
                    foreach (Route route in oldRouteTable.RouteList)
                    {
                        SetRouteParameters setParameters = new SetRouteParameters()
                        {
                            Name = route.Name,
                            AddressPrefix = route.AddressPrefix,
                            NextHop = route.NextHop,
                        };
                        routeOperations.SetRoute(routeTableName, route.Name, setParameters);
                    }
                }
            }
        }
    }
}
