using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using System;
using System.Collections.Generic;

namespace VSIX41
{
    /// <summary>
    /// Classifier that classifies all text as an instance of the "EditorClassifier1" classification type.
    /// 
    /// 将所有文本分类为“EditorClassifier1”分类类型实例的分类器。
    /// </summary>
    internal class EditorClassifier1 : IClassifier
    {
        /// <summary>
        /// Classification type.
        /// 分类类型
        /// </summary>
        private readonly IClassificationType classificationType;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditorClassifier1"/> class.
        /// </summary>
        /// <param name="registry">Classification registry.</param>
        internal EditorClassifier1(IClassificationTypeRegistryService registry)
        {
            this.classificationType = registry.GetClassificationType("EditorClassifier1");
        }

        #region IClassifier

#pragma warning disable 67

        // warning CS0067: 从不使用事件“EditorClassifier1.ClassificationChanged”
        /// <summary>
        /// An event that occurs when the classification of a span of text has changed.
        /// 
        /// 当文本范围的分类更改时发生的事件
        /// </summary>
        /// <remarks>
        /// This event gets raised if a non-text change would affect the classification in some way,
        /// 
        /// 如果非文本更改会以某种方式影响分类，则会引发此事件。
        /// for example typing /* would cause the classification to change in C# without directly
        /// affecting the span.
        /// 
        /// 如果键入/*会导致分类在C#中更改，而不会直接影响范围。
        /// </remarks>
        public event EventHandler<ClassificationChangedEventArgs> ClassificationChanged;

#pragma warning restore 67

        /// <summary>
        /// Gets all the <see cref="ClassificationSpan"/> objects that intersect with the given range of text.
        /// 
        /// 获取与给定文本范围相交的所有对象
        /// </summary>
        /// <remarks>
        /// This method scans the given SnapshotSpan for potential matches for this classification.
        /// 
        /// 此方法扫描给定的快照范围以查找此分类的潜在匹配项。
        /// In this instance, it classifies everything and returns each span as a new ClassificationSpan.
        /// 
        /// 在这个实例中，它对所有内容进行分类，并将每个span作为新的ClassificationSpan返回
        /// 
        /// </remarks>
        /// <param name="span">The span currently being classified.</param>
        /// <returns>A list of ClassificationSpans that represent spans identified to be of this classification.
        /// ClassificationSpans列表，表示确定属于该分类的范围
        /// </returns>
        public IList<ClassificationSpan> GetClassificationSpans(SnapshotSpan span)
        {
            var result = new List<ClassificationSpan>()
            {
                new ClassificationSpan(new SnapshotSpan(span.Snapshot, new Span(span.Start, span.Length)), this.classificationType)
            };

            return result;
        }

        #endregion
    }
}
