// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Azure.IoT.DeviceOnboarding.Models;
using PeterO.Cbor;

namespace Azure.IoT.DeviceOnboarding.Samples.CBORConverter
{
    /// <summary>
    /// Cbor Converter for CertChain Object
    /// Ref X5CHAIN: https://datatracker.ietf.org/doc/html/draft-ietf-cose-x509-08#name-x509-cose-header-parameters
    /// </summary>
    [CBORConverter(typeof(CertChain))]
    internal sealed class Sample_CertChainConverter : ICBORToFromConverter<CertChain>
    {
        private readonly CBORUtil cborUtil;

        public Sample_CertChainConverter()
        {
            cborUtil = new CBORUtil();
        }

        /// <summary>
        /// Convert CertChain Object to the type CBORObject
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public CBORObject ToCBORObject(CertChain obj)
        {
            if (obj == null || obj.Chain == null || obj.Chain.Count == 0)
            {
                return CBORObject.Null;
            }
            /*else if (obj.Chain.Count == 1)
			{
				X509Certificate2 cert = obj.Chain.ElementAt(0);
				byte[] certData = cert.Export(X509ContentType.Cert);
				return CBORObject.FromObjectToCBOR(certData);
			}*/
            else
            {
                var cborObj = CBORObject.NewArray();
                foreach (X509Certificate2 cert in obj.Chain)
                {
                    byte[] certData = cert.Export(X509ContentType.Cert);
                    _ = cborObj.Add(certData);
                }
                return cborObj;
            }
        }

        /// <summary>
        /// Parse CBORObjects and convert to the type CertChain
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public CertChain FromCBORObject(CBORObject obj)
        {
            if (obj == null || obj.Equals(CBORObject.Null))
            {
                return null;
            }
            else if (obj.Type == CBORType.ByteString)
            {
#if NET9_0_OR_GREATER
                var singleCert = X509CertificateLoader.LoadCertificate(obj.GetByteString());
#else
                var singleCert = new X509Certificate2(obj.GetByteString());
#endif
                return new CertChain(new List<X509Certificate2> { singleCert });
            }
            else
            {
                cborUtil.ValidateCBORObjectIsArray(obj);

                var chain = new List<X509Certificate2>();
                foreach (CBORObject cborObj in obj.Values)
                {
                    byte[] rawData = cborObj.GetByteString();
#if NET9_0_OR_GREATER
                    var cert = X509CertificateLoader.LoadCertificate(rawData);
#else
                    var cert = new X509Certificate2(rawData);
#endif
                    chain.Add(cert);
                }
                return new CertChain
                {
                    Chain = chain
                };
            }
        }
    }
}
