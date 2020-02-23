namespace OpenReport.Layouts.Elements
{
    public class DocumentElement : IElement
    {
        public string Content { get; set; }

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
                {Content}
            </body>
            </html>
            ";
        }
    }
}
