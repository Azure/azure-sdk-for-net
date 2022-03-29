// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

#pragma warning disable AZC0011 // Internal visible to product libraries effectively become public API and have to be versioned appropriately
//
// Referenced Members:
//  - EventHubProducerClient::GetPartitionPublishingPropertiesAsync
//  - EventHubProducerClientOptions::EnableIdempotentPartitions
//
// Shadow Types:
//  - PartitionPublishingOptionsInternal
//  - PartitionPublishingPropertiesInternal
//
[assembly: InternalsVisibleTo("Azure.Messaging.EventHubs.Experimental, PublicKey=0024000004800000940000000602000000240000525341310004000001000100097AD52ABBEAA2E1A1982747CC0106534F65CFEA6707EAED696A3A63DAEA80DE2512746801A7E47F88E7781E71AF960D89BA2E25561F70B0E2DBC93319E0AF1961A719CCF5A4D28709B2B57A5D29B7C09DC8D269A490EBE2651C4B6E6738C27C5FB2C02469FE9757F0A3479AC310D6588A50A28D7DD431B907FD325E18B9E8ED")]
[assembly: InternalsVisibleTo("Azure.Messaging.EventHubs.Experimental.Tests, PublicKey=0024000004800000940000000602000000240000525341310004000001000100d15ddcb29688295338af4b7686603fe614abd555e09efba8fb88ee09e1f7b1ccaeed2e8f823fa9eef3fdd60217fc012ea67d2479751a0b8c087a4185541b851bd8b16f8d91b840e51b1cb0ba6fe647997e57429265e85ef62d565db50a69ae1647d54d7bd855e4db3d8a91510e5bcbd0edfbbecaa20a7bd9ae74593daa7b11b4")]
#pragma warning restore AZC0011 // Internal visible to product libraries effectively become public API and have to be versioned appropriately

[assembly: InternalsVisibleTo("Azure.Messaging.EventHubs.Tests, PublicKey=0024000004800000940000000602000000240000525341310004000001000100d15ddcb29688295338af4b7686603fe614abd555e09efba8fb88ee09e1f7b1ccaeed2e8f823fa9eef3fdd60217fc012ea67d2479751a0b8c087a4185541b851bd8b16f8d91b840e51b1cb0ba6fe647997e57429265e85ef62d565db50a69ae1647d54d7bd855e4db3d8a91510e5bcbd0edfbbecaa20a7bd9ae74593daa7b11b4")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2, PublicKey=0024000004800000940000000602000000240000525341310004000001000100c547cac37abd99c8db225ef2f6c8a3602f3b3606cc9891605d02baa56104f4cfc0734aa39b93bf7852f7d9266654753cc297e7d2edfe0bac1cdcf9f717241550e0a7b191195b7667bb4f64bcb8e2121380fd1d9d46ad2d92d2d15605093924cceaf74c4861eff62abf69b9291ed0a340e113be11e6a7d3113e92484cf7045cc7")]

[assembly: SuppressMessage("Usage", "AZC0004:DO provide both asynchronous and synchronous variants for all service methods.", Justification = "As an AMQP-based offering, Event Hubs has been exempted from providing a synchronous surface.")]
[assembly: SuppressMessage("Usage", "AZC0008:ClientOptions should have a nested enum called ServiceVersion", Justification = "The Event Hubs interface does not support the concept of versions.")]
[assembly: SuppressMessage("Usage", "AZC0006:DO provide constructor overloads that allow specifying additional options.", Justification = "Analysis is flagging incorrectly. The Event Hubs constructor patterns adhere to guidance and have obtained board approval.")]
[assembly: SuppressMessage("Usage", "AZC0015:Unexpected client method return type.", Justification = "As an AMQP-based offering, Event Hubs has been exempted from HTTP-based return types.")]
