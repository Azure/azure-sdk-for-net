@CheckIn
Feature: JobPayloadConverter_JobDetails
	In order to get and receive data from the server
	As a component of the SDK
	I want to be able to serialize and deserialize data going back and forth from the server.

Scenario: I can serialize a job detail with an httpStatusCode not Accepted
    Given I have a job details object
	  And the request will return the http status code "BadGateway"
	 When I serialize the object
	 Then the value of the serialized output should be equivalent with the original

Scenario: I can serialize a job detail with an errorCode
    Given I have a job details object
	  And the request will return the error id "ClusterNotFound"
	 When I serialize the object
	 Then the value of the serialized output should be equivalent with the original

Scenario: I can serialize a job detail with a full pacage of data
    Given I have a job details object
	  And the job has an Exit Code of 4
	  And the job has a Job Id of "job123"
	  And the job has the Logical Output Path "http://logicalOutputPath"
	  And the job has the following query:
	  """
		SOME HIVE QUERY
	  """
	  And the job has the Status Code "Initializing"
	  And the job has was submitted on "Wednesday, June 26, 2013 6:31:02 PM"
	  And the job has the name "My First Job"
	  And the job has the Physical Output Path "asv://my@storage/logicalOutputPath"
	 When I serialize the object
	 Then the value of the serialized output should be equivalent with the original