# Ascii Art CLI

## Description

This is a command-line tool (CLI) for making ascii art. If you are unfamiliar with the command-line environment, this program probably is not for you.  

## Installation

### Prerequistes

You will need to install the .NET SDK 8.0.100 as well as the .NET Runtime 8.0.0.

These can be found on [this page](https://dotnet.microsoft.com/en-us/download/dotnet/8.0).

### Download or clone this repo

To get the program on your computer either:

- Download the latest release from "releases".
- Run ```git clone https://github.com/OliFryser/ascii-art.git``` in a your preferred termninal.

### Running the program

Then open a terminal in that the folder you downloaded or "git cloned" the program to. Then navigate into the folder "ascii-art-cli".

Here you should be able to run ```dotnet run``` in the terminal and see an ascii version of the dog, that is also in ```resources/baby.jpg```.

#### Setting custom flags

So, if you want anything else other than a dog, you can specify *flags* for the program. This is done by running ``dotnet run``. Note: Use the longform flags, when using ``dotnet run``. The shortform do not work, since they conflict with some of the ``dotnet`` programs flags.

A filepath passed to the program is interpreted as a filepath, if it is the first unspecified argument. The second unspecified argument will be interpreted as the density string.

For example, running the program with:

``dotnet run ../resources/baby.jpg 10``

will produce a picture of the dog "baby", only with 1's and 0's.

Consult the table below to see which flags are available:

| **Flag** | **Longform** | **Example** | **Description** |
|----------|--------------|-------------|-----------------|
|```-f```  |``--filepath``|``--filepath ../resources/baby.jpg``| Specifies a filepath to the ascii image.|
|``-d``    |``--density``|``--density .,-#``|Sets the density string to a custom string, meaning the ascii image will only be made out of those. |
|``-c``|``--contrast``|``--contrast 10``|Sets the contrast of the image.|
|``-a``|``--alternative``|``--alternative``|Toggles whether to use a denser density string.|
|``-i``|``--invert``|``--invert``|Inverts the image (by reversing the density string)|
|``-w``|``--webcam``|``--webcam 0``|Starts the program in webcam mode. It takes a webcam index as argument. If you are unsure, try a few (0, most likely).|
|``-f``|``--framerate``|``--framerate 30``|Specifies the framerate to run webcam mode in (must be a whole number)|

#### Webcam mode (advanced)

The webcam mode only works is only verified to work on windows, but it you may just need to add the correct nuget package.
