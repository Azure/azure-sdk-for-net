using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Security.Keyvault.Keys
{
    public class DeletedKey : Key
    {
        public string RecoveryId { get; private set; }

        public DateTime? DeletedDate { get; private set; }

        public DateTime? ScheduledPurgeDate { get; private set; }
    }
}
