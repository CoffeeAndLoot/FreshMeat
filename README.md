# FreshMeat

**This project should be considered an early alpha release. It is not been fully tested and may have bugs. Use at your own risk.**

FreshMeat helper application for pricing of Menagerie beasts in Path of Exile using Awakened PoE Trade.

The purpose of FreshMeat is to use the Ninja pricing api to create Awakened PoE Trade filter widget entries showing the current
pricing as reported by the Ninja Api to aid in determining the value of the beasts you have collected, and to assist in locating the beasts you currently 
have in your menagerie catalog.

## Requirements
* Windows 10 or 11 (Not tested on other versions of Windows or Mac or Linux)
* .Net 7 ([link to download](https://dotnet.microsoft.com/en-us/download/dotnet/7.0))
* Awakened Poe Trade must ([link to download](https://github.com/SnosMe/awakened-poe-trade/releases/latest)) be installed and running.
* Active internet connection and not blocking poe.ninja website.


## Installation

**Before you begin**: While in PoE, open Awakened PoE Trade and create a new widget named "Beast". If you already have a widget named "Beast", you can rename it to something else, and then create a new widget named "Beast".

This does not have an installer or any other automated installation process. It is a simple .Net 7 console application.

Download the latest release from the releases page and extract the zip file to a location of your choice.

I would suggest a location C:\FreshMeat or D:\FreshMeat or similar. Not in the default download location or Program Files.

Use FreshMeat.exe file to start the application.

It will create the following:
* folder: C:\Users\{username}\AppData\Local\FreshMeat
* file: C:\Users\{username}\AppData\Local\FreshMeat\settings.json
* folder: C:\Users\{username}\AppData\Local\FreshMeat\logs (log files are created here, 30 day retention)

The installation makes the following assumptions:
* Awakened Poe Trade is installed in the default location: C:\Users\{username}\AppData\Local\Programs\Awakened PoE Trade\
* Awakened Poe Trade configuration file is located in the default 
location: C:\Users\{username}\AppData\Roaming\awakened-poe-trade\apt-data\config.json
* Sanctum league is the active league in Awakened Poe Trade.

## Configuration
* Create a new Widget in Awakened Poe Trade, named "Beast". If you already have a widget named "Beast", you can rename it to something else, and then create a new widget named "Beast".
* Open the settings.json file in a text editor for editing of application settings.


## Usage
* Start the application:
  * by double clicking the FreshMeat.exe file.
  * or by opening a command prompt and navigating to the folder where FreshMeat.exe is located and typing: FreshMeat.exe
  * or by using the windows task scheduler to run the application at a scheduled time.

It will automatically close Awakened PoE Trade, update the Beast widget with the latest pricing, and then restart Awakened PoE Trade once the update is complete.

Note: League selection is based upon Awakened PoE Trade configuration. If you have Standard league selected in Awakened PoE Trade, then Standard league will be used for the pricing. If you have a different league selected, then that league will be used for the pricing.

## Known Issues / Limitations
* English language only.
* ~~Only supports the Sanctum league (league configuration in a future update).~~
* Only creates beasts whose price is greater than 9 chaos orbs.
* Overwrites the existing "Beast" entries in Awakened PoE Trade with the new entries.


## Future Enhancements
* ~~Add support for league selection.~~
* Add support for other languages.
* Add a UI to configure the application.
