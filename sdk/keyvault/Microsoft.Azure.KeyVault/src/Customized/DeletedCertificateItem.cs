namespace Microsoft.Azure.KeyVault.Models
{
    public partial class DeletedCertificateItem
    {
        /// <summary>
        /// The identifier of the deleted secret object. This is used to recover the secret.
        /// </summary>
        public DeletedCertificateIdentifier RecoveryIdentifier
        {
            get
            {
                if ( !string.IsNullOrWhiteSpace( RecoveryId ) )
                    return new DeletedCertificateIdentifier( RecoveryId );
                else
                    return null;
            }
        }
    }
}
