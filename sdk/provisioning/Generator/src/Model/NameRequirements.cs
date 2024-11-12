// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Provisioning.Generator.Model;

/// <summary>
/// Defines the name requirements for a resource.
/// </summary>
/// <param name="Max">Max allowed characters.</param>
/// <param name="Min">Min allowed characters.</param>
/// <param name="Lower">Whether lowercase characters are permitted.</param>
/// <param name="Upper">Whether uppercase characters are permitted.</param>
/// <param name="Numbers">Whether numeric characters are permitted.</param>
/// <param name="Hyphen">Whether hyphens are permitted.</param>
/// <param name="Underscore">Whether underscores are permitted.</param>
/// <param name="Period">Whether periods are permitted.</param>
/// <param name="Parens">Whether parentheses are permitted.</param>
public record NameRequirements(
    int Max,
    int Min = 1,
    bool Lower = false,
    bool Upper = false,
    bool Numbers = false,
    bool Hyphen = false,
    bool Underscore = false,
    bool Period = false,
    bool Parens = false);
