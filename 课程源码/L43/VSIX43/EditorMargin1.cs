using Microsoft.VisualStudio.Text.Editor;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace VSIX43
{
    /// <summary>
    /// Margin's canvas and visual definition including both size and content
    /// 包括了大小和内容的Margin（边框）的画布和可视化定义。
    /// </summary>
    internal class EditorMargin1 : Canvas, IWpfTextViewMargin
    {
        /// <summary>
        /// Margin name.
        /// 边框名称
        /// </summary>
        public const string MarginName = "EditorMargin1";

        /// <summary>
        /// A value indicating whether the object is disposed.
        /// 这个值指示对象是否已释放
        /// </summary>
        private bool isDisposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditorMargin1"/> class for a given <paramref name="textView"/>.
        /// 通过给定的 textView 来初始化 EditorMargin1 类的新实例
        /// </summary>
        /// <param name="textView">The <see cref="IWpfTextView"/> to attach the margin to.</param>
        public EditorMargin1(IWpfTextView textView)
        {
            // Margin height sufficient to have the label
            // 能够显示标签的边框高度
            this.Height = 20;
            this.ClipToBounds = true;
            this.Background = new SolidColorBrush(Colors.LightGreen);

            // Add a green colored label that says "Hello EditorMargin1"
            // 添加一个绿色标签，上面写着“Hello EditorMargin1”
            var label = new Label
            {
                Background = new SolidColorBrush(Colors.Red),
                Content = "Hello EditorMargin1",
            };

            this.Children.Add(label);
        }

        #region IWpfTextViewMargin

        /// <summary>
        /// Gets the <see cref="Sytem.Windows.FrameworkElement"/> that implements the visual representation of the margin.
        /// 获取实现边框可视化表示的 FrameworkElement
        /// </summary>
        /// <exception cref="ObjectDisposedException">The margin is disposed.</exception>
        public FrameworkElement VisualElement
        {
            // Since this margin implements Canvas, this is the object which renders
            // the margin.
            // 由于这个边框实现了画布，因此这是渲染边框的对象。
            get
            {
                this.ThrowIfDisposed();
                return this;
            }
        }

        #endregion

        #region ITextViewMargin

        /// <summary>
        /// Gets the size of the margin.
        /// 获取边框的大小
        /// </summary>
        /// <remarks>
        /// For a horizontal margin this is the height of the margin,
        /// since the width will be determined by the <see cref="ITextView"/>.
        /// 对于水平边框来说，这是边框的高度，因为它的宽度将取决于ITextView
        /// 
        /// For a vertical margin this is the width of the margin,
        /// since the height will be determined by the <see cref="ITextView"/>.
        /// 
        /// 对于垂直边框来说，这是边框的宽度，因为它的高度将取决于ITextView
        /// </remarks>
        /// <exception cref="ObjectDisposedException">The margin is disposed.</exception>
        public double MarginSize
        {
            get
            {
                this.ThrowIfDisposed();

                // Since this is a horizontal margin, its width will be bound to the width of the text view.
                // 由于这是一个水平边框，因此它的宽度将绑定到文本视图的宽度。

                // Therefore, its size is its height.
                // 因此，它的大小就是它的高度
                return this.ActualHeight;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the margin is enabled.
        /// 获取一个值，该值指示边框是否启用
        /// </summary>
        /// <exception cref="ObjectDisposedException">The margin is disposed.</exception>
        public bool Enabled
        {
            get
            {
                this.ThrowIfDisposed();

                // The margin should always be enabled
                // 这个边框应始终启用
                return true;
            }
        }

        /// <summary>
        /// Gets the <see cref="ITextViewMargin"/> with the given <paramref name="marginName"/> or null if no match is found
        /// 获取具有给定 marginName 的 ITextViewMargin 值，如果找不到匹配项，则是null
        /// </summary>
        /// <param name="marginName">The name of the <see cref="ITextViewMargin"/></param>
        /// <returns>The <see cref="ITextViewMargin"/> named <paramref name="marginName"/>, or null if no match is found.</returns>
        /// <remarks>
        /// A margin returns itself if it is passed its own name.
        /// 如果是自己的名称，则边框将返回自身
        /// 
        /// If the name does not match and it is a container margin, it
        /// forwards the call to its children. 
        /// 如果名称不匹配且为容器边框，则会将调用转发给子级
        /// 
        /// Margin name comparisons are case-insensitive.
        /// 边框名称比较不区分大小写
        /// </remarks>
        /// <exception cref="ArgumentNullException"><paramref name="marginName"/> is null.</exception>
        public ITextViewMargin GetTextViewMargin(string marginName)
        {
            return string.Equals(marginName, EditorMargin1.MarginName, StringComparison.OrdinalIgnoreCase) ? this : null;
        }

        /// <summary>
        /// Disposes an instance of <see cref="EditorMargin1"/> class.
        /// </summary>
        public void Dispose()
        {
            if (!this.isDisposed)
            {
                //请求公共语言运行时不要调用指定对象的终结器
                GC.SuppressFinalize(this);
                this.isDisposed = true;
            }
        }

        #endregion

        /// <summary>
        /// Checks and throws <see cref="ObjectDisposedException"/> if the object is disposed.
        /// </summary>
        private void ThrowIfDisposed()
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(MarginName);
            }
        }
    }
}
