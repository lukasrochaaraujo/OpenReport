using System.Text;

namespace OpenReport.Layouts.Elements
{
    public class DocumentElement : IElement
    {
        public string HeaderContent { get; private set; }
        public StringBuilder ContentBuilder { get; private set; }

        public DocumentElement(HeaderElement header)
        {
            ContentBuilder = new StringBuilder();
            HeaderContent = header.HeaderContent;
            AppendContent(header.Render());
        }

        public void AppendContent(string content)
            => ContentBuilder.Append(content);

        public string Render()
        {
            return $@"
            <!doctype html>
            <html>
            <head>
                <meta charset='utf-8'>
                <style media='print'>{Properties.Resources.PureCssContent}></style>
                <style media='screen'>{Properties.Resources.PureCssContent}></style>
            </head>
            <body style='padding: 2.5%'>
                {ContentBuilder}
            </body>
            </html>
            ";
        }
    }
}
