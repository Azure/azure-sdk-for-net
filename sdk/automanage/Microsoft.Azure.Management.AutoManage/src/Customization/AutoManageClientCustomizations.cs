namespace Microsoft.Azure.Management.AutoManage
{   
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
