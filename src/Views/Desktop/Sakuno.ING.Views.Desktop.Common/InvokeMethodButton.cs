﻿using System;
using System.Windows;
using System.Windows.Controls;

namespace Sakuno.ING.Views.Desktop
{
    public class InvokeMethodButton : Button
    {
        public static DependencyProperty MethodNameProperty
            = DependencyProperty.Register(nameof(MethodName), typeof(string), typeof(InvokeMethodButton));

        public string MethodName
        {
            get => (string)GetValue(MethodNameProperty);
            set => SetValue(MethodNameProperty, value);
        }

        protected override void OnClick()
        {
            base.OnClick();

            if (MethodName == null) return;
            var method = DataContext?.GetType().GetMethod(MethodName);
            if (method == null) return;

            method.Invoke(DataContext, Array.Empty<object>());
        }
    }
}
