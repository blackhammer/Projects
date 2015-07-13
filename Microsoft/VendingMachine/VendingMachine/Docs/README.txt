Coding Exercise

Build a command line application that acts like a vending machine. 
The data for the vending machine should be persisted across application restarts, this can be a flat file (data can be in the format of your choosing: JSON, XML, Plain Text, etc.),
or some embedded database (Embedded SQL Server for example). Each item in the vending machine is of a certain type and each type of item has the same cost. 
 
For example, all Drinks are $2.00 but I can have Gatorade and Pepsi, all Chips are $1.50 and I have 3 types of chips and so on.

Things I want to be able to do:
	-Insert a coin with a certain value (value unit should be $, so 25 cents would be 0.25)
		-You don’t need to limit the values to the known denominations, any amount can be accepted (except negative ones of course)
	-See how much money I’ve inserted so far
	-Request the list of items available and for each item I want to see
		-how many of each item are left
		-how much they cost
		-the key I need to provide when requesting them (for example, A3, any format will do).
	-Request a specific item using the item key
		-If I haven’t put enough money, indicate how much is missing
		-If I’ve put too much money, indicate how much change I get back
	-Ask for all the money to be refunded

Please list any assumption that you’ve made as well as a small set of instructions as to how to use the application.