// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.ApiManagement.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Tenant access information contract of the API Management service.
    /// </summary>
    public partial class AccessInformationSecretsContract
    {
        /// <summary>
        /// Initializes a new instance of the AccessInformationSecretsContract
        /// class.
        /// </summary>
        public AccessInformationSecretsContract()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the AccessInformationSecretsContract
        /// class.
        /// </summary>
        /// <param name="id">Access Information type ('access' or
        /// 'gitAccess')</param>
        /// <param name="principalId">Principal (User) Identifier.</param>
        /// <param name="primaryKey">Primary access key. This property will not
        /// be filled on 'GET' operations! Use '/listSecrets' POST request to
        /// get the value.</param>
        /// <param name="secondaryKey">Secondary access key. This property will
        /// not be filled on 'GET' operations! Use '/listSecrets' POST request
        /// to get the value.</param>
        /// <param name="enabled">Determines whether direct access is
        /// enabled.</param>
        public AccessInformationSecretsContract(string id = default(string), string principalId = default(string), string primaryKey = default(string), string secondaryKey = default(string), bool? enabled = default(bool?))
        {
            Id = id;
            PrincipalId = principalId;
            PrimaryKey = primaryKey;
            SecondaryKey = secondaryKey;
            Enabled = enabled;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets access Information type ('access' or 'gitAccess')
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets principal (User) Identifier.
        /// </summary>
        [JsonProperty(PropertyName = "principalId")]
        public string PrincipalId { get; set; }

        /// <summary>
        /// Gets or sets primary access key. This property will not be filled
        /// on 'GET' operations! Use '/listSecrets' POST request to get the
        /// value.
        /// </summary>
        [JsonProperty(PropertyName = "primaryKey")]
        public string PrimaryKey { get; set; }

        /// <summary>
        /// Gets or sets secondary access key. This property will not be filled
        /// on 'GET' operations! Use '/listSecrets' POST request to get the
        /// value.
        /// </summary>
        [JsonProperty(PropertyName = "secondaryKey")]
        public string SecondaryKey { get; set; }

        /// <summary>
        /// Gets or sets determines whether direct access is enabled.
        /// </summary>
        [JsonProperty(PropertyName = "enabled")]
        public bool? Enabled { get; set; }

    }
}
