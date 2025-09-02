// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Identity;

namespace Azure.Messaging.EventHubs.Authorization
{
    /// <summary>
    /// Represents a token credential that uses a user delegation key to authorize requests for shared access
    /// signatures.
    /// </summary>
    /// <remarks>This class provides a mechanism to generate shared access signature tokens using a user
    /// delegation key. It is typically used in scenarios where fine-grained access control is required for Azure
    /// Storage resources.</remarks>
    public class UserDelegationSharedAccessSignatureToken : TokenCredential
    {
        private const string Iso8601Format = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'Z'";
        private readonly string udkSAStokenPrefix = "DelegatedSharedAccessSignature";

        /// <summary>Specifies the shared access signature.</summary>
        private const string AuthenticationTypeToken = "DelegatedSharedAccessSignature";
        /// <summary>Specifies the signed resource.</summary>
        public const string SignedResource = "sr";
        /// <summary>Specifies the signature token.</summary>
        public const string Signature = "sig";
        /// <summary>Specifies the signed key Permissions.</summary>
        public const string SignedPermissions = "sp";
        /// <summary>Specifies the signed start of the token.</summary>
        public const string SignedStart = "st";
        /// <summary>Specifies the signed expiry of the token.</summary>
        public const string SignedExpiry = "se";
        /// <summary>Specifies the full field name of the signed resource.</summary>
        public const string SignedResourceFullFieldName = AuthenticationTypeToken + " " + SignedResource;
        /// <summary>Specifies the key value separator for shared access signature token.</summary>
        public const string SasKeyValueSeparator = "=";
        /// <summary>Specifies the pair separator for shared access signature token.</summary>
        public const string SasPairSeparator = "&";

        /// <summary>The default length of time to consider a signature valid, if not otherwise specified.</summary>
        private static readonly TimeSpan DefaultSignatureValidityDuration = TimeSpan.FromMinutes(30);

        private MessagingUserDelegationKey userDelegationKey;

        /// <summary>
        ///   The resource to which the shared access signature is intended to serve as
        ///   authorization.
        /// </summary>
        public Uri Resource { get; private set; }

        /// <summary>
        ///   The date and time that the shared access signature expires, in UTC.
        /// </summary>
        public DateTimeOffset SignatureExpiration { get; private set; }

        /// <summary>
        ///   The date and time that the shared access signature expires, in UTC.
        /// </summary>
        public string Claims { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserDelegationSharedAccessSignatureToken"/> class, which
        /// generates a shared access signature token for accessing an Event Hub resource.
        /// </summary>
        /// <remarks>The shared access signature token is used to authenticate and authorize access to the
        /// specified Event Hub resource. Ensure that the <paramref name="eventHubResource"/> is correctly specified to
        /// avoid authentication issues.</remarks>
        /// <param name="userDelegationKey"></param>
        /// <param name="eventHubResource">The Event Hub resource for which the shared access signature token is being generated. This should be the
        /// fully qualified Event Hub namespace or entity path.</param>
        /// <param name="claims">The claims to be included in the User Delegation shared access signature token. These claims are used to define the permissions and scope of the token.Possible Values of Send(s),Listen(r),SendListen(sr).</param>
        /// <param name="signatureValidityDuration">The duration for which the generated shared access signature token will remain valid. If not specified, a
        /// default duration will be used.</param>
        public UserDelegationSharedAccessSignatureToken(MessagingUserDelegationKey userDelegationKey, Uri eventHubResource, string claims, TimeSpan? signatureValidityDuration = default)
        {
            signatureValidityDuration ??= DefaultSignatureValidityDuration;

            Argument.AssertNotNullOrEmpty(eventHubResource.AbsoluteUri, nameof(eventHubResource));
            Argument.AssertNotNullOrWhiteSpace(claims, nameof(claims));
            Argument.AssertNotNegative(signatureValidityDuration.Value, nameof(signatureValidityDuration));
            Argument.AssertAtLeast(claims.Length, 1, nameof(claims));
            this.Resource = eventHubResource;
            this.Claims = claims;
            this.SignatureExpiration = DateTimeOffset.UtcNow.Add(signatureValidityDuration.Value);

            if (userDelegationKey == null)
            {
                throw new ArgumentException("userDelegationKey cannot be null");
            }

            if (DateTime.Parse(userDelegationKey.SignedExpiry).ToUniversalTime() <= DateTime.UtcNow)
            {
                throw new ArgumentException("userDelegationKey has expired");
            }
            this.userDelegationKey = userDelegationKey;
        }

        /// <inheritdoc />
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            var sasToken = this.GetDelegatedUserDelegationSASToken(this.Resource, DateTime.UtcNow, this.SignatureExpiration.DateTime, this.Claims);
            IDictionary<string, string> parsedFields = ExtractFieldValues(sasToken);
            string se;
            if (!parsedFields.TryGetValue(SignedExpiry, out se))
            {
                throw new ArgumentNullException(SignedExpiry);
            }
            return new AccessToken(sasToken, DateTimeOffset.Parse(se));
        }

        /// <inheritdoc />
        [UnconditionalSuppressMessage("Trimming", "IL2026:Members annotated with 'RequiresUnreferencedCodeAttribute' require dynamic access otherwise can break functionality when trimming application code", Justification = "<Pending>")]
        public async override  ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
           return await Task.Run(() => GetToken(requestContext, cancellationToken), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Generates a User Delegation SAS token for a specified resource URI with the given start time, expiry, and permissions.
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="expiry"></param>
        /// <param name="resourceUri"></param>
        /// <param name="messagingSasPermissions"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        private string GetDelegatedUserDelegationSASToken(Uri resourceUri, DateTime startTime, DateTime expiry, string messagingSasPermissions)
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

        private static IDictionary<string, string> ExtractFieldValues(string udksharedAccessSignature)
        {
            string[] tokenLines = udksharedAccessSignature.Split();

            if (!string.Equals(tokenLines[0].Trim(), AuthenticationTypeToken, StringComparison.OrdinalIgnoreCase) || tokenLines.Length != 2)
            {
                throw new ArgumentNullException(nameof(udksharedAccessSignature));
            }

            IDictionary<string, string> parsedFields = new ConcurrentDictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            string[] tokenFields = tokenLines[1].Trim().Split(new string[] { SasPairSeparator }, StringSplitOptions.None);

            foreach (string tokenField in tokenFields)
            {
                if (tokenField != string.Empty)
                {
                    string[] fieldParts = tokenField.Split(new string[] { SasKeyValueSeparator }, StringSplitOptions.None);
                    if (string.Equals(fieldParts[0], SignedResource, StringComparison.OrdinalIgnoreCase))
                    {
                        // We need to preserve the casing of the escape characters in the audience,
                        // so defer decoding the URL until later.
                        parsedFields.Add(fieldParts[0], fieldParts[1]);
                    }
                    else
                    {
                        parsedFields.Add(fieldParts[0], HttpUtility.UrlDecode(fieldParts[1]));
                    }
                }
            }

            return parsedFields;
        }
    }
}
