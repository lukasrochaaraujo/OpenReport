using System;
using System.Windows.Forms;

using OpenReport.Layouts.Elements;

namespace OpenReport
{
    public partial class ORDocumentViewer : Form
    {
        DocumentElement Document;

        public ORDocumentViewer(DocumentElement document)
        {
            InitializeComponent();
            Icon = Properties.Resources.OpenReportIcon;
            Document = document;
        }

        private void ORDocumentViewer_Shown(object sender, EventArgs e)
        {
            Text = $"ORViewer - {Document.HeaderContent}";
            wb_viewer.DocumentText = Document.Render();
        }
    }
}
