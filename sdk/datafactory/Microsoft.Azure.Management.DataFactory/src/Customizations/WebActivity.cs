using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.DataFactory.Models
{
    public partial class WebActivity
    {
        /// <summary>
        /// Initializes a new instance of the WebActivity class.
        /// </summary>
        /// <param name="name">Activity name.</param>
        /// <param name="method">Rest API method for target endpoint. Possible
        /// values include: 'GET', 'POST', 'PUT', 'DELETE'</param>
        /// <param name="url">Web activity target endpoint and path. Type:
        /// string (or Expression with resultType string).</param>
        /// <param name="additionalProperties">Unmatched properties from the
        /// message are deserialized this collection</param>
        /// <param name="description">Activity description.</param>
        /// <param name="dependsOn">Activity depends on condition.</param>
        /// <param name="userProperties">Activity user properties.</param>
        /// <param name="linkedServiceName">Linked service reference.</param>
        /// <param name="policy">Activity policy.</param>
        /// <param name="headers">Represents the headers that will be sent to
        /// the request. For example, to set the language and type on a
        /// request: "headers" : { "Accept-Language": "en-us", "Content-Type":
        /// "application/json" }. Type: string (or Expression with resultType
        /// string).</param>
        /// <param name="body">Represents the payload that will be sent to the
        /// endpoint. Required for POST/PUT method, not allowed for GET method
        /// Type: string (or Expression with resultType string).</param>
        /// <param name="authentication">Authentication method used for calling
        /// the endpoint.</param>
        /// <param name="datasets">List of datasets passed to web
        /// endpoint.</param>
        /// <param name="linkedServices">List of linked services passed to web
        /// endpoint.</param>
        /// <param name="connectVia">The integration runtime reference.</param>
        public WebActivity(string name, string method, object url, IDictionary<string, object> additionalProperties = default(IDictionary<string, object>), string description = default(string), IList<ActivityDependency> dependsOn = default(IList<ActivityDependency>), IList<UserProperty> userProperties = default(IList<UserProperty>), LinkedServiceReference linkedServiceName = default(LinkedServiceReference), ActivityPolicy policy = default(ActivityPolicy), object headers = default(object), object body = default(object), WebActivityAuthentication authentication = default(WebActivityAuthentication), IList<DatasetReference> datasets = default(IList<DatasetReference>), IList<LinkedServiceReference> linkedServices = default(IList<LinkedServiceReference>), IntegrationRuntimeReference connectVia = default(IntegrationRuntimeReference))
            : base(name, additionalProperties, description, dependsOn, userProperties, linkedServiceName, policy)
        {
            Method = method;
            Url = url;
            Headers = headers;
            Body = body;
            Authentication = authentication;
            Datasets = datasets;
            LinkedServices = linkedServices;
            ConnectVia = connectVia;
            CustomInit();
        }
    }
}
