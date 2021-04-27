// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.WebJobs.ServiceBus.Bindings
{
    /// <summary>
    /// Bindable queue or topic path strategy implementation for "degenerate" bindable patterns,
    /// i.e. containing no parameters.
    /// </summary>
    internal class BoundServiceBusPath : IBindableServiceBusPath
    {
        private readonly string _queueOrTopicNamePattern;

        public BoundServiceBusPath(string queueOrTopicNamePattern)
        {
            _queueOrTopicNamePattern = queueOrTopicNamePattern;
        }

        public string QueueOrTopicNamePattern
        {
            get { return _queueOrTopicNamePattern; }
        }

        public bool IsBound
        {
            get { return true; }
        }

        public IEnumerable<string> ParameterNames
        {
            get { return Enumerable.Empty<string>(); }
        }

        public string Bind(IReadOnlyDictionary<string, object> bindingData)
        {
            return QueueOrTopicNamePattern;
        }
    }
}
