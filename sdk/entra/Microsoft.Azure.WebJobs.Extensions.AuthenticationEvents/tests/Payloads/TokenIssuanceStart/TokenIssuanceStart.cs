// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Tests.Payloads.TokenIssuanceStart
{
    /// <summary>Test data for the Token Issuance Start</summary>
    public static class TokenIssuanceStart
    {
        /// <summary>Gets the no action response.</summary>
        /// <value>The no action response.</value>
        public static string NoActionResponse
        {
            get
            {
                return PayloadHelper.GetPayload("TokenIssuanceStart.NoActionResponse.json");
            }
        }
        /// <summary>Gets the invalid action response.</summary>
        /// <value>The invalid action response.</value>
        public static string InvalidActionResponse
        {
            get
            {
                return PayloadHelper.GetPayload("TokenIssuanceStart.InvalidActionResponse.json");

            }
        }
        /// <summary>Mocks the data expected from the function execution.</summary>
        /// <value>The function response.</value>
        public static string ActionResponse
        {
            get
            {
                return PayloadHelper.GetPayload("TokenIssuanceStart.CloudEventActionResponse.json");
            }
        }

        /// <summary>Gets the expected payload.</summary>
        /// <value>The expected payload.</value>
        public static string ExpectedPayload
        {
            get
            {
                return PayloadHelper.GetPayload("TokenIssuanceStart.ExpectedPayload.json");
            }
        }

        /// <summary>Mocks the data expected from the function execution that will be converted by yhe EventResponseHandler to an IActionResult.</summary>
        /// <value>The function response.</value>
        public static string ConversionPayload
        {
            get
            {
                return PayloadHelper.GetPayload("TokenIssuanceStart.ConversionPayload.json");
            }
        }
        /// <summary>Gets the token issuance start query parameter expected payload</summary>
        /// <value>The token issuance start query parameter.</value>
        public static string TokenIssuanceStartQueryParameter
        {
            get
            {
                return PayloadHelper.GetPayload("TokenIssuanceStart.QueryParameters.json");
            }
        }

        /// <summary> Gets the payload error message when response is set to null </summary>
        /// <value> The payload with error message </value>
        public static string NullResponsePayload
        {
            get
            {
                return PayloadHelper.GetPayload("TokenIssuanceStart.NullResponse.json");
            }
        }

        /// <summary> Gets the valid request payload </summary>
        public static string ValidRequestPayload
        {
            get
            {
                return PayloadHelper.GetPayload("TokenIssuanceStart.ValidRequest.json");
            }
        }

        /// <summary> Gets the request payload without source field </summary>
        public static string RequestWithoutSourcePayload
        {
            get
            {
                return PayloadHelper.GetPayload("TokenIssuanceStart.RequestMissingSource.json");
            }
        }

        /// <summary> Gets the request payload without ODataType field </summary>
        public static string RequestWithoutODataTypePayload
        {
            get
            {
                return PayloadHelper.GetPayload("TokenIssuanceStart.RequestMissingODataType.json");
            }
        }

        /// <summary> Gets the request payload with invalid json structure </summary>
        public static string RequestWithInvalidCharacter
        {
            get
            {
                return PayloadHelper.GetPayload("TokenIssuanceStart.InvalidJsonRequest.json");
            }
        }

        /// <summary> Gets the request payload with XML structure </summary>
        public static string RequestWithXmlBody
        {
            get
            {
                return PayloadHelper.GetPayload("TokenIssuanceStart.InvalidXmlRequest.xml");
            }
        }
    }
}
