using Azure.AI.InkRecognizer;
using Azure.AI.InkRecognizer.Models;
using Azure.AI.UWP.Stroke;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NoteTakerUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // Replace the subscriptionKey string value with your valid subscription key.
        const string subscriptionKey = "[SUBSCRIPTION KEY GOES HERE]";

        // URI information for ink recognition:
        const string inkRecognitionUrl = "https://api.cognitive.microsoft.com/inkrecognizer";

        InkStrokeStore strokeStore;
        Dictionary<Windows.UI.Input.Inking.InkStroke, long> strokeToIdMap;
        Dictionary<long,Windows.UI.Input.Inking.InkStroke> idToStrokeMap;
        private readonly DispatcherTimer dispatcherTimer;

        // Time to wait before triggering ink recognition operation
        const double IDLE_WAITING_TIME = 1000;

        // <MainPage>
        public MainPage()
        {
            this.InitializeComponent();

            strokeToIdMap = new Dictionary<Windows.UI.Input.Inking.InkStroke, long>();
            idToStrokeMap = new Dictionary<long, Windows.UI.Input.Inking.InkStroke>();

            strokeStore = new InkStrokeStore();

            // By default, enable inking only by Pen
            var inkPresenter = inkCanvas.InkPresenter;
            inkPresenter.InputDeviceTypes = Windows.UI.Core.CoreInputDeviceTypes.Pen;

            inkPresenter.StrokeInput.StrokeStarted += InkPresenter_StrokeInputStarted;
            inkPresenter.StrokeInput.StrokeEnded += InkPresenter_StrokeInputEnded;
            inkPresenter.StrokesCollected += InkPresenter_StrokesCollected;
            inkPresenter.StrokesErased += InkPresenter_StrokesErased;

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(IDLE_WAITING_TIME);
        }
        // </MainPage>

        // <TouchInkingButton_Checked>
        private void TouchInkingButton_Checked(object sender, RoutedEventArgs args)
        {
            var inkPresenter = inkCanvas.InkPresenter;
            inkPresenter.InputDeviceTypes = Windows.UI.Core.CoreInputDeviceTypes.Pen | Windows.UI.Core.CoreInputDeviceTypes.Mouse;
        }
        // </TouchInkingButton_Checked>

        // <TouchInkingButton_Unchecked>
        private void TouchInkingButton_Unchecked(object sender, RoutedEventArgs args)
        {
            var inkPresenter = inkCanvas.InkPresenter;
            inkPresenter.InputDeviceTypes = Windows.UI.Core.CoreInputDeviceTypes.Pen;
        }
        // </TouchInkingButton_Unchecked>

        // <EraseInkingButton_Checked>
        private void EraseInkingButton_Checked(object sender, RoutedEventArgs args)
        {
            var inkPresenter = inkCanvas.InkPresenter;
            inkPresenter.InputProcessingConfiguration.Mode = Windows.UI.Input.Inking.InkInputProcessingMode.Erasing;
        }
        // </EraseInkingButton_Checked>

        // <EraseInkingButton_Unchecked>
        private void EraseInkingButton_Unchecked(object sender, RoutedEventArgs args)
        {
            var inkPresenter = inkCanvas.InkPresenter;
            inkPresenter.InputProcessingConfiguration.Mode = Windows.UI.Input.Inking.InkInputProcessingMode.Inking;
        }
        // </EraseInkingButton_Unchecked>

        // <ClearButton_Tapped>
        private void ClearButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            canvas.Children.Clear();
            var inkPresenter = inkCanvas.InkPresenter;
            inkPresenter.StrokeContainer.Clear();

            foreach(var stroke in strokeToIdMap.Keys)
            {
                strokeStore.RemoveStroke(strokeToIdMap[stroke]);
            }
            strokeToIdMap.Clear();
            idToStrokeMap.Clear();
            output.Text = "";
        }
        // </ClearButton_Tapped>

        // <Search_QuerySubmitted>
        private async void Search_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            try
            {
                var root = await AnalyzeInk();
                var words = root.FindWord(args.QueryText);

                foreach(var word in words)
                {
                    var strokeIds = word.StrokeIds;
                    foreach(var strokeId in strokeIds)
                    {
                        var stroke = idToStrokeMap[strokeId];

                        // Highlight the matching ink strokes in red
                        stroke.DrawingAttributes.Color = Windows.UI.Colors.Red;
                    }
                }
            }
            catch(Exception e)
            {
                output.Text = OutputWriter.PrintError(e.Message);
            }
        }
        // </Search_QuerySubmitted>

        // <InkPresenter_StrokeInputStarted>
        private void InkPresenter_StrokeInputStarted(Windows.UI.Input.Inking.InkStrokeInput sender, PointerEventArgs args)
        {
            StopTimer();
        }
        // </InkPresenter_StrokeInputStarted>

        // <InkPresenter_StrokeInputEnded>
        private void InkPresenter_StrokeInputEnded(Windows.UI.Input.Inking.InkStrokeInput sender, PointerEventArgs args)
        {
            StartTimer();
        }
        // </InkPresenter_StrokeInputEnded>

        // <InkPresenter_StrokesCollected>
        private void InkPresenter_StrokesCollected(Windows.UI.Input.Inking.InkPresenter sender, Windows.UI.Input.Inking.InkStrokesCollectedEventArgs args)
        {
            StopTimer();

            foreach (var stroke in args.Strokes)
            {
                var strokeId = strokeStore.AddStroke(stroke);
                strokeToIdMap.Add(stroke, strokeId);
                idToStrokeMap.Add(strokeId, stroke);
            }

            StartTimer();
        }
        // </InkPresenter_StrokesCollected>

        // <InkPresenter_StrokesErased>
        private void InkPresenter_StrokesErased(Windows.UI.Input.Inking.InkPresenter sender, Windows.UI.Input.Inking.InkStrokesErasedEventArgs args)
        {
            StopTimer();

            foreach (var stroke in args.Strokes)
            {
                strokeStore.RemoveStroke(strokeToIdMap[stroke]);
                idToStrokeMap.Remove(strokeToIdMap[stroke]);
                strokeToIdMap.Remove(stroke);
            }

            StartTimer();
        }
        // </InkPresenter_StrokesErased>

        // <DispatcherTimer_Tick>
        private async void DispatcherTimer_Tick(object sender, object e)
        {
            StopTimer();
            try
            {
                var root = await AnalyzeInk();
                output.Text = OutputWriter.Print(root);
            }
            catch(Exception ex)
            {
                output.Text = OutputWriter.PrintError(ex.Message);
            }
        }
        // </DispatcherTimer_Tick>

        // <GetApplicationKind>
        private ApplicationKind GetApplicationKind(string appKindString)
        {
            switch (appKindString)
            {
                case "Writing":
                    return ApplicationKind.Writing;
                case "Drawing":
                    return ApplicationKind.Drawing;
                case "Mixed":
                default:
                    return ApplicationKind.Mixed;
            }
        }
        // </GetApplicationKind>

        // <AnalyzeInk>
        private async Task<RecognitionRoot> AnalyzeInk()
        {
            try
            {
                var selectedLanguage = (ComboBoxItem)LanguageComboBox.SelectedValue;
                var selectedApplicationKind = (ComboBoxItem)ApplicationKindComboBox.SelectedValue;
                var inkRecognizerClientOptions = new InkRecognizerClientOptions()
                {
                    Language = selectedLanguage.Content.ToString(),
                    ApplicationKind = GetApplicationKind(selectedApplicationKind.Content.ToString())
                };

                var credential = new InkRecognizerCredential(subscriptionKey);
                var endPoint = new Uri(inkRecognitionUrl);
                var inkRecognizer = new InkRecognizerClient(endPoint, credential, inkRecognizerClientOptions);

                var response = await inkRecognizer.RecognizeInkAsync(strokeStore.GetStrokes());
                var root = response.Value;
                return root;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        // </AnalyzeInk>

        public void StartTimer() => dispatcherTimer.Start();
        public void StopTimer() => dispatcherTimer.Stop();
    }
}
