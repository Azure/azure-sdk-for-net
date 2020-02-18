// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    ///
    /// </summary>
    public class SessionOptions
    {
        /// <summary>
        ///
        /// </summary>
        public string SessionId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public ServiceBusConnection Connection { get; set; }
    }
}
