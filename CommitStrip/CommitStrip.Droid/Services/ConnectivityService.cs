using System.Diagnostics;
using Android.Content;
using Android.Net;
using CommitStrip.Core.Services;
using Java.Lang;

namespace CommitStrip.Droid.Services
{
    public class ConnectivityService : INetworkConnectivityService
    {

        private Context Ctx { get; set; }

        private ConnectivityManager _connectivityManager;
        protected ConnectivityManager ConnectivityManager
        {
            get
            {
                _connectivityManager = _connectivityManager ??
                                       (ConnectivityManager)Ctx.GetSystemService(Context.ConnectivityService);
                return _connectivityManager;
            }
        }

        public ConnectivityService(Context ctx)
        {
            Ctx = ctx;
        }

        public bool IsConnected()
        {
            try
            {
                var activeConnection = ConnectivityManager.ActiveNetworkInfo;
                return (activeConnection != null) && activeConnection.IsConnected;
            }
            catch (Exception e)
            {
                Debug.WriteLine("ConnectivityService::IsConnected Exception:");
                Debug.WriteLine(e.ToString());
                return false;
            }
        }
    }
}