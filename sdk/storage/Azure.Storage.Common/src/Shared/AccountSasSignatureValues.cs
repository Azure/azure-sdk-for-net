// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Text;
using Azure.Storage.Common;

#if BlobSDK
namespace Azure.Storage.Blobs
{
#elif QueueSDK
namespace Azure.Storage.Queues 
{
#elif FileSDK
namespace Azure.Storage.Files
{
#endif
    // AccountSASSignatureValues is used to generate a Shared Access Signature (SAS) for an Azure Storage account.
    // For more information, see https://docs.microsoft.com/rest/api/storageservices/constructing-an-account-sas
    public struct AccountSasSignatureValues : IEquatable<AccountSasSignatureValues>
    {
        public string Version { get; set; }
        public SasProtocol Protocol { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset ExpiryTime { get; set; }
        public string Permissions { get; set; }
        public IPRange IPRange { get; set; }
        public string Services { get; set; }
        public string ResourceTypes { get; set; }

        // NewSASQueryParameters uses an account's shared key credential to sign this signature values to produce
        // the proper SAS query parameters.
        public SasQueryParameters ToSasQueryParameters(SharedKeyCredentials sharedKeyCredential)
        {
            // https://docs.microsoft.com/en-us/rest/api/storageservices/Constructing-an-Account-SAS
            sharedKeyCredential = sharedKeyCredential ?? throw Errors.ArgumentNull(nameof(sharedKeyCredential));

            if (this.ExpiryTime == default || String.IsNullOrEmpty(this.Permissions) || String.IsNullOrEmpty(this.ResourceTypes) || String.IsNullOrEmpty(this.Services))
            {
                throw Errors.AccountSasMissingData();
            }
            if (String.IsNullOrEmpty(this.Version))
            {
                this.Version = SasQueryParameters.SasVersion;
            }
            // Make sure the permission characters are in the correct order
            this.Permissions = AccountSasPermissions.Parse(this.Permissions).ToString();
            var startTime = SasQueryParameters.FormatTimesForSasSigning(this.StartTime);
            var expiryTime = SasQueryParameters.FormatTimesForSasSigning(this.ExpiryTime);

            // String to sign: http://msdn.microsoft.com/en-us/library/azure/dn140255.aspx
            var stringToSign = String.Join("\n",
                sharedKeyCredential.AccountName,
                this.Permissions,
                this.Services,
                this.ResourceTypes,
                startTime,
                expiryTime,
                this.IPRange.ToString(),
                this.Protocol.ToString(),
                this.Version,
                "");  // That's right, the account SAS requires a terminating extra newline

            var signature = sharedKeyCredential.ComputeHMACSHA256(stringToSign);
            var p = new SasQueryParameters(this.Version, this.Services, this.ResourceTypes, this.Protocol, this.StartTime, this.ExpiryTime, this.IPRange, null, null, this.Permissions, signature);
            return p;
        }

        public override bool Equals(object obj)
            => obj is AccountSasSignatureValues other
            && this.Equals(other)
            ;

        public override int GetHashCode()
            => this.ExpiryTime.GetHashCode()
            ^ this.IPRange.GetHashCode()
            ^ this.Permissions.GetHashCode()
            ^ this.Protocol.GetHashCode()
            ^ this.ResourceTypes.GetHashCode()
            ^ this.Services.GetHashCode()
            ^ this.StartTime.GetHashCode()
            ^ this.Version.GetHashCode()
            ;

        public static bool operator ==(AccountSasSignatureValues left, AccountSasSignatureValues right) => left.Equals(right);

        public static bool operator !=(AccountSasSignatureValues left, AccountSasSignatureValues right) => !(left == right);

        public bool Equals(AccountSasSignatureValues other)
            => this.ExpiryTime == other.ExpiryTime
            && this.IPRange == other.IPRange
            && this.Permissions == other.Permissions
            && this.Protocol == other.Protocol
            && this.ResourceTypes == other.ResourceTypes
            && this.Services == other.Services
            && this.StartTime == other.StartTime
            && this.Version == other.Version
            ;
    }

    // The AccountSASPermissions type simplifies creating the permissions string for an Azure Storage Account SAS.
    // Initialize an instance of this type and then call its String method to set AccountSASSignatureValues's Permissions field.
    public struct AccountSasPermissions : IEquatable<AccountSasPermissions>
    {
        public bool Read { get; set; }
        public bool Write { get; set; }
        public bool Delete { get; set; }
        public bool List { get; set; }
        public bool Add { get; set; }
        public bool Create { get; set; }
        public bool Update { get; set; }
        public bool Process { get; set; }

        // String produces the SAS permissions string for an Azure Storage account.
        // Call this method to set AccountSASSignatureValues's Permissions field.
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (this.Read)
            {
                sb.Append(Constants.Sas.Permissions.Read);
            }

            if (this.Write)
            {
                sb.Append(Constants.Sas.Permissions.Write);
            }

            if (this.Delete)
            {
                sb.Append(Constants.Sas.Permissions.Delete);
            }

            if (this.List)
            {
                sb.Append(Constants.Sas.Permissions.List);
            }

            if (this.Add)
            {
                sb.Append(Constants.Sas.Permissions.Add);
            }

            if (this.Create)
            {
                sb.Append(Constants.Sas.Permissions.Create);
            }

            if (this.Update)
            {
                sb.Append(Constants.Sas.Permissions.Update);
            }

            if (this.Process)
            {
                sb.Append(Constants.Sas.Permissions.Process);
            }

            return sb.ToString();
        }

        // Parse initializes the AccountSASPermissions's fields from a string.
        public static AccountSasPermissions Parse(string s)
        {
            var p = new AccountSasPermissions(); // Clear out the flags
            foreach (var c in s)
            {
                switch (c)
                {
                    case Constants.Sas.Permissions.Read: p.Read = true; break;
                    case Constants.Sas.Permissions.Write: p.Write = true; break;
                    case Constants.Sas.Permissions.Delete: p.Delete = true; break;
                    case Constants.Sas.Permissions.List: p.List = true; break;
                    case Constants.Sas.Permissions.Add: p.Add = true; break;
                    case Constants.Sas.Permissions.Create: p.Create = true; break;
                    case Constants.Sas.Permissions.Update: p.Update = true; break;
                    case Constants.Sas.Permissions.Process: p.Process = true; break;
                    default: throw Errors.InvalidPermission(c);
                }
            }
            return p;
        }

        public override bool Equals(object obj)
            => obj is AccountSasPermissions other
            && this.Equals(other)
            ;

        public override int GetHashCode()
            => (this.Add ? 0b00000001 : 0)
             + (this.Delete ? 0b00000010 : 0)
             + (this.List ? 0b00000100 : 0)
             + (this.Process ? 0b00001000 : 0)
             + (this.Read ? 0b00010000 : 0)
             + (this.Update ? 0b00100000 : 0)
             + (this.Write ? 0b01000000 : 0)
             + (this.Create ? 0b1000000 : 0)
            ;

        public bool Equals(AccountSasPermissions other)
            => other.Add == this.Add
                && other.Delete == this.Delete
                && other.List == this.List
                && other.Process == this.Process
                && other.Read == this.Read
                && other.Update == this.Update
                && other.Write == this.Write
                && other.Create == this.Create
                ;

        public static bool operator ==(AccountSasPermissions left, AccountSasPermissions right) => left.Equals(right);

        public static bool operator !=(AccountSasPermissions left, AccountSasPermissions right) => !(left == right);
    }

    // The AccountSASServices type simplifies creating the services string for an Azure Storage Account SAS.
    // Initialize an instance of this type and then call its String method to set AccountSASSignatureValues's Services field.
    public struct AccountSasServices : IEquatable<AccountSasServices>
    {
        public bool Blob { get; set; }
        public bool Queue { get; set; }
        public bool File { get; set; }

        // String produces the SAS services string for an Azure Storage account.
        // Call this method to set AccountSASSignatureValues's Services field.
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (this.Blob)
            {
                sb.Append(Constants.Sas.AccountServices.Blob);
            }

            if (this.Queue)
            {
                sb.Append(Constants.Sas.AccountServices.Queue);
            }

            if (this.File)
            {
                sb.Append(Constants.Sas.AccountServices.File);
            }

            return sb.ToString();
        }

        // Parse initializes the AccountSASServices' fields from a string.
        public static AccountSasServices Parse(string s)
        {
            var a = new AccountSasServices(); // Clear out the flags
            foreach (var c in s)
            {
                switch (c)
                {
                    case Constants.Sas.AccountServices.Blob: a.Blob = true; break;
                    case Constants.Sas.AccountServices.Queue: a.Queue = true; break;
                    case Constants.Sas.AccountServices.File: a.File = true; break;
                    default: throw Errors.InvalidService(c);
                }
            }
            return a;
        }

        public override bool Equals(object obj)
            => obj is AccountSasServices other
            && this.Equals(other)
            ;

        public override int GetHashCode()
            => (this.Blob ? 0b001 : 0)
             + (this.Queue ? 0b010 : 0)
             + (this.File ? 0b100 : 0)
            ;

        public bool Equals(AccountSasServices other)
            => other.Blob == this.Blob
                && other.Queue == this.Queue
                && other.File == this.File
                ;

        public static bool operator ==(AccountSasServices left, AccountSasServices right) => left.Equals(right);

        public static bool operator !=(AccountSasServices left, AccountSasServices right) => !(left == right);
    }

    // The AccountSASResourceTypes type simplifies creating the resource types string for an Azure Storage Account SAS.
    // Initialize an instance of this type and then call its String method to set AccountSASSignatureValues's ResourceTypes field.
    public struct AccountSasResourceTypes : IEquatable<AccountSasResourceTypes>
    {
        public bool Service { get; set; }
        public bool Container { get; set; }
#pragma warning disable CA1720 // Identifier contains type name
        public bool Object { get; set; }
#pragma warning restore CA1720 // Identifier contains type name

        // String produces the SAS resource types string for an Azure Storage account.
        // Call this method to set AccountSASSignatureValues's ResourceTypes field.
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (this.Service)
            {
                sb.Append(Constants.Sas.AccountResources.Service);
            }

            if (this.Container)
            {
                sb.Append(Constants.Sas.AccountResources.Container);
            }

            if (this.Object)
            {
                sb.Append(Constants.Sas.AccountResources.Object);
            }

            return sb.ToString();
        }

        // Parse initializes the AccountSASResourceType's fields from a string.
        public static AccountSasResourceTypes Parse(string s)
        {
            var rt = new AccountSasResourceTypes();
            foreach (var c in s)
            {
                switch (c)
                {
                    case Constants.Sas.AccountResources.Service: rt.Service = true; break;
                    case Constants.Sas.AccountResources.Container: rt.Container = true; break;
                    case Constants.Sas.AccountResources.Object: rt.Object = true; break;
                    default: throw Errors.InvalidResourceType(c);
                }
            }
            return rt;
        }

        public override bool Equals(object obj)
            => obj is AccountSasResourceTypes other
            && this.Equals(other)
            ;

        public override int GetHashCode()
            => (this.Service ? 0b001 : 0)
             + (this.Container ? 0b010 : 0)
             + (this.Object ? 0b100 : 0)
            ;

        public bool Equals(AccountSasResourceTypes other)
            => other.Service == this.Service
                && other.Container == this.Container
                && other.Object == this.Object
                ;

        public static bool operator ==(AccountSasResourceTypes left, AccountSasResourceTypes right) => left.Equals(right);

        public static bool operator !=(AccountSasResourceTypes left, AccountSasResourceTypes right) => !(left == right);
    }
}
