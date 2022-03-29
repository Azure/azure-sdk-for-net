// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;

namespace Azure.Core.TestFramework
{
    public class TestAppContextSwitch : DisposableConfig
    {
        private static SemaphoreSlim _lock = new(1, 1);
        public TestAppContextSwitch(string name, string value) : base(name, value, _lock) { }
        public TestAppContextSwitch(Dictionary<string, string> values) : base(values, _lock) { }
        private MethodInfo removeMethod;
        private object _switches;

        internal override void SetValue(string name, string value)
        {
            if (!bool.TryParse(value, out bool boolVal))
            {
                throw new ArgumentException("Value must be parsable as bool");
            }
            if (AppContext.TryGetSwitch(name, out bool originalValue))
            {
                _originalValues[name] = originalValue.ToString();
            }
            else
            {
                _originalValues[name] = null;
            }
            AppContext.SetSwitch(name, boolVal);
        }

        internal override void SetValues(Dictionary<string, string> values)
        {
            foreach (var kvp in values)
            {
                SetValue(kvp.Key, kvp.Value);
            }
        }

        internal override void InitValues()
        {
            Type type = typeof(AppContext);
            FieldInfo info = type.GetField("s_switches", BindingFlags.NonPublic | BindingFlags.Static);
            if (info == null)
            {
                info = type.GetField("s_switchMap", BindingFlags.NonPublic | BindingFlags.Static);
            }
            _switches = info.GetValue(null);
            // initialize the switches, which can be null until the first switch is set.
            // cspell:disable-next-line
            var initSwitch = "azuresdktestinitswitch";
            _originalValues[initSwitch] = null;
            AppContext.SetSwitch(initSwitch, false);
            _switches = info.GetValue(null);
            removeMethod = _switches.GetType().GetMethod("Remove", new[] { typeof(string) });
        }

        internal override void Cleanup()
        {
            foreach (var kvp in _originalValues)
            {
                if (kvp.Value == null)
                {
                    try
                    {
                        removeMethod.Invoke(_switches, new[] { kvp.Key });
                    }
                    catch { }
                }
                else
                {
                    AppContext.SetSwitch(kvp.Key, bool.TryParse(kvp.Value, out bool oldVal) || oldVal);
                }
                AppDomain.CurrentDomain.SetData(kvp.Key, kvp.Value);
            }
        }
    }
}
