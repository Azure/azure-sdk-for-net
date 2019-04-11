// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Diagnostics;

namespace Azure.ApplicationModel.Configuration
{
    class SettingBatchDebugView
    {
        SettingBatch _batch;
        ConfigurationSetting[] _items;

        public SettingBatchDebugView(SettingBatch batch)
        {
            _batch = batch;
            _items = new ConfigurationSetting[_batch.Count];
            for(int i=0; i<_batch.Count; i++) {
                _items[i] = _batch[i];
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public ConfigurationSetting[] Items => _items;        
    }
}
