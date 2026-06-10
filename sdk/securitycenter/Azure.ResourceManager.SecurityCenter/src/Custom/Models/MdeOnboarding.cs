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

namespace Azure.ResourceManager.SecurityCenter.Models
{
    [Obsolete("This API is no longer supported by the service.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class MdeOnboarding : ResourceData, IJsonModel<MdeOnboarding>, IPersistableModel<MdeOnboarding>
    {
        public MdeOnboarding() { }
        public byte[] OnboardingPackageLinux { get { throw new NotSupportedException("This API is no longer supported by the service."); } set { throw new NotSupportedException("This API is no longer supported by the service."); } }
        public byte[] OnboardingPackageWindows { get { throw new NotSupportedException("This API is no longer supported by the service."); } set { throw new NotSupportedException("This API is no longer supported by the service."); } }
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        MdeOnboarding IJsonModel<MdeOnboarding>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<MdeOnboarding>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        MdeOnboarding IPersistableModel<MdeOnboarding>.Create(BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<MdeOnboarding>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        BinaryData IPersistableModel<MdeOnboarding>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
}
