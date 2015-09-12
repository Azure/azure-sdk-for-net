@CheckIn
Feature: JobPayloadConverter_JobList
	In order to get and receive data from the server
	As a component of the SDK
	I want to be able to serialize and deserialize data going back and forth from the server.

Scenario: I can serialize a job list with an httpStatusCode not Accepted
    Given I have a job list object
	  And the request will return the http status code "BadGateway"
	 When I serialize the object
	 Then the value of the serialized output should be equivalent with the original

Scenario: I can serialize a job list with an errorCode
    Given I have a job list object
	  And the request will return the error id "ClusterNotFound"
	 When I serialize the object
	 Then the value of the serialized output should be equivalent with the original

Scenario: I can serialize an empty list of jobIds
    Given I have a job list object
	 When I serialize the object
	 Then the value of the serialized output should be equivalent with the original

Scenario: I can serialize jobIds (one job)
    Given I have a job list object
	  And the jobId "job123" is added to the list of jobIds
	 When I serialize the object
	 Then the value of the serialized output should be equivalent with the original

Scenario: I can serialize jobIds (multiple jobs)
    Given I have a job list object
      And the jobId "job123" is added to the list of jobIds
      And the jobId "job234" is added to the list of jobIds
      And the jobId "job345" is added to the list of jobIds
	 When I serialize the object
	 Then the value of the serialized output should be equivalent with the original
