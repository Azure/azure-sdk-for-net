// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

using Newtonsoft.Json;

namespace Microsoft.Azure.Entra.Authentication
{
    /// <summary>
    /// This abstract model represents the data context object that is sent to the user-defined external api and recieved back when custom extension is configured for an event.
    /// It is common for all external api request payloads and response payloads.
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public abstract class CustomExtensionData
    {
        /// <summary>
        /// Default Constructor for Json Deserialization
        /// </summary>
        protected CustomExtensionData()
        {
        }

        /// <summary>
        /// Constructor for CustomAuthenticationExtensionCalloutData.
        /// All Base classes need to set ODataType
        /// </summary>
        /// <param name="dataType">ODataType</param>
        protected CustomExtensionData(string dataType)
        {
            this.ODataType = APIModelConstants.MicrosoftGraphPrefix + dataType;
        }

        /// <summary>
        /// The ODataType graph string.
        /// JsonProperty.Order is specifically used to define where it ends up on the JSON deserilization.
        /// </summary>
        [JsonProperty(propertyName: APIModelConstants.ODataType, Order = Int32.MinValue)]
        public string ODataType { get; set; }
    }
}
