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
    /// The configuration settings of the app registration for the Twitter
    /// provider.
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class TwitterRegistration : ProxyOnlyResource
    {
        /// <summary>
        /// Initializes a new instance of the TwitterRegistration class.
        /// </summary>
        public TwitterRegistration()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the TwitterRegistration class.
        /// </summary>
        /// <param name="id">Resource Id.</param>
        /// <param name="name">Resource Name.</param>
        /// <param name="kind">Kind of resource.</param>
        /// <param name="type">Resource type.</param>
        /// <param name="consumerKey">The OAuth 1.0a consumer key of the
        /// Twitter application used for sign-in.
        /// This setting is required for enabling Twitter Sign-In.
        /// Twitter Sign-In documentation:
        /// https://dev.twitter.com/web/sign-in</param>
        /// <param name="consumerSecretSettingName">The app setting name that
        /// contains the OAuth 1.0a consumer secret of the Twitter
        /// application used for sign-in.</param>
        public TwitterRegistration(string id = default(string), string name = default(string), string kind = default(string), string type = default(string), string consumerKey = default(string), string consumerSecretSettingName = default(string))
            : base(id, name, kind, type)
        {
            ConsumerKey = consumerKey;
            ConsumerSecretSettingName = consumerSecretSettingName;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the OAuth 1.0a consumer key of the Twitter application
        /// used for sign-in.
        /// This setting is required for enabling Twitter Sign-In.
        /// Twitter Sign-In documentation: https://dev.twitter.com/web/sign-in
        /// </summary>
        [JsonProperty(PropertyName = "properties.consumerKey")]
        public string ConsumerKey { get; set; }

        /// <summary>
        /// Gets or sets the app setting name that contains the OAuth 1.0a
        /// consumer secret of the Twitter
        /// application used for sign-in.
        /// </summary>
        [JsonProperty(PropertyName = "properties.consumerSecretSettingName")]
        public string ConsumerSecretSettingName { get; set; }

    }
}
