using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Core
{
    public struct AccessToken
    {
        public AccessToken(string accessToken, DateTimeOffset expiresOn)
        {
            Token = accessToken;
            ExpiresOn = expiresOn;
        }

        public string Token { get; private set; }

        public DateTimeOffset ExpiresOn { get; private set; }

        public override bool Equals(object obj)
        {
            if (obj is AccessToken)
            {
                var accessToken = (AccessToken)obj;

                return accessToken.ExpiresOn == ExpiresOn && accessToken.Token == Token;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Token.GetHashCode() ^ ExpiresOn.GetHashCode();
        }
    }
}
