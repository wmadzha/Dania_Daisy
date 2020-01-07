# Dania_Daisy
Template for Data Access Audit Trail Logging

Audit trailing or logging all unit of operations throughout our system boundaries is somehow crucial in enterprise applications . each boundaries has thier own related properties/concerns related to their layers. Dania Daisy focusing on logging/tracing all operations related to data access to a datastore . 

Implementation ?

Assuming we have a portable data access library that will be used across multiple application with multiple business logic needs . Implementing this library template will somehow help to have an audit trail sink that will be stored in a centralized data store . 

Data Store Type ? 

In this template ,  Azure Table , Event Log , SQL Database  for centralized , Console and File for on the instance itself . File later may be pulled and mined into your own data warehouse .



![alt text](
https://github.com/wmadzha/Dania_Daisy/blob/master/assets/Centralized%20Sink.png?raw=true)


Sample Output . 

In below sample output , we're trying to simulate a situation where we have 3 instance of microservice applications that is hitting our data store and each of them is required to log their audit trail into a centralized database sink ( in this case display in console ) . 

![alt text](
https://github.com/wmadzha/Dania_Daisy/blob/master/assets/Sample%20Dania%20Daisy%20Output.png?raw=true)
