// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using Azure.ResourceManager.HealthcareApis.Models;

namespace Azure.ResourceManager.HealthcareApis
{
    // Compatibility shim so ModelReaderWriter can serialize the GA-only FHIR access-policy model.
    [ModelReaderWriterBuildable(typeof(FhirServiceAccessPolicyEntry))]
    public partial class AzureResourceManagerHealthcareApisContext
    {
    }
}
