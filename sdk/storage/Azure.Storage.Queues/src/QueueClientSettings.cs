// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Storage.Queues
{
    public partial class QueueClientSettings
    {
        internal string ConnectionString { get; set; }

        internal string QueueName { get; set; }

        /// <summary>
        /// A <see cref="Uri"/> referencing the queue that includes the
        /// name of the account, and the name of the queue.
        /// This is likely to be similar to "https://{account_name}.queue.core.windows.net/{queue_name}". </summary>
        [CodeGenMember("Url")]
        public Uri QueueUri { get; set; }
    }
}
