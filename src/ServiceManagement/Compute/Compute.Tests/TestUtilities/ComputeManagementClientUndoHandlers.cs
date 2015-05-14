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
using Hyak.Common;
using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Management.Compute.Models;

namespace Microsoft.WindowsAzure.Management.Compute.Testing
{
    /// <summary>
    /// Undo handler for Hosted Service Deployment Operations
    /// </summary>
    public class DeploymentUndoHandler : ComplexTypedOperationUndoHandler<IHostedServiceOperations, ComputeManagementClient>
    {
        /// <summary>
        /// Look up the undo operation for the given Deployment operation
        /// </summary>
        /// <param name="client">The IDeploymentOperations instance used for the operation</param>
        /// <param name="method">The name of the deployment method</param>
        /// <param name="parameters">The parameters passed to the operation</param>
        /// <param name="undoAction">The undo action for the given operation, if any</param>
        /// <returns>True if an undo operation is found, otherwise false</returns>
        protected override bool DoLookup(IServiceOperations<ComputeManagementClient> client, string method, IDictionary<string, object> parameters, out Action undoAction)
        {
            undoAction = null;
            switch (method)
            {
                case "BeginCreatingAsync":
                    return TryHandleBeginCreatingAsync(client, parameters, out undoAction);
                case "BeginSwappingAsync":
                    return TryHandleBeginSwappingAsync(client, parameters, out undoAction);
                default:
                    TraceUndoNotFound(this, method, parameters);
                    return false;
            }
        }

        private bool TryHandleBeginCreatingAsync(IServiceOperations<ComputeManagementClient> client, IDictionary<string, object> parameters, out Action undoAction)
        {
            undoAction = null;
            string serviceName;
            DeploymentCreateParameters createParams;
            if (TryAssignParameter<string>("serviceName", parameters, out serviceName) &&
                TryAssignParameter<DeploymentCreateParameters>("parameters", parameters, out createParams) &&
                !string.IsNullOrEmpty(serviceName) && createParams != null && !string.IsNullOrEmpty(createParams.Name))
            {
                undoAction = () =>
                    {
                        using (ComputeManagementClient serviceClient = GetClientFromOperations(client))
                        {
                            serviceClient.Deployments.DeleteByName(serviceName, createParams.Name, true);
                        }
                    };
                return true;
            }
            TraceParameterError(this, "BeginCreatingAsync", parameters);
            return false;
        }

        private bool TryHandleBeginSwappingAsync(IServiceOperations<ComputeManagementClient> client, IDictionary<string, object> parameters, out Action undoAction)
        {
            undoAction = null;
            string serviceName;
            DeploymentSwapParameters swapParams;
            if (TryAssignParameter<string>("serviceName", parameters, out serviceName) &&
                TryAssignParameter<DeploymentSwapParameters>("parameters", parameters, out swapParams) &&
                !string.IsNullOrEmpty(serviceName) && swapParams != null &&
                !string.IsNullOrEmpty(swapParams.ProductionDeployment) &&
                !string.IsNullOrEmpty(swapParams.SourceDeployment))
            {
                undoAction = () =>
                    {
                        using (ComputeManagementClient serviceClient = GetClientFromOperations(client))
                        {
                            serviceClient.Deployments.Swap(serviceName,
                                new DeploymentSwapParameters
                                {
                                    ProductionDeployment = swapParams.SourceDeployment,
                                    SourceDeployment = swapParams.ProductionDeployment
                                });
                        }
                    };

                return true;
            }

            TraceParameterError(this, "BeginSwappingAsync", parameters);
            return false;
        }

        protected override ComputeManagementClient GetClientFromOperations(IServiceOperations<ComputeManagementClient> operations)
        {
            return new ComputeManagementClient(operations.Client.Credentials, operations.Client.BaseUri);
        }
    }

    /// <summary>
    /// Undo handler for Hosted service operations
    /// </summary>
    public class HostedServiceUndoHandler : ComplexTypedOperationUndoHandler<IHostedServiceOperations, ComputeManagementClient>
    {
        /// <summary>
        /// Look up the undo operation for the given HostedService operation
        /// </summary>
        /// <param name="client">The IHostedServiceOperations instance used for the operation</param>
        /// <param name="method">The name of the hosted service method</param>
        /// <param name="parameters">The parameters passed to the operation</param>
        /// <param name="undoAction">The undo action for the given operation, if any</param>
        /// <returns>True if an undo operation is found, otherwise false</returns>
        protected override bool DoLookup(IServiceOperations<ComputeManagementClient> client, string method, IDictionary<string, object> parameters, out Action undoAction)
        {
            undoAction = null;
            switch (method)
            {
                case "CreateAsync":
                    return TryHandleCreateAsync(client, parameters, out undoAction);
                default:
                    TraceUndoNotFound(this, method, parameters);
                    return false;
            }
        }

        private bool TryHandleCreateAsync(IServiceOperations<ComputeManagementClient> client, IDictionary<string, object> parameters, out Action undoAction)
        {
            undoAction = null;
            HostedServiceCreateParameters createParameters;
            if (TryAssignParameter<HostedServiceCreateParameters>("parameters", parameters, out createParameters) &&
                createParameters != null && !string.IsNullOrEmpty(createParameters.ServiceName))
            {
                undoAction = () =>
                {
                    using (ComputeManagementClient serviceClient = GetClientFromOperations(client))
                    {
                        serviceClient.HostedServices.DeleteAll(createParameters.ServiceName);
                    }
                };

                return true;
            }

            TraceParameterError(this, "CreateAsync", parameters);
            return false;
        }

        protected override ComputeManagementClient GetClientFromOperations(IServiceOperations<ComputeManagementClient> operations)
        {
            return new ComputeManagementClient(operations.Client.Credentials, operations.Client.BaseUri);
        }
    }

    /// <summary>
    /// Undo handler for service certifcate operatiosn on hosted services
    /// </summary>
    public class ServiceCertificateUndoHandler : ComplexTypedOperationUndoHandler<IServiceCertificateOperations, ComputeManagementClient>
    {
        /// <summary>
        /// Look up the undo operation for the given Service Certificate operation
        /// </summary>
        /// <param name="client">The IServiceCertificateOperations instance used for the operation</param>
        /// <param name="method">The name of the certificate method</param>
        /// <param name="parameters">The parameters passed to the operation</param>
        /// <param name="undoAction">The undo action for the given operation, if any</param>
        /// <returns>True if an undo operation is found, otherwise false</returns>
        protected override bool DoLookup(IServiceOperations<ComputeManagementClient> client, string method, IDictionary<string, object> parameters, out Action undoAction)
        {
            undoAction = null;
            switch (method)
            {
                case "BeginCreatingAsync":
                    return TryHandleBeginCreatingAsync(client, parameters, out undoAction);
                default:
                    TraceUndoNotFound(this, method, parameters);
                    return false;
            }
        }

        private bool TryHandleBeginCreatingAsync(IServiceOperations<ComputeManagementClient> client, IDictionary<string, object> parameters, out Action undoAction)
        {
            undoAction = null;
            string serviceName;
            ServiceCertificateCreateParameters createParams;
            if (TryAssignParameter<string>("serviceName", parameters, out serviceName) &&
                TryAssignParameter<ServiceCertificateCreateParameters>("parameters", parameters, out createParams) &&
                !string.IsNullOrEmpty(serviceName) && createParams != null && createParams.Data != null)
            {
                X509Certificate2 certificate = new X509Certificate2(createParams.Data);
                undoAction = () =>
                    {
                        using (ComputeManagementClient serviceClient = GetClientFromOperations(client))
                        {
                            serviceClient.ServiceCertificates.Delete(
                                new ServiceCertificateDeleteParameters
                                {
                                    ServiceName = serviceName,
                                    Thumbprint = certificate.Thumbprint,
                                    ThumbprintAlgorithm = certificate.SignatureAlgorithm.FriendlyName
                                });
                        }
                    };

                return true;
            }

            TraceParameterError(this, "BeginCreatingAsync", parameters);
            return false;
        }

        protected override ComputeManagementClient GetClientFromOperations(IServiceOperations<ComputeManagementClient> operations)
        {
            return new ComputeManagementClient(operations.Client.Credentials, operations.Client.BaseUri);
        }
    }

    /// <summary>
    /// Undo handler for virtual machine disk operations
    /// </summary>
    public class VirtualMachineDiskUndoHandler : ComplexTypedOperationUndoHandler<IVirtualMachineDiskOperations, ComputeManagementClient>
    {
        /// <summary>
        /// Look up the undo operation for the given VM Disk operation
        /// </summary>
        /// <param name="client">The IVirtualMachineDiskOperations instance used for the operation</param>
        /// <param name="method">The name of the VM Disk method</param>
        /// <param name="parameters">The parameters passed to the operation</param>
        /// <param name="undoAction">The undo action for the given operation, if any</param>
        /// <returns>True if an undo operation is found, otherwise false</returns>
        protected override bool DoLookup(IServiceOperations<ComputeManagementClient> client, string method, IDictionary<string, object> parameters, out Action undoAction)
        {
            undoAction = null;
            switch (method)
            {
                case "CreateDataDiskAsync":
                    return TryHandleCreateDataDiskAsync(client, parameters, out undoAction);
                case "CreateDiskAsync":
                    return TryHandleCreateDiskAsync(client, parameters, out undoAction);
                default:
                    TraceUndoNotFound(this, method, parameters);
                    return false;
            }
        }

        private bool TryHandleCreateDataDiskAsync(IServiceOperations<ComputeManagementClient> client, IDictionary<string, object> parameters, out Action undoAction)
        {
            undoAction = null;
            string serviceName;
            string deploymentName;
            string roleName;
            VirtualMachineDataDiskCreateParameters createParameters;
            if (TryAssignParameter<string>("serviceName", parameters, out serviceName) &&
                TryAssignParameter<string>("deploymentName", parameters, out deploymentName) &&
                TryAssignParameter<string>("roleName", parameters, out roleName) &&
                TryAssignParameter<VirtualMachineDataDiskCreateParameters>("parameters", parameters, out createParameters) &&
                !string.IsNullOrEmpty(serviceName) && !string.IsNullOrEmpty(deploymentName) && !string.IsNullOrEmpty(roleName) &&
                createParameters != null && createParameters.LogicalUnitNumber.HasValue)
            {
                undoAction = () =>
                    {
                        using (ComputeManagementClient serviceClient = GetClientFromOperations(client))
                        {
                            serviceClient.VirtualMachineDisks.DeleteDataDisk(serviceName, deploymentName, roleName,
                                createParameters.LogicalUnitNumber.Value, true);
                        }
                    };

                return true;
            }

            TraceParameterError(this, "CreateDataDiskAsync", parameters);
            return false;
        }

        private bool TryHandleCreateDiskAsync(IServiceOperations<ComputeManagementClient> client, IDictionary<string, object> parameters, out Action undoAction)
        {
            undoAction = null;
            VirtualMachineDiskCreateParameters createParameters;
            if (TryAssignParameter<VirtualMachineDiskCreateParameters>("parameters", parameters, out createParameters) &&
                createParameters != null && !string.IsNullOrEmpty(createParameters.Name))
            {
                undoAction = () =>
                    {
                        using (ComputeManagementClient serviceClient = GetClientFromOperations(client))
                        {
                            serviceClient.VirtualMachineDisks.DeleteDisk(createParameters.Name, true);
                        }
                    };

                return true;
            }

            TraceParameterError(this, "CreateDiskAsync", parameters);
            return false;
        }

        protected override ComputeManagementClient GetClientFromOperations(IServiceOperations<ComputeManagementClient> operations)
        {
            return new ComputeManagementClient(operations.Client.Credentials, operations.Client.BaseUri);
        }
    }

    /// <summary>
    /// Undo handler for virtual machine image operations
    /// </summary>
    public class VirtualMachineImageUndoHandler : ComplexTypedOperationUndoHandler<IVirtualMachineOSImageOperations, ComputeManagementClient>
    {
        /// <summary>
        /// Look up the undo operation for the given VM Image operation
        /// </summary>
        /// <param name="client">The IVirtualMachineImageOperations instance used for the operation</param>
        /// <param name="method">The name of the VM Image method</param>
        /// <param name="parameters">The parameters passed to the operation</param>
        /// <param name="undoAction">The undo action for the given operation, if any</param>
        /// <returns>True if an undo operation is found, otherwise false</returns>
        protected override bool DoLookup(IServiceOperations<ComputeManagementClient> client, string method, IDictionary<string, object> parameters, out Action undoAction)
        {
            undoAction = null;
            switch (method)
            {
                case "CreateAsync":
                    return TryHandleCreateImageAsync(client, parameters, out undoAction);
                default:
                    TraceUndoNotFound(this, method, parameters);
                    return false;
            }
        }

        private bool TryHandleCreateImageAsync(IServiceOperations<ComputeManagementClient> client, IDictionary<string, object> parameters, out Action undoAction)
        {
            undoAction = null;
            VirtualMachineOSImageCreateParameters createParameters;
            if (TryAssignParameter<VirtualMachineOSImageCreateParameters>("parameters", parameters, out createParameters) &&
                createParameters != null && !string.IsNullOrEmpty(createParameters.Name))
            {
                undoAction = () =>
                    {
                        using (ComputeManagementClient serviceClient = GetClientFromOperations(client))
                        {
                            serviceClient.VirtualMachineOSImages.Delete(createParameters.Name, true);
                        }
                    };

                return true;
            }

            TraceParameterError(this, "CreateAsync", parameters);
            return false;
        }

        protected override ComputeManagementClient GetClientFromOperations(IServiceOperations<ComputeManagementClient> operations)
        {
            return new ComputeManagementClient(operations.Client.Credentials, operations.Client.BaseUri);
        }
    }

    /// <summary>
    /// Undo Handler for ComputeManagementClient VirtualMachine operations.  This is intended to be generated code
    /// </summary>
    public class VirtualMachineUndoHandler : ComplexTypedOperationUndoHandler<IVirtualMachineOperations, ComputeManagementClient>
    {
        /// <summary>
        /// Look up the undo operation for the given VirtualMachine operation
        /// </summary>
        /// <param name="client">The IVirtualMachineOperations instance used for the operation</param>
        /// <param name="method">The name of the virtual machine method</param>
        /// <param name="parameters">The parameters passed to the operation</param>
        /// <param name="undoFunction">The undo action for the given operation, if any</param>
        /// <returns>True if an undo operation is found, otherwise false</returns>
        protected override bool DoLookup(IServiceOperations<ComputeManagementClient> client, string method, IDictionary<string, object> parameters, out Action undoFunction)
        {
            undoFunction = null;
            switch (method)
            {
                case "BeginCreatingAsync":
                    return TryHandleBeginCreatingAsync(client, parameters, out undoFunction);
                case "BeginCreatingDeploymentAsync":
                    return TryHandleBeginCreatingDeploymentAsync(client, parameters, out undoFunction);
                default:
                    TraceUndoNotFound(this, method, parameters);
                    return false;
            }
        }

        protected override ComputeManagementClient GetClientFromOperations(IServiceOperations<ComputeManagementClient> operations)
        {
            return new ComputeManagementClient(operations.Client.Credentials, operations.Client.BaseUri);
        }

        private bool TryHandleBeginCreatingAsync(IServiceOperations<ComputeManagementClient> client, IDictionary<string, object> parameters, out Action undoFunction)
        {
            undoFunction = null;
            VirtualMachineCreateParameters createParameters = parameters["parameters"] as VirtualMachineCreateParameters;
            string serviceName;
            string deploymentName;
            if (TryAssignParameter<string>("serviceName", parameters, out serviceName) &&
                TryAssignParameter<string>("deploymentName", parameters, out deploymentName) &&
                TryAssignParameter<VirtualMachineCreateParameters>("parameters", parameters, out createParameters) &&
                createParameters != null && !string.IsNullOrEmpty(serviceName) && !string.IsNullOrEmpty(deploymentName) &&
                !string.IsNullOrEmpty(createParameters.RoleName))
            {
                undoFunction = () =>
                {
                    using (ComputeManagementClient serviceClient = GetClientFromOperations(client))
                    {
                        serviceClient.VirtualMachines.Delete(serviceName, deploymentName, createParameters.RoleName, true);
                    }
                };

                return true;
            }

            TraceParameterError(this, "BeginCreatingAsync", parameters);
            return false;
        }

        private bool TryHandleBeginCreatingDeploymentAsync(IServiceOperations<ComputeManagementClient> client, IDictionary<string, object> parameters, out Action undoFunction)
        {
            undoFunction = null;
            VirtualMachineCreateDeploymentParameters createParameters;
            string serviceName;
            if (TryAssignParameter<string>("serviceName", parameters, out serviceName) &&
                TryAssignParameter<VirtualMachineCreateDeploymentParameters>("parameters", parameters, out createParameters) &&
                createParameters != null && !string.IsNullOrEmpty(createParameters.Name) && !string.IsNullOrEmpty(serviceName))
            {
                undoFunction = () =>
                {
                    using (ComputeManagementClient serviceClient = GetClientFromOperations(client))
                    {
                        serviceClient.Deployments.DeleteByName(serviceName, createParameters.Name, true);
                    }
                };

                return true;
            }

            TraceParameterError(this, "BeginCreatingDeploymentAsync", parameters);
            return false;
        }
    }
}
