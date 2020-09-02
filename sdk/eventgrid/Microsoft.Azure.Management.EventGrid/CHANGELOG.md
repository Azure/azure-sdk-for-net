# Release History

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