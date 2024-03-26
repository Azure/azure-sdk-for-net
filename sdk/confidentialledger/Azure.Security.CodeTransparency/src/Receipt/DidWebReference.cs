// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Linq;

namespace Azure.Security.CodeTransparency.Receipt
{
    /// <summary>
    /// DidWebReference class encapsulates the logic to fetch the DID document and
    /// the public key for a given CcfReceipt issued by the Code Transparency Service.
    /// Reference: https://w3c-ccg.github.io/did-method-web/ .
    /// </summary>
    public class DidWebReference
    {
        private const string DID_WEB_DOC_WELLKNOWN_PATH = ".well-known";
        private const string DID_WEB_DOC_NAME = "did.json";
        private const string SUPPORTED_ASSERTION_METHOD_TYPE = "JsonWebKey2020";
        /// <summary>
        /// Location of the DID document.
        /// </summary>
        public readonly Uri DidDocUrl;
        /// <summary>
        /// Public key reference in the DID document.
        /// </summary>
        public readonly string KeyId;

        /// <summary>
        /// Construct a DidWebReference from the URL pointing to the DID document and the public key id.
        /// </summary>
        /// <param name="uri">URL that resolves to a DID JSON document.</param>
        /// <param name="id">ID of the public key in the DID document under assertion methods.</param>
        public DidWebReference(Uri uri, string id){
            DidDocUrl = uri;
            KeyId = id;
        }

        /// <summary>
        /// Construct a DidWebReference from the issuer and key id header values in the provided CcfReceipt.
        /// </summary>
        /// <param name="receipt">CCF SCITT receipt.</param>
        public DidWebReference(CcfReceipt receipt)
        {
            CcfReceipt.SignProtected headers = receipt.GetSignProtected() ?? throw new Exception("Missing signProtected headers");
            DidDocUrl = ParseDidDocUrl(headers.Issuer);
            KeyId = headers.KeyId;
        }

        /// <summary>
        /// Fetch the certificate of this DidWebReference.
        /// If the resolver function is not provided then the default
        /// implementation will be used to fetch the DID document.
        /// </summary>
        /// <param name="resolver"></param>
        /// <returns></returns>
        public X509Certificate2 GetCert(Func<DidWebReference, DidDocument> resolver = null)
        {
            resolver ??= defaultResolver();
            DidDocument document = resolver(this);
            return ParseCert(document, KeyId);
        }

        /// <summary>
        /// Default implementation of the DidDocument fetcher which
        /// expects the DidWebReference to point to the Code Transparency Service.
        /// A new CodeTransparencyClient instance will be created and used to fetch
        /// the DID document.
        /// </summary>
        public static Func<DidWebReference, DidDocument> defaultResolver(CodeTransparencyClientOptions clientOptions = null)
        {
            return (DidWebReference r) => {
                // remove path and query from the url
                Uri serviceUri = new(r.DidDocUrl.GetLeftPart(UriPartial.Authority));
                CodeTransparencyClient client = new(serviceUri, null, clientOptions);
                return client.GetDidConfig();
            };
        }

        /// <summary>
        /// Convert a did:web issuer string to a URL that can be used to fetch the DID document.
        /// Reference: https://w3c-ccg.github.io/did-method-web/#read-resolve
        /// </summary>
        /// <param name="issuer">issuer name/url</param>
        /// <returns>URL string to get the did web public keys</returns>
        public static Uri ParseDidDocUrl(string issuer)
        {
            if (issuer == null)
                throw new Exception("invalid did:web issuer: null");
            string[] parts = issuer.Split(':', (char)StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 3)
                throw new Exception("invalid did:web issuer: " + issuer);

            string prefix = parts[0];
            string method = parts[1];
            string location = parts[2];
            if (prefix != "did" || method != "web" || location.Trim().Length == 0)
                throw new Exception("invalid did:web issuer: " + issuer);

            string fqdn = HttpUtility.UrlDecode(location);

            string pathToDidDoc;
            if (parts.Length == 3)
                pathToDidDoc = DID_WEB_DOC_WELLKNOWN_PATH;
            else
                pathToDidDoc = string.Join("/", parts.ToList().Skip(3).ToArray());

            StringBuilder sbUrl = new();
            sbUrl.Append("https://");
            sbUrl.Append(fqdn);
            sbUrl.Append('/');
            sbUrl.Append(pathToDidDoc);
            sbUrl.Append('/');
            sbUrl.Append(DID_WEB_DOC_NAME);
            return new Uri(sbUrl.ToString());
        }

        /// <summary>
        /// Find the certificate in the given DidDocument object under assertion methods. Convert it to X509Certificate2.
        /// </summary>
        /// <param name="doc">DidDocument object.</param>
        /// <param name="keyId">Key id to map the right service certificate from the did web doc</param>
        /// <returns>Service certificate.</returns>
        public static X509Certificate2 ParseCert(DidDocument doc, string keyId)
        {
            X509Certificate2 cert = null;
            if (!keyId.StartsWith("#"))
                keyId = "#" + keyId;
            string expectedMethodKey = doc.Id + keyId;
            foreach (DidDocumentKey method in SupportedAssertionMethods(doc))
            {
                if (method.Id == expectedMethodKey)
                {
                    cert = JwkToCert(method);
                    break;
                }
            }
            return cert ?? throw new Exception($"No matching assertion method found for key id {{{keyId}}} in doc {{{doc}}}");
        }

        /// <summary>
        /// Identify supported JwkAssertionMethod to get the right service certificate.
        /// </summary>
        /// <param name="doc">DidDocument object.</param>
        /// <returns>list of supported DidDocumentKey to get the right service certificate.</returns>
        public static List<DidDocumentKey> SupportedAssertionMethods(DidDocument doc)
        {
            List<DidDocumentKey> methods = new();
            foreach (DidDocumentKey method in doc.AssertionMethod)
            {
                if (method.Type == SUPPORTED_ASSERTION_METHOD_TYPE)
                    methods.Add(method);
            }
            return methods;
        }

        /// <summary>
        /// Get the service certificate from the JwkAssertionMethod object. Uses the x5c field to get the cert chain.
        /// </summary>
        /// <param name="method"></param>
        /// <returns>Service certificate.</returns>
        public static X509Certificate2 JwkToCert(DidDocumentKey method)
        {
            // TODO: create a cert from the serialized JWK values
            if (method.PublicKeyJwk.X5c != null && method.PublicKeyJwk.X5c.Count > 0)
            {
                byte[] cert = Convert.FromBase64String(method.PublicKeyJwk.X5c[0]);
                return new X509Certificate2(cert);
            }
            throw new Exception("Missing cert chain in x5c for id: " + method.Id);
        }
    }
}
