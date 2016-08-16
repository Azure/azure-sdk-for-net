
namespace Microsoft.Azure.KeyVault.Cryptography.Algorithms
{
    public abstract class RsaEncryption : AsymmetricEncryptionAlgorithm
    {
        protected RsaEncryption( string name ) : base( name )
        {
        }
    }
}
