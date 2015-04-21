// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.Rest;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure
{
    /// <summary>
    /// Information for resource.
    /// </summary>
    public partial class ResourceBase
    {
        /// <summary>
        /// Optional. Gets or sets the ID of the resource.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Optional. Gets or sets the name of the resource.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Optional. Gets or sets the type of the resource.
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// Optional. Gets or sets the provisioning state of the resource.
        /// </summary>
        public string ProvisioningState { get; private set; }

        /// <summary>
        /// Required. Gets or sets the location of the resource.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Optional. Gets or sets the tags attached to the resource.
        /// </summary>
        public IDictionary<string, string> Tags { get; set; }

        /// <summary>
        /// Initializes a new instance of the ResourceBase class.
        /// </summary>
        public ResourceBase()
        {
            this.Tags = new LazyDictionary<string, string>();
        }
        
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public virtual void DeserializeJson(JToken inputObject)
        {
            if (inputObject != null && inputObject.Type != JTokenType.Null)
            {
                JToken idValue = inputObject["id"];
                if (idValue != null && idValue.Type != JTokenType.Null)
                {
                    this.Id = ((string)idValue);
                }
                JToken nameValue = inputObject["name"];
                if (nameValue != null && nameValue.Type != JTokenType.Null)
                {
                    this.Name = ((string)nameValue);
                }
                JToken typeValue = inputObject["type"];
                if (typeValue != null && typeValue.Type != JTokenType.Null)
                {
                    this.Type = ((string)typeValue);
                }
                JToken provisioningStateValue = inputObject["properties"]["provisioningState"];
                if (provisioningStateValue != null && provisioningStateValue.Type != JTokenType.Null)
                {
                    this.ProvisioningState = ((string)provisioningStateValue);
                }
                JToken locationValue = inputObject["location"];
                if (locationValue != null && locationValue.Type != JTokenType.Null)
                {
                    this.Location = ((string)locationValue);
                }
                JToken tagsValue = inputObject["tags"];
                if (tagsValue != null && tagsValue.Type != JTokenType.Null)
                {
                    foreach (JProperty property in inputObject["tags"])
                    {
                        this.Tags.Add(property.Name, (string)property.Value);
                    }
                }
            }
        }

        /// <summary>
        /// Serialize the object
        /// </summary>
        /// <returns>
        /// Returns the json model for the type RedisCreateOrUpdateParameters
        /// </returns>
        public virtual JToken SerializeJson(JToken outputObject)
        {
            if (outputObject == null)
            {
                outputObject = new JObject();
            }
            if (this.Location != null)
            {
                outputObject["location"] = this.Location;
            }
            if (this.Tags != null)
            {
                if (this.Tags is ILazyCollection<KeyValuePair<string, string>> == false || ((ILazyCollection<KeyValuePair<string, string>>)this.Tags).IsInitialized)
                {
                    JObject tagsDictionary = new JObject();
                    outputObject["tags"] = tagsDictionary;
                    foreach (KeyValuePair<string, string> pair in this.Tags)
                    {
                        string stringKey = pair.Key;
                        string stringValue = pair.Value;
                        if (stringValue != null)
                        {
                            tagsDictionary[stringKey] = stringValue;
                        }
                    }
                }
            }
            return outputObject;
        }
    }
}
