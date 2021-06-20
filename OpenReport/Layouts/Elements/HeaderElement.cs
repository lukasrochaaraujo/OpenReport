﻿namespace OpenReport.Layouts.Elements
{
    public class HeaderElement : IElement
    {
        public string HeaderTop { get; set; }

        public string HeaderContent { get; set; }

        public string HeaderBottom { get; set; }

        public string Render()
        {
            return $@"
            <header'>
                <p style='font-size: 10pt'>{(string.IsNullOrWhiteSpace(HeaderTop) ? "" : HeaderTop)}</p>
                <p style='font-weight: 600'>{(string.IsNullOrWhiteSpace(HeaderContent) ? "" : HeaderContent)}</p>
                <span>{(string.IsNullOrWhiteSpace(HeaderBottom) ? "" : HeaderBottom)}</span>
            </header>
            ";
        }
    }
}
