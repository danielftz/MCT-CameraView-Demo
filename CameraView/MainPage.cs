namespace CameraView
{
    public class MainPage : ContentPage
    {
        public MainPage()
        {
            Content = new CameraView()
            {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill,
            };

        }
    }
}