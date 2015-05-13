//
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

using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Microsoft.WindowsAzure.Management.ExpressRoute.Models;

namespace Microsoft.WindowsAzure.Management.ExpressRoute.Testing
{
    using System.Collections;
    using Azure.Test;
    using Hyak.Common;

    public class DedicatedCircuitUndoHandler :
        ComplexTypedOperationUndoHandler<IDedicatedCircuitOperations, ExpressRouteManagementClient>
    {
        protected override bool DoLookup(IServiceOperations<ExpressRouteManagementClient> client, string method,
                                         IDictionary<string, object> parameters, out Action undoFunction)
        {
            undoFunction = null;
            switch (method)
            {
                case "BeginNewAsync":
                    return TryHandleBeginNewAsync(client, parameters, out undoFunction);
                default:
                    TraceUndoNotFound(this, method, parameters);
                    return false;
            }
        }

        private bool TryHandleBeginNewAsync(IServiceOperations<ExpressRouteManagementClient> client,
                                            IDictionary<string, object> parameters, out Action undoFunction)
        {
            undoFunction = null;
            ExpressRouteManagementClient expressRouteClient = GetClientFromOperations(client);

            DedicatedCircuitNewParameters newParameters;

            if (TryAssignParameter<DedicatedCircuitNewParameters>("parameters", parameters, out newParameters) &&
                newParameters != null && !string.IsNullOrEmpty(newParameters.CircuitName))
            {
                try
                {
                    undoFunction = () => expressRouteClient.DedicatedCircuits.Remove(new List<AzureDedicatedCircuit>(
                            expressRouteClient.DedicatedCircuits.List().DedicatedCircuits).Find(
                                circuit => circuit.CircuitName.Equals(newParameters.CircuitName)).ServiceKey);
                    return true;
                }
                catch
                {
                }
            }

            TraceParameterError(this, "BeginNewAsync", parameters);
            return false;
        }

        protected override ExpressRouteManagementClient GetClientFromOperations(
            IServiceOperations<ExpressRouteManagementClient> operations)
        {
            return new ExpressRouteManagementClient(operations.Client.Credentials, operations.Client.BaseUri);
        }
    }

    public class BorderGatewayProtocolPeeringUndoHandler :
        ComplexTypedOperationUndoHandler<IBorderGatewayProtocolPeeringOperations, ExpressRouteManagementClient>
    {
        protected override bool DoLookup(IServiceOperations<ExpressRouteManagementClient> client, string method,
                                         IDictionary<string, object> parameters, out Action undoFunction)
        {
            undoFunction = null;
            switch (method)
            {
                case "BeginNewAsync":
                    return TryHandleBeginNewAsync(client, parameters, out undoFunction);
                default:
                    TraceUndoNotFound(this, method, parameters);
                    return false;
            }
        }

        private bool TryHandleBeginNewAsync(IServiceOperations<ExpressRouteManagementClient> client,
                                            IDictionary<string, object> parameters, out Action undoFunction)
        {
            undoFunction = null;
            string serviceKey;
            BgpPeeringAccessType accessType;

            if (TryAssignParameter<string>("serviceKey", parameters, out serviceKey) &&
                TryAssignParameter<BgpPeeringAccessType>("accessType", parameters, out accessType) &&
                !string.IsNullOrEmpty(serviceKey))
            {
                undoFunction = () =>
                    {
                        using (ExpressRouteManagementClient expressRouteClient = GetClientFromOperations(client))
                        {
                            expressRouteClient.BorderGatewayProtocolPeerings.Remove(serviceKey, accessType);
                        }
                    };
                return true;
            }
            
            TraceParameterError(this, "BeginNewAsync", parameters);
            return false;
        }

        protected override ExpressRouteManagementClient GetClientFromOperations(
            IServiceOperations<ExpressRouteManagementClient> operations)
        {
            return new ExpressRouteManagementClient(operations.Client.Credentials, operations.Client.BaseUri);
        }
    }

    public class DedicatedCircuitLinkUndoHandler :
        ComplexTypedOperationUndoHandler<IDedicatedCircuitLinkOperations, ExpressRouteManagementClient>
    {
        protected override bool DoLookup(IServiceOperations<ExpressRouteManagementClient> client, string method,
                                         IDictionary<string, object> parameters, out Action undoFunction)
        {
            undoFunction = null;
            switch (method)
            {
                case "BeginNewAsync":
                    return TryHandleBeginNewAsync(client, parameters, out undoFunction);
                default:
                    TraceUndoNotFound(this, method, parameters);
                    return false;
            }
        }

        private bool TryHandleBeginNewAsync(IServiceOperations<ExpressRouteManagementClient> client,
                                            IDictionary<string, object> parameters, out Action undoFunction)
        {
            undoFunction = null;
            string serviceKey;
            string vnetName;

            if (TryAssignParameter<string>("serviceKey", parameters, out serviceKey) &&
                TryAssignParameter<string>("vnetName", parameters, out vnetName) && !string.IsNullOrEmpty(vnetName) &&
                !string.IsNullOrEmpty(serviceKey))
            {
                undoFunction = () =>
                {
                    using (ExpressRouteManagementClient expressRouteClient = GetClientFromOperations(client))
                    {
                        expressRouteClient.DedicatedCircuitLinks.Remove(serviceKey, vnetName);
                    }
                };
                return true;
            }

            TraceParameterError(this, "BeginNewAsync", parameters);
            return false;
        }

        protected override ExpressRouteManagementClient GetClientFromOperations(
            IServiceOperations<ExpressRouteManagementClient> operations)
        {
            return new ExpressRouteManagementClient(operations.Client.Credentials, operations.Client.BaseUri);
        }
    }

    public class CrossConnectionUndoHandler :
        ComplexTypedOperationUndoHandler<ICrossConnectionOperations, ExpressRouteManagementClient>
    {
        protected override bool DoLookup(IServiceOperations<ExpressRouteManagementClient> client, string method,
                                         IDictionary<string, object> parameters, out Action undoFunction)
        {
            undoFunction = null;
            switch (method)
            {
                case "BeginNewAsync":
                    return TryHandleBeginNewAsync(client, parameters, out undoFunction);
                default:
                    TraceUndoNotFound(this, method, parameters);
                    return false;
            }
        }

        private bool TryHandleBeginNewAsync(IServiceOperations<ExpressRouteManagementClient> client,
                                            IDictionary<string, object> parameters, out Action undoFunction)
        {
            undoFunction = null;
            string serviceKey;
            CrossConnectionUpdateParameters updateParameters = new CrossConnectionUpdateParameters()
                {
                    Operation = UpdateCrossConnectionOperation.NotifyCrossConnectionNotProvisioned
                };

            if (TryAssignParameter<string>("serviceKey", parameters, out serviceKey) &&
                !string.IsNullOrEmpty(serviceKey))
            {
                undoFunction = () =>
                {
                    using (ExpressRouteManagementClient expressRouteClient = GetClientFromOperations(client))
                    {
                        expressRouteClient.CrossConnections.Update(serviceKey, updateParameters);
                    }
                };
                return true;
            }

            TraceParameterError(this, "BeginNewAsync", parameters);
            return false;
        }

        protected override ExpressRouteManagementClient GetClientFromOperations(
            IServiceOperations<ExpressRouteManagementClient> operations)
        {
            return new ExpressRouteManagementClient(operations.Client.Credentials, operations.Client.BaseUri);
        }
    }

    public class DedicatedCircuitLinkAuthorizationMicrosoftIdUndoHandler :
    ComplexTypedOperationUndoHandler<IDedicatedCircuitLinkAuthorizationMicrosoftIdOperations, ExpressRouteManagementClient>
    {
        protected override bool DoLookup(IServiceOperations<ExpressRouteManagementClient> client, string method,
                                         IDictionary<string, object> parameters, out Action undoFunction)
        {
            undoFunction = null;
            switch (method)
            {
                case "BeginNewAsync":
                    return TryHandleBeginNewAsync(client, parameters, out undoFunction);
                default:
                    TraceUndoNotFound(this, method, parameters);
                    return false;
            }
        }

        private bool TryHandleBeginNewAsync(IServiceOperations<ExpressRouteManagementClient> client,
                                            IDictionary<string, object> parameters, out Action undoFunction)
        {
            undoFunction = null;
            string serviceKey;
            string authId;
            DedicatedCircuitLinkAuthorizationMicrosoftIdNewParameters newParameters = null;

            if (TryAssignParameter<string>("serviceKey", parameters, out serviceKey) && TryAssignParameter<string>("authId", parameters, out authId) && TryAssignParameter<DedicatedCircuitLinkAuthorizationMicrosoftIdNewParameters>("parameters", parameters, out newParameters) && !string.IsNullOrEmpty(serviceKey) && !string.IsNullOrEmpty(authId) && newParameters != null)
            {
                undoFunction = () =>
                {
                    using (ExpressRouteManagementClient expressRouteClient = GetClientFromOperations(client))
                    {
                        expressRouteClient.DedicatedCircuitLinkAuthorizationMicrosoftIds.Remove(serviceKey, authId, (new DedicatedCircuitLinkAuthorizationMicrosoftIdRemoveParameters()
                            {
                                MicrosoftIds = newParameters.MicrosoftIds
                            }));
                    }
                };
                return true;
            }

            TraceParameterError(this, "BeginNewAsync", parameters);
            return false;
        }

        protected override ExpressRouteManagementClient GetClientFromOperations(
            IServiceOperations<ExpressRouteManagementClient> operations)
        {
            return new ExpressRouteManagementClient(operations.Client.Credentials, operations.Client.BaseUri);
        }
    }

    public class DedicatedCircuitLinkAuthorizationUndoHandler :
    ComplexTypedOperationUndoHandler<IDedicatedCircuitLinkAuthorizationOperations, ExpressRouteManagementClient>
    {
        protected override bool DoLookup(IServiceOperations<ExpressRouteManagementClient> client, string method,
                                         IDictionary<string, object> parameters, out Action undoFunction)
        {
            undoFunction = null;
            switch (method)
            {
                case "BeginNewAsync":
                    return TryHandleBeginNewAsync(client, parameters, out undoFunction);
                default:
                    TraceUndoNotFound(this, method, parameters);
                    return false;
            }
        }

        private bool TryHandleBeginNewAsync(IServiceOperations<ExpressRouteManagementClient> client,
                                            IDictionary<string, object> parameters, out Action undoFunction)
        {
            undoFunction = null;
            string serviceKey;
            DedicatedCircuitLinkAuthorizationNewParameters newParameters = null;

            if (TryAssignParameter<string>("serviceKey", parameters, out serviceKey) && TryAssignParameter<DedicatedCircuitLinkAuthorizationNewParameters>("parameters", parameters, out newParameters) && !string.IsNullOrEmpty(serviceKey) && newParameters != null)
            {
                ExpressRouteManagementClient expressRouteClient = GetClientFromOperations(client);

                undoFunction = () => expressRouteClient.DedicatedCircuitLinkAuthorizations.Remove(serviceKey, (new List<AzureDedicatedCircuitLinkAuthorization>(
                    expressRouteClient.DedicatedCircuitLinkAuthorizations.List(serviceKey)
                                      .DedicatedCircuitLinkAuthorizations)).Find(
                                          auth =>
                                          auth.MicrosoftIds.Equals(newParameters.MicrosoftIds) &&
                                          auth.Limit.Equals(newParameters.Limit)).LinkAuthorizationId);
                return true;
            }

            TraceParameterError(this, "BeginNewAsync", parameters);
            return false;
        }

        protected override ExpressRouteManagementClient GetClientFromOperations(
            IServiceOperations<ExpressRouteManagementClient> operations)
        {
            return new ExpressRouteManagementClient(operations.Client.Credentials, operations.Client.BaseUri);
        }
    }
}
    