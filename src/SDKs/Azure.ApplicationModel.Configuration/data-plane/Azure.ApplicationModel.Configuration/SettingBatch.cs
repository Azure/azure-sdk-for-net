// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.ComponentModel;
using System.Diagnostics;

namespace Azure.ApplicationModel.Configuration
{

    [DebuggerTypeProxy(typeof(SettingBatchDebugView))]
    public class SettingBatch
    {
        private readonly ConfigurationSetting[] _settings;
        private readonly SettingSelector _selector;
        private readonly string _link;

        public SettingBatch(ConfigurationSetting[] settings, string link, SettingSelector selector)
        {
            _settings = settings;
            _link = link;
            _selector = selector;
        }

        public ConfigurationSetting this[int index] => _settings[index];

        public int Count => _settings.Length;

        public SettingSelector NextBatch
        {
            get
            {
                if (_link != null)
                {
                    return _selector.CloneWithBatchLink(_link);
                }
                return null;
            }
        }

        #region nobody wants to see these
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();
        #endregion
    }
}
