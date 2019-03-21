﻿using System;
using Sakuno.ING.Http;
using Sakuno.ING.Settings;
using Sakuno.ING.Shell;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Sakuno.ING.UWP
{
    [ExportView("Browser")]
    internal sealed partial class BrowserElement : UserControl
    {
        public readonly WebView WebView;
        public readonly FrameworkElement ActualContent;
        private readonly LayoutSetting layoutSetting;

        public BrowserElement(UWPHttpProviderSelector selector, LayoutSetting layoutSetting)
        {
            this.layoutSetting = layoutSetting;
            if (selector.Settings.Debug.InitialValue)
            {
                var btn = new Button
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Content = "Next debug data"
                };

                var debug = (DebugHttpProvider)selector.Current;
                btn.Tapped += (s, e) => debug.Send();

                ActualContent = btn;
            }
            else
            {
                ActualContent = WebView = new WebView(WebViewExecutionMode.SeparateThread);
                WebView.Navigate(new Uri(selector.Settings.DefaultUrl.Value));
            }
            layoutSetting.LayoutScale.ValueChanged += _ => UpdateBrowserScale();
            layoutSetting.BrowserScale.ValueChanged += _ => UpdateBrowserScale();

            this.InitializeComponent();
            UpdateBrowserScale();
        }

        private void UpdateBrowserScale()
        {
            float scale = layoutSetting.BrowserScale.Value / layoutSetting.LayoutScale.Value;
            Transformer.Transform = new ScaleTransform { ScaleX = scale, ScaleY = scale };
        }
    }
}
