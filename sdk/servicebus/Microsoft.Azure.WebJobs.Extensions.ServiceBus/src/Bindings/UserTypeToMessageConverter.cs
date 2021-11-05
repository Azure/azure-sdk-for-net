// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Newtonsoft.Json;
using Azure.Messaging.ServiceBus;

namespace Microsoft.Azure.WebJobs.ServiceBus.Bindings
{
    internal class UserTypeToMessageConverter<TInput> : IConverter<TInput, ServiceBusMessage>
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        public UserTypeToMessageConverter(JsonSerializerSettings jsonSerializerSettings)
        {
            _jsonSerializerSettings = jsonSerializerSettings;
        }

        public ServiceBusMessage Convert(TInput input)
        {
            string text = JsonConvert.SerializeObject(input, _jsonSerializerSettings);
            byte[] bytes = StrictEncodings.Utf8.GetBytes(text);

            return new ServiceBusMessage(bytes)
            {
                ContentType = ContentTypes.ApplicationJson
            };
        }
    }
}
