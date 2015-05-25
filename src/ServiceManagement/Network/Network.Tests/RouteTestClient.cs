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

using Hyak.Common;
using Microsoft.Azure;

namespace Network.Tests
{
    using System;
    using Microsoft.WindowsAzure.Management.Network;
    using Microsoft.WindowsAzure.Management.Network.Models;
    using Routes.TestOperations;

    public class RouteTestClient
    {
        private readonly NetworkTestClient testClient;
        private readonly IRouteOperations routeOperations;

        public RouteTestClient(NetworkTestClient testClient, IRouteOperations routeOperations)
        {
            if (testClient == null)
            {
                throw new ArgumentNullException("testClient");
            }
            if (routeOperations == null)
            {
                throw new ArgumentNullException("routeOperations");
            }

            this.testClient = testClient;
            this.routeOperations = routeOperations;
        }

        public void EnsureNoRouteTablesExist()
        {
            ListRouteTablesResponse listResponse = ListRouteTables();
            if (listResponse.RouteTables != null)
            {
                foreach (RouteTable table in listResponse.RouteTables)
                {
                    DeleteRouteTable(table.Name);
                }
            }
        }

        public void EnsureRouteTableIsOnlyRouteTableInSubscription(string routeTableName)
        {
            ListRouteTablesResponse listResponse = ListRouteTables();

            bool tableExists = false;
            if (listResponse.RouteTables != null)
            {
                foreach (RouteTable table in listResponse.RouteTables)
                {
                    if (string.Equals(routeTableName, table.Name, StringComparison.InvariantCultureIgnoreCase))
                    {
                        tableExists = true;
                    }
                    else
                    {
                        DeleteRouteTable(table.Name);
                    }
                }
            }

            if (tableExists == false)
            {
                CreateRouteTable(new CreateRouteTableParameters()
                {
                    Name = routeTableName,
                    Label = "MockLabel",
                    Location = NetworkTestConstants.WideVNetLocation,
                });
            }
        }

        public void EnsureRouteTableExists(string routeTableName)
        {
            if (string.IsNullOrEmpty(routeTableName))
            {
                throw new ArgumentException("routeTableName cannot be null or empty.", "routeTableName");
            }

            RouteTable routeTable = GetRouteTableSafe(routeOperations, routeTableName);
            if (routeTable == null)
            {
                CreateRouteTable(new CreateRouteTableParameters()
                {
                    Name = routeTableName,
                    Label = "MockLabel",
                    Location = NetworkTestConstants.WideVNetLocation,
                });
            }
        }

        public void EnsureRouteTableDoesntExist(string routeTableName)
        {
            if (string.IsNullOrEmpty(routeTableName))
            {
                throw new ArgumentException("routeTableName cannot be null or empty.", "routeTableName");
            }

            RouteTable routeTable = GetRouteTableSafe(routeOperations, routeTableName);
            if (routeTable != null)
            {
                DeleteRouteTable(routeTableName);
            }
        }

        public void EnsureRouteTableIsEmpty(string routeTableName)
        {
            if (string.IsNullOrEmpty(routeTableName))
            {
                throw new ArgumentException("routeTableName cannot be null or empty.", "routeTableName");
            }

            EnsureRouteTableExists(routeTableName);

            RouteTable routeTable = GetRouteTableSafe(routeOperations, routeTableName);

            if (routeTable != null && routeTable.RouteList != null)
            {
                foreach (Route route in routeTable.RouteList)
                {
                    DeleteRoute(routeTable.Name, route.Name);
                }
            }
        }

        public void EnsureRouteIsOnlyRouteInRouteTable(string routeTableName, string routeName)
        {
            if (string.IsNullOrEmpty(routeTableName))
            {
                throw new ArgumentException("routeTableName cannot be null or empty.", "routeTableName");
            }
            if (string.IsNullOrEmpty(routeName))
            {
                throw new ArgumentException("routeName cannot be null or empty.", "routeName");
            }

            EnsureRouteTableExists(routeTableName);

            RouteTable routeTable = GetRouteTableSafe(routeOperations, routeTableName);

            bool routeExists = false;
            if (routeTable != null && routeTable.RouteList != null)
            {
                foreach (Route route in routeTable.RouteList)
                {
                    if (string.Equals(route.Name, routeName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        routeExists = true;
                        break;
                    }
                    else
                    {
                        DeleteRoute(routeTable.Name, route.Name);
                    }
                }
            }

            if (routeExists == false)
            {
                SetRouteParameters parameters = new SetRouteParameters()
                {
                    Name = routeName,
                    AddressPrefix = "0.0.0.0/0",
                    NextHop = new NextHop()
                    {
                        Type = "VPNGateway",
                    },
                };
                SetRoute(routeTableName, routeName, parameters);
            }
        }

        public void EnsureRouteExists(string routeTableName, string routeName)
        {
            if (string.IsNullOrEmpty(routeTableName))
            {
                throw new ArgumentException("routeTableName cannot be null or empty.", "routeTableName");
            }
            if (string.IsNullOrEmpty(routeName))
            {
                throw new ArgumentException("routeName cannot be null or empty.", "routeName");
            }

            EnsureRouteTableExists(routeTableName);

            RouteTable routeTable = GetRouteTableSafe(routeOperations, routeTableName);

            bool routeExists = false;
            if (routeTable != null && routeTable.RouteList != null)
            {
                foreach (Route route in routeTable.RouteList)
                {
                    if (string.Equals(route.Name, routeName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        routeExists = true;
                        break;
                    }
                }
            }

            if (routeExists == false)
            {
                SetRouteParameters parameters = new SetRouteParameters()
                {
                    Name = routeName,
                    AddressPrefix = "0.0.0.0/0",
                    NextHop = new NextHop()
                    {
                        Type = "VPNGateway",
                    },
                };
                SetRoute(routeTableName, routeName, parameters);
            }
        }

        public void EnsureRouteDoesntExist(string routeTableName, string routeName)
        {
            if (string.IsNullOrEmpty(routeTableName))
            {
                throw new ArgumentException("routeTableName cannot be null or empty.", "routeTableName");
            }
            if (string.IsNullOrEmpty(routeName))
            {
                throw new ArgumentException("routeName cannot be null or empty.", "routeName");
            }

            RouteTable routeTable = GetRouteTableSafe(routeOperations, routeTableName);

            if (routeTable != null && routeTable.RouteList != null)
            {
                foreach (Route route in routeTable.RouteList)
                {
                    if (string.Equals(route.Name, routeName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        DeleteRoute(routeTableName, routeName);
                        break;
                    }
                }
            }
        }

        public GetRouteTableResponse GetRouteTable(string routeTableName)
        {
            return routeOperations.GetRouteTable(routeTableName);
        }
        public GetRouteTableResponse GetRouteTableWithDetails(string routeTableName, string detailLevel)
        {
            return routeOperations.GetRouteTableWithDetails(routeTableName, detailLevel);
        }

        public AzureOperationResponse CreateRouteTable(CreateRouteTableParameters parameters)
        {
            CreateRouteTable operation = new CreateRouteTable(routeOperations, parameters);

            testClient.InvokeTestOperation(operation);

            return operation.InvokeResponse;
        }

        public AzureOperationResponse DeleteRouteTable(string routeTableName)
        {
            DeleteRouteTable operation = new DeleteRouteTable(routeOperations, routeTableName);

            testClient.InvokeTestOperation(operation);

            return operation.InvokeResponse;
        }

        public ListRouteTablesResponse ListRouteTables()
        {
            return routeOperations.ListRouteTables();
        }

        public AzureOperationResponse SetRoute(string routeTableName, string routeName, SetRouteParameters parameters)
        {
            SetRoute operation = new SetRoute(routeOperations, routeTableName, routeName, parameters);

            testClient.InvokeTestOperation(operation);

            return operation.InvokeResponse;
        }

        public AzureOperationResponse DeleteRoute(string routeTableName, string routeName)
        {
            DeleteRoute operation = new DeleteRoute(routeOperations, routeTableName, routeName);

            testClient.InvokeTestOperation(operation);

            return operation.InvokeResponse;
        }

        public AzureOperationResponse AddRouteTableToSubnet(string vnetName, string subnetName, AddRouteTableToSubnetParameters parameters)
        {
            AddRouteTableToSubnet operation = new AddRouteTableToSubnet(routeOperations, vnetName, subnetName, parameters);

            testClient.InvokeTestOperation(operation);

            return operation.InvokeResponse;
        }

        public AzureOperationResponse RemoveRouteTableFromSubnet(string vnetName, string subnetName)
        {
            RemoveRouteTableFromSubnet operation = new RemoveRouteTableFromSubnet(routeOperations, vnetName, subnetName);

            testClient.InvokeTestOperation(operation);

            return operation.InvokeResponse;
        }

        public GetRouteTableForSubnetResponse GetRouteTableForSubnet(string vnetName, string subnetName)
        {
            return routeOperations.GetRouteTableForSubnet(vnetName, subnetName);
        }

        public static RouteTable GetRouteTableSafe(IRouteOperations routeOperations, string routeTableName)
        {
            RouteTable retval = null;

            try
            {
                retval = routeOperations.GetRouteTableWithDetails(routeTableName, "full").RouteTable;
            }
            catch (Hyak.Common.CloudException e)
            {
                if (e.Error.Code != "ResourceNotFound")
                {
                    throw;
                }
            }

            return retval;
        }

        public static string GetRouteTableAssignedToSubnet(IRouteOperations routeOperations, string vnetName, string subnetName)
        {
            string routeTableName = null;

            try
            {
                routeTableName = routeOperations.GetRouteTableForSubnet(vnetName, subnetName).RouteTableName;
            }
            catch (Hyak.Common.CloudException e)
            {
                if (e.Error.Code != "ResourceNotFound")
                {
                    throw;
                }
            }

            return routeTableName;
        }
    }
}
