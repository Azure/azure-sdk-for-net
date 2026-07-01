// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Data.AppConfiguration
{
    /// <summary> The resource type used to filter the labels returned by <see cref="ConfigurationClient.GetLabels(SettingLabelSelector, System.Threading.CancellationToken)"/>. </summary>
    public enum SettingLabelResourceType
    {
        /// <summary> Filters the returned labels to those associated with key-value settings. </summary>
        KeyValue,

        /// <summary> Filters the returned labels to those associated with feature flags. </summary>
        FeatureFlag,
    }
}
