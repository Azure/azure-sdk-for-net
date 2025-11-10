// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Analytics.PlanetaryComputer.Tests
{
    /// <summary>
    /// Test environment configuration for Azure Planetary Computer SDK tests.
    /// Manages environment variables and their sanitized values for test recording and playback.
    /// </summary>
    public class PlanetaryComputerTestEnvironment : TestEnvironment
    {
        /// <summary>
        /// Gets the Planetary Computer service endpoint URL.
        /// Marked as secret to prevent real endpoint from being stored in recordings.
        /// </summary>
        public string Endpoint => GetRecordedVariable("PLANETARYCOMPUTER_ENDPOINT", options => options.IsSecret("https://Sanitized.sanitized_label.sanitized_location.geocatalog.spatio.azure.com"));

        /// <summary>
        /// Gets the STAC collection ID used for testing.
        /// </summary>
        public string CollectionId => GetRecordedVariable("PLANETARYCOMPUTER_COLLECTION_ID");

        /// <summary>
        /// Gets the STAC item ID used for testing.
        /// </summary>
        public string ItemId => GetRecordedVariable("PLANETARYCOMPUTER_ITEM_ID");

        /// <summary>
        /// Gets the collection ID for lifecycle operations (create/update/delete).
        /// Defaults to "sample-lifecycle-collection" when not set via environment.
        ///
        /// Note: Uses GetRecordedOptionalVariable() to store value in recording Variables section.
        /// This matches the pattern used by CollectionId ("naip-atl") which works successfully.
        /// However, Test08 LRO tests still fail in playback due to test proxy sanitization:
        /// - Recording phase: AZSDK3447 removal works, recordings contain unsanitized URLs
        /// - Playback phase: AZSDK3447 still applied, sanitizes collection IDs to "Sanitized"
        /// This is a C# test framework limitation vs Python (remove_batch_sanitizers affects both phases).
        /// Run Test08_01/Test08_03 in Live mode or skip via [Category("RecordingMismatch")] filter.
        /// </summary>
        public string LifecycleCollectionId => GetRecordedOptionalVariable("PLANETARYCOMPUTER_LIFECYCLE_COLLECTION_ID", null) ?? "sample-lifecycle-collection";

        /// <summary>
        /// Gets the Azure Blob Storage container URI for ingestion tests.
        /// Marked as secret to prevent real storage account details from being recorded.
        /// </summary>
        public string IngestionContainerUri => GetRecordedVariable("PLANETARYCOMPUTER_INGESTION_CONTAINER_URI", options => options.IsSecret("https://sanitized.blob.core.windows.net/sentinel2static"));

        /// <summary>
        /// Gets the STAC catalog URL for ingestion tests.
        /// </summary>
        public string IngestionCatalogUrl => GetRecordedVariable("PLANETARYCOMPUTER_INGESTION_CATALOG_URL");

        /// <summary>
        /// Gets the Managed Identity Object ID for authentication in ingestion tests.
        /// Marked as secret to prevent real identity details from being recorded.
        /// </summary>
        public string ManagedIdentityObjectId => GetRecordedVariable("PLANETARYCOMPUTER_MANAGED_IDENTITY_OBJECT_ID", options => options.IsSecret("00000000-0000-0000-0000-000000000000"));

        /// <summary>
        /// Gets the Azure Blob Storage container URI with SAS token for SAS-based ingestion tests.
        /// Marked as secret to prevent real storage and token details from being recorded.
        /// </summary>
        public string IngestionSasContainerUri => GetRecordedVariable("PLANETARYCOMPUTER_INGESTION_SAS_CONTAINER_URI", options => options.IsSecret("https://sanitized.blob.core.windows.net/sample-container"));

        /// <summary>
        /// Gets the SAS token for container access in SAS-based ingestion tests.
        /// Marked as secret to prevent token disclosure in recordings.
        /// </summary>
        public string IngestionSasToken => GetRecordedVariable("PLANETARYCOMPUTER_INGESTION_SAS_TOKEN", options => options.IsSecret("sv=2021-01-01&st=2020-01-01T00:00:00Z&se=2099-12-31T23:59:59Z&sr=c&sp=rl&sig=Sanitized"));

        /// <summary>
        /// Gets the OAuth scope for Geocatalog authentication.
        /// Marked as secret though typically not sensitive, for consistency.
        /// </summary>
        public string GeocatalogScope => GetRecordedVariable("GEOCATALOG_SCOPE", options => options.IsSecret("https://geocatalog.spatio.azure.com/.default"));
    }
}
