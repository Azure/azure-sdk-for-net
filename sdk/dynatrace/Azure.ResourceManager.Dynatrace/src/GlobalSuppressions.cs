// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

// Suppress AZC0030 for generated model types whose names match the service contract.
// Renaming would cause a breaking change and diverge from the REST schema.
[assembly: SuppressMessage("Naming", "AZC0030:Improper model name suffix", Justification = "Generated model name matches service contract; changing would be a breaking change.", Scope = "type", Target = "~T:Azure.ResourceManager.Dynatrace.Models.MarketplaceSaaSResourceDetailsResponse")]
[assembly: SuppressMessage("Naming", "AZC0030:Improper model name suffix", Justification = "Generated model name matches service contract; changing would be a breaking change.", Scope = "type", Target = "~T:Azure.ResourceManager.Dynatrace.Models.MetricsStatusResponse")]