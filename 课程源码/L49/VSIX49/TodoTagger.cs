using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Tagging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSIX49
{
    internal class TodoTagger : ITagger<TodoTag>
    {
        private readonly IClassifier classifier;
        private readonly string searchText = "todo";

#pragma warning disable 67
        public event EventHandler<SnapshotSpanEventArgs> TagsChanged;
#pragma warning restore 67
        public TodoTagger(IClassifier classifier)
        {
            this.classifier = classifier;
        }

        public IEnumerable<ITagSpan<TodoTag>> GetTags(NormalizedSnapshotSpanCollection spans)
        {
            foreach (SnapshotSpan span in spans)
            {
                //look at each classification span \
                foreach (ClassificationSpan classification in classifier.GetClassificationSpans(span))
                {
                    //if the classification is a comment
                    if (classification.ClassificationType.Classification.ToLower().Contains("comment"))
                    {
                        //if the word "todo" is in the comment,
                        //create a new TodoTag TagSpan
                        int index = classification.Span.GetText().ToLower().IndexOf(searchText);
                        if (index != -1)
                        {
                            yield return new TagSpan<TodoTag>(new SnapshotSpan(classification.Span.Start + index, searchText.Length), new TodoTag());
                        }
                    }
                }
            }
        }
    }
}
