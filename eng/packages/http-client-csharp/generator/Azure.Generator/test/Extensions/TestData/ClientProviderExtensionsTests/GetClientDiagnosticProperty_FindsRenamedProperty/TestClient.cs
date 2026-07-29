// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Samples
{
    internal partial class TestClient
    {
        [CodeGenMember("ClientDiagnostics")]
        internal ClientDiagnostics RenamedDiagnostics { get; }
    }
}
