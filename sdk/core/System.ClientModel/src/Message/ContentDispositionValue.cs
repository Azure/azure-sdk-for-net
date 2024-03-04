// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace System.ClientModel.Primitives;

/// <summary>
/// A class to represent the Content-Disposition value for a multipart/form-data request.
/// </summary>
public class ContentDispositionValue
{
    /// <summary>
    /// The name of the form field.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// The filename of the file being uploaded.
    /// </summary>
    public string? FileName { get; }

    /// <summary>
    /// Creates a new instance of the <see cref="ContentDispositionValue"/> class.
    /// </summary>
    /// <param name="name">The name of the form field.</param>
    /// <param name="fileName">The filename of the file being uploaded.</param>
    public ContentDispositionValue(string name, string? fileName = null)
    {
        Name = name;
    }

    /// <inheritdoc/>
    public override string ToString() => FileName == null ? $"form-data; name=\"{Name}\"" : $"form-data; name=\"{Name}\"; filename=\"{FileName}\"";
}
