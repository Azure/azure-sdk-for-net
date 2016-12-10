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
            //$ return gitPassword;

            return null;
        }

        ///GENMHASH:4732BF2508B12B93253015B845FD658D:4A55BB7792435BEEA23D85DC0CB5B024
        public string FtpUrl()
        {
            //$ return ftpUrl;

            return null;
        }

        ///GENMHASH:97E0F94E6C921885654538A045D70AE4:4BAC96658A3BD30F30DB6325C980B34A
        public string FtpPassword()
        {
            //$ return ftpPassword;

            return null;
        }

        ///GENMHASH:F632D8D9095799867FF16C94EA9B05DB:8AA4358217A2D0BD3B50E15A68D68F31
        internal  PublishingProfileImpl(string publishingProfileXml)
        {
            //$ Matcher matcher = GIT_REGEX.Matcher(publishingProfileXml);
            //$ if (matcher.Find()) {
            //$ gitUrl = matcher.Group(1);
            //$ gitUsername = matcher.Group(2);
            //$ gitPassword = matcher.Group(3);
            //$ }
            //$ matcher = FTP_REGEX.Matcher(publishingProfileXml);
            //$ if (matcher.Find()) {
            //$ ftpUrl = matcher.Group(1);
            //$ ftpUsername = matcher.Group(2);
            //$ ftpPassword = matcher.Group(3);
            //$ }
            //$ }

        }

        ///GENMHASH:3A00102CDB3883930D22D211E33DF023:2DC7A289AC2E4496BE37262AB0C17B6A
        public string FtpUsername()
        {
            //$ return ftpUsername;

            return null;
        }

        ///GENMHASH:7F7FC8DC06968B3889A780DE3BDCD874:25B07D16F82F9DBA8A3E9EF1C3B85056
        public string GitUrl()
        {
            //$ return gitUrl;

            return null;
        }

        ///GENMHASH:7E8ABAE0E0571805FF880C3B2A8721E3:B9DDA023577C3DCB5BF9204C69200181
        public string GitUsername()
        {
            //$ return gitUsername;

            return null;
        }
    }
}