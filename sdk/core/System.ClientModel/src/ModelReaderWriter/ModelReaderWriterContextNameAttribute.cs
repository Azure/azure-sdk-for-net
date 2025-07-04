// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;

/// <summary>
/// Attribute to specify the context type for this assemblies <see cref="ModelReaderWriterContext"/> for source generation.
/// </summary>
[AttributeUsage(AttributeTargets.Assembly)]
public class ModelReaderWriterContextNameAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ModelReaderWriterContextNameAttribute"/> class.
    /// </summary>
    /// <param name="contextType">The <see cref="ModelReaderWriterContextNameAttribute"/> type in this assembly.</param>
    public ModelReaderWriterContextNameAttribute(Type contextType)
    {
        ContextType = contextType;
    }

    internal Type ContextType { get; }
}
