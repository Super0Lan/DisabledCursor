using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;

namespace DisabledCursor
{
    public class Assists
    {
        #region 是否使用禁用下的样式设计
        public static bool GetUseDisabledDesign(DependencyObject obj)
        {
            return (bool)obj.GetValue(UseDisabledDesignProperty);
        }

        public static void SetUseDisabledDesign(DependencyObject obj, bool value)
        {
            obj.SetValue(UseDisabledDesignProperty, value);
        }

        // Using a DependencyProperty as the backing store for UseDisabledDesign.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UseDisabledDesignProperty =
            DependencyProperty.RegisterAttached("UseDisabledDesign", typeof(bool), typeof(Assists), new PropertyMetadata(false, OnUseDisabledDesignPropertyChanged));


        private static void OnUseDisabledDesignPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FrameworkElement framework)
            {
                if ((bool)e.NewValue)
                {
                    framework.IsEnabledChanged += Framework_IsEnabledChanged;
                    framework.Loaded += Framework_Loaded;
                }
                else
                {
                    framework.IsEnabledChanged -= Framework_IsEnabledChanged;
                    framework.Loaded -= Framework_Loaded;
                }
            }
            else
            {
                throw new Exception("Source Must be FrameworkElement");
            }
        }

        private static void SetEnable(FrameworkElement framework) {
            var adorner = (UnableAdorner)framework.GetOrAddAdorner(typeof(UnableAdorner));
            adorner.SetEnable(framework.IsEnabled);
        }

        private static void Framework_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender is FrameworkElement framework && framework.IsLoaded) {
                SetEnable(framework);
            }   
        }

        private static void Framework_Loaded(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement framework)
            {
                SetEnable(framework);
            }
        }
        #endregion
    }
}
