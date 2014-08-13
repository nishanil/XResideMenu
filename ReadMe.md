XResideMenu
===========

C# port of ResideMenu. Oringial Android Project: https://github.com/SpecialCyCi/AndroidResideMenu 

![ResideMenu](https://github.com/SpecialCyCi/AndroidResideMenu/raw/master/2.gif)


## Known Binding issue
If you try to bind the original Android project you will run into an issue with R.java class. This is because Capital letters in Java package names cause java.lang.NoClassDefFoundError
exceptions for resources in Android Library Projects. 

### Error that you runinto
You will not get any compile time errors. When you run the app, you will run into this exception:     Java.Lang.NoClassDefFoundError: com.special.ResideMenu.R$layout

Track this
[bug](https://bugzilla.xamarin.com/show_bug.cgi?id=22057)

## Workarounds


### Workaround by changing the Java library

1. Change the package name of "com.example.ResideMenu" to "com.example.residemenu" in the "ResideMenu" Java project. Be sure to change the package name in both the `src/` folder as well as in the `AndroidManifest.xml` file.
2. Rebuild the Java project, update the library project .zip (or .aar) file, and then rebuild the "ResideMenu.Bindings" project.

>  The .aar file included in this project has been re-compiled in Java with this workaround 

Or - 

### Workaround in Xamarin

You can use this option if you'd like to stick with using the `.aar` file that you already made.

1. Build and run the app on device or emulator. It will fail.
2. Edit the `obj/Debug/android/src/com/special/residemenu/R.java` file in the "XResideMenu" project folder, and correct the package name: package com.example.ResideMenu;
3. Again build and run the app. Importantly, do not "Clean" or "Rebuild" the app.
