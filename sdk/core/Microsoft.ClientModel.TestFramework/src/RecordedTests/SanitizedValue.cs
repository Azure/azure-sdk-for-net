// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// Specifies the type of sanitization to apply to sensitive values during test recording.
/// This enum is used to determine how sensitive data should be masked or transformed
/// when recording test sessions to ensure security while maintaining test functionality.
/// </summary>
public enum SanitizedValue
{
    /// <summary>
    /// Applies the default sanitization strategy for the value type.
    /// </summary>
    Default,
    /// <summary>
    /// Represents a base64 encoded value.
    /// </summary>
    Base64
}
