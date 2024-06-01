using System.Media;
using System.Windows;

namespace Task3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SoundPlayer soundPlayer;

        public MainWindow()
        {
            InitializeComponent();

            mediaElement.Source = new Uri("Videos//leon.mp4", UriKind.RelativeOrAbsolute);
            mediaElement.MediaEnded += MediaElement_MediaEnded;

            soundPlayer = new SoundPlayer("Sounds//game-won.wav");
        }

        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            mediaElement.Position = TimeSpan.Zero;
            mediaElement.Play();
        }

        private void PlaySound1Button_Click(object sender, RoutedEventArgs e)
        {
            SystemSounds.Hand.Play();
        }

        private void PlaySound2Button_Click(object sender, RoutedEventArgs e)
        {
            SystemSounds.Beep.Play();
        }

        private void PlaySound3Button_Click(object sender, RoutedEventArgs e)
        {
            soundPlayer.Play();
        }
    }
}