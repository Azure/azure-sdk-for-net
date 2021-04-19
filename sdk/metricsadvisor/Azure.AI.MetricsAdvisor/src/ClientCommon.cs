// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.RegularExpressions;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor
{
    internal static class ClientCommon
    {
        /// <summary>
        /// Used as part of argument validation. Attempts to create a <see cref="Guid"/> from a <c>string</c> and
        /// throws an <see cref="ArgumentException"/> in case of failure.
        /// </summary>
        /// <param name="id">The identifier to be parsed into a <see cref="Guid"/>.</param>
        /// <param name="paramName">The original parameter name of the <paramref name="id"/>. Used to create exceptions in case of failure.</param>
        /// <returns>The <see cref="Guid"/> instance created from the <paramref name="id"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="id"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Thrown when parsing fails.</exception>
        public static Guid ValidateGuid(string id, string paramName)
        {
            Argument.AssertNotNullOrEmpty(id, paramName);

            Guid guid;

            try
            {
                guid = new Guid(id);
            }
            catch (Exception ex) when (ex is FormatException || ex is OverflowException)
            {
                throw new ArgumentException($"The {paramName} must be a valid GUID.", paramName, ex);
            }

            return guid;
        }

        /// <summary>
        /// Coverts a DateTimeOffset to UTC and rounds down to the nearest full second.
        /// </summary>
        /// <param name="dateTimeOffset"></param>
        /// <returns></returns>
        public static DateTimeOffset NormalizeDateTimeOffset(DateTimeOffset dateTimeOffset)
        {
            // The service will currently reject values that are not UTC and with any fractional seconds.
            return new DateTimeOffset(dateTimeOffset.Ticks - dateTimeOffset.Ticks % 10000000, dateTimeOffset.Offset).ToOffset(TimeSpan.Zero);
        }

        private const string UnexpectedHeaderFormat = "The header returned by the service has an unexpected format.";
        private static readonly Regex s_dataFeedIdRegex = new Regex(@"/dataFeeds/(?<dataFeedId>[\d\w-]*)$", RegexOptions.Compiled, TimeSpan.FromSeconds(2));

        public static string GetDataFeedId(string location)
        {
            Match match = s_dataFeedIdRegex.Match(location);

            if (match.Success)
            {
                return match.Groups["dataFeedId"].Value;
            }
            else
            {
                throw new ArgumentException(UnexpectedHeaderFormat);
            }
        }

        private static readonly Regex s_anomalyDetectionConfigurationIdRegex = new Regex(@"/enrichment/anomalyDetection/configurations/(?<configurationId>[\d\w-]*)$", RegexOptions.Compiled, TimeSpan.FromSeconds(2));

        public static string GetAnomalyDetectionConfigurationId(string locationHeader)
        {
            Match match = s_anomalyDetectionConfigurationIdRegex.Match(locationHeader);

            if (match.Success)
            {
                return match.Groups["configurationId"].Value;
            }
            else
            {
                throw new ArgumentException(UnexpectedHeaderFormat);
            }
        }

        private static readonly Regex s_anomalyAlertConfigurationIdRegex = new Regex(@"/alert/anomaly/configurations/(?<configurationId>[\d\w-]*)$", RegexOptions.Compiled, TimeSpan.FromSeconds(2));

        public static string GetAnomalyAlertConfigurationId(string locationHeader)
        {
            Match match = s_anomalyAlertConfigurationIdRegex.Match(locationHeader);

            if (match.Success)
            {
                return match.Groups["configurationId"].Value;
            }
            else
            {
                throw new ArgumentException(UnexpectedHeaderFormat);
            }
        }

        private static readonly Regex s_hookIdRegex = new Regex(@"/hooks/(?<hookId>[\d\w-]*)$", RegexOptions.Compiled, TimeSpan.FromSeconds(2));

        public static string GetHookId(string locationHeader)
        {
            Match match = s_hookIdRegex.Match(locationHeader);

            if (match.Success)
            {
                return match.Groups["hookId"].Value;
            }
            else
            {
                throw new ArgumentException(UnexpectedHeaderFormat);
            }
        }

        private static readonly Regex s_feedbackIdRegex = new Regex(@"/feedback/metric/(?<feedbackId>[\d\w-]*)$", RegexOptions.Compiled, TimeSpan.FromSeconds(2));

        public static string GetFeedbackId(string locationHeader)
        {
            Match match = s_feedbackIdRegex.Match(locationHeader);

            if (match.Success)
            {
                return match.Groups["feedbackId"].Value;
            }
            else
            {
                throw new ArgumentException(UnexpectedHeaderFormat);
            }
        }
    }
}
