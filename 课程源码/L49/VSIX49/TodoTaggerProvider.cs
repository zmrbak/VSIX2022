using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSIX49
{
    [Export(typeof(ITaggerProvider))]
    [ContentType("code")]
    [TagType(typeof(TodoTag))]
    internal class TodoTaggerProvider : ITaggerProvider
    {
#pragma warning disable  649
        [Import]
        internal IClassifierAggregatorService AggregatorService;
#pragma warning restore 649

        public ITagger<T> CreateTagger<T>(ITextBuffer buffer) where T : ITag
        {
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer");
            }

            return new TodoTagger(AggregatorService.GetClassifier(buffer)) as ITagger<T>;
        }
    }
}
