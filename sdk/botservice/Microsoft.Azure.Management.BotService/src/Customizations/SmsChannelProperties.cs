namespace Microsoft.Azure.Management.BotService.Models
{
    public partial class SmsChannelProperties
    {
        public SmsChannelProperties(string phone, string accountSID, string authToken, bool isEnabled, bool? isValidated = default(bool?)):
          this(phone, accountSID, isEnabled, isValidated: isValidated, authToken: authToken) {}
    }
}
