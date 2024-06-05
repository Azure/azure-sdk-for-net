﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using Azure.AI.OpenAI.Chat;
using Azure.AI.OpenAI.Internal;
using OpenAI.Chat;

namespace Azure.AI.OpenAI;

public static partial class AzureChatCompletionOptionsExtensions
{
    [Experimental("AOAI001")]
    public static void AddDataSource(this ChatCompletionOptions options, AzureChatDataSource dataSource)
    {
        options._serializedAdditionalRawData ??= new ChangeTrackingDictionary<string, BinaryData>();
        IList<AzureChatDataSource> existingSources
            = AdditionalPropertyHelpers.GetAdditionalListProperty<AzureChatDataSource>(
                options._serializedAdditionalRawData,
                "data_sources")
            ?? new ChangeTrackingList<AzureChatDataSource>();
        existingSources.Add(dataSource);
        AdditionalPropertyHelpers.SetAdditionalProperty(
            options._serializedAdditionalRawData,
            "data_sources",
            existingSources);
    }

    [Experimental("AOAI001")]
    public static IReadOnlyList<AzureChatDataSource> GetDataSources(this ChatCompletionOptions options)
    {
        return AdditionalPropertyHelpers.GetAdditionalListProperty<AzureChatDataSource>(
            options._serializedAdditionalRawData,
            "data_sources") as IReadOnlyList<AzureChatDataSource>;
    }
}
