namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart.Data
{
    /// <summary>
    /// Represents the Authentication Protocol Type.
    /// </summary>
    public enum AuthenticationProtocolType
    {
        /// <summary>
        /// Oauth 2
        /// </summary>
        OAUTH2,

        /// <summary>
        /// SAML
        /// </summary>
        SAML,

        /// <summary>
        /// WS-FED
        /// </summary>
        WS_FED,

        /// <summary>
        /// Unknown future value
        /// </summary>
        UnknownFutureValue,
    }
}
