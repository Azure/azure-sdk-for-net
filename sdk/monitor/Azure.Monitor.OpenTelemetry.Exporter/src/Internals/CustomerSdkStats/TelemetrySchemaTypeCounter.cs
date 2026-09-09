// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.CustomerSdkStats
{
    internal sealed class TelemetrySchemaTypeCounter
    {
        internal int _requestCount;
        internal int _requestSuccessCount;
        internal int _requestFailureCount;
        internal int _dependencyCount;
        internal int _dependencySuccessCount;
        internal int _dependencyFailureCount;
        internal int _exceptionCount;
        internal int _eventCount;
        internal int _metricCount;
        internal int _traceCount;
        internal int _availabilityCount;

        internal void IncrementRequest(bool? success)
        {
            _requestCount++;
            IncrementSuccessCounter(success, ref _requestSuccessCount, ref _requestFailureCount);
        }

        internal void IncrementDependency(bool? success)
        {
            _dependencyCount++;
            IncrementSuccessCounter(success, ref _dependencySuccessCount, ref _dependencyFailureCount);
        }

        internal void DecrementRequest(bool? success)
        {
            _requestCount = System.Math.Max(0, _requestCount - 1);
            DecrementSuccessCounter(success, ref _requestSuccessCount, ref _requestFailureCount);
        }

        internal void DecrementDependency(bool? success)
        {
            _dependencyCount = System.Math.Max(0, _dependencyCount - 1);
            DecrementSuccessCounter(success, ref _dependencySuccessCount, ref _dependencyFailureCount);
        }

        private static void IncrementSuccessCounter(bool? success, ref int successCount, ref int failureCount)
        {
            if (success == true)
            {
                successCount++;
            }
            else if (success == false)
            {
                failureCount++;
            }
        }

        private static void DecrementSuccessCounter(bool? success, ref int successCount, ref int failureCount)
        {
            if (success == true)
            {
                successCount = System.Math.Max(0, successCount - 1);
            }
            else if (success == false)
            {
                failureCount = System.Math.Max(0, failureCount - 1);
            }
        }
    }
}
