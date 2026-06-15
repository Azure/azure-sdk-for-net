// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Monitor.Models;

namespace Azure.ResourceManager.Monitor
{
    /// <summary> VM Insights onboarding status data. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This API is no longer supported.", false)]
    public partial class VmInsightsOnboardingStatusData : ResourceData, IJsonModel<VmInsightsOnboardingStatusData>, IPersistableModel<VmInsightsOnboardingStatusData>
    {
        internal VmInsightsOnboardingStatusData()
        {
        }

        /// <summary> The resource ID. </summary>
        public ResourceIdentifier ResourceId => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> The data status. </summary>
        public DataStatus? DataStatus => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> The onboarding status. </summary>
        public OnboardingStatus? OnboardingStatus => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> The data containers. </summary>
        public IReadOnlyList<DataContainer> Data => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Writes the model as JSON. </summary>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        void IJsonModel<VmInsightsOnboardingStatusData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        VmInsightsOnboardingStatusData IJsonModel<VmInsightsOnboardingStatusData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        BinaryData IPersistableModel<VmInsightsOnboardingStatusData>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        VmInsightsOnboardingStatusData IPersistableModel<VmInsightsOnboardingStatusData>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        string IPersistableModel<VmInsightsOnboardingStatusData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
