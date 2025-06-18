// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace System.ClientModel.TestFramework;

/// <summary>
/// Marks that a test should only be executed synchronously (in a test
/// fixture derived from <see cref="ClientTestBase"/>).
/// </summary>
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Assembly, AllowMultiple = false, Inherited = true)]
public class SyncOnlyAttribute : NUnitAttribute
{
}