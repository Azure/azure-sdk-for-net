// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace OpenAI.TestFramework;

/// <summary>
/// An attribute used to indicate that a test should be recorded (or played back from a file). When you inherit from
/// <see cref="RecordedClientTestBase"/> in your test class, and add this attribute to your test function, and then
/// make sure to call <see cref="RecordedClientTestBase.ConfigureClientOptions{TClientOptions}(TClientOptions)"/>
/// on the client options you use to configure a client, this should automatically enable the recording/playback
/// functionality.
/// </summary>
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
public class RecordedTestAttribute : TestAttribute
{
}
