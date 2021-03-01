Feature: Movie Resource

Background: 
	Given I am a client

Scenario: Get All Movies
	When I make GET Request 'api/movies'
	Then response code must be '200'
	And response data must look like '[{"id":1,"name":"Avengers","yearOfRelease":2012,"plot":"--","poster":"link","producer":{"id":1,"name":"Kevin Feigi","gender":"M","bio":"American Producer","dob":"2000-01-01T00:00:00"},"actor":[{"id":1,"name":"RDJ","gender":"M","bio":"American Actor","dob":"2000-01-01T00:00:00"}],"genre":[{"id":1,"name":"Thriller"}]}]'

Scenario: Get Single Movie
	When I make GET Request 'api/movies/1'
	Then response code must be '200'
	And response data must look like '{"id":1,"name":"Avengers","yearOfRelease":2012,"plot":"--","poster":"link","producer":{"id":1,"name":"Kevin Feigi","gender":"M","bio":"American Producer","dob":"2000-01-01T00:00:00"},"actor":[{"id":1,"name":"RDJ","gender":"M","bio":"American Actor","dob":"2000-01-01T00:00:00"}],"genre":[{"id":1,"name":"Thriller"}]}'

Scenario: Add Movie
	When  I make POST request to 'api/movies' with data '{"Name":"Avengers 2","yor":2015,"plot":"--","poster":"link","producers":1,"actor":[1,2],"genre":[1]}'
	Then response code must be '201'

Scenario: Update Movie
	When I make PUT Request 'api/movies/1' with data '{"Name":"Avengers 2","yor":2015,"plot":"--","poster":"link","producers":1,"actor":[1,2],"genre":[1]}'
	Then response code must be '200'

Scenario: Delete Movie
	When I make Delete Request 'api/movies/1'
	Then response code must be '200'