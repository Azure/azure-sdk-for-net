// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.ContainerRegistry
{
    // this is a workaround for this issue for now: https://github.com/Azure/autorest.csharp/issues/5427
    [AttributeUsage(AttributeTargets.Property)]
    internal class WirePathAttribute : Attribute
    {
        private string _wirePath;

        public WirePathAttribute(string wirePath)
        {
            _wirePath = wirePath;
        }

        public override string ToString()
        {
            return _wirePath;
        }
    }
}