# BMICalc

##### Requires
	- .NET Core 6
	- Visual Studio 2022

### Setup
	- Launch options set to pass cmdline args
	- Right click the project in the Solution Explorer Pane -> Properties -> Debug -> Launch Properties UI -> Add to command line args.
	- Examples
		-  180cm 75kg
		-  100in 135lbs
		- Can mix metric and imperial numbers

### Comments
Not super happy with the regexToPerson function and amount of repetition +  ToString invocations.
If I were to do this again, I might look to using regex to extract the pairs (attributeUnitofMeasure, Value) and place them into something easier to handle like a dict["kg"]
I'm prioritising minimal extra time on this so will have to do, but in the real world I'd be refactoring this ASAP.