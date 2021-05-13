namespace Microsoft.Azure.Management.BotService.Models
{
    public partial class TelegramChannelProperties
    {
        public TelegramChannelProperties(string accessToken, bool isEnabled, bool? isValidated = default(bool?)):
          this(isEnabled, accessToken: accessToken, isValidated: isValidated) {}
    }
}
