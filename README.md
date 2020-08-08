Application Archtect 
-DataBase Edits : 
- i Added Id as aprimary key auto incremental 
- i removed username and password since i found it useless 
i would like to make professional authenticationsusing identity framework 
but u didn't mention anything about authentications in your document  
Api folder content {
-data access layer : 
i used entity framework core database first approch since i already have the database 
-busniess logic layer :
 i has three folders 
MangmentOpreation it's contain (IRepository interface ,Repository class ,  UnitOfWork class )
Business (contain main opperation that required on the task )
ViewModel(contain DataViewModel (create formatted data message which contain all information that i might need in json object )
-API 
Contain the main api which call the busniess layer then the data access layer from inside the busniess layer 
}
frontend folder : 
contain the frontend project using react.js 
