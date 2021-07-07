namespace Microsoft.Azure.Management.BotService.Models
{
    using System.Collections.Generic;
    public partial class FacebookChannelProperties
    {
         public FacebookChannelProperties(string appId, string appSecret, bool isEnabled, string verifyToken = default(string), IList<FacebookPage> pages = default(IList<FacebookPage>), string callbackUrl = default(string)):
          this(appId, isEnabled, verifyToken: verifyToken, pages: pages, appSecret: appSecret, callbackUrl: callbackUrl) {}
    }
}
