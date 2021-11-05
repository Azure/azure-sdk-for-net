// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using System.Threading.Tasks;
using Azure.Test.Perf;

await PerfProgram.Main(Assembly.GetEntryAssembly(), args);
await Task.Yield();
