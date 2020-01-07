# Dania_Daisy
Template for Data Access Audit Trail Logging

Audit trailing or logging all unit of operations throughout our system boundries is somehow crucial in enterprise applications . each boudries has thier own related properties/concerns related to their layers. Dania Daisy focusing on logging/tracing all operations related to data access to a datastore . 

Implementation ?

Assuming we have a portable data access library that will be used across a multiple application with multiple business logic needs . Implementing this lib template will somehow help to have an audit trail sink that is centralized in a single data store . 

Data Store Type ? 

In this template ,  Azure Table , Event Log , SQL Database  for centralized , Console and File for on the instance itself . File later may be pulled and mined into your own data warehouse .



![alt text](
https://github.com/wmadzha/Dania_Daisy/blob/master/assets/Centralized%20Sink.png?raw=true)
