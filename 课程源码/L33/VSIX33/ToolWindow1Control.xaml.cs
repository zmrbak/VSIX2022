using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace VSIX33
{
    public partial class ToolWindow1Control : UserControl
    {
        public TextBox SearchResultsTextBox { get;  }
        public string SearchContent { get; }
        public ToolWindow1Control()
        {
            this.InitializeComponent();
            SearchResultsTextBox = this.resultsTextBox;

            SearchContent = BuildContent();
            SearchResultsTextBox.Text = SearchContent;
        }

        private string BuildContent()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("1 go");
            stringBuilder.AppendLine("2 Go");
            stringBuilder.AppendLine("3 good");
            stringBuilder.AppendLine("4 Good");
            stringBuilder.AppendLine("5 good morning");
            stringBuilder.AppendLine("6 Good morning");
            return stringBuilder.ToString();
        }
    }
}