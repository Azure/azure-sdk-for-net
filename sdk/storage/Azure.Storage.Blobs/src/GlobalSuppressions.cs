// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Usage", "AZC0004: DO provide both asynchronous and synchronous variants for all service methods.", Justification = "")]
[assembly: SuppressMessage("Usage", "AZC0002: Client method should have an optional CancellationToken (both name and it being optional matters) or a RequestContext as the last parameter.", Justification = "")]