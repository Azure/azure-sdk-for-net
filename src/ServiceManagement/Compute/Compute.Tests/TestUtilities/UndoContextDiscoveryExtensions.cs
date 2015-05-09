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

using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Testing;

namespace Microsoft.WindowsAzure.Management.Compute.Testing
{
    /// <summary>
    /// Discovery extensions - used to discover and construct available undo handlers 
    /// in the current app domain
    /// </summary>
    
    [UndoHandlerFactory]
    public static class UndoContextDiscoveryExtensions
    {
        /// <summary>
        /// Create the undo handler for deployment operations
        /// </summary>
        /// <returns>An undo handler for deployment operations</returns>
        public static OperationUndoHandler CreateDeploymentUndoHandler()
        {
            return new DeploymentUndoHandler();
        }

        /// <summary>
        /// Create the undo handler for hosted service operations
        /// </summary>
        /// <returns>An undo handler for hosted service operations</returns>
        public static OperationUndoHandler CreateHostedServiceUndoHandler()
        {
            return new HostedServiceUndoHandler();
        }

        /// <summary>
        /// Create the undo handler for service certificate operations
        /// </summary>
        /// <returns>An undo handler for service certificate operations</returns>
        public static OperationUndoHandler CreateServiceCertificateUndoHandler()
        {
            return new ServiceCertificateUndoHandler();
        }

        /// <summary>
        /// Create the undo handler for virtual machine disk operations
        /// </summary>
        /// <returns>An undo handler for virtual machine disk operations</returns>
        public static OperationUndoHandler CreateVirtualMachineDiskUndoHandler()
        {
            return new VirtualMachineDiskUndoHandler();
        }

        /// <summary>
        /// Create the undo handler for virtual machine image operations
        /// </summary>
        /// <returns>An undo handler for virtual machine image operations</returns>
        public static OperationUndoHandler CreateVirtualMachineImageUndoHandler()
        {
            return new VirtualMachineImageUndoHandler();
        }

        /// <summary>
        /// Create the undo handler for virtual machine operations
        /// </summary>
        /// <returns>An undo handler for virtual machine operations</returns>
        public static OperationUndoHandler CreateVirtualMachineUndoHandler()
        {
            return new VirtualMachineUndoHandler();
        }
    }
}

