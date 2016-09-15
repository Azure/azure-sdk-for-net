using Microsoft.Azure.Management.Storage.Models;

namespace Microsoft.Azure.Management.V2.Storage
{
    public class AccountStatuses
    {
        public AccountStatuses(AccountStatus? primary, AccountStatus? secondary)
        {
            Primary = primary;
            Secondary = secondary;
        }

        public AccountStatus? Primary
        {
            get; private set;
        }

        public AccountStatus? Secondary
        {
            get; private set;
        }
    }

}
