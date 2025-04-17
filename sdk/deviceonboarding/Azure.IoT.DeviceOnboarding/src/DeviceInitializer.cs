// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Azure.IoT.DeviceOnboarding.Models;
using Azure.IoT.DeviceOnboarding.Models.Providers;

namespace Azure.IoT.DeviceOnboarding
{
    /// <summary>
    /// Client covering device initializiation stage of the FDO process
    /// </summary>
    public class DeviceInitializer : DeviceOnboardingClient
    {
        /// <summary>
        /// OwnershipVoucher for device
        /// </summary>
        public OwnershipVoucher _ownershipVoucher { get; internal set; }

        /// <summary>
        /// Create instance of DeviceInitializer for mocking
        /// </summary>
        protected DeviceInitializer() { }

        /// <summary>
        /// Create new instance of DeviceInitializer
        /// </summary>
        /// <param name="ov"></param>
        /// <param name="cborConverter"></param>
        /// <param name="credProvider"></param>
        internal DeviceInitializer(
            OwnershipVoucher ov,
            CBORConverterProvider cborConverter,
            DeviceCredentialProvider credProvider)
            : base(cborConverter, credProvider)
        {
            _ownershipVoucher = ov;
        }

        /// <summary>
        /// Create new instance of DeviceInitializer
        /// </summary>
        /// <param name="ov"></param>
        /// <param name="cborConverter"></param>
        /// <param name="credProvider"></param>
        /// <param name="options"></param>
        internal DeviceInitializer(
           OwnershipVoucher ov,
           CBORConverterProvider cborConverter,
           DeviceCredentialProvider credProvider,
           DeviceOnboardingClientOptions options)
           : base(cborConverter, credProvider, options)
        {
            _ownershipVoucher = ov;
        }

        /// <summary>
        /// Initialize the device for FDO
        /// </summary>
        public void CreateOwnershipVoucher(X509Certificate2Collection mfgCertChain, PublicKeyEncoding ownerPublicKeyEncoding, RendezvousInfo rvDNS)
        {
            DeviceCredential creds = this._deviceCredentialProvider.GetDeviceCredentials(rvDNS);
            var mfgPublicKey = Models.PublicKey.GeneratePublicKey(mfgCertChain, ownerPublicKeyEncoding);

            var ownershipVoucherHeader = new OwnershipVoucherHeader()
            {
                Version = creds.DeviceProtocolVersion,
                Guid = creds.DeviceGuid,
                DeviceInfo = creds.DeviceInfo,
                RendezvousInfo = creds.DeviceRVInfo,
                DeviceCertChainHash = this._deviceCredentialProvider.GetCertChainHash(this._deviceCredentialProvider.GetDeviceCertificate()),
                PublicKey = mfgPublicKey
            };
            var headerBytes = this._CBORConverterProvider.Serialize(ownershipVoucherHeader);
            var headerHMAC = this._deviceCredentialProvider.GetHMAC(headerBytes, (KeySize)creds.DeviceKeySize, string.Empty);
            creds.HmacSecret = headerHMAC;
            var headerHashType = HashHelper.GetHashType(Models.PublicKey.GetKeySize(ownershipVoucherHeader.PublicKey));
            var headerPublicKeyBytes = HashHelper.GetHashValue(headerHashType,
                this._CBORConverterProvider.Serialize(ownershipVoucherHeader.PublicKey));
            creds.PublicKeyHash = new Hash()
            {
                HashType = headerHashType,
                HashValue = headerPublicKeyBytes
            };
            //populate HMAC secret in device credentials
            this._deviceCredentialProvider.SetDeviceCredentials(creds);
            var ownershipVoucher = new OwnershipVoucher()
            {
                Version = creds.DeviceProtocolVersion,
                Header = headerBytes,
                HeaderHmac = headerHMAC,
                DeviceCertChain = this._deviceCredentialProvider.GetDeviceCertificate(),
                OwnerEntries = new OwnershipVoucherEntries()
            };

            this._ownershipVoucher = ownershipVoucher;
        }

        /// <summary>
        /// Initialize the device for FDO
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public Task CreateOwnershipVoucherAsync(X509Certificate2Collection mfgCertChain, PublicKeyEncoding ownerPublicKeyEncoding, RendezvousInfo rvDNS)
        {
            return Task.Run(() => CreateOwnershipVoucher(mfgCertChain, ownerPublicKeyEncoding, rvDNS));
        }

        /// <summary>
        /// Extend the ownershp voucher with details of the next owner
        /// </summary>
        public void UpdateOwnershipVoucher(AsymmetricAlgorithm currentOwnerPrivateKey, X509Certificate2Collection nextOwnerPublicKey)
        {
            var currentOwnerPubKey = GetLastOwnerPublicKey(_ownershipVoucher);
            Models.PublicKey nextOwnerKey = null;
            Models.PublicKey.ValidateOwnerKeyPair(currentOwnerPubKey,currentOwnerPrivateKey);

            nextOwnerKey = Models.PublicKey.GeneratePublicKey(nextOwnerPublicKey, currentOwnerPubKey.Encoding);
            ValidatePublicKeysForExtension(currentOwnerPubKey, nextOwnerKey);

            OwnershipVoucherEntries currentEntries = _ownershipVoucher.OwnerEntries;
            if ((currentEntries == null) || currentEntries.Count == 0)
            {
                currentEntries = [];
            }

            OwnershipVoucherEntryPayload oVEntryPayload = new OwnershipVoucherEntryPayload();
            var currentHeader = this._CBORConverterProvider.Deserialize<OwnershipVoucherHeader>(_ownershipVoucher.Header);
            var hashType = (_ownershipVoucher.HeaderHmac.HashType == HashType.HMAC_SHA384) ? HashType.SHA384 : HashType.SHA256;
            oVEntryPayload.PreviousHash = GetOVHashPreviousEntry(_ownershipVoucher, hashType);
            oVEntryPayload.HeaderHash = HashHelper.GetOVHeaderHash(currentHeader, hashType);
            oVEntryPayload.OwnerPublicKey = nextOwnerKey;
            oVEntryPayload.Extra = this._CBORConverterProvider.Serialize(OVEntryExtraInfo.GetOVEExtraInfo());

            var entryPayloadBytes = this._CBORConverterProvider.Serialize(oVEntryPayload);
            var coseSign1 = this._deviceCredentialProvider.CreateCoseSign1Message(entryPayloadBytes, null, currentOwnerPubKey.Type, currentOwnerPrivateKey);
            currentEntries.Add(coseSign1);
            _ownershipVoucher.OwnerEntries = currentEntries;
        }

        /// <summary>
        /// Extend the ownershp voucher with details of the next owner
        /// </summary>
        /// <param name="currentOwnerPrivateKey"></param>
        /// <param name="nextOwnerPublicKey"></param>
        /// <returns></returns>
        public Task UpdateOwnershipVoucherAsync(AsymmetricAlgorithm currentOwnerPrivateKey, X509Certificate2Collection nextOwnerPublicKey)
        {
            return Task.Run(() => UpdateOwnershipVoucher(currentOwnerPrivateKey, nextOwnerPublicKey));
        }
        /// <summary>
        /// Get public key of owner from the latest entry
        /// </summary>
        /// <param name="ownershipVoucher">Ownership voucher</param>
        /// <returns></returns>
        private Models.PublicKey GetLastOwnerPublicKey(OwnershipVoucher ownershipVoucher)
        {
            try
            {
                var ovEntries = ownershipVoucher.OwnerEntries;

                if (ovEntries?.Count > 0)
                {
                    var lastOwner = ovEntries[ovEntries.Count - 1];
                    var entryPayloadBytes = lastOwner.Content.Value;
                    var entryPayload = this._CBORConverterProvider.Deserialize<OwnershipVoucherEntryPayload>(entryPayloadBytes.ToArray());
                    return entryPayload.OwnerPublicKey;
                }
                else
                {
                    var ovHeader = this._CBORConverterProvider.Deserialize<OwnershipVoucherHeader>(ownershipVoucher.Header);
                    return ovHeader.PublicKey;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Validate that the next owner and current owner have the same PublicKeyType
        /// </summary>
        /// <param name="currentOwner"></param>
        /// <param name="nextOwner"></param>
        /// <exception cref="ArgumentException"></exception>
        private void ValidatePublicKeysForExtension(Models.PublicKey currentOwner, Models.PublicKey nextOwner)
        {
            if (currentOwner.Type != nextOwner.Type)
            {
                throw new ArgumentException($"Mismatch current owner key type {currentOwner.Type} and next owner key type {nextOwner.Type}");
            }
        }

        /// <summary>
        /// Get hash of the previous entry in OVEntries.
        /// For first entry, the hash of the ovHeader and hmac are returned
        /// </summary>
        /// <param name="ownershipVoucher">Ownership voucher</param>
        /// <param name="hashType">Hashtype, should be SHA384 if supported and SHA256 otherwise</param>
        /// <returns></returns>
        private Hash GetOVHashPreviousEntry(OwnershipVoucher ownershipVoucher, HashType hashType)
        {
                var ovEntries = ownershipVoucher.OwnerEntries;
                byte[] data;

                if (ovEntries?.Count > 0)
                {
                    var ovEntryCount = ownershipVoucher.OwnerEntries.Count;
                    var prevOvEntry = ownershipVoucher.OwnerEntries[ovEntryCount - 1];
                    data = prevOvEntry.Content.Value.ToArray();
                }
                else
                {
                    var ovHeaderBytes = ownershipVoucher.Header;
                    var hmac = ownershipVoucher.HeaderHmac;
                    var hmacBytes = this._CBORConverterProvider.Serialize(hmac);
                    using (var memoryStream = new MemoryStream())
                    {
                        memoryStream.Write(ovHeaderBytes, 0, ovHeaderBytes.Length);
                        memoryStream.Write(hmacBytes, 0, hmacBytes.Length);
                        data = memoryStream.ToArray();
                    }
                }
                var hashBytes = HashHelper.GetHashValue(hashType, data);

                var prevEntryHash = new Hash
                {
                    HashType = hashType,
                    HashValue = hashBytes
                };
                return prevEntryHash;
        }
    }
}
