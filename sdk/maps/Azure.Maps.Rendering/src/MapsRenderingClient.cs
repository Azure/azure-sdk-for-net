// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.GeoJson;
using Azure.Core.Pipeline;
using Azure.Maps.Common;

namespace Azure.Maps.Rendering
{
    /// <summary> The Render service client. </summary>
    public partial class MapsRenderingClient
    {
        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        private readonly HttpPipeline _pipeline;

        /// <summary> The restClient is used to access Render REST client. </summary>
        internal RenderRestClient restClient { get; }

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics _clientDiagnostics { get; }

        /// <summary> Initializes a new instance of MapsRenderingClient. </summary>
        protected MapsRenderingClient()
        {
            _clientDiagnostics = null;
            _pipeline = null;
            restClient = null;
        }

        /// <summary> Initializes a new instance of MapsRenderingClient. </summary>
        /// <param name="credential"> Shared key credential used to authenticate to an Azure Maps Render Service. </param>
        public MapsRenderingClient(AzureKeyCredential credential)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = new Uri("https://atlas.microsoft.com");
            var options = new MapsRenderingClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, "subscription-key"));
            var accept = options.AcceptMediaType.Value != "" ? options.AcceptMediaType : null;

            restClient = new RenderRestClient(_clientDiagnostics, _pipeline, endpoint, null, options.Version, accept);
        }

        /// <summary> Initializes a new instance of MapsRenderingClient. </summary>
        /// <param name="credential"> Shared key credential used to authenticate to an Azure Maps Render Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public MapsRenderingClient(AzureKeyCredential credential, MapsRenderingClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = options.Endpoint ?? new Uri("https://atlas.microsoft.com");
            options ??= new MapsRenderingClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, "subscription-key"));
            var accept = options.AcceptMediaType.Value != "" ? options.AcceptMediaType : null;

            restClient = new RenderRestClient(_clientDiagnostics, _pipeline, endpoint, null, options.Version, accept);
        }

        /// <summary> Initializes a new instance of MapsRenderingClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Maps Render Service. </param>
        /// <param name="clientId"> Specifies which account is intended for usage in conjunction with the Microsoft Entra ID security model.  It represents a unique ID for the Azure Maps account and can be retrieved from the Azure Maps management  plane Account API. To use Microsoft Entra ID security in Azure Maps see the following <see href="https://aka.ms/amauthdetails">articles</see> for guidance. </param>
        public MapsRenderingClient(TokenCredential credential, string clientId)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = new Uri("https://atlas.microsoft.com");
            var options = new MapsRenderingClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            string[] scopes = { "https://atlas.microsoft.com/.default" };
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, scopes), new AzureKeyCredentialPolicy(new AzureKeyCredential(clientId), "x-ms-client-id"));
            var accept = options.AcceptMediaType.Value != "" ? options.AcceptMediaType : null;

            restClient = new RenderRestClient(_clientDiagnostics, _pipeline, endpoint, clientId, options.Version, accept);
        }

        /// <summary> Initializes a new instance of MapsRenderingClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Maps Render Service. </param>
        /// <param name="clientId"> Specifies which account is intended for usage in conjunction with the Microsoft Entra ID security model.  It represents a unique ID for the Azure Maps account and can be retrieved from the Azure Maps management  plane Account API. To use Microsoft Entra ID security in Azure Maps see the following <see href="https://aka.ms/amauthdetails">articles</see> for guidance. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public MapsRenderingClient(TokenCredential credential, string clientId, MapsRenderingClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = options.Endpoint ?? new Uri("https://atlas.microsoft.com");
            options ??= new MapsRenderingClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            string[] scopes = { "https://atlas.microsoft.com/.default" };
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, scopes), new AzureKeyCredentialPolicy(new AzureKeyCredential(clientId), "x-ms-client-id"));
            var accept = options.AcceptMediaType.Value != "" ? options.AcceptMediaType : null;

            restClient = new RenderRestClient(_clientDiagnostics, _pipeline, endpoint, clientId, options.Version, accept);
        }

        /// <summary> Initializes a new instance of MapsRenderingClient. </summary>
        /// <param name="credential"> The Shared Access Signature credential used to connect to Azure. This signature
        /// can be constructed using the <see cref="AzureSasCredential"/>.</param>
        public MapsRenderingClient(AzureSasCredential credential)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = new Uri("https://atlas.microsoft.com");
            var options = new MapsRenderingClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new MapsSasCredentialPolicy(credential));
            var accept = options.AcceptMediaType.Value != "" ? options.AcceptMediaType : null;

            restClient = new RenderRestClient(_clientDiagnostics, _pipeline, endpoint, null, options.Version, accept);
        }

        /// <summary> Initializes a new instance of MapsRenderingClient. </summary>
        /// <param name="credential"> The Shared Access Signature credential used to connect to Azure. This signature
        /// can be constructed using the <see cref="AzureSasCredential"/>.</param>
        /// <param name="options"> The options for configuring the client. </param>
        public MapsRenderingClient(AzureSasCredential credential, MapsRenderingClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = options.Endpoint;
            options ??= new MapsRenderingClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new MapsSasCredentialPolicy(credential));
            var accept = options.AcceptMediaType.Value != "" ? options.AcceptMediaType : null;

            restClient = new RenderRestClient(_clientDiagnostics, _pipeline, endpoint, null, options.Version, accept);
        }

        /// <summary> Initializes a new instance of MapsRenderingClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="clientId"> Specifies which account is intended for usage in conjunction with the Microsoft Entra ID security model.  It represents a unique ID for the Azure Maps account and can be retrieved from the Azure Maps management  plane Account API. To use Microsoft Entra ID security in Azure Maps see the following <see href="https://aka.ms/amauthdetails">articles</see> for guidance. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        internal MapsRenderingClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null, string clientId = null, MapsRenderingClientOptions.ServiceVersion apiVersion = MapsRenderingClientOptions.LatestVersion)
        {
            var options = new MapsRenderingClientOptions(apiVersion);
            var accept = options.AcceptMediaType.Value != "" ? options.AcceptMediaType : null;

            restClient = new RenderRestClient(clientDiagnostics, pipeline, endpoint, clientId, options.Version, accept);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary>
        /// The API renders a user-defined, rectangular image containing a map section using a zoom level. If you are deciding when to use the static image service over the map tile service, you may want to consider how you would like to interact with the rendered map. If the map contents will be relatively unchanging, a static map is a good choice. If you want to support a lot of zooming, panning and changing of the map content, the map tile service would be a better choice.
        /// The service also provides Image Composition functionality to get a static image back with additional data.
        /// </summary>
        /// <param name="options"> The options for configuring the static image. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Stream>> GetMapStaticImageAsync(GetMapStaticImageOptions options, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsRenderingClient.GetMapStaticImage");
            scope.Start();
            try
            {
                List<double> coordinate = null;
                if (options?.CenterCoordinate != null)
                {
                    coordinate = new List<double>();
                    coordinate.Add(options.CenterCoordinate.Value.Longitude);
                    coordinate.Add(options.CenterCoordinate.Value.Latitude);
                }
                List<double> boundingBox = null;
                if (options?.BoundingBox != null)
                {
                    boundingBox = new List<double>();
                    boundingBox.Add(options.BoundingBox.West);
                    boundingBox.Add(options.BoundingBox.South);
                    boundingBox.Add(options.BoundingBox.East);
                    boundingBox.Add(options.BoundingBox.North);
                }
                LocalizedMapView? localizedMapView = null;
                if (options?.LocalizedMapView != null)
                {
                    localizedMapView = new LocalizedMapView(options?.LocalizedMapView.ToString());
                }
                List<string> pushpins = null;
                if (options?.ImagePushpinStyles != null)
                {
                    pushpins = new List<string>();
                    foreach (var pin in options?.ImagePushpinStyles)
                    {
                        pushpins.Add(pin.ToQueryString());
                    }
                }
                List<string> paths = null;
                if (options?.ImagePathStyles != null)
                {
                    paths = new List<string>();
                    foreach (var path in options?.ImagePathStyles)
                    {
                        paths.Add(path.ToQueryString());
                    }
                }
                var response = await restClient.GetMapStaticImageAsync(
                    MapTileSetId.MicrosoftBaseRoad,
                    TrafficTilesetId.MicrosoftTrafficRelativeMain,
                    options?.ZoomLevel,
                    coordinate,
                    boundingBox,
                    options?.HeightInPixels,
                    options?.WidthInPixels,
                    options?.Language.ToString(),
                    localizedMapView,
                    pushpins,
                    paths,
                    cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The API renders a user-defined, rectangular image containing a map section using a zoom level. If you are deciding when to use the static image service over the map tile service, you may want to consider how you would like to interact with the rendered map. If the map contents will be relatively unchanging, a static map is a good choice. If you want to support a lot of zooming, panning and changing of the map content, the map tile service would be a better choice.
        /// The service also provides Image Composition functionality to get a static image back with additional data.
        /// </summary>
        /// <param name="options"> The options for configuring the static image. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Stream> GetMapStaticImage(GetMapStaticImageOptions options, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsRenderingClient.GetMapStaticImage");
            scope.Start();
            try
            {
                List<double> coordinate = null;
                if (options?.CenterCoordinate != null)
                {
                    coordinate = new List<double>();
                    coordinate.Add(options.CenterCoordinate.Value.Longitude);
                    coordinate.Add(options.CenterCoordinate.Value.Latitude);
                }
                List<double> boundingBox = null;
                if (options?.BoundingBox != null)
                {
                    boundingBox = new List<double>();
                    boundingBox.Add(options.BoundingBox.West);
                    boundingBox.Add(options.BoundingBox.South);
                    boundingBox.Add(options.BoundingBox.East);
                    boundingBox.Add(options.BoundingBox.North);
                }
                LocalizedMapView? localizedMapView = null;
                if (options?.LocalizedMapView != null)
                {
                    localizedMapView = new LocalizedMapView(options?.LocalizedMapView.ToString());
                }
                List<string> pushpins = null;
                if (options?.ImagePushpinStyles != null)
                {
                    pushpins = new List<string>();
                    foreach (var pin in options?.ImagePushpinStyles)
                    {
                        pushpins.Add(pin.ToQueryString());
                    }
                }
                List<string> paths = null;
                if (options?.ImagePathStyles != null)
                {
                    paths = new List<string>();
                    foreach (var path in options?.ImagePathStyles)
                    {
                        paths.Add(path.ToQueryString());
                    }
                }
                var response = restClient.GetMapStaticImage(
                    MapTileSetId.MicrosoftBaseRoad,
                    TrafficTilesetId.MicrosoftTrafficRelativeMain,
                    options?.ZoomLevel,
                    coordinate,
                    boundingBox,
                    options?.HeightInPixels,
                    options?.WidthInPixels,
                    options?.Language.ToString(),
                    localizedMapView,
                    pushpins,
                    paths,
                    cancellationToken);
                return Response.FromValue(response.Value, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Fetches state tiles in vector format typically to be integrated into indoor maps module of map control or SDK. The map control will call this API after user turns on dynamic styling (see <see href="https://docs.microsoft.com/azure/location-based-services/zoom-levels-and-tile-grid">Zoom Levels and Tile Grid</see>)
        /// </summary>
        /// <param name="stateSetId"> The state set id for indoor map. </param>
        /// <param name="mapTileIndex">
        /// Zoom level, and coordinate of the tile on zoom grid.
        /// The value of X and Y coordinate in <c>mapTileIndex</c> must be in the range [0, (2^zoom)-1].
        /// Please see <see href="https://docs.microsoft.com/azure/location-based-services/zoom-levels-and-tile-grid">Zoom Levels and Tile Grid</see> for details.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="stateSetId"/> or <paramref name="mapTileIndex"/> is null. </exception>
        public virtual async Task<Response<Stream>> GetMapStateTileAsync(string stateSetId, MapTileIndex mapTileIndex, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsRenderingClient.GetMapStateTile");
            scope.Start();
            try
            {
                var response = await restClient.GetMapStateTileAsync(stateSetId, mapTileIndex, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Fetches state tiles in vector format typically to be integrated into indoor maps module of map control or SDK. The map control will call this API after user turns on dynamic styling (see <see href="https://docs.microsoft.com/azure/location-based-services/zoom-levels-and-tile-grid">Zoom Levels and Tile Grid</see>)
        /// </summary>
        /// <param name="stateSetId"> The state set id. </param>
        /// <param name="mapTileIndex">
        /// Zoom level, and coordinate of the tile on zoom grid.
        /// The value of X and Y coordinate in <c>mapTileIndex</c> must be in the range [0, (2^zoom)-1].
        /// Please see <see href="https://docs.microsoft.com/azure/location-based-services/zoom-levels-and-tile-grid">Zoom Levels and Tile Grid</see> for details.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="stateSetId"/> is null. </exception>
        public virtual Response<Stream> GetMapStateTile(string stateSetId, MapTileIndex mapTileIndex, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(stateSetId, nameof(stateSetId));

            using var scope = _clientDiagnostics.CreateScope("MapsRenderingClient.GetMapStateTile");
            scope.Start();
            try
            {
                var response = restClient.GetMapStateTile(stateSetId, mapTileIndex, cancellationToken);
                return Response.FromValue(response.Value, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Fetches map tiles in vector or raster format typically to be integrated into a new map control or SDK. By default, Azure uses vector map tiles for its web map control (see <see href="https://docs.microsoft.com/azure/location-based-services/zoom-levels-and-tile-grid">Zoom Levels and Tile Grid</see>)
        /// Note: Weather tiles are only available via <see href="https://aka.ms/AzureMapsWeatherTiles">Get Map Tile V2 API</see>. We recommend to start to use the new <see href="https://aka.ms/GetMapTileV2">Get Map Tile V2 API</see>.
        /// </summary>
        /// <param name="options"> The options for configuring the static image. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual async Task<Response<Stream>> GetMapTileAsync(GetMapTileOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using var scope = _clientDiagnostics.CreateScope("MapsRenderingClient.GetMapTile");
            scope.Start();
            try
            {
                LocalizedMapView? localizedMapView = null;
                if (options?.LocalizedMapView != null)
                {
                    localizedMapView = new LocalizedMapView(options?.LocalizedMapView.ToString());
                }
                string language = null;
                if (options?.Language != null)
                {
                    language = options.Language.ToString();
                }
                var response = await restClient.GetMapTileAsync(
                    options.MapTileSetId,
                    options?.MapTileIndex,
                    options?.TimeStamp,
                    options?.MapTileSize,
                    language,
                    localizedMapView,
                    cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Fetches map tiles in vector or raster format typically to be integrated into a new map control or SDK. By default, Azure uses vector map tiles for its web map control (see <see href="https://docs.microsoft.com/azure/location-based-services/zoom-levels-and-tile-grid">Zoom Levels and Tile Grid</see>)
        /// Note: Weather tiles are only available via <see href="https://aka.ms/AzureMapsWeatherTiles">Get Map Tile V2 API</see>. We recommend to start to use the new <see href="https://aka.ms/GetMapTileV2">Get Map Tile V2 API</see>.
        /// </summary>
        /// <param name="options"> The options for configuring the static image. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual Response<Stream> GetMapTile(GetMapTileOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using var scope = _clientDiagnostics.CreateScope("MapsRenderingClient.GetMapTile");
            scope.Start();
            try
            {
                LocalizedMapView? localizedMapView = null;
                if (options?.LocalizedMapView != null)
                {
                    localizedMapView = new LocalizedMapView(options?.LocalizedMapView.ToString());
                }
                string language = null;
                if (options?.Language != null)
                {
                    language = options.Language.ToString();
                }
                var response = restClient.GetMapTile(
                    options.MapTileSetId,
                    options?.MapTileIndex,
                    options?.TimeStamp,
                    options?.MapTileSize,
                    language,
                    localizedMapView,
                    cancellationToken);
                return Response.FromValue(response.Value, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The Get Map Attribution API allows users to request map copyright attribution information for a section of a tileset.
        /// </summary>
        /// <param name="tileSetId"> A tileset is a collection of raster or vector data broken up into a uniform grid of square tiles at preset zoom levels. Every tileset has a <see cref="MapTileSetId"/> to use when making requests. The <see cref="MapTileSetId"/> for tilesets created using <see href="https://aka.ms/amcreator">Azure Maps Creator</see> are generated through the <see href="https://docs.microsoft.com/rest/api/maps-creator/tileset">Tileset Create API</see>. The ready-to-use tilesets supplied by Azure Maps are listed below. For example, <c>microsoft.base</c>. </param>
        /// <param name="zoom"> Zoom level for the desired map attribution. Available values are 0 to 22. </param>
        /// <param name="boundingBox"> The <see cref="GeoBoundingBox"/> that represents the rectangular area of a bounding box. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tileSetId"/> or <paramref name="boundingBox"/> is null. </exception>
        public virtual async Task<Response<IReadOnlyList<string>>> GetMapCopyrightAttributionAsync(MapTileSetId tileSetId, GeoBoundingBox boundingBox, int? zoom = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(boundingBox, nameof(boundingBox));

            using var scope = _clientDiagnostics.CreateScope("MapsRenderingClient.GetMapCopyrightAttribution");
            scope.Start();
            try
            {
                List<double> bounds = null;
                if (boundingBox != null)
                {
                    bounds = new List<double>();
                    bounds.Add(boundingBox.West);
                    bounds.Add(boundingBox.South);
                    bounds.Add(boundingBox.East);
                    bounds.Add(boundingBox.North);
                }
                var response = await restClient.GetMapAttributionAsync(
                    tileSetId, zoom ?? 0, bounds, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value.Copyrights, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The Get Map Attribution API allows users to request map copyright attribution information for a section of a tileset.
        /// </summary>
        /// <param name="tileSetId"> A tileset is a collection of raster or vector data broken up into a uniform grid of square tiles at preset zoom levels. Every tileset has a <see cref="MapTileSetId"/> to use when making requests. The <see cref="MapTileSetId"/> for tilesets created using <see href="https://aka.ms/amcreator">Azure Maps Creator</see> are generated through the <see href="https://docs.microsoft.com/rest/api/maps-creator/tileset">Tileset Create API</see>. The ready-to-use tilesets supplied by Azure Maps are listed below. For example, <c>microsoft.base</c>. </param>
        /// <param name="zoom"> Zoom level for the desired map attribution. Available values are 0 to 22. </param>
        /// <param name="boundingBox"> The <see cref="GeoBoundingBox"/> that represents the rectangular area of a bounding box. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tileSetId"/> or <paramref name="boundingBox"/> is null. </exception>
        public virtual Response<IReadOnlyList<string>> GetMapCopyrightAttribution(MapTileSetId tileSetId, GeoBoundingBox boundingBox, int? zoom = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(boundingBox, nameof(boundingBox));

            using var scope = _clientDiagnostics.CreateScope("MapsRenderingClient.GetMapCopyrightAttribution");
            scope.Start();
            try
            {
                List<double> bounds = null;
                if (boundingBox != null)
                {
                    bounds = new List<double>();
                    bounds.Add(boundingBox.West);
                    bounds.Add(boundingBox.South);
                    bounds.Add(boundingBox.East);
                    bounds.Add(boundingBox.North);
                }
                var response = restClient.GetMapAttribution(tileSetId, zoom ?? 0, bounds, cancellationToken);
                return Response.FromValue(response.Value.Copyrights, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The Get Map Tileset API allows users to request metadata for a tileset.
        /// </summary>
        /// <param name="tileSetId"> A tileset is a collection of raster or vector data broken up into a uniform grid of square tiles at preset zoom levels. Every tileset has a <see cref="MapTileSetId"/> to use when making requests. The <see cref="MapTileSetId"/> for tilesets created using <see href="https://aka.ms/amcreator">Azure Maps Creator</see> are generated through the <see href="https://docs.microsoft.com/rest/api/maps-creator/tileset">Tileset Create API</see>. The ready-to-use tilesets supplied by Azure Maps are listed below. For example, <c>microsoft.base</c>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tileSetId"/> is null. </exception>
        public virtual async Task<Response<MapTileSet>> GetMapTileSetAsync(MapTileSetId tileSetId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tileSetId, nameof(tileSetId));

            using var scope = _clientDiagnostics.CreateScope("MapsRenderingClient.GetMapTileSet");
            scope.Start();
            try
            {
                var response = await restClient.GetMapTilesetAsync(
                    tileSetId, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The Get Map Tileset API allows users to request metadata for a tileset.
        /// </summary>
        /// <param name="tileSetId"> A tileset is a collection of raster or vector data broken up into a uniform grid of square tiles at preset zoom levels. Every tileset has a <see cref="MapTileSetId"/> to use when making requests. The <see cref="MapTileSetId"/> for tilesets created using <see href="https://aka.ms/amcreator">Azure Maps Creator</see> are generated through the <see href="https://docs.microsoft.com/rest/api/maps-creator/tileset">Tileset Create API</see>. The ready-to-use tilesets supplied by Azure Maps are listed below. For example, <c>microsoft.base</c>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tileSetId"/> is null. </exception>
        public virtual Response<MapTileSet> GetMapTileSet(MapTileSetId tileSetId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tileSetId, nameof(tileSetId));

            using var scope = _clientDiagnostics.CreateScope("MapsRenderingClient.GetMapTileSet");
            scope.Start();
            try
            {
                var response = restClient.GetMapTileset(tileSetId, cancellationToken);
                return Response.FromValue(response.Value, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Serve copyright information for Render Tile service.
        /// In addition to basic copyright for the whole map, API is serving specific groups of copyrights for some countries.
        /// As an alternative to copyrights for map request, one can receive captions
        /// for displaying the map provider information on the map.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<CopyrightCaption>> GetCopyrightCaptionAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsRenderingClient.GetCopyrightCaption");
            scope.Start();
            try
            {
                return await restClient.GetCopyrightCaptionAsync(ResponseFormat.Json, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Serve copyright information for Render Tile service.
        /// In addition to basic copyright for the whole map, API is serving specific groups of copyrights for some countries.
        /// As an alternative to copyrights for map request, one can receive captions
        /// for displaying the map provider information on the map.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<CopyrightCaption> GetCopyrightCaption(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsRenderingClient.GetCopyrightCaption");
            scope.Start();
            try
            {
                return restClient.GetCopyrightCaption(ResponseFormat.Json, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Returns copyright information for a given bounding box. Bounding-box requests should specify the minimum and maximum longitude and latitude (EPSG-3857) coordinates
        /// </summary>
        /// <param name="geoBoundingBox"> Minimum coordinates (west, south, east, north) of bounding box in latitude longitude coordinate system. E.g. <c>GeoBoundingBox(4.84228, 52.41064, 4,84923, 52.41762)</c>. </param>
        /// <param name="includeText"> Boolean value to include or exclude textual data from response. If <c>false</c>, only images and country names will be in response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="geoBoundingBox"/> is null. </exception>
        public virtual async Task<Response<RenderCopyright>> GetCopyrightFromBoundingBoxAsync(GeoBoundingBox geoBoundingBox, bool includeText = true, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(geoBoundingBox, nameof(geoBoundingBox));

            using var scope = _clientDiagnostics.CreateScope("MapsRenderingClient.GetCopyrightFromBoundingBox");
            scope.Start();
            try
            {
                var boundingBox = new BoundingBox(new List<double>() { geoBoundingBox.South, geoBoundingBox.West }, new List<double>() { geoBoundingBox.North, geoBoundingBox.East });
                return await restClient.GetCopyrightFromBoundingBoxAsync(ResponseFormat.Json, boundingBox, includeText ? "yes" : "no", cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Returns copyright information for a given bounding box. Bounding-box requests should specify the minimum and maximum longitude and latitude (EPSG-3857) coordinates
        /// </summary>
        /// <param name="geoBoundingBox"> Minimum coordinates (west, south, east, north) of bounding box in latitude longitude coordinate system. E.g. <c>GeoBoundingBox(4.84228, 52.41064, 4,84923, 52.41762)</c>. </param>
        /// <param name="includeText"> Boolean value to include or exclude textual data from response. Iㄑ<c>false</c>, only images and country names will be in response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="geoBoundingBox"/> is null. </exception>
        public virtual Response<RenderCopyright> GetCopyrightFromBoundingBox(GeoBoundingBox geoBoundingBox, bool includeText = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(geoBoundingBox, nameof(geoBoundingBox));

            using var scope = _clientDiagnostics.CreateScope("MapsRenderingClient.GetCopyrightFromBoundingBox");
            scope.Start();
            try
            {
                var boundingBox = new BoundingBox(new List<double>() { geoBoundingBox.South, geoBoundingBox.West }, new List<double>() { geoBoundingBox.North, geoBoundingBox.East });
                return restClient.GetCopyrightFromBoundingBox(ResponseFormat.Json, boundingBox, includeText ? "yes" : "no", cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Serve copyright information for Render Tile  service. In addition to basic copyright for the whole map, API is serving  specific groups of copyrights for some countries.
        /// Returns the copyright information for a given tile. To obtain the copyright information for a particular tile, the request should specify the tile&apos;s zoom level and x and y coordinates (see: Zoom Levels and Tile Grid).
        /// </summary>
        /// <param name="mapTileIndex">
        /// Zoom level, and coordinate of the tile on zoom grid.
        /// The value of X and Y coordinate in <c>renderTileIndex</c> must be in the range [0, (2^zoom)-1]].
        /// Please see <see href="https://docs.microsoft.com/azure/location-based-services/zoom-levels-and-tile-grid">Zoom Levels and Tile Grid</see> for details.
        /// </param>
        /// <param name="includeText"> Boolean value to include or exclude textual data from response. If <c>false</c>, only images and country names will be in response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="mapTileIndex"/> is null. </exception>
        public virtual async Task<Response<RenderCopyright>> GetCopyrightForTileAsync(MapTileIndex mapTileIndex, bool includeText = true, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsRenderingClient.GetCopyrightForTile");
            scope.Start();
            try
            {
                return await restClient.GetCopyrightForTileAsync(ResponseFormat.Json, mapTileIndex, includeText ? "yes" : "no", cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Serve copyright information for Render Tile  service. In addition to basic copyright for the whole map, API is serving  specific groups of copyrights for some countries.
        /// Returns the copyright information for a given tile. To obtain the copyright information for a particular tile, the request should specify the tile&apos;s zoom level and x and y coordinates (see: Zoom Levels and Tile Grid).
        /// </summary>
        /// <param name="mapTileIndex">
        /// Zoom level, and coordinate of the tile on zoom grid.
        /// The value of X and Y coordinate in <c>renderTileIndex</c> must be in the range [0, (2^zoom)-1]].
        /// Please see <see href="https://docs.microsoft.com/azure/location-based-services/zoom-levels-and-tile-grid">Zoom Levels and Tile Grid</see> for details.
        /// </param>
        /// <param name="includeText"> Boolean value to include or exclude textual data from response. If <c>false</c>, only images and country names will be in response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="mapTileIndex"/> is null. </exception>
        public virtual Response<RenderCopyright> GetCopyrightForTile(MapTileIndex mapTileIndex, bool includeText = true, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsRenderingClient.GetCopyrightForTile");
            scope.Start();
            try
            {
                return restClient.GetCopyrightForTile(ResponseFormat.Json, mapTileIndex, includeText ? "yes" : "no", cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Serve copyright information for Render Tile  service. In addition to basic copyright for the whole map, API is serving  specific groups of copyrights for some countries.
        /// Returns the copyright information for the world. To obtain the default copyright information for the whole world, do not specify a tile or bounding box.
        /// </summary>
        /// <param name="includeText"> Boolean value to include or exclude textual data from response. If <c>false</c>, only images and country names will be in response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<RenderCopyright>> GetCopyrightForWorldAsync(bool includeText = true, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsRenderingClient.GetCopyrightForWorld");
            scope.Start();
            try
            {
                return await restClient.GetCopyrightForWorldAsync(ResponseFormat.Json, includeText ? "yes" : "no", cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Serve copyright information for Render Tile  service. In addition to basic copyright for the whole map, API is serving  specific groups of copyrights for some countries.
        /// Returns the copyright information for the world. To obtain the default copyright information for the whole world, do not specify a tile or bounding box.
        /// </summary>
        /// <param name="includeText"> Boolean value to include or exclude textual data from response. If <c>false</c>, only images and country names will be in response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<RenderCopyright> GetCopyrightForWorld(bool includeText = true, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsRenderingClient.GetCopyrightForWorld");
            scope.Start();
            try
            {
                return restClient.GetCopyrightForWorld(ResponseFormat.Json, includeText ? "yes" : "no", cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private const double MinLatitude = -85.05112878;
        private const double MaxLatitude = 85.05112878;
        private const double MinLongitude = -180;
        private const double MaxLongitude = 180;

        /// <summary>
        /// Clips a number to the specified minimum and maximum values.
        /// </summary>
        /// <param name="n">The number to clip.</param>
        /// <param name="minValue">Minimum allowable value.</param>
        /// <param name="maxValue">Maximum allowable value.</param>
        /// <returns>The clipped value.</returns>
        private static double Clip(double n, double minValue, double maxValue)
        {
            return Math.Min(Math.Max(n, minValue), maxValue);
        }

        /// <summary>
        /// Calculates width and height of the map in pixels at a specific zoom level from -180 degrees to 180 degrees.
        /// </summary>
        /// <param name="zoom">Zoom Level to calculate width at.</param>
        /// <param name="tileSize">The size of the tiles in the tile pyramid.</param>
        /// <returns>Width and height of the map in pixels</returns>
        private static double MapSize(double zoom, int tileSize)
        {
            return Math.Ceiling(tileSize * Math.Pow(2, zoom));
        }

        /// <summary>
        /// Global Converts a Pixel coordinate into a geospatial coordinate at a specified zoom level.
        /// Global Pixel coordinates are relative to the top left corner of the map (90, -180)
        /// </summary>
        /// <param name="pixel">Pixel coordinates in the format of GeoPosition.</param>
        /// <param name="zoom">Zoom level</param>
        /// <param name="tileSize">The size of the tiles in the tile pyramid.</param>
        /// <returns>A position value in the format GeoPosition.</returns>
        private static GeoPosition GlobalPixelToPosition(GeoPosition pixel, double zoom, int tileSize)
        {
            var mapSize = MapSize(zoom, tileSize);

            var x = (Clip(pixel.Longitude, 0, mapSize - 1) / mapSize) - 0.5;
            var y = 0.5 - (Clip(pixel.Latitude, 0, mapSize - 1) / mapSize);

            return new GeoPosition(
                360 * x,    //Longitude
                90 - 360 * Math.Atan(Math.Exp(-y * 2 * Math.PI)) / Math.PI  //Latitude
            );
        }

        /// <summary>
        /// Calculates the XY tile coordinates that a coordinate falls into for a specific zoom level.
        /// </summary>
        /// <param name="position">Position coordinate in the format of GeoPosition</param>
        /// <param name="zoom">Zoom level</param>
        /// <param name="tileSize">The size of the tiles in the tile pyramid.</param>
        /// <returns>A tile index contains the tile X, Y index and zoom level.</returns>
        public static MapTileIndex PositionToTileXY(GeoPosition position, int zoom, int tileSize)
        {
            var latitude = Clip(position.Latitude, MinLatitude, MaxLatitude);
            var longitude = Clip(position.Longitude, MinLongitude, MaxLongitude);

            var x = (longitude + 180) / 360;
            var sinLatitude = Math.Sin(latitude * Math.PI / 180);
            var y = 0.5 - Math.Log((1 + sinLatitude) / (1 - sinLatitude)) / (4 * Math.PI);

            //tileSize needed in calculations as in rare cases the multiplying/rounding/dividing can make the difference of a pixel which can result in a completely different tile.
            var mapSize = MapSize(zoom, tileSize);
            var tileX = (int)Math.Floor(Clip(x * mapSize + 0.5, 0, mapSize - 1) / tileSize);
            var tileY = (int)Math.Floor(Clip(y * mapSize + 0.5, 0, mapSize - 1) / tileSize);

            return new MapTileIndex(tileX, tileY, zoom);
        }

        /// <summary>
        /// Calculates the bounding box of a tile.
        /// </summary>
        /// <param name="mapTileIndex">Tile X, Y coordinate and zoom level</param>
        /// <param name="tileSize">The size of the tiles in the tile pyramid.</param>
        /// <returns>A bounding box of the tile defined as an array of numbers in the format of GeoBoundingBox.</returns>
        public static GeoBoundingBox TileXYToBoundingBox(MapTileIndex mapTileIndex, int tileSize)
        {
            //Top left corner pixel coordinates
            var x1 = (double)(mapTileIndex.X * tileSize);
            var y1 = (double)(mapTileIndex.Y * tileSize);

            //Bottom right corner pixel coordinates
            var x2 = (double)(x1 + tileSize);
            var y2 = (double)(y1 + tileSize);

            var nw = GlobalPixelToPosition(new GeoPosition(x1, y1), mapTileIndex.Z, tileSize);
            var se = GlobalPixelToPosition(new GeoPosition(x2, y2), mapTileIndex.Z, tileSize);

            return new GeoBoundingBox(nw.Longitude, se.Latitude, se.Longitude, nw.Latitude);
        }
    }
}
