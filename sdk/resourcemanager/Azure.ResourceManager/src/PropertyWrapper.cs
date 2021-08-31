// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;

namespace Azure.ResourceManager.Core
{
    internal class PropertyWrapper
    {
        private PropertyInfo _info;

        private object _propertyObject;

        internal PropertyWrapper(PropertyInfo info, object propertyObject)
        {
            _info = info;
            _propertyObject = propertyObject;
        }

        internal string GetValue()
        {
            return _info.GetValue(_propertyObject).ToString();
        }

        internal void SetValue(string apiVersion)
        {
            Type type = _info.PropertyType;
            ConstructorInfo ctor = type.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(string) }, null);
            _info.SetValue(_propertyObject, ctor.Invoke(new object[] { apiVersion }));
        }
    }
}
