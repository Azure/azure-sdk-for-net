// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.ProgrammableConnectivity
{
    public partial class NumberVerification
    {
        /// <summary> Verifies the phone number (MSISDN) associated with a device. As part of the frontend authorization flow, the device is redirected to the operator network to authenticate directly. </summary>
        /// <param name="apcGatewayId"> The identifier of the APC Gateway resource which should handle this request. </param>
        /// <param name="numberVerificationWithoutCodeContent"> Request to verify number of device - first call. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apcGatewayId"/> or <paramref name="numberVerificationWithoutCodeContent"/> is null. </exception>
        /// <include file="Generated/Docs/NumberVerification.xml" path="doc/members/member[@name='VerifyWithoutCodeAsync(string,NumberVerificationWithoutCodeContent,CancellationToken)']/*" />
        public virtual async Task<Response> VerifyWithoutCodeAsync(string apcGatewayId, NumberVerificationWithoutCodeContent numberVerificationWithoutCodeContent, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(apcGatewayId, nameof(apcGatewayId));
            Argument.AssertNotNull(numberVerificationWithoutCodeContent, nameof(numberVerificationWithoutCodeContent));

            using RequestContent content = numberVerificationWithoutCodeContent.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await VerifyWithoutCodeAsync(apcGatewayId, content, context).ConfigureAwait(false);
            return response;
        }

        /// <summary> Verifies the phone number (MSISDN) associated with a device. As part of the frontend authorization flow, the device is redirected to the operator network to authenticate directly. </summary>
        /// <param name="apcGatewayId"> The identifier of the APC Gateway resource which should handle this request. </param>
        /// <param name="numberVerificationWithoutCodeContent"> Request to verify number of device - first call. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apcGatewayId"/> or <paramref name="numberVerificationWithoutCodeContent"/> is null. </exception>
        /// <include file="Generated/Docs/NumberVerification.xml" path="doc/members/member[@name='VerifyWithoutCode(string,NumberVerificationWithoutCodeContent,CancellationToken)']/*" />
        public virtual Response VerifyWithoutCode(string apcGatewayId, NumberVerificationWithoutCodeContent numberVerificationWithoutCodeContent, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(apcGatewayId, nameof(apcGatewayId));
            Argument.AssertNotNull(numberVerificationWithoutCodeContent, nameof(numberVerificationWithoutCodeContent));

            using RequestContent content = numberVerificationWithoutCodeContent.ToRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = VerifyWithoutCode(apcGatewayId, content, context);
            return response;
        }

        /// <summary>
        /// [Protocol Method] Verifies the phone number (MSISDN) associated with a device. As part of the frontend authorization flow, the device is redirected to the operator network to authenticate directly.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="VerifyWithoutCodeAsync(string,NumberVerificationWithoutCodeContent,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="apcGatewayId"> The identifier of the APC Gateway resource which should handle this request. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apcGatewayId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Generated/Docs/NumberVerification.xml" path="doc/members/member[@name='VerifyWithoutCodeAsync(string,RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> VerifyWithoutCodeAsync(string apcGatewayId, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(apcGatewayId, nameof(apcGatewayId));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("NumberVerification.VerifyWithoutCode");
            scope.Start();
            try
            {
                using HttpMessage message = CreateVerifyWithoutCodeRequest(apcGatewayId, content, context);
                RedirectPolicy.SetAllowAutoRedirect(message, false);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Verifies the phone number (MSISDN) associated with a device. As part of the frontend authorization flow, the device is redirected to the operator network to authenticate directly.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="VerifyWithoutCode(string,NumberVerificationWithoutCodeContent,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="apcGatewayId"> The identifier of the APC Gateway resource which should handle this request. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apcGatewayId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Generated/Docs/NumberVerification.xml" path="doc/members/member[@name='VerifyWithoutCode(string,RequestContent,RequestContext)']/*" />
        public virtual Response VerifyWithoutCode(string apcGatewayId, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(apcGatewayId, nameof(apcGatewayId));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("NumberVerification.VerifyWithoutCode");
            scope.Start();
            try
            {
                using HttpMessage message = CreateVerifyWithoutCodeRequest(apcGatewayId, content, context);
                RedirectPolicy.SetAllowAutoRedirect(message, false);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}