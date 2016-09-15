using Microsoft.Azure.Management.Storage.Models;

namespace Microsoft.Azure.Management.V2.Storage
{
    public class CheckNameAvailabilityResult
    {
        private CheckNameAvailabilityResultInner inner;

        internal CheckNameAvailabilityResult(CheckNameAvailabilityResultInner inner)
        {
            this.inner = inner;
        }

        public bool? IsAvailalbe
        {
            get
            {
                return inner.NameAvailable;
            }
        }

        public Reason? Reason
        {
            get
            {
                return inner.Reason;
            }
        }

        public string Message
        {
            get
            {
                return inner.Message;
            }
        }
    }
}
