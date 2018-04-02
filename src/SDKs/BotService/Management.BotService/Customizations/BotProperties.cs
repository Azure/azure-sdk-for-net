using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Management.BotService.Models;
using Newtonsoft.Json;

namespace Microsoft.Azure.Management.BotService.Models
{
    public partial class BotProperties : Resource
    {
        /// <summary>
        /// Initializes a new instance of the BotProperties class.
        /// </summary>
        /// <param name="displayName">The Name of the bot</param>
        /// <param name="endpoint">The bot's endpoint</param>
        /// <param name="msaAppId">Microsoft App Id for the bot. If not passed, an MSA App id will be provisioned but additional authentication will be required.</param>
        /// <param name="msaAppPassword">Microsoft App password for the bot. Only needed when passing an msaAppId.</param>
        /// <param name="description">The description of the bot</param>
        /// <param name="iconUrl">The Icon Url of the bot</param>
        /// <param name="endpointVersion">The bot's endpoint version</param>
        /// <param name="configuredChannels">Collection of channels for which
        /// the bot is configured</param>
        /// <param name="enabledChannels">Collection of channels for which the
        /// bot is enabled</param>
        /// <param name="developerAppInsightKey">The Application Insights
        /// key</param>
        /// <param name="developerAppInsightsApiKey">The Application Insights
        /// Api Key</param>
        /// <param name="developerAppInsightsApplicationId">The Application
        /// Insights App Id</param>
        /// <param name="luisAppIds">Collection of LUIS App Ids</param>
        /// <param name="luisKey">The LUIS Key</param>
        public BotProperties(string displayName, string endpoint, string msaAppId, string msaAppPassword, string description = default(string), string iconUrl = default(string), string endpointVersion = default(string), IList<string> configuredChannels = default(IList<string>), IList<string> enabledChannels = default(IList<string>), string developerAppInsightKey = default(string), string developerAppInsightsApiKey = default(string), string developerAppInsightsApplicationId = default(string), IList<string> luisAppIds = default(IList<string>), string luisKey = default(string))
        {
            DisplayName = displayName;
            Description = description;
            IconUrl = iconUrl;
            Endpoint = endpoint;
            EndpointVersion = endpointVersion;
            MsaAppId = msaAppId;
            MsaAppPassword = msaAppPassword;
            ConfiguredChannels = configuredChannels;
            EnabledChannels = enabledChannels;
            DeveloperAppInsightKey = developerAppInsightKey;
            DeveloperAppInsightsApiKey = developerAppInsightsApiKey;
            DeveloperAppInsightsApplicationId = developerAppInsightsApplicationId;
            LuisAppIds = luisAppIds;
            LuisKey = luisKey;
            CustomInit();
        }

        /// <summary>
        /// Gets or sets the app password of the bot
        /// </summary>
        [JsonIgnore]
        public string MsaAppPassword { get; set; }
    }
}
