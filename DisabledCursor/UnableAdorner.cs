using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace DisabledCursor
{
    public sealed class UnableAdorner : Adorner
    {
        /// <summary>
        /// 装饰器上的Visual集合
        /// </summary>
        private VisualCollection VisualCollection { get; set; }

        protected override int VisualChildrenCount => VisualCollection.Count;

        protected override Visual GetVisualChild(int index) => VisualCollection[index];


        private readonly UnablePanel unablePanel;


        public UnableAdorner(UIElement uIElement) : base(uIElement)
        {
            VisualCollection = new VisualCollection(this);
            unablePanel = new UnablePanel();
            VisualCollection.Add(unablePanel);
        }

        public void SetEnable(bool isEnable)
        {
            unablePanel.Visibility = isEnable ? Visibility.Collapsed : Visibility.Visible;
        }

        protected override Size MeasureOverride(Size constraint)
        {
            return base.MeasureOverride(constraint);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            unablePanel.Arrange(new Rect(finalSize));
            return base.ArrangeOverride(finalSize);

        }
    }
}
