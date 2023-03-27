namespace Microsoft.Azure.Management.Compute
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.Serialization;
    using Models;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;

    /// <summary>
    /// Compute Client
    /// </summary>
    public partial class ComputeManagementClient : ServiceClient<ComputeManagementClient>, IComputeManagementClient, IAzureClient
    {
        partial void CustomInitialize()
        {
            this.DeserializationSettings.DateParseHandling = DateParseHandling.None;
        }
    }
}