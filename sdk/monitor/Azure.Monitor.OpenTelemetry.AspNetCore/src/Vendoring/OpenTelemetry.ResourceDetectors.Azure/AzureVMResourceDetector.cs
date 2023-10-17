// <copyright file="AzureVMResourceDetector.cs" company="OpenTelemetry Authors">
// Copyright The OpenTelemetry Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

#nullable enable

using System.Collections.Generic;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace OpenTelemetry.ResourceDetectors.Azure;

/// <summary>
/// Resource detector for Azure VM environment.
/// </summary>
internal sealed class AzureVMResourceDetector : IResourceDetector
{
    internal static readonly IReadOnlyCollection<string> ExpectedAzureAmsFields = new string[]
    {
        ResourceAttributeConstants.AzureVmScaleSetName,
        ResourceAttributeConstants.AzureVmSku,
        ResourceSemanticConventions.AttributeCloudPlatform,
        ResourceSemanticConventions.AttributeCloudProvider,
        ResourceSemanticConventions.AttributeCloudRegion,
        ResourceSemanticConventions.AttributeCloudResourceId,
        ResourceSemanticConventions.AttributeHostId,
        ResourceSemanticConventions.AttributeHostName,
        ResourceSemanticConventions.AttributeHostType,
        ResourceSemanticConventions.AttributeOsType,
        ResourceSemanticConventions.AttributeOsVersion,
        ResourceSemanticConventions.AttributeServiceInstance,
    };

    private static Resource? vmResource;

    /// <inheritdoc/>
    public Resource Detect()
    {
        try
        {
            if (vmResource != null)
            {
                return vmResource;
            }

            // Prevents the http operations from being instrumented.
            using var scope = SuppressInstrumentationScope.Begin();

            var vmMetaDataResponse = AzureVmMetaDataRequestor.GetAzureVmMetaDataResponse();
            if (vmMetaDataResponse == null)
            {
                vmResource = Resource.Empty;

                return vmResource;
            }

            var attributeList = new List<KeyValuePair<string, object>>(ExpectedAzureAmsFields.Count);
            foreach (var field in ExpectedAzureAmsFields)
            {
                attributeList.Add(new KeyValuePair<string, object>(field, vmMetaDataResponse.GetValueForField(field)));
            }

            vmResource = new Resource(attributeList);
        }
        catch
        {
            // TODO: log exception.
            vmResource = Resource.Empty;
        }

        return vmResource;
    }
}
