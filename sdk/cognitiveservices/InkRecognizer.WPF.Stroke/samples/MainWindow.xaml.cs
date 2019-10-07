using Azure.AI.InkRecognizer;
using Azure.AI.InkRecognizer.Models;
using Azure.AI.InkRecognizer.WPF.Stroke;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace NoteTakerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Replace the subscriptionKey string value with your valid subscription key.
        const string subscriptionKey = "[SUBSCRIPTION KEY GOES HERE]";

        // URI information for ink recognition:
        const string inkRecognitionUrl = "https://api.cognitive.microsoft.com/inkrecognizer";

        InkStrokeStore strokeStore;
        Dictionary<System.Windows.Ink.Stroke, long> strokeToIdMap;
        Dictionary<long, System.Windows.Ink.Stroke> idToStrokeMap;
        private readonly DispatcherTimer dispatcherTimer;

        // Time to wait before triggering ink recognition operation
        const double IDLE_WAITING_TIME = 1000;

        // <MainWindow>
        public MainWindow()
        {
            InitializeComponent();

            strokeToIdMap = new Dictionary<System.Windows.Ink.Stroke, long>();
            idToStrokeMap = new Dictionary<long, System.Windows.Ink.Stroke>();

            strokeStore = new InkStrokeStore();

            //Use Bezier smoothing while rendering the stroke
            var drawingAttributes = inkCanvas.DefaultDrawingAttributes;
            drawingAttributes.FitToCurve = true;
            inkCanvas.DefaultDrawingAttributes = drawingAttributes;

            inkCanvas.StrokeCollected += InkCanvas_StrokeCollected;
            inkCanvas.StrokeErasing += InkCanvas_StrokeErased;

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(IDLE_WAITING_TIME);
        }
        // </MainWindow>

        // <TouchInkingButton_Checked>
        void TouchInkingButton_Checked(object sender, RoutedEventArgs e)
        {
            inkCanvas.EditingMode = InkCanvasEditingMode.Ink;
        }
        // </TouchInkingButton_Checked>

        // <TouchInkingButton_Unchecked>
        void TouchInkingButton_Unchecked(object sender, RoutedEventArgs e)
        {
            inkCanvas.EditingMode = InkCanvasEditingMode.None;
        }
        // </TouchInkingButton_Unchecked>

        // <EraseInkingButton_Checked>
        void EraseInkingButton_Checked(object sender, RoutedEventArgs e)
        {
            inkCanvas.EditingMode = InkCanvasEditingMode.EraseByStroke;
        }
        // </EraseInkingButton_Checked>

        // <EraseInkingButton_Unchecked>
        void EraseInkingButton_Unchecked(object sender, RoutedEventArgs e)
        {
            inkCanvas.EditingMode = InkCanvasEditingMode.Ink;
        }
        // </EraseInkingButton_Unchecked>

        // <ClearButton_Tapped>
        private void ClearButton_Tapped(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();
            inkCanvas.Strokes.Clear();

            foreach (var stroke in strokeToIdMap.Keys)
            {
                strokeStore.RemoveStroke(strokeToIdMap[stroke]);
            }
            strokeToIdMap.Clear();
            idToStrokeMap.Clear();
            output.Text = "";
        }
        // </ClearButton_Tapped>

        // <SearchQuery_Submitted>
        private async void SearchQuery_Submitted(object sender, RoutedEventArgs args)
        {
            try
            {
                var root = await AnalyzeInk();
                var words = root.FindWord(searchBox.Text);

                foreach (var word in words)
                {
                    var strokeIds = word.StrokeIds;
                    foreach (var strokeId in strokeIds)
                    {
                        var stroke = idToStrokeMap[strokeId];

                        // Highlight the matching ink strokes in red
                        stroke.DrawingAttributes.Color = Colors.Red;
                    }
                }
            }
            catch (Exception e)
            {
                output.Text = OutputWriter.PrintError(e.Message);
            }
        }
        // </SearchQuery_Submitted>

        // <InkCanvas_StrokeErased>
        private void InkCanvas_StrokeErased(object sender, InkCanvasStrokeErasingEventArgs e)
        {
            StopTimer();

            strokeStore.RemoveStroke(strokeToIdMap[e.Stroke]);
            idToStrokeMap.Remove(strokeToIdMap[e.Stroke]);
            strokeToIdMap.Remove(e.Stroke);

            StartTimer();
        }
        // </InkCanvas_StrokeErased>

        // <InkCanvas_StrokeCollected>
        private void InkCanvas_StrokeCollected(object sender, InkCanvasStrokeCollectedEventArgs e)
        {
            StopTimer();

            var strokeId = strokeStore.AddStroke(e.Stroke);
            strokeToIdMap.Add(e.Stroke, strokeId);
            idToStrokeMap.Add(strokeId, e.Stroke);

            StartTimer();
        }
        // </InkCanvas_StrokeCollected>

        private async void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            StopTimer();

            try
            {
                var root = await AnalyzeInk();
                output.Text = OutputWriter.Print(root);
            }
            catch (Exception ex)
            {
                output.Text = OutputWriter.PrintError(ex.Message);
            }
        }

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

        // <AnalyzeInk>
        private async Task<RecognitionRoot> AnalyzeInk()
        {
            try
            {
                var selectedLanguage = (ComboBoxItem)LanguageComboBox.SelectedValue;
                var selectedApplicationKind = (ComboBoxItem)ApplicationKindComboBox.SelectedValue;
                var inkRecognizerClientOptions = new InkRecognizerClientOptions(InkRecognizerClientOptions.ServiceVersion.Preview1)
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
