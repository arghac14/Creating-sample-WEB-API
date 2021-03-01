Feature: Actor Resource

Background: 
	Given I am a client

@GetActors
Scenario: Get all actors
	When I make GET Request 'api/actors'
	Then response code must be '200'
	And response data must look like '[{"id":1,"name":"RDJ","gender":"M","bio":"American Actor","dob":"2000-01-01T00:00:00"}]'

@GetActorById
Scenario: Get Actor
	When I make GET Request 'api/actors/1'
	Then response code must be '200'
	And response data must look like '{"id":1,"name":"RDJ","gender":"M","bio":"American Actor","dob":"2000-01-01T00:00:00"}'

@AddActor
Scenario: Add an Actor
	When  I make POST request to 'api/actors' with data '{"Name":"Robert Downey Jr","Gender":"M","Bio":"American Actor","DOB":"2000-01-01T00:00:00"}'
	Then response code must be '201'

@UpdateActor
Scenario: Update an Actor
	When I make PUT Request 'api/actors/1' with data '{"name":"Robert Downey","gender":"M","bio":"American Actor","dob":"2000-01-01T00:00:00"}'
	Then response code must be '200'

@DeleteActor
Scenario: Delete an Actor
	When I make Delete Request 'api/actors/1'
	Then response code must be '200'