using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Http;

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    public partial class AzureHttpClient
    {
        //AddDataDisk
        //DeleteDataDisk
        //GetDataDisk
        //UpdateDataDisk

        public Task<string> CreateDiskAsync(string name, string label, Uri linkToBlob, OperatingSystemType osType = OperatingSystemType.None,
                                                                                       CancellationToken token = default(CancellationToken))
        {
            VirtualHardDisk info = new VirtualHardDisk(name, label, linkToBlob, osType);

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Post, CreateTargetUri(UriFormatStrings.Disks), info);

            return StartSendTask(message, token);
        }

        public Task<string> DeleteDiskAsync(string name, CancellationToken token = default(CancellationToken))
        {
            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Delete, CreateTargetUri(UriFormatStrings.DisksAndDisk, name));

            return StartSendTask(message, token);
        }

        public Task<VirtualHardDiskCollection> ListDisksAsync(CancellationToken token = default(CancellationToken))
        {   
            //TODO: Validate params
            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Get, CreateTargetUri(UriFormatStrings.Disks));

            return StartGetTask<VirtualHardDiskCollection>(message, token);
        
        }

        //TODO: UpdateDisk
    }
}
