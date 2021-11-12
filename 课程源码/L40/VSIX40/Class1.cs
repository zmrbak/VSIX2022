using Microsoft.VisualStudio.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSIX40
{
    internal class Class1:DialogPage
    {
        private int addDays;

        public int AddDays
        {
            get { return addDays; }
            set { addDays = value; }
        }

    }
}
