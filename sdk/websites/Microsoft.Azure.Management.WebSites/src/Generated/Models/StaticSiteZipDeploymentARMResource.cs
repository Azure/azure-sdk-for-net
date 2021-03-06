// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.WebSites.Models
{
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Static site zip deployment ARM resource.
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class StaticSiteZipDeploymentARMResource : ProxyOnlyResource
    {
        /// <summary>
        /// Initializes a new instance of the
        /// StaticSiteZipDeploymentARMResource class.
        /// </summary>
        public StaticSiteZipDeploymentARMResource()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// StaticSiteZipDeploymentARMResource class.
        /// </summary>
        /// <param name="id">Resource Id.</param>
        /// <param name="name">Resource Name.</param>
        /// <param name="kind">Kind of resource.</param>
        /// <param name="type">Resource type.</param>
        /// <param name="appZipUrl">URL for the zipped app content</param>
        /// <param name="apiZipUrl">URL for the zipped api content</param>
        /// <param name="deploymentTitle">A title to label the
        /// deployment</param>
        /// <param name="provider">The provider submitting this
        /// deployment</param>
        /// <param name="functionLanguage">The language of the api content, if
        /// it exists</param>
        public StaticSiteZipDeploymentARMResource(string id = default(string), string name = default(string), string kind = default(string), string type = default(string), string appZipUrl = default(string), string apiZipUrl = default(string), string deploymentTitle = default(string), string provider = default(string), string functionLanguage = default(string))
            : base(id, name, kind, type)
        {
            AppZipUrl = appZipUrl;
            ApiZipUrl = apiZipUrl;
            DeploymentTitle = deploymentTitle;
            Provider = provider;
            FunctionLanguage = functionLanguage;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets URL for the zipped app content
        /// </summary>
        [JsonProperty(PropertyName = "properties.appZipUrl")]
        public string AppZipUrl { get; set; }

        /// <summary>
        /// Gets or sets URL for the zipped api content
        /// </summary>
        [JsonProperty(PropertyName = "properties.apiZipUrl")]
        public string ApiZipUrl { get; set; }

        /// <summary>
        /// Gets or sets a title to label the deployment
        /// </summary>
        [JsonProperty(PropertyName = "properties.deploymentTitle")]
        public string DeploymentTitle { get; set; }

        /// <summary>
        /// Gets or sets the provider submitting this deployment
        /// </summary>
        [JsonProperty(PropertyName = "properties.provider")]
        public string Provider { get; set; }

        /// <summary>
        /// Gets or sets the language of the api content, if it exists
        /// </summary>
        [JsonProperty(PropertyName = "properties.functionLanguage")]
        public string FunctionLanguage { get; set; }

    }
}
