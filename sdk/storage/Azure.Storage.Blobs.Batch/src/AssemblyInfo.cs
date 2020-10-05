// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Azure.Storage.Blobs.Batch.Tests, PublicKey=" +
    "0024000004800000940000000602000000240000525341310004000001000100d15ddcb2968829" +
    "5338af4b7686603fe614abd555e09efba8fb88ee09e1f7b1ccaeed2e8f823fa9eef3fdd60217fc" +
    "012ea67d2479751a0b8c087a4185541b851bd8b16f8d91b840e51b1cb0ba6fe647997e57429265" +
    "e85ef62d565db50a69ae1647d54d7bd855e4db3d8a91510e5bcbd0edfbbecaa20a7bd9ae74593d" +
    "aa7b11b4")]
[assembly: Azure.Core.AzureResourceProviderNamespace("Microsoft.Storage")]
[assembly: SuppressMessage("Usage", "AZC0015:Unexpected client method return type.", Justification = "Batch client is exempted from normal return type rules.")]
