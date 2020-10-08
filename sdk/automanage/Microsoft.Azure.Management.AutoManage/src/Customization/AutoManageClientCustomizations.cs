namespace Microsoft.Azure.Management.AutoManage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.AutoManage.Models;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Newtonsoft.Json;
    

    public partial class AutomanageClient : ServiceClient<AutomanageClient>, IAutomanageClient, IAzureClient
    {
        private JsonSerializerSettings basicSerializationSettings = new JsonSerializerSettings()
        {
            Formatting = Formatting.Indented,
            TypeNameHandling = TypeNameHandling.Auto
        };

        partial void CustomInitialize()
        {
            var customJsonClient = this;
            customJsonClient.SerializationSettings = basicSerializationSettings;
            ConfigurationProfilePreferences = new ConfigurationProfilePreferencesOperations(customJsonClient);
        }
    }
}
