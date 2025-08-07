// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.Tests
{
    public class LogMessage
    {
        public LogLevel Level { get; set; }

        public EventId EventId { get; set; }

        public IEnumerable<KeyValuePair<string, object>> State { get; set; }

        public Exception Exception { get; set; }

        public string FormattedMessage { get; set; }

        public string Category { get; set; }

        public DateTime Timestamp { get; set; }

        public override string ToString() => $"[{Timestamp.ToString("HH:mm:ss.fff")}] [{Category}] {FormattedMessage} {Exception}";

        /// <summary>
        /// Returns the value for the key in State. Will throw an exception if there is not
        /// exactly one instance of this key in the dictionary.
        /// </summary>
        /// <typeparam name="T">The type to cast the value to.</typeparam>
        /// <param name="key">The key to look up.</param>
        /// <returns>The value.</returns>
        public T GetStateValue<T>(string key)
        {
            return (T)State.Single(p => p.Key == key).Value;
        }
    }
}
