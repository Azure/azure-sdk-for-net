
namespace Microsoft.Azure.KeyVault.Models
{
    public partial class DeletedCertificateBundle
    {
        /// <summary>
        /// The identifier of the deleted certificate object. This is used to recover the certificate.
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
