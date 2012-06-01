using System;
using System.Data.Services.Client;

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    /// <summary>
    /// Collection of <see cref="Microsoft.WindowsAzure.MediaServices.Client.ILocator"/> objects.
    /// </summary>
    public class LocatorCollection : BaseCloudCollection<ILocator>
    {
        internal const string LocatorEntitySetName = "Locators";
        private readonly CloudMediaContext _cloudMediaContext;

        /// <summary>
        /// Constructs a new LocatorCollection object.
        /// </summary>
        /// <param name="cloudMediaContext">The <see cref="Microsoft.WindowsAzure.MediaServices.Client.CloudMediaContext"/> to perform locator related operations on.</param>
        internal LocatorCollection(CloudMediaContext cloudMediaContext)
            : base(VerifyAndGetDataContext(cloudMediaContext), VerifyAndGetDataContext(cloudMediaContext).CreateQuery<LocatorData>(LocatorEntitySetName))
        {
            if (cloudMediaContext == null)
            {
                throw new ArgumentNullException("cloudMediaContext");
            }

            _cloudMediaContext = cloudMediaContext;
        }

        private static DataServiceContext VerifyAndGetDataContext(CloudMediaContext cloudMediaContext)
        {
            if (cloudMediaContext == null)
            {
                throw new ArgumentNullException("cloudMediaContext");
            }

            return cloudMediaContext.DataContext;
        }

        private static void VerifyLocator(ILocator locator)
        {
            if (locator == null)
            {
                throw new ArgumentNullException("locator");
            }

            if (!(locator is LocatorData))
            {
                throw new ArgumentException(StringTable.InvalidLocatorType, "locator");
            }
        }

        private ILocator CreateLocator(LocatorType locatorType, IAsset asset, IAccessPolicy accessPolicy, DateTime? startTime)
        {
            if (asset == null)
            {
                throw new ArgumentNullException("asset");
            }

            if (accessPolicy == null)
            {
                throw new ArgumentNullException("accessPolicy");
            }

            AccessPolicyCollection.VerifyAccessPolicy(accessPolicy);
            AssetCollection.VerifyAsset(asset);

            AssetData realAsset = (AssetData)asset;

            LocatorData locator = new LocatorData(_cloudMediaContext)
            {
                AccessPolicy = (AccessPolicyData)accessPolicy,
                Asset = realAsset,
                Type = (int)locatorType,
                StartTime = startTime,
            };

            DataContext.AddObject(LocatorEntitySetName, locator);
            DataContext.SetLink(locator, "AccessPolicy", accessPolicy);
            DataContext.SetLink(locator, "Asset", asset);
            DataContext.SaveChanges();

            realAsset.InvalidateLocatorsCollection();

            return locator;
        }

        /// <summary>
        ///     Creates a WindowsAzure CDN Locator for streaming from origin servers, with the specified access policy and asset.
        /// </summary>
        /// <param name="asset"> The asset to create a SAS Locator for. </param>
        /// <param name="accessPolicy"> The AccessPolicy that governs access for the locator. </param>
        /// <returns> A locator enabling streaming access to the specified <paramref name="asset" />. </returns>
        /// <exception cref="ArgumentNullException">When <paramref name="asset"/> is null.</exception>
        /// <exception cref="ArgumentNullException">When <paramref name="accessPolicy"/> is null.</exception>
        public ILocator CreateWindowsAzureCdnLocator(IAsset asset, IAccessPolicy accessPolicy)
        {
            return CreateLocator(LocatorType.WindowsAzureCdn, asset, accessPolicy, startTime: null);
        }

        /// <summary>
        ///     Creates a Windows Azure CDN Locator for streaming from origin servers, starting at the specified start time, with the specified access policy and asset.
        /// </summary>
        /// <param name="asset"> The asset to create a SAS Locator for. </param>
        /// <param name="accessPolicy"> The AccessPolicy that governs access for the locator. </param>
        /// <param name="startTime"> The start time of the created Locator. </param>
        /// <returns> A locator enabling streaming access to the specified <paramref name="asset" />. </returns>
        /// <exception cref="ArgumentNullException">When <paramref name="asset"/> is null.</exception>
        /// <exception cref="ArgumentNullException">When <paramref name="accessPolicy"/> is null.</exception>
        public ILocator CreateWindowsAzureCdnLocator(IAsset asset, IAccessPolicy accessPolicy, DateTime startTime)
        {
            return CreateLocator(LocatorType.WindowsAzureCdn, asset, accessPolicy, startTime: startTime);
        }

        /// <summary>
        ///     Creates an Origin Locator for streaming from origin servers, with the specified access policy and asset.
        /// </summary>
        /// <param name="asset"> The asset to create a SAS Locator for. </param>
        /// <param name="accessPolicy"> The AccessPolicy that governs access for the locator. </param>
        /// <returns> A locator enabling streaming access to the specified <paramref name="asset" />. </returns>
        /// <exception cref="ArgumentNullException">When <paramref name="asset"/> is null.</exception>
        /// <exception cref="ArgumentNullException">When <paramref name="accessPolicy"/> is null.</exception>
        public ILocator CreateOriginLocator(IAsset asset, IAccessPolicy accessPolicy)
        {
            return CreateOriginLocator(asset, accessPolicy, null);
        }

        /// <summary>
        ///     Creates an Origin Locator for streaming from origin servers, with the specified access policy and asset.
        /// </summary>
        /// <param name="asset"> The asset to create a SAS Locator for. </param>
        /// <param name="accessPolicy"> The AccessPolicy that governs access for the locator. </param>
        /// <param name="startTime"> The access start time of the locator. </param>
        /// <returns> A locator enabling streaming access to the specified <paramref name="asset" />. </returns>
        /// <exception cref="ArgumentNullException">When <paramref name="asset"/> is null.</exception>
        /// <exception cref="ArgumentNullException">When <paramref name="accessPolicy"/> is null.</exception>
        public ILocator CreateOriginLocator(IAsset asset, IAccessPolicy accessPolicy, DateTime? startTime)
        {
            return CreateLocator(LocatorType.Origin, asset, accessPolicy, startTime);
        }

        /// <summary>
        ///     Creates a SAS Locator with the specified access policy and asset.
        /// </summary>
        /// <param name="asset"> The asset to create a SAS Locator for. </param>
        /// <param name="accessPolicy"> The AccessPolicy that governs access for the locator. </param>
        /// <returns> A locator granting access specified by <paramref name="accessPolicy" /> to the provided <paramref
        ///      name="asset" />. </returns>
        /// <exception cref="ArgumentNullException">When <paramref name="asset"/> is null.</exception>
        /// <exception cref="ArgumentNullException">When <paramref name="accessPolicy"/> is null.</exception>
        public ILocator CreateSasLocator(IAsset asset, IAccessPolicy accessPolicy)
        {
            return CreateSasLocator(asset, accessPolicy, null);
        }

        /// <summary>
        ///     Creates a SAS Locator with the specified access policy and asset.
        /// </summary>
        /// <param name="asset"> The asset to create a SAS Locator for. </param>
        /// <param name="accessPolicy"> The AccessPolicy that governs access for the locator. </param>
        /// <param name="startTime"> The access start time of the locator. </param>
        /// <returns> A locator granting access specified by <paramref name="accessPolicy" /> to the provided <paramref
        ///      name="asset" />. </returns>
        /// <exception cref="ArgumentNullException">When <paramref name="asset"/> is null.</exception>
        /// <exception cref="ArgumentNullException">When <paramref name="accessPolicy"/> is null.</exception>
        public ILocator CreateSasLocator(IAsset asset, IAccessPolicy accessPolicy, DateTime? startTime)
        {
            return CreateLocator(LocatorType.Sas, asset, accessPolicy, startTime);
        }

        /// <summary>
        /// Updates the expiration time of an Origin locator.
        /// </summary>
        /// <param name="locator">The Origin locator to update</param>
        /// <param name="expiryTime">The new expiration time for the origin locator.</param>
        /// <exception cref="ArgumentNullException">When <paramref name="locator"/> is null.</exception>
        /// <exception cref="InvalidOperationException">When <paramref name="locator"/> is not an Origin Locator.</exception>
        public void Update(ILocator locator, DateTime expiryTime)
        {
            Update(locator, startTime: null, expiryTime: expiryTime);
        }

        /// <summary>
        /// Updates the start time or expiration time of an Origin locator.
        /// </summary>
        /// <param name="locator">The Origin locator to update</param>
        /// <param name="startTime">The new start time for the origin locator.</param>
        /// <param name="expiryTime">The new expiration time for the origin locator.</param>
        /// <exception cref="ArgumentNullException">When <paramref name="locator"/> is null.</exception>
        /// <exception cref="InvalidOperationException">When <paramref name="locator"/> is not an Origin Locator.</exception>
        public void Update(ILocator locator, DateTime? startTime, DateTime expiryTime)
        {
            if (locator == null)
            {
                throw new ArgumentNullException("locator");
            }

            VerifyLocator(locator);
            
            if (locator.Type != LocatorType.Origin)
            {
                throw new InvalidOperationException("Only Origin locators can be updated.");    
            }

            LocatorData locatorData = (LocatorData)locator;
            locatorData.StartTime = startTime;
            locatorData.ExpirationDateTime = expiryTime;
            _cloudMediaContext.DataContext.UpdateObject(locator);
            _cloudMediaContext.DataContext.SaveChanges();
        }

        /// <summary>
        ///     Revokes the specified Locator, denying any access it provided.
        /// </summary>
        /// <param name="locator"> The locator to revoke access for. </param>
        public void Revoke(ILocator locator)
        {
            VerifyLocator(locator);

            DataContext.DeleteObject(locator);
            DataContext.SaveChanges();

            LocatorData locatorData = (LocatorData)locator;

            if (locatorData.Asset != null)
            {
                locatorData.Asset.InvalidateLocatorsCollection();
            }
        }
    }
}
