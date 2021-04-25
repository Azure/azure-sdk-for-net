// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public abstract class WebPubSubOperation
    {
        private WebPubSubOperationKind _operationKind;

        public WebPubSubOperationKind OperationKind
        {
            get
            {
                return (WebPubSubOperationKind)Enum.Parse(typeof(WebPubSubOperationKind), GetType().Name);
            }
            set
            {
                // used in type-less for deserialize.
                _operationKind = value;
            }
        }
    }
}
