using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.BotService.Customizations;
using Microsoft.Azure.Management.BotService.Models;

namespace Microsoft.Azure.Management.BotService
{
    /// <summary>
    /// BotsOperations operations.
    /// </summary>
    public partial interface IBotsOperations
    {
        /// <summary>
        /// Bot service client
        /// </summary>
        AzureBotServiceClient Client { get; }
    }
}
