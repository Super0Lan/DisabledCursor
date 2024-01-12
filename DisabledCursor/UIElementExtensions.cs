using System;
using System.Linq;
using System.Windows;
using System.Windows.Documents;

namespace DisabledCursor
{
    public static class UIElementExtensions
    {
        /// <summary>
        /// 添加并获取对应类型的装饰器
        /// </summary>
        /// <param name="uIElement">需要添加装饰器的控件</param>
        /// <param name="type">装饰器类型</param>
        /// <returns></returns>
        public static Adorner GetOrAddAdorner(this UIElement uIElement, Type type)
        {
            AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(uIElement);
            if (adornerLayer != null)
            {
                var adorner = adornerLayer.GetAdorners(uIElement)?.FirstOrDefault(x => x?.GetType() == type);
                adorner = (Adorner)Activator.CreateInstance(type, new object[] { uIElement });
                adornerLayer.Add(adorner);
                return adorner;
            }
            return null;
        }
    }
}
