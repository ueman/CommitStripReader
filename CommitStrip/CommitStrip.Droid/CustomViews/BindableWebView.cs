using System;
using Android.Content;
using Android.Util;
using Android.Webkit;

namespace CommitStrip.Droid.CustomViews
{
    public class BindableWebView : WebView
    {
        private string _text;

        public BindableWebView(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
        }

        public string Text
        {
            get { return _text; }
            set
            {
                if (string.IsNullOrEmpty(value)) return;

                _text = MakeHtml(value);

                LoadData(_text, "text/html; charset=UTF-8", null);
                UpdatedHtmlContent();
            }
        }

        public event EventHandler HtmlContentChanged;

        private void UpdatedHtmlContent()
        {
            Settings.SetSupportZoom(true);
            HtmlContentChanged?.Invoke(this, EventArgs.Empty);
        }

        private string MakeHtml(string stuff)
        {
            return "<!DOCTYPE html><html><head><title></title>" +
                   "<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0, user-scalable=yes\"/>" +
                   "<meta name=\"charset\" content=\"utf-8\"/><style>html, body { margin: 0; padding: 0;" +
                    "width: 100%; } img { width: 100%; height: auto; } </style>" +
                   "</head><body>" + stuff + "</body></html>";
        }
    }
}