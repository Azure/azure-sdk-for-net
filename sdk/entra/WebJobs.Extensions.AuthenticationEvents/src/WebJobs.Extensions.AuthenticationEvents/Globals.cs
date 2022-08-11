// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using tisEvents = Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart;

[assembly: InternalsVisibleTo("WebJobs.Extensions.AuthenticationEvents.Tests, PublicKey=00240000048000009400000006020000002400005253413100040000010001002d42386f563151ae0e97bb24b0d8eb0c7af24a93308969defd0913380e1f99aacb8a58a6edd0fc77e516a1f4b263899b019424fc80c396d16f8617262df874488db44851595fd85fbc55cafc4fffc8bfb6bed5f8ebdbab514e8b657fc8c03cfcbaf033a4064fe9d1dc716e4b98531054a85f9151a9c5a4fab132124cdb1035ca")]

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    #region Global Enums
    /// <summary>Events available by event type.</summary>
    public enum EventDefinition
    {
        /// <summary>onTokenIssuanceStart event -&gt; preview 10 01 2021.</summary>
        [AuthEventMetadata(typeof(tisEvents.TokenIssuanceStartRequest),
            "onTokenIssuanceStartCustomExtension",
            "TokenIssuanceStart.preview_10_01_2021")]
        TokenIssuanceStartV20211001Preview,
        /// <summary>onTokenIssuanceStart event.</summary>
        [AuthEventMetadata(typeof(tisEvents.TokenIssuanceStartRequest),
           "microsoft.graph.authenticationEvent.TokenIssuanceStart",
           "TokenIssuanceStart", responseTemplate: "CloudEventActionableTemplate.json")]
        TokenIssuanceStart
    }

    /// <summary>Types of events to listen for and attach a function to.</summary>
    public enum EventType
    {
        /// <summary>When a token is issued, this event will be called and the ability to append claim to the token is enabled via the response.</summary>
        OnTokenIssuanceStart
    }

    /// <summary>The status of the incoming request.</summary>
    public enum AuthEventConvertStatusType
    {
        /// <summary>If there is any failures on the incoming status, the StatusMessage property will contain the reason for the failure.</summary>
        Failed,
        /// <summary>All check have passed except for the Token, which is invalid.</summary>
        TokenInvalid,
        /// <summary>Incoming request and token has passed all checks and is in a successful state.</summary>
        Successful
    }

    /// <summary>Supported Azure token schema.</summary>
    internal enum SupportedTokenSchemaVersions
    {
        /// <summary>Version 1.</summary>
        [Description("1.0")] V1_0,
        /// <summary>Version 2.</summary>
        [Description("2.0")] V2_0
    }

    /// <summary>Document Types.</summary>
    internal enum OpenAPIDocumentType
    {
        /// <summary>The open API document.</summary>
        OpenApiDocument,
        /// <summary>The request schema.</summary>
        RequestSchema,
        /// <summary>The response schema.</summary>
        ResponseSchema
    }
    #endregion
}
