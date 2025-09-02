// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using Azure.Core;

namespace Azure.Messaging.EventHubs.Authorization
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserDelegationKeyCredential"/> class.
    /// </summary>
    public class UserDelegationKeyCredential
    {
        private const string Iso8601Format = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'Z'";
        private readonly string udkSAStokenPrefix = "DelegatedSharedAccessSignature";
        private HttpClient nameSpaceClient;
        private TokenCredential tokenCredential;
        private TokenRequestContext tokenRequestContext;
        private string userDelegationKeyResource = "$userDelegationKey";

        /// <summary>
        /// Initializes a new instance of the <see cref="UserDelegationKeyCredential"/> class.
        /// </summary>
        /// <param name="tokenCredential">Token Credentials</param>
        /// <exception cref="ArgumentNullException"></exception>
#pragma warning disable AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        public UserDelegationKeyCredential(TokenCredential tokenCredential)
#pragma warning restore AZC0007 // DO provide a minimal constructor that takes only the parameters required to connect to the service.
        {
            this.tokenCredential = tokenCredential ?? throw new ArgumentNullException(nameof(tokenCredential));
            tokenRequestContext = new TokenRequestContext(new string[] { $"{new Uri("https://eventhubs.azure.net")}/.default" });
            this.nameSpaceClient = new HttpClient();
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="UserDelegationKeyCredential"/> class.
        /// </summary>
        protected UserDelegationKeyCredential()
        {
        }

        /// <summary>
        /// Generates a User Delegation SAS token for a specified resource URI with the given start time, expiry, and permissions.
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="expiry"></param>
        /// <param name="resourceUri"></param>
        /// <param name="messagingSasPermissions"></param>
        /// <param name="apiVersion"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        [RequiresUnreferencedCode("Calls System.Xml.Serialization.XmlSerializer.Serialize(XmlWriter, Object)")]
#pragma warning disable AZC0003 // DO make service methods virtual.
        public async  Task<string> GetDelegatedUserDelegationSASTokenAsync(Uri resourceUri, DateTime startTime, DateTime expiry, string messagingSasPermissions, string apiVersion = "2025-04-01")
#pragma warning restore AZC0003 // DO make service methods virtual.
        {
            if (startTime >= expiry)
            {
                throw new ArgumentException("Start time must be before expiry time.");
            }
            if (string.IsNullOrEmpty(resourceUri.PathAndQuery))
            {
                throw new ArgumentNullException(nameof(resourceUri));
            }
            // Here you would typically call Azure SDK methods to get the User Delegation Key
            // and then create a SAS token using that key.
            // For this example, we will return a placeholder string.

            string st = startTime.ToString(Iso8601Format, CultureInfo.InvariantCulture);
            string se = expiry.ToString(Iso8601Format, CultureInfo.InvariantCulture);
            string sp = messagingSasPermissions;
            string sr = HttpUtility.UrlEncode(resourceUri.AbsoluteUri.ToString());
            MessagingUserDelegationKey userDelegationKey = await GenerateUserDelegationKeyAsync(resourceUri, startTime, expiry, apiVersion).ConfigureAwait(false);
            string signedStart = userDelegationKey.SignedStart;
            string signedExpiry = userDelegationKey.SignedExpiry;
            string stringToSign = string.Join("\n",
                                    sp,
                                    st,
                                    se,
                                    sr,
                                    userDelegationKey.SignedOid,
                                    userDelegationKey.SignedTid,
                                    signedStart,
                                    signedExpiry,
                                    userDelegationKey.SignedVersion,
                                    userDelegationKey.SignedService);

            string signature = System.Web.HttpUtility.UrlEncode(Convert.ToBase64String(new HMACSHA256(Encoding.UTF8.GetBytes(userDelegationKey.Value)).ComputeHash(Encoding.UTF8.GetBytes(stringToSign))));
            string rawtoken = udkSAStokenPrefix + $" skoid={userDelegationKey.SignedOid}&sktid={userDelegationKey.SignedTid}&skt={signedStart}&ske={signedExpiry}&sks={userDelegationKey.SignedService}&skv={userDelegationKey.SignedVersion}" +
                                $"&st={st}&se={se}&sr={sr}&sp={sp}&sig={signature}";
            return rawtoken;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="resourceUri"></param>
        /// <param name="startTime"></param>
        /// <param name="expiry"></param>
        /// <param name="apiVersion"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [RequiresUnreferencedCode("Calls System.Xml.Serialization.XmlSerializer.Serialize(XmlWriter, Object)")]
#pragma warning disable AZC0003 // DO make service methods virtual.
        public async Task<MessagingUserDelegationKey> GenerateUserDelegationKeyAsync(Uri resourceUri, DateTime startTime, DateTime expiry, string apiVersion = "2025-04-01")
#pragma warning restore AZC0003 // DO make service methods virtual.
        {
            string udkEndpoint = this.GetUserDelegationKeyEndpointFromResource(resourceUri);
            string userdelegationKeyPayLoad = GetUserDelegationPayload(startTime.ToString(Iso8601Format, CultureInfo.InvariantCulture), expiry.ToString(Iso8601Format, CultureInfo.InvariantCulture));
            nameSpaceClient.DefaultRequestHeaders.Add("ContentType", "application/atom+xml");
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, udkEndpoint))
            {
                AccessToken accessToken = await tokenCredential.GetTokenAsync(tokenRequestContext, default).ConfigureAwait(false);
                requestMessage.Headers.Add("Authorization", accessToken.Token);
                requestMessage.Headers.Add("x-ms-version", apiVersion);

                byte[] bytes = Encoding.UTF8.GetBytes(userdelegationKeyPayLoad);
                requestMessage.Content = new ByteArrayContent(bytes);
                using (var response = await nameSpaceClient.SendAsync(requestMessage).ConfigureAwait(false))
                {
                    string responseString = string.Empty;
                    using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                    using (var reader = new StreamReader(responseStream, ASCIIEncoding.ASCII))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(MessagingUserDelegationKey), "http://schemas.microsoft.com/netservices/2010/10/servicebus/connect");
                            return (MessagingUserDelegationKey)serializer.Deserialize(reader);
                        }
                        else
                        {
                            try
                            {
                                XmlSerializer serializer = new XmlSerializer(typeof(ErrorResponse));
                                ErrorResponse errorResponse = (ErrorResponse)serializer.Deserialize(reader);
                                throw new Exception($"Error generating User Delegation Key. FailureCode: {errorResponse.Code}; Detail: {errorResponse.Detail}");
                            }
                            catch (Exception)
                            {
                                responseString = await reader.ReadToEndAsync().ConfigureAwait(false);
                                throw new Exception($"Error generating User Delegation Key. Detail: {responseString}");
                            }
                        }
                    }
                }
            }
        }

        private string GetUserDelegationKeyEndpointFromResource(Uri resourceUri)
        {
            if (resourceUri == null)
            {
                throw new ArgumentNullException(nameof(resourceUri));
            }
            string nameSpaceHost = resourceUri.Host;
            string uriudk = new UriBuilder()
            {
                Scheme = "https",
                Host = nameSpaceHost,
                Path = this.userDelegationKeyResource,
            }.ToString();

            return uriudk;
        }

        [RequiresUnreferencedCode("Calls System.Xml.Serialization.XmlSerializer.Serialize(XmlWriter, Object)")]
        private static string GetUserDelegationPayload(string start, string expiry)
        {
            KeyInfo keyInfo = new KeyInfo(start, expiry);
            XmlSerializer serializer = new XmlSerializer(typeof(KeyInfo));

            var settings = new XmlWriterSettings() { OmitXmlDeclaration = true };

            var stream = new StringWriter(CultureInfo.InvariantCulture);
            XmlWriter writer = XmlWriter.Create(stream, settings);
            serializer.Serialize(writer, keyInfo);
            return stream.ToString();
        }

        /// <summary>
        /// Represents the key information for a user delegation key, including the start and expiry times.
        /// </summary>
        [DataContract(Name = "KeyInfo")]
        public class KeyInfo
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="KeyInfo"/> class.
            /// </summary>
            public KeyInfo()
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="KeyInfo"/> class with the specified start and expiry times.
            /// </summary>
            /// <param name="start">The date-time the key is active in ISO 8601 UTC time.</param>
            /// <param name="expiry">The date-time the key expires in ISO 8601 UTC time.</param>
            public KeyInfo(string start, string expiry)
            {
                Start = start;
                Expiry = expiry;
            }

            /// <summary>
            /// Gets or sets the date-time the key is active in ISO 8601 UTC time.
            /// </summary>
            [DataMember(Name = "Start", EmitDefaultValue = false)]
            public string Start { get; set; }

            /// <summary>
            /// Gets or sets the date-time the key expires in ISO 8601 UTC time.
            /// </summary>
            [DataMember(Name = "Expiry", EmitDefaultValue = false)]
            public string Expiry { get; set; }
        }

        [XmlRoot("Error")]
        private class ErrorResponse
        {
            [XmlElement("Code")]
            public int Code { get; set; }

            [XmlElement("Detail")]
            public string Detail { get; set; }
        }
    }
}
