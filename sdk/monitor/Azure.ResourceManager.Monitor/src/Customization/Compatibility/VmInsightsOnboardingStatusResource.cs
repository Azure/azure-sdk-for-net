// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.Monitor
{
    /// <summary> A class representing a VM Insights onboarding status resource and its operations. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This type is no longer supported.", false)]
    public partial class VmInsightsOnboardingStatusResource : ArmResource, IJsonModel<VmInsightsOnboardingStatusData>, IPersistableModel<VmInsightsOnboardingStatusData>
    {
        /// <summary> The resource type for VM Insights onboarding status resources. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Insights/vmInsightsOnboardingStatuses";

        /// <summary> Initializes a new instance of the <see cref="VmInsightsOnboardingStatusResource"/> class for mocking. </summary>
        protected VmInsightsOnboardingStatusResource()
        {
        }

        /// <summary> Gets the resource data. </summary>
        public virtual VmInsightsOnboardingStatusData Data => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets whether the resource has data. </summary>
        public virtual bool HasData => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Creates a resource identifier for a VM Insights onboarding status resource. </summary>
        /// <param name="resourceUri"> The resource URI. </param>
        /// <returns> A resource identifier. </returns>
        public static ResourceIdentifier CreateResourceIdentifier(string resourceUri) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets the VM Insights onboarding status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The VM Insights onboarding status resource. </returns>
        public virtual Response<VmInsightsOnboardingStatusResource> Get(CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        /// <summary> Gets the VM Insights onboarding status. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> The VM Insights onboarding status resource. </returns>
        public virtual Task<Response<VmInsightsOnboardingStatusResource>> GetAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException("This API is no longer supported.");

        void IJsonModel<VmInsightsOnboardingStatusData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        VmInsightsOnboardingStatusData IJsonModel<VmInsightsOnboardingStatusData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        BinaryData IPersistableModel<VmInsightsOnboardingStatusData>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        VmInsightsOnboardingStatusData IPersistableModel<VmInsightsOnboardingStatusData>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        string IPersistableModel<VmInsightsOnboardingStatusData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
