using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System.ComponentModel.Composition;

namespace VSIX41
{
    /// <summary>
    /// Classification type definition export for EditorClassifier1
    /// 
    /// EditorClassifier1的分类类型定义导出    
    /// </summary>
    internal static class EditorClassifier1ClassificationDefinition
    {
        // This disables "The field is never used" compiler's warning. Justification: the field is used by MEF.
        //这将禁用“从未使用该字段”编译器的警告。原因：该字段由MEF使用。
#pragma warning disable 169

        /// <summary>
        /// Defines the "EditorClassifier1" classification type.
        /// 定义“EditorClassifier1”分类类型
        /// </summary>
        [Export(typeof(ClassificationTypeDefinition))]
        [Name("EditorClassifier1")]
        private static ClassificationTypeDefinition typeDefinition;

#pragma warning restore 169
    }
}
