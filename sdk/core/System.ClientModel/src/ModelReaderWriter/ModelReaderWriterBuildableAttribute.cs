// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;

/// <summary>
/// Instructs the System.ClientModel source generator to generate source code to help optimize performance
/// when reading and writing instances of the specified type.
/// </summary>
[AttributeUsage(AttributeTargets.Class,  AllowMultiple = true)]
public class ModelReaderWriterBuildableAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of <see cref="ModelReaderWriterBuildableAttribute"/> with the specified type.
    /// </summary>
    /// <param name="type">The type to generate source code for.</param>
    public ModelReaderWriterBuildableAttribute(Type type)
    {
    }
}
