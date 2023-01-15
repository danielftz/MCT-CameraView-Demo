namespace CameraView
{
    public class MainPage : ContentPage
    {
        public MainPage()
        {
            Content = new ContentView();
        }

        protected override async void OnAppearing()
        {


            PermissionStatus result = await Permissions.CheckStatusAsync<Permissions.Camera>();

            if (result == PermissionStatus.Granted)
            {
                Content = new CameraView();
                return;
            }

            result = await Permissions.RequestAsync<Permissions.Camera>();
            if (result == PermissionStatus.Granted)
            {
                Content = new CameraView();
                return;
            }

            base.OnAppearing();


        }
    }
}
