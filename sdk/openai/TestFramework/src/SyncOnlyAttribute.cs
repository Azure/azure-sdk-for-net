// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace OpenAI.TestFramework;

/// <summary>
/// Attribute that can be applied to a test to indicate it only runs in synchronous mode.
/// </summary>
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
public class SyncOnlyAttribute() : NUnitAttribute
{
}
