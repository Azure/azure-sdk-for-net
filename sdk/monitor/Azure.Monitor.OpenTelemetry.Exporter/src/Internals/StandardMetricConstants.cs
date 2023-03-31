// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal class StandardMetricConstants
    {
        internal const string StandardMetricMeterName = "StandardMetricMeter";
        internal const string RequestDurationInstrumentName = "RequestDurationStandardMetric";
        internal const string DependencyDurationInstrumentName = "DependencyDurationStandardMetric";

        // request duration keys and values
        internal const string RequestDurationMetricIdValue = "requests/duration";
        internal const string RequestSuccessKey = "Request.Success";
        internal const string RequestResultCodeKey = "request/resultCode";

        // dependency duration keys and values
        internal const string DependencyDurationMetricIdValue = "dependencies/duration";
        internal const string DependencySuccessKey = "Dependency.Success";
        internal const string DependencyResultCodeKey = "dependency/resultCode";
        internal const string DependencyTypeKey = "Dependency.Type";
        internal const string DependencyTargetKey = "dependency/target";

        //common keys
        internal const string IsSyntheticKey = "operation/synthetic";
        internal const string IsAutoCollectedKey = "_MS.IsAutocollected";
        internal const string CloudRoleNameKey = "cloud/roleName";
        internal const string CloudRoleInstanceKey = "cloud/roleInstance";
        internal const string MetricIdKey = "_MS.MetricId";
    }
}
