// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace Azure.AI.OpenAI;

/// <summary>
/// Defines the scenario-independent, client-level options for the Azure-specific OpenAI client.
/// </summary>
public partial class AzureOpenAIClientOptions : ClientPipelineOptions
{
    internal string Version { get; }

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
    /// Initializes a new instance of <see cref="AzureOpenAIClientOptions"/>
    /// </summary>
    /// <param name="version"> The service API version to use with the client. </param>
    /// <exception cref="NotSupportedException"> The provided service API version is not supported. </exception>
    public AzureOpenAIClientOptions(ServiceVersion version = LatestVersion)
        : base()
    {
        Version = version switch
        {
#if !AZURE_OPENAI_GA
            ServiceVersion.V2024_08_01_Preview => "2024-08-01-preview",
            ServiceVersion.V2024_09_01_Preview => "2024-09-01-preview",
            ServiceVersion.V2024_10_01_Preview => "2024-10-01-preview",
#endif
            ServiceVersion.V2024_06_01 => "2024-06-01",
            _ => throw new NotSupportedException()
        };
        RetryPolicy = new RetryWithDelaysPolicy();
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
    private const ServiceVersion LatestVersion = ServiceVersion.V2024_10_01_Preview;
#else
    private const ServiceVersion LatestVersion = ServiceVersion.V2024_06_01;
#endif
}
