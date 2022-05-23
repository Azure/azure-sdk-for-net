using System.Collections.Generic;

namespace Microsoft.Azure.Management.DataFactory.Models
{
    public partial class Factory : Resource
    {
        /// <summary>
        /// Initializes a new instance of the Factory class.
        /// </summary>
        /// <param name="id">The resource identifier.</param>
        /// <param name="name">The resource name.</param>
        /// <param name="type">The resource type.</param>
        /// <param name="location">The resource location.</param>
        /// <param name="tags">The resource tags.</param>
        /// <param name="eTag">Etag identifies change in the resource.</param>
        /// <param name="additionalProperties">Unmatched properties from the
        /// message are deserialized this collection</param>
        /// <param name="identity">Managed service identity of the
        /// factory.</param>
        /// <param name="provisioningState">Factory provisioning state, example
        /// Succeeded.</param>
        /// <param name="createTime">Time the factory was created in ISO8601
        /// format.</param>
        /// <param name="version">Version of the factory.</param>
        /// <param name="repoConfiguration">Git repo information of the
        /// factory.</param>
        /// <param name="globalParameters">List of parameters for
        /// factory.</param>
        /// <param name="encryption">Properties to enable Customer Managed Key
        /// for the factory.</param>
        /// <param name="publicNetworkAccess">Whether or not public network
        /// access is allowed for the data factory. Possible values include:
        /// 'Enabled', 'Disabled'</param>
        public Factory(string id = default(string), string name = default(string), string type = default(string), string location = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>), string eTag = default(string), IDictionary<string, object> additionalProperties = default(IDictionary<string, object>), FactoryIdentity identity = default(FactoryIdentity), string provisioningState = default(string), System.DateTime? createTime = default(System.DateTime?), string version = default(string), FactoryRepoConfiguration repoConfiguration = default(FactoryRepoConfiguration), IDictionary<string, GlobalParameterSpecification> globalParameters = default(IDictionary<string, GlobalParameterSpecification>), EncryptionConfiguration encryption = default(EncryptionConfiguration), string publicNetworkAccess = default(string))
            : base(id, name, type, location, tags, eTag)
        {
            AdditionalProperties = additionalProperties;
            Identity = identity;
            ProvisioningState = provisioningState;
            CreateTime = createTime;
            Version = version;
            RepoConfiguration = repoConfiguration;
            GlobalParameters = globalParameters;
            Encryption = encryption;
            PublicNetworkAccess = publicNetworkAccess;
            CustomInit();
        }
    }
}
