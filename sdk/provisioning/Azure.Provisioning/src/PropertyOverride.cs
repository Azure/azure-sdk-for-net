// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning
{
    internal struct PropertyOverride
    {
        public string? PropertyValue { get;  }
        public Parameter? Parameter { get; }
        internal PropertyOverride(string? propertyValue = default, Parameter? parameter = default)
        {
            PropertyValue = propertyValue;
            Parameter = parameter;
        }
    }
}
