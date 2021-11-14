using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Utilities;
using System.ComponentModel.Composition;

namespace VSIX43
{
    /// <summary>
    /// Export a <see cref="IWpfTextViewMarginProvider"/>, which returns an instance of the margin for the editor to use.
    /// 导出一个IWpfTextViewMarginProvider，它返回一个供编辑器使用的边框的实例。
    /// </summary>
    [Export(typeof(IWpfTextViewMarginProvider))]
    [Name(EditorMargin1.MarginName)]
    // Ensure that the margin occurs below the horizontal scrollbar
    // 确保边距位于水平滚动条下方
    [Order(After = PredefinedMarginNames.HorizontalScrollBar)]
    // Set the container to the bottom of the editor window
    // 将容器设置到编辑器窗口的底部
    [MarginContainer(PredefinedMarginNames.Bottom)]
    // Show this margin for all text-based types
    // 为所有基于文本的类型显示此边框
    [ContentType("text")]                                      
    [TextViewRole(PredefinedTextViewRoles.Interactive)]
    internal sealed class EditorMargin1Factory : IWpfTextViewMarginProvider
    {
        #region IWpfTextViewMarginProvider

        /// <summary>
        /// Creates an <see cref="IWpfTextViewMargin"/> for the given <see cref="IWpfTextViewHost"/>.
        /// 为给定的 IWpfTextViewHost 创建 IWpfTextViewMargin 
        /// </summary>
        /// <param name="wpfTextViewHost">The <see cref="IWpfTextViewHost"/> for which to create the <see cref="IWpfTextViewMargin"/>.</param>
        /// <param name="marginContainer">The margin that will contain the newly-created margin.</param>
        /// <returns>The <see cref="IWpfTextViewMargin"/>.
        /// The value may be null if this <see cref="IWpfTextViewMarginProvider"/> does not participate for this context.
        /// 如果此 IWPTextViewMarginProvider 未参与此上下文，则该值可能为null。
        /// </returns>
        public IWpfTextViewMargin CreateMargin(IWpfTextViewHost wpfTextViewHost, IWpfTextViewMargin marginContainer)
        {
            return new EditorMargin1(wpfTextViewHost.TextView);
        }

        #endregion
    }
}
