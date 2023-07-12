// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Usage", "AZC0002:DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.", Justification = "CancellationToken can be passed through RequestOptions")]
[assembly: SuppressMessage("Usage", "AZC0018: Protocol method should have requestContext as the last parameter and don't have model as parameter type or return type. Protocol method should not have optional parameters if ambiguity exists between protocol method and convenience method.", Justification = "CancellationToken can be passed through RequestOptions")]
