// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Microsoft.TypeSpec.Generator.Customizations;

/// <summary> Customizes the generated data type used by a management-plane resource. </summary>
/// <remarks>
/// This generator-side attribute is used only as metadata when compiling custom code.
/// Generated SDKs emit a matching internal attribute in the same namespace for source compatibility.
/// </remarks>
[AttributeUsage(AttributeTargets.Class)]
public sealed class CodeGenResourceDataAttribute : Attribute
{
    /// <summary> Initializes a new instance of the <see cref="CodeGenResourceDataAttribute"/> class. </summary>
    /// <param name="dataType">The data type to use for the annotated resource.</param>
    public CodeGenResourceDataAttribute(Type dataType)
    {
    }
}
