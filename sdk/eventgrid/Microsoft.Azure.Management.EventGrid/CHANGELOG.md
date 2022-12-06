# Release History

## 9.0.0 (2022-06)
- This release corresponds to api-version 2022-06-15 which includes the following new features:
    * Partner Events.
    * Nested Event Subscriptions for Domains, Domain Topics, and Topics.
    * Data residency for Topics and Domains.
    * Management group support.

## 7.0.0 (2021-12)
- This release corresponds to api-version 2021-12-01 which includes the following new features:
    * MSI for delivery to first party destinations.
    * Support for tracked system topic
    * Support for Delivery Attributes
    * Topic type with multiple source scopes.
    * Support for storage queue message TTL.
	* MSI for system topics.
	* Self management of domain topics.
	* Data plane AAD auth.
	* User assigned identity for topics and domains.
	
## 6.2.0 (2021-06)
- This release corresponds to api-version 2021-06-01-preview which includes the following new features:
    * Support of AAD authentication for user topics, domains, and partner namespaces.
    * Private link support for partner namespaces.
    * IP Filtering for partner namespaces.
    * System Identity for partner topics.
    * User Identity for user topics and domains.

## 6.1.0 (2020-10)
- This release corresponds to api-version 2020-10-15-preview which includes the following new features:
    * MSI for System Topics
    * Azure Arc support Topics and Event Subscriptions
    * Delivery Attributes for Event Subscriptions
    * Ability to specify a TTL for StorageQueue destinations
    * New AttributeFiltering Operators for Event Channels
    * Exposing Source scopes on the TopicType resource

## 6.0.0 (2020-06)
- Add support to new GA service API version 2020-06-01.
- The new GA'ed features include:
	* Event delivery schema,
	* Input mapping,
	* Custom input schema event delivery schema,
	* Cloud event V10 schema,
	* Service bus topic as destination,
	* Azure function as destination,
	* Webhook batching,
	* Secure webhook (AAD support),
	* ImmutableId support, IpFiltering, and
	* Private Link.
- Release version 5.3.2-preview still corresponds to latest preview API version 2020-04-01-preview and it includes all the GA'ed features in version 6.0.0 as well additional features that are still in preview. These preview features include:
	* Partner topic,
   	* Tracked system topic,
	* Sku, and
	* MSI support.

## 5.3.2-preview (2020-05)
- This include additional bug fixes to enhance quality.
- As version 5.3.1-preview, this release corresponds to the 2020-04-01-Preview API version which includes the following new functionalities: 
	* Support for IP Filtering when publishing events to Domains and Topics,
	* Partner Topics,
	* Tracked Resource System Topics,
	* Sku,
	* MSI, and
	* Private Link support.

## 5.3.1-preview (2020-04)
- This include various bug fixes to enhance quality.
- As version 5.3.0-preview, this release corresponds to the 2020-04-01-Preview API version which includes the following new functionalities: 
	* Support for IP Filtering when publishing events to Domains and Topics,
	* Partner Topics,
	* Tracked Resource System Topics,
	* Sku,
	* MSI, and
	* Private Link support.

## 5.3.0-preview (2020-03)
- We introduce new features on top of features already added in verion 5.2.0-preview. 
- As version 5.2.0-preview, this release corresponds to the 2020-04-01-Preview API version.
- It adds supports to the following new functionalities: 
	* Support for IP Filtering when publishing events to Domains and Topics,
	* Partner Topics,
	* Tracked Resource System Topics,
	* Sku,
	* MSI, and
	* Private Link support.

## 5.2.0-preview (2020-01)
- This release corresponds to the 2020-04-01-Preview API version.
- It adds supports to the following new functionality:
	* Support for IP Filtering when publishing events to Domains and Topics,

## 5.0.0 (2019-05)
- This release corresponds to the 2019-06-01 API version.
- It adds support to the following new functionalities:
	* Domains,
	* Pagination and search filter for resources list operations,
	* Service Bus Queue as destination,
	* Advanced filtering, and
	* Disallows usage of ‘All’ with IncludedEventTypes."

## 4.1.0-preview (2019-03)
- This release corresponds to the 2019-02-01-preview API version.
- It adds support to the following new functionalities:
	* Pagination and search filter for resources list operations,
	* Manual create/delete of domain topics
	* Service Bus Queue as destination,
	* Disallows usage of ‘All’ with IncludedEventTypes,

## 4.0.0 (2018-12)
- This corresponds to the 2019-01-01 stable API version.
- It supports General Availability of the following functionalities related to event subscriptions:
	* DeadLetter destination,
	* Storage queue as destination,
	* HybridConnection as destination,
	* Manual handshake validation, and 
	* Ssupport for retry policies.
- Features that are still in preview (such as Event Grid domains or advanced filters support) can still be accessed using the 3.0.1-preview version of the SDK."

## 3.0.1-preview (2018-10)
- Taking dependency on 10.0.3 version of Newtonsoft nuget package.

## 3.0.0-preview (2018-10)
- This is a preview SDK for the new features introduced in 2018-09-15-preview API version. - This includes support for:
	* Domain and domain topics CRUD operation
	* Introducing expiration date for event subscription, 
	Introducing advanced filtering for event subscription, 
- The stable version of the SDK targeting the 2018-01-01 API version continues to exist as version 1.3.0

## 2.0.0-preview (2018-05)
- This is a preview SDK for the new features introduced in 2018-05-01-preview API version. 
- The stable version of the SDK targeting the 2018-01-01 API version continues to exist as version 1.3.0.
