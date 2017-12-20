using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Storage.FileProperties;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App18
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public double Maxunmber { get; set; }
        public bool IsSelectable { get; set; }
        public List<ULanguage> Languages { get; set; }

        public MainPage()
        {
            Languages = new List<ULanguage>();
            Languages.Add(new ULanguage { Name = "China", IsSelectable = false });
            Languages.Add(new ULanguage { Name = "China", IsSelectable = true });
            Languages.Add(new ULanguage { Name = "China", IsSelectable = false });
            Languages.Add(new ULanguage { Name = "China", IsSelectable = true });

            this.InitializeComponent();
            cmbLanguage.Drop += CmbLanguage_Drop;
            this.DataContext = this;
            // cmbLanguage.ItemsSource = Languages;

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var da = cmbLanguage.DataContext;

            var item = cmbLanguage.ContainerFromIndex(1) as ComboBoxItem;
            item.IsEnabled = false;

            //    item.IsEnabled = false;
            //var picker = new Windows.Storage.Pickers.FileOpenPicker();
            //picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            //picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            //picker.FileTypeFilter.Add(".jpg");
            //picker.FileTypeFilter.Add(".jpeg");
            //picker.FileTypeFilter.Add(".mp3");

            //Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            //if (file != null)
            //{
            //    // Application now has read/write access to the picked file
            //    this.Info.Text = "Picked photo: " + file.Name;
            //    MusicProperties properties = await file.Properties.GetMusicPropertiesAsync();
            //    TimeSpan myTrackDuration = properties.Duration;
            //    MusicSlider.Maximum = myTrackDuration.TotalSeconds;
            //    var MusicFile = MediaSource.CreateFromStorageFile(file);
            //    Mp3Player.Source = MusicFile;



            //    //   await Task.Delay(100);
            //    // 
            //    Mp3Player.MediaPlayer.Play();
            //    Mp3Player.MediaPlayer.MediaOpened += MediaPlayer_MediaOpened;
            //    //   PlayPauseIm.Source = new BitmapImage(new Uri("ms-appx:///Assets/Pause_Button.png"));
            //}
            //else
            //{
            //    this.Info.Text = "Operation cancelled.";
            //}
        }

        private void CmbLanguage_Drop(object sender, DragEventArgs e)
        {

        }

        private async void MediaPlayer_MediaOpened(Windows.Media.Playback.MediaPlayer sender, object args)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
             {
                 MusicSlider.Maximum = Mp3Player.MediaPlayer.PlaybackSession.NaturalDuration.TotalSeconds;
             });
        }

        private void LanguageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmbLanguage_Loaded(object sender, RoutedEventArgs e)
        {
            cmbLanguage.SelectedIndex = 0;
            //  var item = cmbLanguage.ContainerFromIndex(0) as ComboBoxItem;
            //  item.IsEnabled = false;
        }

        private async void cmbLanguage_DropDownOpened(object sender, object e)
        {
            await Task.Delay(1);
            var item = cmbLanguage.ContainerFromIndex(1) as ComboBoxItem;
            item.IsEnabled = false;
        }
    }
    public class ULanguage
    {
        public string Name { get; set; }
        public bool IsSelectable { get; set; }
    }
}
