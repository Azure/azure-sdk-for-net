﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.OpenAI.Files;
using Azure.AI.OpenAI.RealtimeConversation;
using System.ClientModel.Primitives;

namespace Azure.AI.OpenAI;

#pragma warning disable AOAI001

/// <summary>
/// Defines the scenario-independent, client-level options for the Azure-specific OpenAI client.
/// </summary>
public partial class AzureOpenAIClientOptions : ClientPipelineOptions
{
    internal ServiceVersion? ExplicitVersion { get; }

    /// <summary>
    /// The authorization audience to use when authenticating with Azure authentication tokens
    /// </summary>
    /// <remarks>
    /// By default, the public Azure cloud will be used to authenticate tokens. Modify this value to authenticate tokens
    /// with other clouds like Azure Government.
    /// </remarks>
    public AzureOpenAIAudience? Audience
    {
        get => _authorizationAudience;
        set
        {
            AssertNotFrozen();
            _authorizationAudience = value;
        }
    }
    private AzureOpenAIAudience? _authorizationAudience;

    /// <summary>
    /// An optional application ID to use as part of the request User-Agent header.
    /// </summary>
    public string UserAgentApplicationId
    {
        get => _userAgentApplicationId;
        set
        {
            AssertNotFrozen();
            _userAgentApplicationId = value;
        }
    }
    private string _userAgentApplicationId;

    /// <summary>
    /// Initializes a new instance of <see cref="AzureOpenAIClientOptions"/>.
    /// </summary>
    /// <remarks>
    /// When using this constructor, the best matching service API version will automatically be selected. This is
    /// typically the latest service API version available when the library is published. To specify a service API
    /// version manually, use the <see cref="AzureOpenAIClientOptions(ServiceVersion)"/> overload, instead.
    /// </remarks>
    public AzureOpenAIClientOptions()
        : base()
    {
        RetryPolicy = new RetryWithDelaysPolicy();
    }

    /// <summary>
    /// Initializes a new instance of <see cref="AzureOpenAIClientOptions"/>.
    /// </summary>
    /// <remarks>
    /// This overload will attempt to use a specific service API version label that may differ from the preferred
    /// default. Please note that operation behavior may differ when using non-default service API versions.
    /// </remarks>
    /// <param name="version"> The service API version to use with the client. </param>
    public AzureOpenAIClientOptions(ServiceVersion version)
        : this()
    {
        ExplicitVersion = version;
    }

    /// <summary> The version of the service to use. </summary>
    public enum ServiceVersion
    {
        V2024_06_01 = 0,
#if !AZURE_OPENAI_GA
        V2024_08_01_Preview = 1,
        V2024_09_01_Preview = 2,
        V2024_10_01_Preview = 3,
#endif
        V2024_10_21 = 4,
#if !AZURE_OPENAI_GA
        V2024_12_01_Preview = 5,
        V2025_01_01_Preview = 6,
#endif
    }

    private static string GetStringForVersion(ServiceVersion version)
    {
        return version switch
        {
            ServiceVersion.V2024_06_01 => "2024-06-01",
#if !AZURE_OPENAI_GA
            ServiceVersion.V2024_08_01_Preview => "2024-08-01-preview",
            ServiceVersion.V2024_09_01_Preview => "2024-09-01-preview",
            ServiceVersion.V2024_10_01_Preview => "2024-10-01-preview",
#endif
            ServiceVersion.V2024_10_21 => "2024-10-21",
#if !AZURE_OPENAI_GA
            ServiceVersion.V2024_12_01_Preview => "2024-12-01-preview",
            ServiceVersion.V2025_01_01_Preview => "2025-01-01-preview",
#endif
            _ => throw new NotSupportedException($"The specified {nameof(ServiceVersion)} value ({version}) is not supported.")
        };
    }

    internal string GetRawServiceApiValueForClient(object client)
    {
        if (ExplicitVersion.HasValue)
        {
            return GetStringForVersion(ExplicitVersion.Value);
        }
        else
        {
            ServiceVersion defaultVersion = client switch
            {
#if !AZURE_OPENAI_GA
                // Realtime (preview only) is currently *only* supported on 2024-10-01-preview; override default
                // version selection for optimal out-of-the-box support if it's not explicitly specified.
                AzureRealtimeConversationClient _ => ServiceVersion.V2024_10_01_Preview,
#endif
#if !AZURE_OPENAI_GA
                // Standard default for beta libraries: latest preview version
                _ => ServiceVersion.V2025_01_01_Preview,
#else
                // Standard default for GA libraries: latest stable version
                _ => ServiceVersion.V2024_10_21,
#endif
            };
            return GetStringForVersion(defaultVersion);
        }
    }

    internal class RetryWithDelaysPolicy : ClientRetryPolicy
    {
        protected override TimeSpan GetNextDelay(PipelineMessage message, int tryCount)
        {
            TimeSpan? TryGetTimeSpanFromHeader(string headerName, int millisecondsPerValue = 1, bool allowDateTimeOffset = false)
            {
                if (double.TryParse(
                    message?.Response?.Headers?.TryGetValue(headerName, out string textValue) == true ? textValue : null,
                    out double doubleValue) == true)
                {
                    return TimeSpan.FromMilliseconds(millisecondsPerValue * doubleValue);
                }
                else if (allowDateTimeOffset && DateTimeOffset.TryParse(headerName, out DateTimeOffset delayUntil))
                {
                    return delayUntil - DateTimeOffset.Now;
                }
                return null;
            }

            TimeSpan? delayFromHeader =
                TryGetTimeSpanFromHeader("retry-after-ms")
                ?? TryGetTimeSpanFromHeader("x-ms-retry-after-ms")
                ?? TryGetTimeSpanFromHeader("Retry-After", millisecondsPerValue: 1000, allowDateTimeOffset: true);

            return delayFromHeader ?? base.GetNextDelay(message, tryCount);
        }
    }

#if !AZURE_OPENAI_GA
    private const ServiceVersion LatestVersion = ServiceVersion.V2025_01_01_Preview;
#else
    private const ServiceVersion LatestVersion = ServiceVersion.V2024_10_21;
#endif
}
