// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Management.AppService.Fluent
{
    /// <summary>
    /// A credential for publishing to a web app.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmFwcHNlcnZpY2UuaW1wbGVtZW50YXRpb24uUHVibGlzaGluZ1Byb2ZpbGVJbXBs
    internal partial class PublishingProfileImpl : IPublishingProfile
    {
        private string ftpUrl;
        private string gitUrl;
        private string ftpUsername;
        private string gitUsername;
        private string ftpPassword;
        private string gitPassword;
        private static readonly Regex gitRegex = new Regex("publishMethod=\"MSDeploy\" publishUrl=\"([^\"]+)\".+userName=\"(\\$[^\"]+)\".+userPWD=\"([^\"]+)\"");
        private static readonly Regex ftpRegex = new Regex("publishMethod=\"FTP\" publishUrl=\"ftp://([^\"]+).+userName=\"([^\"]+\\\\\\$[^\"]+)\".+userPWD=\"([^\"]+)\"");

        ///GENMHASH:EED906EE02A83607395DD16B6C952CB5:F903566E74A7E102149C01EBDACBA16F
        public string GitPassword()
        {
            return gitPassword;
        }

        ///GENMHASH:4732BF2508B12B93253015B845FD658D:4A55BB7792435BEEA23D85DC0CB5B024
        public string FtpUrl()
        {
            return ftpUrl;
        }

        ///GENMHASH:97E0F94E6C921885654538A045D70AE4:4BAC96658A3BD30F30DB6325C980B34A
        public string FtpPassword()
        {
            return ftpPassword;
        }

        ///GENMHASH:B45CFC79F53C364F2AEFC729C0B13791:9A0D9C09A1A3DECF7680944A69354DF1
        internal PublishingProfileImpl(string publishingProfileXml)
        {
            var matcher = gitRegex.Match(publishingProfileXml);
            if (matcher.Success)
            {
                gitUrl = matcher.Groups[1].Value;
                gitUsername = matcher.Groups[2].Value;
                gitPassword = matcher.Groups[3].Value;
            }
            matcher = ftpRegex.Match(publishingProfileXml);
            if (matcher.Success)
            {
                ftpUrl = matcher.Groups[1].Value;
                ftpUsername = matcher.Groups[2].Value;
                ftpPassword = matcher.Groups[3].Value;
            }
        }

        ///GENMHASH:3A00102CDB3883930D22D211E33DF023:2DC7A289AC2E4496BE37262AB0C17B6A
        public string FtpUsername()
        {
            return ftpUsername;
        }

        ///GENMHASH:7F7FC8DC06968B3889A780DE3BDCD874:3D4DF5C05B9DB567C2A58850D325D1EA
        public string GitUrl()
        {
            return gitUrl;
        }

        ///GENMHASH:7E8ABAE0E0571805FF880C3B2A8721E3:B9DDA023577C3DCB5BF9204C69200181
        public string GitUsername()
        {
            return gitUsername;
        }
    }
}
