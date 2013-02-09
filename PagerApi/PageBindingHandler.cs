using System;
using System.Html;
using System.Collections;
using System.Runtime.CompilerServices;

// taken from BindindingHandler.cs and modified

namespace PagerApi 
{
    /// <summary>
    /// Represents a custom binding handler in Knockout.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [ScriptName("Object")]
    public abstract class PageBindingHandler {

        /// <summary>
        /// Performs one time initialization for a binding.
        /// </summary>
        /// <param name="element">The element involved in this binding.</param>
        /// <param name="valueAccessor">A function which returns the model property that is involved in this binding.</param>
        /// <param name="allBindingsAccessor">A function which returns all the model properties bound to this element.</param>
        /// <param name="viewModel">The view model instance involved in this binding.</param>
        /// <param name="bindingContext">The binding context involved in this binding.</param>
        public virtual object Init(Element element, Func<object> valueAccessor, Func<JsDictionary> allBindingsAccessor, object viewModel, object bindingContext) 
        {
           return null;
        }

        /// <summary>
        /// Invoked whenever an observable associated with this binding changes.
        /// </summary>
        /// <param name="element">The element involved in this binding.</param>
        /// <param name="valueAccessor">A function which returns the model property that is involved in this binding.</param>
        /// <param name="allBindingsAccessor">A function which returns all the model properties bound to this element.</param>
        /// <param name="viewModel">The view model instance involved in this binding.</param>
        /// <param name="bindingContext">The binding context involved in this binding.</param>
        public virtual object Update(Element element, Func<object> valueAccessor, Func<JsDictionary> allBindingsAccessor, object viewModel, object bindingContext) 
        {
           return null;
        }
    }

    /// <summary>
    /// Represents a custom binding handler in Knockout.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    [Serializable]
    public class InlinePageBindingHandler<T> {
        
        /// <param name="element">The element involved in this binding.</param>
        /// <param name="valueAccessor">A function which returns the model property that is involved in this binding.</param>
        /// <param name="allBindingsAccessor">A function which returns all the model properties bound to this element.</param>
        /// <param name="viewModel">The view model instance involved in this binding.</param>
        /// <param name="bindingContext">The binding context involved in this binding.</param>
        public delegate void PageBindingHandlerMethod(
            Element element, 
            Func<T> valueAccessor, 
            Func<JsDictionary> allBindingsAccessor, 
            object viewModel, 
            object bindingContext);

        /// <summary>
        /// Performs one time initialization for a binding.
        /// </summary>
        [IntrinsicProperty]
        private PageBindingHandlerMethod Init { get; set; }

        /// <summary>
        /// Invoked whenever an observable associated with this binding changes.
        /// </summary>
        [IntrinsicProperty]
        private PageBindingHandlerMethod Update { get; set; }

        [ObjectLiteral]
        public InlinePageBindingHandler(PageBindingHandlerMethod init, PageBindingHandlerMethod update) {
            this.Init = init;
            this.Update = update;
        }

        [ScriptAlias("")]
        public static implicit operator PageBindingHandler(InlinePageBindingHandler<T> handler) { return null; }
    }
}

