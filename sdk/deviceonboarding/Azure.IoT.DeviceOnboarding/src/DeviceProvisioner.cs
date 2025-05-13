// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.Cose;
using System.Threading.Tasks;
using Azure.IoT.DeviceOnboarding.Models;
using Azure.IoT.DeviceOnboarding.Models.Providers;

namespace Azure.IoT.DeviceOnboarding
{
    /// <summary>
    /// Client covering provisioning stage of the FDO process
    /// </summary>
    public class DeviceProvisioner : FDOClient
    {
        /// <summary>
        /// Maximum OV Entries
        /// </summary>
        private const int MaxOVEntries = 256;

        /// <summary>
        /// Maximum Round Trips for TO2
        /// </summary>
        private const int TO2MaxRoundTrips = 100;

        /// <summary>
        /// Response from TO1.RVRedirect used in TO2.ProveOVHDR
        /// </summary>
        private TO2OwnerInfo _tO2OwnerInfo;

        private Dictionary<string, BaseServiceInfoModuleDevice> _registeredModules;

        #region Constructors

        /// <summary>
        /// Create instance of DeviceProvisioner for mocking
        /// </summary>
        protected DeviceProvisioner() { }

        /// <summary>
        /// Create a new instance of DeviceProvisioner for a particular owner server
        /// </summary>
        /// <param name="ownerServerUrl"></param>
        /// <param name="ownerInfo"></param>
        /// <param name="registeredModules"></param>
        /// <param name="cborConverter"></param>
        /// <param name="credProvider"></param>
        internal DeviceProvisioner(
            string ownerServerUrl,
            TO2OwnerInfo ownerInfo,
            Dictionary<string, BaseServiceInfoModuleDevice> registeredModules,
            CBORConverterProvider cborConverter,
            DeviceCredentialProvider credProvider)
            : base(cborConverter, credProvider)
        {
            _serverUrl = ownerServerUrl;
            _tO2OwnerInfo = ownerInfo;
            _registeredModules = registeredModules;
        }

        /// <summary>
        /// Create a new instance of DeviceProvisioner for a particular owner server
        /// </summary>
        /// <param name="ownerServerUrl"></param>
        /// <param name="ownerInfo"></param>
        /// <param name="registeredModules"></param>
        /// <param name="cborConverter"></param>
        /// <param name="credProvider"></param>
        /// <param name="options"></param>
        internal DeviceProvisioner(
            string ownerServerUrl,
            TO2OwnerInfo ownerInfo,
            Dictionary<string, BaseServiceInfoModuleDevice> registeredModules,
            CBORConverterProvider cborConverter,
            DeviceCredentialProvider credProvider,
            DeviceOnboardingClientOptions options)
            : base(cborConverter, credProvider, options)
        {
            _serverUrl = ownerServerUrl;
            _tO2OwnerInfo = ownerInfo;
            _registeredModules = registeredModules;
        }
        #endregion

        /// <summary>
        /// Update ownership of device
        /// </summary>
        public void UpdateDeviceOwner()
        {
            var deviceCreds = this._deviceCredentialProvider.GetDeviceCredentials();
            var to2Hello = new TO2HelloDevice();

            to2Hello.CipherSuiteType = CipherSuiteType.A256GCM;
            to2Hello.KexSuiteName = "ECDH256";

            to2Hello.MaxMessageSize = 0;
            to2Hello.NonceProveTo2Ov = FDONonce.FromRandomUuid();
            to2Hello.Guid = deviceCreds.DeviceGuid;

            var eASigInfo = new SigInfo();
            var deviceKeyType = deviceCreds.DeviceKeyType;
            eASigInfo.SigInfoType = SigInfo.GetSigInfoType(deviceKeyType);
            eASigInfo.Info = Array.Empty<byte>();
            to2Hello.EASigInfo = eASigInfo;
            var to2HelloPayload = this._CBORConverterProvider.Serialize(to2Hello);

            var proveOVHeaderResponse = ConstructAndSendMessage(TOMessageTypes.TO2_HelloDevice, to2HelloPayload);

            AssertMessageType(proveOVHeaderResponse.MessageType, TOMessageTypes.TO2_ProveOVHdr);
            //Decode TO2_ProveOVHdr CoseSign1 Signature
            var coseSign1Message = CoseMessage.DecodeSign1(proveOVHeaderResponse.Payload);
            if (coseSign1Message == null)
            {
                throw new RequestFailedException("Invalid Response for TO2 Hello Device, halting execution.");
            }
            var to1dPayloadBytes = coseSign1Message.Content.Value.ToArray();
            var proveOVHdr = this._CBORConverterProvider.Deserialize<TO2ProveOVHeaderPayload>(to1dPayloadBytes);
            var ownerPublicKeyLabel = new CoseHeaderLabel(FDOConstants.CUPHOwnerPubKey);
            var ownerPublicKeyBytes = coseSign1Message.UnprotectedHeaders[ownerPublicKeyLabel].EncodedValue.ToArray();
            var ownerPublicKey = this._CBORConverterProvider.Deserialize<PublicKey>(ownerPublicKeyBytes);

            var nonceLabel = new CoseHeaderLabel(FDOConstants.CUPHNonce);
            var nonceBytes = coseSign1Message.UnprotectedHeaders[nonceLabel].EncodedValue.ToArray();
            var nonceTO2ProveDv = this._CBORConverterProvider.Deserialize<FDONonce>(nonceBytes);

            // Validate Ownership Voucher Header
            var ovHeaderBytes = proveOVHdr.Header;
            var ovHeader = this._CBORConverterProvider.Deserialize<OwnershipVoucherHeader>(ovHeaderBytes);
            ValidateOwnershipVoucherHeader(proveOVHdr, coseSign1Message, ownerPublicKey, ovHeader, to2Hello);

            // Get Ownership Voucher Entries and Validate
            var hmacType = proveOVHdr.Hmac.HashType;
            var hashType = (hmacType == HashType.HMAC_SHA384) ? HashType.SHA384 : HashType.SHA256;
            var expectedHdrHash = HashHelper.GetOVHeaderHash(ovHeader, hashType);
            var ovEntries = new List<OwnershipVoucherEntryPayload>();
            Hash prevHash = GetHeaderHmacHash(ovHeaderBytes, proveOVHdr.Hmac);
            PublicKey previousKey = ovHeader.PublicKey;
            ProtocolMessage nextOVEntryResponse = new ProtocolMessage();
            for (int i = 0; i < proveOVHdr.NumEntries; i++)
            {
                // Get OV entries one by one
                var getOVEntry = new TO2GetOVNextEntry()
                {
                    EntryNumber = (byte)i
                };
                var to2getOVEntryPayload = this._CBORConverterProvider.Serialize(getOVEntry);
                // Send request
                nextOVEntryResponse = ConstructAndSendMessage(TOMessageTypes.TO2_GetOVNextEntry, to2getOVEntryPayload);

                // Process Response
                AssertMessageType(nextOVEntryResponse.MessageType, TOMessageTypes.TO2_OVNextEntry);
                var nextOVEntry = this._CBORConverterProvider.Deserialize<TO2OVNextEntry>(nextOVEntryResponse.Payload);
                var ovEntryBytes = nextOVEntry.Entry.Content.Value.ToArray();
                var ovEntry = this._CBORConverterProvider.Deserialize<OwnershipVoucherEntryPayload>(ovEntryBytes);
                ovEntries.Add(ovEntry);

                // Validation for OV Entries
                // 0. Verify the OV Entry Num
                var nextOVEntryNumber = (int)nextOVEntry.EntryNumber;
                if (nextOVEntryNumber != i)
                {
                    throw new RequestFailedException($"Incorrect OV Entry returned Expected {i} Received {nextOVEntryNumber}");
                }

                // 1. Verify signature TO2.OVNextEntry.OVEntry using variable PubKey
                var verifyEntry = nextOVEntry.Entry.VerifyEmbedded(PublicKey.DecodeFDOPublicKey(previousKey));
                if (!verifyEntry)
                {
                    throw new RequestFailedException($"Unable to verify latest OV Entry with previous Public Key");
                }

                // 2. Verify variable HashHdrInfo matches TO2.OVEntry.OVEHashHdrInfo
                if (!expectedHdrHash.Equals(ovEntry.HeaderHash))
                {
                    var msg = $"OV Header Hash did not match OV Entry Header Hash";
                    throw new RequestFailedException(msg);
                }

                // 3. Verify HashPrevEntry matches SHA[TO2.OpNextEntry.OVEntry.OVEPubKey]
                if (!prevHash.Equals(ovEntry.PreviousHash))
                {
                    var msg = $"Hash of previous entry is not equal to current entry's previous hash field.";
                    throw new RequestFailedException(msg);
                }
                previousKey = ovEntry.OwnerPublicKey;
                prevHash = GetPreviousEntryHash(ovEntry, hashType);
            }

            // Compare ProveOVHdr Public Key with Last OV Entry Public Key
            if (!ownerPublicKey.Equals(previousKey))
            {
                throw new RequestFailedException($"ProveOVHdr Public Key does not match Last owner's Public Key.");
            }

            // Use last key to verify RVRedirect Message
            var verifyCoseMessage = coseSign1Message.VerifyEmbedded(PublicKey.DecodeFDOPublicKey(previousKey));
            if (!verifyCoseMessage)
            {
                throw new RequestFailedException("TO2ProveOVHeader CoseSign1 message could not be verified with Last OV Entry Public Key.");
            }

            AssertMessageType(nextOVEntryResponse.MessageType, TOMessageTypes.TO2_OVNextEntry);
            var to2ProveDevicePayload = new TO2ProveDevicePayload();
            var kexMessage = Array.Empty<byte>();
            to2ProveDevicePayload.KexB = kexMessage;

            var nonceToProveDv =  nonceTO2ProveDv;
            var to2ProveDeviceBase = new TO2ProveDevice();
            to2ProveDeviceBase.Guid = deviceCreds.DeviceGuid;
            to2ProveDeviceBase.Nonce = nonceToProveDv;
            to2ProveDeviceBase.FdoClaim = to2ProveDevicePayload;
            var payload = this._CBORConverterProvider.Serialize(to2ProveDeviceBase);

            var noneToSetupDv = FDONonce.FromRandomUuid();
            CoseHeaderMap keyValuePairs = new CoseHeaderMap();
            var headerLabel = new CoseHeaderLabel(FDOConstants.EUPHNonce);
            var headerValue = CoseHeaderValue.FromBytes(noneToSetupDv.NonceValue);
            keyValuePairs.Add(headerLabel, headerValue);

            var coseSign1Message2 = this._deviceCredentialProvider.CreateCoseSign1Message(payload, keyValuePairs, deviceCreds.DeviceKeyType);

            var requestPayload = coseSign1Message2.Encode();
            var setupDeviceResponse = ConstructAndSendMessage(TOMessageTypes.TO2_ProveDevice, requestPayload);

            AssertMessageType(setupDeviceResponse.MessageType, TOMessageTypes.TO2_SetupDevice);
            var setupDeviceMessage = CoseMessage.DecodeSign1(setupDeviceResponse.Payload);

            if (setupDeviceMessage == null)
            {
                var msg = "Invalid Response for TO2 Prove Device, halting execution.";
                throw new RequestFailedException(msg);
            }

            var lastOwnerKey = ownerPublicKey;
            if (!coseSign1Message.VerifyEmbedded(PublicKey.DecodeFDOPublicKey(lastOwnerKey)))
            {
                throw new RequestFailedException("Unable to validate SetupDevice CoseSign1 Message with Owner Public Key.");
            }

            var to2SetupDevicePayload = this._CBORConverterProvider.Deserialize<TO2SetupDevicePayload>(setupDeviceMessage.Content.Value.ToArray());

            // Send Device Service Info Ready
            var deviceServiceInfoReady = new TO2DeviceServiceInfoReady();
            deviceServiceInfoReady.Hmac = null;
            deviceServiceInfoReady.MaxMessageSize = null;

            var deviceServiceInfoReadyPayload = this._CBORConverterProvider.Serialize(deviceServiceInfoReady);
            var ownerServiceInfoReadyResponse = ConstructAndSendMessage(TOMessageTypes.TO2_DeviceServiceInfoReady, deviceServiceInfoReadyPayload);

            // Decode OwnerServiceInfo Ready
            AssertMessageType(ownerServiceInfoReadyResponse.MessageType, TOMessageTypes.TO2_OwnerServiceInfoReady);
            var ownerServiceInfoReady = this._CBORConverterProvider.Deserialize<TO2OwnerServiceInfoReady>(ownerServiceInfoReadyResponse.Payload);

            int serviceInfoCount = 0;
            var serviceInfoSize = GetServiceInfoSize();
            var serviceInfoOrchestrator = new ServiceInfoOrchestrator(serviceInfoSize, _registeredModules, this._CBORConverterProvider);

            TO2DeviceServiceInfo deviceServiceInfo = null;
            TO2OwnerServiceInfo ownerServiceInfo = null;

            while (serviceInfoCount <= TO2MaxRoundTrips)
            {
                if (serviceInfoCount == 0)
                {
                    deviceServiceInfo = serviceInfoOrchestrator.GenerateFirstServiceInfoMessage();
                }
                else
                {
                    deviceServiceInfo = serviceInfoOrchestrator.ProcessServiceInfoMessage(ownerServiceInfo);
                }
                // Conditions
                // 1. If owner has more service info to send, device sends a non null deviceserviceinto message
                //    A. if we are less than max trips we will send device service info
                //    B. if we have reached max, we will throw an exception
                // 2. If owner has no more service info to send and device has serviceinfo i.e non null message
                //     A. if we have max trips left, we will send device service info
                //     B. if we have reached max we will throw an exception
                // 3. If owner is not marked done and device has no more service info to send
                //     A. if owner has done marked, we terminate
                //     B. if owner had not marked done and ismoreservice info is false, that implies owner was waiting for more deviceserviceinfo
                //        and if device service info is null -> error
                //     C. if owner is not marked done and ismoreserviceinfo is true, we are never going to send a null service info if we land into this state,
                //        it should again result in error.

                if (deviceServiceInfo == null)
                {
                    if (ownerServiceInfo != null && ownerServiceInfo.IsDone)
                    {
                        break;
                    }
                    else
                    {
                        throw new ArgumentNullException("DeviceServiceInfo should not be null if Owner has more ServiceInfo to send.");
                    }
                }

                if (deviceServiceInfo != null && serviceInfoCount >= TO2MaxRoundTrips)
                {
                    throw new RequestFailedException("Reached the maximum allowed Service info exchange roundtrips.");
                }

                var deviceServiceInfoPayload = this._CBORConverterProvider.Serialize(deviceServiceInfo);
                var ownerServiceInfoResponse = ConstructAndSendMessage(TOMessageTypes.TO2_DeviceServiceInfo, deviceServiceInfoPayload);
                serviceInfoCount++;

                // Process Response
                AssertMessageType(ownerServiceInfoResponse.MessageType, TOMessageTypes.TO2_OwnerServiceInfo);
                ownerServiceInfo = this._CBORConverterProvider.Deserialize<TO2OwnerServiceInfo>(ownerServiceInfoResponse.Payload);
            }
            var to2Done = new TO2Done();
            to2Done.NonceTO2ProveDevice = nonceTO2ProveDv;
            var to2DonePayload = this._CBORConverterProvider.Serialize(to2Done);
            var to2DoneResponse = ConstructAndSendMessage(TOMessageTypes.TO2_Done, to2DonePayload);

            AssertMessageType(to2DoneResponse.MessageType, TOMessageTypes.TO2_Done2);
            var to2Done2Payload = this._CBORConverterProvider.Deserialize<TO2Done2>(to2DoneResponse.Payload);
            var to2SetupDeviceNonce = to2SetupDevicePayload.NonceTO2SetupDv;
            if (!to2Done2Payload.NonceTO2SetupDevice.Equals(to2SetupDeviceNonce))
            {
                throw new RequestFailedException("Failed to validate NonceTO2SetupDevice");
            }
        }

        /// <summary>
        /// Update ownership of device
        /// </summary>
        public Task UpgradeDeviceOwnerAsync()
        {
            return Task.Run(() => UpdateDeviceOwner());
        }

        #region Private methods

        /// <summary>
        /// Gets Maximum allowed Serviceinfo size on device
        /// </summary>
        /// <returns>Max ServiceInfo Size.</returns>
        private int GetServiceInfoSize()
        {
            return this.options.MaxServiceInfoSize;
        }

        /// <summary>
        /// Perform Ownership Voucher Header validations based on [TO2_ProveOVHdr] message.
        /// </summary>
        /// <param name="oVHeaderPayload"></param>
        /// <param name="coseSign1Message"></param>
        /// <param name="ownerPublicKey"></param>
        /// <param name="ovHeader"></param>
        /// <param name="tO2HelloDevice"></param>
        /// <exception cref="Exception"></exception>
        private void ValidateOwnershipVoucherHeader(TO2ProveOVHeaderPayload oVHeaderPayload, CoseSign1Message coseSign1Message, PublicKey ownerPublicKey, OwnershipVoucherHeader ovHeader, TO2HelloDevice tO2HelloDevice)
        {
            var deviceCreds = this._deviceCredentialProvider.GetDeviceCredentials();
            // 1. Compare the NonceProveTO2OV
            var expectedNonce = oVHeaderPayload.NonceTO2ProveOV;
            var actualNonce = tO2HelloDevice.NonceProveTo2Ov;
            if (!actualNonce.Equals(expectedNonce))
            {
                throw new RequestFailedException("NonceProveTO2OV doesn't match with TO2 HelloDevice Message.");
            }

            // 2. Validate OV Entries Number
            var numEntries = (int)oVHeaderPayload.NumEntries;
            if (numEntries > MaxOVEntries)
            {
                throw new RequestFailedException($"Number of OV Entries Exceeds the maximum allowed threshold {MaxOVEntries}");
            }

            // 3. Recalculate the HMAC and verify that it matches
            var ovHeaderBytes = oVHeaderPayload.Header;
            var deviceKeySize = (KeySize)deviceCreds.DeviceKeySize;
            var deviceHmac = this._deviceCredentialProvider.GetHMAC(ovHeaderBytes, deviceKeySize, string.Empty);
            var expectedHmac = oVHeaderPayload.Hmac;
            if (!deviceHmac.Equals(expectedHmac))
            {
                throw new RequestFailedException("HMAC calculated using Device Secret does not match the expected HMAC");
            }

            // 4. Verify the Cose_Sign1 Message with this key
            var verifyCoseMessage = coseSign1Message.VerifyEmbedded(PublicKey.DecodeFDOPublicKey(ownerPublicKey));
            if (!verifyCoseMessage)
            {
                throw new RequestFailedException("TO2ProveOVHeader CoseSign1 message could not be verified with OwnerPublicKey.");
            }

            // 5. Verify the to1payload with the signature
            var to1dPayloadBytes = _tO2OwnerInfo.TO1dCoseSign1MessageEncoded;
            var to1dPayload = CoseMessage.DecodeSign1(to1dPayloadBytes);
            var verifyTO1d = to1dPayload.VerifyEmbedded(PublicKey.DecodeFDOPublicKey(ownerPublicKey));
            if (!verifyTO1d)
            {
                throw new RequestFailedException("TO1dCoseSign1 message could not be verified with OwnerPublicKey.");
            }

            // 6. Validate the Hello Device Hash
            var expectedHash = oVHeaderPayload.HelloHash;
            var helloDevicePayload = this._CBORConverterProvider.Serialize(tO2HelloDevice);
            var actualHashBytes = HashHelper.GetHashValue(expectedHash.HashType, helloDevicePayload);
            var actualHash = new Hash
            {
                HashType = expectedHash.HashType,
                HashValue = actualHashBytes
            };
            if (!actualHash.Equals(expectedHash))
            {
                throw new RequestFailedException("TO2 Hello Device Message Hash failed to match OV Header Hello Device Hash.");
            }

            // 7. Validate the Manufacturer's Public Key Hash
            var publicKeyHash = deviceCreds.PublicKeyHash;
            var mfgPublicKey = ovHeader.PublicKey;
            var mfgPublicKeyHash = ComputePublicKeyHash(mfgPublicKey);
            if (!publicKeyHash.Equals(mfgPublicKeyHash))
            {
                throw new RequestFailedException("Device Credentials Manufacturer's Public Key Hash failed to match OV header Public Key Hash.");
            }
        }

        /// <summary>
        /// Compute hash of publicKey
        /// </summary>
        /// <param name="publicKey"></param>
        /// <returns></returns>
        private Hash ComputePublicKeyHash(PublicKey publicKey)
        {
            var payload = this._CBORConverterProvider.Serialize(publicKey);
            var keySize = PublicKey.GetKeySize(publicKey);
            var hashType = HashHelper.GetHashType(keySize);

            var hashBytes = HashHelper.GetHashValue(hashType: hashType, data: payload);
            var hash = new Hash
            {
                HashType = hashType,
                HashValue = hashBytes
            };
            return hash;
        }

        /// <summary>
        /// Calculate Hash of OV header and hmac
        /// </summary>
        /// <param name="header"></param>
        /// <param name="hmac"></param>
        /// <returns></returns>
        private Hash GetHeaderHmacHash(byte[] header, Hash hmac)
        {
            var hmacType = hmac.HashType;
            byte[] data;
            var hashType = (hmacType == HashType.HMAC_SHA384) ? HashType.SHA384 : HashType.SHA256;

            //OVEHashPrevEntry is the hash of previous entry in OVEntries. For the first entry, the hash is:
            //HASH<halg1>[OwnershipVoucher.OVHeader || OwnershipVoucher.HMac]
            //where halg1 is a suitably - chosen hash algorithm supported in this protocol.
            //halg1 SHOULD be chosen as the SHA384 if the Device supports SHA384, and SHA256 otherwise.

            var hmacBytes = this._CBORConverterProvider.Serialize(hmac);
            using (var memoryStream = new MemoryStream())
            {
                memoryStream.Write(header, 0, header.Length);
                memoryStream.Write(hmacBytes, 0, hmacBytes.Length);
                data = memoryStream.ToArray();
            }

            var hashBytes = HashHelper.GetHashValue(hashType, data);

            var prevEntryHash = new Hash
            {
                HashType = hashType,
                HashValue = hashBytes
            };
            return prevEntryHash;
        }

        /// <summary>
        /// Get hash of OwnershipVoucherEntryPayload
        /// </summary>
        /// <param name="entryPayload"></param>
        /// <param name="hashType"></param>
        /// <returns></returns>
        private Hash GetPreviousEntryHash(OwnershipVoucherEntryPayload entryPayload, HashType hashType)
        {
            var data = this._CBORConverterProvider.Serialize(entryPayload);
            var hashBytes = HashHelper.GetHashValue(hashType, data);

            var prevEntryHash = new Hash
            {
                HashType = hashType,
                HashValue = hashBytes
            };
            return prevEntryHash;
        }
        #endregion
    }
}
