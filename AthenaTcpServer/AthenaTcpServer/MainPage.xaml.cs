using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Networking;
using System.Diagnostics;


namespace AthenaTcpServer
{
    /// <summary>
    /// Home Page
    /// </summary>
    public sealed partial class MainPage : Page
    {
        TcpMainController SocketManager = new TcpMainController();

        public MainPage()
        {
            this.InitializeComponent();

            TcpMainController.IsServer = true;
            HostName ServerAdress = new HostName("Darkspede_AthenaServer");

            SocketManager.DataListener_OpenListenPorts();


            AssetController asset = new AssetController();


            // Server
            if (TcpMainController.IsServer)
            {
                Debug.WriteLine("[ATHENA] Online");
            }
            // Client
            else
            {
                SocketManager.SentResponse(ServerAdress, "Athena");
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
