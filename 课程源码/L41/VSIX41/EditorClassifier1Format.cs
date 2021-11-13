using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System.ComponentModel.Composition;
using System.Windows.Media;

namespace VSIX41
{
    /// <summary>
    /// Defines an editor format for the EditorClassifier1 type that has a purple background
    /// and is underlined.
    /// 
    /// 定义EditorClassifier1类型的编辑器格式，该类型具有紫色背景并带下划线
    /// </summary>
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "EditorClassifier1")]
    [Name("EditorClassifier1")]
    // This should be visible to the end user
    //这对最终用户应该是可见的
    [UserVisible(true)]
    // Set the priority to be after the default classifiers
    //将优先级设置为在默认分类器之后
    [Order(Before = Priority.Default)] 
    internal sealed class EditorClassifier1Format : ClassificationFormatDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EditorClassifier1Format"/> class.
        /// </summary>
        public EditorClassifier1Format()
        {
            this.DisplayName = "EditorClassifier1"; // Human readable version of the name
            this.BackgroundColor = Colors.BlueViolet;
            this.TextDecorations = System.Windows.TextDecorations.Underline;
        }
    }
}
