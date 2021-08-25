// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using Azure.Test.Perf;

// Allow the framework to execute the test scenarios.

await PerfProgram.Main(Assembly.GetEntryAssembly(), args);
