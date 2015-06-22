using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BackupServices.Tests.Helpers
{
    public class ServiceNamespaces
    {
        /// <summary>
        /// Namespace used by data contracts in BMS interface
        /// </summary>
        public const string BMSServiceNamespace = "http://windowscloudbackup.com/BackupManagement/V2014_09";
    }

    [DataContract(Namespace = ServiceNamespaces.BMSServiceNamespace)]
    public class ManagementBaseObject
    {
    }

    [DataContract(Namespace = ServiceNamespaces.BMSServiceNamespace)]
    [KnownType(typeof(ContainerQueryObject))]
    public class ManagementQueryObject : ManagementBaseObject
    {
        public static string DateTimeFormat = "yyyy-MM-dd hh:mm:ss tt";
        public ManagementQueryObject()
        {
        }

        public virtual NameValueCollection GetNameValueCollection()
        {
            return new NameValueCollection();
        }

        public virtual void Initialize(NameValueCollection filters)
        {
            ValidateCollection(filters);
        }

        public virtual List<string> GetSupportedFilters()
        {
            return new List<string>();
        }

        public override string ToString()
        {
            return "ManagementQueryObject";
        }

        private void ValidateCollection(NameValueCollection filters)
        {
            List<string> supportedFilters = GetSupportedFilters();

            if (filters == null)
            {
                throw new ArgumentException("Null collection", "Filters");
            }

            if (filters.Count != filters.AllKeys.Length)
            {
                throw new ArgumentException("Duplicate keys", "Filters");
            }

            if (filters.Count > supportedFilters.Count)
            {
                string errMsg = String.Format("Unsupported filters specified, filter count: {0}", filters.Count);
                throw new ArgumentException(errMsg, "Filters");
            }

            foreach (var filter in filters.AllKeys)
            {
                if (!supportedFilters.Contains(filter))
                {
                    string errMsg = String.Format("Unsupported filters specified, filter: {0}", filter);
                    throw new ArgumentException(errMsg, "Filters");
                }
            }
        }

        //Helper functions that can be used 
        //while convertion of different dataTypes
        //Override this to handle new dataTypes if required
        public static string GetString(string str)
        {
            return str;
        }

        public static string GetString(DateTime date)
        {
            return date.ToUniversalTime().ToString(DateTimeFormat, CultureInfo.InvariantCulture);
        }

        public static string GetString(List<string> strList)
        {
            String[] strtArr = strList.ToArray();
            return String.Join(",", strtArr);
        }

        //Helper funtions to get the DataType format from string
        //Add new dataType conversion if required.
        public static T GetValueFromString<T>(string str)
        {
            if (typeof(T) == typeof(string))
            {
                return (T)Convert.ChangeType(str, typeof(T));
            }
            else if (typeof(T) == typeof(List<string>))
            {
                String[] strArr = str.Split(',');
                List<string> list = new List<string>(strArr.Length);
                foreach (string s in strArr)
                {
                    list.Add(s);
                }
                return (T)Convert.ChangeType(list, typeof(T));
            }
            else if (typeof(T) == typeof(DateTime))
            {
                DateTime date = DateTime.ParseExact(str, DateTimeFormat, CultureInfo.InvariantCulture);
                return (T)Convert.ChangeType(date, typeof(T));
            }
            else
            {
                throw new NotSupportedException();
            }
        }
    }

    [DataContract(Namespace = ServiceNamespaces.BMSServiceNamespace)]
    public enum ContainerType
    {
        [EnumMember]
        Invalid = 0,

        [EnumMember]
        Unknown,

        // used by fabric adapter to populate discovered VMs
        [EnumMember]
        IaasVMContainer,

        // used by fabric adapter to populate discovered services
        // VMs are child containers of services they belong to
        [EnumMember]
        IaasVMServiceContainer
    }

    [DataContract(Namespace = ServiceNamespaces.BMSServiceNamespace)]
    public enum RegistrationStatus
    {
        [EnumMember]
        Invalid = 0,

        [EnumMember]
        Unknown,

        [EnumMember]
        NotRegistered,

        [EnumMember]
        Registered,

        [EnumMember]
        Registering,
    }

    [DataContract(Namespace = ServiceNamespaces.BMSServiceNamespace)]
    public class ContainerQueryObject : ManagementQueryObject
    {
        public const string ContainerTypeField = "ContainerType";
        public const string ContainerStatusField = "ContainerStatus";
        public const string ContainerFriendlyNameField = "FriendlyName";

        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public string Status { get; set; }

        [DataMember]
        public string FriendlyName { get; set; }

        public ContainerQueryObject()
        {
        }

        public ContainerQueryObject(string type, string status)
        {
            this.Type = type;
            this.Status = status;
            this.FriendlyName = string.Empty;
        }

        public ContainerQueryObject(string type, string status, string name)
        {
            this.Type = type;
            this.Status = status;
            this.FriendlyName = name;
        }

        public override List<string> GetSupportedFilters()
        {
            var filterList = base.GetSupportedFilters();
            filterList.Add(ContainerTypeField);
            filterList.Add(ContainerStatusField);
            filterList.Add(ContainerFriendlyNameField);
            return filterList;
        }

        public override NameValueCollection GetNameValueCollection()
        {
            var collection = base.GetNameValueCollection();

            if (!String.IsNullOrEmpty(Type))
            {
                collection.Add(ContainerTypeField, Type);
            }

            if (!String.IsNullOrEmpty(Status))
            {
                collection.Add(ContainerStatusField, Status);
            }

            if (!String.IsNullOrEmpty(FriendlyName))
            {
                collection.Add(ContainerFriendlyNameField, FriendlyName);
            }
            return collection;
        }

        public override void Initialize(NameValueCollection collection)
        {
            base.Initialize(collection);

            if (collection[ContainerTypeField] != null)
            {
                SetType(collection[ContainerTypeField]);
            }

            if (collection[ContainerStatusField] != null)
            {
                SetStatus(collection[ContainerStatusField]);
            }

            if (collection[ContainerFriendlyNameField] != null)
            {
                SetFriendlyName(collection[ContainerFriendlyNameField]);
            }
        }

        public override string ToString()
        {
            return String.Format("{0} ContainerTypeField: {1}, ContainerStatusField: {2}", base.ToString(), Type, Status);
        }

        private void SetType(string type)
        {
            ContainerType containerType;
            if (!Enum.TryParse<ContainerType>(type, out containerType) || containerType == ContainerType.Invalid || containerType == ContainerType.Unknown)
            {
                throw new ArgumentException("Invalid type filter", ContainerTypeField);
            }

            Type = type;
        }

        private void SetStatus(string status)
        {
            RegistrationStatus contatinerStatus;
            if (!Enum.TryParse<RegistrationStatus>(status, out contatinerStatus) || contatinerStatus == RegistrationStatus.Invalid || contatinerStatus == RegistrationStatus.Unknown)
            {
                throw new ArgumentException("Invalid status filter", ContainerStatusField);
            }

            Status = status;
        }

        private void SetFriendlyName(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name is NullorEmpty", ContainerFriendlyNameField);
            }

            FriendlyName = name;
        }
    }

    public static class BackupManagementAPIHelper
    {
        public static string GetQueryString(NameValueCollection collection)
        {
            if (collection == null || collection.Count == 0)
            {
                return String.Empty;
            }

            var httpValueCollection = HttpUtility.ParseQueryString(String.Empty);
            httpValueCollection.Add(collection);

            return "&" + httpValueCollection.ToString();
        }
    }
}
