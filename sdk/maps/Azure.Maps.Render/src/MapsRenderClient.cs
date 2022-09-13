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
using Azure.Maps.Render.Models;

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
        /// <param name="endpoint"> server parameter. </param>
        public MapsRenderClient(AzureKeyCredential credential, Uri endpoint)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var options = new MapsRenderClientOptions();
            endpoint ??= new Uri("https://atlas.microsoft.com");
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, "subscription-key"));
            restClient = new RenderRestClient(_clientDiagnostics, _pipeline, endpoint, null, options.Version);
        }

        /// <summary> Initializes a new instance of MapsRenderClient. </summary>
        /// <param name="credential"> Shared key credential used to authenticate to an Azure Maps Render Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public MapsRenderClient(AzureKeyCredential credential, Uri endpoint = null, MapsRenderClientOptions options = null)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            endpoint ??= new Uri("https://atlas.microsoft.com");
            options ??= new MapsRenderClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, "subscription-key"));
            restClient = new RenderRestClient(_clientDiagnostics, _pipeline, endpoint, null, options.Version);
        }

        /// <summary> Initializes a new instance of MapsRenderClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Maps Render Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="clientId"> Specifies which account is intended for usage in conjunction with the Azure AD security model.  It represents a unique ID for the Azure Maps account and can be retrieved from the Azure Maps management  plane Account API. To use Azure AD security in Azure Maps see the following <see href="https://aka.ms/amauthdetails">articles</see> for guidance. </param>
        public MapsRenderClient(TokenCredential credential, Uri endpoint, string clientId)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            endpoint ??= new Uri("https://atlas.microsoft.com");
            var options = new MapsRenderClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            string[] scopes = { "https://atlas.microsoft.com/.default" };
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, scopes), new AzureKeyCredentialPolicy(new AzureKeyCredential(clientId), "x-ms-client-id"));
            restClient = new RenderRestClient(_clientDiagnostics, _pipeline, endpoint, clientId, options.Version);
        }

        /// <summary> Initializes a new instance of MapsRenderClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Maps Render Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="clientId"> Specifies which account is intended for usage in conjunction with the Azure AD security model.  It represents a unique ID for the Azure Maps account and can be retrieved from the Azure Maps management  plane Account API. To use Azure AD security in Azure Maps see the following <see href="https://aka.ms/amauthdetails">articles</see> for guidance. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public MapsRenderClient(TokenCredential credential, Uri endpoint = null, string clientId = null, MapsRenderClientOptions options = null)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            endpoint ??= new Uri("https://atlas.microsoft.com");
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
                var response = await restClient.GetMapStaticImageAsync(
                    options?.Format,
                    options?.Layer,
                    options?.Style,
                    options?.Zoom,
                    options?.Center,
                    options?.BoundingBox,
                    options?.Height,
                    options?.Width,
                    options?.Language,
                    options?.LocalizedMapView,
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
                var response = restClient.GetMapStaticImage(
                    options?.Format,
                    options?.Layer,
                    options?.Style,
                    options?.Zoom,
                    options?.Center,
                    options?.BoundingBox,
                    options?.Height,
                    options?.Width,
                    options?.Language,
                    options?.LocalizedMapView,
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
        /// <param name="style"> Map style to be returned. Allowed values: <c>MapImageryStyle.Satellite</c>. </param>
        /// <param name="format"> Desired format of the tile. Allowed values: <c>RasterTileFormat.Png</c>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tileIndex"/>, <paramref name="format"/> or <paramref name="style"/> is null. </exception>
        public virtual async Task<Response<Stream>> GetMapImageryTileAsync(TileIndex tileIndex, MapImageryStyle? style = null, RasterTileFormat? format = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsRenderClient.GetMapImageryTile");
            scope.Start();
            try
            {
                var response = await restClient.GetMapImageryTileAsync(tileIndex, style, format, cancellationToken).ConfigureAwait(false);
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
        /// <param name="style"> Map style to be returned. Allowed values: <c>MapImageryStyle.Satellite</c>. </param>
        /// <param name="format"> Desired format of the tile. Allowed values: <c>RasterTileFormat.Png</c>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tileIndex"/>, <paramref name="format"/> or <paramref name="style"/> is null. </exception>
        public virtual Response<Stream> GetMapImageryTile(TileIndex tileIndex, MapImageryStyle? style = null, RasterTileFormat? format = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsRenderClient.GetMapImageryTile");
            scope.Start();
            try
            {
                var response = restClient.GetMapImageryTile(tileIndex, style, format, cancellationToken);
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
        /// The value of X and Y coordinate in <c>tileIndex</c> must be in the range [0, 2&lt;sup&gt;`zoom`&lt;/sup&gt; -1].
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
        /// The value of X and Y coordinate in <c>tileIndex</c> must be in the range [0, 2&lt;sup&gt;`zoom`&lt;/sup&gt; -1].
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
                var response = await restClient.GetMapTileAsync(
                    options.Format,
                    options.Layer,
                    options.Style,
                    options.TileIndex,
                    options?.TileSize,
                    options?.Language,
                    options?.LocalizedMapView,
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
                var response = restClient.GetMapTile(
                    options.Format,
                    options.Layer,
                    options.Style,
                    options.TileIndex,
                    options?.TileSize,
                    options?.Language,
                    options?.LocalizedMapView,
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
        /// <param name="format"> Desired format of the response. Value can be either <c>ResponseFormat.Json</c> or <c>ResponseFormat.Xml</c>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<CopyrightCaption>> GetCopyrightCaptionAsync(ResponseFormat? format = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsRenderClient.GetCopyrightCaption");
            scope.Start();
            try
            {
                return await restClient.GetCopyrightCaptionAsync(format, cancellationToken).ConfigureAwait(false);
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
        /// <param name="format"> Desired format of the response. Value can be either <c>ResponseFormat.Json</c> or <c>ResponseFormat.Xml</c>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<CopyrightCaption> GetCopyrightCaption(ResponseFormat? format = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsRenderClient.GetCopyrightCaption");
            scope.Start();
            try
            {
                return restClient.GetCopyrightCaption(format, cancellationToken);
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
        /// <param name="format"> Desired format of the response. Value can be either <c>ResponseFormat.Json</c> or <c>ResponseFormat.Xml</c>. </param>
        /// <param name="includeText"> Boolean value to include or exclude textual data from response. Only images and country names will be in response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="geoBoundingBox"/> is null. </exception>
        public virtual async Task<Response<RenderCopyrights>> GetCopyrightFromBoundingBoxAsync(GeoBoundingBox geoBoundingBox, ResponseFormat? format = null, bool includeText = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(geoBoundingBox, nameof(geoBoundingBox));

            using var scope = _clientDiagnostics.CreateScope("MapsRenderClient.GetCopyrightFromBoundingBox");
            scope.Start();
            try
            {
                var boundingBox = new BoundingBox(new List<double>() { geoBoundingBox.South, geoBoundingBox.West }, new List<double>() { geoBoundingBox.North, geoBoundingBox.East });
                return await restClient.GetCopyrightFromBoundingBoxAsync(boundingBox, format, includeText ? "yes" : "no", cancellationToken).ConfigureAwait(false);
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
        /// <param name="format"> Desired format of the response. Value can be either <c>ResponseFormat.Json</c> or <c>ResponseFormat.Xml</c>. </param>
        /// <param name="includeText"> Boolean value to include or exclude textual data from response. Only images and country names will be in response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="geoBoundingBox"/> or <paramref name="format"/> is null. </exception>
        public virtual Response<RenderCopyrights> GetCopyrightFromBoundingBox(GeoBoundingBox geoBoundingBox, ResponseFormat? format = null, bool includeText = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(geoBoundingBox, nameof(geoBoundingBox));

            using var scope = _clientDiagnostics.CreateScope("MapsRenderClient.GetCopyrightFromBoundingBox");
            scope.Start();
            try
            {
                var boundingBox = new BoundingBox(new List<double>() { geoBoundingBox.South, geoBoundingBox.West }, new List<double>() { geoBoundingBox.North, geoBoundingBox.East });
                return restClient.GetCopyrightFromBoundingBox(boundingBox, format, includeText ? "yes" : "no", cancellationToken);
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
        /// <param name="format"> Desired format of the response. Value can be either <c>ResponseFormat.Json</c> or <c>ResponseFormat.Xml</c>. </param>
        /// <param name="includeText"> Boolean value to include or exclude textual data from response. Only images and country names will be in response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tileIndex"/> is null. </exception>
        public virtual async Task<Response<RenderCopyrights>> GetCopyrightForTileAsync(TileIndex tileIndex, ResponseFormat? format = null, bool includeText = false, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsRenderClient.GetCopyrightForTile");
            scope.Start();
            try
            {
                return await restClient.GetCopyrightForTileAsync(tileIndex, format, includeText ? "yes" : "no", cancellationToken).ConfigureAwait(false);
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
        /// <param name="format"> Desired format of the response. Value can be either <c>ResponseFormat.Json</c> or <c>ResponseFormat.Xml</c>. </param>
        /// <param name="includeText"> Boolean value to include or exclude textual data from response. Only images and country names will be in response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tileIndex"/> is null. </exception>
        public virtual Response<RenderCopyrights> GetCopyrightForTile(TileIndex tileIndex, ResponseFormat? format = null, bool includeText = false, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsRenderClient.GetCopyrightForTile");
            scope.Start();
            try
            {
                return restClient.GetCopyrightForTile(tileIndex, format, includeText ? "yes" : "no", cancellationToken);
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
        /// <param name="format"> Desired format of the response. Value can be either <c>ResponseFormat.Json</c> or <c>ResponseFormat.Xml</c>. </param>
        /// <param name="includeText"> Boolean value to include or exclude textual data from response. Only images and country names will be in response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<RenderCopyrights>> GetCopyrightForWorldAsync(ResponseFormat? format = null, bool includeText = false, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsRenderClient.GetCopyrightForWorld");
            scope.Start();
            try
            {
                return await restClient.GetCopyrightForWorldAsync(format, includeText ? "yes" : "no", cancellationToken).ConfigureAwait(false);
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
        /// <param name="format"> Desired format of the response. Value can be either <c>ResponseFormat.Json</c> or <c>ResponseFormat.Xml</c>. </param>
        /// <param name="includeText"> Boolean value to include or exclude textual data from response. Only images and country names will be in response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<RenderCopyrights> GetCopyrightForWorld(ResponseFormat? format = null, bool includeText = false, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsRenderClient.GetCopyrightForWorld");
            scope.Start();
            try
            {
                return restClient.GetCopyrightForWorld(format, includeText ? "yes" : "no", cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
