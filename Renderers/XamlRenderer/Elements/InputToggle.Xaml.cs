﻿using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml;
using MarkedNet;
using Xceed.Wpf.Toolkit;

namespace Adaptive
{
    public partial class InputToggle
    {
        /// <summary>
        /// Override the renderer for this element
        /// </summary>
        public static Func<InputToggle, RenderContext, FrameworkElement> AlternateRenderer;

        /// <summary>
        /// TextInput
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override FrameworkElement Render(RenderContext context)
        {
            if (AlternateRenderer != null)
                return AlternateRenderer(this, context);

            if (context.Options.SupportInteraction)
            {
                var uiToggle = new CheckBox();
                uiToggle.Content = this.Title;
                uiToggle.IsChecked = this.Value == (this.ValueOn ?? "true");
                uiToggle.Style = context.GetStyle($"Adaptive.Input.Toggle");
                uiToggle.DataContext = this;
                context.InputControls.Add(uiToggle);
                return uiToggle;
            }
            else
            {
                var textBlock = new TextBlock() { Text = GetFallbackText() ?? this.Title };
                return textBlock.Render(context);
            }

        }
    }

}