// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.AI.Projects.Agents;

[CodeGenSuppress("FoundryOpenAIError", typeof(string), typeof(string), typeof(string), typeof(string), typeof(MisalignmentErrorDetailsResource), typeof(IEnumerable<FoundryOpenAIError>), typeof(IDictionary<string, BinaryData>), typeof(IDictionary<string, BinaryData>))]
public static partial class ProjectsAgentsModelFactory
{
    /// <summary> Initializes a new instance of <see cref="Agents.FoundryOpenAIError"/> for mocking. </summary>
    /// <param name="code"> The machine-readable error code. </param>
    /// <param name="message"> A human-readable description of the failure. </param>
    /// <param name="param"> The parameter associated with the error. </param>
    /// <param name="type"> The category of error. </param>
    /// <param name="details"> Additional errors that contributed to this failure. </param>
    /// <param name="additionalInfo"> Additional structured information about the failure. </param>
    /// <param name="debugInfo"> Diagnostic information supplied by the service for troubleshooting. </param>
    /// <returns> A new <see cref="Agents.FoundryOpenAIError"/> instance for mocking. </returns>
    public static FoundryOpenAIError FoundryOpenAIError(
        string code = default,
        string message = default,
        string param = default,
        string type = default,
        IEnumerable<FoundryOpenAIError> details = default,
        IDictionary<string, BinaryData> additionalInfo = default,
        IDictionary<string, BinaryData> debugInfo = default)
    {
        details ??= new ChangeTrackingList<FoundryOpenAIError>();
        return new FoundryOpenAIError(
            code,
            message,
            param,
            type,
            misalignment: null,
            details.ToList(),
            additionalInfo ?? new ChangeTrackingDictionary<string, BinaryData>(),
            debugInfo ?? new ChangeTrackingDictionary<string, BinaryData>(),
            additionalBinaryDataProperties: null);
    }
}
