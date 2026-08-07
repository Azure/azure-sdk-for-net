// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ApplicationInsights
{
    // The TypeSpec models ApplicationInsightsComponent as an ARM "custom resource"
    // (extends the hand-written ComponentsResource envelope), so the generated data
    // model would derive from ComponentsResource instead of the TrackedResourceData
    // base shipped in the GA (1.1.0) SDK. Declare the intended base here so the
    // generator emits ApplicationInsightsComponentData : TrackedResourceData.
    public partial class ApplicationInsightsComponentData : TrackedResourceData
    {
    }
}
