// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NET6_0
using System.Reflection;
using Azure.Test.Perf;

await PerfProgram.Main(Assembly.GetEntryAssembly(), args);
#endif
