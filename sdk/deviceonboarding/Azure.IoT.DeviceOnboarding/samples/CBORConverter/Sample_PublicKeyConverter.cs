// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using Azure.IoT.DeviceOnboarding.Models;
using PeterO.Cbor;

namespace Azure.IoT.DeviceOnboarding.Samples
{
    /// <summary>
    /// Cbor Converter for PublicKey Object
    /// Ref https://fidoalliance.org/specs/FDO/FIDO-Device-Onboard-RD-v1.1-20211214/FIDO-device-onboard-spec-v1.1-rd-20211214.html#publickey
    /// </summary>
    [CBORConverter(typeof(PublicKey))]
    internal sealed class Sample_PublicKeyConverter : ICBORToFromConverter<PublicKey>
    {
        private readonly CBORUtil cborUtil;

        public Sample_PublicKeyConverter()
        {
            cborUtil = new CBORUtil();
        }

        /// <summary>
        /// Convert OwnerPublicKey Object to the type CBORObject
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public CBORObject ToCBORObject(PublicKey obj)
        {
            cborUtil.ValidateObjectNotNull(obj);

            CBORObject cborObj = CBORObject.NewArray()
                .Add((byte)obj.Type)
                .Add((ushort)obj.Encoding);

            switch (obj.Encoding)
            {
                case PublicKeyEncoding.X509:
                    byte[] publicKeyData = (byte[])Convert.ChangeType(obj.Body, typeof(byte[]), CultureInfo.InvariantCulture);
                    _ = cborObj.Add(publicKeyData);
                    break;
                case PublicKeyEncoding.COSEX5CHAIN:
                    CertChain certChain = (CertChain)Convert.ChangeType(obj.Body, typeof(CertChain), CultureInfo.InvariantCulture);
                    CBORObject certChainCborObject = Sample_CBORConverter.FromObjectToCBOR(certChain);
                    _ = cborObj.Add(certChainCborObject);
                    break;
                case PublicKeyEncoding.CRYPTO:
                case PublicKeyEncoding.COSEKEY:
                default:
                    throw new NotImplementedException("The key encoding type is currently not implemented");
            }

            return cborObj;
        }

        /// <summary>
        /// Parse CBORObject and convert to the type OwnerPublicKey
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public PublicKey FromCBORObject(CBORObject obj)
        {
            cborUtil.ValidateCBORObjectIsArray(obj);

            var pubKey = new PublicKey
            {
                Type = (PublicKeyType)obj[0].AsInt32(),
                Encoding = (PublicKeyEncoding)obj[1].AsInt32(),
            };

            switch (pubKey.Encoding)
            {
                case PublicKeyEncoding.X509:
                    byte[] publicKeyBytes = Sample_CBORConverter.ToObject<byte[]>(obj[2]);
                    pubKey.Body = publicKeyBytes;
                    break;
                case PublicKeyEncoding.COSEX5CHAIN:
                    CertChain certChain = Sample_CBORConverter.ToObject<CertChain>(obj[2]);
                    pubKey.Body = certChain;
                    break;
                case PublicKeyEncoding.CRYPTO:
                case PublicKeyEncoding.COSEKEY:
                default:
                    throw new NotImplementedException("The key encoding type is currently not implemented");
            }

            return pubKey;
        }
    }
}
