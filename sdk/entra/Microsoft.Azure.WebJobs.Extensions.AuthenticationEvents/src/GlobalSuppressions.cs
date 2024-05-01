// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Usage", "AZC0007:DO provide a minimal constructor that takes only the parameters required to connect to the service.", Justification = "Seems like a misfire, as this is a simple class that does not have client options.(Perhaps the name ending in Client)", Scope = "type", Target = "~T:Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart.WebJobsAuthenticationEventsContextClient")]
