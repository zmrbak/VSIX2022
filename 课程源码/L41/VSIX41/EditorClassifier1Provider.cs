using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System.ComponentModel.Composition;

namespace VSIX41
{
    /// <summary>
    /// Classifier provider. It adds the classifier to the set of classifiers.
    /// 
    /// 分类器提供者。它将分类器添加到分类器集中。
    /// </summary>
    [Export(typeof(IClassifierProvider))]
    // This classifier applies to all text files.
    //此分类器适用于所有文本文件。
    [ContentType("text")] 
    internal class EditorClassifier1Provider : IClassifierProvider
    {
        // Disable "Field is never assigned to..." compiler's warning. Justification: the field is assigned by MEF.
        // 禁用“字段从未分配给…”编译器的警告。原因：该字段由MEF指定。
#pragma warning disable 649

        /// <summary>
        /// Classification registry to be used for getting a reference
        /// to the custom classification type later.
        /// 
        /// 分类注册表，用于以后获取对自定义分类类型的引用
        /// </summary>
        [Import]
        private IClassificationTypeRegistryService classificationRegistry;

#pragma warning restore 649

        #region IClassifierProvider

        /// <summary>
        /// Gets a classifier for the given text buffer.
        /// 获取给定文本缓冲区的分类器
        /// 
        /// </summary>
        /// <param name="buffer">The <see cref="ITextBuffer"/> to classify.</param>
        /// <returns>A classifier for the text buffer, or null if the provider cannot do so in its current state.
        /// 文本缓冲区的分类器，如果提供程序在其当前状态下无法这样做，则返回null
        /// </returns>
        public IClassifier GetClassifier(ITextBuffer buffer)
        {
            //return buffer.Properties.GetOrCreateSingletonProperty<EditorClassifier1>(creator: () => new EditorClassifier1(this.classificationRegistry));
            return buffer.Properties.GetOrCreateSingletonProperty<EditorClassifier1>(
                () => new EditorClassifier1(this.classificationRegistry)
                );
        }

        #endregion
    }
}
