namespace TaskManager_ConsoleApp_Terry
{
    public class Program
    {
        static void Main(string[] args)
        {
            var App = new App();
            App.Intialize();
            App.Main();
            App.Shutdown();
        }
    }
}
