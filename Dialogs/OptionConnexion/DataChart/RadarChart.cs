using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI.DataVisualization.Charting;
namespace TrevorBot.Dialogs.OptionConnexion.DataChart
{
    public class RadarChart
    {
        private string[] themes = new string[] {"Satisfaction", "Réalisation", "Barrière"," Face au stress", "Soutien", "Motivation", "Connaissance", "Changement" };

        public string GetLineChart(Dictionary<DateTime, double> points, string title)
        {
            // Create a series and add data points to it
            var series = new Series("Chart");
            foreach (var point in points)
            {
                series.Points.AddXY(point.Key, point.Value);
            }
            series.ChartType = SeriesChartType.Line;
            series.MarkerStyle = MarkerStyle.Circle;

            var chart = new Chart { Height = 800, Width = 800, Titles = { new Title(title) }};
            // Setup some styling

            chart.BackColor = Color.FromArgb(211, 223, 240);
            chart.BorderlineDashStyle = ChartDashStyle.Solid;
            chart.BackGradientStyle = GradientStyle.TopBottom;
            chart.BorderlineWidth = 1;
            chart.Palette = ChartColorPalette.BrightPastel;
            chart.BorderlineColor = Color.FromArgb(26, 59, 105);
            chart.RenderType = RenderType.BinaryStreaming;
            chart.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
            chart.AntiAliasing = AntiAliasingStyles.All;
            chart.TextAntiAliasingQuality = TextAntiAliasingQuality.Normal;

            // Add series to chart with area

            chart.Series.Add(series);
            var area = new ChartArea("Area");
            chart.ChartAreas.Add(area);
            chart.ChartAreas[0].AxisX.LabelStyle.Format = "t";

            // Save it to a stream

            var imageStream = new System.IO.MemoryStream();
            chart.SaveImage(imageStream, ChartImageFormat.Png);

            // Convert stream to base64 string

            var base64 = Convert.ToBase64String(imageStream.ToArray());

            // Return base64 string prefixed with the relevant data URL parameters

            return $"data:image/png;base64,{base64}";
        }



    }
}