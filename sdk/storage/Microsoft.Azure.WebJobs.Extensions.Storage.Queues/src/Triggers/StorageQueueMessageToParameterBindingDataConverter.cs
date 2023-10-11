// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Queues.Triggers
{
    internal class StorageQueueMessageToParameterBindingDataConverter : IConverter<QueueMessage, ParameterBindingData>
    {
        public ParameterBindingData Convert(QueueMessage input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            var content = new BinaryData(input);
            return new ParameterBindingData("1.0", Constants.WebJobsQueueExtensionName, content, "application/json");
        }
    }
}
