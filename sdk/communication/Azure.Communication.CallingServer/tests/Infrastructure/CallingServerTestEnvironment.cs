// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using Azure.Communication.Tests;
using Azure.Core.TestFramework;

namespace Azure.Communication.CallingServer.Tests
{
    /// <summary>
    /// A helper class used to retrieve information to be used for tests.
    /// </summary>
    public class CallingServerTestEnvironment : CommunicationTestEnvironment
    {
        /// <summary>
        /// The phone number associated with the source.
        /// </summary>
        public string SourcePhoneNumber => GetRecordedVariable(AzurePhoneNumber, options => options.IsSecret());

        /// <summary>
        /// The phone number associated with the source.
        /// </summary>
        public string TargetPhoneNumber => GetRecordedVariable(AzurePhoneNumber, options => options.IsSecret());

        /// <summary>
        /// The audio file name of the play prompt.
        /// </summary>
        public string AudioFileName => "sample-message.wav";

        /// <summary>
        /// The secret for validating incoming request.
        /// </summary>
        public string IncomingRequestSecret => "helloworld";

        /// <summary>
        /// The base url of the applicaiton.
        /// </summary>
        public string AppBaseUrl => "https://dummy.ngrok.io";

        /// <summary>
        /// The callback url of the application where notification would be received.
        /// </summary>
        public string AppCallbackUrl => $"{AppBaseUrl}/api/incident/callback?SecretKey={WebUtility.UrlEncode(IncomingRequestSecret)}";

        /// <summary>
        /// The publicly available url of the audio file which would be played as a prompt.
        /// </summary>
        public string AudioFileUrl => $"{AppBaseUrl}/audio/{AudioFileName}";
    }
}
