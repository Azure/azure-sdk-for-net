// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Bindings.Path;

namespace Microsoft.Azure.WebJobs.ServiceBus.Bindings
{
    /// <summary>
    /// Implementation of <see cref="IBindableServiceBusPath"/> strategy for paths
    /// containing one or more parameters.
    /// </summary>
    internal class ParameterizedServiceBusPath : IBindableServiceBusPath
    {
        private readonly BindingTemplate _template;

        public ParameterizedServiceBusPath(BindingTemplate template)
        {
            Debug.Assert(template != null, "template must not be null");
            Debug.Assert(template.ParameterNames.Any(), "template must contain one or more parameters");

            _template = template;
        }

        public string QueueOrTopicNamePattern
        {
            get { return _template.Pattern; }
        }

        public bool IsBound
        {
            get { return false; }
        }

        public IEnumerable<string> ParameterNames
        {
            get { return _template.ParameterNames; }
        }

        public string Bind(IReadOnlyDictionary<string, object> bindingData)
        {
            if (bindingData == null)
            {
                throw new ArgumentNullException(nameof(bindingData));
            }

            string queueOrTopicName = _template.Bind(bindingData);
            return queueOrTopicName;
        }
    }
}
