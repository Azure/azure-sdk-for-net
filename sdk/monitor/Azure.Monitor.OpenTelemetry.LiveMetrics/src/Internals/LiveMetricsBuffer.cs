// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals
{
    internal class LiveMetricsBuffer
    {
        // REQUEST
        internal long RequestsCount;
        internal double RequestsDuration;
        internal long RequestsSuccededCount;
        internal long RequestsFailedCount;

        // DEPENDENCY
        internal long DependenciesCount;
        internal double DependenciesDuration;
        internal long DependenciesSuccededCount;
        internal long DependenciesFailedCount;

        // EXCEPTIONS
        internal long ExceptionsCount;

        public void RecordRequestSucceeded(double duration)
        {
            RequestsCount++;
            RequestsDuration += duration;
            RequestsSuccededCount++;
        }

        public void RecordRequestFailed(double duration)
        {
            RequestsCount++;
            RequestsDuration += duration;
            RequestsFailedCount++;
        }

        public void RecordDependencySucceeded(double duration)
        {
            DependenciesCount++;
            DependenciesDuration += duration;
            DependenciesSuccededCount++;
        }

        public void RecordDependencyFailed(double duration)
        {
            DependenciesCount++;
            DependenciesDuration += duration;
            DependenciesFailedCount++;
        }

        public void RecordException()
        {
            ExceptionsCount++;
        }
    }
}
