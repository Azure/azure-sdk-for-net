// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Azure.Core;

[assembly: AzureResourceProviderNamespace("Microsoft.Search")]

[assembly: InternalsVisibleTo("Azure.Search.Documents.Tests, PublicKey=" +
    "00240000048000009400000006020000002400005253413100" +
    "04000001000100d15ddcb29688295338af4b7686603fe614ab" +
    "d555e09efba8fb88ee09e1f7b1ccaeed2e8f823fa9eef3fdd6" +
    "0217fc012ea67d2479751a0b8c087a4185541b851bd8b16f8d" +
    "91b840e51b1cb0ba6fe647997e57429265e85ef62d565db50a" +
    "69ae1647d54d7bd855e4db3d8a91510e5bcbd0edfbbecaa20a" +
    "7bd9ae74593daa7b11b4")]
[assembly: InternalsVisibleTo(
    "DynamicProxyGenAssembly2, PublicKey=" +
    "00240000048000009400000006020000002400005253413100" +
    "04000001000100c547cac37abd99c8db225ef2f6c8a3602f3b" +
    "3606cc9891605d02baa56104f4cfc0734aa39b93bf7852f7d9" +
    "266654753cc297e7d2edfe0bac1cdcf9f717241550e0a7b191" +
    "195b7667bb4f64bcb8e2121380fd1d9d46ad2d92d2d1560509" +
    "3924cceaf74c4861eff62abf69b9291ed0a340e113be11e6a7" +
    "d3113e92484cf7045cc7")]

[assembly: SuppressMessage("Usage", "AZC0012:Avoid single word type names", Justification = "Search service terminology", Scope = "type", Target = "~T:Azure.Search.Documents.Models.Analyzer")]
[assembly: SuppressMessage("Usage", "AZC0012:Avoid single word type names", Justification = "Search service terminology", Scope = "type", Target = "~T:Azure.Search.Documents.Models.Skill")]
[assembly: SuppressMessage("Usage", "AZC0012:Avoid single word type names", Justification = "Search service terminology", Scope = "type", Target = "~T:Azure.Search.Documents.Models.Skillset")]
[assembly: SuppressMessage("Usage", "AZC0012:Avoid single word type names", Justification = "Search service terminology", Scope = "type", Target = "~T:Azure.Search.Documents.Models.Suggester")]
[assembly: SuppressMessage("Usage", "AZC0012:Avoid single word type names", Justification = "Search service terminology", Scope = "type", Target = "~T:Azure.Search.Documents.Models.Tokenizer")]
