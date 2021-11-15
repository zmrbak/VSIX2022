using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Formatting;
using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace VSIX45
{
    /// <summary>
    /// TextAdornment1 places red boxes behind all the "a"s in the editor window
    /// TextAdorment1将红色框放在编辑器窗口中所有“a”的后面
    /// </summary>
    internal sealed class TextAdornment1
    {
        /// <summary>
        /// The layer of the adornment.
        /// 装饰的层
        /// </summary>
        private readonly IAdornmentLayer layer;

        /// <summary>
        /// Text view where the adornment is created.
        /// 创建装饰的文本视图
        /// </summary>
        private readonly IWpfTextView view;

        /// <summary>
        /// Adornment brush.
        /// 装饰画刷
        /// </summary>
        private readonly Brush brush;

        /// <summary>
        /// Adornment pen.
        /// 装饰画笔
        /// </summary>
        private readonly Pen pen;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextAdornment1"/> class.
        /// 初始化TextAdornment1类的新实例
        /// </summary>
        /// <param name="view">
        /// Text view to create the adornment for 
        /// 要为其创建装饰的文本视图
        /// </param>
        public TextAdornment1(IWpfTextView view)
        {
            if (view == null)
            {
                throw new ArgumentNullException("view");
            }

            this.layer = view.GetAdornmentLayer("TextAdornment1");

            this.view = view;
            this.view.LayoutChanged += this.OnLayoutChanged;

            // Create the pen and brush to color the box behind the a's
            // 创建画刷和画笔，为a后面的方框上色
            this.brush = new SolidColorBrush(Color.FromArgb(0x20, 0x00, 0x00, 0xff));
            this.brush.Freeze();

            var penBrush = new SolidColorBrush(Colors.Red);
            penBrush.Freeze();
            this.pen = new Pen(penBrush, 0.5);
            this.pen.Freeze();
        }

        /// <summary>
        /// Handles whenever the text displayed in the view changes by adding the adornment to any reformatted lines
        /// 当装饰添加到每一个重新格式化的行中，视图中显示的文本发生更改时，都会进行处理
        /// </summary>
        /// <remarks>
        /// <para>This event is raised whenever the rendered text displayed in the <see cref="ITextView"/> changes.
        /// 当ITextView中显示的渲染文本发生更改时，将引发此事件
        /// </para>
        /// <para>It is raised whenever the view does a layout (which happens when DisplayTextLineContainingBufferPosition is called or in response to text or classification changes).
        /// 当视图进行布局时引发该事件。（在调用DisplayTextLineContainingBufferPosition或响应文本或分类更改时）
        /// </para>
        /// <para>It is also raised whenever the view scrolls horizontally or when its size changes.
        /// 当视图水平滚动或其大小更改时，也会引发该事件
        /// </para>
        /// </remarks>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        internal void OnLayoutChanged(object sender, TextViewLayoutChangedEventArgs e)
        {
            foreach (ITextViewLine line in e.NewOrReformattedLines)
            {
                this.CreateVisuals(line);
            }
        }

        /// <summary>
        /// Adds the scarlet box behind the 'a' characters within the given line
        /// 在给定行中的“a”字符背后添加猩红色框
        /// </summary>
        /// <param name="line">
        /// Line to add the adornments 
        /// 将被添加装饰的行
        /// </param>
        private void CreateVisuals(ITextViewLine line)
        {
            IWpfTextViewLineCollection textViewLines = this.view.TextViewLines;

            // Loop through each character, and place a box around any 'a'
            // 循环遍历每个字符，并在任何“a”周围放置一个框
            for (int charIndex = line.Start; charIndex < line.End; charIndex++)
            {
                if (this.view.TextSnapshot[charIndex] == 'a')
                {
                    SnapshotSpan span = new SnapshotSpan(this.view.TextSnapshot, Span.FromBounds(charIndex, charIndex + 1));
                    Geometry geometry = textViewLines.GetMarkerGeometry(span);
                    if (geometry != null)
                    {
                        var drawing = new GeometryDrawing(this.brush, this.pen, geometry);
                        drawing.Freeze();

                        var drawingImage = new DrawingImage(drawing);
                        drawingImage.Freeze();

                        var image = new Image
                        {
                            Source = drawingImage,
                        };

                        // Align the image with the top of the bounds of the text geometry
                        // 将图像与文本几何体边界的顶部对齐
                        Canvas.SetLeft(image, geometry.Bounds.Left);
                        Canvas.SetTop(image, geometry.Bounds.Top);

                        this.layer.AddAdornment(AdornmentPositioningBehavior.TextRelative, span, null, image, null);
                    }
                }
            }
        }
    }
}
