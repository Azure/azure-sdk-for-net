using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;


namespace Windows.Azure.Management
{
    //this is a set of utility classes  used to parse various kinds of publishprofiles
    //out of publish settings file.
    //this is an extensible file format and is used for increasingly more things
    //if you need to add new one, derive a new class, and add the "DeployMethod" string
    //to the DeployMethods class.
    //if it is a WebDeploy publish profile, derive from the WebDeployProfile class (q.v.)
    //otherwise derive from the PublishProfile base class.

    internal static class DeployMethods
    {
        //NOTE: these are case sensitive
        internal const String AzureServiceManagementAPIMethod = "AzureServiceManagementAPI";
        internal const String MSDeployMethod = "MSDeploy";
        internal const String FTPMethod = "FTP";
        internal const String BasicAuthMethod = "BasicAuth";
    }

    public static class PubSettingsParser
    {
        public static List<PublishProfile> Parse(String fileText)
        {
            if (String.IsNullOrEmpty(fileText))
                return new List<PublishProfile>();

            XDocument doc = XDocument.Parse(fileText);

            return Parse(doc);
        }

        public static List<PublishProfile> Parse(XDocument doc)
        {
            if (doc == null) throw new ArgumentNullException("doc");

            XElement publishData = doc.Root;

            var profiles = publishData.Elements(PublishSettingsXNames.X_PublishProfile);

            if (profiles == null || profiles.Count() == 0)
            {
                //try the other casing...
                profiles = publishData.Elements(PublishSettingsXNames.X_PublishProfileCap);
            }

            List<PublishProfile> profileList = new List<PublishProfile>();

            foreach (var profile in profiles)
            {
                //for now, this simply ignores unknown types
                PublishProfile pub = PublishProfile.Parse(profile);
                if (pub != null)
                {
                    profileList.Add(pub);
                }
            }

            return profileList;
        }
    }

    internal static class PublishSettingsXNames
    {
        //General Element\Attribute names
        //NOTE: These XNames *don't* have xmlns...
        //in fact they are inconsistent wrt capitalization, hence
        //the duplicates
        internal const String X_PublishData = "publishData";
        internal const String X_PublishDataCap = "PublishData";
        internal const String X_PublishMethod = "publishMethod";
        internal const String X_PublishMethodCap = "PublishMethod";
        internal const String X_PublishProfile = "publishProfile";
        internal const String X_PublishProfileCap = "PublishProfile";
        internal const String X_Url = "Url";
        internal const String X_Id = "Id";
        internal const String X_Name = "Name";

        //AzureServiceManagementAPI Element\Attribute names
        internal const String X_ManagementCert = "ManagementCertificate";
        internal const String X_CertPWD = "ManagementCertificatePassword";
        internal const String X_Subscription = "Subscription";

        //WebDeploy Attribute Names
        internal const String X_PublishUrl = "publishUrl";
        internal const String X_UserName = "userName";
        internal const String X_UserPWD = "userPWD";
        internal const String X_DestinationAppUrl = "destinationAppUrl";
        internal const String X_SQLServerDBConnectionString = "SQLServerDBConnectionString";
        internal const String X_MySQLDBConnectionString = "mySQLDBConnectionString";
        internal const String X_HostingProviderForumLink = "hostingProviderForumLink";
        internal const String X_ControlPanelLink = "controlPanelLink";

        //MSDeploy Attribute Names
        internal const String X_MSDeploySite = "msdeploySite";

        //FTP Attribute Names
        internal const String X_FTPPassiveMode = "ftpPassiveMode";
    }

    public abstract class PublishProfile
    {
        //this method returns null if the profile is unrecognized
        //consider: GenericPublishProfile that just has
        //a dictionary of attributes, for unknown profile types?
        internal static PublishProfile Parse(XElement publishProfileElement)
        {

            String pubMethod = ParsePublishMethod(publishProfileElement);

            if (String.Compare(pubMethod, DeployMethods.AzureServiceManagementAPIMethod, StringComparison.Ordinal) == 0)
            {
                return AzureServiceManagementApiProfile.Parse(publishProfileElement);
            }
            else if (String.Compare(pubMethod, DeployMethods.MSDeployMethod, StringComparison.Ordinal) == 0)
            {
                return MSDeployProfile.Parse(publishProfileElement);
            }
            else if (String.Compare(pubMethod, DeployMethods.FTPMethod, StringComparison.Ordinal) == 0)
            {
                return FtpProfile.Parse(publishProfileElement);
            }
            else if (String.Compare(pubMethod, DeployMethods.BasicAuthMethod, StringComparison.Ordinal) == 0)
            {
                return BasicAuthProfile.Parse(publishProfileElement);
            }
            else
            {
                return null;
            }

        }

        //this happens at several places, and due to the capitalization issue
        //this helper keeps us from duplicating this code over and over...
        internal static String ParsePublishMethod(XElement element)
        {
            //it could be capitalized or not, so ask for this one first as not required
            string pubMethod = ParseAttribute(element, PublishSettingsXNames.X_PublishMethod);

            if (String.IsNullOrEmpty(pubMethod))
            {
                //now try capitalized as required, we need one of them
                pubMethod = ParseAttribute(element, PublishSettingsXNames.X_PublishMethodCap, true);
            }

            return pubMethod;
        }

        //helper method to extract an attribute value, and throw if null, if required
        internal static String ParseAttribute(XElement element, XName name, bool required = false)
        {
            XAttribute attr = element.Attribute(name);

            if (attr == null || String.IsNullOrEmpty(attr.Value))
            {
                if (required)
                {
                    throw new ArgumentException(string.Empty, name.ToString());
                }
                else
                {
                    return String.Empty;
                }
            }
            else
            {
                return attr.Value;
            }
        }

        internal PublishProfile(String publishMethod)
        {
            this.PublishMethod = publishMethod;
        }

        public String PublishMethod
        {
            get;
            private set;
        }
    }

    //WebDeploy supports a couple different DeployMethods, and they
    //have a quite a few properties in common, hence this base class
    //derive additional DeployMethods used with WebDeploy from
    //this class
    public abstract class WebDeployProfile : PublishProfile
    {
        protected WebDeployProfile(String pubMethod)
            : base(pubMethod)
        {
        }

        /// <summary>
        /// This methods is intended to be called from the Parse method of the
        /// derived classes, to fill in the parent class details.
        /// Sub parse method will create an instance of itself, pass to this method
        /// then fill in its own details.
        /// </summary>
        /// <param name="thisProfile"></param>
        /// <param name="publishProfileElement"></param>
        internal static void Parse(WebDeployProfile thisProfile, XElement publishProfileElement)
        {
            //publish URL is required, everything else is optional, depending on situation...
            thisProfile.PublishUrl = PublishProfile.ParseAttribute(publishProfileElement, PublishSettingsXNames.X_PublishUrl, true);

            thisProfile.UserName = PublishProfile.ParseAttribute(publishProfileElement, PublishSettingsXNames.X_UserName);

            thisProfile.UserPWD = PublishProfile.ParseAttribute(publishProfileElement, PublishSettingsXNames.X_UserPWD);

            String destinationAppUrl = PublishProfile.ParseAttribute(publishProfileElement, PublishSettingsXNames.X_DestinationAppUrl);

            if (!String.IsNullOrEmpty(destinationAppUrl))
            {
                thisProfile.DestinationAppUrl = new Uri(destinationAppUrl);
            }

            thisProfile.SqlServerDBConnectionString = PublishProfile.ParseAttribute(publishProfileElement, PublishSettingsXNames.X_SQLServerDBConnectionString);

            thisProfile.MySqlDBConnectionString = PublishProfile.ParseAttribute(publishProfileElement, PublishSettingsXNames.X_MySQLDBConnectionString);

            String hostingProviderForumLink = PublishProfile.ParseAttribute(publishProfileElement, PublishSettingsXNames.X_HostingProviderForumLink);

            if (!String.IsNullOrEmpty(hostingProviderForumLink))
            {
                thisProfile.HostingProviderForumLink = new Uri(hostingProviderForumLink);
            }

            String controlPanelLink = PublishProfile.ParseAttribute(publishProfileElement, PublishSettingsXNames.X_ControlPanelLink);

            if (!String.IsNullOrEmpty(controlPanelLink))
            {
                thisProfile.ControlPanelLink = new Uri(controlPanelLink);
            }
        }


        //not a full Url
        [SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings")]
        public String PublishUrl
        {
            get;
            private set;
        }

        public String UserName
        {
            get;
            private set;
        }

        //CONSIDER: SecureString?
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "PWD", Justification = "Matches the schema used in the antares profile.")]
        public String UserPWD
        {
            get;
            private set;
        }

        public Uri DestinationAppUrl
        {
            get;
            private set;
        }

        public String SqlServerDBConnectionString
        {
            get;
            set;
        }

        public String MySqlDBConnectionString
        {
            get;
            set;
        }

        public Uri HostingProviderForumLink
        {
            get;
            set;
        }

        public Uri ControlPanelLink
        {
            get;
            set;
        }
    }

    public sealed class MSDeployProfile : WebDeployProfile
    {
        //the values are filled in after construction, see Parse method
        private MSDeployProfile(String publishMethod)
            : base(publishMethod)
        {
        }

        internal static new PublishProfile Parse(XElement publishProfileElement)
        {
            string pubMethod = PublishProfile.ParsePublishMethod(publishProfileElement);

            if (String.Compare(pubMethod, DeployMethods.MSDeployMethod, StringComparison.Ordinal) != 0)
                //throw new ArgumentException(WorkflowResources.WrongPublishMethodInProfile(pubMethod, DeployMethods.MSDeployMethod), "publishProfileElement");
                throw new ArgumentException();

            MSDeployProfile ret = new MSDeployProfile(pubMethod);

            WebDeployProfile.Parse(ret, publishProfileElement);

            ret.MSDeploySite = PublishProfile.ParseAttribute(publishProfileElement, PublishSettingsXNames.X_MSDeploySite);

            return ret;
        }

        public String MSDeploySite
        {
            get;
            private set;
        }
    }

    public sealed class FtpProfile : WebDeployProfile
    {
        //the values are filled in after construction, see Parse method
        private FtpProfile(String publishMethod)
            : base(publishMethod)
        {
        }

        internal static new PublishProfile Parse(XElement publishProfileElement)
        {
            string pubMethod = PublishProfile.ParsePublishMethod(publishProfileElement);

            if (String.Compare(pubMethod, DeployMethods.FTPMethod, StringComparison.Ordinal) != 0)
                //throw new ArgumentException(WorkflowResources.WrongPublishMethodInProfile(pubMethod, DeployMethods.FTPMethod), "publishProfileElement");
                throw new ArgumentException();

            FtpProfile ret = new FtpProfile(pubMethod);

            WebDeployProfile.Parse(ret, publishProfileElement);

            String passiveModeValue = PublishProfile.ParseAttribute(publishProfileElement, PublishSettingsXNames.X_FTPPassiveMode);

            if (String.IsNullOrEmpty(passiveModeValue))
            {
                ret.FtpPassiveMode = false;
            }
            else
            {
                ret.FtpPassiveMode = Boolean.Parse(passiveModeValue);
            }

            return ret;
        }

        public Boolean FtpPassiveMode
        {
            get;
            private set;
        }
    }

    public sealed class AzureServiceManagementApiProfile : PublishProfile
    {
        private AzureServiceManagementApiProfile(String publishMethod,
            String url,
            byte[] certbytes,
            String certPWD,
            AzureSubscription[] subscriptions)
            : base(publishMethod)
        {
            this.Url = new Uri(url);
            if (String.IsNullOrEmpty(certPWD))
            {
                this.ManagementCertificate = new X509Certificate2(certbytes);
            }
            else
            {
                this.ManagementCertificate = new X509Certificate2(certbytes, certPWD);
            }

            this.Subscriptions = subscriptions.ToList<AzureSubscription>();
        }

        public Uri Url
        {
            get;
            private set;
        }

        public X509Certificate2 ManagementCertificate
        {
            get;
            private set;
        }

        public List<AzureSubscription> Subscriptions
        {
            get;
            private set;
        }

        internal static new PublishProfile Parse(XElement publishProfileElement)
        {
            String pubMethod = PublishProfile.ParsePublishMethod(publishProfileElement);

            if (String.Compare(pubMethod, DeployMethods.AzureServiceManagementAPIMethod, StringComparison.Ordinal) != 0)
                //throw new ArgumentException(WorkflowResources.WrongPublishMethodInProfile(pubMethod, DeployMethods.AzureServiceManagementAPIMethod),
                //                          "publishProfileElement");
                throw new ArgumentException();

            //all attributes are required except Password, subscription element is not required
            String url = PublishProfile.ParseAttribute(publishProfileElement, PublishSettingsXNames.X_Url, true);

            String cert = PublishProfile.ParseAttribute(publishProfileElement, PublishSettingsXNames.X_ManagementCert, true);

            String certPWD = PublishProfile.ParseAttribute(publishProfileElement, PublishSettingsXNames.X_CertPWD, false);

            var elements = publishProfileElement.Elements(PublishSettingsXNames.X_Subscription);

            int subCount = elements.Count();
            AzureSubscription[] subs = new AzureSubscription[subCount];
            int i = 0;
            foreach (var elem in elements)
            {
                AzureSubscription sub = new AzureSubscription();

                sub.Id = new Guid(elem.Attribute(PublishSettingsXNames.X_Id).Value);
                sub.Name = elem.Attribute(PublishSettingsXNames.X_Name).Value;

                subs[i++] = sub;
            }

            return new AzureServiceManagementApiProfile(pubMethod,
                url,
                Convert.FromBase64String(cert),
                certPWD,
                subs);
        }
    }

    public class AzureSubscription
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
    }

    //this class is used for testing with Antares sites that use BasicAuth as
    //the API auth method. As such, this will likely not be used
    //for production.
    public sealed class BasicAuthProfile : PublishProfile
    {
        private BasicAuthProfile(String pubMethod, String userName, String userPWD)
            : base(pubMethod)
        {
            this.UserName = userName;
            this.UserPWD = userPWD;
        }

        internal static new PublishProfile Parse(XElement publishProfileElement)
        {
            String pubMethod = PublishProfile.ParsePublishMethod(publishProfileElement);

            if (String.Compare(pubMethod, DeployMethods.BasicAuthMethod, StringComparison.Ordinal) != 0)
                //throw new ArgumentException(WorkflowResources.WrongPublishMethodInProfile(pubMethod, DeployMethods.BasicAuthMethod), "publishProfileElement");
                throw new ArgumentException();

            //all attributes are required
            String userName = PublishProfile.ParseAttribute(publishProfileElement, PublishSettingsXNames.X_UserName, true);

            String userPWD = PublishProfile.ParseAttribute(publishProfileElement, PublishSettingsXNames.X_UserPWD, true);

            return new BasicAuthProfile(pubMethod, userName, userPWD);
        }

        public String UserName
        {
            get;
            private set;
        }

        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "PWD", Justification = "Matches the schema used in the antares profile.")]
        public String UserPWD
        {
            get;
            private set;
        }
    }
}

