using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Text;

namespace VSIX47
{
    [Export(typeof(IClassifierProvider))]
    [ContentType("Json")]
    internal class EditorClassifier1Provider : IClassifierProvider
    {
#pragma warning disable 649,169

        [Import]
        private IClassificationTypeRegistryService classificationRegistry;

        [Import]
        private IContentTypeRegistryService contentTypeRegistryService;


#pragma warning restore 649

        #region IClassifierProvider

        public IClassifier GetClassifier(ITextBuffer buffer)
        {
            int index = 0;
            foreach (var item in contentTypeRegistryService.ContentTypes)
            {
                index++;
                Debug.WriteLine("["+index+"]:"+item.DisplayName);
                foreach (var item2 in item.BaseTypes)
                {
                    Debug.WriteLine("\t" + item2.DisplayName);
                }
            }

            return buffer.Properties.GetOrCreateSingletonProperty<EditorClassifier1>(creator: () => new EditorClassifier1(this.classificationRegistry));
        }

        #endregion
    }
}
