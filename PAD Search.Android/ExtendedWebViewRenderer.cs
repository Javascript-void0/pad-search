using Android.Content;
using Android.Webkit;
using PAD_Search.ViewModels;
using PAD_Search.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using WebView = Android.Webkit.WebView;
using System.Collections.Generic;
using System.Diagnostics;

[assembly: ExportRenderer(typeof(ExtendedWebView), typeof(ExtendedWebViewRenderer))]
namespace PAD_Search.Droid
{
    public class ExtendedWebViewRenderer : WebViewRenderer
    {
        //static List<ExtendedWebView> _xwebViews = new List<ExtendedWebView>();
        WebView _webView;
        Context _context;

        public ExtendedWebViewRenderer(Context context) : base(context)
        {
            _context = context;
        }

        class ExtendedWebViewClient : WebViewClient
        {
            private ExtendedWebView _xwebView;
            public ExtendedWebViewClient(ExtendedWebView _xwebView)
            {
                this._xwebView = _xwebView;
            }
            public override async void OnPageFinished(WebView view, string url)
            {
                try
                {
                    if (_xwebView != null)
                    {
                        int i = 10;
                        while (view.ContentHeight == 0 && i-- > 0) // wait here till content is rendered
                            await System.Threading.Tasks.Task.Delay(100);
                        _xwebView.HeightRequest = view.ContentHeight;
                    }
                    base.OnPageFinished(view, url);
                }
                catch (System.ObjectDisposedException ex)
                {
                    System.Diagnostics.Debug.WriteLine("WebView already gone (OnPageFinished)");
                }
            }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.WebView> e)
        {
            try
            {
                base.OnElementChanged(e);
                _webView = Control;
                if (e.OldElement == null)
                {
                    _webView.SetWebViewClient(new ExtendedWebViewClient(
                        e.NewElement as ExtendedWebView));
                }
            }
            catch (System.ObjectDisposedException ex)
            {
                System.Diagnostics.Debug.WriteLine("WebView already gone (OneElementChanged)");
            }
        }
    }
}