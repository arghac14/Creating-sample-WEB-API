﻿Feature: Producer Resource

@GetProducers
Scenario: Get all Producers
	Given I am a client
	When I make GET Request 'api/producers'
	Then response code must be '200'
	And response data must look like '[{"id":1,"name":"Kevin Feigi","gender":"M","bio":"American Producer","dob":"2000-01-01T00:00:00"}]'

@GetProducerById
Scenario: Get Producer
	Given I am a client
	When I make GET Request 'api/producers/1'
	Then response code must be '200'
	And response data must look like '{"id":1,"name":"Kevin Feigi","gender":"M","bio":"American Producer","dob":"2000-01-01T00:00:00"}'


Scenario: Add Producer
Given I am a client
When  I make POST request to 'api/producers' with data '{"Id":1,"Name":"James Ingold","Gender":"M","Bio":"American Producer","DOB":"2000-01-01T00:00:00"}'
Then response code must be '201'

Scenario: Update Producer
Given I am a client
When I make PUT Request 'api/producers/1' with data '{"id":1,"name":"James Ingold","gender":"M","bio":"American Producer","dob":"2000-01-01T00:00:00"}'
Then response code must be '200'


Scenario: Delete Producer
Given I am a client
When I make Delete Request 'api/producers/1'
Then response code must be '200'