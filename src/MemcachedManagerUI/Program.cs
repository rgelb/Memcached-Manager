namespace MemcachedManager.UI;

internal static class Program {
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main() {
        // Add handler to handle the exception raised by main threads
        Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);

        // Add handler to handle the exception raised by additional threads
        AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);


        ApplicationConfiguration.Initialize();
        Application.Run(new frmMain());
    }

    private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) {
        MessageBox.Show(((Exception)e.ExceptionObject).Message);
    }

    private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e) {
        MessageBox.Show(e.Exception.Message);
    }
}