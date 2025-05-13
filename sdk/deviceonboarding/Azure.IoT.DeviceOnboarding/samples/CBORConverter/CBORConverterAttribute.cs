// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.IoT.DeviceOnboarding.Samples
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class CBORConverterAttribute : Attribute
    {
        public CBORConverterAttribute(Type targetType)
        {
            this.TargetType = targetType;
        }

        public Type TargetType { get; }
    }
}
