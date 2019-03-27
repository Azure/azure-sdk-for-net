// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Base.Attributes
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
    public class AzureSdkClientLibraryAttribute: Attribute
    {
        public string ComponentName { get; }

        public AzureSdkClientLibraryAttribute(string componentName)
        {
            ComponentName = componentName;
        }
    }
}
