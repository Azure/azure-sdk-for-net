// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Naming", "AZC0030:Improper model name suffix", Justification = "Other 'Options' are used in this library, and this naming is consistent with the same feature across other SDK languages", Scope = "type", Target = "~T:Azure.Communication.PhoneNumbers.OperatorInformationOptions")]
[assembly: SuppressMessage("Naming", "AZC0030:Improper model name suffix", Justification = "Other 'Requests' are used in this library, and this naming is consistent with the same feature across other SDK languages", Scope = "type", Target = "~T:Azure.Communication.PhoneNumbers.PhoneNumberBrowseCapabilitiesRequest")]
