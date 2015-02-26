// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest;

namespace Microsoft.Azure
{
    /// <summary>
    /// A standard service response including an HTTP status code and request
    /// ID.
    /// </summary>
    public class AzureOperationResponse : IDeserializationModel
    {
        /// <summary>
        /// Gets or sets the value that uniquely identifies a request 
        /// made against the service.
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// In an impementing class, deserialize the instance with data from the given Json Token.
        /// </summary>
        /// <param name="inputObject">The Json Token that contains serialized data.</param>
        public virtual void DeserializeJson(Newtonsoft.Json.Linq.JToken inputObject)
        {
            // Do nothing
        }

        /// <summary>
        /// In an implementing class, deserialize the instance with data from the given Xml Container.
        /// </summary>
        /// <param name="inputObject">The Xml Container containing the serialized data.</param>
        public virtual void DeserializeXml(System.Xml.Linq.XContainer inputObject)
        {
            // Do nothing
        }
    }
}