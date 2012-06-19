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
    }
}
