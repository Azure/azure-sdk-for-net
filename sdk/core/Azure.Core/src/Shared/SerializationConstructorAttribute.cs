// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core
{
    /// <summary>
    /// An attribute class indicating to AutoRest which constructor to use for serialization.
    /// </summary>
    [AttributeUsage(AttributeTargets.Constructor)]
    internal class SerializationConstructorAttribute : Attribute
    {
    }
}
