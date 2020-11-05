// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Globalization;
using Microsoft.Azure.WebJobs.Host.Protocols;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Queues
{
    /// <summary>Represents a parameter triggered on a queue in Azure Storage.</summary>
    internal class QueueTriggerParameterDescriptor : TriggerParameterDescriptor
    {
        /// <summary>Gets or sets the name of the storage account.</summary>
        public string AccountName { get; set; }

        /// <summary>Gets or sets the name of the queue.</summary>
        public string QueueName { get; set; }

        /// <inheritdoc />
        public override string GetTriggerReason(IDictionary<string, string> arguments)
        {
            return string.Format(CultureInfo.CurrentCulture, "New queue message detected on '{0}'.", QueueName);
        }
    }
}
