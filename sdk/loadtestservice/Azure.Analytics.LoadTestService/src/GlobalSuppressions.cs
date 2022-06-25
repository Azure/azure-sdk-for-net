// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Usage", "AZC0002:DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.", Justification = "CancellationToken can be passed through RequestOptions")]
[assembly: SuppressMessage("Usage", "AZC0016:Invalid ServiceVersion member name.", Justification = "Generated code: https://github.com/Azure/autorest.csharp/issues/1524")]
[assembly: SuppressMessage("Usage", "SA1402:File may only contain a single type")]

[assembly: SuppressMessage("Usage", "CA2227: Collection properties should be read only")]

[assembly: SuppressMessage("Usage", "CA1056: URI properties should not be strings")]