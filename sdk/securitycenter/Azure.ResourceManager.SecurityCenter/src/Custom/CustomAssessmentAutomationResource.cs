// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591 // Hidden obsolete compatibility shims do not need public docs.

using System;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.SecurityCenter;
using Azure.ResourceManager.SecurityCenter.Mocking;
using Azure.ResourceManager.SecurityCenter.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter
{
    [Obsolete("This API is no longer supported by the service.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class CustomAssessmentAutomationResource : ArmResource, IJsonModel<CustomAssessmentAutomationData>, IPersistableModel<CustomAssessmentAutomationData>
    {
        public static readonly ResourceType ResourceType;
        protected CustomAssessmentAutomationResource() { }
        public virtual CustomAssessmentAutomationData Data { get { throw new NotSupportedException("This API is no longer supported by the service."); } }
        public virtual bool HasData { get { throw new NotSupportedException("This API is no longer supported by the service."); } }
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string customAssessmentAutomationName) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual Response<CustomAssessmentAutomationResource> Get(CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual Task<Response<CustomAssessmentAutomationResource>> GetAsync(CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        CustomAssessmentAutomationData IJsonModel<CustomAssessmentAutomationData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<CustomAssessmentAutomationData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        CustomAssessmentAutomationData IPersistableModel<CustomAssessmentAutomationData>.Create(BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<CustomAssessmentAutomationData>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        BinaryData IPersistableModel<CustomAssessmentAutomationData>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual ArmOperation<CustomAssessmentAutomationResource> Update(WaitUntil waitUntil, CustomAssessmentAutomationCreateOrUpdateContent content, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
        public virtual Task<ArmOperation<CustomAssessmentAutomationResource>> UpdateAsync(WaitUntil waitUntil, CustomAssessmentAutomationCreateOrUpdateContent content, CancellationToken cancellationToken = default(CancellationToken)) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
