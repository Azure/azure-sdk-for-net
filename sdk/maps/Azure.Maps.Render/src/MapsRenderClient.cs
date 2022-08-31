// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.GeoJson;
using Azure.Core.Pipeline;

namespace Azure.Maps.Render
{
    /// <summary> The Render service client. </summary>
    public partial class MapsRenderClient
    {
        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        private readonly HttpPipeline _pipeline;

        /// <summary> The restClient is used to access Render REST client. </summary>
        internal RenderRestClient restClient { get; }

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics _clientDiagnostics { get; }

        /// <summary> Initializes a new instance of MapsRenderClient. </summary>
        protected MapsRenderClient()
        {
            _clientDiagnostics = null;
            _pipeline = null;
            restClient = null;
        }

        /// <summary> Initializes a new instance of MapsRenderClient. </summary>
        /// <param name="credential"> Shared key credential used to authenticate to an Azure Maps Render Service. </param>
        public MapsRenderClient(AzureKeyCredential credential)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = new Uri("https://atlas.microsoft.com");
            var options = new MapsRenderClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, "subscription-key"));
            restClient = new RenderRestClient(_clientDiagnostics, _pipeline, endpoint, null, options.Version);
        }

        /// <summary> Initializes a new instance of MapsRenderClient. </summary>
        /// <param name="credential"> Shared key credential used to authenticate to an Azure Maps Render Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public MapsRenderClient(AzureKeyCredential credential, MapsRenderClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = options.Endpoint ?? new Uri("https://atlas.microsoft.com");
            options ??= new MapsRenderClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, "subscription-key"));
            restClient = new RenderRestClient(_clientDiagnostics, _pipeline, endpoint, null, options.Version);
        }

        /// <summary> Initializes a new instance of MapsRenderClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Maps Render Service. </param>
        /// <param name="clientId"> Specifies which account is intended for usage in conjunction with the Azure AD security model.  It represents a unique ID for the Azure Maps account and can be retrieved from the Azure Maps management  plane Account API. To use Azure AD security in Azure Maps see the following <see href="https://aka.ms/amauthdetails">articles</see> for guidance. </param>
        public MapsRenderClient(TokenCredential credential, string clientId)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = new Uri("https://atlas.microsoft.com");
            var options = new MapsRenderClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            string[] scopes = { "https://atlas.microsoft.com/.default" };
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, scopes), new AzureKeyCredentialPolicy(new AzureKeyCredential(clientId), "x-ms-client-id"));
            restClient = new RenderRestClient(_clientDiagnostics, _pipeline, endpoint, clientId, options.Version);
        }

        /// <summary> Initializes a new instance of MapsRenderClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Maps Render Service. </param>
        /// <param name="clientId"> Specifies which account is intended for usage in conjunction with the Azure AD security model.  It represents a unique ID for the Azure Maps account and can be retrieved from the Azure Maps management  plane Account API. To use Azure AD security in Azure Maps see the following <see href="https://aka.ms/amauthdetails">articles</see> for guidance. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public MapsRenderClient(TokenCredential credential, string clientId, MapsRenderClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = options.Endpoint ?? new Uri("https://atlas.microsoft.com");
            options ??= new MapsRenderClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            string[] scopes = { "https://atlas.microsoft.com/.default" };
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, scopes), new AzureKeyCredentialPolicy(new AzureKeyCredential(clientId), "x-ms-client-id"));
            restClient = new RenderRestClient(_clientDiagnostics, _pipeline, endpoint, clientId, options.Version);
        }

        /// <summary> Initializes a new instance of MapsRenderClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="clientId"> Specifies which account is intended for usage in conjunction with the Azure AD security model.  It represents a unique ID for the Azure Maps account and can be retrieved from the Azure Maps management  plane Account API. To use Azure AD security in Azure Maps see the following <see href="https://aka.ms/amauthdetails">articles</see> for guidance. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        internal MapsRenderClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null, string clientId = null, MapsRenderClientOptions.ServiceVersion apiVersion = MapsRenderClientOptions.LatestVersion)
        {
            var options = new MapsRenderClientOptions(apiVersion);
            restClient = new RenderRestClient(clientDiagnostics, pipeline, endpoint, clientId, options.Version);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary>
        /// The API renders a user-defined, rectangular image containing a map section using a zoom level from 0 to 20. The static image service renders a user-defined, rectangular image containing a map section using a zoom level from 0 to 20. The supported resolution range for the map image is from 1x1 to 8192x8192. If you are deciding when to use the static image service over the map tile service, you may want to consider how you would like to interact with the rendered map. If the map contents will be relatively unchanging, a static map is a good choice. If you want to support a lot of zooming, panning and changing of the map content, the map tile service would be a better choice.
        /// Service also provides Image Composition functionality to get a static image back with additional data like; pushpins and geometry overlays with following S0 and S1 capabilities.
        /// </summary>
        /// <param name="options"> The options for configuring the static image. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Stream>> GetMapStaticImageAsync(RenderStaticImageOptions options, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsRenderClient.GetMapStaticImage");
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
                var response = await restClient.GetMapStaticImageAsync(
                    RasterTileFormat.Png,
                    options?.TileLayer,
                    options?.TileStyle,
                    options?.ZoomLevel,
                    coordinate,
                    boundingBox,
                    options?.HeightInPixels,
                    options?.WidthInPixels,
                    options?.RenderLanguage,
                    localizedMapView,
                    options?.Pins,
                    options?.Path,
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
        /// The API renders a user-defined, rectangular image containing a map section using a zoom level from 0 to 20. The static image service renders a user-defined, rectangular image containing a map section using a zoom level from 0 to 20. The supported resolution range for the map image is from 1x1 to 8192x8192. If you are deciding when to use the static image service over the map tile service, you may want to consider how you would like to interact with the rendered map. If the map contents will be relatively unchanging, a static map is a good choice. If you want to support a lot of zooming, panning and changing of the map content, the map tile service would be a better choice.
        /// Service also provides Image Composition functionality to get a static image back with additional data like; pushpins and geometry overlays with following S0 and S1 capabilities.
        /// </summary>
        /// <param name="options"> The options for configuring the static image. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Stream> GetMapStaticImage(RenderStaticImageOptions options, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsRenderClient.GetMapStaticImage");
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
                var response = restClient.GetMapStaticImage(
                    RasterTileFormat.Png,
                    options?.TileLayer,
                    options?.TileStyle,
                    options?.ZoomLevel,
                    coordinate,
                    boundingBox,
                    options?.HeightInPixels,
                    options?.WidthInPixels,
                    options?.RenderLanguage,
                    localizedMapView,
                    options?.Pins,
                    options?.Path,
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
        /// This API returns a map image tile with size 256x256, given the x and y coordinates and zoom
        /// level. Zoom level ranges from 1 to 19. The current available style value is &apos;satellite&apos; which provides satellite
        /// imagery alone.
        /// </summary>
        /// <param name="tileIndex">
        /// Zoom level, and coordinate of the tile on zoom grid.
        /// The value of X and Y coordinate in <c>tileIndex</c> must be in the range [0, 2&lt;sup&gt;`zoom`&lt;/sup&gt; -1].
        /// Please see <see href="https://docs.microsoft.com/azure/location-based-services/zoom-levels-and-tile-grid">Zoom Levels and Tile Grid</see> for details.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tileIndex"/> is null. </exception>
        public virtual async Task<Response<Stream>> GetMapImageryTileAsync(TileIndex tileIndex, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsRenderClient.GetMapImageryTile");
            scope.Start();
            try
            {
                var response = await restClient.GetMapImageryTileAsync(tileIndex, RasterTileFormat.Png, MapImageryStyle.Satellite, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// This API returns a map image tile with size 256x256, given the x and y coordinates and zoom
        /// level. Zoom level ranges from 1 to 19. The current available style value is &apos;satellite&apos; which provides satellite
        /// imagery alone.
        /// </summary>
        /// <param name="tileIndex">
        /// Zoom level, and coordinate of the tile on zoom grid.
        /// The value of X and Y coordinate in <c>tileIndex</c> must be in the range [0, 2&lt;sup&gt;`zoom`&lt;/sup&gt; -1].
        /// Please see <see href="https://docs.microsoft.com/azure/location-based-services/zoom-levels-and-tile-grid">Zoom Levels and Tile Grid</see> for details.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tileIndex"/> is null. </exception>
        public virtual Response<Stream> GetMapImageryTile(TileIndex tileIndex, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsRenderClient.GetMapImageryTile");
            scope.Start();
            try
            {
                var response = restClient.GetMapImageryTile(tileIndex, RasterTileFormat.Png, MapImageryStyle.Satellite, cancellationToken);
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
        /// <param name="statesetId"> The state set id. </param>
        /// <param name="tileIndex">
        /// Zoom level, and coordinate of the tile on zoom grid.
        /// The value of X and Y coordinate in <c>tileIndex</c> must be in the range [0, (2^zoom)-1].
        /// Please see <see href="https://docs.microsoft.com/azure/location-based-services/zoom-levels-and-tile-grid">Zoom Levels and Tile Grid</see> for details.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="statesetId"/> or <paramref name="tileIndex"/> is null. </exception>
        public virtual async Task<Response<Stream>> GetMapStateTileAsync(string statesetId, TileIndex tileIndex, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsRenderClient.GetMapStateTile");
            scope.Start();
            try
            {
                var response = await restClient.GetMapStateTileAsync(statesetId, tileIndex, cancellationToken).ConfigureAwait(false);
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
        /// <param name="statesetId"> The state set id. </param>
        /// <param name="tileIndex">
        /// Zoom level, and coordinate of the tile on zoom grid.
        /// The value of X and Y coordinate in <c>tileIndex</c> must be in the range [0, (2^zoom)-1].
        /// Please see <see href="https://docs.microsoft.com/azure/location-based-services/zoom-levels-and-tile-grid">Zoom Levels and Tile Grid</see> for details.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="statesetId"/> is null. </exception>
        public virtual Response<Stream> GetMapStateTile(string statesetId, TileIndex tileIndex, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(statesetId, nameof(statesetId));

            using var scope = _clientDiagnostics.CreateScope("MapsRenderClient.GetMapStateTile");
            scope.Start();
            try
            {
                var response = restClient.GetMapStateTile(statesetId, tileIndex, cancellationToken);
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
        /// **Note**: Weather tiles are only available via <see href="https://aka.ms/AzureMapsWeatherTiles">Get Map Tile V2 API</see>. We recommend to start to use the new <see href="https://aka.ms/GetMapTileV2">Get Map Tile V2 API</see>.
        /// </summary>
        /// <param name="options"> The options for configuring the static image. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual async Task<Response<Stream>> GetMapTileAsync(RenderTileOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using var scope = _clientDiagnostics.CreateScope("MapsRenderClient.GetMapTile");
            scope.Start();
            try
            {
                LocalizedMapView? localizedMapView = null;
                if (options?.LocalizedMapView != null)
                {
                    localizedMapView = new LocalizedMapView(options?.LocalizedMapView.ToString());
                }
                var response = await restClient.GetMapTileAsync(
                    options.TileFormat,
                    options.TileLayer,
                    options.TileStyle,
                    options.TileIndex,
                    options?.TileSize,
                    options?.RenderLanguage,
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
        /// **Note**: Weather tiles are only available via <see href="https://aka.ms/AzureMapsWeatherTiles">Get Map Tile V2 API</see>. We recommend to start to use the new <see href="https://aka.ms/GetMapTileV2">Get Map Tile V2 API</see>.
        /// </summary>
        /// <param name="options"> The options for configuring the static image. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual Response<Stream> GetMapTile(RenderTileOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using var scope = _clientDiagnostics.CreateScope("MapsRenderClient.GetMapTile");
            scope.Start();
            try
            {
                LocalizedMapView? localizedMapView = null;
                if (options?.LocalizedMapView != null)
                {
                    localizedMapView = new LocalizedMapView(options?.LocalizedMapView.ToString());
                }
                var response = restClient.GetMapTile(
                    options.TileFormat,
                    options.TileLayer,
                    options.TileStyle,
                    options.TileIndex,
                    options?.TileSize,
                    options?.RenderLanguage,
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
        /// RenderCopyrights API is designed to serve copyright information for Render Tile
        /// service. In addition to basic copyright for the whole map, API is serving
        /// specific groups of copyrights for some countries.
        ///
        /// As an alternative to copyrights for map request, one can receive captions
        /// for displaying the map provider information on the map.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<CopyrightCaption>> GetCopyrightCaptionAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsRenderClient.GetCopyrightCaption");
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
        /// RenderCopyrights API is designed to serve copyright information for Render Tile
        /// service. In addition to basic copyright for the whole map, API is serving
        /// specific groups of copyrights for some countries.
        /// As an alternative to copyrights for map request, one can receive captions
        /// for displaying the map provider information on the map.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<CopyrightCaption> GetCopyrightCaption(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsRenderClient.GetCopyrightCaption");
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
        /// <param name="includeText"> Boolean value to include or exclude textual data from response. Only images and country names will be in response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="geoBoundingBox"/> is null. </exception>
        public virtual async Task<Response<RenderCopyrights>> GetCopyrightFromBoundingBoxAsync(GeoBoundingBox geoBoundingBox, bool includeText = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(geoBoundingBox, nameof(geoBoundingBox));

            using var scope = _clientDiagnostics.CreateScope("MapsRenderClient.GetCopyrightFromBoundingBox");
            scope.Start();
            try
            {
                var boundingBox = new BoundingBox(new List<double>() { geoBoundingBox.South, geoBoundingBox.West }, new List<double>() { geoBoundingBox.North, geoBoundingBox.East });
                return await restClient.GetCopyrightFromBoundingBoxAsync(boundingBox, ResponseFormat.Json, includeText ? "yes" : "no", cancellationToken).ConfigureAwait(false);
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
        /// <param name="includeText"> Boolean value to include or exclude textual data from response. Only images and country names will be in response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="geoBoundingBox"/> is null. </exception>
        public virtual Response<RenderCopyrights> GetCopyrightFromBoundingBox(GeoBoundingBox geoBoundingBox, bool includeText = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(geoBoundingBox, nameof(geoBoundingBox));

            using var scope = _clientDiagnostics.CreateScope("MapsRenderClient.GetCopyrightFromBoundingBox");
            scope.Start();
            try
            {
                var boundingBox = new BoundingBox(new List<double>() { geoBoundingBox.South, geoBoundingBox.West }, new List<double>() { geoBoundingBox.North, geoBoundingBox.East });
                return restClient.GetCopyrightFromBoundingBox(boundingBox, ResponseFormat.Json, includeText ? "yes" : "no", cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// RenderCopyrights API is designed to serve copyright information for Render Tile  service. In addition to basic copyright for the whole map, API is serving  specific groups of copyrights for some countries.
        /// Returns the copyright information for a given tile. To obtain the copyright information for a particular tile, the request should specify the tile&apos;s zoom level and x and y coordinates (see: Zoom Levels and Tile Grid).
        /// </summary>
        /// <param name="tileIndex">
        /// Zoom level, and coordinate of the tile on zoom grid.
        /// The value of X and Y coordinate in <c>tileIndex</c> must be in the range [0, 2&lt;sup&gt;`zoom`&lt;/sup&gt; -1].
        /// Please see <see href="https://docs.microsoft.com/azure/location-based-services/zoom-levels-and-tile-grid">Zoom Levels and Tile Grid</see> for details.
        /// </param>
        /// <param name="includeText"> Boolean value to include or exclude textual data from response. Only images and country names will be in response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tileIndex"/> is null. </exception>
        public virtual async Task<Response<RenderCopyrights>> GetCopyrightForTileAsync(TileIndex tileIndex, bool includeText = false, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsRenderClient.GetCopyrightForTile");
            scope.Start();
            try
            {
                return await restClient.GetCopyrightForTileAsync(tileIndex, ResponseFormat.Json, includeText ? "yes" : "no", cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// RenderCopyrights API is designed to serve copyright information for Render Tile  service. In addition to basic copyright for the whole map, API is serving  specific groups of copyrights for some countries.
        /// Returns the copyright information for a given tile. To obtain the copyright information for a particular tile, the request should specify the tile&apos;s zoom level and x and y coordinates (see: Zoom Levels and Tile Grid).
        /// </summary>
        /// <param name="tileIndex">
        /// Zoom level, and coordinate of the tile on zoom grid.
        /// The value of X and Y coordinate in <c>tileIndex</c> must be in the range [0, 2&lt;sup&gt;`zoom`&lt;/sup&gt; -1].
        /// Please see <see href="https://docs.microsoft.com/azure/location-based-services/zoom-levels-and-tile-grid">Zoom Levels and Tile Grid</see> for details.
        /// </param>
        /// <param name="includeText"> Boolean value to include or exclude textual data from response. Only images and country names will be in response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tileIndex"/> is null. </exception>
        public virtual Response<RenderCopyrights> GetCopyrightForTile(TileIndex tileIndex, bool includeText = false, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsRenderClient.GetCopyrightForTile");
            scope.Start();
            try
            {
                return restClient.GetCopyrightForTile(tileIndex, ResponseFormat.Json, includeText ? "yes" : "no", cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// RenderCopyrights API is designed to serve copyright information for Render Tile  service. In addition to basic copyright for the whole map, API is serving  specific groups of copyrights for some countries.
        /// Returns the copyright information for the world. To obtain the default copyright information for the whole world, do not specify a tile or bounding box.
        /// </summary>
        /// <param name="includeText"> Boolean value to include or exclude textual data from response. Only images and country names will be in response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<RenderCopyrights>> GetCopyrightForWorldAsync(bool includeText = false, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsRenderClient.GetCopyrightForWorld");
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
        /// RenderCopyrights API is designed to serve copyright information for Render Tile  service. In addition to basic copyright for the whole map, API is serving  specific groups of copyrights for some countries.
        /// Returns the copyright information for the world. To obtain the default copyright information for the whole world, do not specify a tile or bounding box.
        /// </summary>
        /// <param name="includeText"> Boolean value to include or exclude textual data from response. Only images and country names will be in response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<RenderCopyrights> GetCopyrightForWorld(bool includeText = false, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsRenderClient.GetCopyrightForWorld");
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
    }
}
