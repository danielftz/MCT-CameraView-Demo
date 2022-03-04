namespace CameraView
{
    public class MainPage : ContentPage
    {
        public MainPage()
        {
            Content = new CameraView()
            {
                BackgroundColor = Colors.Green,
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill,
                //HeightRequest = 500,
            };

        }
    }
}