Integration Testing
===================
By `Steve Smith`_

Integration testing ensures that an application's components function correctly when assembled together. ASP.NET 5 supports integration testing using unit test frameworks and a built-in test web host that can be used to handle requests without network overhead.

In this article:
  - `Introduction to Integration Testing`_
  - `Integration Testing ASP.NET`_
  - `Running Tests`_


`Download sample from GitHub <https://github.com/aspnet/docs/tree/master/aspnet/testing/integration-testing/sample>`_. 

Introduction to Integration Testing
-----------------------------------
Integration tests verify that different parts of an application work correctly together. Unlike :doc:`unit-testing`, integration tests frequently involve application infrastructure concerns, such as a database, file system, network resources, or web requests and responses. Unit tests use fakes or mock objects in place of these concerns, but the purpose of integration tests is to confirm that the system works as expected with these systems.

Integration tests, because they exercise larger segments of code and because they rely on infrastructure elements, tend to be orders of magnitude slower than unit tests. Thus, it's a good idea to limit how many integration tests you write, especially if you can test the same behavior with a unit test.

.. tip:: If some behavior can be tested using either a unit test or an integration test, prefer the unit test, since it will be almost always be faster. You might have dozens or hundreds of unit tests with many different inputs, but just a handful of integration tests covering the most important scenarios.

Testing the logic within your own methods is usually the domain of unit tests. Testing how your application works within its framework (e.g. ASP.NET) or with a database is where integration tests come into play. It doesn't take too many integration tests to confirm that you're able to write a row to and then read a row from the database. You don't need to test every possible permutation of your data access code - you only need to test enough to give you confidence that your application is working properly.

Integration Testing ASP.NET
---------------------------
To get set up to run integration tests, you'll need to create a test project, refer to your ASP.NET web project, and install a test runner. This process is described in the :doc:`unit-testing` documentation, along with more detailed instructions on running tests and recommendations for naming your tests and test classes.

.. tip:: Separate your unit tests and your integration tests using different projects. This helps ensure you don't accidentally introduce infrastructure concerns into your unit tests, and lets you easily choose to run all tests, or just one set or the other.



Summary
-------
Add summary here.
