# VSGBinanceWebSocket-API

Into the Solution explorer you can see 4 projects:

BinanceHubConnection - this is Console app which is using to established connection and consume data stream
BinanceProcessor - this is Class Library which is using as middleware between ConnectionHub and Database layer
DbConnection - this is a Class Library project which is using to create and make CRUD over SqLite database
WebAPI - this is a simple asp.net core web api
How to start:

Set up the WebAPI project as a startup project and click ctrl+f5 to start the project (swagger api should be opened in chrome browser).
Right click BinanceHubConnection project -> select Debug option -> Start New Instance
