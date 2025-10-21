// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace System.ClientModel.Primitives;

/// <summary>
/// Attribute to specify the context type for this assemblies <see cref="ModelReaderWriterContext"/> for source generation.
/// </summary>
[AttributeUsage(AttributeTargets.Assembly)]
[EditorBrowsable(EditorBrowsableState.Never)]
public sealed class ModelReaderWriterContextTypeAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ModelReaderWriterContextTypeAttribute"/> class.
    /// </summary>
    /// <param name="contextType">The <see cref="ModelReaderWriterContextTypeAttribute"/> type in this assembly.</param>
    public ModelReaderWriterContextTypeAttribute(Type contextType)
    {
        ContextType = contextType;
    }

    internal Type ContextType { get; }
}
