# ColorOperations (Alpha - Version 1.0)
## Introduction
ColorOperations is a light weight library for dealing with colors in C#.
## Classes
### `ColorConverter`
It's a static class that contains a collection of methods to convert between the following color modes:
- RGB --> Hex
#### Example:
```
int r = 255;
int g = 255;
int b = 255;
HEX hex = ColorConverter.FromRGBToHEX(r, g, b); // Returns an object of type HEX
```
- HEX --> RGB
#### Example:
```
string hex = "#ffffff"; // OR ffffff OR #FFFFFF OR FFFFFF
RGB rgb = ColorConverter.FromHexToRGB(hex);; // Returns an object of type RGB
```
- RGB --> HSL
#### Example:
```
int r = 255;
int g = 255;
int b = 255;
HEX hex = ColorConverter.FromRGBToHEX(r, g, b); // Returns an object of type HEX
```
- HSL --> RGB
#### Example:
```
int h = 360;
int s = 100;
int l = 100;
RGB rgb = ColorConverter.FromHSLToRGB(h, s, l); // Returns an object of type RGB
```
- HEX --> HSL
#### Example:
```
string hex = "#ffffff";
HSL hsl = ColorConverter.FromHexToHSL(hex); // Returns an object of type HSL
```
- HSL --> HEX
#### Example:
```
int h = 360;
int s = 100;
int l = 100;
HEX hex = ColorConverter.FromHSLToHex(h, s, l); // Returns an object of type HEX
```
---
### `HEX`
It's a class provides collection of methods to proccessing HEX color mode.
- Methods
  - ToHashString()
  ```
  HEX hex = new HEX("ff", "ff", "ff");
  hex.toHashString(); // Output: #FFFFFF
  ```
  - ToString() -- Overrided--
  ```
  HEX hex = new HEX("ff", "ff", "ff");
  hex.toHashString(); // Output: FFFFFF
  ```
---
### `RGB`
It's a class provides collection of methods to proccessing RGB color mode.
- Methods
  - ToUpperRGBString()
  ```
  RGB rgb = new RGB(255, 255, 255);
  rgb.ToUpperRGBString(); // Output: RGB(255, 255, 255)
  ```
  - ToLowerRGBString()
  ```
  RGB rgb = new RGB(255, 255, 255);
  rgb.ToLowerRGBString(); // Output: rgb(255, 255, 255)
  ```
  - ToSpacesString()
  ```
  RGB rgb = new RGB(255, 255, 255);
  rgb.ToSpacesString(); // Output: 255 255 255
  ```
  - ToString() -- Overrided--
  ```
  RGB rgb = new RGB(255, 255, 255);
  rgb.ToString(); // Output: 255, 255, 255
  ```
---
### `HSL`
It's a class provides collection of methods to proccessing HSL color mode.
- Methods
  - ToUpperHSLString()
  ```
  HSL hsl = new HSL(360, 100, 100);
  hsl.ToUpperHSLString(); // Output: HSL(360, 100, 100)
  ```
  - ToLowerHSLString()
  ```
  HSL hsl = new HSL(360, 100, 100);
  hsl.ToLowerHSLString(); // Output: hsl(360, 100, 100)
  ```
  - ToSpacesString()
  ```
  HSL hsl = new HSL(360, 100, 100);
  hsl.ToSpacesString(); // Output: 360 100 100
  ```
  - ToString() -- Overrided--
  ```
  HSL hsl = new HSL(360, 100, 100);
  hsl.ToString(); // Output: 360, 100, 100
  ```
---
# Thank You & Bye 👋
