# NetlandAPI
The goal of the project, was to create an application in ASP.NET 6.0.
The most important purposes of the application are:
* reading data from a csv file,
* mapping data to the Order.cs class,
* download all data or data that matching the search criteria,

How to run the application?
1. Download the application, e.g. from the link below or from my github profile
https://github.com/Tomasz2375/NetlandAPI.git
2. Create a csv file with the following structure:
* header
Number,ClientCode,ClientName,OrderDate,ShipmentDate,Quantity,Confirmed,Value
* file content
	* Number - takes a string value enclosed in double quotes
	  (the quotation marks are optional),
	* ClientCode - takes a string value enclosed in double quotes
	  (the quotation marks are optional),
	* ClientName - takes a string value enclosed in double quotes
	  (the quotation marks are optional),
	* OrderDate - stores the date in the format dd.MM.yyyy
	* ShipmentDate - stores the date in the format dd.MM.yyyy 
	  (it can take a null value),
	* Quantity - takes an integer value,
	* Confirmed - takes a logical value (0 = false, 1 = true),
	* Value - takes a decimal value.
3. Set path to your file in "appsettings.Development.json"
in variable "OrderFilePath".
4. This application uses external packages:
	* CsvHelper Version 30.0.1
	* Swashbuckle.AspNetCore Version 6.5.0
5. Run the application and use the swagger to use the get method.