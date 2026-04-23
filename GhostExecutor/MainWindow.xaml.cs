using System;
using System.Windows;
using System.Windows.Input;
using System.Runtime.InteropServices;

namespace GhostExecutor
{
    public partial class MainWindow : Window
    {
        // Импорт функций из твоей будущей GhostAPI.dll
        [DllImport("GhostAPI.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void ExecuteScript(string script);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void DragWindow(object sender, MouseButtonEventArgs e) => this.DragMove();
        private void CloseApp(object sender, RoutedEventArgs e) => Application.Current.Shutdown();
        private void MinimizeApp(object sender, RoutedEventArgs e) => this.WindowState = WindowState.Minimized;
        private void MaximizeApp(object sender, RoutedEventArgs e) => this.WindowState = (this.WindowState == WindowState.Maximized) ? WindowState.Normal : WindowState.Maximized;

        private void Execute_Click(object sender, RoutedEventArgs e)
        {
            try { ExecuteScript(ScriptBox.Text); }
            catch { MessageBox.Show("DLL not found! Please add GhostAPI.dll to the folder."); }
        }

        private void Clear_Click(object sender, RoutedEventArgs e) => ScriptBox.Clear();

        private void NewFile_Click(object sender, RoutedEventArgs e) => ScriptBox.Text = "-- New Script";
    }
}
