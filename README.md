# PagerJS API for C# / Saltarelle

PagerJS Api is a import metadata library that lets you use [PagerJs](http://oscar.finnsson.nu/pagerjs) 
in projects written with the [Saltarelle-compiler](http://www.saltarelle-compiler.com) (C# to JavaScript).

What's includeded:

* the API library source files
* an example that implements a custom widget
* a simple website that runs the above example

# The PagerJS API

The following objects are exposed:

* the `Pager` static object
* the `Page` class 
* the `PageBindingHandler` class (for creating custom widgets)


# Configuring it

Just reference `Script.PagerApi.dll` from within your C#-Saltarelle projects. Remember to add the using: 

```C#
using PagerApi;
```    

# How to use it

First decide what history engine your are going to use in your web application. PagerJS 
gives three choices:

* naive history (working only on HTML5 browser)
* jQuery hasChange history
* History.js

if you decide to use History.js you have to reference it in your html file.

## Using naive history manager:

```C#
Pager.ExtendWithPage(viewModel);                    
Knockout.ApplyBindings(viewModel);
Pager.Start();              
```

## Using jquery haschange:

```C#
Pager.UseHTML5history = true;
Pager.ExtendWithPage(viewModel);                    
Knockout.ApplyBindings(viewModel);
Pager.StartHashChange();  
```

## Using History.JS:

```C#
Pager.UseHTML5history = true;
pager.Href5History = History;
Pager.ExtendWithPage(viewModel);                    
Knockout.ApplyBindings(viewModel);
Pager.StartHistoryJS();  
```

# Making Custom Widgets

To make "custom widgets" (as defined in the PageJS website) you inherit from the
`Page` class and override some of the following methods as needed:

```C#
object Init();
object GetValue();
Page GetParentPage();
Observable<string> SourceUrl(Observable<string> source);
void LoadSource(Observable<string> source);
void Show(Action callback);
void ShowElement(Action callback);
void HideElement(Action callback);
```

then you create a binding handler for KnockOut deriving from `PageBindingHandler` (it's not the same binding
handler used in KnockOut). See the example included for an implementation of the `page-accordion-widget` featured
on the Pager.Js website.

