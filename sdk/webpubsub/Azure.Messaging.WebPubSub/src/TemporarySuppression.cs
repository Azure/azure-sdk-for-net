// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

// the current version of the generator will generate aspdotnet extension methods for internal classes which leads to compilation errors
// temporarily add this suppression until the issue https://github.com/Azure/autorest.csharp/issues/3122 is resolved.
[assembly: CodeGenSuppressType("WebPubSubServiceClientBuilderExtensions")]
