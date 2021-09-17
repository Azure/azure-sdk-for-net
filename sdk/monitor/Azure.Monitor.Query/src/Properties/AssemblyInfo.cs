// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Azure.Monitor.Query.Tests, PublicKey=0024000004800000940000000602000000240000525341310004000001000100d15ddcb29688295338af4b7686603fe614abd555e09efba8fb88ee09e1f7b1ccaeed2e8f823fa9eef3fdd60217fc012ea67d2479751a0b8c087a4185541b851bd8b16f8d91b840e51b1cb0ba6fe647997e57429265e85ef62d565db50a69ae1647d54d7bd855e4db3d8a91510e5bcbd0edfbbecaa20a7bd9ae74593daa7b11b4")]

[assembly: Azure.Core.AzureResourceProviderNamespace("Microsoft.Insights")]

[assembly: SuppressMessage("Usage", "AZC0012:Avoid single word type names", Justification = "<Pending>", Scope = "type", Target = "~T:Azure.Monitor.Query.Models.MetricResult")]
[assembly: SuppressMessage("Usage", "AZC0014:Types from System.Text.Json, Newtonsoft.Json, System.Collections.Immutable assemblies should not be exposed as part of public API surface.", Justification = "<Pending>")]
