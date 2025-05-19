// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography.Cose;
using System.Threading.Tasks;
using Azure.IoT.DeviceOnboarding.Models;
using Azure.IoT.DeviceOnboarding.Models.Providers;

namespace Azure.IoT.DeviceOnboarding
{
    /// <summary>
    /// Client covering the discovery stage of the FDO process
    /// </summary>
    public class DeviceDiscoverer : FDOClient
    {
        #region Constructors
        /// <summary>
        /// Create instance of DeviceDiscoverer for mocking
        /// </summary>
        protected DeviceDiscoverer() { }

        /// <summary>
        /// Create new instance of DeviceDiscoverer for a particular rv server.
        /// </summary>
        /// <param name="rvServerUrl"></param>
        /// <param name="cborConverter"></param>
        /// <param name="credProvider"></param>
        internal DeviceDiscoverer(
            string rvServerUrl,
            CBORConverterProvider cborConverter,
            DeviceCredentialProvider credProvider)
            : base(cborConverter,credProvider)
        {
            _serverUrl = rvServerUrl;
        }

        /// <summary>
        /// Create new instance of DeviceDiscoverer for a particular rv server.
        /// </summary>
        /// <param name="rvServerUrl"></param>
        /// <param name="cborConverter"></param>
        /// <param name="credProvider"></param>
        /// <param name="options"></param>
        internal DeviceDiscoverer(
            string rvServerUrl,
            CBORConverterProvider cborConverter,
            DeviceCredentialProvider credProvider,
            DeviceOnboardingClientOptions options)
            : base(cborConverter, credProvider, options)
        {
            _serverUrl = rvServerUrl;
        }
        #endregion

        /// <summary>
        /// Get the Owner Info for TO2 by reaching out to the rv server
        /// </summary>
        /// <returns></returns>
        public TO2OwnerInfo GetOwnerInfo()
        {
            var deviceCreds = this._deviceCredentialProvider.GetDeviceCredentials();
            var eASigInfo = new SigInfo();
            var deviceKeyType = deviceCreds.DeviceKeyType;
            eASigInfo.SigInfoType = SigInfo.GetSigInfoType(deviceKeyType);
            eASigInfo.Info = Array.Empty<byte>();
            var helloRV = new TO1HelloRV()
            {
                Guid = deviceCreds.DeviceGuid,
                EASigInfo = eASigInfo
            };
            var helloRVPayload = this._CBORConverterProvider.Serialize(helloRV);
            var helloRVAckResponse = ConstructAndSendMessage(TOMessageTypes.TO1_HelloRV, helloRVPayload);
            Console.Write(helloRVAckResponse.Payload);
            Console.Write(this._CBORConverterProvider.Deserialize<ErrorMessage>(helloRVAckResponse.Payload).Message);
            AssertMessageType(helloRVAckResponse.MessageType, TOMessageTypes.TO1_HelloRVAck);

            var helloRVAck = this._CBORConverterProvider.Deserialize<TO1HelloRVAck>(helloRVAckResponse.Payload);
            var sigInfo = helloRVAck.EBSigInfo;

            var nonce = helloRVAck.NonceTO1Proof;

            var to1ProveToRv = new TO1ProveToRV()
            {
                Nonce = nonce,
                Guid = deviceCreds.DeviceGuid
            };

            var eatPayloadBytes = this._CBORConverterProvider.Serialize(to1ProveToRv);
            var coseSign1 = this._deviceCredentialProvider.CreateCoseSign1Message(eatPayloadBytes, null, deviceCreds.DeviceKeyType);
            var coseSign1Bytes = coseSign1.Encode();

            var TO1RVRedirectResponse = ConstructAndSendMessage(TOMessageTypes.TO1_ProveToRV, coseSign1Bytes);

            AssertMessageType(TO1RVRedirectResponse.MessageType, TOMessageTypes.TO1_RVRedirect);
            var coseSign1Message = CoseMessage.DecodeSign1(TO1RVRedirectResponse.Payload);
            if (coseSign1Message == null)
            {
                var msg = "Invalid Response for TO1 RV Redirect, halting execution.";
                throw new RequestFailedException(msg);
            }
            var to1dPayloadBytes = coseSign1Message.Content.Value.ToArray();
            var payload = this._CBORConverterProvider.Deserialize<TO1dPayload>(to1dPayloadBytes);
            var to2OwnerInformation = new TO2OwnerInfo
            {
                To1dPayload = payload,
                TO1dCoseSign1MessageEncoded = TO1RVRedirectResponse.Payload
            };

            return to2OwnerInformation;
        }

        /// <summary>
        /// Get the Owner Info for TO2 by reaching out to the rv server
        /// </summary>
        /// <returns></returns>
        public Task<TO2OwnerInfo> GetOwnerInfoAsync()
        {
            return Task.Run(() => GetOwnerInfo());
        }
    }
}
