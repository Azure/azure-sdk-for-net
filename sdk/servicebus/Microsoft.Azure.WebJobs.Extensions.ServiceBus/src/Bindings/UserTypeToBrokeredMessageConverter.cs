﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Diagnostics.CodeAnalysis;
using System.IO;
using Microsoft.Azure.WebJobs.Host.Converters;
using Newtonsoft.Json;
using Azure.Messaging.ServiceBus;

namespace Microsoft.Azure.WebJobs.ServiceBus.Bindings
{
    internal class UserTypeToBrokeredMessageConverter<TInput> : IConverter<TInput, ServiceBusMessage>
    {
        public ServiceBusMessage Convert(TInput input)
        {
            string text = JsonConvert.SerializeObject(input, Constants.JsonSerializerSettings);
            byte[] bytes = StrictEncodings.Utf8.GetBytes(text);

            return new ServiceBusMessage(bytes)
            {
                ContentType = ContentTypes.ApplicationJson
            };
        }
    }
}
