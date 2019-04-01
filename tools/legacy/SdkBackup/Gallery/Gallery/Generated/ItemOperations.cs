// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Hyak.Common;
using Microsoft.Azure.Gallery;
using Microsoft.Azure.Gallery.Models;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Gallery
{
    /// <summary>
    /// Operations for working with gallery items.
    /// </summary>
    internal partial class ItemOperations : IServiceOperations<GalleryClient>, IItemOperations
    {
        /// <summary>
        /// Initializes a new instance of the ItemOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        internal ItemOperations(GalleryClient client)
        {
            this._client = client;
        }
        
        private GalleryClient _client;
        
        /// <summary>
        /// Gets a reference to the Microsoft.Azure.Gallery.GalleryClient.
        /// </summary>
        public GalleryClient Client
        {
            get { return this._client; }
        }
        
        /// <summary>
        /// Gets a gallery items.
        /// </summary>
        /// <param name='itemIdentity'>
        /// Optional. Gallery item identity.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// Gallery item information.
        /// </returns>
        public async Task<ItemGetParameters> GetAsync(string itemIdentity, CancellationToken cancellationToken)
        {
            // Validate
            
            // Tracing
            bool shouldTrace = TracingAdapter.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = TracingAdapter.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("itemIdentity", itemIdentity);
                TracingAdapter.Enter(invocationId, this, "GetAsync", tracingParameters);
            }
            
            // Construct URL
            string url = "";
            url = url + "/Microsoft.Gallery/galleryitems/";
            if (itemIdentity != null)
            {
                url = url + Uri.EscapeDataString(itemIdentity);
            }
            List<string> queryParameters = new List<string>();
            queryParameters.Add("api-version=2015-04-01");
            queryParameters.Add("includePreview=true");
            if (queryParameters.Count > 0)
            {
                url = url + "?" + string.Join("&", queryParameters);
            }
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Get;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        TracingAdapter.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        TracingAdapter.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
                        if (shouldTrace)
                        {
                            TracingAdapter.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    ItemGetParameters result = null;
                    // Deserialize Response
                    if (statusCode == HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                        result = new ItemGetParameters();
                        JToken responseDoc = null;
                        if (string.IsNullOrEmpty(responseContent) == false)
                        {
                            responseDoc = JToken.Parse(responseContent);
                        }
                        
                        if (responseDoc != null && responseDoc.Type != JTokenType.Null)
                        {
                            GalleryItem itemInstance = new GalleryItem();
                            result.Item = itemInstance;
                            
                            JToken identityValue = responseDoc["identity"];
                            if (identityValue != null && identityValue.Type != JTokenType.Null)
                            {
                                string identityInstance = ((string)identityValue);
                                itemInstance.Identity = identityInstance;
                            }
                            
                            JToken itemNameValue = responseDoc["itemName"];
                            if (itemNameValue != null && itemNameValue.Type != JTokenType.Null)
                            {
                                string itemNameInstance = ((string)itemNameValue);
                                itemInstance.Name = itemNameInstance;
                            }
                            
                            JToken itemDisplayNameValue = responseDoc["itemDisplayName"];
                            if (itemDisplayNameValue != null && itemDisplayNameValue.Type != JTokenType.Null)
                            {
                                string itemDisplayNameInstance = ((string)itemDisplayNameValue);
                                itemInstance.DisplayName = itemDisplayNameInstance;
                            }
                            
                            JToken publisherValue = responseDoc["publisher"];
                            if (publisherValue != null && publisherValue.Type != JTokenType.Null)
                            {
                                string publisherInstance = ((string)publisherValue);
                                itemInstance.Publisher = publisherInstance;
                            }
                            
                            JToken publisherDisplayNameValue = responseDoc["publisherDisplayName"];
                            if (publisherDisplayNameValue != null && publisherDisplayNameValue.Type != JTokenType.Null)
                            {
                                string publisherDisplayNameInstance = ((string)publisherDisplayNameValue);
                                itemInstance.PublisherDisplayName = publisherDisplayNameInstance;
                            }
                            
                            JToken versionValue = responseDoc["version"];
                            if (versionValue != null && versionValue.Type != JTokenType.Null)
                            {
                                string versionInstance = ((string)versionValue);
                                itemInstance.Version = versionInstance;
                            }
                            
                            JToken summaryValue = responseDoc["summary"];
                            if (summaryValue != null && summaryValue.Type != JTokenType.Null)
                            {
                                string summaryInstance = ((string)summaryValue);
                                itemInstance.Summary = summaryInstance;
                            }
                            
                            JToken longSummaryValue = responseDoc["longSummary"];
                            if (longSummaryValue != null && longSummaryValue.Type != JTokenType.Null)
                            {
                                string longSummaryInstance = ((string)longSummaryValue);
                                itemInstance.LongSummary = longSummaryInstance;
                            }
                            
                            JToken descriptionValue = responseDoc["description"];
                            if (descriptionValue != null && descriptionValue.Type != JTokenType.Null)
                            {
                                string descriptionInstance = ((string)descriptionValue);
                                itemInstance.Description = descriptionInstance;
                            }
                            
                            JToken marketingMaterialValue = responseDoc["marketingMaterial"];
                            if (marketingMaterialValue != null && marketingMaterialValue.Type != JTokenType.Null)
                            {
                                MarketingMaterial marketingMaterialInstance = new MarketingMaterial();
                                itemInstance.MarketingMaterial = marketingMaterialInstance;
                                
                                JToken pathValue = marketingMaterialValue["path"];
                                if (pathValue != null && pathValue.Type != JTokenType.Null)
                                {
                                    string pathInstance = ((string)pathValue);
                                    marketingMaterialInstance.Path = pathInstance;
                                }
                            }
                            
                            JToken screenshotUrisArray = responseDoc["screenshotUris"];
                            if (screenshotUrisArray != null && screenshotUrisArray.Type != JTokenType.Null)
                            {
                                foreach (JToken screenshotUrisValue in ((JArray)screenshotUrisArray))
                                {
                                    itemInstance.ScreenshotUris.Add(((string)screenshotUrisValue));
                                }
                            }
                            
                            JToken iconFileUrisSequenceElement = ((JToken)responseDoc["iconFileUris"]);
                            if (iconFileUrisSequenceElement != null && iconFileUrisSequenceElement.Type != JTokenType.Null)
                            {
                                foreach (JProperty property in iconFileUrisSequenceElement)
                                {
                                    string iconFileUrisKey = ((string)property.Name);
                                    string iconFileUrisValue = ((string)property.Value);
                                    itemInstance.IconFileUris.Add(iconFileUrisKey, iconFileUrisValue);
                                }
                            }
                            
                            JToken linksArray = responseDoc["links"];
                            if (linksArray != null && linksArray.Type != JTokenType.Null)
                            {
                                foreach (JToken linksValue in ((JArray)linksArray))
                                {
                                    Link linkInstance = new Link();
                                    itemInstance.Links.Add(linkInstance);
                                    
                                    JToken idValue = linksValue["id"];
                                    if (idValue != null && idValue.Type != JTokenType.Null)
                                    {
                                        string idInstance = ((string)idValue);
                                        linkInstance.Identifier = idInstance;
                                    }
                                    
                                    JToken displayNameValue = linksValue["displayName"];
                                    if (displayNameValue != null && displayNameValue.Type != JTokenType.Null)
                                    {
                                        string displayNameInstance = ((string)displayNameValue);
                                        linkInstance.DisplayName = displayNameInstance;
                                    }
                                    
                                    JToken uriValue = linksValue["uri"];
                                    if (uriValue != null && uriValue.Type != JTokenType.Null)
                                    {
                                        string uriInstance = ((string)uriValue);
                                        linkInstance.Uri = uriInstance;
                                    }
                                }
                            }
                            
                            JToken categoryIdsArray = responseDoc["categoryIds"];
                            if (categoryIdsArray != null && categoryIdsArray.Type != JTokenType.Null)
                            {
                                foreach (JToken categoryIdsValue in ((JArray)categoryIdsArray))
                                {
                                    itemInstance.Categories.Add(((string)categoryIdsValue));
                                }
                            }
                            
                            JToken propertiesSequenceElement = ((JToken)responseDoc["properties"]);
                            if (propertiesSequenceElement != null && propertiesSequenceElement.Type != JTokenType.Null)
                            {
                                foreach (JProperty property2 in propertiesSequenceElement)
                                {
                                    string propertiesKey = ((string)property2.Name);
                                    string propertiesValue = ((string)property2.Value);
                                    itemInstance.Properties.Add(propertiesKey, propertiesValue);
                                }
                            }
                            
                            JToken metadataSequenceElement = ((JToken)responseDoc["metadata"]);
                            if (metadataSequenceElement != null && metadataSequenceElement.Type != JTokenType.Null)
                            {
                                foreach (JProperty property3 in metadataSequenceElement)
                                {
                                    string metadataKey = ((string)property3.Name);
                                    string metadataValue = ((string)property3.Value);
                                    itemInstance.Metadata.Add(metadataKey, metadataValue);
                                }
                            }
                            
                            JToken artifactsArray = responseDoc["artifacts"];
                            if (artifactsArray != null && artifactsArray.Type != JTokenType.Null)
                            {
                                foreach (JToken artifactsValue in ((JArray)artifactsArray))
                                {
                                    Artifact artifactInstance = new Artifact();
                                    itemInstance.Artifacts.Add(artifactInstance);
                                    
                                    JToken nameValue = artifactsValue["name"];
                                    if (nameValue != null && nameValue.Type != JTokenType.Null)
                                    {
                                        string nameInstance = ((string)nameValue);
                                        artifactInstance.Name = nameInstance;
                                    }
                                    
                                    JToken uriValue2 = artifactsValue["uri"];
                                    if (uriValue2 != null && uriValue2.Type != JTokenType.Null)
                                    {
                                        string uriInstance2 = ((string)uriValue2);
                                        artifactInstance.Uri = uriInstance2;
                                    }
                                    
                                    JToken typeValue = artifactsValue["type"];
                                    if (typeValue != null && typeValue.Type != JTokenType.Null)
                                    {
                                        string typeInstance = ((string)typeValue);
                                        artifactInstance.Type = typeInstance;
                                    }
                                }
                            }
                            
                            JToken filtersArray = responseDoc["filters"];
                            if (filtersArray != null && filtersArray.Type != JTokenType.Null)
                            {
                                foreach (JToken filtersValue in ((JArray)filtersArray))
                                {
                                    Filter filterInstance = new Filter();
                                    itemInstance.Filters.Add(filterInstance);
                                    
                                    JToken typeValue2 = filtersValue["type"];
                                    if (typeValue2 != null && typeValue2.Type != JTokenType.Null)
                                    {
                                        string typeInstance2 = ((string)typeValue2);
                                        filterInstance.Type = typeInstance2;
                                    }
                                    
                                    JToken valueValue = filtersValue["value"];
                                    if (valueValue != null && valueValue.Type != JTokenType.Null)
                                    {
                                        string valueInstance = ((string)valueValue);
                                        filterInstance.Value = valueInstance;
                                    }
                                }
                            }
                            
                            JToken productsArray = responseDoc["products"];
                            if (productsArray != null && productsArray.Type != JTokenType.Null)
                            {
                                foreach (JToken productsValue in ((JArray)productsArray))
                                {
                                    Product productInstance = new Product();
                                    itemInstance.Products.Add(productInstance);
                                    
                                    JToken displayNameValue2 = productsValue["displayName"];
                                    if (displayNameValue2 != null && displayNameValue2.Type != JTokenType.Null)
                                    {
                                        string displayNameInstance2 = ((string)displayNameValue2);
                                        productInstance.DisplayName = displayNameInstance2;
                                    }
                                    
                                    JToken publisherDisplayNameValue2 = productsValue["publisherDisplayName"];
                                    if (publisherDisplayNameValue2 != null && publisherDisplayNameValue2.Type != JTokenType.Null)
                                    {
                                        string publisherDisplayNameInstance2 = ((string)publisherDisplayNameValue2);
                                        productInstance.PublisherDisplayName = publisherDisplayNameInstance2;
                                    }
                                    
                                    JToken legalTermsUriValue = productsValue["legalTermsUri"];
                                    if (legalTermsUriValue != null && legalTermsUriValue.Type != JTokenType.Null)
                                    {
                                        string legalTermsUriInstance = ((string)legalTermsUriValue);
                                        productInstance.LegalTermsUri = legalTermsUriInstance;
                                    }
                                    
                                    JToken privacyPolicyUriValue = productsValue["privacyPolicyUri"];
                                    if (privacyPolicyUriValue != null && privacyPolicyUriValue.Type != JTokenType.Null)
                                    {
                                        string privacyPolicyUriInstance = ((string)privacyPolicyUriValue);
                                        productInstance.PrivacyPolicyUri = privacyPolicyUriInstance;
                                    }
                                    
                                    JToken pricingDetailsUriValue = productsValue["pricingDetailsUri"];
                                    if (pricingDetailsUriValue != null && pricingDetailsUriValue.Type != JTokenType.Null)
                                    {
                                        string pricingDetailsUriInstance = ((string)pricingDetailsUriValue);
                                        productInstance.PricingDetailsUri = pricingDetailsUriInstance;
                                    }
                                    
                                    JToken offerDetailsValue = productsValue["offerDetails"];
                                    if (offerDetailsValue != null && offerDetailsValue.Type != JTokenType.Null)
                                    {
                                        OfferDetails offerDetailsInstance = new OfferDetails();
                                        productInstance.OfferDetails = offerDetailsInstance;
                                        
                                        JToken offerIdValue = offerDetailsValue["offerId"];
                                        if (offerIdValue != null && offerIdValue.Type != JTokenType.Null)
                                        {
                                            string offerIdInstance = ((string)offerIdValue);
                                            offerDetailsInstance.OfferIdentifier = offerIdInstance;
                                        }
                                        
                                        JToken publisherIdValue = offerDetailsValue["publisherId"];
                                        if (publisherIdValue != null && publisherIdValue.Type != JTokenType.Null)
                                        {
                                            string publisherIdInstance = ((string)publisherIdValue);
                                            offerDetailsInstance.PublisherIdentifier = publisherIdInstance;
                                        }
                                        
                                        JToken plansArray = offerDetailsValue["plans"];
                                        if (plansArray != null && plansArray.Type != JTokenType.Null)
                                        {
                                            foreach (JToken plansValue in ((JArray)plansArray))
                                            {
                                                Plan planInstance = new Plan();
                                                offerDetailsInstance.Plans.Add(planInstance);
                                                
                                                JToken planIdValue = plansValue["planId"];
                                                if (planIdValue != null && planIdValue.Type != JTokenType.Null)
                                                {
                                                    string planIdInstance = ((string)planIdValue);
                                                    planInstance.PlanIdentifier = planIdInstance;
                                                }
                                                
                                                JToken displayNameValue3 = plansValue["displayName"];
                                                if (displayNameValue3 != null && displayNameValue3.Type != JTokenType.Null)
                                                {
                                                    string displayNameInstance3 = ((string)displayNameValue3);
                                                    planInstance.DisplayName = displayNameInstance3;
                                                }
                                                
                                                JToken summaryValue2 = plansValue["summary"];
                                                if (summaryValue2 != null && summaryValue2.Type != JTokenType.Null)
                                                {
                                                    string summaryInstance2 = ((string)summaryValue2);
                                                    planInstance.Summary = summaryInstance2;
                                                }
                                                
                                                JToken descriptionValue2 = plansValue["description"];
                                                if (descriptionValue2 != null && descriptionValue2.Type != JTokenType.Null)
                                                {
                                                    string descriptionInstance2 = ((string)descriptionValue2);
                                                    planInstance.Description = descriptionInstance2;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            
                            JToken uiDefinitionUriValue = responseDoc["uiDefinitionUri"];
                            if (uiDefinitionUriValue != null && uiDefinitionUriValue.Type != JTokenType.Null)
                            {
                                string uiDefinitionUriInstance = ((string)uiDefinitionUriValue);
                                itemInstance.UiDefinitionUri = uiDefinitionUriInstance;
                            }
                        }
                        
                    }
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        TracingAdapter.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
        
        /// <summary>
        /// Gets collection of gallery items.
        /// </summary>
        /// <param name='parameters'>
        /// Optional. Query parameters. If null is passed returns all gallery
        /// items.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// List of gallery items.
        /// </returns>
        public async Task<ItemListResult> ListAsync(ItemListParameters parameters, CancellationToken cancellationToken)
        {
            // Validate
            
            // Tracing
            bool shouldTrace = TracingAdapter.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = TracingAdapter.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("parameters", parameters);
                TracingAdapter.Enter(invocationId, this, "ListAsync", tracingParameters);
            }
            
            // Construct URL
            string url = "";
            url = url + "/Microsoft.Gallery/galleryitems";
            List<string> queryParameters = new List<string>();
            queryParameters.Add("api-version=2015-04-01");
            queryParameters.Add("includePreview=true");
            List<string> odataFilter = new List<string>();
            if (parameters != null && parameters.Filter != null)
            {
                odataFilter.Add(Uri.EscapeDataString(parameters.Filter));
            }
            if (odataFilter.Count > 0)
            {
                queryParameters.Add("$filter=" + string.Join(null, odataFilter));
            }
            if (parameters != null && parameters.Top != null)
            {
                queryParameters.Add("$top=" + Uri.EscapeDataString(parameters.Top.Value.ToString()));
            }
            if (queryParameters.Count > 0)
            {
                url = url + "?" + string.Join("&", queryParameters);
            }
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Get;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        TracingAdapter.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        TracingAdapter.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
                        if (shouldTrace)
                        {
                            TracingAdapter.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    ItemListResult result = null;
                    // Deserialize Response
                    if (statusCode == HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                        result = new ItemListResult();
                        JToken responseDoc = null;
                        if (string.IsNullOrEmpty(responseContent) == false)
                        {
                            responseDoc = JToken.Parse(responseContent);
                        }
                        
                        if (responseDoc != null && responseDoc.Type != JTokenType.Null)
                        {
                            JToken itemsArray = responseDoc;
                            if (itemsArray != null && itemsArray.Type != JTokenType.Null)
                            {
                                foreach (JToken itemsValue in ((JArray)itemsArray))
                                {
                                    GalleryItem galleryItemInstance = new GalleryItem();
                                    result.Items.Add(galleryItemInstance);
                                    
                                    JToken identityValue = itemsValue["identity"];
                                    if (identityValue != null && identityValue.Type != JTokenType.Null)
                                    {
                                        string identityInstance = ((string)identityValue);
                                        galleryItemInstance.Identity = identityInstance;
                                    }
                                    
                                    JToken itemNameValue = itemsValue["itemName"];
                                    if (itemNameValue != null && itemNameValue.Type != JTokenType.Null)
                                    {
                                        string itemNameInstance = ((string)itemNameValue);
                                        galleryItemInstance.Name = itemNameInstance;
                                    }
                                    
                                    JToken itemDisplayNameValue = itemsValue["itemDisplayName"];
                                    if (itemDisplayNameValue != null && itemDisplayNameValue.Type != JTokenType.Null)
                                    {
                                        string itemDisplayNameInstance = ((string)itemDisplayNameValue);
                                        galleryItemInstance.DisplayName = itemDisplayNameInstance;
                                    }
                                    
                                    JToken publisherValue = itemsValue["publisher"];
                                    if (publisherValue != null && publisherValue.Type != JTokenType.Null)
                                    {
                                        string publisherInstance = ((string)publisherValue);
                                        galleryItemInstance.Publisher = publisherInstance;
                                    }
                                    
                                    JToken publisherDisplayNameValue = itemsValue["publisherDisplayName"];
                                    if (publisherDisplayNameValue != null && publisherDisplayNameValue.Type != JTokenType.Null)
                                    {
                                        string publisherDisplayNameInstance = ((string)publisherDisplayNameValue);
                                        galleryItemInstance.PublisherDisplayName = publisherDisplayNameInstance;
                                    }
                                    
                                    JToken versionValue = itemsValue["version"];
                                    if (versionValue != null && versionValue.Type != JTokenType.Null)
                                    {
                                        string versionInstance = ((string)versionValue);
                                        galleryItemInstance.Version = versionInstance;
                                    }
                                    
                                    JToken summaryValue = itemsValue["summary"];
                                    if (summaryValue != null && summaryValue.Type != JTokenType.Null)
                                    {
                                        string summaryInstance = ((string)summaryValue);
                                        galleryItemInstance.Summary = summaryInstance;
                                    }
                                    
                                    JToken longSummaryValue = itemsValue["longSummary"];
                                    if (longSummaryValue != null && longSummaryValue.Type != JTokenType.Null)
                                    {
                                        string longSummaryInstance = ((string)longSummaryValue);
                                        galleryItemInstance.LongSummary = longSummaryInstance;
                                    }
                                    
                                    JToken descriptionValue = itemsValue["description"];
                                    if (descriptionValue != null && descriptionValue.Type != JTokenType.Null)
                                    {
                                        string descriptionInstance = ((string)descriptionValue);
                                        galleryItemInstance.Description = descriptionInstance;
                                    }
                                    
                                    JToken marketingMaterialValue = itemsValue["marketingMaterial"];
                                    if (marketingMaterialValue != null && marketingMaterialValue.Type != JTokenType.Null)
                                    {
                                        MarketingMaterial marketingMaterialInstance = new MarketingMaterial();
                                        galleryItemInstance.MarketingMaterial = marketingMaterialInstance;
                                        
                                        JToken pathValue = marketingMaterialValue["path"];
                                        if (pathValue != null && pathValue.Type != JTokenType.Null)
                                        {
                                            string pathInstance = ((string)pathValue);
                                            marketingMaterialInstance.Path = pathInstance;
                                        }
                                    }
                                    
                                    JToken screenshotUrisArray = itemsValue["screenshotUris"];
                                    if (screenshotUrisArray != null && screenshotUrisArray.Type != JTokenType.Null)
                                    {
                                        foreach (JToken screenshotUrisValue in ((JArray)screenshotUrisArray))
                                        {
                                            galleryItemInstance.ScreenshotUris.Add(((string)screenshotUrisValue));
                                        }
                                    }
                                    
                                    JToken iconFileUrisSequenceElement = ((JToken)itemsValue["iconFileUris"]);
                                    if (iconFileUrisSequenceElement != null && iconFileUrisSequenceElement.Type != JTokenType.Null)
                                    {
                                        foreach (JProperty property in iconFileUrisSequenceElement)
                                        {
                                            string iconFileUrisKey = ((string)property.Name);
                                            string iconFileUrisValue = ((string)property.Value);
                                            galleryItemInstance.IconFileUris.Add(iconFileUrisKey, iconFileUrisValue);
                                        }
                                    }
                                    
                                    JToken linksArray = itemsValue["links"];
                                    if (linksArray != null && linksArray.Type != JTokenType.Null)
                                    {
                                        foreach (JToken linksValue in ((JArray)linksArray))
                                        {
                                            Link linkInstance = new Link();
                                            galleryItemInstance.Links.Add(linkInstance);
                                            
                                            JToken idValue = linksValue["id"];
                                            if (idValue != null && idValue.Type != JTokenType.Null)
                                            {
                                                string idInstance = ((string)idValue);
                                                linkInstance.Identifier = idInstance;
                                            }
                                            
                                            JToken displayNameValue = linksValue["displayName"];
                                            if (displayNameValue != null && displayNameValue.Type != JTokenType.Null)
                                            {
                                                string displayNameInstance = ((string)displayNameValue);
                                                linkInstance.DisplayName = displayNameInstance;
                                            }
                                            
                                            JToken uriValue = linksValue["uri"];
                                            if (uriValue != null && uriValue.Type != JTokenType.Null)
                                            {
                                                string uriInstance = ((string)uriValue);
                                                linkInstance.Uri = uriInstance;
                                            }
                                        }
                                    }
                                    
                                    JToken categoryIdsArray = itemsValue["categoryIds"];
                                    if (categoryIdsArray != null && categoryIdsArray.Type != JTokenType.Null)
                                    {
                                        foreach (JToken categoryIdsValue in ((JArray)categoryIdsArray))
                                        {
                                            galleryItemInstance.Categories.Add(((string)categoryIdsValue));
                                        }
                                    }
                                    
                                    JToken propertiesSequenceElement = ((JToken)itemsValue["properties"]);
                                    if (propertiesSequenceElement != null && propertiesSequenceElement.Type != JTokenType.Null)
                                    {
                                        foreach (JProperty property2 in propertiesSequenceElement)
                                        {
                                            string propertiesKey = ((string)property2.Name);
                                            string propertiesValue = ((string)property2.Value);
                                            galleryItemInstance.Properties.Add(propertiesKey, propertiesValue);
                                        }
                                    }
                                    
                                    JToken metadataSequenceElement = ((JToken)itemsValue["metadata"]);
                                    if (metadataSequenceElement != null && metadataSequenceElement.Type != JTokenType.Null)
                                    {
                                        foreach (JProperty property3 in metadataSequenceElement)
                                        {
                                            string metadataKey = ((string)property3.Name);
                                            string metadataValue = ((string)property3.Value);
                                            galleryItemInstance.Metadata.Add(metadataKey, metadataValue);
                                        }
                                    }
                                    
                                    JToken artifactsArray = itemsValue["artifacts"];
                                    if (artifactsArray != null && artifactsArray.Type != JTokenType.Null)
                                    {
                                        foreach (JToken artifactsValue in ((JArray)artifactsArray))
                                        {
                                            Artifact artifactInstance = new Artifact();
                                            galleryItemInstance.Artifacts.Add(artifactInstance);
                                            
                                            JToken nameValue = artifactsValue["name"];
                                            if (nameValue != null && nameValue.Type != JTokenType.Null)
                                            {
                                                string nameInstance = ((string)nameValue);
                                                artifactInstance.Name = nameInstance;
                                            }
                                            
                                            JToken uriValue2 = artifactsValue["uri"];
                                            if (uriValue2 != null && uriValue2.Type != JTokenType.Null)
                                            {
                                                string uriInstance2 = ((string)uriValue2);
                                                artifactInstance.Uri = uriInstance2;
                                            }
                                            
                                            JToken typeValue = artifactsValue["type"];
                                            if (typeValue != null && typeValue.Type != JTokenType.Null)
                                            {
                                                string typeInstance = ((string)typeValue);
                                                artifactInstance.Type = typeInstance;
                                            }
                                        }
                                    }
                                    
                                    JToken filtersArray = itemsValue["filters"];
                                    if (filtersArray != null && filtersArray.Type != JTokenType.Null)
                                    {
                                        foreach (JToken filtersValue in ((JArray)filtersArray))
                                        {
                                            Filter filterInstance = new Filter();
                                            galleryItemInstance.Filters.Add(filterInstance);
                                            
                                            JToken typeValue2 = filtersValue["type"];
                                            if (typeValue2 != null && typeValue2.Type != JTokenType.Null)
                                            {
                                                string typeInstance2 = ((string)typeValue2);
                                                filterInstance.Type = typeInstance2;
                                            }
                                            
                                            JToken valueValue = filtersValue["value"];
                                            if (valueValue != null && valueValue.Type != JTokenType.Null)
                                            {
                                                string valueInstance = ((string)valueValue);
                                                filterInstance.Value = valueInstance;
                                            }
                                        }
                                    }
                                    
                                    JToken productsArray = itemsValue["products"];
                                    if (productsArray != null && productsArray.Type != JTokenType.Null)
                                    {
                                        foreach (JToken productsValue in ((JArray)productsArray))
                                        {
                                            Product productInstance = new Product();
                                            galleryItemInstance.Products.Add(productInstance);
                                            
                                            JToken displayNameValue2 = productsValue["displayName"];
                                            if (displayNameValue2 != null && displayNameValue2.Type != JTokenType.Null)
                                            {
                                                string displayNameInstance2 = ((string)displayNameValue2);
                                                productInstance.DisplayName = displayNameInstance2;
                                            }
                                            
                                            JToken publisherDisplayNameValue2 = productsValue["publisherDisplayName"];
                                            if (publisherDisplayNameValue2 != null && publisherDisplayNameValue2.Type != JTokenType.Null)
                                            {
                                                string publisherDisplayNameInstance2 = ((string)publisherDisplayNameValue2);
                                                productInstance.PublisherDisplayName = publisherDisplayNameInstance2;
                                            }
                                            
                                            JToken legalTermsUriValue = productsValue["legalTermsUri"];
                                            if (legalTermsUriValue != null && legalTermsUriValue.Type != JTokenType.Null)
                                            {
                                                string legalTermsUriInstance = ((string)legalTermsUriValue);
                                                productInstance.LegalTermsUri = legalTermsUriInstance;
                                            }
                                            
                                            JToken privacyPolicyUriValue = productsValue["privacyPolicyUri"];
                                            if (privacyPolicyUriValue != null && privacyPolicyUriValue.Type != JTokenType.Null)
                                            {
                                                string privacyPolicyUriInstance = ((string)privacyPolicyUriValue);
                                                productInstance.PrivacyPolicyUri = privacyPolicyUriInstance;
                                            }
                                            
                                            JToken pricingDetailsUriValue = productsValue["pricingDetailsUri"];
                                            if (pricingDetailsUriValue != null && pricingDetailsUriValue.Type != JTokenType.Null)
                                            {
                                                string pricingDetailsUriInstance = ((string)pricingDetailsUriValue);
                                                productInstance.PricingDetailsUri = pricingDetailsUriInstance;
                                            }
                                            
                                            JToken offerDetailsValue = productsValue["offerDetails"];
                                            if (offerDetailsValue != null && offerDetailsValue.Type != JTokenType.Null)
                                            {
                                                OfferDetails offerDetailsInstance = new OfferDetails();
                                                productInstance.OfferDetails = offerDetailsInstance;
                                                
                                                JToken offerIdValue = offerDetailsValue["offerId"];
                                                if (offerIdValue != null && offerIdValue.Type != JTokenType.Null)
                                                {
                                                    string offerIdInstance = ((string)offerIdValue);
                                                    offerDetailsInstance.OfferIdentifier = offerIdInstance;
                                                }
                                                
                                                JToken publisherIdValue = offerDetailsValue["publisherId"];
                                                if (publisherIdValue != null && publisherIdValue.Type != JTokenType.Null)
                                                {
                                                    string publisherIdInstance = ((string)publisherIdValue);
                                                    offerDetailsInstance.PublisherIdentifier = publisherIdInstance;
                                                }
                                                
                                                JToken plansArray = offerDetailsValue["plans"];
                                                if (plansArray != null && plansArray.Type != JTokenType.Null)
                                                {
                                                    foreach (JToken plansValue in ((JArray)plansArray))
                                                    {
                                                        Plan planInstance = new Plan();
                                                        offerDetailsInstance.Plans.Add(planInstance);
                                                        
                                                        JToken planIdValue = plansValue["planId"];
                                                        if (planIdValue != null && planIdValue.Type != JTokenType.Null)
                                                        {
                                                            string planIdInstance = ((string)planIdValue);
                                                            planInstance.PlanIdentifier = planIdInstance;
                                                        }
                                                        
                                                        JToken displayNameValue3 = plansValue["displayName"];
                                                        if (displayNameValue3 != null && displayNameValue3.Type != JTokenType.Null)
                                                        {
                                                            string displayNameInstance3 = ((string)displayNameValue3);
                                                            planInstance.DisplayName = displayNameInstance3;
                                                        }
                                                        
                                                        JToken summaryValue2 = plansValue["summary"];
                                                        if (summaryValue2 != null && summaryValue2.Type != JTokenType.Null)
                                                        {
                                                            string summaryInstance2 = ((string)summaryValue2);
                                                            planInstance.Summary = summaryInstance2;
                                                        }
                                                        
                                                        JToken descriptionValue2 = plansValue["description"];
                                                        if (descriptionValue2 != null && descriptionValue2.Type != JTokenType.Null)
                                                        {
                                                            string descriptionInstance2 = ((string)descriptionValue2);
                                                            planInstance.Description = descriptionInstance2;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    
                                    JToken uiDefinitionUriValue = itemsValue["uiDefinitionUri"];
                                    if (uiDefinitionUriValue != null && uiDefinitionUriValue.Type != JTokenType.Null)
                                    {
                                        string uiDefinitionUriInstance = ((string)uiDefinitionUriValue);
                                        galleryItemInstance.UiDefinitionUri = uiDefinitionUriInstance;
                                    }
                                }
                            }
                        }
                        
                    }
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        TracingAdapter.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
    }
}
