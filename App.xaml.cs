namespace ForMyFather
{
	using System.Windows;
	using ForMyFather.View;

	/// <summary> 
	    /// App.xaml の相互作用ロジック 
	    /// </summary> 
	public partial class App : Application
	{
		private void Application_Startup(object sender, StartupEventArgs e)
		{
			var v = new MainWindow();
			v.Show();
		}
	}
}
