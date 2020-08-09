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
-unit test
i have created quick unit test to test if apis return not null objects 
for both api and unitofwork 
}
frontend folder : 
contain the frontend project using react.js 

Notes  : 
i have created a project view all producst data 
with save locally option , download local version , tell the user if local version Available and tell user if any update happened within 3 days 
for any of files 
with a unit test 
please tell me if you would like further edits 

i would prefer to save the files physically and just put urls in the database and use asp identity authentication 
but i prefered to follow the requirments as is 

