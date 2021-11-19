using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace VSIX48
{
    internal /*static*/ class Class1
    {
#pragma warning disable 649
        [Export]
        [Name("zmrbak")]        
        [BaseDefinition("text")]
        internal /*static*/ ContentTypeDefinition exampleDefinition;


        [Export]
        [FileExtension(".zmrbak")]  
        [ContentType("zmrbak")]
        internal /*static*/ FileExtensionToContentTypeDefinition abcFileExtensionDefinition;
#pragma warning restore 649
    }
}
