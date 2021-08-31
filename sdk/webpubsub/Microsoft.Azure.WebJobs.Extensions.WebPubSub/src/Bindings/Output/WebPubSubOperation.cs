// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public abstract class WebPubSubOperation
    {
        public string OperationKind
        {
            get
            {
                return GetType().Name;
            }
            set
            {
                // used in type-less for deserialize.
                _ = value;
            }
        }
    }
}
