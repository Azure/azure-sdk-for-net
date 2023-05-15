// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using CoreWCF.Queue.Common;

namespace Azure.Storage.CoreWCF.Channels
{
    internal class AzureQueueStorageMessageContext : QueueMessageContext
    {
        private IDictionary<string, object> _properties = new Dictionary<string, object>();

        public override IDictionary<string, object> Properties
        {
            get { return _properties; }
        }

        public void SetProperties(IDictionary<string, object> properties)
        {
            _properties = properties;
        }
    }
}
