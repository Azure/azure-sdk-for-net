@CheckIn
Feature: JobPayloadConverter_JobCreation
	In order to get and receive data from the server
	As a component of the SDK
	I want to be able to serialize and deserialize data going back and forth from the server.

@mytag
Scenario: I can create a hive job with no values specified
    Given I have a hive job request object
	  And I set the job name as "<jobName>"
	 When I serialize the object
	 Then the value of the serialized output should be equivalent with the original

Scenario: I can create a map reduce job with no values specified
    Given I have a map reduce job request object
	  And I set the job name as "<jobName>"
	 When I serialize the object
	 Then the value of the serialized output should be equivalent with the original

Scenario: I can create a job with basic values
    Given I have a map reduce job request object
      And I set the job name as "job1"
	  And I set the class name as "pi"
	  And I set the Jar file as "pi.jar"
	 When I serialize the object
	 Then the value of the serialized output should be equivalent with the original

Scenario: I can create a request without a OutputStorageLocation
    Given I have a map reduce job request object
	  And I set the job name as "<jobName>"
	  And I set the class name as "<className>"
	  And I set the Jar file as "pi.jar"
	  And I add the following argument "16"
	  And I add the following argument "10000"
	  And I add the following parameter "one" with a value of "aaa"
	  And I add the following parameter "two" with a value of "bbb"
	  And I add the following parameter "three" with a value of "ccc"
	  And I add the following resource "a" with a value of "1"
	  And I add the following resource "b" with a value of "2"
	  And I add the following resource "c" with a value of "3"
	 When I serialize the object
	 Then the value of the serialized output should be equivalent with the original

Scenario: I can create a complicated map reduce job with multiple values
    Given I have a map reduce job request object
	  And I set the job name as "<jobName>"
	  And I set the class name as "<className>"
	  And I set the Jar file as "pi.jar"
	  And I add the following argument "16"
	  And I add the following argument "10000"
	  And I add the following parameter "one" with a value of "aaa"
	  And I add the following parameter "two" with a value of "bbb"
	  And I add the following parameter "three" with a value of "ccc"
	  And I add the following resource "a" with a value of "1"
	  And I add the following resource "b" with a value of "2"
	  And I add the following resource "c" with a value of "3"
	  And I set the Output Storage Location as "/output"
	 When I serialize the object
	 Then the value of the serialized output should be equivalent with the original

Scenario: I can create a complicated hive job with multiple values
    Given I have a hive job request object
	  And I set the job name as "jobName"
	  And I add the following parameter "one" with a value of "aaa"
	  And I add the following parameter "two" with a value of "bbb"
	  And I add the following parameter "three" with a value of "ccc"
	  And I add the following resource "a" with a value of "1"
	  And I add the following resource "b" with a value of "2"
	  And I add the following resource "c" with a value of "3"
	  And I set the Output Storage Location as "/output"
	  And I set the Query to the following:
	  """
		Hive Query
	  """
	 When I serialize the object
	 Then the value of the serialized output should be equivalent with the original
