// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.CognitiveServices.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The api properties for special APIs.
    /// </summary>
    public partial class ApiProperties
    {
        /// <summary>
        /// Initializes a new instance of the ApiProperties class.
        /// </summary>
        public ApiProperties()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ApiProperties class.
        /// </summary>
        /// <param name="additionalProperties">Unmatched properties from the
        /// message are deserialized this collection</param>
        /// <param name="qnaRuntimeEndpoint">(QnAMaker Only) The runtime
        /// endpoint of QnAMaker.</param>
        /// <param name="qnaAzureSearchEndpointKey">(QnAMaker Only) The Azure
        /// Search endpoint key of QnAMaker.</param>
        /// <param name="qnaAzureSearchEndpointId">(QnAMaker Only) The Azure
        /// Search endpoint id of QnAMaker.</param>
        /// <param name="statisticsEnabled">(Bing Search Only) The flag to
        /// enable statistics of Bing Search.</param>
        /// <param name="eventHubConnectionString">(Personalization Only) The
        /// flag to enable statistics of Bing Search.</param>
        /// <param name="storageAccountConnectionString">(Personalization Only)
        /// The storage account connection string.</param>
        /// <param name="aadClientId">(Metrics Advisor Only) The Azure AD
        /// Client Id (Application Id).</param>
        /// <param name="aadTenantId">(Metrics Advisor Only) The Azure AD
        /// Tenant Id.</param>
        /// <param name="superUser">(Metrics Advisor Only) The super user of
        /// Metrics Advisor.</param>
        /// <param name="websiteName">(Metrics Advisor Only) The website name
        /// of Metrics Advisor.</param>
        public ApiProperties(IDictionary<string, object> additionalProperties = default(IDictionary<string, object>), string qnaRuntimeEndpoint = default(string), string qnaAzureSearchEndpointKey = default(string), string qnaAzureSearchEndpointId = default(string), bool? statisticsEnabled = default(bool?), string eventHubConnectionString = default(string), string storageAccountConnectionString = default(string), string aadClientId = default(string), string aadTenantId = default(string), string superUser = default(string), string websiteName = default(string))
        {
            AdditionalProperties = additionalProperties;
            QnaRuntimeEndpoint = qnaRuntimeEndpoint;
            QnaAzureSearchEndpointKey = qnaAzureSearchEndpointKey;
            QnaAzureSearchEndpointId = qnaAzureSearchEndpointId;
            StatisticsEnabled = statisticsEnabled;
            EventHubConnectionString = eventHubConnectionString;
            StorageAccountConnectionString = storageAccountConnectionString;
            AadClientId = aadClientId;
            AadTenantId = aadTenantId;
            SuperUser = superUser;
            WebsiteName = websiteName;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets unmatched properties from the message are deserialized
        /// this collection
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties { get; set; }

        /// <summary>
        /// Gets or sets (QnAMaker Only) The runtime endpoint of QnAMaker.
        /// </summary>
        [JsonProperty(PropertyName = "qnaRuntimeEndpoint")]
        public string QnaRuntimeEndpoint { get; set; }

        /// <summary>
        /// Gets or sets (QnAMaker Only) The Azure Search endpoint key of
        /// QnAMaker.
        /// </summary>
        [JsonProperty(PropertyName = "qnaAzureSearchEndpointKey")]
        public string QnaAzureSearchEndpointKey { get; set; }

        /// <summary>
        /// Gets or sets (QnAMaker Only) The Azure Search endpoint id of
        /// QnAMaker.
        /// </summary>
        [JsonProperty(PropertyName = "qnaAzureSearchEndpointId")]
        public string QnaAzureSearchEndpointId { get; set; }

        /// <summary>
        /// Gets or sets (Bing Search Only) The flag to enable statistics of
        /// Bing Search.
        /// </summary>
        [JsonProperty(PropertyName = "statisticsEnabled")]
        public bool? StatisticsEnabled { get; set; }

        /// <summary>
        /// Gets or sets (Personalization Only) The flag to enable statistics
        /// of Bing Search.
        /// </summary>
        [JsonProperty(PropertyName = "eventHubConnectionString")]
        public string EventHubConnectionString { get; set; }

        /// <summary>
        /// Gets or sets (Personalization Only) The storage account connection
        /// string.
        /// </summary>
        [JsonProperty(PropertyName = "storageAccountConnectionString")]
        public string StorageAccountConnectionString { get; set; }

        /// <summary>
        /// Gets or sets (Metrics Advisor Only) The Azure AD Client Id
        /// (Application Id).
        /// </summary>
        [JsonProperty(PropertyName = "aadClientId")]
        public string AadClientId { get; set; }

        /// <summary>
        /// Gets or sets (Metrics Advisor Only) The Azure AD Tenant Id.
        /// </summary>
        [JsonProperty(PropertyName = "aadTenantId")]
        public string AadTenantId { get; set; }

        /// <summary>
        /// Gets or sets (Metrics Advisor Only) The super user of Metrics
        /// Advisor.
        /// </summary>
        [JsonProperty(PropertyName = "superUser")]
        public string SuperUser { get; set; }

        /// <summary>
        /// Gets or sets (Metrics Advisor Only) The website name of Metrics
        /// Advisor.
        /// </summary>
        [JsonProperty(PropertyName = "websiteName")]
        public string WebsiteName { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (EventHubConnectionString != null)
            {
                if (EventHubConnectionString.Length > 1000)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "EventHubConnectionString", 1000);
                }
                if (!System.Text.RegularExpressions.Regex.IsMatch(EventHubConnectionString, "^( *)Endpoint=sb://(.*);( *)SharedAccessKeyName=(.*);( *)SharedAccessKey=(.*)$"))
                {
                    throw new ValidationException(ValidationRules.Pattern, "EventHubConnectionString", "^( *)Endpoint=sb://(.*);( *)SharedAccessKeyName=(.*);( *)SharedAccessKey=(.*)$");
                }
            }
            if (StorageAccountConnectionString != null)
            {
                if (StorageAccountConnectionString.Length > 1000)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "StorageAccountConnectionString", 1000);
                }
                if (!System.Text.RegularExpressions.Regex.IsMatch(StorageAccountConnectionString, "^(( *)DefaultEndpointsProtocol=(http|https)( *);( *))?AccountName=(.*)AccountKey=(.*)EndpointSuffix=(.*)$"))
                {
                    throw new ValidationException(ValidationRules.Pattern, "StorageAccountConnectionString", "^(( *)DefaultEndpointsProtocol=(http|https)( *);( *))?AccountName=(.*)AccountKey=(.*)EndpointSuffix=(.*)$");
                }
            }
            if (AadClientId != null)
            {
                if (AadClientId.Length > 500)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "AadClientId", 500);
                }
            }
            if (AadTenantId != null)
            {
                if (AadTenantId.Length > 500)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "AadTenantId", 500);
                }
            }
            if (SuperUser != null)
            {
                if (SuperUser.Length > 500)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "SuperUser", 500);
                }
            }
            if (WebsiteName != null)
            {
                if (WebsiteName.Length > 500)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "WebsiteName", 500);
                }
            }
        }
    }
}
