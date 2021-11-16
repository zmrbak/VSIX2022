using Microsoft.VisualStudio.Text.Editor;
using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace VSIX46
{
    /// <summary>
    /// Adornment class that draws a square box in the top right hand corner of the viewport
    /// 在视口右上角绘制方框的装饰类
    /// </summary>
    internal sealed class ViewportAdornment1
    {
        /// <summary>
        /// The width of the square box.
        /// 方框的宽度。
        /// </summary>
        private const double AdornmentWidth = 30;

        /// <summary>
        /// The height of the square box.
        /// 方框的高度
        /// </summary>
        private const double AdornmentHeight = 30;

        /// <summary>
        /// Distance from the viewport top to the top of the square box.
        /// 从视口顶部到方框顶部的距离
        /// </summary>
        private const double TopMargin = 30;

        /// <summary>
        /// Distance from the viewport right to the right end of the square box.
        /// 从视口右侧到方框右端的距离
        /// </summary>
        private const double RightMargin = 30;

        /// <summary>
        /// Text view to add the adornment on.
        /// 要在上面添加装饰的文本视图
        /// </summary>
        private readonly IWpfTextView view;

        /// <summary>
        /// Adornment image
        /// </summary>
        private readonly Image image;

        /// <summary>
        /// The layer for the adornment.
        /// 装饰图像
        /// </summary>
        private readonly IAdornmentLayer adornmentLayer;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewportAdornment1"/> class.
        /// 初始化 ViewportAdornment1 类的新实例
        /// Creates a square image and attaches an event handler to the layout changed event that
        /// adds the the square in the upper right-hand corner of the TextView via the adornment layer
        /// 创建一个正方形图像，并将事件处理程序附加到布局更改事件，该事件通过装饰层将正方形添加到TextView的右上角
        /// </summary>
        /// <param name="view">The <see cref="IWpfTextView"/> upon which the adornment will be drawn
        /// 在上面绘制装饰的IWpfTextView</param>
        public ViewportAdornment1(IWpfTextView view)
        {
            if (view == null)
            {
                throw new ArgumentNullException("view");
            }

            this.view = view;

            var brush = new SolidColorBrush(Colors.BlueViolet);
            brush.Freeze();
            var penBrush = new SolidColorBrush(Colors.Red);
            penBrush.Freeze();
            var pen = new Pen(penBrush, 0.5);
            pen.Freeze();

            // Draw a square with the created brush and pen
            System.Windows.Rect r = new System.Windows.Rect(0, 0, AdornmentWidth, AdornmentHeight);
            var geometry = new RectangleGeometry(r);

            var drawing = new GeometryDrawing(brush, pen, geometry);
            drawing.Freeze();

            var drawingImage = new DrawingImage(drawing);
            drawingImage.Freeze();

            this.image = new Image
            {
                Source = drawingImage,
            };

            this.adornmentLayer = view.GetAdornmentLayer("ViewportAdornment1");

            this.view.LayoutChanged += this.OnSizeChanged;
            //this.view.LayoutChanged += View_LayoutChanged;
        }

        private void View_LayoutChanged(object sender, TextViewLayoutChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Event handler for viewport layout changed event. Adds adornment at the top right corner of the viewport.
        /// 视口布局更改事件的事件处理程序。在视口的右上角添加装饰。
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void OnSizeChanged(object sender, EventArgs e)
        {
            // Clear the adornment layer of previous adornments
            // 清除以前装饰的装饰层
            this.adornmentLayer.RemoveAllAdornments();

            // Place the image in the top right hand corner of the Viewport
            Canvas.SetLeft(this.image, this.view.ViewportRight - RightMargin - AdornmentWidth);
            Canvas.SetTop(this.image, this.view.ViewportTop + TopMargin);

            // Add the image to the adornment layer and make it relative to the viewport
            // 将图像添加到装饰层,并使其位置相对于视口
            this.adornmentLayer.AddAdornment(AdornmentPositioningBehavior.ViewportRelative, null, null, this.image, null);
        }
    }
}
