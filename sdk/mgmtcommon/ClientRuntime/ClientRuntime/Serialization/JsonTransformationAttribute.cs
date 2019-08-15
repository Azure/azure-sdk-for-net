// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Rest.Serialization
{
    /// <summary>
    /// Instructs the Microsoft.Rest.Serialization.TransformationJsonConverter to 
    /// transform properties of the type based on dot convention.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class JsonTransformationAttribute : Attribute
    {
    }
}
