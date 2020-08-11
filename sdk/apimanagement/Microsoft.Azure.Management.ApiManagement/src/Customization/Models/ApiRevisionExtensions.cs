
namespace Microsoft.Azure.Management.ApiManagement.Models
{
    /// <summary>
    /// API details.
    /// </summary>
    public static class ApiRevisionExtensions
    {
        public static string ApiRevisionIdentifier(this string apiId, string revisionId)
        {
            if (!string.IsNullOrEmpty(apiId) && !string.IsNullOrEmpty(revisionId))
            {
                return $"{apiId};rev={revisionId}";
            }

            return null;
        }

        public static string ApiRevisionIdentifierFullPath(this string apiId, string revisionId)
        {
            if (!string.IsNullOrEmpty(apiId) && !string.IsNullOrEmpty(revisionId))
            {
                return $"/apis/{apiId};rev={revisionId}";
            }
            return null;
        }
    }
}
