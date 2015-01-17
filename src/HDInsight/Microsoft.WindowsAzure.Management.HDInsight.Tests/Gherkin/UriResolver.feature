Feature: StorageAccountAbstraction
	In order to interact with a Hadoop cluster from the SDK
	As a developer
	I want to have a way to interact with storage

@CheckIn
Scenario: I can not delete a container
	Given I apply storage abstraction simulation
	  And I have the Windows Azure Blob storage abstraction for the account 'default@tststg00hdxcibld02a.blob.core.windows.net'
	 When I try to delete the path 'wabs://default@tststg00hdxcibld02a.blob.core.windows.net'
	 Then an 'InvalidOperationException' is thrown containing the message 'Containers can not be deleted via this API'

@CheckIn
Scenario: I can not store data without a path
    Given I apply storage abstraction simulation
	  And I have the Windows Azure Blob storage abstraction for the account 'default@tststg00hdxcibld02a.blob.core.windows.net'
	 When I write the data "data" to the path 'wabs://default@tststg00hdxcibld02a.blob.core.windows.net'
	 Then an 'InvalidOperationException' is thrown containing the message 'without a path'

@CheckIn
Scenario: I can read content I previously wrote to storage
   Given I apply storage abstraction simulation
	  And I have the Windows Azure Blob storage abstraction for the account 'default@tststg00hdxcibld02a.blob.core.windows.net'
	 When I write the data "data" to the path 'wabs://default@tststg00hdxcibld02a.blob.core.windows.net/list2/item1'
	  And I read the data from the path 'wabs://default@tststg00hdxcibld02a.blob.core.windows.net/list2/item1'
	 Then the value of the data should be "data"
	  And no error should be returned from the storage abstraction

@CheckIn
Scenario: I can list the items in the account
   Given I apply storage abstraction simulation
	  And I have the Windows Azure Blob storage abstraction for the account 'default@tststg00hdxcibld02a.blob.core.windows.net'
	 When I write the data "data" to the path 'wabs://default@tststg00hdxcibld02a.blob.core.windows.net/list1/item1'
	  And I list the items under the path 'wabs://default@tststg00hdxcibld02a.blob.core.windows.net/list1'
	 Then the number of items returned should be 2
	  And no error should be returned from the storage abstraction

@CheckIn
Scenario: Listing the items in an empty directory returns no items
   Given I apply storage abstraction simulation
	  And I have the Windows Azure Blob storage abstraction for the account 'default@tststg00hdxcibld02a.blob.core.windows.net'
	 When I list the items under the path 'wabs://default@tststg00hdxcibld02a.blob.core.windows.net/doesNotExist'
	 Then the number of items returned should be 0
	  And no error should be returned from the storage abstraction

@CheckIn
Scenario: I can list the items under a directory recursively
   Given I apply storage abstraction simulation
	  And I have the Windows Azure Blob storage abstraction for the account 'default@tststg00hdxcibld02a.blob.core.windows.net'
	 When I write the data "data" to the path 'wabs://default@tststg00hdxcibld02a.blob.core.windows.net/list3/item1'
	  And I write the data "data" to the path 'wabs://default@tststg00hdxcibld02a.blob.core.windows.net/list3/sub1/item1'
	  And I write the data "data" to the path 'wabs://default@tststg00hdxcibld02a.blob.core.windows.net/list3/sub1/item2'
	  And I write the data "data" to the path 'wabs://default@tststg00hdxcibld02a.blob.core.windows.net/list3/sub2/item1'
	  And I write the data "data" to the path 'wabs://default@tststg00hdxcibld02a.blob.core.windows.net/list3/sub2/item2'
	  And I write the data "data" to the path 'wabs://default@tststg00hdxcibld02a.blob.core.windows.net/list3/sub3/item1'
	  And I write the data "data" to the path 'wabs://default@tststg00hdxcibld02a.blob.core.windows.net/list3/sub3/item2'
	  And I write the data "data" to the path 'wabs://default@tststg00hdxcibld02a.blob.core.windows.net/list3/sub3/item3'
	  And I list the items under the path 'wabs://default@tststg00hdxcibld02a.blob.core.windows.net/list3' recursively
	 Then the number of items returned should be 12
	  And no error should be returned from the storage abstraction

@CheckIn
Scenario: When I delete a directory all child items and directories are removed (delete is recursive)
   Given I apply storage abstraction simulation
	  And I have the Windows Azure Blob storage abstraction for the account 'default@tststg00hdxcibld02a.blob.core.windows.net'
	 When I write the data "data" to the path 'wabs://default@tststg00hdxcibld02a.blob.core.windows.net/list4/item1'
	  And I write the data "data" to the path 'wabs://default@tststg00hdxcibld02a.blob.core.windows.net/list4/sub1/item1'
	  And I write the data "data" to the path 'wabs://default@tststg00hdxcibld02a.blob.core.windows.net/list4/sub1/item2'
	  And I write the data "data" to the path 'wabs://default@tststg00hdxcibld02a.blob.core.windows.net/list4/sub2/item1'
	  And I write the data "data" to the path 'wabs://default@tststg00hdxcibld02a.blob.core.windows.net/list4/sub2/item2'
	  And I write the data "data" to the path 'wabs://default@tststg00hdxcibld02a.blob.core.windows.net/list4/sub3/item1'
	  And I write the data "data" to the path 'wabs://default@tststg00hdxcibld02a.blob.core.windows.net/list4/sub3/item2'
	  And I write the data "data" to the path 'wabs://default@tststg00hdxcibld02a.blob.core.windows.net/list4/sub3/item3'
	  And I try to delete the path 'wabs://default@tststg00hdxcibld02a.blob.core.windows.net/list4/sub3'
	  And I list the items under the path 'wabs://default@tststg00hdxcibld02a.blob.core.windows.net/list4' recursively
	 Then the number of items returned should be 8
	  And no error should be returned from the storage abstraction

@CheckIn
Scenario: When I check for the existence of an item that does not exist a false value is returned
   Given I apply storage abstraction simulation
	  And I have the Windows Azure Blob storage abstraction for the account 'default@tststg00hdxcibld02a.blob.core.windows.net'
	 When I check existence of the path 'wabs://default@tststg00hdxcibld02a.blob.core.windows.net/list4/sub3'
	 Then the existence check should return false
	  And no error should be returned from the storage abstraction

@CheckIn
Scenario: When I check for the existence of an item that does exist a true value is returned 
   Given I apply storage abstraction simulation
	  And I have the Windows Azure Blob storage abstraction for the account 'default@tststg00hdxcibld02a.blob.core.windows.net'
	 When I write the data "data" to the path 'wabs://default@tststg00hdxcibld02a.blob.core.windows.net/list5/sub1/sub2/item1'
	  And I check existence of the path 'wabs://default@tststg00hdxcibld02a.blob.core.windows.net/list5/sub1/sub2/item1'
	 Then the existence check should return true
	  And no error should be returned from the storage abstraction
