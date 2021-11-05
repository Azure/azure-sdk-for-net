// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub.Operations
{
    /// <summary>
    /// Abstract class of operation to invoke service.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public abstract class WebPubSubOperation
    {
        /// <summary>
        /// Name of the opeartion. Used in js to identify the operation.
        /// </summary>
        public string OperationKind
        {
            get
            {
                return GetType().Name;
            }
            internal set
            {
                // used in type-less for deserialize.
                _ = value;
            }
        }
    }
}
