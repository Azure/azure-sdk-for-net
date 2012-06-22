using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading;

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    public partial class AzureHttpClient
    {
        //AddVirtualMachineRoleAsync
        //CaptureVirtualMachineRole
        //DeleteVirualMachineRole

        public Task<PersistentVMRole> GetVirtualMachineRoleAsync(string cloudServiceName, string deploymentName, string roleName, CancellationToken token = default(CancellationToken))
        {
            //TODO: Validate params
            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Get, CreateTargetUri(UriFormatStrings.RolesAndRole, cloudServiceName, deploymentName, roleName));

            return StartGetTask<PersistentVMRole>(message, token);
        }

        //ShutdownVirtualMachineRoleAsync
        //RestartVirtualMachineRoleAsync
        //StartVirtualMachineRoleAsync
        //UpdateVirtualMachineRoleAsync

        public Task<string> CreateVirtualMachineDeploymentAsync(string cloudServiceName, string deploymentName, string deploymentLabel, PersistentVMRole vmRole, CancellationToken token = default(CancellationToken))
        {
            CreateVirtualMachineDeploymentInfo info = CreateVirtualMachineDeploymentInfo.Create(deploymentName, deploymentLabel, vmRole);

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Post, CreateTargetUri(UriFormatStrings.Deployments, cloudServiceName), info);

            return StartSendTask(message, token);
        }

        public Task<string> CreateVirtualMachineDeploymentAsync(string cloudServiceName, string deploymentName, string deploymentLabel, List<PersistentVMRole> vmRoles, 
                                                               string virtualNetworkName = null /*, DnsServerCollection dns = null*/, CancellationToken token = default(CancellationToken))
        {
            CreateVirtualMachineDeploymentInfo info = CreateVirtualMachineDeploymentInfo.Create(deploymentName, deploymentLabel, vmRoles, virtualNetworkName);

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Post, CreateTargetUri(UriFormatStrings.Deployments, cloudServiceName), info);

            return StartSendTask(message, token);

        }
    }
}
