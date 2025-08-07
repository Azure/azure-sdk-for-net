// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Security.Cryptography;

[assembly: SuppressMessage("Usage", "AZC0030:Model name 'ExitOptions' ends with 'Options'. Suggest to rename it to 'ExitConfig' or any other appropriate name.", Justification = "SDK Review Approved, ExitCodeMapping and ExitCodeRangeMapping models have parameter called exitOptions which we wanted to match", Scope = "namespaceanddescendants", Target = "~N:Azure.Compute.Batch")]
