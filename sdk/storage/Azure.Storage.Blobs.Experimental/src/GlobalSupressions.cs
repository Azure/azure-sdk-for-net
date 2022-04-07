// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

// TODO: remove all supressions
[module: SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods")]
[module: SuppressMessage("Style", "VSTHRD103:Call async methods when in an async method")]
[module: SuppressMessage("Style", "VSTHRD002:Avoid problematic synchronous waits")]
[module: SuppressMessage("Style", "VSTHRD110: Observe the awaitable result of this method call by awaiting it, assigning to a variable, or passing it to another method")]
[assembly: SuppressMessage("Usage", "VSTHRD101:Avoid unsupported async delegates", Justification = "<Pending>", Scope = "member", Target = "~M:Azure.Storage.TaskThrottler.ProcessTasks")]
