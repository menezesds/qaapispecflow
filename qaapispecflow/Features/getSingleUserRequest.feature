Feature: To test the Users request

A short summary of the feature

@tag1
Scenario: GET request single user
	Given the user sends a get request for single user with url as "https://reqres.in/api/users/2"
	Then the request should be success and return status code 200

@tag2
Scenario: GET request list users
	Given the user sends a get request for list users with url as "https://reqres.in/api/users?page=2"
	Then the request should be success, return status code 200 and displey thet total of users 12

@tag3
Scenario: POST request create user
	Given the user sends a post request with url as "https://reqres.in/api/users"
	Then the request should be success and return status code 201
