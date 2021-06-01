using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.DataFactory.Models
{
    public partial class AzureDataExplorerLinkedService : LinkedService
    {
        /// <summary>
        /// Initializes a new instance of the AzureDataExplorerLinkedService
        /// class.
        /// </summary>
        /// <param name="endpoint">The endpoint of Azure Data Explorer (the
        /// engine's endpoint). URL will be in the format
        /// https://&lt;clusterName&gt;.&lt;regionName&gt;.kusto.windows.net.
        /// Type: string (or Expression with resultType string)</param>
        /// <param name="servicePrincipalId">The ID of the service principal
        /// used to authenticate against Azure Data Explorer. Type: string (or
        /// Expression with resultType string).</param>
        /// <param name="servicePrincipalKey">The key of the service principal
        /// used to authenticate against Kusto.</param>
        /// <param name="database">Database name for connection. Type: string
        /// (or Expression with resultType string).</param>
        /// <param name="tenant">The name or ID of the tenant to which the
        /// service principal belongs. Type: string (or Expression with
        /// resultType string).</param>
        /// <param name="additionalProperties">Unmatched properties from the
        /// message are deserialized this collection</param>
        /// <param name="connectVia">The integration runtime reference.</param>
        /// <param name="description">Linked service description.</param>
        /// <param name="parameters">Parameters for linked service.</param>
        /// <param name="annotations">List of tags that can be used for
        /// describing the linked service.</param>
        public AzureDataExplorerLinkedService(object endpoint, object servicePrincipalId, SecretBase servicePrincipalKey, object database, object tenant, IDictionary<string, object> additionalProperties = default(IDictionary<string, object>), IntegrationRuntimeReference connectVia = default(IntegrationRuntimeReference), string description = default(string), IDictionary<string, ParameterSpecification> parameters = default(IDictionary<string, ParameterSpecification>), IList<object> annotations = default(IList<object>))
            : base(additionalProperties, connectVia, description, parameters, annotations)
        {
            Endpoint = endpoint;
            ServicePrincipalId = servicePrincipalId;
            ServicePrincipalKey = servicePrincipalKey;
            Database = database;
            Tenant = tenant;
            CustomInit();
        }
    }
}
