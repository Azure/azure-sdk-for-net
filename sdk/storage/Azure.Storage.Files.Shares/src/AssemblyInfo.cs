// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Azure.Storage.Files.Shares.Tests, PublicKey=" +
    "0024000004800000940000000602000000240000525341310004000001000100d15ddcb2968829" +
    "5338af4b7686603fe614abd555e09efba8fb88ee09e1f7b1ccaeed2e8f823fa9eef3fdd60217fc" +
    "012ea67d2479751a0b8c087a4185541b851bd8b16f8d91b840e51b1cb0ba6fe647997e57429265" +
    "e85ef62d565db50a69ae1647d54d7bd855e4db3d8a91510e5bcbd0edfbbecaa20a7bd9ae74593d" +
    "aa7b11b4")]
[assembly: InternalsVisibleTo("Azure.Storage.DataMovement.Files.Shares.Tests, PublicKey=" +
    "0024000004800000940000000602000000240000525341310004000001000100d15ddcb2968829" +
    "5338af4b7686603fe614abd555e09efba8fb88ee09e1f7b1ccaeed2e8f823fa9eef3fdd60217fc" +
    "012ea67d2479751a0b8c087a4185541b851bd8b16f8d91b840e51b1cb0ba6fe647997e57429265" +
    "e85ef62d565db50a69ae1647d54d7bd855e4db3d8a91510e5bcbd0edfbbecaa20a7bd9ae74593d" +
    "aa7b11b4")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2, PublicKey=0024000004800000940000000602000000240000525341310004000001000100c547cac37abd99c8db225ef2f6c8a3602f3b3606cc9891605d02baa56104f4cfc0734aa39b93bf7852f7d9266654753cc297e7d2edfe0bac1cdcf9f717241550e0a7b191195b7667bb4f64bcb8e2121380fd1d9d46ad2d92d2d15605093924cceaf74c4861eff62abf69b9291ed0a340e113be11e6a7d3113e92484cf7045cc7")]
[assembly: Azure.Core.AzureResourceProviderNamespace("Microsoft.Storage")]

[assembly: SuppressMessage("Usage", "AZC0015:Unexpected client method return type.", Justification = "Helper method that does multiple requests", Scope = "member", Target = "~M:Azure.Storage.Files.Shares.ShareDirectoryClient.ForceCloseAllHandles(System.Nullable{System.Boolean},System.Threading.CancellationToken)~Azure.Storage.Files.Shares.Models.CloseHandlesResult")]
[assembly: SuppressMessage("Usage", "AZC0015:Unexpected client method return type.", Justification = "Helper method that does multiple requests", Scope = "member", Target = "~M:Azure.Storage.Files.Shares.ShareDirectoryClient.ForceCloseAllHandlesAsync(System.Nullable{System.Boolean},System.Threading.CancellationToken)~System.Threading.Tasks.Task{Azure.Storage.Files.Shares.Models.CloseHandlesResult}")]
[assembly: SuppressMessage("Usage", "AZC0015:Unexpected client method return type.", Justification = "Helper method that does multiple requests", Scope = "member", Target = "~M:Azure.Storage.Files.Shares.ShareFileClient.ForceCloseAllHandles(System.Threading.CancellationToken)~Azure.Storage.Files.Shares.Models.CloseHandlesResult")]
[assembly: SuppressMessage("Usage", "AZC0015:Unexpected client method return type.", Justification = "Helper method that does multiple requests", Scope = "member", Target = "~M:Azure.Storage.Files.Shares.ShareFileClient.ForceCloseAllHandlesAsync(System.Threading.CancellationToken)~System.Threading.Tasks.Task{Azure.Storage.Files.Shares.Models.CloseHandlesResult}")]
