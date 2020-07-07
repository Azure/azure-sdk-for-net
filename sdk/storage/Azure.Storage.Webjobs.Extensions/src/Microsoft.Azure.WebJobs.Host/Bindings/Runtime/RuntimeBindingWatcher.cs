// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs.Host.Protocols;

namespace Microsoft.Azure.WebJobs.Host.Bindings.Runtime
{
    internal class RuntimeBindingWatcher : IWatcher
    {
        private readonly object _itemsLock = new object();
        private ICollection<Tuple<ParameterDescriptor, string, IWatchable>> _items =
            new List<Tuple<ParameterDescriptor, string, IWatchable>>();

        public void Add(ParameterDescriptor parameterDescriptor, string value, IWatchable watchable)
        {
            lock (_itemsLock)
            {
                _items.Add(new Tuple<ParameterDescriptor, string, IWatchable>(parameterDescriptor, value, watchable));
            }
        }

        public ParameterLog GetStatus()
        {
            lock (_itemsLock)
            {
                if (_items.Count == 0)
                {
                    return null;
                }

                List<BinderParameterLogItem> logItems = new List<BinderParameterLogItem>();

                foreach (Tuple<ParameterDescriptor, string, IWatchable> item in _items)
                {
                    ParameterDescriptor parameterDescriptor = item.Item1;
                    string value = item.Item2;
                    IWatchable watchable = item.Item3;
                    IWatcher watcher;

                    if (watchable != null)
                    {
                        watcher = watchable.Watcher;
                    }
                    else
                    {
                        watcher = null;
                    }

                    ParameterLog itemStatus;

                    if (watcher != null)
                    {
                        itemStatus = watcher.GetStatus();
                    }
                    else
                    {
                        itemStatus = null;
                    }
                    
                    BinderParameterLogItem logItem = new BinderParameterLogItem
                    {
                        Descriptor = parameterDescriptor,
                        Value = value,
                        Log = itemStatus
                    };
                    logItems.Add(logItem);
                }

                return new BinderParameterLog { Items = logItems };
            }
        }
    }
}
