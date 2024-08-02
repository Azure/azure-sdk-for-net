// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace OpenAI.TestFramework.Recording;

/// <summary>
/// Currently equivalent to <see cref="TestAttribute"/>. This is here to reduce the delta when moving to this
/// framework from the from other recording test frameworks.
/// </summary>
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
public class RecordedTestAttribute : TestAttribute
{
}
