namespace Microsoft.Azure.Management.BotService.Models
{
    public partial class EmailChannelProperties
    {
        public EmailChannelProperties(string emailAddress, string password, bool isEnabled): this(emailAddress, isEnabled, password) {}
    }
}
