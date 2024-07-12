// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace Azure.AI.OpenAI;

/// <summary>
/// Defines the scenario-independent, client-level options for the Azure-specific OpenAI client.
/// </summary>
public partial class AzureOpenAIClientOptions : ClientPipelineOptions
{
    internal string Version => _version;
    private readonly string _version;

    /// <summary>
    /// Initializes a new instance of <see cref="AzureOpenAIClientOptions"/>
    /// </summary>
    /// <param name="version"> The service API version to use with the client. </param>
    /// <exception cref="NotSupportedException"> The provided service API version is not supported. </exception>
    public AzureOpenAIClientOptions(ServiceVersion version = LatestVersion)
        : base()
    {
        _version = version switch
        {
            ServiceVersion.V2024_04_01_Preview => "2024-04-01-preview",
            ServiceVersion.V2024_05_01_Preview => "2024-05-01-preview",
            ServiceVersion.V2024_06_01 => "2024-06-01",
            _ => throw new NotSupportedException()
        };
        RetryPolicy = new RetryWithDelaysPolicy();
    }

    /// <summary> The version of the service to use. </summary>
    public enum ServiceVersion
    {
        /// <summary> Service version "2024-04-01-preview". </summary>
        V2024_04_01_Preview = 7,
        V2024_05_01_Preview = 8,
        V2024_06_01 = 9,
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

           return delayFromHeader ?? DefaultDelay;
        }

        private TimeSpan DefaultDelay
        {
            get
            {
                _defaultDelay ??= TimeSpan.FromMilliseconds(800);
                return _defaultDelay.Value;
            }
        }
        private TimeSpan? _defaultDelay;
    }

    private const ServiceVersion LatestVersion = ServiceVersion.V2024_05_01_Preview;
}
