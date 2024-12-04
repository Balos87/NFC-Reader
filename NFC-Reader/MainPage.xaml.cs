using Plugin.NFC;

namespace NFC_Reader
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            CrossNFC.Current.OnMessageReceived += Current_OnMessageReceived;
            CrossNFC.Current.OnTagDiscovered += Current_OnTagDiscovered;
            CrossNFC.Current.OnNfcStatusChanged += Current_OnNfcStatusChanged;
        }

        private void Current_OnMessageReceived(ITagInfo tagInfo)
        {
            if (tagInfo == null) return;

            var message = tagInfo.Records?.FirstOrDefault()?.Message;
            DisplayAlert("NFC Message", message ?? "Ingen data funnen.", "OK");
        }


        private void Current_OnTagDiscovered(ITagInfo tagInfo, bool format)
        {
            if (tagInfo == null) return;

            DisplayAlert("NFC Tag Discovered", $"Tag ID: {tagInfo.Identifier}", "OK");
        }


        private void Current_OnNfcStatusChanged(bool isEnabled)
        {
            DisplayAlert("NFC Status", isEnabled ? "NFC är aktiverat" : "NFC är avstängt", "OK");
        }


        private async void ScanBtn_Clicked(object sender, EventArgs e)
        {
            if (!CrossNFC.IsSupported)
            {
                await DisplayAlert("Fel", "NFC stöds inte på denna enhet.", "OK");
                return;
            }

            if (!CrossNFC.Current.IsAvailable || !CrossNFC.Current.IsEnabled)
            {
                await DisplayAlert("Fel", "NFC är inte tillgängligt eller aktiverat.", "OK");
                return;
            }

            CrossNFC.Current.StartListening(); // Starta NFC-lyssning
            await DisplayAlert("Info", "Lyssnar efter NFC-taggar.", "OK");
        }


        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
