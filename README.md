# FaceDetector

1. Takes pic with webcam
2. Detects fac(es)
3. Crop out fac(es)
4. Adds effects
5. Sets as your wallpaper


This project isnt intended to be anything useful. Its mostly just for me to learn face detection concepts and working with the Emgu(Open CV) library.



Program settings, Remove all the comments before using.

```json
{
	"AddedBrightness": 0,          // Adds brightness
	"AddedSharpness": 1,           // Adds sharpness
	"Flip": false,                 // Flips the image
	"EffectMode": "normal",        // Adds different effects. example: normal, pedo, nazi.
	"WallpaperFormat": "stretch",  // Wallpaper format, example: fit, fill, stretch.
	"KeepOutputImage": false,      // keeps the image after exiting in the form of Image.png
	"ExitAfterCompletion": true,   // Exits after running
	"VerboseErrorOutput": false,   // Displays the raw exception data instead of just "ERROR: ..."
}
```
