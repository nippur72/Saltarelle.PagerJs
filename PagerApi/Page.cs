using System;
using System.Html;
using System.Runtime.CompilerServices;

using KnockoutApi;

namespace PagerApi
{		
   [Imported]
   [ScriptNamespace("pager")]      
   public class Page
   {      
      public Page(Element element, Func<object> valueAccessor, Func<System.Collections.JsDictionary> allBindingsAccessor, object viewModel, object bindingContext) { }

      /* giving access to some basic page properties */
      public Element Element;
      public Func<object> ValueAccessor;
      public Func<System.Collections.JsDictionary> AllBindingsAccessor;
      public Object ViewModel;
      public Object BindingContext;
      public ObservableArray<object> children;
      public Object ChildManager;
      public Page ParentPage;
      public String CurrentId;
      public Object ctx;
      public Object CurrentParentPage;
      public Observable<bool> IsVisible;
      public object OriginalRoute;
      public Object Route;
      
      /* methods to override for implementing custom widgets*/
      public virtual object Init() { return null; }
      public virtual object GetValue() { return null; }
      public virtual Page GetParentPage() { return null; }
      public virtual Observable<string> SourceUrl(Observable<string> source) { return null; }
      public virtual void LoadSource(Observable<string> source) { }
      public virtual void Show(Action callback) { }
      public virtual void ShowElement(Action callback) { }
      public virtual void HideElement(Action callback) { }
   }        
}

