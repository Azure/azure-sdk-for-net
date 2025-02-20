// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

// some clients' constructors have been customized and the generated aspdotnet extension is using the old constructor which leads to compilation error
// until this issue is fixed in the generator, the generated aspdotnet extension class is suppressed here to temporarily solve this
[assembly: CodeGenSuppressType("SecurityConfidentialLedgerClientBuilderExtensions")]
