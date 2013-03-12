namespace Microsoft.WindowsAzure.Storage.Table.Protocol
{
    using System.IO;
    using Microsoft.WindowsAzure.Storage.Core.Auth;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;

#if RTMD
    internal
#else
    public
#endif
        class TableRequest
    {
        /// <summary>
        /// Writes a collection of shared access policies to the specified stream in XML format.
        /// </summary>
        /// <param name="sharedAccessPolicies">A collection of shared access policies.</param>
        /// <param name="outputStream">An output stream.</param>
        public static void WriteSharedAccessIdentifiers(SharedAccessTablePolicies sharedAccessPolicies, Stream outputStream)
        {
            Request.WriteSharedAccessIdentifiers(
                sharedAccessPolicies,
                outputStream,
                (policy, writer) =>
                {
                    writer.WriteElementString(
                        Constants.Start,
                        SharedAccessSignatureHelper.GetDateTimeOrEmpty(policy.SharedAccessStartTime));
                    writer.WriteElementString(
                        Constants.Expiry,
                        SharedAccessSignatureHelper.GetDateTimeOrEmpty(policy.SharedAccessExpiryTime));
                    writer.WriteElementString(
                        Constants.Permission,
                        SharedAccessTablePolicy.PermissionsToString(policy.Permissions));
                });
        }

        internal static string ExtractEntityIndexFromExtendedErrorInformation(RequestResult result)
        {
            if (result != null && result.ExtendedErrorInformation != null && !string.IsNullOrEmpty(result.ExtendedErrorInformation.ErrorMessage))
            {
                int semiDex = result.ExtendedErrorInformation.ErrorMessage.IndexOf(":");

                if (semiDex > 0 && semiDex < 3)
                {
                    return result.ExtendedErrorInformation.ErrorMessage.Substring(0, semiDex);
                }
            }

            return null;
        }
    }
}
